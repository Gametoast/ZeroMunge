using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace SWBF2_AutomationTool
{
    public partial class AutomationTool : Form
    {
        public AutomationTool()
        {
            InitializeComponent();
        }

        private void AutomationTool_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Returns the directory of the specified file path.  
        /// Example: Inputting "C:\Documents\foo.bar" would return "C:\Documents"
        /// </summary>
        /// <param name="filePath">Path of file to get directory from.</param>
        /// <returns>Directory of the specified file path.</returns>
        private string GetFileDirectory(string filePath)
        {
            // Get the file's directory
            string filePathDir = "";
            int index = filePath.LastIndexOf(@"\");
            if (index > 0)
            {
                filePathDir = filePath.Substring(0, index); // or index + 1 to keep slash
            }

            return filePathDir;
        }


        /// <summary>
        /// Returns the project ID of the project in the specified file path.  
        /// Example: Inputting "C:\BF2_ModTools\data_ABC" would return "ABC"
        /// </summary>
        /// <param name="filePath">Path of file to get project ID from.</param>
        /// <returns>Project ID of the project in the specified file path.</returns>
        private string GetProjectID(string filePath)
        {
            // Get the project ID
            string projectID = "";
            int index = filePath.LastIndexOf("data_");
            if (index > 0)
            {
                projectID = filePath.Substring(index + 5);
            }

            return projectID;
        }


        /// <summary>
        /// Returns the current time in 12-hour format, e.g. "12:40:34 AM".
        /// </summary>
        /// <returns>Current time in 12-hour format.</returns>
        private string GetTimestamp()
        {
            return DateTime.Now.ToString("h:mm:ss tt");
        }



        // ***************************
        // ** PROCESS MANAGER
        // ***************************

        private int procManager_activeFile;
        private Process procManager_curProc;
        private bool procManager_procAborted;

        /// <summary>
        /// Goes through the specified list of files and executes the ones that are checked.
        /// </summary>
        public void ProcManager_Start()
        {
            procManager_activeFile = 0;
            procManager_procAborted = false;

            Thread enterThread = new Thread(() => {
                LogOutput_Proc(Environment.NewLine, false);
                LogOutput_Proc("**************************************************************");
                LogOutput_Proc("******** AutomationTool: Entered");
                LogOutput_Proc("**************************************************************");
                LogOutput_Proc(Environment.NewLine, false);
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
            // Are we processing multiple files?
            if (!singleFile)
            {
                // If we've reached here, then all the processes are complete
                if (procManager_activeFile >= (clist_Files.Items.Count - 1))
                {
                    // We have no more files, so finish up
                    ProcManager_Complete();
                }
                else
                {
                    // Move on to the next file
                    ProcManager_ActivateProcess(procManager_activeFile + 1);
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
            if (whichFile > clist_Files.Items.Count)
            {
                return;
            }

            procManager_activeFile = whichFile;
            if (clist_Files.GetItemChecked(procManager_activeFile) == true)
            {
                procManager_curProc = ProcManager_StartProcess(clist_Files.GetItemText(clist_Files.Items[procManager_activeFile]));
            }
            else
            {
                ProcManager_NotifyProcessComplete(procManager_activeFile);
            }
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
                WorkingDirectory = GetFileDirectory(filePath),
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
                if (!procManager_procAborted)
                {
                    Thread outputThread = new Thread(() => LogOutput_Proc(e.Data));
                    outputThread.Start();
                }
            });


            // Print the file path before starting
            Thread initOutputThread = new Thread(() =>
            {
                LogOutput_Proc("AutomationTool: Executing file " + filePath);
                LogOutput_Proc(Environment.NewLine, false);
            });
            initOutputThread.Start();

            // Notify the manager that the process is done
            proc.Exited += ((sender, e) =>
            {
                // Don't send out exited messages if we've aborted
                if (!procManager_procAborted)
                {
                    Thread procExitThread = new Thread(() => {
                        LogOutput_Proc("AutomationTool: File done");
                    });
                    procExitThread.Start();
                    
                    ProcManager_NotifyProcessComplete(procManager_activeFile, singleFile);
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
            procManager_procAborted = true;

            // Kill the process
            procManager_curProc.Kill();

            Thread exitThread = new Thread(() => {
                LogOutput_Proc(Environment.NewLine, false);
                LogOutput_Proc("**************************************************************");
                LogOutput_Proc("******** AutomationTool: Aborted");
                LogOutput_Proc("**************************************************************");

                // Re-enable the UI
                EnableUI_Proc(true);
            });
            exitThread.Start();
        }


        /// <summary>
        /// This is called after all the files have been processed.
        /// </summary>
        public void ProcManager_Complete()
        {
            Thread exitThread = new Thread(() => {
                LogOutput_Proc(Environment.NewLine, false);
                LogOutput_Proc("**************************************************************");
                LogOutput_Proc("******** AutomationTool: Exited");
                LogOutput_Proc("**************************************************************");

                // Re-enable the UI
                EnableUI_Proc(true);
            });
            exitThread.Start();
        }



        // ***************************
        // ** TOGGLE UI
        // ***************************

        // This method is executed on the worker thread and makes a thread-safe call on the UI controls.
        /// <summary>
        /// Sets the enabled state of the application's UI controls.
        /// </summary>
        /// <param name="enabled">True to enable UI interactivity, false to disable.</param>
        public void EnableUI_Proc(bool enabled)
        {
            EnableUI(enabled);
        }
        

        // This delegate enables asynchronous calls for setting the enabled property on the UI control.
        delegate void EnableUICallback(bool enabled);
        

        /// <summary>
        /// Sets the enabled state of the application's UI controls.  
        /// WARNING: Don't call this directly, please call `EnableUI_Proc` instead.
        /// </summary>
        /// <param name="enabled">True to enable UI interactivity, false to disable.</param>
        private void EnableUI(bool enabled)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true.
            if (InvokeRequired)
            {
                EnableUICallback cb = new EnableUICallback(EnableUI);
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
                btn_CopyLog.Enabled = enabled;
                btn_SaveLog.Enabled = enabled;
                btn_ClearLog.Enabled = enabled;

                // File list
                clist_Files.Enabled = enabled;
            }
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
        public void LogOutput_Proc(string message, bool newLine = true)
        {
            LogOutput(message, newLine);
        }
        

        // This delegate enables asynchronous calls for setting the text property on a RichTextBox control.
        delegate void LogOutputCallback(string message, bool newLine = true);


        /// <summary>
        /// Prints the specified text to the output log.  
        /// WARNING: Don't call this directly, please call `LogOutput_Proc` instead.
        /// </summary>
        /// <param name="message">Text to print.</param>
        /// <param name="newLine">Optional: True to append a new line to the end of the message.</param>
        private void LogOutput(string message, bool newLine = true)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true.
            if (text_OutputLog.InvokeRequired)
            {
                LogOutputCallback cb = new LogOutputCallback(LogOutput);
                BeginInvoke(cb, new object[] { message, newLine });
            }
            else
            {
                if (!string.IsNullOrEmpty(message))
                {
                    // Print message
                    text_OutputLog.AppendText(GetTimestamp() + " : " + message);

                    // Are we supposed to print a new line?
                    if (newLine)
                    {
                        // Print message on new line
                        text_OutputLog.AppendText(Environment.NewLine);
                    }
                }
            }
        }



        // ***************************
        // ** WINDOWS FORMS CONTROLS
        // ***************************

        public CommonOpenFileDialog openDlg_AddFoldersPrompt = new CommonOpenFileDialog();
        public CommonOpenFileDialog openDlg_AddProjectPrompt = new CommonOpenFileDialog();
        public string addFilesLastDir = "C:\\";
        public string addFoldersLastDir = "C:\\";
        public string addProjectLastDir = "C:\\";
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
        /// Adds the specified file path to the file list.
        /// </summary>
        /// <param name="file">Full path of file to add.</param>
        /// <returns>True if the file was successfully added, false if not.</returns>
        private bool AddFile(string file)
        {
            // Does the file path exist?
            if (File.Exists(file))
            {
                Thread outputThread = new Thread(() => {
                    LogOutput_Proc("AutomationTool: Adding " + file);
                });
                outputThread.Start();

                // Add the file to the list
                clist_Files.Items.Add(file, true);

                return true;
            }
            else
            {
                Thread outputThread = new Thread(() => {
                    LogOutput_Proc("AutomationTool: ERROR! " + file + " not found");
                });
                outputThread.Start();

                return false;
            }
        }


        // When the user clicks the "Run" button:
        // Begin processing the list of files as a playlist.
        private void btn_Run_Click(object sender, EventArgs e)
        {
            // Don't continue if there aren't any files in the list
            if (clist_Files.Items.Count <= 0)
            {
                Thread errorThread = new Thread(() => {
                    LogOutput_Proc("AutomationTool: ERROR! File list must contain at least one file");

                    // Re-enable the UI
                    EnableUI_Proc(true);
                });
                errorThread.Start();

                return;
            }

            // Disable the UI
            EnableUI_Proc(false);

            ProcManager_Start();
        }


        // When the user clicks the "Cancel" button:
        // 
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
            // Add the selected files to the list
            foreach (string file in openDlg_AddFilesPrompt.FileNames)
            {
                // Save the current directory
                addFilesLastDir = GetFileDirectory(file);

                // Add the file to the list
                AddFile(file);
            }
        }


        // When the user clicks the "Add Folders..." button:
        // Prompt the user to select folders containing munge.bat files to add to the file list.
        private void btn_AddFolders_Click(object sender, EventArgs e)
        {
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
                    addFoldersLastDir = GetFileDirectory(folder);
                    
                    // Add the file to the list
                    AddFile(file);
                }
            }
        }


        // When the user clicks the "Add Project..." button:
        // Prompt the user to select a project to add to the file list.
        private void btn_AddProject_Click(object sender, EventArgs e)
        {
            openDlg_AddProjectPrompt.InitialDirectory = addProjectLastDir;
            openDlg_AddProjectPrompt.IsFolderPicker = true;
            //openDlg_AddProjectPrompt.Multiselect = true;

            // Auto-detect the munge.bat file inside each selected folder and add it to the file list
            if (openDlg_AddProjectPrompt.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // Get the project ID
                var projectID = GetProjectID(openDlg_AddProjectPrompt.FileName);


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
                    addProjectLastDir = GetFileDirectory(openDlg_AddProjectPrompt.FileName);

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
            if (clist_Files.Items.Count <= 0)
            {
                Thread errorThread = new Thread(() => {
                    LogOutput_Proc("AutomationTool: ERROR! File list must contain at least one file");

                    // Re-enable the UI
                    EnableUI_Proc(true);
                });
                errorThread.Start();

                return;
            }

            // Don't continue if a file isn't selected from the list
            if (clist_Files.SelectedItems.Count <= 0)
            {
                Thread errorThread = new Thread(() => {
                    LogOutput_Proc("AutomationTool: ERROR! File must be selected");

                    // Re-enable the UI
                    EnableUI_Proc(true);
                });
                errorThread.Start();

                return;
            }

            // Remove the currently selected file from the list
            clist_Files.Items.RemoveAt(clist_Files.SelectedIndex);
        }


        // When the user clicks the "Remove All" button:
        // Remove all files from the file list.
        private void btn_RemoveAllFiles_Click(object sender, EventArgs e)
        {
            clist_Files.Items.Clear();
        }


        // When the user clicks the "Copy to Clipboard" button:
        // Copy the entire contents of the log to the clipboard.
        private void btn_CopyLog_Click(object sender, EventArgs e)
        {
            text_OutputLog.SelectAll();
            text_OutputLog.Copy();
            text_OutputLog.DeselectAll();
        }


        // When the user clicks the "Save Log..." button:
        // Prompt the user to save the log to a new file.
        private void btn_SaveLog_Click(object sender, EventArgs e)
        {
            saveDlg_SaveLogPrompt.ShowDialog();
        }

        
        // When the user clicks the "OK" button in the "Save Log..." prompt:
        private void saveDlg_SaveLogPrompt_FileOk(object sender, CancelEventArgs e)
        {
            // Has a file name been entered?
            if (saveDlg_SaveLogPrompt.FileName != "")
            {
                // Get the file name
                string name = saveDlg_SaveLogPrompt.FileName;

                // Write the output log's contents to the file
                //File.WriteAllText(name, text_OutputLog.Text);
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
            // Auto-scroll to the most recent line
            text_OutputLog.ScrollToCaret();

            // Is the log full?
            if (text_OutputLog.TextLength >= (text_OutputLog.MaxLength - 500))
            {
                //lbl_OutputLogLines.Text = ("Lines: " + text_OutputLog.Lines.Count().ToString());
            }

            // Update line count
            lbl_OutputLogLines.Text = ("Lines: " + text_OutputLog.Lines.Count().ToString());

            // TODO: add functionality to remove lines from the beginning when the text box becomes full
        }
    }
}
