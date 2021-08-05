using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using ZeroMunge.Modules;
using System.Text;

namespace ZeroMunge
{
	[Serializable]
	public partial class ZeroMunge : Form, Logger
	{
		public enum BuildType
		{
			Debug,
			DebugClearSettings,
			Release
		}

		// Is this a debug build?
		public BuildType BUILD_TYPE;


		#region Constants

		// Web links
		public const string LINK_GH_OPENISSUES = "https://github.com/Gametoast/ZeroMunge/issues";
		public const string LINK_GH_BUGS = "https://github.com/Gametoast/ZeroMunge/issues/new?template=bug_report.md";
		public const string LINK_GH_SUGGESTIONS = "https://github.com/Gametoast/ZeroMunge/issues/new?template=feature_request.md";
		public const string LINK_LICENSE = "https://www.w3.org/Consortium/Legal/2008/03-bsd-license.html";
		public const string LINK_EMAIL = "mailto:marth8880@gmail.com";
		public const string LINK_WEBSITE = "http://www.moddb.com/company/frayedwiresstudios";
		public const string LINK_PROJECT = "https://github.com/Gametoast/ZeroMunge";

		// Recent files list
		public const int RECENT_FILES_MAX = 10;

		#region Constants : data_Files

		// data_Files : Column names
		public const string STR_DATA_FILES_CHK_ENABLED = "col_Enabled";
		public const string STR_DATA_FILES_CHK_COPY = "col_Copy";
		public const string STR_DATA_FILES_TXT_FILE = "col_File";
		public const string STR_DATA_FILES_BTN_FILE_BROWSE = "col_FileBrowse";
		public const string STR_DATA_FILES_TXT_STAGING = "col_Staging";
		public const string STR_DATA_FILES_BTN_STAGING_BROWSE = "col_StagingBrowse";
		public const string STR_DATA_FILES_TXT_MUNGE_DIR = "col_MungeDir";
		public const string STR_DATA_FILES_TXT_MUNGED_FILES = "col_MungedFiles";
		public const string STR_DATA_FILES_BTN_MUNGED_FILES_EDIT = "col_MungedFilesEdit";
		public const string STR_DATA_FILES_CHK_IS_MUNGE_SCRIPT = "col_IsMungeScript";
		public const string STR_DATA_FILES_CHK_IS_VALID = "col_IsValid";

		// data_Files : Column indexes
		public const int INT_DATA_FILES_CHK_ENABLED = 0;
		public const int INT_DATA_FILES_CHK_COPY = 1;
		public const int INT_DATA_FILES_TXT_FILE = 2;
		public const int INT_DATA_FILES_BTN_FILE_BROWSE = 3;
		public const int INT_DATA_FILES_TXT_STAGING = 4;
		public const int INT_DATA_FILES_BTN_STAGING_BROWSE = 5;
		public const int INT_DATA_FILES_TXT_MUNGE_DIR = 6;
		public const int INT_DATA_FILES_TXT_MUNGED_FILES = 7;
		public const int INT_DATA_FILES_BTN_MUNGED_FILES_EDIT = 8;
		public const int INT_DATA_FILES_CHK_IS_MUNGE_SCRIPT = 9;
		public const int INT_DATA_FILES_CHK_IS_VALID = 10;

		#endregion Constants : data_Files

		#endregion Constants


		#region Fields

		// data_Files : Cell error color
		public Color errorRed = Color.FromArgb(251, 99, 99);

		// data_Files : Different methods with which cell contents are changed
		public enum CellChangeMethod
		{
			Button,     // Buttons outside the DataGridView
			Cell        // Cells inside the DataGridView
		}


		// Message requesting the user to report a problem, if found
		public string MSG_REPORT_PROBLEM = string.Concat("\n\n\t", "Please report this problem here: ", LINK_GH_OPENISSUES, "\n\n",
						"\t", "Be sure to include:", "\n",
						"\t\t", "1. The log file, which can be saved with the 'Save Log As...' button.", "\n",
						"\t\t", "2. A short summary of what you were doing when this problem occurred.", "\n",
						"\t\t", "3. Steps to reproduce this issue, if possible.", "\n\n",
						"Thanks!", "\n\n");


		// Updates
		public static VersionInfo latestAppVersion = new VersionInfo();
		public static bool updateAvailable = false;
		public Thread updateCheckThread;

		// User exit flow
		public bool inExitFlow = false;

		// Recent files list
		public List<string> recentFiles = new List<string>(RECENT_FILES_MAX);

		// User preferences
		public Prefs prefs = new Prefs();

		#endregion Fields

		#region Properties

		public string MungeLogName
		{
			get
			{
				string folder = GetProjectFolderFromRow(1);
				if (folder == null)
					folder = ".\\";
				else
					folder += "\\_BUILD";
				string retVal = Path.GetFullPath(Utilities.EnsureTrailingSlash( folder ) + this.Platform.ToString() + "_MungeLog.txt");
				return retVal;
			}
		}
		private Platform plt_Platform = Platform.PC;
		/// <summary>
		/// The munge platform
		/// </summary>
		public Platform Platform
		{
			get { return plt_Platform; }
			set
			{
				if (this.plt_Platform != value)
				{
					this.plt_Platform = value;
					OnPlatformChanged();
				}
			}
		}

		bool checkConsoleSupport = true;
		private void OnPlatformChanged()
		{
			string text = "";
			Color backColor = this.data_Files.Columns[0].DefaultCellStyle.BackColor;

			switch (this.Platform)
			{
				case Platform.PC:
					text = "Platform (PC)";
					break;
				case Platform.XBOX:
					text = "Platform (XBOX)";
					backColor = Color.Gray;
					break;
				case Platform.PS2:
					text = "Platform (PS2/PSP)";
					backColor = Color.Gray;
					break;
			}
			menu_xboxPlatform.Checked = Platform == Platform.XBOX;
			menu_pcPlatform.Checked = Platform == Platform.PC;
			menu_ps2Platform.Checked = Platform == Platform.PS2;

			this.data_Files.Columns[1].DefaultCellStyle.BackColor = backColor;
			menu_strip_platform.Text = text;
			string message = "Platform changed to "+Platform.ToString();
			if (Platform != Platform.PC)
				message += ", files will not be copied to staging area.";
			mungePanel.Platform = this.Platform;
			Log(message, LogType.Info);

			if (checkConsoleSupport && this.Platform != Platform.PC)
			{
				Preferences.CheckConsoleMungeSupport(prefs.ModToolsLocation);
				checkConsoleSupport = false;
			}
		}
		#endregion Properties


		// This is the very first method called by the application. It initializes the UI controls and loads user settings.
		public ZeroMunge()
		{
			InitializeComponent();

			// Set debug flag based on solution configuration
#if (BUILD_DEBUG)
			BUILD_TYPE = BuildType.Debug;
#elif (BUILD_DEBUG_CLEARSETTINGS)
				BUILD_TYPE = BuildType.DebugClearSettings;
#elif (BUILD_RELEASE)
				BUILD_TYPE = BuildType.Release;
#endif
			Trace.WriteLine("BUILD_TYPE: " + BUILD_TYPE.ToString());

			if (BUILD_TYPE == BuildType.DebugClearSettings)
			{
				Properties.Settings.Default.Reset();
			}

			latestAppVersion.BuildNum = 0;

			// Load any saved settings
			LoadSettings();
			UsingAlternateUI = menu_alternateUI.Checked;
			mungePanel.Logger = this;
			mungePanel.PlatformChanged += MungePanel_PlatformChanged;
		}


		#region  Alternate UI Stuff
		private void MungePanel_PlatformChanged(object sender, EventArgs e)
		{
			this.Platform = mungePanel.Platform;
		}

		private void menu_alternateUI_Click(object sender, EventArgs e)
		{
			menu_alternateUI.Checked = !menu_alternateUI.Checked;
		}
		private void menu_alternateUI_CheckChanged(object sender, EventArgs e)
		{
			mungePanel.Visible = UsingAlternateUI = menu_alternateUI.Checked;
			InitializeAlternateUI();
		}

		public bool UsingAlternateUI { get; private set; }

		private void InitializeAlternateUI()
		{
			if (menu_alternateUI.Checked)
			{
				if (data_Files.Rows.Count > 0 &&
					data_Files.Rows[0].Cells.Count > 1 &&
					data_Files.Rows[0].Cells[2].Value != null)
				{
					string dir = data_Files.Rows[0].Cells[2].Value.ToString();
					int index = dir.IndexOf("_BUILD");
					string arg = dir.Substring(0, index + 6);
					mungePanel.SetBuildDir(arg);
					string pc_outputDir = Utilities.EnsureTrailingSlash(data_Files.Rows[0].Cells[4].Value.ToString());
					index = pc_outputDir.IndexOf("data\\_LVL_PC\\");
					if (index > -1)
						pc_outputDir = pc_outputDir.Substring(0, index);
					else
						Log("AlternateUI: Error finding PC copy destination. You may need to manually edit dest.", LogType.Error );
					mungePanel.PCOutputFolder = pc_outputDir;
					mungePanel.Prefs = this.prefs;
				}
				else
				{
					menu_alternateUI.Checked = false;
					MessageBox.Show("First Load a project to use the Alternate UI");
				}
			}
		}

		private string GetCurrentProjectFolder()
		{
			string retVal = null;
			if (data_Files.Rows.Count > 0 &&
					data_Files.Rows[0].Cells.Count > 1 &&
					data_Files.Rows[0].Cells[2].Value != null)
			{
				string dir = data_Files.Rows[0].Cells[2].Value.ToString();
				int index = dir.IndexOf("_BUILD");
				retVal = dir.Substring(0, index );
			}
			return retVal;
		}

		/// <summary>
		/// munge.bat or clean.bat
		/// </summary>
		public string GetAltUIOperationFile()
		{
			string retVal = "";
			if (menu_alternateUI.Checked)
			{
				if (mungePanel.UseOVerrideCommand)
				{
					if (mungePanel.GetOverrideCommand().Trim().StartsWith("clean", StringComparison.OrdinalIgnoreCase))
						retVal = Utilities.EnsureTrailingSlash(mungePanel.MungeDir) + "clean.bat";
					else if (mungePanel.GetOverrideCommand().Trim().StartsWith("munge", StringComparison.OrdinalIgnoreCase))
						retVal = Utilities.EnsureTrailingSlash(mungePanel.MungeDir) + "munge.bat";
					else
					{
						string batchFile = mungePanel.GetOverrideCommand().Trim();
						int index = batchFile.IndexOf(' ');
						if(index > -1)
							batchFile = batchFile.Substring(0, index);
						string test = Utilities.EnsureTrailingSlash(mungePanel.MungeDir) + batchFile;
						if (!File.Exists(test))
							test = Utilities.EnsureTrailingSlash(mungePanel.MungeDir) + batchFile+".bat";
						if (File.Exists(test))
							retVal = test;
						else
							throw new InvalidOperationException("Invalid Override command; must be a batch file in the '_BUILD' folder.");
					}
				}
				else
					retVal = Utilities.EnsureTrailingSlash(mungePanel.MungeDir) + "munge.bat";
			}
			return retVal;
		}

		private bool askedAboutMissionMungeFile = false;
		public List<MungeFactory> GetAltUIFileList()
		{
			List<MungeFactory> retVal = new List<MungeFactory>();
			if (menu_alternateUI.Checked)
			{
				MungeFactory munge = new MungeFactory()
				{
					FileDir = GetAltUIOperationFile(),
					Args = GetAltUIOptions(),
				};
				if(mungePanel.MissionOnly)
				{
					string missionOnlyMungeFile = Utilities.EnsureTrailingSlash(mungePanel.MungeDir) + "Common\\munge_MISSION.bat";
					if(!File.Exists(missionOnlyMungeFile) && !this.askedAboutMissionMungeFile)
					{
						if( MessageBox.Show(
							"You have selected 'mission' only, would you like to create a 'munge_Mission.bat' file to handle this",
							"Create special 'mission only' batch file?", 
							MessageBoxButtons.YesNo, 
							MessageBoxIcon.Question
							) == DialogResult.Yes)
						{
							Assembly assembly = Assembly.GetExecutingAssembly();
							//string[] names = assembly.GetManifestResourceNames();// uncomment to see resources in debugger
							StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("ZeroMunge.Resources.munge_MISSION.bat"));
							string content = reader.ReadToEnd();
							File.WriteAllText(missionOnlyMungeFile, content);
						}
						this.askedAboutMissionMungeFile = true;
					}
					if (File.Exists(missionOnlyMungeFile) )
					{
						munge.FileDir = missionOnlyMungeFile;
						munge.Args = Platform.ToString();
					}
				}
				retVal.Add(munge);

				if (mungePanel.MungeAddme && !munge.FileDir.ToLower().Contains("clean.bat") && !mungePanel.UseOVerrideCommand )
				{
					FileInfo addmeInfo = new FileInfo(Utilities.EnsureTrailingSlash(mungePanel.MungeDir) + "..\\addme\\mungeAddme.bat");
					MungeFactory addme = new MungeFactory()
					{
						FileDir = addmeInfo.FullName,
						Args = "",
					};
					retVal.Insert(0,addme);
				}
			}
			return retVal;
		}

		public List<MungeFactory> GetAltUICleanFileList()
		{
			MungeFactory cleaner = new MungeFactory()
			{
				FileDir = Utilities.EnsureTrailingSlash(mungePanel.MungeDir) + "clean.bat",
				Args = this.GetAltUIOptions(),
			};
			List<MungeFactory> retVal = new List<MungeFactory>();
			retVal.Add(cleaner);
			return retVal;
		}

		public string GetAltUIOptions()
		{
			return mungePanel.GetOptions();
		}

		#endregion

		#region Main Window
		private const string ZeroMungeLog = ".\\ZeroMunge_OutputLog.log";


		// When the ZeroMunge form is finished loading:
		// Create the tray icon, initialize some stuff with the file list, and start a new output log.
		private void ZeroMunge_Load(object sender, EventArgs e)
		{
			stat_UpdateLink.Visible = false;

			// Set the tray icon if it's enabled
			if (prefs.ShowTrayIcon)
			{
				trayIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
				trayIcon.Text = "Zero Munge: Idle";
				stat_JobStatus.Text = "Idle";
			}
			else
			{
				trayIcon.Visible = false;
			}

			col_MungeDir.Visible = prefs.ShowMungeOutputDir;

			// Set the visibility of the debug columns in the file list
			col_IsMungeScript.Visible = BUILD_TYPE == BuildType.Debug || BUILD_TYPE == BuildType.DebugClearSettings;
			col_IsValid.Visible = BUILD_TYPE == BuildType.Debug || BUILD_TYPE == BuildType.DebugClearSettings;
			button2.Visible = BUILD_TYPE == BuildType.Debug || BUILD_TYPE == BuildType.DebugClearSettings;
			button3.Visible = BUILD_TYPE == BuildType.Debug || BUILD_TYPE == BuildType.DebugClearSettings;

			// Set the visibility of the DataGridView buttons
			col_FileBrowse.UseColumnTextForButtonValue = true;
			col_StagingBrowse.UseColumnTextForButtonValue = true;
			col_MungedFilesEdit.UseColumnTextForButtonValue = true;

			// Set the UI tooltip text
			SetToolTips();

			// Start a new log file
			if (prefs.OutputLogToFile)
			{
				try
				{
					string openMessage = "Opened logfile " + ZeroMungeLog + "  " + DateTime.Now.ToString("yyyy-MM-dd") + " " + Utilities.GetTimestamp();
					File.WriteAllText(ZeroMungeLog, openMessage + Environment.NewLine);
				}
				catch (IOException ex)
				{
					Trace.WriteLine(ex.Message);
					Log(ex.Message, LogType.Error);
				}
				catch (UnauthorizedAccessException ex)
				{
					Trace.WriteLine(ex.Message);
					Log(ex.Message, LogType.Error);
				}
			}

			// Populate the Recent Files list
			if (!IsRecentFilesPrefsListEmpty())
			{
				try
				{
					recentFiles = prefs.RecentFiles.Cast<string>().ToList();
					RecentFiles_RepopulateMenu();
				}
				catch (InvalidCastException ex)
				{
					var msg = "Failed to load Recent Files list. Reason: " + ex.Message;
					Trace.WriteLine(msg);
					Log(msg, LogType.Error);
				}
			}
			else
			{
				prefs.RecentFiles = new StringCollection();
			}

			Log(string.Format("Starting Zero Munge  v{0}, r{1} — {2}", Properties.Settings.Default.Info_Version, Properties.Settings.Default.Info_BuildNum.ToString(), Properties.Settings.Default.Info_BuildDate.ToString("yyyy-MM-dd")), LogType.Info);
		}


		// When the form is first shown: 
		// Check for updates, set the game path, and auto-load the last save file.
		private void ZeroMunge_Shown(object sender, EventArgs e)
		{
			// Check for application updates
			if (prefs.CheckForUpdatesOnStartup)
			{
				updateCheckThread = new Thread(() =>
				{
					Log("Checking for updates... (Auto-check can be disabled in Preferences)", LogType.Update);

					UpdateInfo updateInfo = Utilities.CheckForUpdates(this, false);

					if (updateInfo != null)
					{
						latestAppVersion = updateInfo.LatestVersionInfo;

						switch (updateInfo.CheckResult)
						{
							case Utilities.UpdateResult.Available:
								string latestVer = string.Format("v{0}, r{1} — {2}", updateInfo.LatestVersionInfo.Version, updateInfo.LatestVersionInfo.BuildNum.ToString(), updateInfo.LatestVersionInfo.BuildDate);
								string currentVer = string.Format("v{0}, r{1} — {2}", Properties.Settings.Default.Info_Version, Properties.Settings.Default.Info_BuildNum.ToString(), Properties.Settings.Default.Info_BuildDate.ToString("yyyy-MM-dd"));
								string releaseNotes = updateInfo.LatestVersionInfo.ReleaseNotes.Replace("\n", "\n\t\t");

								string logMessage = string.Concat("Application update is available!", "\n\t",
									"Current version:", "   ", currentVer, "\n\t",
									"Latest version:", "    ", latestVer, "\n\t",
									"Download link:", "     ", updateInfo.LatestVersionInfo.DownloadUrl, "\n\t",
									"Release notes:", "\n\t\t", releaseNotes, "\n");

								if (prefs.ShowUpdatePromptOnStartup)
								{
									Trace.WriteLine("Check succeeded. Update is available. Pushing update prompt.");
									Log(logMessage, LogType.Update);
									Flow_Updates_Start();
								}
								else
								{
									Trace.WriteLine("Check succeeded. Update is available, but user has specified to not show the update prompt on startup.");
									Log(logMessage, LogType.Update);
								}

								stat_UpdateLink.Text = string.Format("Update available ({0})", updateInfo.LatestVersionInfo.Version);
								stat_UpdateLink.Visible = true;
								break;

							case Utilities.UpdateResult.NoneAvailable:
								Trace.WriteLine("Check succeeded. No updates are available.");
								Log("No updates are available", LogType.Update);
								break;

							case Utilities.UpdateResult.NetConnectionError:
								Trace.WriteLine("Check failed. Network connection could not be established.");
								Log("Network connection could not be established.", LogType.Update);
								break;
						}
					}
				});
				updateCheckThread.Name = "updateCheckThread";
				updateCheckThread.Start();
			}

			// Set game path
			Log("Checking game path...", LogType.Info);
			if (prefs.GameDirectory != "")
			{
				var msg = string.Format("Setting game path: \"{0}\"", prefs.GameDirectory);
				Log(msg, LogType.Info, true);
			}
			else
			{
				Flow_SetGameDirectory_Start();
			}

			string[] args = Environment.GetCommandLineArgs();
			string openProjectOnLaunch = "";

			// Was a project path passed into the application?
			if (args.Length > 1)
			{
				if (Directory.Exists(args[1]))
				{
					openProjectOnLaunch = args[1];
					this.Log(string.Format("Project path was specified in application argument. Adding project found in {0}", openProjectOnLaunch));

					AddProject(openProjectOnLaunch);
				}
				else
				{
					this.Log(string.Format("Project path '{0}' was specified but cannot be found!", args[1]), LogType.Error);
				}
			}
			else
			{
				// Auto-load the last save file
				if (prefs.AutoLoadEnabled && prefs.LastSaveFilePath != "UNSET")
				{
					if (prefs.LastSaveFilePath != "" && File.Exists(prefs.LastSaveFilePath))
					{
						Log(string.Format("Auto-load is enabled. Loading save file: \"{0}\"", prefs.LastSaveFilePath), LogType.Info);

						//DataFilesContainer data = DeserializeData(prefs.LastSaveFilePath);
						//LoadDataIntoFileList(data, prefs.LastSaveFilePath);

						OpenFileListFile(prefs.LastSaveFilePath);
					}
				}
			}
		}


