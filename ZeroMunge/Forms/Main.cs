using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;

namespace ZeroMunge
{
	[Serializable]
	public partial class ZeroMunge : Form
	{
		// Is this a debug build?
		public bool BUILD_DEBUG;

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
		
		// data_Files : Cell error color
		public Color errorRed = Color.FromArgb(251, 99, 99);

		// Updates
		public static UpdateInfo latestAppVersion = new UpdateInfo();
		public static bool updateAvailable = false;

		public enum CellChangeMethod
		{
			Button,     // Buttons outside the DataGridView
			Cell        // Cells inside the DataGridView
		};


		// This is the very first method called by the application. It initializes the UI controls and loads user settings.
		public ZeroMunge()
		{
			InitializeComponent();

			// Set debug flag based on solution configuration
			#if (BUILD_DEBUG)
				BUILD_DEBUG = true;
			#elif (BUILD_RELEASE)
				BUILD_DEBUG = false;
			#endif
			Trace.WriteLine("BUILD_DEBUG: " + BUILD_DEBUG);

			latestAppVersion.BuildNum = 0;

			// Load any saved settings
			LoadSettings();
		}

		public Prefs prefs = new Prefs();

		// When the ZeroMunge form is finished loading:
		// Create the tray icon, initialize some stuff with the file list, and start a new output log.
		private void ZeroMunge_Load(object sender, EventArgs e)
		{
			// Set the tray icon if it's enabled
			if (prefs.ShowTrayIcon)
			{
				trayIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
				trayIcon.Text = "Zero Munge: Idle";
			}
			else
			{
				trayIcon.Visible = false;
			}

			// Set the visibility of the debug columns in the file list
			col_MungeDir.Visible = BUILD_DEBUG;
			col_IsMungeScript.Visible = BUILD_DEBUG;
			col_IsValid.Visible = BUILD_DEBUG;
			button2.Visible = BUILD_DEBUG;
			button3.Visible = BUILD_DEBUG;

			// Set the visibility of the DataGridView buttons
			col_FileBrowse.UseColumnTextForButtonValue = true;
			col_StagingBrowse.UseColumnTextForButtonValue = true;
			col_MungedFilesEdit.UseColumnTextForButtonValue = true;

			// Start a new log file
			string openMessage = "Opened logfile ZeroMunge_OutputLog.log  " + DateTime.Now.ToString("yyyy-MM-dd") +  " " + Utilities.GetTimestamp();
			File.WriteAllText(Directory.GetCurrentDirectory() + @"\ZeroMunge_OutputLog.log", openMessage + Environment.NewLine);
		}

		private void ZeroMunge_Shown(object sender, EventArgs e)
		{
			// Check for application updates
			updateAvailable = CheckForUpdates();
			if (updateAvailable)
			{
				if (prefs.ShowUpdatePromptOnStartup)
				{
					Trace.WriteLine("Update is available. Pushing update prompt.");
					StartUpdateFlow();
				}
				else
				{
					Trace.WriteLine("Update is available, but user has specified to not show the update prompt on startup.");
				}
			}

			
		}
		

		public void SetUpdateStatusBar(bool available)
		{
			this.SetUpdateStatusBar(available, null);
		}
		public void SetUpdateStatusBar(bool available, string downloadUrl)
		{
			// do stuff
		}


		/// <summary>
		/// Loads and initializes saved user settings.
		/// </summary>
		public void LoadSettings()
		{
			// Load the saved user settings into our prefs object
			prefs = Utilities.LoadPrefs();

			Debug.WriteLine("Loading GameDirectory: " + prefs.GameDirectory);
			Log("Loading GameDirectory: " + prefs.GameDirectory, LogType.Info);
		}


		/// <summary>
		/// If there is an internet connection, checks for updates and returns true if an update is available.
		/// </summary>
		/// <returns>True if an update is available, false if not.</returns>
		public static bool CheckForUpdates()
		{
			Trace.WriteLine("Checking for application updates...");

			if (Utilities.CheckForInternetConnection())
			{
				latestAppVersion = Utilities.GetLatestVersion();
				int curBuild = Properties.Settings.Default.Info_BuildNum;

				Debug.WriteLine("Current build, latest build:    {0}, {1}", curBuild, latestAppVersion.BuildNum);

				// Prompt for update if one is available
				if (curBuild < latestAppVersion.BuildNum)
				{
					Trace.WriteLine("Update is available.");
					return true;
				}
				else
				{
					Trace.WriteLine("No updates available!");
					return false;
				}
			}
			else
			{
				Trace.WriteLine("There is no internet connection!");
				return false;
			}
		}


		/// <summary>
		/// Starts the update flow (duh).
		/// </summary>
		public static void StartUpdateFlow()
		{
			OpenWindow_Updates();
		}


		/// <summary>
		/// Call this to open a new instance of the Preferences window.  
		/// NOTE: The window will be opened as a dialog.
		/// </summary>
		private void OpenWindow_Preferences()
		{
			Preferences prefsForm = new Preferences();
			prefsForm.ShowDialog();
		}


