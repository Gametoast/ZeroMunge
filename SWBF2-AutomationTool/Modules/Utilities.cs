using System;
using System.Diagnostics;
using System.IO;
using System.Media;

namespace AutomationTool.Modules
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
            else if (dirdir.Name.ToLower() == "sides")
            {
                type = MungeTypes.Side;
            }
            else if (dir.Name.ToLower() == "sound")
            {
                type = MungeTypes.Sound;
            }
            else if (dirdir.Name.ToLower() == "worlds")
            {
                type = MungeTypes.World;
            }
            else
            {
                type = MungeTypes.Nil;
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
    }
}