		// Set the initial state of the window
		FormWindowState lastWindowState = FormWindowState.Minimized;
		FormWindowState lastWindowSize = FormWindowState.Normal;

		// When the user resizes the window by dragging the handles, maximizing, restoring, or minimizing:
		// Store the WindowState for future reference when the user double-clicks the trayIcon.
		private void ZeroMunge_Resize(object sender, EventArgs e)
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


		// When the form is focused on and activated:
		// Reload the application settings.
		private void ZeroMunge_Activated(object sender, EventArgs e)
		{
			//Debug.WriteLine("ZeroMunge_Activated() entered");

			prefs = Utilities.LoadPrefs();
		}


		// When the form is unfocused and deactivated:
		// 
		private void ZeroMunge_Deactivate(object sender, EventArgs e)
		{
			//Debug.WriteLine("ZeroMunge_Deactivate() entered");
		}

		private delegate void CallbackCompleteDelegate(List<MungeFactory> fileList);

		public void CompleteCallback(List<MungeFactory> fileList)
		{
			if (this.InvokeRequired)
			{
				Debugger.Log(1, "debug", "ShowCompletedMessage: Invoke was required ");
				CallbackCompleteDelegate cb = new CallbackCompleteDelegate(CompleteCallback);
				this.BeginInvoke(cb, new object[] { fileList });
			}
			else
			{
				if (prefs.ShowNotificationPopups)
				{
					trayIcon.Text = "Zero Munge: Idle";
					trayIcon.BalloonTipTitle = "Success";
					trayIcon.BalloonTipText = "The operation was completed successfully.";
					trayIcon.ShowBalloonTip(30000);
					stat_JobStatus.Text = "Idle";
				}

				if (fileList.Count > 0 && fileList[0].FileDir.IndexOf("clean.bat", StringComparison.OrdinalIgnoreCase) == -1)
				{ // a munge operation has finished
					if (UsingAlternateUI)
					{
						// don't do automatic copy of non-PC builds.
						if (this.Platform == Platform.PC && mungePanel.AutoCopy)
							mungePanel.CopyFiles();
					}
				}
			}
		}


