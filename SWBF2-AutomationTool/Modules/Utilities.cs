using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace AutomationTool
{
	public static class Utilities
	{
		public enum MungeTypes
		{
			Nil,
			Addme,
			Common,
			Load,
			Shell,
			Side,
			Sound,
			World
		};

		public enum ReqChunkParseState
		{
			CheckBegin,
			FileHeader,
			FileBegin,
			ChunkHeader,
			ChunkBegin,
			ChunkName,
			ChunkAlign,
			ChunkPlatform,
			ChunkContents,
			ChunkEnd,
			FileEnd
		};


		/// <summary>
		/// Returns the first N characters of the specified string.
		/// </summary>
		/// <param name="str">String to truncate.</param>
		/// <param name="maxLength">Number of characters to return.</param>
		/// <returns>First N characters of the specified string</returns>
		public static string TruncateLongString(this string str, int maxLength)
		{
			return str.Substring(0, Math.Min(str.Length, maxLength));
		}


		/// <summary>
		/// Given a string containing lines of text separated by new-line delimiters ("\n"), returns a list containing each extracted line.
		/// </summary>
		/// <param name="str">String to extract lines from.</param>
		/// <returns>List of extracted lines.</returns>
		public static List<string> ExtractLines(string str)
		{
			// List that we're gonna add the split segments to
			List<string> newStr = new List<string>();

			// Split the string wherever there's a new-line delimiter and store the split segments in an array
			string[] strSplitted = str.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

			// Add each split segment to the list
			foreach (string s in strSplitted)
			{
				Debug.WriteLine(s);
				newStr.Add(s);
			}

			return newStr;
		}


		/// <summary>
		/// Returns the extension of the file at the given path.  
		/// Example: Inputting "C:\Documents\foo.bar" or simply "foo.bar" would return "bar".
		/// </summary>
		/// <param name="filePath">File path or name to get extension from.</param>
		/// <returns>File extension of given file (e.g., "txt")</returns>
		public static string GetFileExtension(string filePath)
		{
			return filePath.ToLower().Substring(filePath.LastIndexOf(".") + 1);
		}


		/// <summary>
		/// Returns the directory of the specified file path.  
		/// Example: Inputting "C:\Documents\foo.bar" would return "C:\Documents"
		/// </summary>
		/// <param name="filePath">Path of file to get directory from.</param>
		/// <returns>Directory of the specified file path.</returns>
		public static string GetFileDirectory(string filePath)
		{
			// Get the file's directory
			string filePathDir = "";
			int index = filePath.LastIndexOf(@"\");
			if (index > 0)
			{
				filePathDir = filePath.Substring(0, index);
			}

			return filePathDir;
		}


		/// <summary>
		/// Returns the name of the specified file path's parent folder.  
		/// Example: Inputting "C:\Documents\foo.bar" would return "Documents"
		/// </summary>
		/// <param name="filePath">Path of file to get parent folder name from.</param>
		/// <returns>Name of the specified file path's parent folder.</returns>
		public static string GetParentFolderName(string filePath)
		{
			DirectoryInfo dir = new DirectoryInfo(GetFileDirectory(filePath));

			return dir.Name;
		}


		/// <summary>
		/// Returns the project root directory of the specified file path.  
		/// Example: Inputting "C:\BF2_ModTools\data_ABC\_BUILD\Common\munge.bat" would return "C:\BF2_ModTools\data_ABC"
		/// </summary>
		/// <param name="filePath">Path of file to get project root directory from.</param>
		/// <returns>Project root directory of the specified file path.</returns>
		public static string GetProjectDirectory(string filePath)
		{
			// Get the file's project directory
			if (GetMungeType(filePath) == MungeTypes.Addme)
			{
				return GetFileDirectory(GetFileDirectory(filePath));
			}
			else
			{
				int index = filePath.LastIndexOf("_BUILD");

				if (index > 0)
				{
					return filePath.Substring(0, index);
				}
				else
				{
					return "nil";
				}
			}
		}


		/// <summary>
		/// Returns the ID of the project in the specified file path.  
		/// Example: Inputting "C:\BF2_ModTools\data_ABC" would return "ABC"
		/// </summary>
		/// <param name="filePath">Path of file to get project ID from.</param>
		/// <returns>ID of the project in the specified file path.</returns>
		public static string GetProjectID(string filePath)
		{
			// Get the project ID
			string projectID = "";
			int index = filePath.LastIndexOf("data_");
			if (index > 0)
			{
				// Chomp off the left half of the string
				var part = filePath.Substring(index + 5);

				// Chomp off the right half of the string so all we have is the project ID
				projectID = part.Substring(0, 3);
			}

			return projectID;
		}


		/// <summary>
		/// Returns the munge directory of the specified file.  
		/// </summary>
		/// <param name="filePath">Path of file to get munge directory from.</param>
		/// <returns>Munge directory of the specified file path.</returns>
		public static string GetMungeDirectory(string filePath)
		{
			string directory = "nil";

			DirectoryInfo dir = new DirectoryInfo(GetFileDirectory(filePath));
			DirectoryInfo dirdir = new DirectoryInfo(dir.Name);
			DirectoryInfo dirdirdir = new DirectoryInfo(dirdir.Name);

			switch (GetMungeType(filePath))
			{
				default:
					directory = "nil";
					break;
				case MungeTypes.Addme:
					directory = GetProjectDirectory(filePath) + "\\addme\\munged\\";
					break;
				case MungeTypes.Common:
					directory = GetProjectDirectory(filePath) + "\\_LVL_PC\\";
					break;
				case MungeTypes.Load:
					directory = GetProjectDirectory(filePath) + "\\_LVL_PC\\Load\\";
					break;
				case MungeTypes.Shell:
					directory = GetProjectDirectory(filePath) + "\\_LVL_PC\\Shell\\";   // TODO: this might be wrong (it might be _LVL_PC)
					break;
				case MungeTypes.Side:
					directory = GetProjectDirectory(filePath) + "\\_LVL_PC\\SIDE\\";
					break;
				case MungeTypes.Sound:
					directory = GetProjectDirectory(filePath) + "\\_LVL_PC\\Sound\\";
					break;
				case MungeTypes.World:
					directory = GetProjectDirectory(filePath) + "\\_LVL_PC\\" + dir.Name;
					break;
			}

			return directory;
		}


		/// <summary>
		/// Returns a list of names of files compiled by the munge script at the specified file path.  
		/// </summary>
		/// <param name="mungeScriptPath">Path of munge script to get list of compiled files from.</param>
		/// <returns>List of names of files compiled by munge script.</returns>
		public static List<string> GetCompiledFiles(string mungeScriptPath)
		{
			List<string> compiledFiles = new List<string>();

			DirectoryInfo dir = new DirectoryInfo(GetFileDirectory(mungeScriptPath));
			DirectoryInfo dirdir = new DirectoryInfo(dir.Name);
			DirectoryInfo dirdirdir = new DirectoryInfo(dirdir.Name);

			//Debug.WriteLine(dir.Name);
			//Debug.WriteLine(dirdir.Name);
			//Debug.WriteLine(dirdirdir.Name);

			switch (GetMungeType(mungeScriptPath))
			{
				default:
					compiledFiles.Add("nil");
					break;
				case MungeTypes.Addme:
					compiledFiles.Add("addme.script");
					break;
				case MungeTypes.Common:
					compiledFiles = ParseLevelpackReqs(mungeScriptPath);
					break;
				case MungeTypes.Load:
					compiledFiles.Add("common.lvl");
					break;
				case MungeTypes.Shell:
					compiledFiles = ParseLevelpackReqs(mungeScriptPath);
					break;
				case MungeTypes.Side:
					compiledFiles = ParseReqsInDirectory(GetProjectDirectory(mungeScriptPath) + "\\Sides\\" + GetParentFolderName(mungeScriptPath));
					break;
				case MungeTypes.Sound:
					compiledFiles.Add("nil");   // since soundmunge takes care of copying files
					break;
				case MungeTypes.World:
					compiledFiles = ParseReqsInDirectory(GetProjectDirectory(mungeScriptPath) + "\\Worlds\\" + GetParentFolderName(mungeScriptPath));
					break;
			}

			if (compiledFiles.Count > 1)
			{
				Debug.WriteLine("Going through list...");
				for (int i = compiledFiles.Count - 1; i > 0; i--)
				{
					Debug.WriteLine(compiledFiles[i]);

					if (compiledFiles[i] == "" || compiledFiles[i] == "\n")
					{
						compiledFiles.RemoveAt(i);
					}
				}
				Debug.WriteLine("Going through list... Done");
			}

			//Debug.WriteLine(directory);

			return compiledFiles;
		}


		/// <summary>
		/// Returns the names of all of the LVLs munged from the REQ files in the given directory (typically side or world). Also automatically excludes sub-LVLs.
		/// </summary>
		/// <param name="directory">File directory containing the REQ files to parse.</param>
		/// <returns>List of the LVL files compiled from the REQ files in the given directory.</returns>
		public static List<string> ParseReqsInDirectory(string directory)
		{
			List<string> reqs = new List<string>();

			try
			{
				string[] reqFiles = Directory.GetFiles(directory, "*.req", SearchOption.AllDirectories);

				// Sub-reqs that should be excluded from the req list
				List<string> excludeReqs = new List<string>();

				// Get all REQ files in the world's directory (and all subfolders)
				foreach (string file in reqFiles)
				{
					// Find any sub-reqs to exclude
					List<string> subReqs = ParseReqChunk(file, "lvl").Contents;
					if (subReqs != null)
					{
						excludeReqs.AddRange(subReqs);
					}

					// Get only the file name
					int index = file.LastIndexOf("\\");
					string fileName = file.Substring(index + 1);

					// Replace the .req extension with .lvl
					fileName = fileName.Substring(0, fileName.LastIndexOf(".")) + ".lvl";
					reqs.Add(fileName);
				}

				// Are there any sub-reqs to exclude?
				if (excludeReqs != null)
				{
					foreach (string req in reqs.ToArray())
					{
						// Check if the req matches any of the reqs that should be excluded
						foreach (string subReq in excludeReqs)
						{
							// Should this req be excluded?
							if (subReq == req.Substring(0, req.LastIndexOf(".")))
							{
								Debug.WriteLine("Match found. Removing req: " + req);
								reqs.Remove(req);
								break;
							}
						}
					}
				}
			}
			catch (ArgumentNullException e)
			{
				Trace.WriteLine(e.Message);
			}
			catch (ArgumentOutOfRangeException e)
			{
				Trace.WriteLine(e.Message);
			}
			catch (DirectoryNotFoundException e)
			{
				Trace.WriteLine(e.Message);
			}
			catch (IOException e)
			{
				Trace.WriteLine(e.Message);
			}
			catch (UnauthorizedAccessException e)
			{
				Trace.WriteLine(e.Message);
			}

			return reqs;
		}


		public static ReqChunk ParseReqChunk(string reqFilePath, string reqChunkName)
		{
			string ParseLine(string line)
			{
				if (line.Contains("\""))
				{
					return line.Substring(line.IndexOf("\"") + 1, line.LastIndexOf("\"") - line.IndexOf("\"") - 1);
				}
				else
				{
					return line;
				}
			}

			bool CheckLine(string line, string match)
			{
				if (line.ToLower().Contains(match.ToLower()))
				{
					//Debug.WriteLine("match: " + match.ToLower());
				}
				return line.ToLower().Contains(match.ToLower());
			}

			ReqChunk reqChunk = new ReqChunk();
			reqChunk.Contents = new List<string>();

			if (!File.Exists(reqFilePath))
			{
				var message = "ERROR! File does not exist at " + reqFilePath;
				Trace.WriteLine(message);
				return reqChunk;
			}
			
			if (GetFileExtension(reqFilePath) != "req")
			{
				var message = "ERROR! File extension is " + reqFilePath;
				Trace.WriteLine(message);
				return reqChunk;
			}

			string curLine;
			int numChunks = 0;
			int curChunkIdx = 0;
			bool foundChunk = false;
			ReqChunkParseState curState = ReqChunkParseState.CheckBegin;
			StreamReader file = new StreamReader(reqFilePath);

			// Count the number of REQ chunks in the file
			while ((curLine = file.ReadLine()) != null)
			{
				//Debug.WriteLine("curLine: " + curLine);
				if (CheckLine(curLine, "REQN"))
				{
					numChunks++;
				}
			}

			Debug.WriteLine("numChunks: " + numChunks);

			// Scan the file line by line and extract the segments from the given REQ chunk
			Debug.WriteLine("Looking for chunk: " + reqChunkName);
			file = new StreamReader(reqFilePath);
			if (numChunks > 0)
			{
				while ((curLine = file.ReadLine()) != null)
				{
					var parsedLine = ParseLine(curLine);
					//Debug.WriteLine("curLine: " + curLine);

					// File Header
					if (CheckLine(parsedLine, "ucft") && curState == ReqChunkParseState.CheckBegin)
					{
						curState = ReqChunkParseState.FileHeader;
					}

					// File Begin - opening bracket
					if (CheckLine(parsedLine, "{") && curState == ReqChunkParseState.FileHeader)
					{
						curState = ReqChunkParseState.FileBegin;
					}

					// Chunk Header
					if (CheckLine(parsedLine, "REQN"))
					{
						curState = ReqChunkParseState.ChunkHeader;
						curChunkIdx++;
					}

					// Chunk Begin - opening bracket
					if (CheckLine(parsedLine, "{") && curState == ReqChunkParseState.ChunkHeader)
					{
						curState = ReqChunkParseState.ChunkBegin;
					}

					// Chunk Name - declaration of chunk type, e.g. "lvl", "class", "config", etc.
					if (!parsedLine.Contains("{") && curState == ReqChunkParseState.ChunkBegin)
					{
						curState = ReqChunkParseState.ChunkName;
						//Debug.WriteLine("Current chunk: " + parsedLine);

						if (parsedLine == reqChunkName)
						{
							Debug.WriteLine("Found chunk: " + parsedLine);
							Debug.WriteLine("Adding Name: " + parsedLine);
							reqChunk.Name = parsedLine;
							foundChunk = true;
						}
						else
						{
							Debug.WriteLine("Wrong chunk: " + parsedLine);
							foundChunk = false;
						}
					}

					// Start processing and storing the different chunk segments if we have the right chunk
					if (foundChunk && reqChunk.Name != null)
					{
						// Chunk Align - chunk header byte align value, pretty much almost always "align=2048"
						if (CheckLine(parsedLine, "align=") && (curState == ReqChunkParseState.ChunkName || curState == ReqChunkParseState.ChunkPlatform))
						{
							curState = ReqChunkParseState.ChunkAlign;
							Debug.WriteLine("Adding Align: " + parsedLine);
							reqChunk.Align = parsedLine;
						}

						// Chunk Platform - platform designation for the chunk, always "platform=" followed by "pc", "ps2" or "xbox", e.g. "platform=pc"
						if ((curState == ReqChunkParseState.ChunkName || curState == ReqChunkParseState.ChunkAlign) && CheckLine(parsedLine, "platform="))
						{
							curState = ReqChunkParseState.ChunkPlatform;
							Debug.WriteLine("Adding Platform: " + parsedLine);
							reqChunk.Platform = parsedLine;
						}

						// Chunk Contents - list of files within the chunk
						if (!CheckLine(parsedLine, "align=") && !CheckLine(parsedLine, "platform=") && !CheckLine(parsedLine, reqChunk.Name) && !CheckLine(parsedLine, "}") &&
							(curState == ReqChunkParseState.ChunkContents || curState == ReqChunkParseState.ChunkName || curState == ReqChunkParseState.ChunkAlign || curState == ReqChunkParseState.ChunkPlatform))
						{
							curState = ReqChunkParseState.ChunkContents;
							
							// Don't add blank lines!
							if (curLine.Contains("\""))
							{
								Debug.WriteLine("Adding Contents: " + parsedLine);
								reqChunk.AddContents(parsedLine);
							}
						}
					}

					// Chunk End - closing bracket
					if (CheckLine(parsedLine, "}") && ((curState == ReqChunkParseState.ChunkContents) || (curState == ReqChunkParseState.ChunkName && !foundChunk)))
					{
						curState = ReqChunkParseState.ChunkEnd;
					}

					// File End - closing bracket
					if (CheckLine(parsedLine, "}") && curState == ReqChunkParseState.ChunkEnd && curChunkIdx == numChunks)
					{
						Debug.WriteLine("END OF FILE");
						curState = ReqChunkParseState.FileEnd;
					}
				}
			}
			else
			{
				Trace.WriteLine("ERROR! There are no chunks in the REQ file @ " + @reqFilePath);
			}

			file.Close();

			return reqChunk;
		}


		/// <summary>
		/// Scans through the munge script at the specified path and extracts all of the names of the REQs compiled by levelpack.
		/// </summary>
		/// <param name="mungeScriptPath">Path of munge script to scan.</param>
		/// <param name="skipUserScripts">Whether or not to skip user scripts and custom GCs.</param>
		/// <param name="skipInshell">Whether or not to skip inshell.</param>
		/// <returns>List of the LVL files compiled by levelpack.</returns>
		public static List<string> ParseLevelpackReqs(string mungeScriptPath, bool skipUserScripts = true, bool skipInshell = true)
		{
			List<string> reqs = new List<string>();

			if (!File.Exists(mungeScriptPath))
			{
				var message = "ERROR! File does not exist at " + mungeScriptPath;
				Trace.WriteLine(message);
				return reqs;
			}


			//Debug.WriteLine("Adding REQs to list:");

			string curLine;

			// Scan the file line by line and extract the REQ names from the levelpack lines
			StreamReader file = new StreamReader(mungeScriptPath);
			while ((curLine = file.ReadLine()) != null)
			{
				// Is the line a levelpack line?
				if (TruncateLongString(curLine, 9).ToLower() == "levelpack")
				{
					string reqName = curLine;
					bool skipFile = false;

					// Sample of the beginning of a levelpack line
					var levelpackSample = "levelpack -inputfile";

					// Remove the right half of the string from the file extension onwards
					reqName = reqName.TruncateLongString(reqName.LastIndexOf(".req"));

					// Remove the left half of the string from the inputfile command onwards
					reqName = reqName.Remove(0, levelpackSample.Length);

					// Trim any excess spaces from the ends of the string
					reqName = reqName.Trim(" "[0]);

					// Add the LVL file extension to the end
					reqName = string.Concat(reqName, ".lvl");


					// Determine whether or not to skip the file
					if (skipUserScripts && !skipFile)
					{
						// Exclude user scripts
						skipFile = reqName.Contains("user_script");
					}
					if (skipUserScripts && !skipFile)
					{
						// Exclude custom GCs
						skipFile = reqName.Contains("custom_gc");
					}
					if (skipInshell && !skipFile)
					{
						// Exclude custom GCs
						skipFile = reqName.Contains("inshell");
					}
					if (!skipFile)
					{
						// Exclude any lines that are for munging sub-lvls (they typically look like this: "MISSION\*.req")
						skipFile = reqName.Contains("*");
					}


					if (!skipFile)
					{
						//Debug.WriteLine(reqName);
						reqs.Add(reqName);
					}
				}
			}

			file.Close();
			
			return reqs;
		}


		/// <summary>
		/// Returns the munge type of the specified file.  
		/// </summary>
		/// <param name="filePath">Path of file to get munge type from.</param>
		/// <returns>Munge type of the specified file path.</returns>
		public static MungeTypes GetMungeType(string filePath)
		{
			DirectoryInfo dir = new DirectoryInfo(GetFileDirectory(filePath));
			DirectoryInfo dirdir = new DirectoryInfo(dir.Name);
			DirectoryInfo dirdirdir = new DirectoryInfo(dirdir.Name);

			// Get the project ID
			MungeTypes type;
			if (dir.Name.ToLower() == "addme")
			{
				type = MungeTypes.Addme;
			}
			else if (dir.Name.ToLower() == "common")
			{
				type = MungeTypes.Common;
			}
			else if (dir.Name.ToLower() == "load")
			{
				type = MungeTypes.Load;
			}
			else if (dir.Name.ToLower() == "shell")
			{
				type = MungeTypes.Shell;
			}
			else if (dir.Name.ToLower() == "sound")
			{
				type = MungeTypes.Sound;
			}
			else
			{
				if (GetParentFolderName(GetFileDirectory(filePath)).ToLower() == "sides")
				{
					type = MungeTypes.Side;
				}
				else if (GetParentFolderName(GetFileDirectory(filePath)).ToLower() == "worlds")
				{
					type = MungeTypes.World;
				}
				else
				{
					Debug.WriteLine(GetParentFolderName(GetFileDirectory(filePath)).ToLower());
					type = MungeTypes.Nil;
				}
			}

			return type;
		}


		public static List<JsonPair> ParseJsonStrings(string url)
		{
			var json = new WebClient().DownloadString(url);

			List<JsonPair> parsedJson = new List<JsonPair>();
			JsonPair curPair = new JsonPair();

			JsonTextReader reader = new JsonTextReader(new StringReader(json));
			while (reader.Read())
			{
				if (reader.Value != null)
				{
					switch (reader.TokenType)
					{
						case JsonToken.PropertyName:
							curPair.Key = reader.Value;
							break;
						case JsonToken.String:
							curPair.Value = reader.Value;
							if (curPair.Key != null)
								parsedJson.Add(curPair);
							break;
						case JsonToken.Integer:
							curPair.Value = reader.Value;
							if (curPair.Key != null)
								parsedJson.Add(curPair);
							break;
					}
				}
			}

			return parsedJson;
		}


		/// <summary>
		/// Returns the current time in 12-hour format, e.g. "12:40:34 AM".
		/// </summary>
		/// <returns>Current time in 12-hour format.</returns>
		public static string GetTimestamp()
		{
			return DateTime.Now.ToString("h:mm:ss tt");
		}


		/// <summary>
		/// Plays the specified sound type.
		/// </summary>
		/// <param name="type">Type of sound to play ("start", "success", or "abort").</param>
		public static void PlaySound(string type)
		{
			if (!Properties.Settings.Default.PlayNotificationSounds) { return; }

			string soundToPlay = "null";

			if (type == "start")
			{
				soundToPlay = Directory.GetCurrentDirectory() + "\\ZeroMunge\\start.wav";
			}
			if (type == "success")
			{
				soundToPlay = Directory.GetCurrentDirectory() + "\\ZeroMunge\\success.wav";
			}
			if (type == "abort")
			{
				soundToPlay = Directory.GetCurrentDirectory() + "\\ZeroMunge\\abort.wav";
			}

			// Does the sound file exist?
			if (File.Exists(soundToPlay) || soundToPlay != "null")
			{
				SoundPlayer sound = new SoundPlayer(soundToPlay);
				sound.Play();
			}
		}


		/// <summary>
		/// Returns an object containing the application's saved user settings.
		/// </summary>
		/// <returns>Prefs object containing the application's saved user settings.</returns>
		public static Prefs LoadPrefs()
		{
			Prefs prefs = new Prefs {
				GameDirectory = Properties.Settings.Default.GameDirectory,
				ShowTrayIcon = Properties.Settings.Default.ShowTrayIcon,
				ShowNotificationPopups = Properties.Settings.Default.ShowNotificationPopups,
				PlayNotificationSounds = Properties.Settings.Default.PlayNotificationSounds,
				AutoDetectStagingDir = Properties.Settings.Default.AutoDetectStagingDir,
				AutoDetectMungedFiles = Properties.Settings.Default.AutoDetectMungedFiles
			};

			return prefs;
		}


		/// <summary>
		/// Saves the provided Prefs values into the application settings.
		/// </summary>
		/// <param name="prefs">Prefs object containing the values to save.</param>
		public static void SavePrefs(Prefs prefs)
		{
			Properties.Settings.Default.GameDirectory = prefs.GameDirectory;
			Properties.Settings.Default.ShowTrayIcon = prefs.ShowTrayIcon;
			Properties.Settings.Default.ShowNotificationPopups = prefs.ShowNotificationPopups;
			Properties.Settings.Default.PlayNotificationSounds = prefs.PlayNotificationSounds;
			Properties.Settings.Default.AutoDetectStagingDir = prefs.AutoDetectStagingDir;
			Properties.Settings.Default.AutoDetectMungedFiles = prefs.AutoDetectMungedFiles;

			Properties.Settings.Default.Save();
		}
	}

	public class Prefs
	{
		public string GameDirectory { get; set; }
		public bool ShowTrayIcon { get; set; }
		public bool ShowNotificationPopups { get; set; }
		public bool PlayNotificationSounds { get; set; }
		public bool AutoDetectStagingDir { get; set; }
		public bool AutoDetectMungedFiles { get; set; }
	}

	public class ReqChunk
	{
		/// <summary>
		/// Name of the chunk.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Header byte align value.
		/// </summary>
		public string Align { get; set; }

		/// <summary>
		/// Chunk's platform designation.
		/// </summary>
		public string Platform { get; set; }

		/// <summary>
		/// List of files within the chunk.
		/// </summary>
		public List<string> Contents { get; set; }

		public void AddContents(string file)
		{
			if (Contents == null)
			{
				Contents = new List<string>();
			}
			Contents.Add(file);
		}

		/// <summary>
		/// Print all of the chunk's segments.
		/// </summary>
		public void PrintAll()
		{
			Debug.WriteLine("PrintAll(): START OF CHUNK");
			Debug.WriteLine("PrintAll(): Name        = " + Name);
			if (Align != null)
			{
				Debug.WriteLine("PrintAll(): Align       = " + Align);
			}
			if (Platform != null)
			{
				Debug.WriteLine("PrintAll(): Platform    = " + Platform);
			}
			if (Contents != null)
			{
				foreach (string file in Contents)
				{
					Debug.WriteLine("PrintAll(): Contents    = " + file);
				}
			}
			Debug.WriteLine("PrintAll(): END OF CHUNK");
		}
	}
}
