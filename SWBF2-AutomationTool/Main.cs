using System;
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

        private void ExecuteFile(String filePath)
        {
            System.Diagnostics.Process.Start(filePath);
        }

        private void WriteToOutputLog(String message)
        {
            if (message != null)
            {
                // Print message on new line
                text_OutputLog.AppendText(message + Environment.NewLine);

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

        private void btn_AddFiles_Click(object sender, EventArgs e)
        {
            // Open the 'Add Files' prompt
            openDlg_AddFilesPrompt.ShowDialog();
        }

        private void btn_RemoveFiles_Click(object sender, EventArgs e)
        {
            // Remove the currently selected file from the list
            clist_Files.Items.RemoveAt(clist_Files.SelectedIndex);
        }

        private void openDlg_AddFilesPrompt_FileOk(object sender, CancelEventArgs e)
        {
            // Add the selected files to the list
            foreach (String file in openDlg_AddFilesPrompt.FileNames)
            {
                clist_Files.Items.Add(file, true);
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            WriteToOutputLog("test");

            // Execute each checked file in the list
            /*foreach (int curFile in clist_Files.Items)
            {
                if (clist_Files.GetItemChecked(curFile) == true)
                {
                    System.Diagnostics.Debug.Print(clist_Files.Items[curFile].ToString());
                }
            }*/
        }
    }
}