		// When the form is in the process of closing:
		// Auto-save the file list (if enabled).
		private void ZeroMunge_FormClosing(object sender, FormClosingEventArgs e)
		{
			inExitFlow = true;

			if (ProcessManager.IsRunning())
			{
				ProcessManager.Abort(this);
			}

			if (prefs.AutoSaveEnabled)
			{
				//if (!IsFileListEmpty())
				//{
				string filePath = prefs.LastSaveFilePath;

				// Use the default autosave file path if LastSaveFilePath is unset
				if (filePath == "UNSET")
				{
					filePath = Directory.GetCurrentDirectory() + @"\ZeroMunge-auto.zmd";
				}

				SaveFileListToFile(filePath, true, false);
				//}
				//else
				//{
				//	var message = "Cannot save empty file list!";
				//	Trace.WriteLine(message);
				//	Log(message, LogType.Error);
				//}
			}
			else
			{
				if (isFileListDirty)
				{
					string promptTitle = "Save File List";
					string promptCaption = "There are unsaved changes to the file list. Would you like to save before closing?";

					DialogResult result = MessageBox.Show(promptCaption, promptTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

					switch (result)
					{
						case DialogResult.Yes:
							//e.Cancel = true;
							Command_Save();
							break;

						case DialogResult.No:

							break;

						case DialogResult.Cancel:
							e.Cancel = true;
							inExitFlow = false;
							break;
					}
				}
			}

			if (!e.Cancel)
			{
				if (prefs.ShowTrayIcon)
				{
					trayIcon.Visible = false;
					trayIcon.Dispose();
				}

				if (updateCheckThread != null && updateCheckThread.ThreadState == System.Threading.ThreadState.Running)
				{
					try
					{
						updateCheckThread.Abort();
					}
					catch (ThreadStateException ex)
					{
						Trace.WriteLine(ex.Message);
					}
				}
			}
		}


		// When the user presses a key:
		// Execute conditional logic based on the key combination that was pressed.
		private void ZeroMunge_KeyDown(object sender, KeyEventArgs e)
		{
			// When the modifier key is Shift:
			if ((ModifierKeys & Keys.Shift) == Keys.Shift)
			{
				switch (e.KeyCode)
				{
					// Stop processing files in the file list.
					case Keys.F5:
						Hotkey_ShiftF5();
						e.Handled = true;
						break;
				}
			}

			// When the modifier key is Ctrl:
			if ((ModifierKeys & Keys.Control) == Keys.Control)
			{
				switch (e.KeyCode)
				{
					// Run the New command.
					case Keys.N:
						Hotkey_CtrlN();
						e.Handled = true;
						break;

					// Run the Open command.
					case Keys.O:
						Hotkey_CtrlO();
						e.Handled = true;
						break;

					// Run the Save command.
					case Keys.S:
						Hotkey_CtrlS();
						e.Handled = true;
						break;

					// Exit the application.
					case Keys.Q:
						Hotkey_CtrlQ();
						e.Handled = true;
						break;

					// Open the Preferences window.
					case Keys.P:
						Hotkey_CtrlP();
						e.Handled = true;
						break;
				}
			}

			// If no modifier keys were pressed:
			switch (e.KeyCode)
			{
				// Open the Help window.
				case Keys.F1:
					if ((ModifierKeys & Keys.Shift) == Keys.Shift) { return; }
					Hotkey_F1();
					e.Handled = true;
					break;

				// Start processing files in the file list.
				case Keys.F5:
					if ((ModifierKeys & Keys.Shift) == Keys.Shift) { return; }
					Hotkey_F5();
					e.Handled = true;
					break;
				case Keys.F6:
					Hotkey_F6();
					e.Handled = true;
					break;
				case Keys.F10:
					Hotkey_F10();
					e.Handled = true;
					break;

				// Open the About window.
				case Keys.F12:
					if ((ModifierKeys & Keys.Shift) == Keys.Shift) { return; }
					Hotkey_F12();
					e.Handled = true;
					break;

				// Clear the contents of the currently selected cells in the file list.
				case Keys.Delete:
					Hotkey_Delete();
					e.Handled = true;
					break;
			}
		}


		#region Hotkeys

		/// <summary>
		/// Executes the logic for the 'Shift + F5' hotkey.
		/// </summary>
		private void Hotkey_ShiftF5()
		{
			Debug.WriteLine("Shift + F5 was pressed");

			if (ProcessManager.IsRunning())
			{
				ProcessManager.Abort(this);
			}
		}


		/// <summary>
		/// Executes the logic for the 'Ctrl + N' hotkey.
		/// </summary>
		private void Hotkey_CtrlN()
		{
			Debug.WriteLine("Ctrl + N was pressed");

			if (!ProcessManager.IsRunning())
			{
				Command_New();
			}
		}


		/// <summary>
		/// Executes the logic for the 'Ctrl + O' hotkey.
		/// </summary>
		private void Hotkey_CtrlO()
		{
			Debug.WriteLine("Ctrl + O was pressed");

			if (!ProcessManager.IsRunning())
			{
				Command_Open();
			}
		}


		/// <summary>
		/// Executes the logic for the 'Ctrl + S' hotkey.
		/// </summary>
		private void Hotkey_CtrlS()
		{
			Debug.WriteLine("Ctrl + S was pressed");

			if (!ProcessManager.IsRunning())
			{
				if (!IsFileListEmpty())
				{
					Command_Save();
				}
				else
				{
					var message = "Cannot save empty file list!";
					Trace.WriteLine(message);
					Log(message, LogType.Error);
				}
			}
		}


		/// <summary>
		/// Executes the logic for the 'Ctrl + Q' hotkey.
		/// </summary>
		private void Hotkey_CtrlQ()
		{
			Debug.WriteLine("Ctrl + Q was pressed");

			if (!ProcessManager.IsRunning())
			{
				Command_Quit();
			}
		}


		/// <summary>
		/// Executes the logic for the 'Ctrl + P' hotkey.
		/// </summary>
		private void Hotkey_CtrlP()
		{
			Debug.WriteLine("Ctrl + P was pressed");

			if (!ProcessManager.IsRunning())
			{
				OpenWindow_Preferences();
			}
		}


		/// <summary>
		/// Executes the logic for the 'F1' hotkey.
		/// </summary>
		private void Hotkey_F1()
		{
			Debug.WriteLine("F1 was pressed");

			if (!ProcessManager.IsRunning())
			{
				OpenWindow_Help();
			}
		}


		/// <summary>
		/// Executes the logic for the 'F5' hotkey.
		/// </summary>
		private void Hotkey_F5()
		{
			Debug.WriteLine("F5 was pressed");

			if (!ProcessManager.IsRunning())
			{
				StartMunge();
			}
		}

		private void StartMunge()
		{
			try
			{
				if (UsingAlternateUI)
					ProcessManager.Start(this, GetAltUIFileList(), data_Files);
				else
					ProcessManager.Start(this, GetCheckedFiles(), data_Files);
			}
			catch(InvalidOperationException e)
			{
				// Alt UI Panel can throw this exception when using the 'override command'
				MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Hotkey_F6()
		{
			Debug.WriteLine("F6 was pressed");

			LaunchDebuggerExe();
		}

		private void Hotkey_F10()
		{
			Debug.WriteLine("F10 was pressed");

			LaunchZeroEditor();
		}


		/// <summary>
		/// Executes the logic for the 'F12' hotkey.
		/// </summary>
		private void Hotkey_F12()
		{
			Debug.WriteLine("F12 was pressed");

			if (!ProcessManager.IsRunning())
			{
				OpenWindow_About();
			}
		}


		/// <summary>
		/// Executes the logic for the 'Delete' hotkey.
		/// </summary>
		private void Hotkey_Delete()
		{
			Debug.WriteLine("Delete was pressed");

			if (!ProcessManager.IsRunning())
			{
				foreach (DataGridViewCell cell in data_Files.SelectedCells)
				{
					// Determine the cell type
					if (cell is DataGridViewTextBoxCell)
					{
						if (cell.Value != null)
						{
							cell.Value = "";
						}
					}
				}
			}
		}

		#endregion Hotkeys


		/// <summary>
		/// Sets tooltips for all form controls
		/// </summary>
		private void SetToolTips()
		{
			FormTooltips.AutoPopDelay = Properties.Settings.Default.TooltipPopDelay;

			// File Menu
			menu_newToolStripMenuItem.ToolTipText = Tooltips.FileMenu.New;
			menu_openToolStripMenuItem.ToolTipText = Tooltips.FileMenu.Open;
			//menu_openRecentToolStripMenuItem.ToolTipText = Tooltips.FileMenu.OpenRecent;
			// NOTE: The tooltip text for the Clear Recent File List button is set when the control is generated in RecentFiles_RepopulateMenu
			menu_saveToolStripMenuItem.ToolTipText = Tooltips.FileMenu.Save;
			menu_saveAsToolStripMenuItem.ToolTipText = Tooltips.FileMenu.SaveAs;
			menu_exitToolStripMenuItem.ToolTipText = Tooltips.FileMenu.Exit;


			// File List
			FormTooltips.SetToolTip(btn_Run, Tooltips.FileList.Run);
			FormTooltips.SetToolTip(btn_Cancel, Tooltips.FileList.Cancel);
			FormTooltips.SetToolTip(btn_EasyFilePicker, Tooltips.FileList.EasyFilePicker);
			FormTooltips.SetToolTip(btn_AddFiles, Tooltips.FileList.AddFiles);
			FormTooltips.SetToolTip(btn_AddFolders, Tooltips.FileList.AddFolders);
			FormTooltips.SetToolTip(btn_AddProject, Tooltips.FileList.AddProject);
			FormTooltips.SetToolTip(btn_RemoveFile, Tooltips.FileList.RemoveFile);
			FormTooltips.SetToolTip(btn_RemoveAllFiles, Tooltips.FileList.RemoveAllFiles);
			FormTooltips.SetToolTip(btn_clean, Tooltips.FileList.Clean);

			menu_runToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_Run);
			menu_cancelToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_Cancel);
			menu_easyFilePickerToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_EasyFilePicker);
			menu_addFilesToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_AddFiles);
			menu_addFoldersToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_AddFolders);
			menu_addProjectToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_AddProject);
			menu_removeToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_RemoveFile);
			menu_removeAllToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_RemoveAllFiles);

			// Output Log
			FormTooltips.SetToolTip(btn_OpenMungeLog, Tooltips.Actions.OpenMungeLog);
			FormTooltips.SetToolTip(btn_OpenLog, Tooltips.OutputLog.OpenLog);
			FormTooltips.SetToolTip(btn_SaveLog, Tooltips.OutputLog.SaveLogAs);
			FormTooltips.SetToolTip(btn_ClearLog, Tooltips.OutputLog.ClearLog);

			menu_copyLogToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_OpenMungeLog);
			menu_saveLogAsToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_SaveLog);
			menu_clearLogToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_ClearLog);

			// Action Items
			menu_openGameLog.ToolTipText = Tooltips.Actions.OpenGameLog;
			menu_openModToolsExe.ToolTipText = Tooltips.Actions.OpenModToolsExe;
			menu_launchZeroEditor.ToolTipText = Tooltips.Actions.OpenZeroEditor;
			menu_openGameExe.ToolTipText = Tooltips.Actions.OpenGameExe;
			menu_openGameFolder.ToolTipText = Tooltips.Actions.OpenGameFolder;
			menu_openMungeLog.ToolTipText = Tooltips.Actions.OpenMungeLog;
			menu_openLog.ToolTipText = Tooltips.OutputLog.OpenLog;
			// -------------------------------------------------

			// Tools Menu
			menu_createSideMungeFolderToolStripMenuItem.ToolTipText = Tooltips.Tools.CreateSideMungeFolder;
			menu_createWorldMungeFolderToolStripMenuItem.ToolTipText = Tooltips.Tools.CreateWorldMungeFolder;
			menu_fixWorldMungeScriptsToolStripMenuItem.ToolTipText = Tooltips.Tools.FixWorldMungeFile;
			menu_fixSoundMungeFilesToolStripMenuItem.ToolTipText = Tooltips.Tools.FixSoundMungeFiles;
			menu_modifyMungedSoundFoldersToolStripMenuItem.ToolTipText = Tooltips.Tools.ModifyMungedSoundFolders;
			menu_addMission.ToolTipText = Tooltips.Tools.AddMission;


			// Settings
			FormTooltips.SetToolTip(btn_SetGamePath, Tooltips.Settings.SetGamePath);

			menu_setGamePathToolStripMenuItem.ToolTipText = FormTooltips.GetToolTip(btn_SetGamePath);
			menu_prefsToolStripMenuItem.ToolTipText = Tooltips.Settings.OpenPreferences;


			// Help Menu
			menu_viewHelpToolStripMenuItem.ToolTipText = Tooltips.HelpMenu.ViewHelp;
			menu_viewChangelogToolStripMenuItem.ToolTipText = Tooltips.HelpMenu.ViewChangelog;
			menu_viewLicenseToolStripMenuItem.ToolTipText = Tooltips.HelpMenu.ViewLicense;
			menu_viewReadmeToolStripMenuItem.ToolTipText = Tooltips.HelpMenu.ViewReadme;
			menu_reportBugToolStripMenuItem.ToolTipText = Tooltips.HelpMenu.ReportBug;
			menu_provideSuggestionToolStripMenuItem.ToolTipText = Tooltips.HelpMenu.ProvideSuggestion;
			menu_viewOpenIssuesToolStripMenuItem.ToolTipText = Tooltips.HelpMenu.ViewOpenIssues;
			menu_checkForUpdatesToolStripMenuItem.ToolTipText = Tooltips.HelpMenu.CheckForUpdates;
			menu_aboutToolStripMenuItem.ToolTipText = Tooltips.HelpMenu.OpenAbout;
			menu_gametoastForums.ToolTipText = Tooltips.HelpMenu.Gametoast;
			menu_gametoastGithub.ToolTipText = Tooltips.HelpMenu.GametoastGithub;
			menu_Battlefront2API.ToolTipText = Tooltips.HelpMenu.Battlefront2API;
		}


		/// <summary>
		/// Updates the form's title with the file list's dirty state and the name of the file list's current save file.
		/// </summary>
		private void UpdateWindowTitle()
		{
			string baseName = "Zero Munge";
			string fullName;

			if (curFileListName == "null")
			{
				fullName = baseName;
			}
			else
			{
				if (isFileListDirty)
				{
					fullName = string.Format("{0} - * {1}", baseName, curFileListName);
				}
				else
				{
					fullName = string.Format("{0} - {1}", baseName, curFileListName);
				}
			}

			this.Text = fullName;
			this.Update();
		}


		/// <summary>
		/// Loads and initializes saved user settings.
		/// </summary>
		public void LoadSettings()
		{
			// Load the saved user settings into our prefs object
			prefs = Utilities.LoadPrefs();
		}


		/// <summary>
		/// Shortcut method to call Utilities.OpenFile and log the result.
		/// </summary>
		/// <param name="fileName">Name of the file to open.</param>
		private void OpenApplicationResourceFile(string fileName)
		{
			var result = Utilities.OpenApplicationResourceFile(fileName);
			LogType logType = LogType.Info;

			if (result.Contains("Could not open"))
			{
				logType = LogType.Error;
			}

			Log(result, logType);
		}

		#endregion Main Window


		#region OpenWindow

		/// <summary>
		/// Call this to open a new instance of the Easy File Picker window.
		/// </summary>
		private void OpenWindow_EasyFilePicker()
		{
			menu_alternateUI.Checked = false;// force user back to default ui

			EasyFilePicker easyFilePickerForm = new EasyFilePicker();
			if (easyFilePickerForm.ShowDialog() == DialogResult.OK)
			{
				SelectLastRow();

				foreach (string file in easyFilePickerForm.mungeFilePaths)
				{
					AddFile(file, true);
				}
			}
			easyFilePickerForm.Dispose();
		}


		/// <summary>
		/// Starts the update flow (duh).
		/// </summary>
		public static void Flow_Updates_Start() => OpenWindow_Updates();


		/// <summary>
		/// Call this to open a new instance of the Preferences window.  
		/// NOTE: The window will be opened as a dialog.
		/// </summary>
		private void OpenWindow_Preferences()
		{
			bool prevShowMungeOutputDirState = prefs.ShowMungeOutputDir;

			Preferences prefsForm = new Preferences();
			prefsForm.StartPosition = FormStartPosition.CenterParent;
			if (prefsForm.ShowDialog(this) == DialogResult.OK)
			{
				if (!String.IsNullOrEmpty(prefsForm.Message))
				{
					string[] lines = prefsForm.Message.Split(new char[] { '\n' });
					foreach (string line in lines)
						Log(line, LogType.Info);
				}

				// Reload our preferences
				prefs = Utilities.LoadPrefs();

				if (prefs.ShowMungeOutputDir != prevShowMungeOutputDirState)
				{
					col_MungeDir.Visible = prefs.ShowMungeOutputDir;
				}

				Log("Saving preferences", LogType.Info);
			}
			prefsForm.Dispose();
		}


		/// <summary>
		/// Call this to open a new instance of the Help window.  
		/// NOTE: The window will be opened as a dialog.
		/// </summary>
		private void OpenWindow_Help()
		{
			Utilities.OpenHelp(this);
		}


		/// <summary>
		/// Shows the update prompt in a new window.
		/// </summary>
		private static void OpenWindow_Updates()
		{
			Updates updatesForm = new Updates();
			updatesForm.ShowDialog();
		}


		/// <summary>
		/// Call this to open a new instance of the About window.  
		/// NOTE: The window will be opened as a dialog.
		/// </summary>
		private void OpenWindow_About()
		{
			About aboutForm = new About();
			aboutForm.ShowDialog();
		}

		#endregion OpenWindow


		#region Commands

		/// <summary>
		/// Clear the file list and start a new save file
		/// </summary>
		public void Command_New()
		{
			curFileListName = "Untitled";
			UpdateWindowTitle();

			lastCellChangeMethod = CellChangeMethod.Button;
			ClearFileList();

			ResetCurFileListInfo();
		}


		/// <summary>
		/// Open a prompt to load a new data container file's contents into the file list.
		/// </summary>
		public void Command_Open()
		{
			openDlg_OpenFileListPrompt.InitialDirectory = openFileListLastDir;
			if (openDlg_OpenFileListPrompt.ShowDialog() == DialogResult.OK)
			{
				OpenFileListFile(openDlg_OpenFileListPrompt.FileName);
			}
		}


		/// <summary>
		/// Immediately save the contents of the file list to the current file.
		/// </summary>
		public void Command_Save(bool isAutoSave = false, bool inExitFlow = false)
		{
			//if (!IsFileListEmpty())
			//{
			if (curFileListPath == "null" || curFileListName == "null")
			{
				Command_SaveAs();
			}
			else
			{
				SaveFileListToFile(curFileListPath, isAutoSave, inExitFlow);
			}
			//}
			//else
			//{
			//	var message = "Cannot save empty file list!";
			//	Trace.WriteLine(message);
			//	Log(message, LogType.Error);
			//}
		}


		/// <summary>
		/// Open a prompt to save the contents of the file list to a new file.
		/// </summary>
		public void Command_SaveAs()
		{
			saveDlg_SaveFileListPrompt.InitialDirectory = saveFileListLastDir;

			DialogResult dialogResult = saveDlg_SaveFileListPrompt.ShowDialog();

			if (inExitFlow)
			{
				switch (dialogResult)
				{
					case DialogResult.OK:
						inExitFlow = false;
						Application.Exit();
						break;

					default:
						inExitFlow = false;
						//Application.Exit();
						break;
				}
			}
		}


		/// <summary>
		/// Exit the application.
		/// </summary>
		public void Command_Quit()
		{
			//Flow_ExitApplication_Start();

			try
			{
				Application.Exit();
			}
			catch (InvalidOperationException ex)
			{
				var msg = "Invalid operation while starting process. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
				throw;
			}
		}

		#endregion Commands


		#region Output Log

		// ***************************
		// ** OUTPUT LOG
		// ***************************
		#region Output Log : Logic

		/// <summary>
		/// Prints the specified text to the output log.
		/// This method is executed on the worker thread and makes a thread-safe call on the RichTextBox control.
		/// </summary>
		/// <param name="message">Text to print.</param>
		public void Log(string message)
		{
			Log_Proc(message, LogType.None, false);
		}
		/// <summary>
		/// Prints the specified text to the output log.
		/// This method is executed on the worker thread and makes a thread-safe call on the RichTextBox control.
		/// </summary>
		/// <param name="message">Text to print.</param>
		/// <param name="logType">Log type. See enum 'LogType'.</param>
		public void Log(string message, LogType logType)
		{
			Log_Proc(message, logType, false);
		}
		/// <summary>
		/// Prints the specified text to the output log.
		/// This method is executed on the worker thread and makes a thread-safe call on the RichTextBox control.
		/// </summary>
		/// <param name="message">Text to print.</param>
		/// <param name="logType">Log type. See enum 'LogType'.</param>
		/// <param name="debugWriteLine">Optional: True, write the message to the Debug output.</param>
		public void Log(string message, LogType logType, bool debugWriteLine)
		{
			Log_Proc(message, logType, debugWriteLine);
		}

		// This delegate enables asynchronous calls for setting the text property on the output log.
		delegate void LogCallback(string message, LogType logType, bool debugWriteLine);

		// WARNING: Don't call this directly, please call `Log` instead.
		private void Log_Proc(string message, LogType logType, bool debugWriteLine)
		{
			// InvokeRequired required compares the thread ID of the 
			// calling thread to the thread ID of the creating thread. 
			// If these threads are different, it returns true.
			if (text_OutputLog.InvokeRequired)
			{
				LogCallback cb = new LogCallback(Log_Proc);
				BeginInvoke(cb, new object[] { message, logType, debugWriteLine });
			}
			else
			{
				if (debugWriteLine)
					Debug.WriteLine(message);

				string timestamp = "";
				if (prefs.LogPrintTimestamps)
					timestamp = Utilities.GetTimestamp();

				string typeInfo = "";
				if (logType != LogType.None)
					typeInfo = logType.ToString();

				string messageToLog = String.Format("{0} [{1}]\t{2}\r\n", timestamp, typeInfo, message);

				// Log the message to the log file
				if (prefs.OutputLogToFile)
					File.AppendAllText(ZeroMungeLog, messageToLog);

				// Log the message to the textbox
				AppendToTextArea(messageToLog);
			}
		}

		private void AppendToTextArea(string msg)
		{
			text_OutputLog.AppendText(msg);
			if(text_OutputLog.Lines.Length > prefs.LogMaxLineCount)
			{
				// take the last 'n' lines
				int n = prefs.LogMaxLineCount;
				ArraySegment<String> seg = new ArraySegment<string>(text_OutputLog.Lines, text_OutputLog.Lines.Length - n, n);
				text_OutputLog.Lines = seg.ToArray();
			}
			text_OutputLog.SelectionStart = text_OutputLog.Text.Length;
			text_OutputLog.ScrollToCaret();
		}

		#endregion Output Log : Logic


		#region Output Log : Form Controls

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

				Log(string.Format("Saved log file to path: \"{0}\"", name), LogType.Info);

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


		// When the Output Log's text is changed:
		// Scroll to the bottom of the output log, deal with the log being full, and update the line count.
		private void text_OutputLog_TextChanged(object sender, EventArgs e)
		{
			// Update character count
			stat_LogLength.Text = string.Concat("length : ", text_OutputLog.Text.Count().ToString("N0"));

			// Update line count
			stat_LogLines.Text = string.Concat("lines : ", text_OutputLog.Lines.Count().ToString("N0"));
		}


		// When a link in the Output Log is clicked:
		// Open the link in a web browser.
		private void text_OutputLog_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}

		#endregion Output Log : Form Controls

		#endregion Output Log


		#region Toggle UI

		// ***************************
		// ** TOGGLE UI
		// ***************************

		public bool UIEnabled = true;


		/// <summary>
		/// Sets the enabled state of the application's UI controls.
		/// This method is executed on the worker thread and makes a thread-safe call on the UI controls.
		/// </summary>
		/// <param name="enabled">True to enable UI interactivity, false to disable.</param>
		public void EnableUI(bool enabled)
		{
			EnableUI_Proc(enabled);
		}

		// This delegate enables asynchronous calls for setting the enabled property on the UI control.
		delegate void EnableUICallback(bool enabled);

		// WARNING: Don't call this directly, please call `EnableUI` instead.
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
				UIEnabled = enabled;

				// Buttons
				btn_Run.Enabled = enabled;
				btn_Cancel.Enabled = !enabled;
				btn_EasyFilePicker.Enabled = enabled;
				btn_AddFiles.Enabled = enabled;
				btn_AddFolders.Enabled = enabled;
				btn_AddProject.Enabled = enabled;
				btn_RemoveFile.Enabled = enabled;
				btn_RemoveAllFiles.Enabled = enabled;
				btn_SetGamePath.Enabled = enabled;

				btn_OpenMungeLog.Enabled = enabled;
				btn_SaveLog.Enabled = enabled;
				btn_ClearLog.Enabled = enabled;
				btn_clean.Enabled = enabled;


				// Status Strip
				stat_UpdateLink.Enabled = enabled;


				// File list
				data_Files.Enabled = enabled;


				// Tray icon context menu
				cmenu_TrayIcon_Run.Enabled = enabled;
				cmenu_TrayIcon_Cancel.Enabled = !enabled;
				cmenu_TrayIcon_Quit.Enabled = enabled;


				// Menu strip context menus
				// File menu
				menu_newToolStripMenuItem.Enabled = enabled;
				menu_openToolStripMenuItem.Enabled = enabled;
				menu_saveToolStripMenuItem.Enabled = enabled;
				menu_saveAsToolStripMenuItem.Enabled = enabled;
				menu_exitToolStripMenuItem.Enabled = enabled;
				menu_openRecentToolStripMenuItem.Enabled = enabled;
				menu_strip_platform.Enabled = enabled;

				// Actions menu
				menu_runToolStripMenuItem.Enabled = enabled;
				menu_cancelToolStripMenuItem.Enabled = !enabled;
				menu_easyFilePickerToolStripMenuItem.Enabled = enabled;
				menu_addFilesToolStripMenuItem.Enabled = enabled;
				menu_addFoldersToolStripMenuItem.Enabled = enabled;
				menu_addProjectToolStripMenuItem.Enabled = enabled;
				menu_removeToolStripMenuItem.Enabled = enabled;
				menu_removeAllToolStripMenuItem.Enabled = enabled;

				// Tools menu
				menu_createSideMungeFolderToolStripMenuItem.Enabled = enabled;
				menu_createWorldMungeFolderToolStripMenuItem.Enabled = enabled;
				menu_fixWorldMungeScriptsToolStripMenuItem.Enabled = enabled;
				menu_fixSoundMungeFilesToolStripMenuItem.Enabled = enabled;
				menu_modifyMungedSoundFoldersToolStripMenuItem.Enabled = enabled;
				menu_addMission.Enabled = enabled;

				// Log menu
				menu_logSubToolStripMenuItem.Enabled = enabled;
				menu_copyLogToolStripMenuItem.Enabled = enabled;
				menu_saveLogAsToolStripMenuItem.Enabled = enabled;
				menu_clearLogToolStripMenuItem.Enabled = enabled;

				// Settings menu
				menu_setGamePathToolStripMenuItem.Enabled = enabled;
				menu_prefsToolStripMenuItem.Enabled = enabled;

				// Help menu
				menu_viewHelpToolStripMenuItem.Enabled = enabled;
				menu_viewChangelogToolStripMenuItem.Enabled = enabled;
				menu_viewLicenseToolStripMenuItem.Enabled = enabled;
				menu_viewReadmeToolStripMenuItem.Enabled = enabled;
				menu_provideFeedbackToolStripMenuItem.Enabled = enabled;
				menu_checkForUpdatesToolStripMenuItem.Enabled = enabled;
				menu_aboutToolStripMenuItem.Enabled = enabled;

				mungePanel.Enabled = enabled;
			}
		}

		#endregion Toggle UI


		#region Windows Form Controls

		// ***************************
		// ** WINDOWS FORMS CONTROLS
		// ***************************

		#region File List : DataGridView

		#region File List : Fields

		/// <summary>
		/// Index of currently selected row in data_Files.
		/// </summary>
		public int data_Files_CurSelectedRow = 0;

		/// <summary>
		/// Index of currently selected column in data_Files.
		/// </summary>
		public int data_Files_CurSelectedColumn = 0;

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
		/// Last directory user was in for the openDlg_OpenFileListPrompt.
		/// </summary>
		public string openFileListLastDir = Directory.GetCurrentDirectory();

		/// <summary>
		/// Last directory user was in for the saveDlg_SaveFileListPrompt.
		/// </summary>
		public string saveFileListLastDir = Directory.GetCurrentDirectory();

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
		/// Name of the file list's current save file.
		/// </summary>
		public string curFileListName = "null";

		/// <summary>
		/// File path of the file list's current save file.
		/// </summary>
		public string curFileListPath = "null";

		/// <summary>
		/// Whether or not the file list is dirty.
		/// </summary>
		public bool isFileListDirty = false;

		/// <summary>
		/// Last method that was used to change the contents of a cell.
		/// </summary>
		public CellChangeMethod lastCellChangeMethod = CellChangeMethod.Button;

		#endregion File List : Fields


		#region File List : Logic Methods

		/// <summary>
		/// Returns a list of files that are currently checkmarked in the file list.
		/// </summary>
		/// <param name="arg">if cleaning, set arg="clean", otherwise it'll get the munge files</param>
		/// <returns>List<MungeFactory> of files that are checkmarked.</returns>
		public List<MungeFactory> GetCheckedFiles(string arg="")
		{
			List<MungeFactory> checkedFiles = new List<MungeFactory>();

			Debug.WriteLine("There are " + (data_Files.RowCount - 1) + " rows");

			foreach (DataGridViewRow row in data_Files.Rows)
			{
				Debug.WriteLine("Row " + row.Index + ", entered");

				// Add the file to the list if all its fields are correct and valid (note: StagingDirectory isn't required)
				if (row.Cells[STR_DATA_FILES_CHK_ENABLED].Value != null &&
					row.Cells[STR_DATA_FILES_TXT_MUNGE_DIR].Value != null)
				{
					if (row.Cells[STR_DATA_FILES_CHK_ENABLED].Value.ToString() == "True")
					{
						if (row.Cells[STR_DATA_FILES_CHK_ENABLED].Value == null)
						{
							Debug.WriteLine("WARNING! Row at index " + row.Index + " isn't enabled!");
						}

						if (row.Cells[STR_DATA_FILES_TXT_FILE].Value == null)
						{
							var message = "FilePath at row index " + row.Index + " isn't specified!";
							Log(message, LogType.Error, true);
						}

						if (row.Cells[STR_DATA_FILES_TXT_STAGING].Value == null)
						{
							var message = "StagingDirectory at row index " + row.Index + " isn't specified!";
							Log(message, LogType.Warning);
						}

						if (row.Cells[STR_DATA_FILES_TXT_MUNGE_DIR].Value == null)
						{
							var message = "MungeDirectory at row index " + row.Index + " isn't specified!";
							Log(message, LogType.Error, true);
						}

						if (row.Cells[STR_DATA_FILES_TXT_MUNGED_FILES].Value == null)
						{
							var message = "MungedFiles at row index " + row.Index + " isn't specified!";
							Log(message, LogType.Warning, true);
						}


						if (!File.Exists(row.Cells[STR_DATA_FILES_TXT_FILE].Value.ToString()))
						{
							var message = "FilePath at row index " + row.Index + " cannot be found!";
							Log(message, LogType.Error, true);
						}

						Debug.WriteLine(row.Cells[STR_DATA_FILES_TXT_FILE].Value.ToString());
						if (row.Cells[STR_DATA_FILES_TXT_STAGING].Value != null)
						{
							Debug.WriteLine(row.Cells[STR_DATA_FILES_TXT_STAGING].Value.ToString());
						}
						Debug.WriteLine(row.Cells[STR_DATA_FILES_TXT_MUNGE_DIR].Value.ToString());


						// Construct a new MungeFactory object and initialize our data into it
						MungeFactory fileInfo = new MungeFactory
						{
							CopyToStaging = row.Cells[STR_DATA_FILES_CHK_COPY].Value.ToString(),    // 'Copy' data
							FileDir = row.Cells[STR_DATA_FILES_TXT_FILE].Value.ToString(),          // 'File directory' data
							MungeDir = row.Cells[STR_DATA_FILES_TXT_MUNGE_DIR].Value.ToString()     // 'Munge directory' data
						};

						// 'Staging directory' data
						if (row.Cells[STR_DATA_FILES_TXT_STAGING].Value != null)
						{
							fileInfo.StagingDir = row.Cells[STR_DATA_FILES_TXT_STAGING].Value.ToString();
						}

						// 'Munged files' data
						if (row.Cells[STR_DATA_FILES_TXT_MUNGED_FILES].Value != null)
						{
							fileInfo.MungedFiles = Utilities.ExtractLines(row.Cells[STR_DATA_FILES_TXT_MUNGED_FILES].Value.ToString());
						}

						if("clean".Equals(arg, StringComparison.OrdinalIgnoreCase))
						{
							string target = fileInfo.FileDir.Replace("munge.bat", "clean.bat");
							if (File.Exists(target) && target.IndexOf("clean") > -1)
								fileInfo.FileDir = target;
							else
								fileInfo = null;
						}
						if (fileInfo != null)
						{
							// Add our MungeFactory object to the checked files list
							checkedFiles.Add(fileInfo);
						}
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
		/// Adds the specified file path to the file list. It is assumed that the file is not a munge script.
		/// </summary>
		/// <param name="file">Full path of file to add.</param>
		/// <returns>True if the file was successfully added, false if not.</returns>
		public bool AddFile(string file)
		{
			return AddFile(file, true);
		}
		/// <summary>
		/// Adds the specified file path to the file list.
		/// </summary>
		/// <param name="file">Full path of file to add.</param>
		/// <param name="isMungeScript">Whether or not the specified file is a munge script.</param>
		/// <returns>True if the file was successfully added, false if not.</returns>
		public bool AddFile(string file, bool isMungeScript)
		{
			// Does the file path exist?
			if (File.Exists(file))
			{
				if (isMungeScript && !IsWorldMungeFileValid(file) && new DirectoryInfo(file).Parent.Parent.Name.ToLower() == "worlds")
				{
					string worldName = new DirectoryInfo(file).Parent.Name;

					DialogResult result = MessageBox.Show("World " + worldName + " appears to have an incorrect munge.bat file. Attempt to fix?", "Fix World Munge Script", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						FixWorldMungeScript(file, worldName);
					}
				}

				try
				{
					// Add the file to the list
					if (data_Files.SelectedCells.Count >= 0)
					{
						// Auto-set the staging directory if the game directory has been set
						if (prefs.GameDirectory != "")
						{
							string projectStagingRoot = prefs.GameDirectory + "\\addon\\" + Utilities.GetProjectID(file);
							string stagingDirectory = "";
							string mungeOutputDirectory = "";
							string compiledFiles = "";

							List<string> compiledFilesList = Utilities.GetCompiledFiles(file);

							Debug.WriteLine(Utilities.GetProjectID(file));

							// Set the file's staging directory based on the file's munge type (e.g., side, world, common)
							switch (Utilities.GetMungeType(file))
							{
								default:
									stagingDirectory = "nil";
									break;
								case Utilities.MungeTypes.Addme:
									stagingDirectory = projectStagingRoot + "\\";
									break;
								case Utilities.MungeTypes.Common:
									stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\";
									break;
								case Utilities.MungeTypes.Load:
									stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\Load\\";
									break;
								case Utilities.MungeTypes.Shell:
									stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\";
									break;
								case Utilities.MungeTypes.Side:
									stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\SIDE\\";
									break;
								case Utilities.MungeTypes.Sound:
									stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\Sound\\";
									break;
								case Utilities.MungeTypes.World:
									stagingDirectory = projectStagingRoot + "\\data\\_LVL_PC\\" + Utilities.GetProjectID(file) + "\\";
									break;
							}

							// Get the file's munge output directory
							mungeOutputDirectory = Utilities.GetMungeDirectory(file);


							// Remove any duplicate backslashes
							file = file.Replace(@"\\", @"\");
							stagingDirectory = stagingDirectory.Replace(@"\\", @"\");
							mungeOutputDirectory = mungeOutputDirectory.Replace(@"\\", @"\");


							// Assemble a multi-line string of the compiled files' names
							foreach (string compiledFile in compiledFilesList)
							{
								compiledFiles = string.Concat(compiledFiles, compiledFile, "\n");
							}


							// Make all data values nil if file isn't a munge script (except for the File Path value)
							if (!isMungeScript)
							{
								stagingDirectory = "nil";
								mungeOutputDirectory = "nil";
								compiledFiles = "nil";

								var message = "File is not a munge script, copy operations will be disabled for it";
								Log(message, LogType.Info, true);
							}


							if (!prefs.AutoDetectStagingDir)
							{
								stagingDirectory = "nil";

								var message = "Not setting Staging Directory in accordance with user preferences";
								Log(message, LogType.Info, true);
							}


							if (!prefs.AutoDetectMungedFiles)
							{
								compiledFiles = "nil";

								var message = "Not setting Munged Files in accordance with user preferences";
								Log(message, LogType.Info, true);
							}


							// Are none of the rows selected? (i.e., did the user click the "Add Files..." button?)
							if (data_Files_CurSelectedRow == -1)
							{
								// Create a new row first
								int rowId = data_Files.Rows.Add();

								// Grab the new row
								DataGridViewRow newRow = data_Files.Rows[rowId];

								// Initialize data into the new row
								newRow.Cells[STR_DATA_FILES_CHK_ENABLED].Value = true;
								newRow.Cells[STR_DATA_FILES_CHK_COPY].Value = isMungeScript;
								newRow.Cells[STR_DATA_FILES_TXT_FILE].Value = file;
								newRow.Cells[STR_DATA_FILES_TXT_STAGING].Value = stagingDirectory;
								newRow.Cells[STR_DATA_FILES_TXT_MUNGE_DIR].Value = mungeOutputDirectory;
								newRow.Cells[STR_DATA_FILES_TXT_MUNGED_FILES].Value = compiledFiles;
								newRow.Cells[STR_DATA_FILES_CHK_IS_MUNGE_SCRIPT].Value = isMungeScript;
							}
							else
							{
								// Add a blank row to the bottom of the list if we're not updating an existing row
								if (data_Files[INT_DATA_FILES_TXT_FILE, data_Files_CurSelectedRow].Value == null)
								{
									data_Files.Rows.Add();
								}

								// Initialize data into the new row
								data_Files[INT_DATA_FILES_CHK_ENABLED, data_Files_CurSelectedRow].Value = true;
								data_Files[INT_DATA_FILES_CHK_COPY, data_Files_CurSelectedRow].Value = isMungeScript;
								data_Files[INT_DATA_FILES_TXT_FILE, data_Files_CurSelectedRow].Value = file;
								data_Files[INT_DATA_FILES_TXT_STAGING, data_Files_CurSelectedRow].Value = stagingDirectory;
								data_Files[INT_DATA_FILES_TXT_MUNGE_DIR, data_Files_CurSelectedRow].Value = mungeOutputDirectory;
								data_Files[INT_DATA_FILES_TXT_MUNGED_FILES, data_Files_CurSelectedRow].Value = compiledFiles;
								data_Files[INT_DATA_FILES_CHK_IS_MUNGE_SCRIPT, data_Files_CurSelectedRow].Value = isMungeScript;
							}


							Log("");
							Log(string.Format("Adding file: \"{0}\"", file), LogType.Info);
							Log(string.Format("Staging directory: \"{0}\"", stagingDirectory), LogType.Info);
							Log(string.Format("Munge output directory: \"{0}\"", mungeOutputDirectory), LogType.Info);


							// Reset the stored index of the currently selected row
							data_Files_CurSelectedRow = -1;
						}
						else
						{
							var message = "Game path not set";
							Log(message, LogType.Error, true);

							return false;
						}
					}

					return true;
				}
				catch (ArgumentOutOfRangeException ex)
				{
					var msg = "ArgumentOutOfRangeException when adding files to the file list. Reason: " + ex.Message;
					Trace.WriteLine(msg);
					Log(msg, LogType.Error);
					throw;
				}
				catch (IndexOutOfRangeException ex)
				{
					var msg = "IndexOutOfRangeException when adding files to the file list. Reason: " + ex.Message;
					Trace.WriteLine(msg);
					Log(msg, LogType.Error);
					throw;
				}
			}
			else
			{
				var message = string.Format("Could not find file at path: \"{0}\"", file);
				Log(message, LogType.Error, true);

				return false;
			}
		}


		/// <summary>
		/// Serializes the contents of the file list and saves them to the specified file path.
		/// </summary>
		/// <param name="filePath">File path to save the contents of the file list to.</param>
		public void SerializeData(string filePath)
		{
			DataFilesContainer saveData = new DataFilesContainer();
			saveData.FileVersion = Properties.Settings.Default.Info_SaveFileVersion;
			saveData.AppVersion = Properties.Settings.Default.Info_Version;

			foreach (DataGridViewRow row in data_Files.Rows)
			{
				if (!row.IsNewRow)
				{
					try
					{
						DataFilesRow rowData = new DataFilesRow();

						rowData.Enabled = (bool)row.Cells[INT_DATA_FILES_CHK_ENABLED].Value;
						rowData.Copy = (bool)row.Cells[INT_DATA_FILES_CHK_COPY].Value;
						rowData.IsMungeScript = (bool)row.Cells[INT_DATA_FILES_CHK_IS_MUNGE_SCRIPT].Value;
						rowData.IsValid = (bool)row.Cells[INT_DATA_FILES_CHK_IS_VALID].Value;

						if (row.Cells[INT_DATA_FILES_TXT_FILE].Value != null)
							rowData.FilePath = row.Cells[INT_DATA_FILES_TXT_FILE].Value.ToString();
						else
							rowData.FilePath = "";

						if (row.Cells[INT_DATA_FILES_TXT_STAGING].Value != null)
							rowData.StagingDir = row.Cells[INT_DATA_FILES_TXT_STAGING].Value.ToString();
						else
							rowData.StagingDir = "";

						if (row.Cells[INT_DATA_FILES_TXT_MUNGE_DIR].Value != null)
							rowData.MungeDir = row.Cells[INT_DATA_FILES_TXT_MUNGE_DIR].Value.ToString();
						else
							rowData.MungeDir = "";

						if (row.Cells[INT_DATA_FILES_TXT_MUNGED_FILES].Value != null)
							rowData.MungedFiles = row.Cells[INT_DATA_FILES_TXT_MUNGED_FILES].Value.ToString();
						else
							rowData.MungedFiles = "";


						saveData.AddRow(rowData);
					}
					catch (NullReferenceException e)
					{
						var message = "Failed to write row " + row.Index.ToString() + " to file. Reason: " + e.Message;
						Trace.WriteLine(message);
						Log(message, LogType.Error);
					}
				}
			}

			// Attempt to save the binary file
			FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
			try
			{
				// Serialize and save the data
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(fs, saveData);
			}
			catch (SerializationException e)
			{
				Trace.WriteLine("Failed to serialize. Reason: " + e.Message);
				Log("Failed to serialize. Reason: " + e.Message, LogType.Error);
				throw;
			}
			catch (IOException e)
			{
				var msg = string.Format("Failed to write to file path: \"{0}\". Reason: {1}", filePath, e.Message);
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
				throw;
			}
			finally
			{
				fs.Close();
			}
		}


		/// <summary>
		/// Deserializes the file at the specified file path and returns the results.
		/// </summary>
		/// <param name="filePath">File path of the file containing the contents of the file list to deserialize.</param>
		/// <returns>The deserialized contents of the inputted file list.</returns>
		public DataFilesContainer DeserializeData(string filePath)
		{
			// Declare an object variable of the type to be deserialized
			DataFilesContainer data = null;

			// Attempt to read the binary file
			FileStream fs = new FileStream(filePath, FileMode.Open);
			try
			{
				IFormatter formatter = new BinaryFormatter();

				// Deserialize and store the data
				data = (DataFilesContainer)formatter.Deserialize(fs);

				// Ensure that the save file is compatible with this version of the application
				if (data.FileVersion == 0)
				{
					Log("Specified file was saved with a previous version of Zero Munge and might not be fully compatible with this version", LogType.Warning);
				}
				else if (data.FileVersion < Properties.Settings.Default.Info_SaveFileVersion)
				{
					Log("Specified file is incompatible with this version of Zero Munge", LogType.Error);
					Log(string.Format("Failed to read from file path: \"{0}\"", filePath), LogType.Error);
				}
			}
			catch (SerializationException e)
			{
				Trace.WriteLine("Failed to deserialize. Reason: " + e.Message);
				Log("Failed to deserialize. Reason: " + e.Message, LogType.Error);
				Log("Specified file is likely incompatible with this version of Zero Munge", LogType.Error);
				Log(string.Format("Failed to read from file path: \"{0}\"", filePath), LogType.Error);
				//throw;
			}
			catch (IOException e)
			{
				var msg = string.Format("Failed to read from file path: \"{0}\". Reason: {1}", filePath, e.Message);
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
				throw;
			}
			finally
			{
				fs.Close();
			}

			Trace.WriteLineIf(data == null || data.DataRows == null, string.Format("WARNING: No data was found in the file: \"{0}\"", filePath));

			return data;
		}


		/// <summary>
		/// Removes all committed rows from the file list.
		/// </summary>
		public void ClearFileList()
		{
			data_Files.Rows.Clear();
		}


		/// <summary>
		/// Reset the row selection to the bottom of the file list.
		/// </summary>
		public void SelectLastRow()
		{
			data_Files.ClearSelection();
			data_Files[INT_DATA_FILES_BTN_FILE_BROWSE, data_Files.RowCount - 1].Selected = true;
			data_Files_CurSelectedRow = data_Files.RowCount - 1;
		}


		/// <summary>
		/// Loads data from the specified DataFilesContainer into the file list.
		/// </summary>
		/// <param name="data">DataFilesContainer object containing the data to load into the file list.</param>
		/// <param name="replaceCurrentContents">Whether or not to clear the contents of the file list before loading the new data into it. Default = true</param>
		public bool LoadDataIntoFileList(DataFilesContainer data, string filePath, bool replaceCurrentContents = true)
		{
			try
			{
				if (data.DataRows == null)
				{
					var msg = string.Format("No data was found in the file: \"{0}\"", filePath);
					Trace.WriteLine(msg);
					Log(msg, LogType.Error);

					return false;
				}

				// Clear the contents of the file list if specified
				if (replaceCurrentContents)
				{
					ClearFileList();
				}

				// Fill the file list with the data from the provided container
				foreach (DataFilesRow row in data.DataRows)
				{
					// Create a new row first
					int rowId = data_Files.Rows.Add();

					// Grab the new row
					DataGridViewRow newRow = data_Files.Rows[rowId];

					// Initialize data into the new row
					newRow.Cells[STR_DATA_FILES_CHK_ENABLED].Value = row.Enabled;
					newRow.Cells[STR_DATA_FILES_CHK_COPY].Value = row.Copy;
					newRow.Cells[STR_DATA_FILES_TXT_FILE].Value = row.FilePath;
					newRow.Cells[STR_DATA_FILES_TXT_STAGING].Value = row.StagingDir;
					newRow.Cells[STR_DATA_FILES_TXT_MUNGE_DIR].Value = row.MungeDir;
					newRow.Cells[STR_DATA_FILES_TXT_MUNGED_FILES].Value = row.MungedFiles;
					newRow.Cells[STR_DATA_FILES_CHK_IS_MUNGE_SCRIPT].Value = row.IsMungeScript;
					newRow.Cells[STR_DATA_FILES_CHK_IS_VALID].Value = row.IsValid;
				}
			}
			catch (NullReferenceException e)
			{
				Trace.WriteLine("Failed to load data into file list. Reason: " + e.Message);
				Log("File does not contain any data to load", LogType.Error);
				//throw;
			}
			catch (InvalidOperationException e)
			{
				Trace.WriteLine("Invalid operation while adding row. Reason: " + e.Message);
				Log("Invalid operation while adding row. Reason: " + e.Message, LogType.Error);
				throw;
			}


			// Update the current file list and window title
			UpdateCurFileListInfo(filePath);
			FileListIsDirty(false);
			UpdateWindowTitle();

			return true;
		}


		/// <summary>
		/// Saves the contents of the file list to the specified file path.
		/// </summary>
		/// <param name="filePath">File path to save the file list to.</param>
		/// <param name="isAutoSave">Whether or not this an auto-save.</param>
		private void SaveFileListToFile(string filePath, bool isAutoSave, bool inExitFlow)
		{
			// Serialize and save the data
			SerializeData(filePath);

			string autoSaveMsg = "";
			if (isAutoSave) autoSaveMsg = "Auto-save is enabled. ";
			Log(string.Format("{0}Saving file list to path: \"{1}\"", autoSaveMsg, filePath), LogType.Info);

			prefs.LastSaveFilePath = filePath;
			Utilities.SavePrefs(prefs);

			// Update the current file list and window title
			UpdateCurFileListInfo(filePath);
			FileListIsDirty(false);
			UpdateWindowTitle();
		}


		/// <summary>
		/// Sets whether or not the file list is dirty.
		/// </summary>
		/// <param name="dirty">True, file list is dirty. False, file list is not dirty.</param>
		private void FileListIsDirty(bool dirty)
		{
			Debug.WriteLine("File list is dirty: " + dirty);

			isFileListDirty = dirty;
		}


		/// <summary>
		/// Checks whether or not the file list contains any filled rows.
		/// </summary>
		/// <returns>True, file list contains one or more filled rows. False, it's empty.</returns>
		public bool IsFileListEmpty()
		{
			var rows = data_Files.Rows;

			foreach (DataGridViewRow row in rows)
			{
				// Are all of the string cells null?
				foreach (DataGridViewCell cell in row.Cells)
				{
					if (cell.Value is string)
					{
						if ((string)cell.Value != null && cell.ColumnIndex != INT_DATA_FILES_TXT_MUNGED_FILES)
						{
							return false;
						}
					}
				}
			}

			return true;
		}


		/// <summary>
		/// Update the current file list's save file path and name.
		/// </summary>
		/// <param name="filePath">New file path to save.</param>
		private void UpdateCurFileListInfo(string filePath)
		{
			curFileListPath = filePath;
			DirectoryInfo dir = new DirectoryInfo(curFileListPath);
			curFileListName = dir.Name;
		}


		/// <summary>
		/// Resets the current file list path and name.
		/// </summary>
		private void ResetCurFileListInfo()
		{
			curFileListPath = "null";
			curFileListName = "null";

			prefs.LastSaveFilePath = "UNSET";
			Utilities.SavePrefs(prefs);
		}


		/// <summary>
		/// Gets the type of DataGridViewColumn represented as a string.
		/// </summary>
		/// <param name="column">DataGridViewColumn to get the type of.</param>
		/// <returns>Possible values: 'TextBox', 'Button', 'CheckBox', or 'nil'.</returns>
		private string GetColumnType(DataGridViewColumn column)
		{
			if (column is DataGridViewTextBoxColumn)
			{
				return "TextBox";
			}
			else if (column is DataGridViewButtonColumn)
			{
				return "Button";
			}
			else if (column is DataGridViewCheckBoxColumn)
			{
				return "CheckBox";
			}
			else
			{
				return "nil";
			}
		}


		/// <summary>
		/// Handles the logic for when a cell button is clicked based on which column the button belongs to.
		/// </summary>
		/// <param name="fileIsNull">Is the File Path cell's value null?</param>
		private void HandleCellButtonClicked(bool fileIsNull)
		{
			switch (data_Files_CurSelectedColumn)
			{
				case INT_DATA_FILES_BTN_FILE_BROWSE:     // col_FileBrowse
														 // Open the 'Add Files' prompt
					openDlg_AddFilesPrompt.InitialDirectory = addFilesLastDir;
					openDlg_AddFilesPrompt.ShowDialog();
					break;

				case INT_DATA_FILES_BTN_STAGING_BROWSE:     // col_StagingBrowse
															// Fire the faux-event for the button
					if (!fileIsNull)
					{
						btn_SetStaging_Click();
					}
					break;

				case INT_DATA_FILES_BTN_MUNGED_FILES_EDIT:     // col_MungedFilesEdit
															   // Fire the faux-event for the button
					if (!fileIsNull)
					{
						btn_MungedFilesEdit_Click();
					}
					break;
			}
		}


		/// <summary>
		/// Checks whether or not the specified DataGridViewCell has a valid string value.
		/// </summary>
		/// <param name="cell">DataGridViewCell to check validity of. This should be a string cell.</param>
		/// <returns>False if value is null, blank, or "nil".</returns>
		private bool IsStringCellValueValid(DataGridViewCell cell)
		{
			if (cell.Value == null ||
				cell.Value.ToString() == "" ||
				cell.Value.ToString() == "nil")
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion File List : Logic Methods


		#region File List : data_Files

		// When the user clicks on a cell:
		// Reset the currently selected row header index.
		private void data_Files_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			lastCellChangeMethod = CellChangeMethod.Cell;

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


		// When a row is added to the File List:
		// Mark the File List as dirty and update the window title.
		private void data_Files_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			FileListIsDirty(true);
			UpdateWindowTitle();
		}


		// When a row is removed from the File List:
		// Mark the File List as dirty and update the window title.
		private void data_Files_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			FileListIsDirty(true);
			UpdateWindowTitle();
		}


		// When the user clicks on a cell in the file list:
		// Do something depending on the cell that was clicked on.
		private void data_Files_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var senderGrid = (DataGridView)sender;

			bool fileIsNull = false;
			string cellType = "nil";

			// Debug messages
			if (e.RowIndex >= 0)
			{
				// Determine the cell type
				cellType = GetColumnType(senderGrid.Columns[e.ColumnIndex]);

				if (cellType == "CheckBox")
				{
					FileListIsDirty(true);
					UpdateWindowTitle();
				}

				//Debug.WriteLine(cellType + " cell content clicked at row index " + e.RowIndex + ", column index " + e.ColumnIndex);
			}

			try
			{
				// Does the File Path cell contain actual data?
				fileIsNull = !IsStringCellValueValid(data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE]);

				if (fileIsNull)
				{
					if (data_Files_CurSelectedColumn != INT_DATA_FILES_BTN_FILE_BROWSE)
					{
						var message = "File Path must first be specified";
						Log(message, LogType.Error, true);
					}
				}
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Trace.WriteLine(ex.Message);
			}

			// Do stuff if the clicked cell's type was Button
			if (cellType == "Button" && e.RowIndex != -1)
			{
				HandleCellButtonClicked(fileIsNull);
			}
		}

		// When a cell's value in the file list has changed:
		// Validate or invalidate the cell.
		private void data_Files_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine("Cell value changed");
			//FileListIsDirty(true);
			//UpdateWindowTitle();

			var senderGrid = (DataGridView)sender;

			bool fileIsNull = false;
			//string cellType = "nil";

			if (e.ColumnIndex == INT_DATA_FILES_TXT_FILE)
			{
				Debug.WriteLine("File Path value was changed");
			}

			// Debug messages
			//if (e.RowIndex >= 0)
			//{
			//    // Determine the cell type
			//    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
			//    {
			//        cellType = "TextBox";
			//    }
			//    else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
			//    {
			//        cellType = "Button";
			//    }
			//    else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
			//    {
			//        cellType = "CheckBox";
			//    }

			//    //Debug.WriteLine(cellType + " cell content clicked at row index " + e.RowIndex + ", column index " + e.ColumnIndex);
			//}

			if (e.RowIndex < 0 || data_Files.Rows[e.RowIndex].IsNewRow) { return; }

			FileListIsDirty(true);
			UpdateWindowTitle();

			// Does the File Path cell contain actual data?
			if (data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value == null)
			{
				fileIsNull = true;

				if (data_Files_CurSelectedColumn != INT_DATA_FILES_BTN_FILE_BROWSE)
				{
					if (lastCellChangeMethod == CellChangeMethod.Cell)
					{
						var message = "File Path must first be specified";
						Log(message, LogType.Error, true);
					}
				}
			}

			// Do stuff if the edited cell's type was TextBox
			switch (e.ColumnIndex)
			{
				case INT_DATA_FILES_TXT_FILE:     // col_File
												  // Throw an error and color the cell red if the file at the specified path is blank, null, or doesn't exist
					if (fileIsNull)
					{
						data_Files_ValidateCell(e.RowIndex, INT_DATA_FILES_TXT_FILE, false);
						data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_CHK_IS_VALID].Value = false;

						var message = "File Path is blank";
						Log(message, LogType.Error, true);
					}
					else if (data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value.ToString() == "" ||
						!File.Exists(data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value.ToString()))
					{
						data_Files_ValidateCell(e.RowIndex, INT_DATA_FILES_TXT_FILE, false);
						data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_CHK_IS_VALID].Value = false;

						var message = string.Format("Could not find file at path: \"{0}\"", data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value.ToString());
						Log(message, LogType.Error, true);
					}
					else
					{
						data_Files_ValidateCell(e.RowIndex, INT_DATA_FILES_TXT_FILE, true);
						data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_CHK_IS_VALID].Value = true;
					}
					break;

				case INT_DATA_FILES_TXT_STAGING:     // col_Staging

					break;

				case INT_DATA_FILES_TXT_MUNGED_FILES:     // col_MungedFiles

					break;
			}
		}


		// When the user presses a key in the file list:
		// Do stuff depending on the key combination pressed.
		private void data_Files_KeyDown(object sender, KeyEventArgs e)
		{
			// When the key combination is Delete:
			// Clear the contents of the currently selected cell in the file list.
			if (e.KeyCode == Keys.Delete)
			{
				Debug.WriteLine("Delete was pressed");

				foreach (DataGridViewCell cell in data_Files.SelectedCells)
				{
					// Determine the cell type
					if (cell is DataGridViewTextBoxCell)
					{
						if (cell.Value != null)
						{
							cell.Value = "";
						}
					}
				}

				e.Handled = true;
			}
		}


		/// <summary>
		/// Validates or invalidates the cell in the given row and column. If the cell is valid, it's colored normally. If not, it's colored red.
		/// </summary>
		/// <param name="row">Index of row containing cell to validate.</param>
		/// <param name="column">Index of column containing cell to validate.</param>
		/// <param name="validate">True, validate cell. False, invalidate cell.</param>
		private void data_Files_ValidateCell(int row, int column, bool validate)
		{
			if (validate)
			{
				data_Files.Rows[row].Cells[column].Style.BackColor = data_Files.DefaultCellStyle.BackColor;
			}
			else
			{
				data_Files.Rows[row].Cells[column].Style.BackColor = errorRed;
			}
		}

		#endregion File List : data_Files


		#region File List : data_Files Custom Controls

		// This is called when the user clicks the Browse button to select a new staging directory for a file.
		// Prompt the user to select a new staging directory for the currently selected file.
		private void btn_SetStaging_Click()
		{
			if (data_Files[INT_DATA_FILES_TXT_STAGING, data_Files_CurSelectedRow].Value != null)
			{
				openDlg_SetStagingPrompt.Title = "Select Staging Directory";
				openDlg_SetStagingPrompt.InitialDirectory = data_Files[INT_DATA_FILES_TXT_STAGING, data_Files_CurSelectedRow].Value.ToString();
				openDlg_SetStagingPrompt.IsFolderPicker = true;
				openDlg_SetStagingPrompt.Multiselect = false;

				// Auto-detect the munge.bat file inside each selected folder and add it to the file list
				if (openDlg_SetStagingPrompt.ShowDialog() == CommonFileDialogResult.Ok)
				{
					var folder = openDlg_SetStagingPrompt.FileName;

					// Save the current directory
					setStagingLastDir = Utilities.GetFileDirectory(folder);

					// Set the staging directory if it exists
					if (Directory.Exists(folder))
					{
						data_Files[INT_DATA_FILES_TXT_STAGING, data_Files_CurSelectedRow].Value = folder;
					}
				}
			}
		}


		// This is called when the user clicks the dropdown button to edit the list of compiled files.
		// Show a multi-line textbox containing the contents of the compiled files list.
		private void btn_MungedFilesEdit_Click()
		{
			// Number of pixels to offset the textbox from the mouse cursor
			int positionOffset = 5;


			// Disable the form's Accept/Cancel Button handlers
			ActiveForm.AcceptButton = null;
			ActiveForm.CancelButton = null;


			// Assemble the location for the textbox
			Point newPosition = ActiveForm.PointToClient(Cursor.Position);
			newPosition.X = (newPosition.X - pan_MungedFilesEdit.Width) - positionOffset;
			newPosition.Y = (newPosition.Y) + positionOffset;

			// Set the location
			pan_MungedFilesEdit.Location = newPosition;
			pan_MungedFilesEdit.Parent = ActiveForm;


			// Populate the textbox's contents if there's any contents to populate
			if (data_Files[INT_DATA_FILES_TXT_MUNGED_FILES, data_Files_CurSelectedRow].Value != null)
			{
				text_MungedFilesEdit.Text = data_Files[INT_DATA_FILES_TXT_MUNGED_FILES, data_Files_CurSelectedRow].Value.ToString();
			}


			// Attach our keyboard/mouse event handlers
			text_MungedFilesEdit.KeyDown += text_MungedFilesEdit_KeyDown;

			data_Files.MouseClick += text_MungedFilesEdit_MouseClickOutside;
			menu_MainForm.MouseClick += text_MungedFilesEdit_MouseClickOutside;
			text_OutputLog.MouseClick += text_MungedFilesEdit_MouseClickOutside;
			flp_FileButtons.MouseClick += text_MungedFilesEdit_MouseClickOutside;
			this.MouseClick += text_MungedFilesEdit_MouseClickOutside;


			// Show and focus the textbox
			pan_MungedFilesEdit.Visible = true;
			text_MungedFilesEdit.Focus();
		}


		// When the user presses a key when the Munged Files Edit popup is open:
		// Depending on the key combination pressed, commit the text to the cell or dispose of it.
		private void text_MungedFilesEdit_KeyDown(object sender, KeyEventArgs e)
		{
			if ((ModifierKeys & Keys.Control) == Keys.Control)
			{
				if (e.KeyCode == Keys.Enter)
				{
					Debug.WriteLine("Ctrl + Enter was pressed");

					text_MungedFilesEdit_Commit();

					ActiveForm.AcceptButton = btn_Run;

					pan_MungedFilesEdit.Visible = false;
					text_MungedFilesEdit.KeyDown -= text_MungedFilesEdit_KeyDown;
					e.Handled = true;
				}

				/*if (e.KeyCode == Keys.C)
				{
					Debug.WriteLine("Ctrl + C was pressed");
					
					text_MungedFilesEdit.Copy();

					e.Handled = true;
				}

				if (e.KeyCode == Keys.V)
				{
					Debug.WriteLine("Ctrl + V was pressed");

					text_MungedFilesEdit.Paste();

					e.Handled = true;
				}

				if (e.KeyCode == Keys.A)
				{
					Debug.WriteLine("Ctrl + A was pressed");

					text_MungedFilesEdit.SelectAll();

					e.Handled = true;
				}*/
			}

			if (e.KeyCode == Keys.Escape)
			{
				Debug.WriteLine("Escape was pressed");

				text_MungedFilesEdit_Dispose();
				e.Handled = true;
			}

			/*if (e.KeyCode == Keys.Delete)
			{
				Debug.WriteLine("Delete was pressed");

				text_MungedFilesEdit.Text.Remove(text_MungedFilesEdit.SelectionStart, text_MungedFilesEdit.SelectionLength);
				
				e.Handled = true;
			}*/
		}


		// When the user clicks outside of the Munged Files Edit popup when it's open:
		// Dispose of any text entered in the popup.
		private void text_MungedFilesEdit_MouseClickOutside(object sender, EventArgs e)
		{
			text_MungedFilesEdit_Dispose();
		}


		/// <summary>
		/// Commit text in the Munged Files Edit popup to the corresponding cell.
		/// </summary>
		private void text_MungedFilesEdit_Commit()
		{
			// Do initial empty-line removal
			text_MungedFilesEdit.Text = Regex.Replace(text_MungedFilesEdit.Text, @"^\s*$(\n|\r|\r\n)", "", RegexOptions.Multiline);

			// Remove any empty lines that were somehow missed
			string[] lines = text_MungedFilesEdit.Lines;
			if (lines.Count() > 0 && (lines[lines.Length - 1] == "" || lines[lines.Length - 1] == "\n"))
			{
				Debug.WriteLine("Found empty line! EXTERMINATE, EXTERMINATE, EXTERMINATE...");

				// Convert to list, remove last element, convert back to array (C# arrays suuuuuuck)
				List<string> linesList = lines.ToList();
				linesList.RemoveAt(lines.Length - 1);
				lines = linesList.ToArray<string>();
			}


			// Commit text to cell
			text_MungedFilesEdit.Lines = lines;
			data_Files[INT_DATA_FILES_TXT_MUNGED_FILES, data_Files_CurSelectedRow].Value = text_MungedFilesEdit.Text;

			text_MungedFilesEdit_Dispose();
		}


		/// <summary>
		/// Close the Munged Files Edit popup.
		/// </summary>
		private void text_MungedFilesEdit_Dispose()
		{
			pan_MungedFilesEdit.Visible = false;
			text_MungedFilesEdit.Text = "";

			// Re-enable the form's Accept/Cancel Button handlers
			ActiveForm.AcceptButton = btn_Run;
			ActiveForm.CancelButton = btn_Cancel;

			// Detach our event handlers
			text_MungedFilesEdit.KeyDown -= text_MungedFilesEdit_KeyDown;
			data_Files.MouseClick -= text_MungedFilesEdit_MouseClickOutside;
			menu_MainForm.MouseClick -= text_MungedFilesEdit_MouseClickOutside;
			text_OutputLog.MouseClick -= text_MungedFilesEdit_MouseClickOutside;
			flp_FileButtons.MouseClick -= text_MungedFilesEdit_MouseClickOutside;
			this.MouseClick -= text_MungedFilesEdit_MouseClickOutside;
		}

		#endregion File List : data_Files Custom Controls

		#endregion File List : DataGridView


		#region File List : Sidebar Buttons

		// When the user clicks the "Easy File Picker" button:
		// Open the Easy File Picker.
		private void btn_EasyFilePicker_Click(object sender, EventArgs e)
		{
			OpenWindow_EasyFilePicker();
		}


		// When the user clicks the "Run" button:
		// Begin processing the list of files as a playlist.
		private void btn_Run_Click(object sender, EventArgs e)
		{
			StartMunge();
		}


		// When the user clicks the "Cancel" button:
		// Abort the active process and stop processing files.
		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			ProcessManager.Abort(this);
		}


		// When the user clicks the "Add Files..." button:
		// Prompt the user to select files to add to the file list.
		private void btn_AddFiles_Click(object sender, EventArgs e)
		{
			menu_alternateUI.Checked = false;
			lastCellChangeMethod = CellChangeMethod.Button;
			SelectLastRow();

			// Set the initial directory to the previous-most one
			openDlg_AddFilesPrompt.InitialDirectory = addFilesLastDir;

			// Open the 'Add Files' prompt
			openDlg_AddFilesPrompt.ShowDialog();
		}


		// When the user clicks the "OK" button in the "Add Files..." prompt:
		// Add the selected files to the file list.
		private void openDlg_AddFilesPrompt_FileOk(object sender, CancelEventArgs e)
		{
			// Save the current directory
			addFilesLastDir = Utilities.GetFileDirectory(openDlg_AddFilesPrompt.FileNames[0]);

			// Add each file to the list
			foreach (string file in openDlg_AddFilesPrompt.FileNames)
			{
				if (File.Exists(file))
				{
					// Determine whether or not the file is a munge script
					bool isMungeScript = new DirectoryInfo(file).Name.Contains("munge");

					// And add the file to the list
					AddFile(file, isMungeScript);
				}
			}
		}


		// When the user clicks the "Add Folders..." button:
		// Prompt the user to select folders containing munge.bat files to add to the file list.
		private void btn_AddFolders_Click(object sender, EventArgs e)
		{
			menu_alternateUI.Checked = false;
			lastCellChangeMethod = CellChangeMethod.Button;

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
					addFoldersLastDir = Utilities.GetFileDirectory(folder);

					if (File.Exists(file))
					{
						// Add the file to the list
						AddFile(file);
					}
					else
					{
						var message = string.Format("Could not find file at path: \"{0}\"", file);
						Log(message, LogType.Error, true);
					}
				}
			}
		}


		// When the user clicks the "Add Project..." button:
		// Prompt the user to select a project to add to the file list.
		private void btn_AddProject_Click(object sender, EventArgs e)
		{
			lastCellChangeMethod = CellChangeMethod.Button;

			openDlg_AddProjectPrompt.Title = "Select Project Folder";
			openDlg_AddProjectPrompt.InitialDirectory = addProjectLastDir;
			openDlg_AddProjectPrompt.IsFolderPicker = true;
			//openDlg_AddProjectPrompt.Multiselect = true;

			// Auto-detect the munge.bat file inside each selected folder and add it to the file list
			if (openDlg_AddProjectPrompt.ShowDialog() == CommonFileDialogResult.Ok)
			{
				AddProject(openDlg_AddProjectPrompt.FileName);
			}
			InitializeAlternateUI();
		}

		private void AddProject(string projectPath)
		{
			var projectID = Utilities.GetProjectID(projectPath);

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

				// Assemble the complete file path of the munge.bat file
				var path = projectPath + theFile;

				// Save the current directory
				addProjectLastDir = Utilities.GetFileDirectory(projectPath);

				// Add the file to the list
				AddFile(path);
			}
		}


		// When the user clicks the "Remove" button:
		// Remove the selected file from the file list.
		private void btn_RemoveFile_Click(object sender, EventArgs e)
		{
			menu_alternateUI.Checked = false;
			lastCellChangeMethod = CellChangeMethod.Button;

			// Don't continue if there aren't any files in the list
			if (data_Files.RowCount <= 0)
			{
				Log("File list must contain at least one file", LogType.Error);

				// Re-enable the UI
				EnableUI(true);

				return;
			}

			// Did the user select the rows by the column header? If not, we'll need to remove them manually
			if (data_Files.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in data_Files.SelectedRows)
				{
					data_Files.Rows.RemoveAt(row.Index);
				}
			}
			else
			{
				var selectedCells = data_Files.SelectedCells;
				List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();

				// Go through the selected cells and add its row to the list of selected rows (without duplicates!)
				foreach (DataGridViewCell cell in selectedCells)
				{
					bool rowExists = false;

					// Is the row already present in the list of selected rows?
					if (selectedRows.Count > 0)
					{
						foreach (DataGridViewRow row in selectedRows)
						{
							if (row == cell.OwningRow)
							{
								rowExists = true;
							}
						}
					}

					// If not, add the row to the list
					if (!rowExists)
					{
						selectedRows.Add(cell.OwningRow);
					}
				}

				// Remove all the selected rows
				foreach (DataGridViewRow row in selectedRows)
				{
					try
					{
						data_Files.Rows.RemoveAt(row.Index);
					}
					catch (InvalidOperationException ex)
					{
						Trace.WriteLine(ex.Message);
						Log("Cannot remove the last (uncommitted) row", LogType.Error);
					}
				}
			}

			// Is the currently selected column the row header?
			//if (data_Files_CurSelectedColumn == -1)
			//{
			//	if (!data_Files.Rows[data_Files_CurSelectedRow].IsNewRow)
			//	{
			//		// Remove the currently selected file from the list
			//		data_Files.Rows.RemoveAt(data_Files_CurSelectedRow);
			//	}
			//	else
			//	{
			//		Thread errorThread = new Thread(() => {
			//			Log("Cannot remove the last (uncommitted) row", LogType.Error);

			//			// Re-enable the UI
			//			EnableUI(true);
			//		});
			//		errorThread.Start();
			//	}
			//}
		}


		// When the user clicks the "Remove All" button:
		// Remove all files from the file list.
		private void btn_RemoveAllFiles_Click(object sender, EventArgs e)
		{
			menu_alternateUI.Checked = false;// force user back to default ui
			lastCellChangeMethod = CellChangeMethod.Button;
			ClearFileList();
		}


		// When the user clicks the "Set Game Path..." button:
		// Prompt the user to select the file path of SWBF2's executable.
		private void btn_SetGamePath_Click(object sender, EventArgs e)
		{
			Flow_SetGameDirectory_Start();
		}

		#endregion File List : Sidebar Buttons


		#region Flow : Set Game Directory

		/// <summary>
		/// Starts the flow for setting the GameDirectory.
		/// </summary>
		public bool Flow_SetGameDirectory_Start()
		{
			return Flow_SetGameDirectory_ShowDialog();
		}


		/// <summary>
		/// Gets the initial directory in which to start the SetGameDirectory dialog.
		/// </summary>
		/// <returns>Program Files directory if the GameDirectory isn't already set, otherwise the existing GameDirectory value from user prefs.</returns>
		public string Flow_SetGameDirectory_GetInitialDirectory()
		{
			// If the GameDirectory isn't already set, start in Program Files
			string initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
			if (prefs.GameDirectory != "")
			{
				initialDirectory = prefs.GameDirectory;
			}

			return initialDirectory;
		}


		/// <summary>
		/// Shows the dialog to set the game directory.
		/// </summary>
		/// <returns>True, the user completed the flow successfully. False, the user cancelled out of the flow at some point.</returns>
		public bool Flow_SetGameDirectory_ShowDialog()
		{
			bool retVal = false;
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.RestoreDirectory = true;
			dlg.Title = "Browse to Game Executable";
			dlg.Filter = "Game Executable file|BattlefrontII.exe";
			dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				String exePath = dlg.FileName;
				int lastSlash = exePath.LastIndexOf("\\");
				prefs.GameDirectory = exePath.Substring(0, lastSlash);
				Utilities.SavePrefs(prefs);
				retVal = true;
				Log("Game path set to: " + prefs.GameDirectory, LogType.Info);
			}
			else
			{
				// Give a warning if the user cancelled the flow and the GameDirectory is still unset
				Log("Game path is not set!", LogType.Warning);
			}
			dlg.Dispose();
			return retVal;
		}
		#endregion Flow : Set Game Directory


		#region Status Bar

		// When the "Update available" link is clicked:
		// Open the update's download page in the user's default web browser.
		private void stat_UpdateLink_Click(object sender, EventArgs e)
		{
			Process.Start(latestAppVersion.DownloadUrl);
		}

		#endregion Status Bar


		#region Tray Icon

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


		// When the user clicks the "Run" item in the tray icon context menu:
		// Begin processing the list of files as a playlist.
		private void cmenu_TrayIcon_Run_Click(object sender, EventArgs e)
		{
			StartMunge();
		}


		// When the user clicks the "Cancel" item in the tray icon context menu:
		// Abort the active process and stop processing files.
		private void cmenu_TrayIcon_Cancel_Click(object sender, EventArgs e)
		{
			ProcessManager.Abort(this);
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
			Command_Quit();
		}

		#endregion Tray Icon


		#region Text Context Menu

		Control rightClickedControl = null;

		// When the Text context menu is opened:
		// Set the rightClickedControl.
		private void cmenu_Text_Opened(object sender, EventArgs e)
		{
			rightClickedControl = cmenu_Text.SourceControl;
		}


		// When the Munged Files Edit control enters focus:
		// Set the rightClickedControl.
		private void text_MungedFilesEdit_Enter(object sender, EventArgs e)
		{
			Debug.WriteLine("text_MungedFilesEdit_Enter() entered");

			rightClickedControl = (RichTextBox)sender;
		}


		// When the Munged Files Edit control leaves focus:
		// Unset the rightClickedControl.
		private void text_MungedFilesEdit_Leave(object sender, EventArgs e)
		{
			Debug.WriteLine("text_MungedFilesEdit_Leave() entered");

			rightClickedControl = null;
		}


		// When the user clicks the Copy button in the text context menu:
		// Copy the selected text in the textbox.
		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("copyToolStripMenuItem_Click() entered");

			// Try to cast the sender to a ToolStripItem
			ToolStripItem menuItem = sender as ToolStripItem;
			if (menuItem != null)
			{
				// Retrieve the ContextMenuStrip that owns this ToolStripItem
				if (menuItem.Owner is ContextMenuStrip owner)
				{
					// Get the control that is displaying this context menu
					//Control rightClickedControl = owner.SourceControl;

					if (rightClickedControl is RichTextBox)
					{
						Debug.WriteLine("Control is RichTextBox");
						var rtb = (RichTextBox)rightClickedControl;

						rtb.Copy();
					}
				}
			}
		}


		// When the user clicks the Paste button in the text context menu:
		// Paste the clipboard's contents into the textbox.
		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("pasteToolStripMenuItem_Click() entered");

			// Try to cast the sender to a ToolStripItem
			ToolStripItem menuItem = sender as ToolStripItem;
			if (menuItem != null)
			{
				// Retrieve the ContextMenuStrip that owns this ToolStripItem
				ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
				if (owner != null)
				{
					// Get the control that is displaying this context menu
					//Control sourceControl = owner.SourceControl;

					if (rightClickedControl is RichTextBox)
					{
						Debug.WriteLine("Control is RichTextBox");
						var rtb = (RichTextBox)rightClickedControl;

						rtb.Paste();
					}
				}
			}
		}


		// When the user clicks the Delete button in the text context menu:
		// Delete the selected text in the textbox.
		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("deleteToolStripMenuItem_Click() entered");

			// Try to cast the sender to a ToolStripItem
			ToolStripItem menuItem = sender as ToolStripItem;
			if (menuItem != null)
			{
				// Retrieve the ContextMenuStrip that owns this ToolStripItem
				ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
				if (owner != null)
				{
					// Get the control that is displaying this context menu
					//Control sourceControl = owner.SourceControl;

					if (rightClickedControl is RichTextBox)
					{
						Debug.WriteLine("Control is RichTextBox");
						var rtb = (RichTextBox)rightClickedControl;

						rtb.Text = rtb.Text.Remove(rtb.SelectionStart, rtb.SelectionLength);
					}
				}
			}
		}


		// When the user clicks the Select All button in the text context menu:
		// Select all of the textbox's contents.
		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("selectAllToolStripMenuItem_Click() entered");

			// Try to cast the sender to a ToolStripItem
			ToolStripItem menuItem = sender as ToolStripItem;
			if (menuItem != null)
			{
				// Retrieve the ContextMenuStrip that owns this ToolStripItem
				ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
				if (owner != null)
				{
					// Get the control that is displaying this context menu
					//Control rightClickedControl = owner.SourceControl;

					if (rightClickedControl is RichTextBox)
					{
						Debug.WriteLine("Control is RichTextBox");
						var rtb = (RichTextBox)rightClickedControl;

						rtb.SelectAll();
					}
				}
			}
		}

		#endregion Text Context Menu


		#region File Menu

		// When the user clicks the New button in the File menu:
		// Exit the application.
		private void menu_newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Command_New();
		}


		// When the user clicks the Open button in the File menu:
		// Open a prompt to load a new data container file's contents into the file list.
		private void menu_openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Command_Open();
		}


		#region File Menu : Recent Files List

		// When the user clicks the Clear Recent File List button in the Open Recent submenu:
		// Clear all of the recent files from the recent files list.
		private void menu_clearRecentFileListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RecentFiles_Clear();
		}


		// When the user clicks a file in the Open Recent submenu:
		// Attempt to open the file.
		private void menu_recentFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripItem menuItem = (ToolStripItem)sender;

			// Determine which menu item that was clicked
			int menuItemIdx = menu_openRecentToolStripMenuItem.DropDownItems.IndexOf(menuItem);
			string recentFilePath = recentFiles[menuItemIdx];

			// Attempt to open the file
			bool openSucceeded = OpenFileListFile(recentFilePath);

			if (!openSucceeded)
			{
				string promptTitle = "File Not Found";
				string promptCaption = string.Format("Failed to find the file at the specified path: \n\n\"{0}\"\n\nWould you like to remove it from the list?", recentFilePath);
				DialogResult result = MessageBox.Show(promptCaption, promptTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result == DialogResult.Yes)
				{
					RecentFiles_RemoveFile(menuItemIdx);
				}
			}
		}


		/// <summary>
		/// Checks if the recent files list (in the user preferences) is empty or not.
		/// </summary>
		/// <returns>True, list is empty; false if not.</returns>
		public bool IsRecentFilesPrefsListEmpty()
		{
			return prefs.RecentFiles == null || prefs.RecentFiles.Count <= 0;
		}


		/// <summary>
		/// Adds the specified file path to the Recent Files list.
		/// </summary>
		/// <param name="filePath">File path to add to the list.</param>
		public void RecentFiles_AddFile(string filePath)
		{
			string newItem = filePath;

			Debug.Assert(File.Exists(newItem), "UpdateRecentFilesList: Could not find file at path \"" + newItem + "\"");

			// Does the list already contain the file?
			if (recentFiles.Contains(newItem))
			{
				// If so, move the file to the beginning of the list
				ObservableCollection<string> newList = new ObservableCollection<string>(recentFiles);
				newList.Move(newList.IndexOf(newItem), 0);
				recentFiles = newList.ToList();
			}
			else
			{
				// If not, insert the file at the beginning of the list
				recentFiles.Insert(0, newItem);
			}

			RecentFiles_RepopulateMenu();
		}


		/// <summary>
		/// Removes the file of the specified file index from the Recent Files list.
		/// </summary>
		/// <param name="fileIndex">Index of the file to remove.</param>
		public void RecentFiles_RemoveFile(int fileIndex)
		{
			try
			{
				menu_openRecentToolStripMenuItem.DropDownItems.RemoveAt(fileIndex);
				recentFiles.RemoveAt(fileIndex);
				prefs.RecentFiles.RemoveAt(fileIndex);

				Utilities.SavePrefs(prefs);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				string msg = "ArgumentOutOfRangeException while attempting to remove fileIndex " + fileIndex.ToString() + " from Recent Files list. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);

				throw;
			}
		}


		ToolStripItem menu_clearRecentFileListToolStripMenuItem = new ToolStripMenuItem();

		/// <summary>
		/// Repopulate the Recent Files menu with the contents of the recentFiles collection.
		/// </summary>
		public void RecentFiles_RepopulateMenu()
		{
			// Reload the submenu with the modified file list
			menu_openRecentToolStripMenuItem.DropDownItems.Clear();
			for (int fileIdx = 0; fileIdx < recentFiles.Count; fileIdx++)
			{
				if (fileIdx >= RECENT_FILES_MAX) { break; }

				// Construct the dropdown item
				ToolStripItem subItem = new ToolStripMenuItem(recentFiles[fileIdx]);
				subItem.AutoToolTip = true;
				subItem.Click += menu_recentFileToolStripMenuItem_Click;

				// Add it to the dropdown menu
				menu_openRecentToolStripMenuItem.DropDownItems.Insert(fileIdx, subItem);
			}

			// Add the separator and Clear Recent File List menu items
			menu_openRecentToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
			menu_clearRecentFileListToolStripMenuItem = new ToolStripMenuItem("Clear Recent File List");
			menu_clearRecentFileListToolStripMenuItem.ToolTipText = Tooltips.FileMenu.ClearRecentFileList;
			menu_clearRecentFileListToolStripMenuItem.Click += menu_clearRecentFileListToolStripMenuItem_Click;
			menu_openRecentToolStripMenuItem.DropDownItems.Add(menu_clearRecentFileListToolStripMenuItem);

			menu_openRecentToolStripMenuItem.Enabled = true;
			menu_openRecentToolStripMenuItem.Visible = true;

			// Save the list in the user's settings
			if (IsRecentFilesPrefsListEmpty())
			{
				prefs.RecentFiles = new StringCollection();
			}
			prefs.RecentFiles.Clear();
			prefs.RecentFiles.AddRange(recentFiles.ToArray());

			Utilities.SavePrefs(prefs);
		}


		/// <summary>
		/// Clear all recent file menu items from the Recent Files menu.
		/// </summary>
		public void RecentFiles_ClearMenu()
		{
			if (recentFiles.Count > 0)
			{
				for (int i = 0; i < recentFiles.Count; i++)
				{
					if (menu_openRecentToolStripMenuItem.DropDownItems.Count > 2)
					{
						menu_openRecentToolStripMenuItem.DropDownItems.RemoveAt(0);
					}
				}
			}
		}


		/// <summary>
		/// Clear all recent files from the menu and disable it.
		/// </summary>
		public void RecentFiles_Clear()
		{
			// Remove the dropdown items from the menu
			RecentFiles_ClearMenu();
			menu_openRecentToolStripMenuItem.Enabled = false;
			menu_openRecentToolStripMenuItem.Visible = false;

			// Clear collections and save changes
			recentFiles.Clear();
			prefs.RecentFiles.Clear();

			Utilities.SavePrefs(prefs);
		}


		/// <summary>
		/// Open the save file at the specified path.
		/// </summary>
		/// <param name="filePath">Path of file to open.</param>
		/// <returns>True, successfully opened file; false, failed to open file.</returns>
		public bool OpenFileListFile(string filePath)
		{
			// Has a file name been entered?
			if (filePath != "")
			{
				Log(string.Format("Opening file at path: \"{0}\"", filePath), LogType.Info);

				if (File.Exists(filePath))
				{
					// Store the current directory
					openFileListLastDir = Utilities.GetFileDirectory(filePath);

					DataFilesContainer data = DeserializeData(filePath);
					if (data == null || data.DataRows == null)
					{
						var msg = string.Format("No data was found; failed to load the file: \"{0}\"", filePath);
						Trace.WriteLine(msg);
						//Log(msg, LogType.Warning, true);

						return false;
					}
					LoadDataIntoFileList(data, filePath);

					prefs.LastSaveFilePath = filePath;
					Utilities.SavePrefs(prefs);

					RecentFiles_AddFile(filePath);

					return true;
				}
				else
				{
					Log(string.Format("File not found at path: \"{0}\"", filePath), LogType.Error);
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		#endregion File Menu : Recent Files List


		// When the user clicks the OK button in the Open File List prompt:
		// Attempt to deserialize the data in the specified file and load it into the file list.
		private void openDlg_OpenFileListPrompt_FileOk(object sender, CancelEventArgs e)
		{
			OpenFileListFile(openDlg_OpenFileListPrompt.FileName);
		}


		// When the user clicks the Save button in the File menu:
		// Immediately save the contents of the file list to the current file.
		private void menu_saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!IsFileListEmpty())
			{
				Command_Save();
			}
			else
			{
				var message = "Cannot save empty file list!";
				Trace.WriteLine(message);
				Log(message, LogType.Error);
			}
		}


		// When the user clicks the Save As button in the File menu:
		// Open a prompt to save the contents of the file list to a new file.
		private void menu_saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!IsFileListEmpty())
			{
				Command_SaveAs();
			}
			else
			{
				var message = "Cannot save empty file list!";
				Trace.WriteLine(message);
				Log(message, LogType.Error);
			}
		}


		// When the user clicks the OK button in the Save File List prompt:
		// Attempt to save the file list contents to the specified file path.
		private void saveDlg_SaveFileListPrompt_FileOk(object sender, CancelEventArgs e)
		{
			// Has a file name been entered?
			if (saveDlg_SaveFileListPrompt.FileName != "")
			{
				// Store the current directory
				saveFileListLastDir = Utilities.GetFileDirectory(saveDlg_SaveFileListPrompt.FileName);

				// Write the file list's contents to the file
				SaveFileListToFile(saveDlg_SaveFileListPrompt.FileName, false, inExitFlow);
			}
		}


		// When the user clicks the Exit button in the File menu:
		// Exit the application.
		private void menu_exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Command_Quit();
		}

		#endregion File Menu


		#region Tools Menu

		// When the user clicks the 'Create Side Munge Folders...' button in the Tools menu:
		// Begin the logic for creating a side munge folder.
		private void menu_createSideMungeFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommonOpenFileDialog openDlg_CreateSideMungeFolderPrompt2 = new CommonOpenFileDialog
			{
				Title = "Select Side Folders",
				DefaultDirectory = "C:\\BF2_ModTools",
				IsFolderPicker = true,
				RestoreDirectory = true,
				Multiselect = true
			};

			if (openDlg_CreateSideMungeFolderPrompt2.ShowDialog() == CommonFileDialogResult.Ok)
			{
				foreach (string folder in openDlg_CreateSideMungeFolderPrompt2.FileNames)
				{
					try
					{
						if (!new DirectoryInfo(folder).Parent.FullName.ToLower().EndsWith("\\sides"))
							throw new DirectoryNotFoundException("Invalid side folder(s) specified.");

						DirectoryInfo projectDir = new DirectoryInfo(folder).Parent.Parent;
						if (projectDir.Name.ToLower() == "_build")
							projectDir = projectDir.Parent;

						string sideName = new DirectoryInfo(folder).Name;

						CreateSideMungeFolder(projectDir.FullName, sideName);
					}
					catch (DirectoryNotFoundException ex)
					{
						Trace.WriteLine(ex.Message);

						// Show error message allowing user to select a different directory, ignore the error, or abort the operation
						DialogResult dr = MessageBox.Show(string.Format("Invalid side folder specified: \"{0}\".\n\nPlease specify a valid side folder, e.g. \"C:\\BF2_ModTools\\data_ABC\\Sides\\CIS\".", folder), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
						switch (dr)
						{
							case DialogResult.Retry:
								menu_createSideMungeFolderToolStripMenuItem_Click(sender, e);
								break;
						}
					}
				}
			}
		}


		// When the user clicks the 'Create World Munge Folders...' button in the Tools menu:
		// Begin the logic for creating a world munge folder.
		private void menu_createWorldMungeFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommonOpenFileDialog openDlg_CreateWorldMungeFolderPrompt2 = new CommonOpenFileDialog
			{
				Title = "Select World Folders",
				DefaultDirectory = "C:\\BF2_ModTools",
				IsFolderPicker = true,
				RestoreDirectory = true,
				Multiselect = true
			};

			if (openDlg_CreateWorldMungeFolderPrompt2.ShowDialog() == CommonFileDialogResult.Ok)
			{
				foreach (string folder in openDlg_CreateWorldMungeFolderPrompt2.FileNames)
				{
					try
					{
						if (!new DirectoryInfo(folder).Parent.FullName.ToLower().EndsWith("\\worlds"))
							throw new DirectoryNotFoundException("Invalid world folder(s) specified.");

						DirectoryInfo projectDir = new DirectoryInfo(folder).Parent.Parent;
						if (projectDir.Name.ToLower() == "_build")
							projectDir = projectDir.Parent;

						string worldName = new DirectoryInfo(folder).Name;

						CreateWorldMungeFolder(projectDir.FullName, worldName);
					}
					catch (DirectoryNotFoundException ex)
					{
						Trace.WriteLine(ex.Message);

						// Show error message allowing user to select a different directory, ignore the error, or abort the operation
						DialogResult dr = MessageBox.Show(string.Format("Invalid world folder specified: \"{0}\".\n\nPlease specify a valid world folder, e.g. \"C:\\BF2_ModTools\\data_ABC\\Worlds\\ABC\".", folder), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
						switch (dr)
						{
							case DialogResult.Retry:
								menu_createWorldMungeFolderToolStripMenuItem_Click(sender, e);
								break;
						}
					}
				}
			}
		}


		// When the user clicks the 'Fix World Munge File...' button in the Tools menu:
		// Begin the logic for fixing a world munge file.
		private void menu_fixWorldMungeScriptsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommonOpenFileDialog openDlg_FixWorldMungeScriptsPrompt = new CommonOpenFileDialog
			{
				Title = "Select World Folders",
				DefaultDirectory = "C:\\BF2_ModTools",
				IsFolderPicker = true,
				RestoreDirectory = true,
				Multiselect = true
			};

			if (openDlg_FixWorldMungeScriptsPrompt.ShowDialog() == CommonFileDialogResult.Ok)
			{
				foreach (string folder in openDlg_FixWorldMungeScriptsPrompt.FileNames)
				{
					try
					{
						if (!new DirectoryInfo(folder).Parent.FullName.ToLower().EndsWith("\\worlds"))
							throw new DirectoryNotFoundException("Invalid world folder(s) specified.");

						DirectoryInfo projectDir = new DirectoryInfo(folder).Parent.Parent;
						string worldName = new DirectoryInfo(folder).Name;
						string mungeFilePath;

						if (new DirectoryInfo(folder).Parent.Parent.Name.ToUpper() == "_BUILD")
						{
							mungeFilePath = folder + "\\munge.bat";
						}
						else
						{
							mungeFilePath = new DirectoryInfo(folder).Parent.Parent.FullName + "\\_BUILD\\Worlds\\" + worldName + "\\munge.bat";
						}

						if (!IsWorldMungeFileValid(mungeFilePath))
						{
							DialogResult result = MessageBox.Show("World " + worldName + " appears to have an incorrect munge.bat file. Attempt to fix?", "Fix World Munge Script", MessageBoxButtons.YesNo);
							if (result == DialogResult.Yes)
							{
								FixWorldMungeScript(mungeFilePath, worldName);
							}
						}
						else
						{
							MessageBox.Show(string.Format("World munge.bat file doesn't appear to contain problems.\n\nFile path: \"{0}\"", mungeFilePath), "There's magic in the air...", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
					catch (DirectoryNotFoundException ex)
					{
						Trace.WriteLine(ex.Message);

						// Show error message allowing user to select a different directory, ignore the error, or abort the operation
						DialogResult dr = MessageBox.Show(string.Format("Invalid world folder specified: \"{0}\".\n\nPlease specify a valid world folder, e.g. \"C:\\BF2_ModTools\\data_ABC\\Worlds\\ABC\".", folder), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
						switch (dr)
						{
							case DialogResult.Retry:
								menu_fixWorldMungeScriptsToolStripMenuItem_Click(sender, e);
								break;
						}
					}
				}
			}
		}


		// When the user clicks the 'Fix Sound Munge Files' button in the Tools menu:
		// Begin the logic for applying the sound munge fix.
		private void menu_fixSoundMungeFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommonOpenFileDialog openDlg_SelectProjectPrompt = new CommonOpenFileDialog
			{
				Title = "Select Project Folder",
				DefaultDirectory = "C:\\BF2_ModTools",
				IsFolderPicker = true,
				RestoreDirectory = true
			};

			if (openDlg_SelectProjectPrompt.ShowDialog() == CommonFileDialogResult.Ok)
			{
				try
				{
					if (!Directory.Exists(openDlg_SelectProjectPrompt.FileName + "\\_BUILD"))
						throw new DirectoryNotFoundException("Invalid project directory specified.");

					FixSoundMungeFiles(openDlg_SelectProjectPrompt.FileName);
				}
				catch (DirectoryNotFoundException ex)
				{
					Trace.WriteLine(ex.Message);

					// Show error message allowing user to select a different directory, ignore the error, or abort the operation
					DialogResult dr = MessageBox.Show(string.Format("Unable to find _BUILD directory in \"{0}\".\n\nPlease specify a valid project directory, e.g. \"C:\\BF2_ModTools\\data_ABC\".", openDlg_SelectProjectPrompt.FileName), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
					switch (dr)
					{
						case DialogResult.Retry:
							menu_fixSoundMungeFilesToolStripMenuItem_Click(sender, e);
							break;
					}
				}
			}
		}


		// When the user clicks the 'Modify Munged Sound Folders' button in the Tools menu:
		// Begin the logic for specifying which sound folders are munged.
		private void menu_modifyMungedSoundFoldersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SoundMungeForm form = new SoundMungeForm();
			form.ShowDialog();
		}

		enum MungeComponentType
		{
			World,
			Side
		}

		/// <summary>
		/// Create a munge folder for the specified component.
		/// </summary>
		/// <param name="projectDirectory">Project directory in which the side resides.</param>
		/// <param name="componentName">Name of the component. Ex: "ABC"</param>
		/// <param name="componentType">Type of the component.</param>
		private void CreateMungeFolder(string projectDirectory, MungeComponentType componentType, string componentName, string cleanFile, string mungeFile)
		{
			string mungeDirParent;
			string destDir;
			string typeName = componentType.ToString();

			try
			{
				void CopyFileTemplate(string filePath)
				{
					bool copy = true;
					string fileName = new FileInfo(filePath).Name;

					// Warn user if the file already exists and prompt them to overwrite it or not
					if (File.Exists(destDir + "\\" + fileName))
					{
						DialogResult cleanOverwritePromptResult = MessageBox.Show(string.Format("A file named {0} already exists in the directory: \n{1}\n\nWould you like to overwrite it?", fileName, destDir), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (cleanOverwritePromptResult == DialogResult.No)
						{
							copy = false;
						}
					}
					if (copy)
					{
						Log(string.Format("Copying {0} template to directory: \"{1}\"", fileName, destDir), LogType.Info);
						File.Copy(filePath, destDir + "\\" + fileName, true);
					}
				}

				// Determine the munge root folder
				switch (componentType)
				{
					case MungeComponentType.World:
						mungeDirParent = "Worlds";
						break;
					case MungeComponentType.Side:
						mungeDirParent = "Sides";
						break;
					default:
						throw new ArgumentException("Invalid argument value specified.", "componentType");
				}

				// What directory should the template files be copied to?
				destDir = string.Format("{0}\\_BUILD\\{1}\\{2}", projectDirectory, mungeDirParent, componentName);

				// Copy the template files to the target directory
				Directory.CreateDirectory(destDir);
				CopyFileTemplate(cleanFile);
				CopyFileTemplate(mungeFile);

				// Rewrite the munge.bat template file
				string mungeFileContents = File.ReadAllText(destDir + "\\munge.bat");
				File.WriteAllText(destDir + "\\munge.bat", mungeFileContents.Replace("@#$", componentName));

				Log(string.Format("Successfully created {0} munge folder for {1}: \"{2}\"", typeName.ToLower(), componentName, destDir), LogType.Info);

				// Prompt user to add the munge file to the File List
				DialogResult successPromptResult = MessageBox.Show("Would you like to add the munge file to the File List?", "Success", MessageBoxButtons.YesNo);
				if (successPromptResult == DialogResult.Yes)
				{
					AddFile(destDir + "\\munge.bat", true);
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				var msg = string.Format("Failed to create {0} munge directory. Reason: {1}", typeName.ToLower(), ex.Message);
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (NotSupportedException ex)
			{
				var msg = string.Format("Failed to create {0} munge directory. Reason: {1}", typeName.ToLower(), ex.Message);
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (PathTooLongException ex)
			{
				var msg = string.Format("Failed to create {0} munge directory. Reason: {1}", typeName.ToLower(), ex.Message);
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (DirectoryNotFoundException ex)
			{
				var msg = string.Format("Failed to create {0} munge directory. Reason: {1}", typeName.ToLower(), ex.Message);
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (FileNotFoundException ex)
			{
				var msg = string.Format("Failed to create {0} munge directory. Reason: {1}\nFile: {2}", typeName.ToLower(), ex.Message, ex.FileName);
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (IOException ex)
			{
				var msg = string.Format("Failed to create {0} munge directory. Reason: {1}", typeName.ToLower(), ex.Message);
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (ArgumentNullException ex)
			{
				var msg = string.Format("Failed to create {0} munge directory. Reason: {1}", typeName.ToLower(), ex.Message);
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (ArgumentException ex)
			{
				var msg = string.Format("Failed to create {0} munge directory. Reason: {1}", typeName.ToLower(), ex.Message);
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
		}


		/// <summary>
		/// Create a side munge folder for the specified side.
		/// </summary>
		/// <param name="projectDirectory">Project directory in which the side resides.</param>
		/// <param name="sideName">Name of the side. Ex: "ABC"</param>
		private void CreateSideMungeFolder(string projectDirectory, string sideName)
		{
			try
			{
				CreateMungeFolder(projectDirectory, MungeComponentType.Side, sideName,
					Directory.GetCurrentDirectory() + "\\ZeroMunge\\templates\\SideMungeFolder\\clean.bat",
					Directory.GetCurrentDirectory() + "\\ZeroMunge\\templates\\SideMungeFolder\\munge.bat");
			}
			catch (UnauthorizedAccessException ex)
			{
				var msg = "Failed to create side munge directory. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (NotSupportedException ex)
			{
				var msg = "Failed to create side munge directory. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
		}


		/// <summary>
		/// Create a world munge folder for the specified world.
		/// </summary>
		/// <param name="projectDirectory">Project directory in which the world resides.</param>
		/// <param name="worldName">Name of the world. Ex: "ABC"</param>
		private void CreateWorldMungeFolder(string projectDirectory, string worldName)
		{
			try
			{
				CreateMungeFolder(projectDirectory, MungeComponentType.World, worldName,
					Directory.GetCurrentDirectory() + "\\ZeroMunge\\templates\\WorldMungeFolder\\clean.bat",
					Directory.GetCurrentDirectory() + "\\ZeroMunge\\templates\\WorldMungeFolder\\munge.bat");
			}
			catch (UnauthorizedAccessException ex)
			{
				var msg = "Failed to create world munge directory. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (NotSupportedException ex)
			{
				var msg = "Failed to create world munge directory. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
		}


		/// <summary>
		/// Fix world munge script's world argument.
		/// </summary>
		/// <param name="mungeFilePath">File path of munge script.</param>
		/// <param name="worldName">Name of world. Ex: "ABC"</param>
		private void FixWorldMungeScript(string mungeFilePath, string worldName)
		{
			try
			{
				string destDir = new DirectoryInfo(mungeFilePath).Parent.FullName;
				string mungeFileTemplate = Directory.GetCurrentDirectory() + "\\ZeroMunge\\templates\\WorldMungeFolder\\munge.bat";

				Log(string.Format("Copying munge.bat template to directory: \"{0}\"", destDir), LogType.Info);
				File.Copy(mungeFileTemplate, destDir + "\\munge.bat", true);

				// Rewrite the munge.bat template file
				string mungeFileContents = File.ReadAllText(destDir + "\\munge.bat");
				File.WriteAllText(destDir + "\\munge.bat", mungeFileContents.Replace("@#$", worldName));

				Log(string.Format("Successfully fixed world munge file for {0}", worldName), LogType.Info);
			}
			catch (UnauthorizedAccessException ex)
			{
				var msg = "Failed to fix world munge file. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (NotSupportedException ex)
			{
				var msg = "Failed to fix world munge file. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (PathTooLongException ex)
			{
				var msg = "Failed to fix world munge file. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (DirectoryNotFoundException ex)
			{
				var msg = "Failed to fix world munge file. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (FileNotFoundException ex)
			{
				var msg = "Failed to fix world munge file. Reason: " + ex.Message + "\nFile: " + ex.FileName;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (IOException ex)
			{
				var msg = "Failed to fix world munge file. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (ArgumentNullException ex)
			{
				var msg = "Failed to fix world munge file. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (ArgumentException ex)
			{
				var msg = "Failed to fix world munge file. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
		}


		/// <summary>
		/// Checks whether or not the specified world munge file munges the correct world.
		/// </summary>
		/// <param name="filePath">File path of world munge file.</param>
		/// <returns>True, world munge file munges the correct world. False if not.</returns>
		private bool IsWorldMungeFileValid(string filePath)
		{
			if (File.Exists(filePath))
			{
				string worldName = new DirectoryInfo(filePath).Name;
				if (worldName.ToLower() == "munge.bat")
				{
					worldName = new DirectoryInfo(filePath).Parent.Name;
				}

				string fileContents = File.ReadAllText(filePath);
				string nameInMungeFile = "";
				string[] mungeFileArgs = fileContents.Split(' ');

				// Find world id argument
				for (int i = 0; i < mungeFileArgs.Length - 1; i++)
				{
					if (mungeFileArgs[i].Contains("munge_world.bat"))
					{
						nameInMungeFile = mungeFileArgs[i + 1];
						break;
					}
				}

				if (nameInMungeFile.ToUpper() == worldName.ToUpper())
				{
					return true;
				}
			}

			return false;
		}


		/// <summary>
		/// Applies the sound munge fix to the specified project directory.
		/// </summary>
		/// <param name="projectDirectory">Project directory to apply the sound munge fix to.</param>
		private void FixSoundMungeFiles(string projectDirectory)
		{
			try
			{
				string projectDir = projectDirectory;

				bool PromptOverwriteFile(string filePath)
				{
					if (File.Exists(filePath))
					{
						DialogResult overwritePromptResult = MessageBox.Show("The file already exists at the following path: \n" + filePath + "\n\nWould you like to overwrite it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						if (overwritePromptResult == DialogResult.No)
						{
							return false;
						}
					}

					return true;
				}


				// Get the project ID
				string projectID = Utilities.GetProjectID(projectDir);
				string projectRoot = new DirectoryInfo(projectDir).Name;

				string mungeFile = Directory.GetCurrentDirectory() + "\\ZeroMunge\\templates\\SoundMungeFixes\\munge.bat";
				string soundmungeFile = Directory.GetCurrentDirectory() + "\\ZeroMunge\\templates\\SoundMungeFixes\\soundmunge.bat";
				string soundmungedirFile = Directory.GetCurrentDirectory() + "\\ZeroMunge\\templates\\SoundMungeFixes\\soundmungedir.bat";

				// Warn user if munge.bat already exists and prompt them to overwrite it or not
				if (PromptOverwriteFile(projectDir + "\\_BUILD\\Sound\\munge.bat"))
				{
					Log(string.Format("Copying munge.bat template to directory: \"{0}\"", projectDir + "\\_BUILD\\Sound"), LogType.Info);
					File.Copy(mungeFile, projectDir + "\\_BUILD\\Sound\\munge.bat", true);
				}

				// Warn user if soundmunge.bat already exists and prompt them to overwrite it or not
				if (PromptOverwriteFile(projectDir + "\\soundmunge.bat"))
				{
					Log(string.Format("Copying soundmunge.bat template to directory: \"{0}\"", projectDir), LogType.Info);
					File.Copy(soundmungeFile, projectDir + "\\soundmunge.bat", true);
				}

				// Warn user if soundmungedir.bat already exists and prompt them to overwrite it or not
				if (PromptOverwriteFile(projectDir + "\\soundmungedir.bat"))
				{
					Log(string.Format("Copying soundmunge.bat template to directory: \"{0}\"", projectDir), LogType.Info);
					File.Copy(soundmungedirFile, projectDir + "\\soundmungedir.bat", true);
				}

				// Prompt the user to modify the munged sound folders
				DialogResult modifySoundFoldersPromptResult = MessageBox.Show("Would you like to change which sound folders are munged? (recommended)", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (modifySoundFoldersPromptResult == DialogResult.Yes)
				{
					SoundMungeForm form = new SoundMungeForm(projectDir);
					form.ShowDialog();
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				var msg = "Failed to fix sound munge files. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (NotSupportedException ex)
			{
				var msg = "Failed to fix sound munge files. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (PathTooLongException ex)
			{
				var msg = "Failed to fix sound munge files. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (DirectoryNotFoundException ex)
			{
				var msg = "Failed to fix sound munge files. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (FileNotFoundException ex)
			{
				var msg = "Failed to fix sound munge files. Reason: " + ex.Message + "\nFile: " + ex.FileName;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (IOException ex)
			{
				var msg = "Failed to fix sound munge files. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (ArgumentNullException ex)
			{
				var msg = "Failed to fix sound munge files. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
			catch (ArgumentException ex)
			{
				var msg = "Failed to fix sound munge files. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				Log(msg, LogType.Error);
			}
		}

		#endregion Tools Menu


		#region Settings Menu

		// When the user clicks the Preferences button in the Settings menu:
		// Open the Preferences window.
		private void menu_prefsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWindow_Preferences();
		}

		#endregion Settings Menu


		#region Help Menu

		private void menu_aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWindow_About();
		}


		private void menu_viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWindow_Help();
		}


		private void menu_viewChangelogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenApplicationResourceFile("CHANGELOG.html");
		}


		private void menu_viewLicenseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenApplicationResourceFile("LICENSE.html");
		}


		private void menu_viewReadmeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenApplicationResourceFile("README.html");
		}


		private void menu_checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Utilities.StartFlow_CheckForUpdates(this, true);
		}


		#region Help Menu : Feedback Menu

		private void menu_reportBugToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(LINK_GH_BUGS);
		}


		private void menu_provideSuggestionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(LINK_GH_SUGGESTIONS);
		}


		private void menu_viewOpenIssuesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(LINK_GH_OPENISSUES);
		}

		#endregion Help Menu : Feedback Menu

		#endregion Help Menu

		#endregion Windows Form Controls


		#region Debug Buttons

		private void button2_Click(object sender, EventArgs e)
		{
			//Help.ShowHelp(this, HELP_PATH, HelpNavigator.Topic, "src/topic_gs.html");

			//string newItem = "TestFile" + recentFiles.Count;
			//recentFiles.Insert(0, newItem);

			//ToolStripItem subItem = new ToolStripMenuItem(newItem);
			//menu_openRecentToolStripMenuItem.DropDownItems.Insert(0, subItem);

			//SaveFileListPrompt prompt = new SaveFileListPrompt();
			//prompt.ShowDialog();

			//Debug.WriteLine(IsFileListEmpty().ToString());

			//var parsedJson = Utilities.ParseJsonStrings(this, "https://raw.githubusercontent.com/marth8880/ZeroMunge/master/test.json");
			//if (parsedJson == null) return;

			//foreach (JsonPair pair in parsedJson)
			//{
			//	Debug.WriteLine("Key, Value:    {0}, {1}", pair.Key, pair.Value);
			//}

			//var isLatest = Utilities.GetLatestVersion(this);

			//Debug.WriteLine("isLatest: " + isLatest);

			//var reqChunk = Utilities.ParseReqChunk(@"J:\BF2_ModTools\data_SOL\data_SOL\Sides\SOL\sol.req", "lvl");
			//reqChunk.PrintAll();

			//SerializeData(@"data.zmd");

			//Serialize();
			//Deserialize();

			//Debug.WriteLine(data_Files.Rows[0].Cells[STR_DATA_FILES_TXT_FILE].Value.ToString());

			//List<string> files = new List<string>();
			//files.Add(@"testfile1.txt");
			//files.Add(@"testfile2.txt");
			//files.Add(@"testfile3.txt");

			//string targetDir = @"Y:\ZeroMungeFileTests\target";
			//string sourceDir = @"Y:\ZeroMungeFileTests\source";

			//foreach (string file in files)
			//{
			//    Debug.WriteLine(targetDir + "\\" + file);

			//    File.Copy(string.Concat(targetDir, "\\", file), string.Concat(sourceDir, "\\", file), true);
			//}

			//string compiledFiles = "";

			//foreach (string compiledFile in Utilities.GetCompiledFiles(@"J:\BF2_ModTools\data_MEU\data_ME5\_BUILD\Common\munge.bat"))
			//{
			//    compiledFiles = string.Concat(compiledFiles, compiledFile, "\n");
			//}

			//Utilities.ExtractLines(compiledFiles);

			//Utilities.ParseLevelpackReqs(@"J:\BF2_ModTools\data_MEU\data_ME5\_BUILD\Common\munge.bat");
			//Utilities.GetCompiledFiles(@"J:\BF2_ModTools\data_MEU\data_ME5\_BUILD\Sides\CON_COL\munge_col.bat");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			//DataFilesContainer data = DeserializeData(@"data.zmd");
			//data.PrintAllRows();

			//LoadDataIntoFileList(data);

			//EnableUI(!UIEnabled);
		}

		#endregion Debug Buttons

		[Serializable]
		public class DataFilesRow
		{
			public bool Enabled { get; set; }
			public bool Copy { get; set; }
			public string FilePath { get; set; }
			public string StagingDir { get; set; }
			public string MungeDir { get; set; }
			public string MungedFiles { get; set; }
			public bool IsMungeScript { get; set; }
			public bool IsValid { get; set; }
		}

		[Serializable]
		public class DataFilesContainer
		{
			// NOTE: Don't forget to increment Info_SaveFileVersion in the application properties settings when this data structure is changed!
			public List<DataFilesRow> DataRows { get; private set; }
			public int FileVersion { get; set; }
			public string AppVersion { get; set; }

			public DataFilesContainer()
			{
				FileVersion = 0;
				AppVersion = "Unknown";
			}

			public DataFilesRow AddRow(DataFilesRow row)
			{
				if (DataRows == null)
				{
					DataRows = new List<DataFilesRow>();
				}

				DataRows.Add(row);

				return row;
			}

			public void PrintAllRows()
			{
				if (DataRows != null)
				{
					foreach (DataFilesRow row in DataRows)
					{
						Debug.WriteLine("PrintAllRows(): ");
						Debug.WriteLine("PrintAllRows(): Printing next row");
						Debug.WriteLine("PrintAllRows(): ");
						Debug.WriteLine("PrintAllRows(): Enabled       = " + row.Enabled.ToString());
						Debug.WriteLine("PrintAllRows(): Copy          = " + row.Copy.ToString());
						Debug.WriteLine("PrintAllRows(): FilePath      = " + row.FilePath.ToString());
						Debug.WriteLine("PrintAllRows(): StagingDir    = " + row.StagingDir.ToString());
						Debug.WriteLine("PrintAllRows(): MungeDir      = " + row.MungeDir.ToString());
						Debug.WriteLine("PrintAllRows(): MungedFiles   = " + row.MungedFiles.ToString());
						Debug.WriteLine("PrintAllRows(): IsMungeScript = " + row.IsMungeScript.ToString());
						Debug.WriteLine("PrintAllRows(): IsValid       = " + row.IsValid.ToString());
						Debug.WriteLine("PrintAllRows(): ");
					}
				}
			}
		}

		private void openBF2LogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenBFront2Log();
		}

		private void OpenBFront2Log()
		{
			if (String.IsNullOrEmpty(prefs.GameDirectory))
			{
				MessageBox.Show("Game path not set. Set game path to use this feature.", "Error");
				return;
			}
			string editor = GetEditor();
			string logPath = prefs.GameDirectory + "\\BFront2.log";
			if (File.Exists(logPath))
			{
				this.Log("Opening BFront2.log...", LogType.Info);
				ProcessManager.RunCommand(editor, "\"" + logPath + "\"", null);
			}
			else
			{
				MessageBox.Show(String.Format("Could not find '{0}'\r\nDid you run the BF2_Modtools program yet?", logPath), "Warning");
			}
		}

		private void setPreferredEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetPreferredEditor();
		}

		private void SetPreferredEditor()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.RestoreDirectory = true;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				prefs.PreferredTextEditor = dlg.FileName;
				this.Log("Saving Preferred editor to " + dlg.FileName, LogType.Info);
				Utilities.SavePrefs(prefs);
			}
			dlg.Dispose();
		}

		private void openModtoolsExeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LaunchDebuggerExe();
		}

		private void LaunchDebuggerExe()
		{
			if (String.IsNullOrEmpty(prefs.GameDirectory))
			{
				MessageBox.Show("Game path not set. Set game path in 'Preferences' to use this feature.", "Error");
				return;
			}
			string programName = prefs.DebuggerExe;

			if (File.Exists(programName))
			{
				string msg = "Launching " + programName + " " + prefs.DebuggerArgs;
				Debug.WriteLine(msg);
				this.Log(msg, LogType.Info);
				ProcessManager.RunCommand("\"" + programName + "\"", prefs.DebuggerArgs, prefs.GameDirectory);
			}
			else
			{
				MessageBox.Show(String.Format("Could not find '{0}'\r\n", programName), "Warning");
			}
		}

		private void menu_openGameExe_Click(object sender, EventArgs e)
		{
			LaunchGameExe();
		}

		private void LaunchGameExe()
		{
			if (String.IsNullOrEmpty(prefs.GameDirectory))
			{
				MessageBox.Show("Game path not set. Set game path in 'Preferences' to use this feature.", "Error");
				return;
			}
			string programName = prefs.GameDirectory + "\\BattlefrontII.exe";

			if (File.Exists(programName))
			{
				string msg = "Launching BattlefrontII.exe " + prefs.GameExeArgs;
				Debug.WriteLine(msg);
				this.Log(msg, LogType.Info);
				ProcessManager.RunCommand("\"" + programName + "\"", prefs.GameExeArgs, prefs.GameDirectory);
			}
			else
			{
				MessageBox.Show(String.Format("Could not find '{0}'", programName), "Error");
			}
		}

		private void menu_openGameFolder_Click(object sender, EventArgs e)
		{
			OpenGameFolder();
		}

		private void OpenGameFolder()
		{
			if (String.IsNullOrEmpty(prefs.GameDirectory))
			{
				MessageBox.Show("Game path not set. Set game path in 'Preferences' to use this feature.", "Error");
				return;
			}
			this.Log("Opening Game Folder...", LogType.Info);
			ProcessManager.RunCommand("explorer.exe", "\"" + prefs.GameDirectory + "\"", null);
		}

		private void LaunchZeroEditor()
		{
			if (String.IsNullOrEmpty(prefs.PreferredZeroEditor))
			{
				MessageBox.Show("Zero Editor path not set. Set Zero Editor path in 'Preferences' to use this feature.", "Error");
				return;
			}
			int lastSlash = prefs.PreferredZeroEditor.LastIndexOf(Path.DirectorySeparatorChar);
			string zeFolder = prefs.PreferredZeroEditor.Substring(0, lastSlash);
			this.Log("Opening Zero Editor...", LogType.Info);
			ProcessManager.RunCommand(prefs.PreferredZeroEditor, "", zeFolder);
		}

		private void menu_launchZeroEditor_Click(object sender, EventArgs e)
		{
			LaunchZeroEditor();
		}

		private void launchMissionInDebuggerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MissionLauncherForm launcher = new MissionLauncherForm(this);
			launcher.StartPosition = FormStartPosition.CenterParent;
			launcher.Show();
		}

		private void menu_Platform_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem current = sender as ToolStripMenuItem;
			menu_pcPlatform.Checked = false;
			menu_xboxPlatform.Checked = false;
			menu_ps2Platform.Checked = false;

			current.Checked = true;
			if (menu_pcPlatform.Checked)
				this.Platform = Platform.PC;
			else if (menu_xboxPlatform.Checked)
				this.Platform = Platform.XBOX;
			else if (menu_ps2Platform.Checked)
				this.Platform = Platform.PS2;
		}

		private void menu_launchPPSSPP_Click(object sender, EventArgs e)
		{
			LaunchPPSSPP();
		}

		private void LaunchPPSSPP()
		{
			if (String.IsNullOrEmpty(prefs.PPSSPPLocation) || String.IsNullOrEmpty(prefs.PSPGameLocation))
			{
				MessageBox.Show("Please set 'PPSSPP (emulator exe) Location' and 'PSP Game Folder' to use this feature.", "Error");
				return;
			}
			string programName = prefs.PPSSPPLocation;

			if (File.Exists(programName))
			{
				string msg = "Launching " + programName + " " + prefs.PSPGameLocation;
				Log(msg, LogType.Info);
				int index = prefs.PPSSPPLocation.LastIndexOf("\\");
				string PPSSPPdir = prefs.PPSSPPLocation.Substring(0, index);
				string programArgs = prefs.PSPGameLocation;
				ProcessManager.RunCommand("\"" + programName + "\"", programArgs, PPSSPPdir);
			}
			else
			{
				string msg = String.Format("Could not find '{0}'\r\n", programName);
				Log(msg, LogType.Warning);
				MessageBox.Show(msg, "Warning");
			}
		}

		private string  GetProjectFolderFromSelectedCell()
		{
			string folder = null;
			int row = -1;
			if (data_Files.SelectedCells.Count > 0 )
			{
				row = data_Files.SelectedCells[0].RowIndex;
				folder = GetProjectFolderFromRow(row);
			}
			return folder;
		}

		private string GetProjectFolderFromRow(int row)
		{
			string folder = null;
			int col = 2;  // Target the 'munge.bat' columns
			if ( (row < data_Files.Rows.Count) &&
				 (data_Files.Rows[row].Cells.Count > 2) &&
				 (data_Files.Rows[row].Cells[col].Value != null) )
			{
				string filename = data_Files.Rows[row].Cells[col].Value.ToString();
				int index = filename.IndexOf("_BUILD");
				if (index < 0) index = filename.IndexOf("addme");
				if (index > -1)
					folder = filename.Substring(0, index);
			}
			return folder;
		}

		private string GetStagingFolderFromSelectedCell()
		{
			string folder = null;
			int col = 4;  // Target the Staging folder column
			int row = -1;
			if (data_Files.SelectedCells.Count > 0)
			{
				row = data_Files.SelectedCells[0].RowIndex;
				if (data_Files.Rows[row].Cells.Count > 2 && data_Files.Rows[row].Cells[col].Value != null)
					folder = data_Files.Rows[row].Cells[col].Value.ToString();
			}
			return folder;
		}
		private void menu_openProjectFolderEditor(object sender, EventArgs e)
		{
			if(String.IsNullOrEmpty( prefs.PreferredTextEditor ))
			{
				MessageBox.Show("Please set preferred editor in 'Preferences' (to an editor that can open a folder, like Code or SublimeText)");
				return;
			}
			string folder = GetProjectFolderFromSelectedCell();
			if (folder != null)
			{
				Log("Opening project folder: " + folder, LogType.Info);
				ProcessManager.RunCommand(prefs.PreferredTextEditor, "\"" + folder + "\"", folder);
			}
			else
				MessageBox.Show("Could not determine project folder from selected Cell");
		}

		private void menu_openBuildCmd_Click(object sender, EventArgs e)
		{
			string folder = GetProjectFolderFromSelectedCell();
			if (folder != null)
			{
				Log("Opening cmd.exe ... ", LogType.Info);
				ProcessManager.RunCommand("cmd.exe", "", Utilities.EnsureTrailingSlash(folder) + "_BUILD");
			}
			else
				MessageBox.Show("Could not determine project folder from selected Cell");
		}

		private void menu_openStagingDirectory_Click(object sender, EventArgs e)
		{
			string folder = GetStagingFolderFromSelectedCell();
			if (folder != null)
			{
				if (Directory.Exists(folder))
				{
					Log("Opening addon  folder: " + folder, LogType.Info);
					ProcessManager.RunCommand("Explorer.exe", "\"" + folder + "\"", folder);
				}
				else
					MessageBox.Show("Folder does not exist: " + folder+"\r\nDid you munge yet?", "Error");
			}
			else
				MessageBox.Show("Could not determine staging folder from selected Cell");
		}

		private void menu_gametoastForums_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://gametoast.com/");
		}

		private void menu_gametoastGithub_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/Gametoast");
		}

		private void menu_openProjectFolder_Click(object sender, EventArgs e)
		{
			string folder = GetProjectFolderFromSelectedCell();
			if (folder != null)
			{
				Log("Opening project folder: " + folder, LogType.Info);
				ProcessManager.RunCommand("Explorer.exe", "\""+folder + "\"", folder);
			}
			else
				MessageBox.Show("Could not determine project folder, is there one currently loaded? ");
		}

		private void btn_clean_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("Clean was pressed");
			StartClean();
		}

		private void StartClean()
		{
			if (!ProcessManager.IsRunning())
			{
				if (UsingAlternateUI)
					ProcessManager.Start(this, GetAltUICleanFileList(), data_Files);
				else
					ProcessManager.Start(this, GetCheckedFiles("clean"), data_Files);
			}
		}

		private void menu_Battlefront2API_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/Gametoast/SWBF2-Lua-API/blob/master/API/LuaDevelopmentTools/Battlefront2API.doclua");
		}

		private void menu_addMission_Click(object sender, EventArgs e)
		{
			AddMission();
		}

		private void AddMission()
		{
			string input = StringInputDlg.GetString("Enter mission name",
				"Pressing 'OK' will:\r\n"+
				"  1. Add a <mission_name>.req to the 'Common\\mission' folder.\r\n"+
				"  2. Update 'mission.req'\r\n"+
				"  3. Create <mission_name>.lua and open it in preferred editor.",
				"ABCg_con.lua");
			if (input == null)
				return;	// user canceled
			string projectFolder = GetCurrentProjectFolder();
			if (projectFolder == null)
			{
				Log("Error determining project folder, no mission added.", LogType.Error);
				return;
			}
			if (input != null)
			{
				if (input.IndexOf(".") == -1) input += ".lua";
				try
				{
					AddMission(projectFolder, input);
				}
				catch (InvalidOperationException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// Adds a mission (creates req file, updates mission.req, creates .lua mission file, opend in default editor)
		/// throws InvalidOperationException on failure.
		/// </summary>
		/// <param name="modFolder">The full path to the mod folder</param>
		/// <param name="missionFileName">The mission file name</param>
		private void AddMission(string modFolder, string missionFileName)
		{
			if (missionFileName.IndexOf(".") == -1)
				missionFileName += ".lua";
			DirectoryInfo commonFolder = new DirectoryInfo(modFolder + "Common");
			FileInfo[] infos = commonFolder.GetFiles(missionFileName);
			if (infos.Length > 0) throw new InvalidOperationException( "Error: File already exists\r\n" + infos[0].FullName);
			
			// create req file, update mission.req, create mission lua file
			string reqFileName = commonFolder.FullName + "\\mission\\" + missionFileName.Replace(".lua", ".req");
			string missionName = missionFileName.Replace(".lua", "");
			string missionFolder = GetMissionLuaFolder(missionName, modFolder);
			FileInfo luaFileInfo = new FileInfo(missionFolder + "\\" + missionFileName);
			FileInfo[] missionReqs = commonFolder.GetFiles("mission.req", SearchOption.AllDirectories);

			if (luaFileInfo.Exists) throw new InvalidOperationException("Error: File already exists " + luaFileInfo.FullName);
			if (missionFolder.Length == 0) throw new InvalidOperationException("Error: Could not determine mod name");
			if (missionReqs.Length == 0) throw new InvalidOperationException("Error: Could not find 'mission.req'");
			
			string reqContent =
@"ucft
{
	REQN
	{
		'script'
		'XXX'
	}
}".Replace("'", "\"").Replace("XXX", missionName);

			string missionReqText = File.ReadAllText(missionReqs[0].FullName);
			int index = missionReqText.LastIndexOf("\"") + 1;
			if (index < 3) throw new InvalidOperationException("Error updating mission.req");

			missionReqText = missionReqText.Insert(index, string.Format("\r\n\t\t\"{0}\"", missionName));

			// update mission.req 
			File.WriteAllText(missionReqs[0].FullName, missionReqText);
			Log("Updated mission.req ", LogType.Info);

			// write the req file
			File.WriteAllText(reqFileName, reqContent);
			Log("Wrote " + reqFileName, LogType.Info);
			// create the Lua file
			if (!luaFileInfo.Directory.Exists) luaFileInfo.Directory.Create(); // create the folder if it does not exist
			File.WriteAllText(luaFileInfo.FullName, 
				string.Format("--{0}\n--TODO: Update addme\n",luaFileInfo.Name));
			string editor = GetEditor();
			this.Log(String.Format(" Opening {0}...", luaFileInfo.FullName), LogType.Info);
			ProcessManager.RunCommand(editor, "\"" + luaFileInfo.FullName + "\"", null);
		}

		private string GetEditor()
		{
			string editor = "notepad.exe";
			if (prefs.PreferredTextEditor != null && File.Exists(prefs.PreferredTextEditor))
				editor = prefs.PreferredTextEditor;
			return editor;
		}

		private string GetMissionLuaFolder(string missionName,string modFolder)
		{
			string retVal = "";
			DirectoryInfo scriptFolder = new DirectoryInfo(modFolder + "\\Common\\scripts");
			int index = missionName.IndexOf('_');
			if (index > -1)
			{
				string test = "";
				do
				{
					test = scriptFolder.FullName + "\\" + missionName.Substring(0, index - 1);
					if(Directory.Exists(test))
					{
						retVal = test;
						break;
					}
					index--;
				} while (index > 1);
				if(retVal == "")
				{
					index = modFolder.LastIndexOf("_")+1;
					if (index > 0)
					{
						string subFolder = modFolder.Substring(index).Replace("\\", "");
						retVal = modFolder + "\\Common\\scripts\\" + subFolder;
					}
				}
			}
			return retVal;
		}

		private void btn_OpenLog_Click(object sender, EventArgs e)
		{
			OpenZeroMungeLog();
		}

		private void OpenZeroMungeLog()
		{
			string editor = GetEditor();
			this.Log(String.Format("Opening {0}...", ZeroMungeLog), LogType.Info);
			ProcessManager.RunCommand(editor, "\"" + Path.GetFullPath(ZeroMungeLog) + "\"", null);
		}

		public void ShowMungeLog(bool verbose, string editor=null)
		{
			string mungeLog = MungeLogName;
			if( editor == null)
				editor = GetEditor();

			if (File.Exists(mungeLog))
			{
				FileInfo info = new FileInfo(mungeLog);
				if (info.Length > 0)
				{
					Log("Munge log not empty, showing munge log", LogType.Warning);
					ProcessManager.RunCommand(editor, mungeLog, info.DirectoryName);
				}
				else if(verbose)
				{
					Log(String.Format("'{0}' is empty", mungeLog), LogType.Info);
				}
			}
			else if (verbose)
			{
				Log(String.Format("'{0}' does not exist", mungeLog), LogType.Warning);
			}
		}

		private void menu_openLog_Click(object sender, EventArgs e)
		{
			OpenZeroMungeLog();
		}

		private void menu_openMungeLog_Click(object sender, EventArgs e)
		{
			ShowMungeLog(true);
		}

		private void btn_OpenMungeLog_Click(object sender, EventArgs e)
		{
			ShowMungeLog(true);
		}
	}
}