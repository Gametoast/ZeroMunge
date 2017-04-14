using System;
using System.IO;
using System.Media;

namespace AutomationTool.Modules
{
    public static class Utilities
    {
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
        /// Returns the project ID of the project in the specified file path.  
        /// Example: Inputting "C:\BF2_ModTools\data_ABC" would return "ABC"
        /// </summary>
        /// <param name="filePath">Path of file to get project ID from.</param>
        /// <returns>Project ID of the project in the specified file path.</returns>
        public static string GetProjectID(string filePath)
        {
            // Get the project ID
            string projectID = "";
            int index = filePath.LastIndexOf("data_");
            if (index > 0)
            {
                projectID = filePath.Substring(index + 5);
            }

            return projectID;
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
