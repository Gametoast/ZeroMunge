using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace ZeroMunge.Modules
{
	public static class ProcessManager
	{
		private static bool isRunning = false;
		private static int activeFile;
		private static Process curProc;
		private static bool procAborted;
		private static List<MungeFactory> fileList;

		/// <summary>
		/// Goes through the specified list of files and executes the ones that are checked.
		/// </summary>
		/// <param name="sender">The sending ZeroMunge form.</param>
		/// <param name="files">List of MungeFactory members that should be used as the file list.</param>
		/// <param name="dataGridView">The DataGridView control that the files have been added to.</param>
		public static void Start(ZeroMunge sender, List<MungeFactory> files, DataGridView dataGridView)
		{
			// Disable the UI
			sender.EnableUI(false);

			string mungeLog = sender.MungeLogName;
			if(File.Exists(mungeLog))
				File.Delete(mungeLog);

			isRunning = true;

			Thread logPollThread = new Thread(() =>
			{
				while (isRunning)
				{
					if (sender.notifyLogThread)
					{
						sender.notifyLogThread = false;
						sender.NotifyOutputLog();
					}
				}
			});
			logPollThread.Name = "logPollThread";
			logPollThread.Start();

			// Update tray icon text and play start sound
			if (sender.prefs.ShowTrayIcon)
			{
				sender.trayIcon.Text = "Zero Munge: Running";
				sender.stat_JobStatus.Text = "Running";
			}

			Utilities.PlaySound(Utilities.SoundType.Start);

			// Grab the list of checked files
			fileList = files;

			// BEGIN CHECKING FOR ROW ERRORS

			int procError = 0;

			// Are there no items in the list?
			if (sender.data_Files.Rows[0].IsNewRow)
			{
				if (dataGridView.Rows[0].Cells[ZeroMunge.STR_DATA_FILES_TXT_FILE].Value == null ||
					dataGridView.Rows[0].Cells[ZeroMunge.STR_DATA_FILES_TXT_STAGING].Value == null ||
					dataGridView.Rows[0].Cells[ZeroMunge.STR_DATA_FILES_TXT_MUNGE_DIR].Value == null)
				{
					Debug.WriteLine("First row is new row");
					procError = 1;
				}
			}
			else
			{
				// Are none of the items checked?
				if (fileList.Count <= 0)
				{
					procError = 2;
				}
			}

			// Report the error if one is present
			if (procError > 0)
			{
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
				sender.Log(errorMessage, LogType.Error);

				// Re-enable the UI
				sender.EnableUI(true);
				isRunning = false;
				return;
			}

			if (fileList.Count == 0) { return; }

			// FINISH CHECKING FOR ROW ERRORS

			activeFile = 0;
			procAborted = false;

			sender.Log("");
			sender.Log("**************************************************************");
			sender.Log("******** STARTED JOB");
			sender.Log("**************************************************************");
			sender.Log("");

			// Activate the first file
			ActivateProcess(sender, 0);
		}


		/// <summary>
		/// Aborts the active process.
		/// </summary>
		/// <param name="sender">The sending ZeroMunge form.</param>
		public static void Abort(ZeroMunge sender)
		{
			if (!isRunning) return;
			isRunning = false;

			if (sender.prefs.ShowTrayIcon)
			{
				sender.trayIcon.Text = "Zero Munge: Idle";
				sender.stat_JobStatus.Text = "Idle";
			}
			Utilities.PlaySound(Utilities.SoundType.Abort);

			procAborted = true;

			// Kill the process
			if (curProc != null && !curProc.HasExited)
				curProc.Kill();

			// Reset the stored list of checked files
			//fileList = null;
			fileList.Clear();

			sender.Log("");
			sender.Log("**************************************************************");
			sender.Log("******** ABORTED JOB");
			sender.Log("**************************************************************");

			// Re-enable the UI
			sender.EnableUI(true);
		}


		/// <summary>
		/// This is called after all the files have been processed.
		/// </summary>
		/// <param name="sender">The sending ZeroMunge form.</param>
		public static void Complete(ZeroMunge sender)
		{
			isRunning = false;

			sender.Log("");
			sender.Log("**************************************************************");
			sender.Log("******** FINISHED JOB");
			sender.Log("**************************************************************");

			// Re-enable the UI
			sender.EnableUI(true);
			sender.CompleteCallback(fileList);
			// when setting Control properties a 'BeginInvoke' should be used.
			//if (sender.prefs.ShowNotificationPopups)
			//{
			//	sender.trayIcon.Text = "Zero Munge: Idle";
			//	sender.trayIcon.BalloonTipTitle = "Success";
			//	sender.trayIcon.BalloonTipText = "The operation was completed successfully.";
			//	sender.trayIcon.ShowBalloonTip(30000);
			//	sender.stat_JobStatus.Text = "Idle";
			//}
			Utilities.PlaySound(Utilities.SoundType.Success);
			sender.ShowMungeLog(false, "Notepad.exe");
		}

		/// <summary>
		/// Checks whether or not the ProcessManager is running.
		/// </summary>
		/// <returns>True if the ProcessManager is running, or false if not.</returns>
		public static bool IsRunning()
		{
			return isRunning;
		}


		/// <summary>
		/// Use this to tell the manager when the active file has finished.
		/// </summary>
		/// <param name="sender">The sending ZeroMunge form.</param>
		/// <param name="whichFile">Index of the member in the fileList that finished.</param>
		/// <param name="singleFile">True, only process the first file in the list. False, process all files in the list.</param>
		private static void NotifyProcessComplete(ZeroMunge sender, int whichFile, bool singleFile)
		{
			try
			{
				MungeFactory target = fileList.ElementAt(whichFile);

				if (target.MungedFiles != null &&
					target.MungedFiles.Count() > 0 &&
					target.MungedFiles != null &&
					target.MungedFiles[0] != "nil" &&
					target.StagingDir != null &&
					!target.FileDir.Contains("clean.bat") &&
					target.CopyToStaging != null &&
					sender.Platform == Platform.PC // only copy to staging area for the 'PC' Build
				)
				{
					if (target.CopyToStaging == "True")
					{
						// Copy the compiled files to the staging directory
						List<string> filesToCopy = target.MungedFiles;

						string sourceDir = target.MungeDir;
						string targetDir = target.StagingDir;

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
								var message = string.Format("Source file does not exist at path: \"{0}\"", fullSourceFilePath);
								Trace.WriteLine(message);
								sender.Log(message, LogType.Error);
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
										sender.Log(e.Message, LogType.Error);
									}
									catch (UnauthorizedAccessException e)
									{
										Trace.WriteLine(e.Message);
										sender.Log(e.Message, LogType.Error);

										var message = "Try running the application with administrative privileges";
										Trace.WriteLine(message);
										sender.Log(message, LogType.Error);
									}
								}

								// Copy the file
								if (File.Exists(fullSourceFilePath))
								{
									try
									{
										File.Copy(fullSourceFilePath, fullTargetFilePath, true);

										var message = string.Format("Successfully copied \"{0}\" to \"{1}\"", fullSourceFilePath, fullTargetFilePath);
										Debug.WriteLine(message);
										sender.Log(message, LogType.Info);
									}
									catch (IOException e)
									{
										Trace.WriteLine(e.Message);
										sender.Log(e.Message, LogType.Error);
									}
									catch (UnauthorizedAccessException e)
									{
										Trace.WriteLine(e.Message);
										sender.Log(e.Message, LogType.Error);
									}
								}
								else
								{
									var message = string.Format("File does not exist at path: \"{0}\"", fullSourceFilePath);
									Trace.WriteLine(message);
									sender.Log(message, LogType.Error);
								}
							}
						}
					}
					else
					{
						var message = string.Format("Copy is unchecked, skipping copy operation for \"{0}\"", target.FileDir);
						Debug.WriteLine(message);
						sender.Log(message, LogType.Warning);
					}
				}
			}
			catch (ArgumentOutOfRangeException e)
			{
				var message = "ArgumentOutOfRangeException! Reason: " + e.Message;
				Trace.WriteLine(message);
				sender.Log(message, LogType.Error);
			}

			// Are we processing multiple files?
			if (!singleFile)
			{
				// If we've reached here, then all the processes are complete
				if (activeFile >= (fileList.Count - 1))
				{
					// We have no more files, so finish up
					Complete(sender);
				}
				else
				{
					// Move on to the next file
					ActivateProcess(sender, activeFile + 1);
				}
			}
			else
			{
				// We have no more files, so finish up
				Complete(sender);
			}
		}


		/// <summary>
		/// Updates the current file number and starts its process.
		/// </summary>
		/// <param name="whichFile">Index of the fileList member to start processing.</param>
		private static void ActivateProcess(ZeroMunge sender, int whichFile)
		{
			// Don't advance to the next file if this is the last one
			if (whichFile > fileList.Count)
			{
				return;
			}
			activeFile = whichFile;
			MungeFactory target = fileList.ElementAt(whichFile);
			// Start & listen to the process on another thread to keep the UI thread responsive.
			Thread runProcThread = new Thread(() =>
				curProc = StartProcess(sender, target.FileDir,  target.Args)
			);
			runProcThread.Name = "runProcThread: "+ target.FileDir;
			runProcThread.Start();
		}

		/// <summary>
		/// Executes the specified file in a new process.
		/// </summary>
		/// <param name="filePath">Full path of the file to execute.</param>
		/// <param name="singleFile">True to only execute a single file, false to notify the manager to execute the next file after this one is finished.</param>
		/// <returns>Process that was executed.</returns>
		private static Process StartProcess(ZeroMunge sender, string filePath, string args = "", bool singleFile = false)
		{
			if (string.IsNullOrEmpty(args))
			{
				switch (sender.Platform)
				{
					case Platform.PS2: args = " PS2 "; break;
					case Platform.XBOX: args = " XBOX "; break;
				}
			}
			if (args == null) args = "";// so it gets Logged nicely below
			// Initilialize process start info
			ProcessStartInfo startInfo = new ProcessStartInfo(@filePath)
			{
				WorkingDirectory = Utilities.GetFileDirectory(@filePath),
				WindowStyle = ProcessWindowStyle.Hidden,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				CreateNoWindow = true,
				Arguments = args
			};
			string mungeLog = sender.MungeLogName;
			startInfo.EnvironmentVariables.Add("MUNGE_LOG", mungeLog);

			// Initialize the process
			Process proc = new Process();
			proc.StartInfo = startInfo;
			proc.EnableRaisingEvents = true;

			// Log any output data that's received
			proc.OutputDataReceived += ((procSender, e) =>
			{
				if (!procAborted)
				{
					sender.Log(e.Data, LogType.Munge);
				}
			});


			// Print the file path before starting
			sender.Log(string.Format("Executing file: \"{0}\" {1}", startInfo.FileName, startInfo.Arguments), LogType.Info);
			sender.Log("");

			// Notify the manager that the process is done
			proc.Exited += ((procSender, e) =>
			{
				// Don't send out 'exited' messages if we've aborted
				if (!procAborted)
				{
					sender.Log("File done", LogType.Info);
					NotifyProcessComplete(sender, activeFile, singleFile);
				}
			});

			try
			{
				// Start the process
				proc.Start();
				proc.BeginOutputReadLine();
				proc.WaitForExit();
			}
			catch (InvalidOperationException e)
			{
				Trace.WriteLine("Invalid operation while starting process. Reason: " + e.Message);
				throw;
			}
			catch (Win32Exception e)
			{
				Trace.WriteLine("Win32 exception while starting process. Reason: " + e.Message);
				throw;
			}

			return proc;
		}

		/// <summary>
		/// Starts a process with the given program name, arguments and working directory
		/// </summary>
		/// <param name="programName">The program name</param>
		/// <param name="args">the space seperated arguments</param>
		/// <param name="workingDir">Working dir for the process; (null = 'not important')</param>
		public static void RunCommand(string programName, string args, string workingDir)
		{
			Console.WriteLine("Running command: " + programName + " " + args);
			ProcessStartInfo processStartInfo = new ProcessStartInfo
			{
				FileName = programName,
				Arguments = args,
				UseShellExecute = false
			};
			if (workingDir != null)
				processStartInfo.WorkingDirectory = workingDir;

			Process.Start(processStartInfo);
		}

		public static string RunCommandAndGetOutput(string programName, string args, bool includeStdErr)
		{
			Console.WriteLine("Running command: " + programName + " " + args);
			ProcessStartInfo processStartInfo = new ProcessStartInfo
			{
				FileName = programName,
				Arguments = args,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true,
			};
			var process = Process.Start(processStartInfo);
			string output = process.StandardOutput.ReadToEnd();
			string err = process.StandardError.ReadToEnd();
			process.WaitForExit();
			if (includeStdErr)
				output = output + "\r\n" + err;
			return output;
		}

		public static bool IsProcessOpen(string name)
		{
			foreach (Process clsProcess in Process.GetProcesses())
			{
				if (clsProcess.ProcessName.Contains(name))
				{
					return true;
				}
			}
			return false;
		}
	}
}
