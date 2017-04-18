using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace AutomationTool
{
    public partial class AutomationTool : Form
    {
        // This is the very first method called by the application. It initializes the UI controls and loads user settings.
        public AutomationTool()
        {
            InitializeComponent();

            // Load any saved settings
            LoadSettings();
        }


        // When the AutomationTool form is finished loading:
        // Create the tray icon, initialize some stuff with the file list, and start a new output log.
        private void AutomationTool_Load(object sender, EventArgs e)
        {
            // Set the tray icon
            trayIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            trayIcon.Text = "Zero Munge: Idle";

            // Set the visibility of the DataGridView buttons
            col_FileBrowse.UseColumnTextForButtonValue = true;
            col_StagingBrowse.UseColumnTextForButtonValue = true;
            col_MungedFilesButton.UseColumnTextForButtonValue = true;

            // Start a new log file
            string openMessage = "Opened logfile ZeroMunge_OutputLog.log  " + DateTime.Now.ToString("yyyy-MM-dd") +  " " + Modules.Utilities.GetTimestamp();
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\ZeroMunge_OutputLog.log", openMessage + Environment.NewLine);
        }


        /// <summary>
        /// Loads and initializes saved user settings.
        /// </summary>
        public void LoadSettings()
        {
            gameDirectory = Properties.Settings.Default["GameDirectory"].ToString();

            Debug.WriteLine("Loading GameDirectory: " + gameDirectory);
            Log("Loading GameDirectory: " + gameDirectory);
        }


        // ***************************
        // ** PROCESS MANAGER
        // ***************************

        private int ProcManager_activeFile;
        private Process ProcManager_curProc;
        private bool ProcManager_procAborted;
        private List<MungeFactory> ProcManager_fileList;

        /// <summary>
        /// Goes through the specified list of files and executes the ones that are checked.
        /// </summary>
        public void ProcManager_Start()
        {
            Thread soundThread = new Thread(() => {
                trayIcon.Text = "Zero Munge: Running";
                Modules.Utilities.PlaySound("start");
            });
            soundThread.Start();

            // Grab the list of checked files
            ProcManager_fileList = new List<MungeFactory>();
            ProcManager_fileList = GetCheckedFiles();

            ProcManager_activeFile = 0;
            ProcManager_procAborted = false;

            Thread enterThread = new Thread(() => {
                Log(Environment.NewLine, false);
                Log("**************************************************************");
                Log("******** ZeroMunge: Entered");
                Log("**************************************************************");
                Log(Environment.NewLine, false);
            });
            enterThread.Start();

            // Activate the first file
            ProcManager_ActivateProcess(0);
        }


        /// <summary>
        /// Use this to tell the manager when the active file has finished.
        /// </summary>
        /// <param name="whichFile"></param>
        /// <param name="singleFile"></param>
        private void ProcManager_NotifyProcessComplete(int whichFile, bool singleFile)
        {
            // Copy the compiled files to the staging directory
            List<string> filesToCopy = new List<string>();
            filesToCopy = ProcManager_fileList.ElementAt(whichFile).MungedFiles;

            string sourceDir = ProcManager_fileList.ElementAt(whichFile).MungeDir;
            string targetDir = ProcManager_fileList.ElementAt(whichFile).StagingDir;

            // Copy each file to the staging directory
            foreach (string file in filesToCopy)
            {
                // Assemble the full file paths
                var fullSourceFilePath = string.Concat(sourceDir, "\\", file);
                var fullTargetFilePath = string.Concat(targetDir, "\\", file);

                // Remove any duplicate backslashes
                fullSourceFilePath = fullSourceFilePath.Replace(@"\\", @"\");
                fullTargetFilePath = fullTargetFilePath.Replace(@"\\", @"\");


                // Make sure the source file exists before attempting to copy it
                if (!File.Exists(fullSourceFilePath))
                {
                    var message = "ERROR! Source file does not exist at path " + fullSourceFilePath;
                    Trace.WriteLine(message);
                    Log("ZeroMunge: " + message);
                }
                else
                {
                    // Create the target directory if it doesn't already exist
                    if (!Directory.Exists(targetDir))
                    {
                        try
                        {
                            Directory.CreateDirectory(targetDir);
                        }
                        catch (IOException e)
                        {
                            Trace.WriteLine(e.Message);
                            Log(e.Message);
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            Trace.WriteLine(e.Message);
                            Log(e.Message);

                            var message = "Try running the application with administrative privileges";
                            Trace.WriteLine(message);
                            Log("ZeroMunge: " + message);
                        }
                    }

                    // Copy the file
                    if (File.Exists(fullSourceFilePath))
                    {
                        try
                        {
                            File.Copy(fullSourceFilePath, fullTargetFilePath, true);

                            var message = "Successfully copied " + fullSourceFilePath + " to " + fullTargetFilePath;
                            Debug.WriteLine(message);
                            Log("ZeroMunge: " + message);
                        }
                        catch (IOException e)
                        {
                            Trace.WriteLine(e.Message);
                            Log(e.Message);
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            Trace.WriteLine(e.Message);
                            Log(e.Message);
                        }
                    }
                    else
                    {
                        var message = "ERROR! File does not exist at path " + fullSourceFilePath;
                        Trace.WriteLine(message);
                        Log("ZeroMunge: " + message);
                    }
                }
            }


            // Are we processing multiple files?
            if (!singleFile)
            {
                // If we've reached here, then all the processes are complete
                if (ProcManager_activeFile >= (ProcManager_fileList.Count - 1))
                {
                    // We have no more files, so finish up
                    ProcManager_Complete();
                }
                else
                {
                    // Move on to the next file
                    ProcManager_ActivateProcess(ProcManager_activeFile + 1);
                }
            }
            else
            {
                // We have no more files, so finish up
                ProcManager_Complete();
            }
        }


        /// <summary>
        /// Updates the current file number and starts its process.
        /// </summary>
        /// <param name="whichFile"></param>
        private void ProcManager_ActivateProcess(int whichFile)
        {
            // Don't advance to the next file if this is the last one
            if (whichFile > ProcManager_fileList.Count)
            {
                return;
            }

            ProcManager_activeFile = whichFile;

            ProcManager_curProc = ProcManager_StartProcess(ProcManager_fileList.ElementAt(ProcManager_activeFile).FileDir);

            //if (clist_Files.GetItemChecked(ProcManager_activeFile) == true)
            //{
            //    ProcManager_curProc = ProcManager_StartProcess(clist_Files.GetItemText(clist_Files.Items[ProcManager_activeFile]));
            //}
            //else
            //{
            //    ProcManager_NotifyProcessComplete(ProcManager_activeFile, false);
            //}
        }


        /// <summary>
        /// Executes the specified file in a new process.
        /// </summary>
        /// <param name="filePath">Full path of the file to execute.</param>
        /// <param name="singleFile">True to only execute a single file, false to notify the manager to execute the next file after this one is finished.</param>
        /// <returns>Process that was executed.</returns>
        private Process ProcManager_StartProcess(string filePath, bool singleFile = false)
        {

            // Initilialize process start info
            ProcessStartInfo startInfo = new ProcessStartInfo(@filePath)
            {
                WorkingDirectory = Modules.Utilities.GetFileDirectory(@filePath),
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            // Initialize the process
            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.EnableRaisingEvents = true;

            // Log any output data that's received
            proc.OutputDataReceived += ((sender, e) =>
            {
                if (!ProcManager_procAborted)
                {
                    Thread outputThread = new Thread(() => Log(e.Data));
                    outputThread.Start();
                }
            });


            // Print the file path before starting
            Thread initOutputThread = new Thread(() =>
            {
                Log("ZeroMunge: Executing file " + @filePath);
                Log(Environment.NewLine, false);
            });
            initOutputThread.Start();

            // Notify the manager that the process is done
            proc.Exited += ((sender, e) =>
            {
                // Don't send out exited messages if we've aborted
                if (!ProcManager_procAborted)
                {
                    Thread procExitThread = new Thread(() => {
                        Log("ZeroMunge: File done");
                    });
                    procExitThread.Start();

                    ProcManager_NotifyProcessComplete(ProcManager_activeFile, singleFile);
                }
            });


            // Start the process
            proc.Start();
            proc.BeginOutputReadLine();
            //proc.WaitForExit();
            //Thread.Sleep(5000);

            return proc;
        }


        /// <summary>
        /// Aborts the active process.
        /// </summary>
        public void ProcManager_Abort()
        {
            Thread soundThread = new Thread(() => {
                trayIcon.Text = "Zero Munge: Idle";
                Modules.Utilities.PlaySound("abort");
            });
            soundThread.Start();

            ProcManager_procAborted = true;

            // Kill the process
            ProcManager_curProc.Kill();

            // Reset the stored list of checked files
            ProcManager_fileList = null;

            Thread exitThread = new Thread(() => {
                Log(Environment.NewLine, false);
                Log("**************************************************************");
                Log("******** ZeroMunge: Aborted");
                Log("**************************************************************");

                // Re-enable the UI
                EnableUI(true);
            });
            exitThread.Start();
        }


        /// <summary>
        /// This is called after all the files have been processed.
        /// </summary>
        public void ProcManager_Complete()
        {
            Thread exitThread = new Thread(() => {
                Log(Environment.NewLine, false);
                Log("**************************************************************");
                Log("******** ZeroMunge: Exited");
                Log("**************************************************************");

                // Re-enable the UI
                EnableUI(true);
            });
            exitThread.Start();

            Thread soundThread = new Thread(() => {
                trayIcon.Text = "Zero Munge: Idle";
                trayIcon.BalloonTipTitle = "Success";
                trayIcon.BalloonTipText = "The operation was completed successfully.";
                trayIcon.ShowBalloonTip(30000);
                Modules.Utilities.PlaySound("success");
            });
            soundThread.Start();
        }


        // ***************************
        // ** OUTPUT LOG
        // ***************************

        // This method is executed on the worker thread and makes a thread-safe call on the RichTextBox control.
        /// <summary>
        /// Prints the specified text to the output log.
        /// </summary>
        /// <param name="message">Text to print.</param>
        /// <param name="newLine">Optional: True to append a new line to the end of the message.</param>
        public void Log(string message, bool newLine = true)
        {
            Log_Proc(message, newLine);
        }


        // This delegate enables asynchronous calls for setting the text property on the output log.
        delegate void LogCallback(string message, bool newLine = true);


        /// <summary>
        /// Prints the specified text to the output log.  
        /// WARNING: Don't call this directly, please call `Log` instead.
        /// </summary>
        /// <param name="message">Text to print.</param>
        /// <param name="newLine">Optional: True to append a new line to the end of the message.</param>
        private void Log_Proc(string message, bool newLine = true)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true.
            if (text_OutputLog.InvokeRequired)
            {
                LogCallback cb = new LogCallback(Log_Proc);
                BeginInvoke(cb, new object[] { message, newLine });
            }
            else
            {
                if (!string.IsNullOrEmpty(message))
                {
                    // Assemble message
                    string messageToLog = string.Concat(Modules.Utilities.GetTimestamp(), " : ", message);

                    // Print message
                    text_OutputLog.AppendText(messageToLog);

                    // Are we supposed to print a new line?
                    if (newLine)
                    {
                        // Print message on new line
                        text_OutputLog.AppendText(Environment.NewLine);
                    }

                    // Log the message to the log file
                    StreamWriter sw = File.AppendText(string.Concat(Directory.GetCurrentDirectory(), @"\ZeroMunge_OutputLog.log"));
                    sw.WriteLine(messageToLog);
                    sw.Close();

                    // Is the output log full?
                    if (text_OutputLog.TextLength >= (text_OutputLog.MaxLength - 500))
                    {
                        // Make sure the text box is still populated
                        if (text_OutputLog.Lines.Count() > 0)
                        {
                            text_OutputLog.Select(0, text_OutputLog.Text.IndexOf('\n') + 1);
                            int a = text_OutputLog.SelectionStart;
                            int b = text_OutputLog.SelectionLength;
                            text_OutputLog.Text = text_OutputLog.Text.Remove(a, b);

                            // Get the lines of text
                            /*string[] lineArray = text_OutputLog.Lines;

                            // Create a collection so that a line can be removed
                            var lineCollection = new List<string>(lineArray);

                            // Remove the first line
                            lineCollection.RemoveAt(0);

                            // Convert the collection back to an array
                            lineArray = lineCollection.ToArray();

                            // Display the new data in the control
                            text_OutputLog.Lines = lineArray;*/
                        }
                    }

                    // Auto-scroll to the most recent line
                    text_OutputLog.Select(text_OutputLog.Text.Length, text_OutputLog.Text.Length);
                    text_OutputLog.ScrollToCaret();
                }
            }
        }



        // ***************************
        // ** TOGGLE UI
        // ***************************

        // This method is executed on the worker thread and makes a thread-safe call on the UI controls.
        /// <summary>
        /// Sets the enabled state of the application's UI controls.
        /// </summary>
        /// <param name="enabled">True to enable UI interactivity, false to disable.</param>
        public void EnableUI(bool enabled)
        {
            EnableUI_Proc(enabled);
        }
        

        // This delegate enables asynchronous calls for setting the enabled property on the UI control.
        delegate void EnableUICallback(bool enabled);
        

        /// <summary>
        /// Sets the enabled state of the application's UI controls.  
        /// WARNING: Don't call this directly, please call `EnableUI` instead.
        /// </summary>
        /// <param name="enabled">True to enable UI interactivity, false to disable.</param>
        private void EnableUI_Proc(bool enabled)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true.
            if (InvokeRequired)
            {
                EnableUICallback cb = new EnableUICallback(EnableUI_Proc);
                BeginInvoke(cb, new object[] { enabled });
            }
            else
            {
                // Buttons
                btn_Run.Enabled = enabled;
                btn_Cancel.Enabled = !enabled;
                btn_AddFiles.Enabled = enabled;
                btn_AddFolders.Enabled = enabled;
                btn_AddProject.Enabled = enabled;
                btn_RemoveFile.Enabled = enabled;
                btn_RemoveAllFiles.Enabled = enabled;
                btn_SetGamePath.Enabled = enabled;
                btn_CopyLog.Enabled = enabled;
                btn_SaveLog.Enabled = enabled;
                btn_ClearLog.Enabled = enabled;

                // File list
                data_Files.Enabled = enabled;

                // Tray icon context menu
                cmenu_TrayIcon_Quit.Enabled = enabled;
            }
        }



        // ***************************
        // ** WINDOWS FORMS CONTROLS
        // ***************************

        /// <summary>
        /// SWBF2's GameData directory.
        /// </summary>
        public string gameDirectory = "";

        /// <summary>
        /// Index of currently selected row in data_Files.
        /// </summary>
        public int data_Files_CurSelectedRow = -1;

        /// <summary>
        /// Index of currently selected column in data_Files.
        /// </summary>
        public int data_Files_CurSelectedColumn = -1;

        /// <summary>
        /// Folder selection prompt for setting the staging directory of the currently selected row in the DataGridView.
        /// </summary>
        public CommonOpenFileDialog openDlg_SetStagingPrompt = new CommonOpenFileDialog();

        /// <summary>
        /// Folder selection prompt for adding folders to the DataGridView.
        /// </summary>
        public CommonOpenFileDialog openDlg_AddFoldersPrompt = new CommonOpenFileDialog();

        /// <summary>
        /// Folder selection prompt for adding projects to the DataGridView.
        /// </summary>
        public CommonOpenFileDialog openDlg_AddProjectPrompt = new CommonOpenFileDialog();

        /// <summary>
        /// Folder selection prompt for selecting SWBF2's GameData directory.
        /// </summary>
        public CommonOpenFileDialog openDlg_SetGamePathPrompt = new CommonOpenFileDialog();

        /// <summary>
        /// Last directory user was in for the openDlg_SetStagingPrompt.
        /// </summary>
        public string setStagingLastDir = Directory.GetCurrentDirectory();

        /// <summary>
        /// Last directory user was in for the openDlg_AddFilesPrompt.
        /// </summary>
        public string addFilesLastDir = Directory.GetCurrentDirectory();

        /// <summary>
        /// Last directory user was in for the openDlg_AddFoldersPrompt.
        /// </summary>
        public string addFoldersLastDir = Directory.GetCurrentDirectory();

        /// <summary>
        /// Last directory user was in for the openDlg_AddProjectPrompt.
        /// </summary>
        public string addProjectLastDir = Directory.GetCurrentDirectory();

        /// <summary>
        /// Common munge scripts for a typical project.
        /// </summary>
        public string[] addProject_CommonFiles = {
            "\\_BUILD\\Common\\munge.bat",
            "\\_BUILD\\Sides\\ALL\\munge.bat",
            "\\_BUILD\\Sides\\CIS\\munge.bat",
            "\\_BUILD\\Sides\\IMP\\munge.bat",
            "\\_BUILD\\Sides\\REP\\munge.bat",
            "\\_BUILD\\Sides\\TUR\\munge.bat",
            "\\_BUILD\\Worlds\\@#$\\munge.bat",
            "\\addme\\mungeAddme.bat"
        };


        /// <summary>
        /// Returns a list of files that are currently checkmarked in the file list.
        /// </summary>
        /// <returns>List<MungeFactory> of files that are checkmarked.</MungeFactory></returns>
        private List<MungeFactory> GetCheckedFiles()
        {
            var checkedFiles = new List<MungeFactory>();

            Debug.WriteLine("There are " + (data_Files.RowCount - 1) + " rows");

            foreach (DataGridViewRow row in data_Files.Rows)
            {
                Debug.WriteLine("Row " + row.Index + ", entered");

                // Add the file to the list if all its fields are correct and valid (note: StagingDirectory isn't required)
                if (row.Cells[0].Value != null &&
                    row.Cells[1].Value != null &&
                    row.Cells[5].Value != null)
                {
                    if (row.Cells[0].Value.ToString() == "True")
                    {
                        Thread errorThread = new Thread(() => {
                            if (row.Cells[0].Value == null)
                            {
                                Debug.WriteLine("WARNING! Row at index " + row.Index + " isn't enabled!");
                            }

                            if (String.IsNullOrEmpty(row.Cells[1].Value.ToString()))
                            {
                                var message = "ERROR! FilePath at row index " + row.Index + " isn't specified!";
                                Debug.WriteLine(message);
                                Log("ZeroMunge: " + message);
                            }

                            if (String.IsNullOrEmpty(row.Cells[3].Value.ToString()))
                            {
                                var message = "WARNING! StagingDirectory at row index " + row.Index + " isn't specified!";
                                Debug.WriteLine(message);
                                Log("ZeroMunge: " + message);
                            }

                            if (String.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                            {
                                var message = "ERROR! MungeDirectory at row index " + row.Index + " isn't specified!";
                                Debug.WriteLine(message);
                                Log("ZeroMunge: " + message);
                            }

                            if (String.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                            {
                                var message = "ERROR! MungeDirectory at row index " + row.Index + " isn't specified!";
                                Debug.WriteLine(message);
                                Log("ZeroMunge: " + message);
                            }

                            if (String.IsNullOrEmpty(row.Cells[6].Value.ToString()))
                            {
                                var message = "WARNING! MungedFiles at row index " + row.Index + " isn't specified!";
                                Debug.WriteLine(message);
                                Log("ZeroMunge: " + message);
                            }


                            if (!File.Exists(row.Cells[1].Value.ToString()))
                            {
                                var message = "ERROR! FilePath at row index " + row.Index + " cannot be found!";
                                Debug.WriteLine(message);
                                Log("ZeroMunge: " + message);
                            }
                        });
                        errorThread.Start();

                        Debug.WriteLine(row.Cells[1].Value.ToString());
                        if (row.Cells[3].Value != null)
                        {
                            Debug.WriteLine(row.Cells[3].Value.ToString());
                        }
                        Debug.WriteLine(row.Cells[5].Value.ToString());


                        // Construct a new MungeFactory object and initialize our data into it
                        MungeFactory fileInfo = new MungeFactory();

                        fileInfo.FileDir = row.Cells[1].Value.ToString();

                        if (row.Cells[3].Value != null)
                        {
                            fileInfo.StagingDir = row.Cells[3].Value.ToString();
                        }

                        fileInfo.MungeDir = row.Cells[5].Value.ToString();

                        if (row.Cells[6].Value != null)
                        {
                            fileInfo.MungedFiles = Modules.Utilities.ExtractLines(row.Cells[6].Value.ToString());
                        }


                        // Add our MungeFactory object to the checked files list
                        checkedFiles.Add(fileInfo);
                    }
                    else
                    {
                        Debug.WriteLine("WARNING! Row at index " + row.Index + " isn't enabled!");
                    }
                }
            }

            return checkedFiles;
        }


        /// <summary>
        /// Adds the specified file path to the file list.
        /// </summary>
        /// <param name="file">Full path of file to add.</param>
        /// <returns>True if the file was successfully added, false if not.</returns>
        private bool AddFile(string file)
        {
            // Does the file path exist?
            if (File.Exists(file))
            {
                // Add the file to the list
                if (data_Files.SelectedCells.Count >= 0)
                {
                    // Auto-set the staging directory if the game directory has been set
                    if (gameDirectory != "")
                    {
                        string projectStagingRoot = gameDirectory + "\\addon\\" + Modules.Utilities.GetProjectID(file);
                        string stagingDirectory = "";
                        string mungeOutputDirectory = "";
                        string compiledFiles = "";

                        Debug.WriteLine(Modules.Utilities.GetProjectID(file));

                        // Set the file's staging directory based on the file's munge type (e.g., side, world, common)
                        switch (Modules.Utilities.GetMungeType(file))
                        {
                            default:
                                stagingDirectory = "nil";
                                break;
                            case Modules.Utilities.MungeTypes.Addme:
                                stagingDirectory = projectStagingRoot + "\\";
                                break;
                            case Modules.Utilities.MungeTypes.Common:
                                stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\";
                                break;
                            case Modules.Utilities.MungeTypes.Load:
                                stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\Load\\";
                                break;
                            case Modules.Utilities.MungeTypes.Shell:
                                stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\";
                                break;
                            case Modules.Utilities.MungeTypes.Side:
                                stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\SIDE\\";
                                break;
                            case Modules.Utilities.MungeTypes.Sound:
                                stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\Sound\\";
                                break;
                            case Modules.Utilities.MungeTypes.World:
                                stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\" + Modules.Utilities.GetProjectID(file) + "\\";
                                break;
                        }

                        // Get the file's munge output directory
                        mungeOutputDirectory = Modules.Utilities.GetMungeDirectory(file);


                        // Remove any duplicate backslashes
                        file = file.Replace(@"\\", @"\");
                        stagingDirectory = stagingDirectory.Replace(@"\\", @"\");
                        mungeOutputDirectory = mungeOutputDirectory.Replace(@"\\", @"\");


                        foreach (string compiledFile in Modules.Utilities.GetCompiledFiles(file))
                        {
                            compiledFiles = string.Concat(compiledFiles, compiledFile, "\n");
                        }
                        

                        // Are none of the rows selected? (i.e., did the user click the "Add Files..." button?)
                        if (data_Files_CurSelectedRow == -1)
                        {
                            // Create a new row first
                            int rowId = data_Files.Rows.Add();

                            // Grab the new row
                            DataGridViewRow newRow = data_Files.Rows[rowId];

                            // Initialize data into the new row
                            newRow.Cells[0].Value = true;
                            newRow.Cells[1].Value = file;
                            newRow.Cells[3].Value = stagingDirectory;
                            newRow.Cells[5].Value = mungeOutputDirectory;
                            newRow.Cells[6].Value = compiledFiles;
                        }
                        else
                        {
                            // Add a blank row to the bottom of the list
                            data_Files.Rows.Add();

                            // Initialize data into the new row
                            data_Files[0, data_Files_CurSelectedRow].Value = true;
                            data_Files[1, data_Files_CurSelectedRow].Value = file;
                            data_Files[3, data_Files_CurSelectedRow].Value = stagingDirectory;
                            data_Files[5, data_Files_CurSelectedRow].Value = mungeOutputDirectory;
                            data_Files[6, data_Files_CurSelectedRow].Value = compiledFiles;
                        }

                        
                        Thread logThread = new Thread(() => {
                            Log(Environment.NewLine, false);
                            Log("ZeroMunge: Adding file: " + file);
                            Log("ZeroMunge: Staging directory: " + stagingDirectory);
                            Log("ZeroMunge: Munge output directory: " + mungeOutputDirectory);
                        });
                        logThread.Start();


                        // Reset the stored index of the currently selected row
                        data_Files_CurSelectedRow = -1;
                    }
                    else
                    {
                        Thread errorThread = new Thread(() => {
                            Log("ZeroMunge: ERROR! Game directory not set!");
                        });
                        errorThread.Start();
                    }
                }

                return true;
            }
            else
            {
                Thread outputThread = new Thread(() => {
                    Log("ZeroMunge: ERROR! " + file + " not found");
                });
                outputThread.Start();

                return false;
            }
        }


        // When the user clicks on a cell:
        // Reset the currently selected row header index.
        private void data_Files_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            // Reset the currently selected header row
            if (e.RowIndex >= 0)
            {
                Debug.WriteLine("Cell clicked at row index " + e.RowIndex + ", column index " + e.ColumnIndex);

                data_Files_CurSelectedRow = e.RowIndex;
                data_Files_CurSelectedColumn = e.ColumnIndex;

                //Debug.WriteLine("Selected header row: " + data_Files_CurSelectedHeaderRow);
            }
        }


        // When the user clicks on a cell in the DataGridView:
        // Do something depending on the cell that was clicked on.
        private void data_Files_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            // Debug messages
            if (e.RowIndex >= 0)
            {
                string cellType = "nil";

                // Determine the cell type
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
                {
                    cellType = "TextBox";
                }
                else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    cellType = "Button";
                }
                else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    cellType = "CheckBox";
                }

                Debug.WriteLine(cellType + " cell content clicked at row index " + e.RowIndex + ", column index " + e.ColumnIndex);
            }

            // Do stuff if the clicked cell's type was Button
            switch (data_Files_CurSelectedColumn)
            {
                case 2:     // col_FileBrowse
                    // Open the 'Add Files' prompt
                    openDlg_AddFilesPrompt.InitialDirectory = addFilesLastDir;
                    openDlg_AddFilesPrompt.ShowDialog();
                    break;
                        
                case 4:     // col_StagingBrowse
                    // Fire the faux-event for the button
                    btn_SetStaging_Click();
                    break;
            }
        }


        // This is called when the user clicks the Browse button to select a new staging directory for a file.
        // Prompt the user to select a new staging directory for the currently selected file.
        private void btn_SetStaging_Click()
        {
            openDlg_SetStagingPrompt.Title = "Select Staging Directory";
            openDlg_SetStagingPrompt.InitialDirectory = data_Files[2, data_Files_CurSelectedRow].Value.ToString();
            openDlg_SetStagingPrompt.IsFolderPicker = true;
            openDlg_SetStagingPrompt.Multiselect = false;

            // Auto-detect the munge.bat file inside each selected folder and add it to the file list
            if (openDlg_SetStagingPrompt.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var folder = openDlg_SetStagingPrompt.FileName;

                // Save the current directory
                setStagingLastDir = Modules.Utilities.GetFileDirectory(folder);

                // Set the staging directory if it exists
                if (Directory.Exists(folder))
                {
                    data_Files[3, data_Files_CurSelectedRow].Value = folder;
                }
            }
        }


        // When the user clicks the "Run" button:
        // Begin processing the list of files as a playlist.
        private void btn_Run_Click(object sender, EventArgs e)
        {
            int procError = 0;

            // Are there no items in the list?
            if (data_Files.RowCount == 1)
            {
                if (data_Files.Rows[0].Cells[1].Value == null ||
                    data_Files.Rows[0].Cells[3].Value == null ||
                    data_Files.Rows[0].Cells[5].Value == null)
                {
                    procError = 1;
                }
            }
            else
            {
                var files = GetCheckedFiles();

                // Are none of the items checked?
                if (files.Count <= 0)
                {
                    procError = 2;
                }
            }
            
            // Report the error if one is present
            if (procError > 0)
            {
                Thread errorThread = new Thread(() => {
                    string errorMessage = "";

                    switch (procError)
                    {
                        case 1:
                            errorMessage = "ZeroMunge: ERROR! File list must contain at least one file";
                            break;
                        case 2:
                            errorMessage = "ZeroMunge: ERROR! At least one item must be checked";
                            break;
                    }

                    Log(errorMessage);

                    // Re-enable the UI
                    EnableUI(true);
                });
                errorThread.Start();

                return;
            }

            // Disable the UI
            EnableUI(false);

            ProcManager_Start();
        }


        // When the user clicks the "Cancel" button:
        // Abort the active process and stop processing files.
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ProcManager_Abort();
        }


        // When the user clicks the "Add Files..." button:
        // Prompt the user to select files to add to the file list.
        private void btn_AddFiles_Click(object sender, EventArgs e)
        {
            openDlg_AddFilesPrompt.InitialDirectory = addFilesLastDir;

            // Open the 'Add Files' prompt
            openDlg_AddFilesPrompt.ShowDialog();
        }


        // When the user clicks the "OK" button in the "Add Files..." prompt:
        // Add the selected files to the file list.
        private void openDlg_AddFilesPrompt_FileOk(object sender, CancelEventArgs e)
        {
            string file = openDlg_AddFilesPrompt.FileName;

            // Save the current directory
            addFilesLastDir = Modules.Utilities.GetFileDirectory(file);

            // Add the file to the list
            AddFile(file);
        }


        // When the user clicks the "Add Folders..." button:
        // Prompt the user to select folders containing munge.bat files to add to the file list.
        private void btn_AddFolders_Click(object sender, EventArgs e)
        {
            openDlg_AddFoldersPrompt.Title = "Select Folders";
            openDlg_AddFoldersPrompt.InitialDirectory = addFoldersLastDir;
            openDlg_AddFoldersPrompt.IsFolderPicker = true;
            openDlg_AddFoldersPrompt.Multiselect = true;

            // Auto-detect the munge.bat file inside each selected folder and add it to the file list
            if (openDlg_AddFoldersPrompt.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // Parse each folder that was selected
                foreach (string folder in openDlg_AddFoldersPrompt.FileNames)
                {
                    // Set the file path of the munge.bat file
                    var file = folder + "\\munge.bat";

                    // Save the current directory
                    addFoldersLastDir = Modules.Utilities.GetFileDirectory(folder);
                    
                    // Add the file to the list
                    AddFile(file);
                }
            }
        }


        // When the user clicks the "Add Project..." button:
        // Prompt the user to select a project to add to the file list.
        private void btn_AddProject_Click(object sender, EventArgs e)
        {
            openDlg_AddProjectPrompt.Title = "Select Project Folder";
            openDlg_AddProjectPrompt.InitialDirectory = addProjectLastDir;
            openDlg_AddProjectPrompt.IsFolderPicker = true;
            //openDlg_AddProjectPrompt.Multiselect = true;

            // Auto-detect the munge.bat file inside each selected folder and add it to the file list
            if (openDlg_AddProjectPrompt.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // Get the project ID
                var projectID = Modules.Utilities.GetProjectID(openDlg_AddProjectPrompt.FileName);


                // Add all common munge.bat files in the project folder
                foreach (string file in addProject_CommonFiles)
                {
                    // Store in editable field
                    var theFile = file;

                    // Is the current file the World munge.bat?
                    if (theFile.Contains("@#$"))
                    {
                        theFile = theFile.Replace("@#$", projectID);
                    }

                    // Set the complete file path of the munge.bat file
                    var path = openDlg_AddProjectPrompt.FileName + theFile;

                    // Save the current directory
                    addProjectLastDir = Modules.Utilities.GetFileDirectory(openDlg_AddProjectPrompt.FileName);

                    // Add the file to the list
                    AddFile(path);
                }
            }
        }


        // When the user clicks the "Remove" button:
        // Remove the selected file from the file list.
        private void btn_RemoveFile_Click(object sender, EventArgs e)
        {
            // Don't continue if there aren't any files in the list
            if (data_Files.RowCount <= 0)
            {
                Thread errorThread = new Thread(() => {
                    Log("ZeroMunge: ERROR! File list must contain at least one file");

                    // Re-enable the UI
                    EnableUI(true);
                });
                errorThread.Start();

                return;
            }

            // Is the currently selected column the row header?
            if (data_Files_CurSelectedColumn == -1)
            {
                if (data_Files_CurSelectedRow == data_Files.RowCount)
                {
                    // Remove the currently selected file from the list
                    data_Files.Rows.RemoveAt(data_Files_CurSelectedRow);
                }
                else
                {
                    Thread errorThread = new Thread(() => {
                        Log("ZeroMunge: ERROR! Cannot remove the last (uncommitted) row");

                        // Re-enable the UI
                        EnableUI(true);
                    });
                    errorThread.Start();
                }
            }
        }


        // When the user clicks the "Remove All" button:
        // Remove all files from the file list.
        private void btn_RemoveAllFiles_Click(object sender, EventArgs e)
        {
            // Is there at least 1 committed row to remove?
            if (data_Files.RowCount > 1)
            {
                Debug.WriteLine("Rows to remove: " + (data_Files.RowCount - 1));

                // Keep removing the topmost row until only 1 row remains
                do
                {
                    data_Files.Rows.RemoveAt(data_Files.Rows[0].Index);
                    Debug.WriteLine("Rows remaining: " + (data_Files.RowCount - 1));
                } while (data_Files.RowCount > 1);
            }
            else
            {
                Thread errorThread = new Thread(() =>
                {
                    Log("ZeroMunge: ERROR! File list must contain at least one file");

                    // Re-enable the UI
                    EnableUI(true);
                });
                errorThread.Start();
            }
        }


        // When the user clicks the "Set Game Path..." button:
        // Prompt the user to select the file path of SWBF2's executable.
        private void btn_SetGamePath_Click(object sender, EventArgs e)
        {
            openDlg_SelectGameExePrompt.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            openDlg_SelectGameExePrompt.ShowDialog();
        }


        // When the user clicks the "OK" button in the "Select Game Executable..." prompt:
        // Sets the game directory based on the file path of SWBF2's executable.
        private void openDlg_SelectGameExePrompt_FileOk(object sender, CancelEventArgs e)
        {
            var file = openDlg_SelectGameExePrompt.FileName;

            // Set the game path if it exists
            if (Directory.Exists(Modules.Utilities.GetFileDirectory(file)))
            {
                gameDirectory = Modules.Utilities.GetFileDirectory(file);

                Properties.Settings.Default["GameDirectory"] = gameDirectory;
                Properties.Settings.Default.Save();

                Thread outputThread = new Thread(() => {
                    Debug.WriteLine("Saving GameDirectory: " + Properties.Settings.Default["GameDirectory"]);
                    Log("ZeroMunge: Saving GameDirectory: " + Properties.Settings.Default["GameDirectory"]);
                });
                outputThread.Start();
            }
        }


        // When the user clicks the "Copy Log" button:
        // Copy the contents of the output log window to the clipboard.
        private void btn_CopyLog_Click(object sender, EventArgs e)
        {
            text_OutputLog.SelectAll();
            text_OutputLog.Copy();
            text_OutputLog.DeselectAll();
        }


        // When the user clicks the "Save Log As..." button:
        // Prompt the user to save the output log to a new file.
        private void btn_SaveLog_Click(object sender, EventArgs e)
        {
            saveDlg_SaveLogPrompt.FileName = "ZeroMunge_OutputLog_" + DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss");
            saveDlg_SaveLogPrompt.ShowDialog();
        }

        
        // When the user clicks the "OK" button in the "Save Log As" prompt:
        // Save the contents of the entire output log to a new file.
        private void saveDlg_SaveLogPrompt_FileOk(object sender, CancelEventArgs e)
        {
            // Has a file name been entered?
            if (saveDlg_SaveLogPrompt.FileName != "")
            {
                // Get the file name
                string name = saveDlg_SaveLogPrompt.FileName;

                Log("ZeroMunge: Saved logfile as " + name);

                // Write the output log's contents to the file
                File.WriteAllLines(name, text_OutputLog.Lines);
            }
        }


        // When the user clicks the "Clear Log" button:
        // Clear the entire contents of the output log.
        private void btn_ClearLog_Click(object sender, EventArgs e)
        {
            text_OutputLog.Clear();
        }


        // When the output log's text is changed:
        // Scroll to the bottom of the output log, deal with the log being full, and update the line count.
        private void text_OutputLog_TextChanged(object sender, EventArgs e)
        {
            // Update character count
            lbl_OutputLogChars.Text = string.Concat("Length: ", text_OutputLog.Text.Count().ToString());

            // Update line count
            lbl_OutputLogLines.Text = string.Concat("Lines: ", text_OutputLog.Lines.Count().ToString());
        }


        // Set the initial state of the window
        FormWindowState lastWindowState = FormWindowState.Minimized;
        FormWindowState lastWindowSize = FormWindowState.Normal;

        // When the user resizes the window by dragging the handles, maximizing, restoring, or minimizing:
        // Store the WindowState for future reference when the user double-clicks the trayIcon.
        private void AutomationTool_Resize(object sender, EventArgs e)
        {
            Debug.WriteLine("WindowState changed");
            lastWindowState = WindowState;
            
            if (WindowState == FormWindowState.Maximized)
            {
                Debug.WriteLine("WindowState: Maximized");
                lastWindowSize = FormWindowState.Maximized;
            }
            if (WindowState == FormWindowState.Normal)
            {
                Debug.WriteLine("WindowState: Normal");
                lastWindowSize = FormWindowState.Normal;
            }
        }


        // When the user double-clicks the tray icon:
        // Restore the form to its previous WindowState.
        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = lastWindowSize;
        }


        // When the user clicks any of the balloon tips that pop up:
        // Restore the form to its previous WindowState.
        private void trayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            WindowState = lastWindowSize;
        }


        // When the user clicks the "Open" item in the tray icon context menu:
        // Restore the form to its previous WindowState.
        private void cmenu_TrayIcon_Open_Click(object sender, EventArgs e)
        {
            WindowState = lastWindowSize;
        }


        // When the user clicks the "Quit" item in the tray icon context menu:
        // Exit the application.
        private void cmenu_TrayIcon_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            files.Add(@"testfile1.txt");
            files.Add(@"testfile2.txt");
            files.Add(@"testfile3.txt");

            string targetDir = @"Y:\ZeroMungeFileTests\target";
            string sourceDir = @"Y:\ZeroMungeFileTests\source";

            foreach (string file in files)
            {
                Debug.WriteLine(targetDir + "\\" + file);

                File.Copy(string.Concat(targetDir, "\\", file), string.Concat(sourceDir, "\\", file), true);
            }

            //string compiledFiles = "";

            //foreach (string compiledFile in Modules.Utilities.GetCompiledFiles(@"J:\BF2_ModTools\data_MEU\data_ME5\_BUILD\Common\munge.bat"))
            //{
            //    compiledFiles = string.Concat(compiledFiles, compiledFile, "\n");
            //}

            //Modules.Utilities.ExtractLines(compiledFiles);

            //Modules.Utilities.ParseLevelpackReqs(@"J:\BF2_ModTools\data_MEU\data_ME5\_BUILD\Common\munge.bat");
            //Modules.Utilities.GetCompiledFiles(@"J:\BF2_ModTools\data_MEU\data_ME5\_BUILD\Sides\CON_COL\munge_col.bat");
        }
    }

    public class MungeFactory
    {
        public string FileDir { get; set; }
        public string StagingDir { get; set; }
        public string MungeDir { get; set; }
        public List<string> MungedFiles { get; set; }
    }
}
