using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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



        // ***************************
        // ** PROCESS MANAGER
        // ***************************

        private int procManager_activeFile;

        /// <summary>
        /// Goes through the specified list of files and executes the ones that are checked.
        /// </summary>
        public void ProcManager_Start()
        {
            procManager_activeFile = 0;

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


            Thread enterThread = new Thread(() => {
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
        private void ProcManager_NotifyProcessComplete(int whichFile)
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
                ProcManager_StartProcess(clist_Files.GetItemText(clist_Files.Items[procManager_activeFile]));
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
        /// <returns>Process that was executed.</returns>
        private Process ProcManager_StartProcess(string filePath)
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
                Thread outputThread = new Thread(() => LogOutput_Proc(e.Data));
                outputThread.Start();
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
                Thread procExitThread = new Thread(() => {
                    LogOutput_Proc("AutomationTool: File done");
                });
                procExitThread.Start();

                ProcManager_NotifyProcessComplete(procManager_activeFile);
            });


            // Start the process
            proc.Start();
            proc.BeginOutputReadLine();
            //proc.WaitForExit();
            //Thread.Sleep(5000);

            return proc;
        }


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


        /// <summary>
        /// Returns the folder path of the specified file path.  
        /// Example: Inputting "C:\Documents\foo.bar" would return "C:\Documents"
        /// </summary>
        /// <param name="filePath">Path of file to get folder path from.</param>
        /// <returns>Folder path of the specified file path.</returns>
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
                btn_Submit.Enabled = enabled;
                btn_AddFiles.Enabled = enabled;
                btn_RemoveFiles.Enabled = enabled;
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
                if (!String.IsNullOrEmpty(message))
                {
                    // Print message
                    text_OutputLog.AppendText(message);

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

        // When the user clicks the 'Run' button:
        // Begin processing the list of files as a playlist.
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            //checkedItems.Clear();

            for (int item = 0; item < clist_Files.Items.Count; item++)
            {
                //checkedItems.Add(clist_Files.GetItemChecked(item));
            }

            // Disable the UI
            EnableUI_Proc(false);

            ProcManager_Start();
        }


        // When the user clicks the "Add..." button:
        // Prompt the user to select files to add to the file list.
        private void btn_AddFiles_Click(object sender, EventArgs e)
        {
            // Open the 'Add Files' prompt
            openDlg_AddFilesPrompt.ShowDialog();
        }


        // When the user clicks the "Remove" button:
        // Remove the selected file from the file list.
        private void btn_RemoveFiles_Click(object sender, EventArgs e)
        {
            // Remove the currently selected file from the list
            clist_Files.Items.RemoveAt(clist_Files.SelectedIndex);
        }


        // When the user clicks the "OK" button in the "Add Files..." prompt:
        // Add the selected files to the file list.
        private void openDlg_AddFilesPrompt_FileOk(object sender, CancelEventArgs e)
        {
            // Add the selected files to the list
            foreach (String file in openDlg_AddFilesPrompt.FileNames)
            {
                clist_Files.Items.Add(file, true);
            }
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


        private void clist_Files_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
