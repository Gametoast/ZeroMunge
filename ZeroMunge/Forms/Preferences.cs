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
		public const int PREFS_POLLING_RATE_MAX = 50;

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
			chk_AutoSaveEnabled.Checked = prefs.AutoSaveEnabled;
			chk_AutoLoadEnabled.Checked = prefs.AutoLoadEnabled;
			txt_LogPollingRate.Text = prefs.LogPollingRate.ToString();
			chk_OutputLogToFile.Checked = prefs.OutputLogToFile;
			chk_LogPrintTimestamps.Checked = prefs.LogPrintTimestamps;
			chk_ShowUpdatePromptOnStartup.Checked = prefs.ShowUpdatePromptOnStartup;
			chk_CheckForUpdatesOnStartup.Checked = prefs.CheckForUpdatesOnStartup;
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
			// Save the LogPollingRate value
			string logPollingRateStr = txt_LogPollingRate.Text;
			if (int.TryParse(logPollingRateStr, out int logPollingRate))
			{
				if (logPollingRate >= PREFS_POLLING_RATE_MAX)
				{
					prefs.LogPollingRate = logPollingRate;
				}
				else
				{
					Console.WriteLine("ERROR: Value of LogPollingRate must be >= " + PREFS_POLLING_RATE_MAX);
				}
			}
			else
			{
				Console.WriteLine("ERROR: Could not convert LogPollingRate input value '" + logPollingRateStr + "' to int");
			}

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

		private void chk_AutoSaveEnabled_CheckedChanged(object sender, EventArgs e)
		{
			prefs.AutoSaveEnabled = chk_AutoSaveEnabled.Checked;
		}

		private void chk_AutoLoadEnabled_CheckedChanged(object sender, EventArgs e)
		{
			prefs.AutoLoadEnabled = chk_AutoLoadEnabled.Checked;
		}

		private void chk_ShowUpdatePromptOnStartup_CheckedChanged(object sender, EventArgs e)
		{
			prefs.ShowUpdatePromptOnStartup = chk_ShowUpdatePromptOnStartup.Checked;
		}

		private void chk_CheckForUpdatesOnStartup_CheckedChanged(object sender, EventArgs e)
		{
			prefs.CheckForUpdatesOnStartup = chk_CheckForUpdatesOnStartup.Checked;
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
