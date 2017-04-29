using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomationTool
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        public Prefs prefs = new Prefs();

        private void Preferences_Load(object sender, EventArgs e)
        {
            // Load the saved user settings into our prefs object
            prefs = Utilities.LoadPrefs();

            // Fill the form control values with the loaded settings
            chk_ShowTrayIcon.Checked = prefs.ShowTrayIcon;
            chk_ShowNotificationPopups.Checked = prefs.ShowNotificationPopups;
            chk_PlayNotificationSounds.Checked = prefs.PlayNotificationSounds;
            chk_AutoDetectStagingDir.Checked = prefs.AutoDetectStagingDir;
            chk_AutoDetectMungedFiles.Checked = prefs.AutoDetectMungedFiles;
        }


        /// <summary>
        /// Destroy our prefs object and close the form.
        /// </summary>
        private void CloseForm()
        {
            prefs = null;
            Close();
        }


        // When the user clicks the OK button:
        // Commit their set preferences by saving them to the application settings, then close the form.
        private void btn_Accept_Click(object sender, EventArgs e)
        {
            Utilities.SavePrefs(prefs);
            CloseForm();
        }


        // When the user clicks the Cancel button:
        // Close the form without saving any preferences.
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }


        // When the user checks/unchecks one of the preference checkboxes:
        // Store the checkbox's checked state in our prefs object.
        private void chk_ShowTrayIcon_CheckedChanged(object sender, EventArgs e)
        {
            prefs.ShowTrayIcon = chk_ShowTrayIcon.Checked;

            // Disable/enable the Show Notification Popups checkbox based on this one's checked state
            chk_ShowNotificationPopups.Enabled = chk_ShowTrayIcon.Checked;

            // Uncheck Show Notification Popups if Show Tray Icon is unchecked
            if (!chk_ShowTrayIcon.Checked)
            {
                chk_ShowNotificationPopups.Checked = false;
            }
        }

        private void chk_ShowNotificationPopups_CheckedChanged(object sender, EventArgs e)
        {
            prefs.ShowNotificationPopups = chk_ShowNotificationPopups.Checked;
        }

        private void chk_PlayNotificationSounds_CheckedChanged(object sender, EventArgs e)
        {
            prefs.PlayNotificationSounds = chk_PlayNotificationSounds.Checked;
        }

        private void chk_AutoDetectStagingDir_CheckedChanged(object sender, EventArgs e)
        {
            prefs.AutoDetectStagingDir = chk_AutoDetectStagingDir.Checked;
        }

        private void chk_AutoDetectMungedFiles_CheckedChanged(object sender, EventArgs e)
        {
            prefs.AutoDetectMungedFiles = chk_AutoDetectMungedFiles.Checked;
        }
    }
}
