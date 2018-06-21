using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZeroMunge
{
	public partial class Preferences : Form
	{
		public const int PREFS_POLLING_RATE_MIN = 10;
		public const int PREFS_POLLING_RATE_MAX = 999999;
		public const int PREFS_POLLING_RATE_INC = 10;

		public const int PREFS_MAX_LINE_COUNT_MIN = 1;
		public const int PREFS_MAX_LINE_COUNT_MAX = 2000;
		public const int PREFS_MAX_LINE_COUNT_INC = 10;

		public Preferences()
		{
			InitializeComponent();
		}

		public Prefs prefs = new Prefs();

		private void Preferences_Load(object sender, EventArgs e)
		{
			SetToolTips();

			// Set the minimum, maximum, and increment values for the numeric input boxes
			num_LogPollingRate.Minimum = PREFS_POLLING_RATE_MIN;
			num_LogPollingRate.Maximum = PREFS_POLLING_RATE_MAX;
			num_LogPollingRate.Increment = PREFS_POLLING_RATE_INC;
			num_LogMaxLineCount.Minimum = PREFS_MAX_LINE_COUNT_MIN;
			num_LogMaxLineCount.Maximum = PREFS_MAX_LINE_COUNT_MAX;
			num_LogMaxLineCount.Increment = PREFS_MAX_LINE_COUNT_INC;

			// Load the saved user settings into our prefs object
			prefs = Utilities.LoadPrefs();

			// Fill the form control values with the loaded settings
			chk_ShowTrayIcon.Checked = prefs.ShowTrayIcon;
			chk_ShowNotificationPopups.Checked = prefs.ShowNotificationPopups;
			chk_PlayNotificationSounds.Checked = prefs.PlayNotificationSounds;
			chk_AutoDetectStagingDir.Checked = prefs.AutoDetectStagingDir;
			chk_AutoDetectMungedFiles.Checked = prefs.AutoDetectMungedFiles;
			chk_AutoSaveEnabled.Checked = prefs.AutoSaveEnabled;
			chk_AutoLoadEnabled.Checked = prefs.AutoLoadEnabled;
			num_LogPollingRate.Value = prefs.LogPollingRate;
			num_LogMaxLineCount.Value = prefs.LogMaxLineCount;
			chk_OutputLogToFile.Checked = prefs.OutputLogToFile;
			chk_LogPrintTimestamps.Checked = prefs.LogPrintTimestamps;
			chk_ShowUpdatePromptOnStartup.Checked = prefs.ShowUpdatePromptOnStartup;
			chk_CheckForUpdatesOnStartup.Checked = prefs.CheckForUpdatesOnStartup;
		}


		private void SetToolTips()
		{
			string maxValueMsg = "\n\nPossible value range: ";
			string maxValueSeparator = " - ";

			// Settings
			FormTooltips.SetToolTip(chk_ShowTrayIcon, Tooltips.Settings.ShowTrayIcon);
			FormTooltips.SetToolTip(chk_ShowNotificationPopups, Tooltips.Settings.ShowNotificationPopups);
			FormTooltips.SetToolTip(chk_PlayNotificationSounds, Tooltips.Settings.PlayNotificationSounds);
			FormTooltips.SetToolTip(chk_AutoDetectStagingDir, Tooltips.Settings.AutoDetectStagingDirectory);
			FormTooltips.SetToolTip(chk_AutoDetectMungedFiles, Tooltips.Settings.AutoDetectMungedFiles);
			FormTooltips.SetToolTip(chk_AutoSaveEnabled, Tooltips.Settings.AutoSaveFileList);
			FormTooltips.SetToolTip(chk_AutoLoadEnabled, Tooltips.Settings.AutoLoadLastSaveFile);
			FormTooltips.SetToolTip(lbl_LogPollingRate, string.Format(Tooltips.Settings.LogPollingRate + "{0}{1}{2}{3}", maxValueMsg, PREFS_POLLING_RATE_MIN, maxValueSeparator, PREFS_POLLING_RATE_MAX.ToString()));
			FormTooltips.SetToolTip(num_LogPollingRate, string.Format(Tooltips.Settings.LogPollingRate + "{0}{1}{2}{3}", maxValueMsg, PREFS_POLLING_RATE_MIN, maxValueSeparator, PREFS_POLLING_RATE_MAX.ToString()));
			FormTooltips.SetToolTip(lbl_LogMaxLineCount, string.Format(Tooltips.Settings.LogMaxLineCount + "{0}{1}{2}{3}", maxValueMsg, PREFS_MAX_LINE_COUNT_MIN, maxValueSeparator, PREFS_MAX_LINE_COUNT_MAX.ToString()));
			FormTooltips.SetToolTip(num_LogMaxLineCount, string.Format(Tooltips.Settings.LogMaxLineCount + "{0}{1}{2}{3}", maxValueMsg, PREFS_MAX_LINE_COUNT_MIN, maxValueSeparator, PREFS_MAX_LINE_COUNT_MAX.ToString()));
			FormTooltips.SetToolTip(chk_OutputLogToFile, Tooltips.Settings.OutputLogToFile);
			FormTooltips.SetToolTip(chk_LogPrintTimestamps, Tooltips.Settings.LogPrintTimestamps);
			FormTooltips.SetToolTip(chk_CheckForUpdatesOnStartup, Tooltips.Settings.CheckForUpdatesOnStartup);
			FormTooltips.SetToolTip(chk_ShowUpdatePromptOnStartup, Tooltips.Settings.ShowUpdatePromptOnStartup);
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
			// Save the numeric input values
			prefs.LogPollingRate = (int)num_LogPollingRate.Value;
			prefs.LogMaxLineCount = (int)num_LogMaxLineCount.Value;

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
			//chk_ShowNotificationPopups.Enabled = chk_ShowTrayIcon.Checked;

			// Show Notification Popups is dependent on this setting
			if (!chk_ShowTrayIcon.Checked)
			{
				chk_ShowNotificationPopups.Checked = false;
			}
		}

		private void chk_ShowNotificationPopups_CheckedChanged(object sender, EventArgs e)
		{
			prefs.ShowNotificationPopups = chk_ShowNotificationPopups.Checked;

			// This setting requires Show Icon Tray
			if (chk_ShowNotificationPopups.Checked)
			{
				chk_ShowTrayIcon.Checked = true;
			}
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

		private void chk_AutoSaveEnabled_CheckedChanged(object sender, EventArgs e)
		{
			prefs.AutoSaveEnabled = chk_AutoSaveEnabled.Checked;
		}

		private void chk_AutoLoadEnabled_CheckedChanged(object sender, EventArgs e)
		{
			prefs.AutoLoadEnabled = chk_AutoLoadEnabled.Checked;
		}

		private void chk_CheckForUpdatesOnStartup_CheckedChanged(object sender, EventArgs e)
		{
			prefs.CheckForUpdatesOnStartup = chk_CheckForUpdatesOnStartup.Checked;

			// Disable/enable the Show Update Prompt On Startup checkbox based on this one's checked state
			//chk_ShowUpdatePromptOnStartup.Enabled = chk_CheckForUpdatesOnStartup.Checked;

			// Show Update Prompt On Startup is dependent on this setting
			if (!chk_CheckForUpdatesOnStartup.Checked)
			{
				chk_ShowUpdatePromptOnStartup.Checked = false;
			}
		}

		private void chk_ShowUpdatePromptOnStartup_CheckedChanged(object sender, EventArgs e)
		{
			prefs.ShowUpdatePromptOnStartup = chk_ShowUpdatePromptOnStartup.Checked;

			// This setting requires Check For Updates On Startup
			if (chk_ShowUpdatePromptOnStartup.Checked)
			{
				chk_CheckForUpdatesOnStartup.Checked = true;
			}
		}

		private void chk_OutputLogToFile_CheckedChanged(object sender, EventArgs e)
		{
			prefs.OutputLogToFile = chk_OutputLogToFile.Checked;
		}

		private void chk_LogPrintTimestamps_CheckedChanged(object sender, EventArgs e)
		{
			prefs.LogPrintTimestamps = chk_LogPrintTimestamps.Checked;
		}
	}
}
