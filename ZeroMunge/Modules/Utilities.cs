using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using ZeroMunge.Modules;

namespace ZeroMunge
{
	public static class Utilities
	{
		public const string UPDATES_URL = "https://raw.githubusercontent.com/Gametoast/ZeroMunge/master/json/updates.json";
		public const string NET_CHECK_URL = "http://clients3.google.com/generate_204";
		public const string HELP_PATH = @"ZeroMunge\ZeroMungeHelp.chm";

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
		}

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
		}

		public enum UpdateResult
		{
			NoneAvailable,
			Available,
			NetConnectionError
		}

		public enum SoundType
		{
			Start,
			Success,
			Abort
		}

		/// <summary>
		/// Returns the input string with a '\\' to the end of the string if it doesn't already have it.
		/// </summary>
		public static string EnsureTrailingSlash(string input)
		{
			if (!input.EndsWith("\\"))
				input += "\\";
			return input;
		}


		/// <summary>
		/// Extracts the attributes from an HTML node. 
		/// 
		/// Source: http://omegacoder.com/?p=512
		/// </summary>
		/// <param name="node">HTML node to extract attributes from.</param>
		/// <returns>Dictionary storing the attributes and their values as key-value string pairs.</returns>
		public static Dictionary<string, string> ExtractHtmlAttributes(string node)
		{
			string pattern = @"
(?:<)(?<Tag>[^\s/>]+)       # Extract the tag name.
(?![/>])                    # Stop if /> is found
                     # -- Extract Attributes Key Value Pairs  --
 
((?:\s+)             # One to many spaces start the attribute
 (?<Key>[^=]+)       # Name/key of the attribute
 (?:=)               # Equals sign needs to be matched, but not captured.
 
(?([\x22\x27])              # If quotes are found
  (?:[\x22\x27])
  (?<Value>[^\x22\x27]+)    # Place the value into named Capture
  (?:[\x22\x27])
 |                          # Else no quotes
   (?<Value>[^\s/>]*)       # Place the value into named Capture
 )
)+                  # -- One to many attributes found!";

			var attributes = (from Match mt in Regex.Matches(@node, pattern, RegexOptions.IgnorePatternWhitespace)
							  select new
							  {
								  Name = mt.Groups["Tag"],
								  Attrs = (from cpKey in mt.Groups["Key"].Captures.Cast<Capture>().Select((a, i) => new { a.Value, i })
										   join cpValue in mt.Groups["Value"].Captures.Cast<Capture>().Select((b, i) => new { b.Value, i }) on cpKey.i equals cpValue.i
										   select new KeyValuePair<string, string>(cpKey.Value, cpValue.Value)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
							  }).First().Attrs;


			//foreach (KeyValuePair<string, string> kvp in attributes)
			//	Trace.WriteLine("Key {0,15}    Value: {1}", kvp.Key, kvp.Value);

			return attributes;
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
		/// Shortcut method to return the directory of the specified file path.  
		/// Example: Inputting "C:\Documents\foo.bar" would return "C:\Documents"
		/// </summary>
		/// <param name="filePath">Path of file to get directory from.</param>
		/// <returns>Directory of the specified file path.</returns>
		public static string GetFileDirectory(string filePath)
		{
			return new DirectoryInfo(filePath).Parent.FullName;
		}


		/// <summary>
		/// Shortcut method to return the name of the specified file path's parent folder.  
		/// Example: Inputting "C:\Documents\foo.bar" would return "Documents"
		/// </summary>
		/// <param name="filePath">Path of file to get parent folder name from.</param>
		/// <returns>Name of the specified file path's parent folder.</returns>
		public static string GetParentFolderName(string filePath)
		{
			return new DirectoryInfo(GetFileDirectory(filePath)).Name;
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
					compiledFiles = ParseReqsInDirectory(GetProjectDirectory(mungeScriptPath) + "\\Sides\\" + GetParentFolderName(mungeScriptPath), SearchOption.TopDirectoryOnly);
					break;
				case MungeTypes.Sound:
					compiledFiles.Add("nil");   // since soundmunge takes care of copying files
					break;
				case MungeTypes.World:
					compiledFiles = ParseReqsInDirectory(GetProjectDirectory(mungeScriptPath) + "\\Worlds\\" + GetParentFolderName(mungeScriptPath), SearchOption.AllDirectories);
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
		public static List<string> ParseReqsInDirectory(string directory, SearchOption searchOption)
		{
			List<string> reqs = new List<string>();

			try
			{
				string[] reqFiles = Directory.GetFiles(directory, "*.req", searchOption);

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
					string fileName = file.Substring(index + 1).ToLower();

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
							if (subReq.ToLower() == req.Substring(0, req.LastIndexOf(".")))
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


		/// <summary>
		/// Returns the contents of a given chunk name in a REQ file.
		/// </summary>
		/// <param name="reqFilePath">File path of REQ file to parse chunk from.</param>
		/// <param name="reqChunkName">Name of REQ chunk to parse.</param>
		/// <returns>Contents of parsed REQ chunk.</returns>
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

			if (new FileInfo(reqFilePath).Extension != "req")
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
								Debug.WriteLine("Adding Contents: " + parsedLine.ToLower());
								reqChunk.AddContents(parsedLine.ToLower());
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
				if (curLine.TruncateLongString(9).ToLower() == "levelpack")
				{
					bool skipFile = false;

					// Sample of the beginning of a levelpack line
					var levelpackSample = "levelpack -inputfile";

					// Remove the right half of the string from the file extension onwards
					string reqName = curLine
						.TruncateLongString(curLine.LastIndexOf(".req"))    // Remove the right half of the string from the file extension onwards
						.Remove(0, levelpackSample.Length)                  // Remove the left half of the string from the inputfile command onwards
						.Trim(" "[0]);                                      // Trim any excess spaces from the ends of the string

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


		/// <summary>
		/// Attempts to download a JSON string from the specified URL and return it as a List of JsonPairs.
		/// </summary>
		/// <param name="sender">Sending form.</param>
		/// <param name="url">Web address to download the JSON string from.</param>
		/// <returns>List of JsonPairs parsed from the downloaded JSON string.</returns>
		public static List<JsonPair> ParseJsonStringsFromUrl(Form sender, string url)
		{
			string json;

			ZeroMunge mainForm = sender as ZeroMunge;

			try
			{
				json = new WebClient().DownloadString(url);
			}
			catch (WebException e)
			{
				var message = "Failed to retrieve update payload. Reason: " + e.Message;
				Trace.WriteLine(message);
				if (mainForm != null)
				{
					mainForm.Log(message, LogType.Error);
				}

				return null;
			}

			return ParseJsonStrings(mainForm, json);
		}


		/// <summary>
		/// Converts a JSON string into a List of key-value JsonPairs.
		/// </summary>
		/// <param name="sender">Sending form.</param>
		/// <param name="unparsedJson">JSON string to parse.</param>
		/// <returns>List of JsonPairs parsed from the specified JSON string.</returns>
		public static List<JsonPair> ParseJsonStrings(Form sender, string unparsedJson)
		{
			List<JsonPair> parsedJson = new List<JsonPair>();
			JsonPair curPair = new JsonPair();
			int curStep = 0;

			ZeroMunge mainForm = sender as ZeroMunge;

			try
			{
				JsonTextReader reader = new JsonTextReader(new StringReader(unparsedJson));
				while (reader.Read())
				{
					if (reader.Value != null)
					{
						Debug.WriteLine("ParseJsonStrings - Value: " + reader.Value);

						// Determine if this is a key or value
						switch (reader.TokenType)
						{
							case JsonToken.PropertyName:
								curStep = 0;
								break;
							case JsonToken.String:
								curStep = 1;
								break;
							case JsonToken.Integer:
								curStep = 1;
								break;
						}

						// Create a new JsonPair if this is a key
						if (curStep == 0)
						{
							curPair = new JsonPair();
						}

						// Store the key or value in the current JsonPair
						switch (curStep)
						{
							case 0:
								curPair.Key = reader.Value;
								break;
							case 1:
								curPair.Value = reader.Value;
								if (curPair.Key != null)
									parsedJson.Add(curPair);
								break;
						}
					}
				}
			}
			catch (ArgumentNullException ex)
			{
				var msg = "ArgumentNullException when trying to parse json. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				if (mainForm != null)
				{
					mainForm.Log(msg, LogType.Error);
				}
			}
			catch (NullReferenceException ex)
			{
				var msg = "NullReferenceException when trying to parse json. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				if (mainForm != null)
				{
					mainForm.Log(msg, LogType.Error);
				}
			}
			catch (JsonReaderException ex)
			{
				var msg = "JsonReaderException when trying to parse json. Reason: " + ex.Message;
				Trace.WriteLine(msg);
				if (mainForm != null)
				{
					mainForm.Log(msg, LogType.Error);
				}
			}

			return parsedJson;
		}


		/// <summary>
		/// If there is an internet connection, checks for updates and returns true if an update is available.
		/// </summary>
		/// <returns>True if an update is available, false if not.</returns>
		public static UpdateInfo CheckForUpdates(Form sender, bool useWaitCursor)
		{
			Trace.WriteLine("Checking for application updates...");

			UpdateInfo updateInfo = new UpdateInfo();

			if (CheckForInternetConnection(sender, useWaitCursor))
			{
				updateInfo.LatestVersionInfo = GetLatestVersion(sender);
				if (updateInfo.LatestVersionInfo == null) return null;

				int curBuild = Properties.Settings.Default.Info_BuildNum;

				Debug.WriteLine("Current build, latest build:    {0}, {1}", curBuild, updateInfo.LatestVersionInfo.BuildNum);

				// Prompt for update if one is available
				if (curBuild < updateInfo.LatestVersionInfo.BuildNum)
				{
					Trace.WriteLine("Update is available.");
					updateInfo.CheckResult = UpdateResult.Available;
				}
				else
				{
					Trace.WriteLine("No updates available!");
					updateInfo.CheckResult = UpdateResult.NoneAvailable;
				}
			}
			else
			{
				Trace.WriteLine("There is no internet connection!");
				updateInfo.CheckResult = UpdateResult.NetConnectionError;
			}

			return updateInfo;
		}


		/// <summary>
		/// Checks for the latest application version from a pre-specified updates URL and returns a VersionInfo object containing the information.
		/// </summary>
		/// <returns>UpdateInfo object containing the latest build number, the download URL, and release notes.</returns>
		public static VersionInfo GetLatestVersion(Form sender)
		{
			List<JsonPair> parsedJson = new List<JsonPair>();
			parsedJson = ParseJsonStringsFromUrl(sender, UPDATES_URL);
			if (parsedJson == null) return null;
			VersionInfo info = new VersionInfo
			{
				BuildNum = 0
			};

			foreach (JsonPair pair in parsedJson)
			{
				Debug.WriteLine("Key, Value:    {0}, {1}", pair.Key, pair.Value);

				if ((string)pair.Key == "Version")
				{
					info.Version = pair.Value.ToString();
				}
				if ((string)pair.Key == "BuildNum")
				{
					info.BuildNum = Convert.ToInt32(pair.Value);
				}
				if ((string)pair.Key == "BuildDate")
				{
					info.BuildDate = pair.Value.ToString();
				}
				if ((string)pair.Key == "DownloadUrl")
				{
					info.DownloadUrl = pair.Value.ToString();
				}
				if ((string)pair.Key == "ReleaseNotes")
				{
					info.ReleaseNotes = pair.Value.ToString();
				}
			}

			return info;
		}


		/// <summary>
		/// Checks for an internet connection by attempting to read the contents of a pre-specified URL.
		/// </summary>
		/// <returns>True if an internet connection could be established, false if not.</returns>
		public static bool CheckForInternetConnection(Form sender, bool useWaitCursor)
		{
			bool TryConnection(string url)
			{
				if (useWaitCursor)
				{
					sender.Cursor = Cursors.WaitCursor;
					Application.DoEvents();
				}

				try
				{
					using (var client = new WebClient())
					{
						using (client.OpenRead(url))
						{
							Trace.WriteLine("Trying '" + url + "' ...");
							if (useWaitCursor)
							{
								sender.Cursor = Cursors.Default;
								Application.DoEvents();
							}
							return true;
						}
					}
				}
				catch
				{
					Trace.WriteLine("Failed to establish connection with '" + url + "'");
					if (useWaitCursor)
					{
						sender.Cursor = Cursors.Default;
						Application.DoEvents();
					}
					return false;
				}
			}

			// First try the Google test url, then if it fails try the actual updates url
			if (TryConnection(NET_CHECK_URL)) { return true; }
			if (TryConnection(UPDATES_URL)) { return true; }

			// Can't establish a connection if we've made it this far
			return false;
		}


		/// <summary>
		/// Starts the menu flow for checking for updates.
		/// </summary>
		/// <param name="sender">Sending Form, `this` can usually be used.</param>
		public static void StartFlow_CheckForUpdates(Form sender, bool useWaitCursor)
		{
			UpdateInfo updateInfo = CheckForUpdates(sender, useWaitCursor);
			if (updateInfo == null)
			{
				Trace.WriteLine("Check failed for an unknown reason.");
				MessageBox.Show(sender, "Unable to check for updates for an unknown reason.", "Updates");
				return;
			}

			switch (updateInfo.CheckResult)
			{
				case UpdateResult.Available:
					Trace.WriteLine("Check succeeded. Update is available. Pushing update prompt.");
					ZeroMunge.Flow_Updates_Start();
					break;

				case UpdateResult.NoneAvailable:
					Trace.WriteLine("Check succeeded. No updates are available.");
					MessageBox.Show(sender, "No new updates are available.", "Updates");
					break;

				case UpdateResult.NetConnectionError:
					Trace.WriteLine("Check failed. Network connection could not be established.");
					MessageBox.Show(sender, "Unable to check for updates. Please check your Internet connection.", "Updates");
					break;
			}
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
		/// Opens the specified file in the 'ZeroMunge' directory.
		/// </summary>
		/// <param name="fileName">Name of the file to open.</param>
		/// <returns>If the file is opened successfully, a success message is returned. If not, an error message is returned.</returns>
		public static string OpenApplicationResourceFile(string fileName)
		{
			string file = Directory.GetCurrentDirectory() + "\\ZeroMunge\\" + fileName;
			string result = "";

			try
			{
				Process.Start(file);
				result = string.Format("Opening file list: \"{0}\"", file);
			}
			catch (UnauthorizedAccessException ex)
			{
				result = string.Format("Could not open \"{0}\". Reason: {1}", file, ex.Message);
				Trace.WriteLine(result);
			}
			catch (FileNotFoundException ex)
			{
				result = string.Format("Could not open \"{0}\". Reason: {1}", file, ex.Message);
				Trace.WriteLine(result);
			}
			catch (ObjectDisposedException ex)
			{
				result = string.Format("Could not open \"{0}\". Reason: {1}", file, ex.Message);
				Trace.WriteLine(result);
			}
			catch (System.ComponentModel.Win32Exception ex)
			{
				result = string.Format("Could not open \"{0}\". Reason: {1}", file, ex.Message);
				Trace.WriteLine(result);
			}

			return result;
		}


		/// <summary>
		/// Opens the Help file.
		/// </summary>
		/// <param name="sender">Sending form.</param>
		public static void OpenHelp(Form sender)
		{
			OpenHelp(sender, "topic_start");
		}
		/// <summary>
		/// Opens the Help file at the specified topic.
		/// </summary>
		/// <param name="sender">Sending form.</param>
		/// <param name="topic">Name of the help topic to open. Should only be the file name without the extension. Ex: "topic_start"</param>
		public static void OpenHelp(Form sender, string topic)
		{
			if (File.Exists(HELP_PATH))
			{
				string helpTopic = string.Format("src/{0}.html", topic);
				Help.ShowHelp(sender, HELP_PATH, HelpNavigator.Topic, helpTopic);
			}
			else
			{
				var message = string.Format("Help file does not exist at path: \"{0}\"", HELP_PATH);
				Trace.WriteLine(message);

				if (sender is ZeroMunge)
				{
					ZeroMunge zm = sender as ZeroMunge;
					zm.Log(message, LogType.Error);
				}
				else
				{
					MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}


		/// <summary>
		/// Plays the specified sound type.
		/// </summary>
		/// <param name="type">Type of sound to play.</param>
		public static void PlaySound(SoundType type)
		{
			if (!Properties.Settings.Default.PlayNotificationSounds) { return; }

			string soundToPlay = "null";

			switch (type)
			{
				case SoundType.Start:
					soundToPlay = Directory.GetCurrentDirectory() + "\\ZeroMunge\\start.wav";
					break;

				case SoundType.Success:
					soundToPlay = Directory.GetCurrentDirectory() + "\\ZeroMunge\\success.wav";
					break;

				case SoundType.Abort:
					soundToPlay = Directory.GetCurrentDirectory() + "\\ZeroMunge\\abort.wav";
					break;
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
			Prefs prefs = new Prefs
			{
				GameDirectory = Properties.Settings.Default.GameDirectory,
				ShowTrayIcon = Properties.Settings.Default.ShowTrayIcon,
				ShowNotificationPopups = Properties.Settings.Default.ShowNotificationPopups,
				PlayNotificationSounds = Properties.Settings.Default.PlayNotificationSounds,
				AutoDetectStagingDir = Properties.Settings.Default.AutoDetectStagingDir,
				AutoDetectMungedFiles = Properties.Settings.Default.AutoDetectMungedFiles,
				LogPollingRate = Properties.Settings.Default.LogPollingRate,
				LogMaxLineCount = Properties.Settings.Default.LogMaxLineCount,
				OutputLogToFile = Properties.Settings.Default.OutputLogToFile,
				LogPrintTimestamps = Properties.Settings.Default.LogPrintTimestamps,
				ShowUpdatePromptOnStartup = Properties.Settings.Default.ShowUpdatePromptOnStartup,
				CheckForUpdatesOnStartup = Properties.Settings.Default.CheckForUpdatesOnStartup,
				AutoSaveEnabled = Properties.Settings.Default.AutoSaveEnabled,
				LastSaveFilePath = Properties.Settings.Default.LastSaveFilePath,
				AutoLoadEnabled = Properties.Settings.Default.AutoLoadEnabled,
				ShowMungeOutputDir = Properties.Settings.Default.ShowMungeOutputDir,
				RecentFiles = Properties.Settings.Default.RecentFiles,
				PreferredTextEditor = Properties.Settings.Default.PreferredTextEditor,
				PreferredZeroEditor = Properties.Settings.Default.PreferredZeroEditor,
				DebuggerExe = Properties.Settings.Default.DebuggerExe,
				DebuggerArgs = Properties.Settings.Default.DebuggerArgs,
				GameExeArgs = Properties.Settings.Default.GameExeArgs,
				ModToolsLocation = Properties.Settings.Default.ModToolsLocation,
				PSPGameLocation = Properties.Settings.Default.PSPGameLocation,
				PPSSPPLocation = Properties.Settings.Default.PPSSPPLocation,
				ProfileName = Properties.Settings.Default.ProfileName,
				XboxCopyFolder = Properties.Settings.Default.XboxCopyFolder,
				PS2CopyFolder = Properties.Settings.Default.PS2CopyFolder,
				FTPDest = Properties.Settings.Default.FTPDest,
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
			Properties.Settings.Default.LogPollingRate = prefs.LogPollingRate;
			Properties.Settings.Default.LogMaxLineCount = prefs.LogMaxLineCount;
			Properties.Settings.Default.OutputLogToFile = prefs.OutputLogToFile;
			Properties.Settings.Default.LogPrintTimestamps = prefs.LogPrintTimestamps;
			Properties.Settings.Default.ShowUpdatePromptOnStartup = prefs.ShowUpdatePromptOnStartup;
			Properties.Settings.Default.CheckForUpdatesOnStartup = prefs.CheckForUpdatesOnStartup;
			Properties.Settings.Default.AutoSaveEnabled = prefs.AutoSaveEnabled;
			Properties.Settings.Default.LastSaveFilePath = prefs.LastSaveFilePath;
			Properties.Settings.Default.AutoLoadEnabled = prefs.AutoLoadEnabled;
			Properties.Settings.Default.ShowMungeOutputDir = prefs.ShowMungeOutputDir;
			Properties.Settings.Default.RecentFiles = prefs.RecentFiles;
			Properties.Settings.Default.PreferredTextEditor = prefs.PreferredTextEditor;
			Properties.Settings.Default.PreferredZeroEditor = prefs.PreferredZeroEditor;
			Properties.Settings.Default.DebuggerExe = prefs.DebuggerExe;
			Properties.Settings.Default.DebuggerArgs = prefs.DebuggerArgs;
			Properties.Settings.Default.GameExeArgs = prefs.GameExeArgs;
			Properties.Settings.Default.ModToolsLocation = prefs.ModToolsLocation;
			Properties.Settings.Default.PSPGameLocation = prefs.PSPGameLocation;
			Properties.Settings.Default.PPSSPPLocation = prefs.PPSSPPLocation;
			Properties.Settings.Default.ProfileName = prefs.ProfileName;
			Properties.Settings.Default.XboxCopyFolder = prefs.XboxCopyFolder;
			Properties.Settings.Default.PS2CopyFolder = prefs.PS2CopyFolder;
			Properties.Settings.Default.FTPDest = prefs.FTPDest;
			Properties.Settings.Default.Save();
		}
	}

	public class JsonPair
	{
		public object Key { get; set; }
		public object Value { get; set; }
	}

	public class VersionInfo
	{
		public string Version { get; set; }
		public int BuildNum { get; set; }
		public string BuildDate { get; set; }
		public string DownloadUrl { get; set; }
		public string ReleaseNotes { get; set; }
	}

	public class UpdateInfo
	{
		public Utilities.UpdateResult CheckResult { get; set; }
		public VersionInfo LatestVersionInfo { get; set; }
	}

	public class Prefs
	{
		public string GameDirectory { get; set; }
		public bool ShowTrayIcon { get; set; }
		public bool ShowNotificationPopups { get; set; }
		public bool PlayNotificationSounds { get; set; }
		public bool AutoDetectStagingDir { get; set; }
		public bool AutoDetectMungedFiles { get; set; }
		public bool ShowMungeOutputDir { get; set; }
		public int LogPollingRate { get; set; }
		public int LogMaxLineCount { get; set; }
		public bool OutputLogToFile { get; set; }
		public bool LogPrintTimestamps { get; set; }
		public bool ShowUpdatePromptOnStartup { get; set; }
		public bool CheckForUpdatesOnStartup { get; set; }
		public bool AutoSaveEnabled { get; set; }
		public bool AutoLoadEnabled { get; set; }
		public string LastSaveFilePath { get; set; }
		public StringCollection RecentFiles { get; set; }
		public String PreferredTextEditor { get; set; }
		public String PreferredZeroEditor { get; set; }
		public String DebuggerExe { get; set; }
		public String DebuggerArgs { get; set; }
		public String GameExeArgs { get; set; }
		public String ModToolsLocation { get; set; }
		public string PSPGameLocation { get; set; }
		public string PPSSPPLocation { get; set; }
		public string ProfileName { get; set; }
		public string XboxCopyFolder { get; set; }
		public string PS2CopyFolder { get; set; }
		public string FTPDest { get; set; }
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

	public enum Platform
	{
		None,
		PC,
		XBOX,
		PS2
	}

	public enum LogType
	{
		None,
		Munge,
		Info,
		Update,
		Warning,
		Error
	}
	public interface Logger
	{
		void Log(string message);
		void Log(string message, LogType logType);
	}
}
