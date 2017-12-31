using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Text.RegularExpressions;

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
                    compiledFiles.Add(GetParentFolderName(mungeScriptPath) + ".lvl");
                    break;
                case MungeTypes.Sound:
                    compiledFiles.Add("nil");   // since soundmunge takes care of copying files
                    break;
                case MungeTypes.World:
                    compiledFiles = ParseWorldReqs(mungeScriptPath);
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
        /// Returns the names of all of the main world LVLs munged by a given world munge script.
        /// </summary>
        /// <param name="mungeScriptPath">Path of world munge script to get munged LVL names from.</param>
        /// <returns>List of the world LVL files compiled by levelpack.</returns>
        public static List<string> ParseWorldReqs(string mungeScriptPath)
        {
            List<string> reqs = new List<string>();
            List<string> worlds = new List<string>();
            
            string worldID = GetParentFolderName(mungeScriptPath);
            string worldPath = GetProjectDirectory(mungeScriptPath) + "\\Worlds\\" + worldID;

            // Add world directories (e.g. world1, world2, world3, etc.) to list
            try
            {
                var worldsArray = Directory.GetDirectories(worldPath);
                foreach (string world in worldsArray)
                {
                    if (world.ToLower().Contains("world"))
                    {
                        worlds.Add(world);
                    }
                }
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

            // Get all REQ files in each world directory (and all subfolders)
            foreach (string dir in worlds)
            {
                try
                {
                    var reqFiles = Directory.GetFiles(dir, "*.req", SearchOption.AllDirectories);
                    foreach (string file in reqFiles)
                    {
                        // Get only the file name
                        int index = file.LastIndexOf("\\");
                        string fileName = file.Substring(index + 1);

                        // Replace the .req extension with .lvl
                        fileName = fileName.Substring(0, fileName.LastIndexOf(".")) + ".lvl";
                        reqs.Add(fileName);
                    }
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
            }

            return reqs;
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
}
