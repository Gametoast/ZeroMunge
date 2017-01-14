using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // TODO: prevent application from locking up during batch execution
        /// <summary>
        /// Executes the specified file.
        /// </summary>
        /// <param name="filePath">Full path of the file to execute.</param>
        private void ExecuteFile(String filePath)
        {
            //System.Diagnostics.Process.Start(filePath);

            // Get the file's directory
            string filePathDir = "";
            int index = filePath.LastIndexOf(@"\");
            if (index > 0)
            {
                filePathDir = filePath.Substring(0, index); // or index + 1 to keep slash
            }

            Process proc = new Process();
            proc.StartInfo.FileName = filePath;
            proc.StartInfo.WorkingDirectory = filePathDir;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.Start();

            // Log the output
            string output = proc.StandardOutput.ReadToEnd();
            WriteToOutputLog(output);
            proc.WaitForExit();
        }

        /// <summary>
        /// Prints the specified text to the output log.
        /// </summary>
        /// <param name="message">Text to print.</param>
        /// <param name="newLine">Optional: True to append a new line to the end of the message.</param>
        private void WriteToOutputLog(String message, bool newLine = false)
        {
            if (message != null)
            {
                // Print message
                text_OutputLog.AppendText(message);

                // Are we supposed to print a new line?
                if (newLine)
                {
                    // Print message on new line
                    text_OutputLog.AppendText(Environment.NewLine);
                }

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

        // When user clicks the 'Add...' button
        private void btn_AddFiles_Click(object sender, EventArgs e)
        {
            // Open the 'Add Files' prompt
            openDlg_AddFilesPrompt.ShowDialog();
        }

        // When user clicks the 'Remove' button
        private void btn_RemoveFiles_Click(object sender, EventArgs e)
        {
            // Remove the currently selected file from the list
            clist_Files.Items.RemoveAt(clist_Files.SelectedIndex);
        }

        // When user clicks the 'OK' button in the 'Add Files...' prompt
        private void openDlg_AddFilesPrompt_FileOk(object sender, CancelEventArgs e)
        {
            // Add the selected files to the list
            foreach (String file in openDlg_AddFilesPrompt.FileNames)
            {
                clist_Files.Items.Add(file, true);
            }
        }

        // When user clicks the 'Run' button
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            // Go through each file in the list
            for (int curFile = 0; curFile < clist_Files.Items.Count; curFile++)
            {
                // Execute each file that is checked
                if (clist_Files.GetItemChecked(curFile) == true)
                {
                    ExecuteFile(clist_Files.GetItemText(clist_Files.Items[curFile]));
                }
            }
        }
    }
}
