using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroMunge
{
	public static class Tooltips
	{
		public static class FileMenu
		{
			public const string New = "Start a new file.";
			public const string Open = "Open a saved file list.";
			public const string OpenRecent = "Select a recent file list to open.";
			public const string ClearRecentFileList = "Clear the list of recent files.";
			public const string Save = "Save the current file list.";
			public const string SaveAs = "Save the current file list to a new file.";
			public const string Exit = "Quit the application.";
		}

		public static class FileList
		{
			public const string Run = "Start the munge process. In the default 'list view' UI, each file will be executed sequentially.\n"+
									  "In the 'alternate UI' view (F12), only the project for the specified 'munge folder' will be munged.";
			public const string Cancel = "Stop processing files.  \n\nWARNING: Canceling a munge is strongly NOT recommended.";
			public const string EasyFilePicker = "Open the Easy File Picker, which greatly simplifies the process of adding munge files to the file list.";
			public const string AddFiles = "Open a prompt to add files to the file list.";
			public const string AddFolders = "Open a prompt to select folders containing munge.bat files to add to the file list.";
			public const string AddProject = "Open a prompt to select a project folder (the 'data_<MOD_ID>' folder).";
			public const string RemoveFile = "Remove the selected files from the file list.";
			public const string RemoveAllFiles = "Remove all files from the file list.";
			public const string HelpButton = "Get help with the user interface.";
		}

		public static class Actions
		{
			public const string OpenGameLog = "Open BFront2.log 'debug log'.";
			public const string OpenModToolsExe = "Launch the ModTools debugger program.";
			public const string OpenZeroEditor = "Launch Zero Editor.";
			public const string OpenGameExe = "Launch Star Wars Battlefront II.";
			public const string OpenGameFolder = "Open the 'GameData' folder.";
		}

		public static class OutputLog
		{
			public const string CopyLog = "Copy the contents of the output log window to the clipboard.";
			public const string SaveLogAs = "Save the contents of the output log to a new file.";
			public const string ClearLog = "Clear the contents of the output log.";
		}

		public static class Tools
		{
			public const string CreateSideMungeFolder = "Automatically create the munge folder (and batch scripts) for a side by simply selecting its side folder.";
			public const string CreateWorldMungeFolder = "Automatically create the munge folder (and batch scripts) for a world by simply selecting its world folder.";
			public const string FixWorldMungeFile = "Check to see if a world's munge.bat script is set to munge the correct world and fix it if not.";
			public const string FixSoundMungeFiles = "Apply the sound munge fixes to a project directory.";
			public const string ModifyMungedSoundFolders = "Select which sound folders should be munged when sound is munged.";
		}

		public static class SoundMungeForm
		{
			public const string Browse = "Browse for a project directory.";
			public const string Apply = "Apply the modifications to the project directory's soundmunge.bat file. Each selected folder in the tree view will be added to the file.";
			public const string Close = "Close this dialog.";
			public const string HelpButton = "Get help with the user interface for this dialog.";
		}

		public static class EasyFilePicker
		{
			public const string OK = "Close this dialog and add the munge files for the selected items to the file list.";
			public const string Cancel = "Close this dialog.";
			public const string HelpButton = "Get help with the user interface for this dialog.";
			public const string AddProject = "Open a prompt to select a mod project folder to add to the treeview.";
		}

		public static class Updates
		{
			public const string Yes = "Open a web page to download the update in the default browser.";
			public const string No = "Close this prompt without downloading the update.";
			public const string ShowUpdatePrompt = "If checked, this prompt will be shown whenever an update is available.";
		}

		public static class ThirdPartySoftware
		{
			public const string OK = "Close this dialog and return to the application.";
		}

		public static class Settings
		{
			public const string OK = "Save any changes made and close this dialog.";
			public const string Cancel = "Close this dialog without saving changes made.";
			public const string OpenPreferences = "Change various application settings such as checking for updates or showing the update prompt on startup, file list auto-save and auto-load, etc.";
			public const string SetGamePath = "Open a prompt to point Zero Munge to Battlefront's GameData directory.";
			public const string ShowTrayIcon = "Whether or not to show the application's icon in the system tray.  \n\nNOTE: The application must be restarted in order for changes to this setting to take effect.";
			public const string ShowNotificationPopups = "Whether or not to show notification popups for events such as when a job is completed or aborted.  \n\nNOTE: 'Show Tray Icon' must be checked in order for this setting to work.";
			public const string PlayNotificationSounds = "Whether or not to play unique sounds for events such as when a job is started, completed, or aborted.";
			public const string AutoDetectStagingDirectory = "Whether or not to automatically detect and fill the 'Staging Directory' field when a file is added to the file list.";
			public const string AutoDetectMungedFiles = "Whether or not to automatically detect and fill the 'Munged Files' field when a file is added to the file list.";
			public const string AutoSaveFileList = "Whether or not to automatically save the file list's contents to file when the application exits.";
			public const string AutoLoadLastSaveFile = "Whether or not to automatically load the most recent save file when the application starts up.";
			public const string LogPollingRate = "The rate (in milliseconds) at which the contents of the output log are updated. A higher value may improve performance.";
			public const string LogMaxLineCount = "The maximum number of lines that the output log can display. A lower value may improve performance. \n\nNOTE: This does not affect the contents of the log file.";
			public const string OutputLogToFile = "Whether or not to write the output log to a file as it is updated.  \n\nNOTE: The entire log file can be monitored in real-time via an external application such as Glogg or Tail if this setting is enabled.";
			public const string LogPrintTimestamps = "Whether or not to prepend timestamps to output log messages.";
			public const string CheckForUpdatesOnStartup = "Whether or not to check for updates on application startup.";
			public const string ShowUpdatePromptOnStartup = "Whether or not to show an update prompt on application startup if an update is available.  \n\nNOTE: 'Check For Updates On Startup' must be checked in order for this setting to work. If an update is available, a relevant message will always be printed to the output log regardless of whether or not this setting is enabled.";
			public const string SetDebuggerPath = "Browse to the Debugger executable you use to debug Battlefront II.";
			public const string PreferredTextEditorPath = "Browse to your preferred text editor (used for viewing logs).";
			public const string PreferredZeroEditorPath = "Browse to your preferred Zero Editor exe";

			public const string DebuggerArgs = "Arguments to be passed to the Debugger executable, like launch mission name.\nExamples:\ncor1c_con \t\t(built-in mission name)\n/win\t\t\t(windowed mode)\n/resolution 1920 1080\t(specify resolution)";
			public const string GameExeArgs = "Arguments to be passed to the Game executable, like launch mission name.\nExamples:\ncor1c_con \t\t(built-in mission name)\n/win\t\t\t(windowed mode)\n/resolution 1920 1080\t(specify resolution)";
			public const string ModToolsDir = "The path to 'BF2_ModTools'";
			public const string ConsoleSupport = "Check/enable your ModTools for Console (XBOX,PS2/PSP) munge";
		}

		public static class AltUIPanel
		{
			public const string CheckShell = 
				"If you're munging 'shell', typically you'll first need to copy the 'BF2_ModTools\\assets\\shell' folder to your 'data_ABC' folder.\n" +
				"(munge.bat /SHELL)";
			public const string CheckLoad = "Munge the loading screen data \n(munge.bat /LOAD)";
			public const string CheckSound = "Sound will me munged when this is checked ( munge.bat /SOUND )";
			public const string CheckMovies = "Movies will me munged when this is checked ( munge.bat /MOVIES )";
			public const string CheckMissions = "If this is checked by itself, you are given the option to only munge mission.lvl (will prompt for creating 'mission only' batch file)";
			public const string CheckCommon = "Munge common stuff [core.lvl, common.lvl, ingame.lvl, mission.lvl] ( munge.bat /COMMON )";
			public const string CheckAddme =  "addme.script will be munged when this is checked ( mungeAddme.bat )";
			public const string CheckCopyIfNewer= "Only copy a file if it is newer than the one already at the deployment location.";
			public const string CheckAutoCopy = "For the PC Munge, automatically copy files after the munge is complete.";
			public const string ButtonCopy = "Copy the files now. For PC, the addme.script will be placed at the root of the addon folder. The LVL files will be placed according to the 'normal' structure.";
			public const string ButtonBrowseOutputFolder= "Browse to a folder that you want your files copied to.";
			public const string GroupMungeFolder= "The target munge folder";
			public const string OverrideDesc = "Run a batch file in the '_BUILD' folder instead of just 'munge' or 'clean'";
			public const string ComboSide=  "Select the specific 'side' to munge.";
			public const string ComboWorld= "Select the specific 'World' to munge.";
			public const string GroupPlatform= "Select the platform to munge";
			public const string CopyLocationTip =
				"Location to copy files to (per platform). Will copy .lvl, .script, .txt and .mvs files.\n" +
				"For PS2 and XBOX the files will be copied to the destination, preserving the file structure of the _LVL_<platform> folder.\n" +
				"For 'PC', the files will be copied according to the PC file pattern.\n" +
				"   'addme.script' will be placed at ...\\GameData\\addon\\<MOD_ID>\\addme.script.\n" +
				"   The rest of the files will be copied to ...\\GameData\\addon\\<MOD_ID>\\data\\_LVL_PC\\\n";
			
		}

		public static class MissionLauncher
		{
			public const string Mission = "The mission name; can be a shipped mission or one added with 'AddDownloadableContent(map,missionName,4)'";
			public const string LaunchDebugger =  "The debugger will launch into the specified mission after you choose your profile.";
			public const string Close =   "Closing this window will clean up the auto launch mission (addme)";
			public const string PPSSPPAutoLaunch = "'auto launch' a mission using PPSSPP and the Alternate addon system for PSP\nGame contents must have been extracted to the file system and 'Alt addon' system must be setup.";
			public const string AutoLaunchFileLocation = "The location of the autolaunch (addon) file.";
		}

		public static class FTPScriptForm
		{
			public const string Browse = "Browse To Local Folder";
			public const string Source = "The source folder on your computer to copy from.";
			public const string Dest = "IP address of the dest.";
			public const string RemoteFolder = "The base folder location on the XBOX to transfer files to";
			public const string GenerateScript = "Generate a batch file (and companion ftp instructions ) to copy the selected files to the destination.";
		}

		public static class HelpMenu
		{
			public const string ViewHelp = "Open the help viewer.";     // TODO: change this wtf are you thinking this dosent' help anyonne
			public const string ViewChangelog = "View the changes for the current and past releases of Zero Munge.";
			public const string ViewLicense = "View the licensing information for Zero Munge.";
			public const string ViewReadme = "View the readme file for Zero Munge.";
			public const string ReportBug = "File a bug report.";
			public const string ProvideSuggestion = "Submit a suggestion.";     // TODO: expand
			public const string ViewOpenIssues = "View a list of bugs that have been reported but are not yet fixed, as well as upcoming features and improvements.";
			public const string OK = "Close this dialog.";
			public const string OpenAbout = "Open the About window to view application information.";
			public const string ApplicationBanner = "Open Zero Munge's project page on GitHub in a new web browser window.";
			public const string CheckForUpdates = "Check to see if a new release of Zero Munge is available.  \n\nNOTE: This requires an Internet connection.";
			public const string Contact = "Send me an e-mail at marth8880@gmail.com  \n\nNOTE: If a default e-mail program isn't set up, this link probably won't do anything.";
			public const string ThirdPartySoftware = "View a list of the third-party software used in Zero Munge.";
		}

		public static class SaveFileListPrompt
		{
			public const string Yes = "Save the file list and quit the application.";
			public const string No = "Quit the application without saving the file list.";
			public const string Cancel = "Close this dialog and return to the application.";
		}

		public static class SetGameDirectoryPrompt
		{
			public const string Yes = "Open a prompt to browse for the game's executable.";
			public const string No = "Close this dialog without setting the game path.";
		}
	}
}