		/// <summary>
		/// Call this to open a new instance of the Help window.  
		/// NOTE: The window will be opened as a dialog.
		/// </summary>
		private void OpenWindow_Help()
		{
			string helpPath = @"ZeroMunge\ZeroMungeHelp.chm";

			if (File.Exists(helpPath))
			{
				Help.ShowHelp(this, helpPath);
			}
			else
			{
				var message = "Help file does not exist at path " + helpPath;
				Trace.WriteLine(message);
				Log(message, LogType.Error);
			}
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

		
		private void Command_New()
		{
			curFileListName = "Untitled";
			UpdateWindowTitle();
		}


		/// <summary>
		/// Open a prompt to load a new data container file's contents into the file list.
		/// </summary>
		private void Command_Open()
		{
			openDlg_OpenFileListPrompt.InitialDirectory = openFileListLastDir;
			openDlg_OpenFileListPrompt.ShowDialog();
		}


		/// <summary>
		/// Immediately save the contents of the file list to the current file.
		/// </summary>
		private void Command_Save()
		{
			if (curFileListPath == "null" || curFileListName == "null")
			{
				Command_SaveAs();
			}
			else
			{
				SaveFileListToFile(curFileListPath);
			}
		}


		/// <summary>
		/// Open a prompt to save the contents of the file list to a new file.
		/// </summary>
		private void Command_SaveAs()
		{
			saveDlg_SaveFileListPrompt.InitialDirectory = saveFileListLastDir;
			saveDlg_SaveFileListPrompt.ShowDialog();
		}



		// ***************************
		// ** PROCESS MANAGER
		// ***************************

		public bool ProcManager_isRunning = false;
		private int ProcManager_activeFile;
		private Process ProcManager_curProc;
		private bool ProcManager_procAborted;
		private List<MungeFactory> ProcManager_fileList;

		/// <summary>
		/// Goes through the specified list of files and executes the ones that are checked.
		/// </summary>
		public void ProcManager_Start()
		{
			// Disable the UI
			EnableUI(false);

			ProcManager_isRunning = true;
			
			Thread logPollThread = new Thread(() => {
				while (ProcManager_isRunning)
				{
					if (notifyLogThread)
					{
						notifyLogThread = false;
						NotifyOutputLog();
					}
				}
			});
			logPollThread.Start();

			Thread soundThread = new Thread(() => {
				if (prefs.ShowTrayIcon)
				{
					trayIcon.Text = "Zero Munge: Running";
				}
				Utilities.PlaySound("start");
			});
			soundThread.Start();

			// Grab the list of checked files
			ProcManager_fileList = new List<MungeFactory>();
			ProcManager_fileList = GetCheckedFiles();


			// BEGIN CHECKING FOR ROW ERRORS

			int procError = 0;

			// Are there no items in the list?
			if (data_Files.Rows[0].IsNewRow)
			{
				if (data_Files.Rows[0].Cells[STR_DATA_FILES_TXT_FILE].Value == null ||
					data_Files.Rows[0].Cells[STR_DATA_FILES_TXT_STAGING].Value == null ||
					data_Files.Rows[0].Cells[STR_DATA_FILES_TXT_MUNGE_DIR].Value == null)
				{
					Debug.WriteLine("First row is new row");
					procError = 1;
				}
			}
			else
			{
				// Are none of the items checked?
				if (ProcManager_fileList.Count <= 0)
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
							errorMessage = "File list must contain at least one file";
							break;
						case 2:
							errorMessage = "At least one item must be checked";
							break;
					}

					Log(errorMessage, LogType.Error);

					// Re-enable the UI
					EnableUI(true);
				});
				errorThread.Start();

				ProcManager_isRunning = false;

				return;
			}

			if (ProcManager_fileList.Count == 0) { return; }

			// FINISH CHECKING FOR ROW ERRORS


			ProcManager_activeFile = 0;
			ProcManager_procAborted = false;

