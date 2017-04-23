using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            chk_EnableTrayIcon.Checked = prefs.TrayIconEnabled;
            chk_EnableNotificationPopups.Checked = prefs.NotificationPopupsEnabled;
            chk_EnableNotificationSounds.Checked = prefs.NotificationSoundsEnabled;
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
        private void chk_EnableTrayIcon_CheckedChanged(object sender, EventArgs e)
        {
            prefs.TrayIconEnabled = chk_EnableTrayIcon.Checked;

            // Disable/enable the Enable Notification Popups checkbox based on this one's checked state
            chk_EnableNotificationPopups.Enabled = chk_EnableTrayIcon.Checked;
        }

        private void chk_EnableNotificationPopups_CheckedChanged(object sender, EventArgs e)
        {
            prefs.NotificationPopupsEnabled = chk_EnableNotificationPopups.Checked;
        }

        private void chk_EnableNotificationSounds_CheckedChanged(object sender, EventArgs e)
        {
            prefs.NotificationSoundsEnabled = chk_EnableNotificationSounds.Checked;
        }
    }
}