			Thread enterThread = new Thread(() => {
				Log("");
				Log("**************************************************************");
				Log("******** ZeroMunge: Entered");
				Log("**************************************************************");
				Log("");
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
			try
			{
				if (ProcManager_fileList.ElementAt(whichFile).MungedFiles != null &&
				ProcManager_fileList.ElementAt(whichFile).MungedFiles[0] != "nil" &&
				ProcManager_fileList.ElementAt(whichFile).StagingDir != null &&
				ProcManager_fileList.ElementAt(whichFile).CopyToStaging != null)
				{
					if (ProcManager_fileList.ElementAt(whichFile).CopyToStaging == "True")
					{
						// Copy the compiled files to the staging directory
						List<string> filesToCopy = ProcManager_fileList.ElementAt(whichFile).MungedFiles;

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
								var message = "Source file does not exist at path " + fullSourceFilePath;
								Trace.WriteLine(message);
								Log(message, LogType.Error);
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
										Log(e.Message, LogType.Error);
									}
									catch (UnauthorizedAccessException e)
									{
										Trace.WriteLine(e.Message);
										Log(e.Message, LogType.Error);

										var message = "Try running the application with administrative privileges";
										Trace.WriteLine(message);
										Log(message, LogType.Error);
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
										Log(message, LogType.Info);
									}
									catch (IOException e)
									{
										Trace.WriteLine(e.Message);
										Log(e.Message, LogType.Error);
									}
									catch (UnauthorizedAccessException e)
									{
										Trace.WriteLine(e.Message);
										Log(e.Message, LogType.Error);
									}
								}
								else
								{
									var message = "File does not exist at path " + fullSourceFilePath;
									Trace.WriteLine(message);
									Log(message, LogType.Error);
								}
							}
						}
					}
					else
					{
						var message = "Copy is unchecked, skipping copy operation for " + ProcManager_fileList.ElementAt(whichFile).FileDir;
						Debug.WriteLine(message);
						Log("ZeroMunge: " + message);
					}
				}
			}
			catch (ArgumentOutOfRangeException e)
			{
				var message = "ArgumentOutOfRangeException! Reason: " + e.Message;
				Console.WriteLine(message);
				Log(message, LogType.Error);
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
				WorkingDirectory = Utilities.GetFileDirectory(@filePath),
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
					Thread outputThread = new Thread(() => Log(e.Data, LogType.Munge));
					outputThread.Start();
				}
			});


			// Print the file path before starting
			Thread initOutputThread = new Thread(() =>
			{
				Log("Executing file " + @filePath, LogType.Info);
				Log("");
			});
			initOutputThread.Start();


			// Notify the manager that the process is done
			proc.Exited += ((sender, e) =>
			{
				// Don't send out exited messages if we've aborted
				if (!ProcManager_procAborted)
				{
					Thread procExitThread = new Thread(() => {
						Log("File done", LogType.Info);
					});
					procExitThread.Start();

					ProcManager_NotifyProcessComplete(ProcManager_activeFile, singleFile);
				}
			});


			try
			{
				// Start the process
				proc.Start();
				proc.BeginOutputReadLine();
				//proc.WaitForExit();
				//Thread.Sleep(5000);
			}
			catch (InvalidOperationException e)
			{
				Console.WriteLine("Invalid operation while starting process. Reason: " + e.Message);
				throw;
			}
			catch (Win32Exception e)
			{
				Console.WriteLine("Win32 exception while starting process. Reason: " + e.Message);
				throw;
			}

			return proc;
		}


		/// <summary>
		/// Aborts the active process.
		/// </summary>
		public void ProcManager_Abort()
		{
			ProcManager_isRunning = false;

			Thread soundThread = new Thread(() => {
				if (prefs.ShowTrayIcon)
				{
					trayIcon.Text = "Zero Munge: Idle";
				}
				Utilities.PlaySound("abort");
			});
			soundThread.Start();

			ProcManager_procAborted = true;

			// Kill the process
			ProcManager_curProc.Kill();

			// Reset the stored list of checked files
			ProcManager_fileList = null;

			Thread exitThread = new Thread(() => {
				Log("");
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
			ProcManager_isRunning = false;

			Thread exitThread = new Thread(() => {
				Log("");
				Log("**************************************************************");
				Log("******** ZeroMunge: Exited");
				Log("**************************************************************");

				// Re-enable the UI
				EnableUI(true);
			});
			exitThread.Start();

			Thread soundThread = new Thread(() => {
				if (prefs.ShowNotificationPopups)
				{
					trayIcon.Text = "Zero Munge: Idle";
					trayIcon.BalloonTipTitle = "Success";
					trayIcon.BalloonTipText = "The operation was completed successfully.";
					trayIcon.ShowBalloonTip(30000);
				}
				Utilities.PlaySound("success");
			});
			soundThread.Start();
		}


		// ***************************
		// ** OUTPUT LOG
		// ***************************

		public enum LogType
		{
			None,
			Munge,
			Info,
			Warning,
			Error
		};

		// This method is executed on the worker thread and makes a thread-safe call on the RichTextBox control.
		/// <summary>
		/// Prints the specified text to the output log.
		/// </summary>
		/// <param name="message">Text to print.</param>
		/// <param name="logType">Log type. See enum 'LogType'.</param>
		/// <param name="newLine">Optional: True to append a new line to the end of the message.</param>
		public void Log(string message, LogType logType = LogType.None, bool newLine = false)
		{
			Log_Proc(message, logType, newLine);
		}


		// This delegate enables asynchronous calls for setting the text property on the output log.
		delegate void LogCallback(string message, LogType logType = LogType.None, bool newLine = false);


		private List<string> logLineCollection = new List<string>();

		/// <summary>
		/// Prints the specified text to the output log.  
		/// WARNING: Don't call this directly, please call `Log` instead.
		/// </summary>
		/// <param name="message">Text to print.</param>
		/// <param name="logType">Log type. See enum 'LogType'.</param>
		/// <param name="newLine">Optional: True to append a new line to the end of the message.</param>
		private void Log_Proc(string message, LogType logType = LogType.None, bool newLine = false)
		{
			// InvokeRequired required compares the thread ID of the 
			// calling thread to the thread ID of the creating thread. 
			// If these threads are different, it returns true.
			if (text_OutputLog.InvokeRequired)
			{
				LogCallback cb = new LogCallback(Log_Proc);
				BeginInvoke(cb, new object[] { message, logType, newLine });
			}
			else
			{
				//Thread swThread = new Thread(() => {
				string newLineText = "";

				if (newLine)
				{
					newLineText = Environment.NewLine;
				}

				string timestamp = "";
				if (prefs.LogPrintTimestamps)
				{
					timestamp = string.Concat(Utilities.GetTimestamp(), " : ");
				}

				string typeInfo = "";
				if (logType != LogType.None)
				{
					typeInfo = string.Concat("[", logType.ToString(), "]\t");
				}

				// Assemble message
				string messageToLog = string.Concat(timestamp, typeInfo, message, newLineText);

				// Print message
				//text_OutputLog.AppendText(messageToLog);

				// Are we supposed to print a new line?
				if (newLine)
				{
					// Print message on new line
					//text_OutputLog.AppendText(Environment.NewLine);
				}

				// Log the message to the log file
				if (prefs.OutputLogToFile)
				{
					StreamWriter sw = File.AppendText(string.Concat(Directory.GetCurrentDirectory(), @"\ZeroMunge_OutputLog.log"));
					sw.WriteLine(messageToLog);
					sw.Close();
				}


				// Remove the previous temporary blank line from the end if the log isn't empty
				if (logLineCollection.Count > 0)
				{
					logLineCollection.RemoveAt(logLineCollection.Count - 1);
				}

				// Add the message to the line collection
				logLineCollection.Add(messageToLog);

				// Add a temporary new blank line to the end
				logLineCollection.Add("");


				// Remove the first line if the output log is full
				if (logLineCollection.Count >= 100)
				{
					logLineCollection.RemoveAt(0);
				}
				//});
				//swThread.Start();
				
				if (ProcManager_isRunning)
				{
					notifyLogThread = true;
				}
				else
				{
					UpdateOutputLog();
				}
			}
		}


		private bool notifyLogThread = false;
		private bool logThreadReady = true;
		
		public void NotifyOutputLog()
		{
			if (logThreadReady)
			{
				logThreadReady = false;
				UpdateOutputLog();
			}
		}


		// This method is executed on the worker thread and makes a thread-safe call on the RichTextBox control.
		/// <summary>
		/// Updates the Output Log with the text in the logLineCollection.
		/// </summary>
		public void UpdateOutputLog()
		{
			Debug.WriteLine(string.Concat(Utilities.GetTimestamp(), " : ", "UpdateOutputLog: Entered"));
			UpdateOutputLog_Proc();
		}


		// This delegate enables asynchronous calls for setting the text property on the output log.
		delegate void UpdateOutputLogCallback();

		public void UpdateOutputLog_Proc()
		{
			// InvokeRequired required compares the thread ID of the 
			// calling thread to the thread ID of the creating thread. 
			// If these threads are different, it returns true.
			if (text_OutputLog.InvokeRequired)
			{
				UpdateOutputLogCallback cb = new UpdateOutputLogCallback(UpdateOutputLog_Proc);
				BeginInvoke(cb);
			}
			else
			{
				// Display the new data in the control
				text_OutputLog.Lines = logLineCollection.ToArray();

				// Auto-scroll to the most recent line
				text_OutputLog.Select(text_OutputLog.Text.Length, text_OutputLog.Text.Length);
				text_OutputLog.ScrollToCaret();

				if (ProcManager_isRunning)
				{
					// Only update the Output Log once every X milliseconds
					Thread.Sleep(prefs.LogPollingRate);
				}

				logThreadReady = true;
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


				// Menu strip context menus
				// File menu
				menu_newToolStripMenuItem.Enabled = enabled;
				menu_openToolStripMenuItem.Enabled = enabled;
				menu_saveToolStripMenuItem.Enabled = enabled;
				menu_saveAsToolStripMenuItem.Enabled = enabled;
				menu_exitToolStripMenuItem.Enabled = enabled;

				// Edit menu
				menu_runToolStripMenuItem.Enabled = enabled;
				menu_cancelToolStripMenuItem.Enabled = !enabled;
				menu_addFilesToolStripMenuItem.Enabled = enabled;
				menu_addFoldersToolStripMenuItem.Enabled = enabled;
				menu_addProjectToolStripMenuItem.Enabled = enabled;
				menu_removeToolStripMenuItem.Enabled = enabled;
				menu_removeAllToolStripMenuItem.Enabled = enabled;

				// Log menu
				menu_copyLogToolStripMenuItem.Enabled = enabled;
				menu_saveLogAsToolStripMenuItem.Enabled = enabled;
				menu_clearLogToolStripMenuItem.Enabled = enabled;

				// Settings menu
				menu_setGamePathToolStripMenuItem.Enabled = enabled;
				menu_prefsToolStripMenuItem.Enabled = enabled;

				// Help menu
				menu_viewHelpToolStripMenuItem.Enabled = enabled;
				menu_aboutToolStripMenuItem.Enabled = enabled;
			}
		}



		// ***************************
		// ** WINDOWS FORMS CONTROLS
		// ***************************

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

		public CellChangeMethod lastCellChangeMethod = CellChangeMethod.Button;


		/// <summary>
		/// Returns a list of files that are currently checkmarked in the file list.
		/// </summary>
		/// <returns>List<MungeFactory> of files that are checkmarked.</returns>
		private List<MungeFactory> GetCheckedFiles()
		{
			var checkedFiles = new List<MungeFactory>();

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
						Thread errorThread = new Thread(() => {
							if (row.Cells[STR_DATA_FILES_CHK_ENABLED].Value == null)
							{
								Debug.WriteLine("WARNING! Row at index " + row.Index + " isn't enabled!");
							}

							if (row.Cells[STR_DATA_FILES_TXT_FILE].Value == null)
							{
								var message = "FilePath at row index " + row.Index + " isn't specified!";
								Debug.WriteLine(message);
								Log(message, LogType.Error);
							}

							if (row.Cells[STR_DATA_FILES_TXT_STAGING].Value == null)
							{
								var message = "StagingDirectory at row index " + row.Index + " isn't specified!";
								Debug.WriteLine(message);
								Log(message, LogType.Warning);
							}

							if (row.Cells[STR_DATA_FILES_TXT_MUNGE_DIR].Value == null)
							{
								var message = "MungeDirectory at row index " + row.Index + " isn't specified!";
								Debug.WriteLine(message);
								Log(message, LogType.Error);
							}

							if (row.Cells[STR_DATA_FILES_TXT_MUNGED_FILES].Value == null)
							{
								var message = "MungedFiles at row index " + row.Index + " isn't specified!";
								Debug.WriteLine(message);
								Log(message, LogType.Warning);
							}


							if (!File.Exists(row.Cells[STR_DATA_FILES_TXT_FILE].Value.ToString()))
							{
								var message = "FilePath at row index " + row.Index + " cannot be found!";
								Debug.WriteLine(message);
								Log(message, LogType.Error);
							}
						});
						errorThread.Start();

						Debug.WriteLine(row.Cells[STR_DATA_FILES_TXT_FILE].Value.ToString());
						if (row.Cells[STR_DATA_FILES_TXT_STAGING].Value != null)
						{
							Debug.WriteLine(row.Cells[STR_DATA_FILES_TXT_STAGING].Value.ToString());
						}
						Debug.WriteLine(row.Cells[STR_DATA_FILES_TXT_MUNGE_DIR].Value.ToString());


						// Construct a new FileFactory object and initialize our data into it
						MungeFactory fileInfo = new MungeFactory();

						// 'Copy' data
						fileInfo.CopyToStaging = row.Cells[STR_DATA_FILES_CHK_COPY].Value.ToString();

						// 'File directory' data
						fileInfo.FileDir = row.Cells[STR_DATA_FILES_TXT_FILE].Value.ToString();

						// 'Staging directory' data
						if (row.Cells[STR_DATA_FILES_TXT_STAGING].Value != null)
						{
							fileInfo.StagingDir = row.Cells[STR_DATA_FILES_TXT_STAGING].Value.ToString();
						}

						// 'Munge directory' data
						fileInfo.MungeDir = row.Cells[STR_DATA_FILES_TXT_MUNGE_DIR].Value.ToString();

						// 'Munged files' data
						if (row.Cells[STR_DATA_FILES_TXT_MUNGED_FILES].Value != null)
						{
							fileInfo.MungedFiles = Utilities.ExtractLines(row.Cells[STR_DATA_FILES_TXT_MUNGED_FILES].Value.ToString());
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
		/// <param name="isMungeScript">Whether or not the specified file is a munge script.</param>
		/// <returns>True if the file was successfully added, false if not.</returns>
		private bool AddFile(string file, bool isMungeScript = true)
		{
			// Does the file path exist?
			if (File.Exists(file))
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

							Thread infoThread = new Thread(() => {
								var message = "File is not a munge script, copy operations will be disabled for it";
								Debug.WriteLine(message);
								Log(message, LogType.Info);
							});
							infoThread.Start();
						}


						if (!prefs.AutoDetectStagingDir)
						{
							stagingDirectory = "nil";

							Thread infoThread = new Thread(() => {
								var message = "Not setting Staging Directory in accordance with preferences";
								Debug.WriteLine(message);
								Log(message, LogType.Info);
							});
							infoThread.Start();
						}


						if (!prefs.AutoDetectMungedFiles)
						{
							compiledFiles = "nil";

							Thread infoThread = new Thread(() => {
								var message = "Not setting Munged Files in accordance with preferences";
								Debug.WriteLine(message);
								Log(message, LogType.Info);
							});
							infoThread.Start();
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

						
						Thread logThread = new Thread(() => {
							Log("");
							Log("Adding file: " + file, LogType.Info);
							Log("Staging directory: " + stagingDirectory, LogType.Info);
							Log("Munge output directory: " + mungeOutputDirectory, LogType.Info);
						});
						logThread.Start();


						// Reset the stored index of the currently selected row
						data_Files_CurSelectedRow = -1;
					}
					else
					{
						Thread errorThread = new Thread(() => {
							var message = "Game directory not set";
							Debug.WriteLine(message);
							Log(message, LogType.Error);
						});
						errorThread.Start();

						return false;
					}
				}

				return true;
			}
			else
			{
				Thread errorThread = new Thread(() => {
					var message = "File does not exist at " + file;
					Debug.WriteLine(message);
					Log(message, LogType.Error);
				});
				errorThread.Start();

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

			foreach (DataGridViewRow row in data_Files.Rows)
			{
				if (!row.IsNewRow)
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
			}

			// A FileStream is needed to save the binary file
			FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
			try
			{
				// Create an instance of the BinaryFormatter
				IFormatter formatter = new BinaryFormatter();

				// Serialize and save the data
				formatter.Serialize(fs, saveData);
			}
			catch (SerializationException e)
			{
				Console.WriteLine("Failed to serialize. Reason: " + e.Message);
				Log("Failed to serialize. Reason: " + e.Message, LogType.Error);
				throw;
			}
			catch (IOException e)
			{
				Console.WriteLine("Failed to write to file path. Reason: " + e.Message);
				Log("Failed to write to file path. Reason: " + e.Message, LogType.Error);
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
			DataFilesContainer data;

			// A FileStream is needed to read the binary file
			FileStream fs = new FileStream(filePath, FileMode.Open);
			try
			{
				// Create an instance of the BinaryFormatter
				IFormatter formatter = new BinaryFormatter();

				// Deserialize and store the data
				data = (DataFilesContainer)formatter.Deserialize(fs);
			}
			catch (SerializationException e)
			{
				Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
				Log("Failed to deserialize. Reason: " + e.Message, LogType.Error);
				throw;
			}
			catch (IOException e)
			{
				Console.WriteLine("Failed to read from file path. Reason: " + e.Message);
				Log("Failed to read from file path. Reason: " + e.Message, LogType.Error);
				throw;
			}
			finally
			{
				fs.Close();
			}

			return data;
		}

		/// <summary>
		/// Removes all committed rows from the file list.
		/// </summary>
		/// <param name="printErrors">Whether or not error messages should be printed to the Output Log.</param>
		public void ClearFileList(bool printErrors = false)
		{
			// Is there at least 1 committed row to remove?
			if (data_Files.RowCount > 1 && !data_Files.Rows[0].IsNewRow)
			{
				Debug.WriteLine("Rows to remove: " + (data_Files.RowCount - 1));

				// Keep removing the topmost row until only 1 row remains
				do
				{
					try
					{
						data_Files.Rows.RemoveAt(data_Files.Rows[0].Index);
					}
					catch (ArgumentOutOfRangeException e)
					{
						Console.WriteLine("Argument out of range while removing row. Reason: " + e.Message);
						Log("Argument out of range while removing row. Reason: " + e.Message, LogType.Error);
						throw;
					}
					catch (InvalidOperationException e)
					{
						Console.WriteLine("Invalid operation while removing row. Reason: " + e.Message);
						Log("Invalid operation while removing row. Reason: " + e.Message, LogType.Error);
						throw;
					}
					Debug.WriteLine("Rows remaining: " + (data_Files.RowCount - 1));
				} while (data_Files.RowCount > 1);
			}
			else
			{
				Thread errorThread = new Thread(() =>
				{
					if (printErrors)
					{
						Log("File list must contain at least one file", LogType.Error);
					}

					// Re-enable the UI
					EnableUI(true);
				});
				errorThread.Start();
			}
		}

		/// <summary>
		/// Loads data from the specified DataFilesContainer into the file list.
		/// </summary>
		/// <param name="data">DataFilesContainer object containing the data to load into the file list.</param>
		/// <param name="replaceCurrentContents">Whether or not to clear the contents of the file list before loading the new data into it. Default = true</param>
		public void LoadDataIntoFileList(DataFilesContainer data, bool replaceCurrentContents = true)
		{
			// Clear the contents of the file list if specified
			if (replaceCurrentContents)
			{
				ClearFileList();
			}

			// Fill the file list with the data from the provided container
			foreach (DataFilesRow row in data.DataRows)
			{
				try
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
				catch (NullReferenceException e)
				{
					Thread errorThread = new Thread(() =>
					{
						Console.WriteLine("Failed to load data into file list. Reason: " + e.Message);
						Log("File does not contain any data to load", LogType.Error);
					});
					errorThread.Start();

					//throw;
				}
				catch (InvalidOperationException e)
				{
					Console.WriteLine("Invalid operation while adding row. Reason: " + e.Message);
					Log("Invalid operation while adding row. Reason: " + e.Message, LogType.Error);
					throw;
				}
			}
		}


		/// <summary>
		/// Saves the contents of the file list to the specified file path.
		/// </summary>
		/// <param name="filePath">File path to save the file list to.</param>
		private void SaveFileListToFile(string filePath)
		{
			// Serialize and save the data
			SerializeData(filePath);
			Log("Saved file list as " + filePath, LogType.Info);

			// Update the current file list's save file path and name
			curFileListPath = filePath;
			DirectoryInfo dir = new DirectoryInfo(curFileListPath);
			curFileListName = dir.Name;

			// Flag the file list as no longer being dirty
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
			if (dirty)
			{

			}

			isFileListDirty = dirty;
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
					fullName = baseName + " - " + "*" + curFileListName;
				}
				else
				{
					fullName = baseName + " - " + curFileListName;
				}
			}

			this.Text = fullName;
			this.Update();
		}


		// When the user presses a key:
		// 
		private void ZeroMunge_KeyDown(object sender, KeyEventArgs e)
		{
			// When the key combination is Shift + F5:
			// Stop processing files in the file list.
			if ((ModifierKeys & Keys.Shift) == Keys.Shift)
			{
				if (e.KeyCode == Keys.F5)
				{
					Debug.WriteLine("Shift + F5 was pressed");

					if (ProcManager_isRunning)
					{
						ProcManager_Abort();
					}

					e.Handled = true;
				}
			}

			// When the modifier key is Ctrl:
			if ((ModifierKeys & Keys.Control) == Keys.Control)
			{
				// And the action key is N:
				// Run the New command.
				if (e.KeyCode == Keys.N)
				{
					Debug.WriteLine("Ctrl + N was pressed");

					if (!ProcManager_isRunning)
					{
						Command_New();
					}

					e.Handled = true;
				}

				// And the action key is O:
				// Run the Open command.
				if (e.KeyCode == Keys.O)
				{
					Debug.WriteLine("Ctrl + O was pressed");

					if (!ProcManager_isRunning)
					{
						Command_Open();
					}

					e.Handled = true;
				}

				// And the action key is S:
				// Run the Save command.
				if (e.KeyCode == Keys.S)
				{
					Debug.WriteLine("Ctrl + S was pressed");

					if (!ProcManager_isRunning)
					{
						Command_Save();
					}

					e.Handled = true;
				}

				// And the action key is Q:
				// Exit the application.
				if (e.KeyCode == Keys.Q)
				{
					Debug.WriteLine("Ctrl + Q was pressed");

					if (!ProcManager_isRunning)
					{
						Application.Exit();
					}

					e.Handled = true;
				}

				// And the action key is P:
				// Open the Preferences window.
				if (e.KeyCode == Keys.P)
				{
					Debug.WriteLine("Ctrl + P was pressed");

					if (!ProcManager_isRunning)
					{
						OpenWindow_Preferences();
					}

					e.Handled = true;
				}
			}

			// When the key combination is F1:
			// Open the Help window.
			if (e.KeyCode == Keys.F1)
			{
				if ((ModifierKeys & Keys.Shift) == Keys.Shift) { return; }

				Debug.WriteLine("F1 was pressed");

				if (!ProcManager_isRunning)
				{
					OpenWindow_Help();
				}

				e.Handled = true;
			}

			// When the key combination is F5:
			// Start processing files in the file list.
			if (e.KeyCode == Keys.F5)
			{
				if ((ModifierKeys & Keys.Shift) == Keys.Shift) { return; }

				Debug.WriteLine("F5 was pressed");

				if (!ProcManager_isRunning)
				{
					ProcManager_Start();
				}

				e.Handled = true;
			}

			// When the key combination is F12:
			// Open the About window.
			if (e.KeyCode == Keys.F12)
			{
				if ((ModifierKeys & Keys.Shift) == Keys.Shift) { return; }

				Debug.WriteLine("F12 was pressed");

				if (!ProcManager_isRunning)
				{
					OpenWindow_About();
				}

				e.Handled = true;
			}

			// When the key combination is Delete:
			// Clear the contents of the currently selected cell in the file list.
			if (e.KeyCode == Keys.Delete)
			{
				Debug.WriteLine("Delete was pressed");

				if (!ProcManager_isRunning)
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

				e.Handled = true;
			}
		}


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

					FileListIsDirty(true);
					UpdateWindowTitle();
				}

				//Debug.WriteLine(cellType + " cell content clicked at row index " + e.RowIndex + ", column index " + e.ColumnIndex);
			}

			try
			{
				// Does the File Path cell contain actual data?
				if (data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value == null || 
					data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value.ToString() == "" || 
					data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value.ToString() == "nil")
				{
					fileIsNull = true;

					if (data_Files_CurSelectedColumn != INT_DATA_FILES_BTN_FILE_BROWSE)
					{
						Thread errorThread = new Thread(() => {
							var message = "File Path must first be specified";
							Debug.WriteLine(message);
							Log(message, LogType.Error);
						});
						errorThread.Start();
					}
				}
			}
			catch (ArgumentOutOfRangeException) { }

			// Do stuff if the clicked cell's type was Button
			if (cellType == "Button" && e.RowIndex != -1)
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
		}

		// When a cell's value in the file list has changed:
		// Validate or invalidate the cell.
		private void data_Files_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			//Debug.WriteLine("Cell value changed");
			FileListIsDirty(true);
			UpdateWindowTitle();

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

			// Does the File Path cell contain actual data?
			if (data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value == null)
			{
				fileIsNull = true;

				if (data_Files_CurSelectedColumn != INT_DATA_FILES_BTN_FILE_BROWSE)
				{
					if (lastCellChangeMethod == CellChangeMethod.Cell)
					{
						Thread errorThread = new Thread(() => {
							var message = "File Path must first be specified";
							Debug.WriteLine(message);
							Log(message, LogType.Error);
						});
						errorThread.Start();
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

						Thread errorThread = new Thread(() => {
							var message = "File Path is blank";
							Debug.WriteLine(message);
							Log(message, LogType.Error);
						});
						errorThread.Start();
					}
					else if (data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value.ToString() == "" || 
						!File.Exists(data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value.ToString()))
					{
						data_Files_ValidateCell(e.RowIndex, INT_DATA_FILES_TXT_FILE, false);
						data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_CHK_IS_VALID].Value = false;

						Thread errorThread = new Thread(() => {
							var message = "File Path doesn't exist at " + data_Files.Rows[e.RowIndex].Cells[INT_DATA_FILES_TXT_FILE].Value.ToString();
							Debug.WriteLine(message);
							Log(message, LogType.Error);
						});
						errorThread.Start();
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
			cont_FileButtons.MouseClick += text_MungedFilesEdit_MouseClickOutside;
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
			if (lines[lines.Length - 1] == "" || lines[lines.Length - 1] == "\n")
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
			cont_FileButtons.MouseClick -= text_MungedFilesEdit_MouseClickOutside;
			this.MouseClick -= text_MungedFilesEdit_MouseClickOutside;
		}


		// When the user clicks the "Run" button:
		// Begin processing the list of files as a playlist.
		private void btn_Run_Click(object sender, EventArgs e)
		{
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
			lastCellChangeMethod = CellChangeMethod.Button;

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
						Thread errorThread = new Thread(() => {
							var message = "File does not exist at " + file;
							Debug.WriteLine(message);
							Log(message, LogType.Error);
						});
						errorThread.Start();
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
				// Get the project ID
				var projectID = Utilities.GetProjectID(openDlg_AddProjectPrompt.FileName);


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
					var path = openDlg_AddProjectPrompt.FileName + theFile;

					// Save the current directory
					addProjectLastDir = Utilities.GetFileDirectory(openDlg_AddProjectPrompt.FileName);

					// Add the file to the list
					AddFile(path);
				}
			}
		}


		// When the user clicks the "Remove" button:
		// Remove the selected file from the file list.
		private void btn_RemoveFile_Click(object sender, EventArgs e)
		{
			lastCellChangeMethod = CellChangeMethod.Button;

			// Don't continue if there aren't any files in the list
			if (data_Files.RowCount <= 0)
			{
				Thread errorThread = new Thread(() => {
					Log("File list must contain at least one file", LogType.Error);

					// Re-enable the UI
					EnableUI(true);
				});
				errorThread.Start();

				return;
			}

			// Is the currently selected column the row header?
			if (data_Files_CurSelectedColumn == -1)
			{
				if (!data_Files.Rows[data_Files_CurSelectedRow].IsNewRow)
				{
					// Remove the currently selected file from the list
					data_Files.Rows.RemoveAt(data_Files_CurSelectedRow);
				}
				else
				{
					Thread errorThread = new Thread(() => {
						Log("Cannot remove the last (uncommitted) row", LogType.Error);

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
			lastCellChangeMethod = CellChangeMethod.Button;

			ClearFileList(true);
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
			if (Directory.Exists(Utilities.GetFileDirectory(file)))
			{
				prefs.GameDirectory = Utilities.GetFileDirectory(file);

				Utilities.SavePrefs(prefs);

				Thread outputThread = new Thread(() => {
					Debug.WriteLine("Saving GameDirectory: " + Properties.Settings.Default.GameDirectory);
					Log("Saving GameDirectory: " + Properties.Settings.Default.GameDirectory, LogType.Info);
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

				Log("Saved logfile as " + name, LogType.Info);

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
				ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
				if (owner != null)
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

		private void openDlg_OpenFileListPrompt_FileOk(object sender, CancelEventArgs e)
		{
			// Has a file name been entered?
			if (openDlg_OpenFileListPrompt.FileName != "")
			{
				// Store the current directory
				openFileListLastDir = Utilities.GetFileDirectory(openDlg_OpenFileListPrompt.FileName);
				
				DataFilesContainer data = DeserializeData(openDlg_OpenFileListPrompt.FileName);
				LoadDataIntoFileList(data);
			}
		}


		// When the user clicks the Save button in the File menu:
		// Immediately save the contents of the file list to the current file.
		private void menu_saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Command_Save();
		}


		// When the user clicks the Save As button in the File menu:
		// Open a prompt to save the contents of the file list to a new file.
		private void menu_saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Command_SaveAs();
		}

		private void saveDlg_SaveFileListPrompt_FileOk(object sender, CancelEventArgs e)
		{
			// Has a file name been entered?
			if (saveDlg_SaveFileListPrompt.FileName != "")
			{
				// Store the current directory
				saveFileListLastDir = Utilities.GetFileDirectory(saveDlg_SaveFileListPrompt.FileName);

				// Write the file list's contents to the file
				SaveFileListToFile(saveDlg_SaveFileListPrompt.FileName);
			}
		}


		// When the user clicks the Exit button in the File menu:
		// Exit the application.
		private void menu_exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}


		// When the user clicks the Preferences button in the Settings menu:
		// Open the Preferences window.
		private void menu_prefsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWindow_Preferences();
		}

		private void menu_aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWindow_About();
		}

		private void menu_viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenWindow_Help();
		}


		// When the form is focused on and activated:
		// Reload the application settings.
		private void ZeroMunge_Activated(object sender, EventArgs e)
		{
			Debug.WriteLine("ZeroMunge_Activated() entered");

			prefs = Utilities.LoadPrefs();
		}


		// When the form is unfocused and deactivated:
		// 
		private void ZeroMunge_Deactivate(object sender, EventArgs e)
		{
			Debug.WriteLine("ZeroMunge_Deactivate() entered");
		}


		private void button2_Click(object sender, EventArgs e)
		{
			var parsedJson = Utilities.ParseJsonStrings("https://raw.githubusercontent.com/marth8880/ZeroMunge/master/test.json");

			foreach (JsonPair pair in parsedJson)
			{
				Debug.WriteLine("Key, Value:    {0}, {1}", pair.Key, pair.Value);
			}

			var isLatest = Utilities.GetLatestVersion();

			Debug.WriteLine("isLatest: " + isLatest);

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
			DataFilesContainer data = DeserializeData(@"data.zmd");
			data.PrintAllRows();

			LoadDataIntoFileList(data);
		}
	}

	public class MungeFactory
	{
		public string CopyToStaging { get; set; }
		public string FileDir { get; set; }
		public string StagingDir { get; set; }
		public string MungeDir { get; set; }
		public List<string> MungedFiles { get; set; }
	}

	public class JsonPair
	{
		public object Key { get; set; }
		public object Value { get; set; }
	}

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
		public List<DataFilesRow> DataRows { get; private set; }

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
}
