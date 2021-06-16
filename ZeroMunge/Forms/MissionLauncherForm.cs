using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZeroMunge.Modules;
using System.Text.RegularExpressions;

namespace ZeroMunge
{
	public partial class MissionLauncherForm : Form
	{
		private System.Windows.Forms.ToolTip FormTooltips = new ToolTip();
		private Prefs prefs = null;
		Logger log_dude = null;
		LaunchPlatform launchPlatform = LaunchPlatform.ModToolsDebugger;

		public MissionLauncherForm(Logger logger)
		{
			InitializeComponent();
			prefs = Utilities.LoadPrefs();
			txt_missionName.AppendText( LastMission);
			log_dude = logger;
			txt_profileName.Text = prefs.ProfileName;

			// set tooltips 
			FormTooltips.SetToolTip(txt_missionName, Tooltips.MissionLauncher.Mission);
			FormTooltips.SetToolTip(btn_launch, Tooltips.MissionLauncher.LaunchDebugger);
			FormTooltips.SetToolTip(btn_modToolsDebugger, Tooltips.MissionLauncher.LaunchDebugger);
			FormTooltips.SetToolTip(btn_close, Tooltips.MissionLauncher.Close);
			FormTooltips.SetToolTip(btn_ppsspp, Tooltips.MissionLauncher.PPSSPPAutoLaunch);
			FormTooltips.SetToolTip(grp_autoLaunchLocation, Tooltips.MissionLauncher.AutoLaunchFileLocation);
			FormTooltips.SetToolTip(txt_autoLaunchFileLocation, Tooltips.MissionLauncher.AutoLaunchFileLocation);

			OnLaunchPlatformChanged();
			txt_missionName.SelectAll();
		}

		LaunchPlatform LaunchPlatform
		{
			get { return launchPlatform; }
			set
			{
				if( launchPlatform != value)
				{
					launchPlatform = value;
					OnLaunchPlatformChanged();
				}
			}
		}

		private void OnLaunchPlatformChanged()
		{
			switch(this.LaunchPlatform)
			{
				case LaunchPlatform.ModToolsDebugger:
					btn_launch.Text = "Launch ModTools debugger";
					txt_autoLaunchFileLocation.Text = GetAutoLaunchFileLocation(LaunchPlatform.ModToolsDebugger);
					FormTooltips.SetToolTip(btn_launch, Tooltips.MissionLauncher.LaunchDebugger);
					break;
				case LaunchPlatform.PPSSPP:
					btn_launch.Text = "Launch in PPSSPP";
					txt_autoLaunchFileLocation.Text = GetAutoLaunchFileLocation(LaunchPlatform.PPSSPP);
					FormTooltips.SetToolTip(btn_launch, Tooltips.MissionLauncher.PPSSPPAutoLaunch);
					break;
			}
		}

		private string PSPAddonFolderRelativePath { get { return "PSP_GAME\\USRDIR\\data\\_lvl_psp\\addon\\"; } }

		private static string LastMission = "nab2c_con"; // nice example for user

		private void Log(string message, LogType type)
		{
			if( log_dude != null)
				log_dude.Log(message, type);
		}

		private void btn_close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn_modToolsDebugger_CheckedChanged(object sender, EventArgs e)
		{
			if (btn_ppsspp.Checked)
			{
				if (AltAddonFolderExists())
					this.LaunchPlatform = LaunchPlatform.PPSSPP;
				else if (File.Exists(Utilities.EnsureTrailingSlash(prefs.PSPGameLocation)))
				{
					MessageBox.Show("Setup the 'Alt Addon' system to use this feature.");
					btn_modToolsDebugger.Checked = true;
				}
				else
				{
					MessageBox.Show("This feature requires that 'PSP Game Folder' to be set (Preferences -> Set Preferences).");
					btn_modToolsDebugger.Checked = true;
				}
			}
			else
				this.LaunchPlatform = LaunchPlatform.ModToolsDebugger;
		}

		private void txt_missionName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				LaunchMission();
			}
		}

		private void btn_launch_Click(object sender, EventArgs e)
		{
			LaunchMission();
		}

		#region overrides 
		protected override void OnClosing(CancelEventArgs e)
		{
			if(txt_profileName.Text != prefs.ProfileName)
			{
				prefs.ProfileName = txt_profileName.Text;
				Utilities.SavePrefs(prefs);
			}
			base.OnClosing(e);
			Cleanup();
		}
		#endregion overrides 

		private bool AltAddonFolderExists()
		{
			bool retVal = false;
			string pspGamePath = Utilities.EnsureTrailingSlash(prefs.PSPGameLocation);
			string altAddonFolder = pspGamePath + "PSP_GAME\\USRDIR\\data\\_lvl_psp\\addon\\";
			if (Directory.Exists(altAddonFolder))
				retVal = true;
			return retVal;
		}

		private void LaunchMission()
		{
			prefs = Utilities.LoadPrefs();
			if (Directory.Exists(prefs.ModToolsLocation) && File.Exists(prefs.DebuggerExe))
			{
				if (SetupMission()  )
				{
					if (LaunchPlatform == LaunchPlatform.PPSSPP) //  Launch PPSSPP here 
					{
						LaunchPPSSPP();
					}
					else
					{
						LaunchDebuggerExe();
					}
				}
			}
			else
			{
				MessageBox.Show("Please set both 'ModTools location' and 'Debugger exe' (in preferences) to use this feature\n", "Warning",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		// PPSSPP: luaFileName = 'addon999.lua', outputFileName= 'addon999.lvl'
		// PC    : luaFileName = 'addme.lua',    outputFileName= 'addme.script'
		private string MungeScript(string contents, string outputPath, string luaFileName, string outputFileName)
		{
			String tempDir = Path.GetTempPath();
			string tmpLuaFile = tempDir + luaFileName;
			File.WriteAllText(tmpLuaFile, contents);
			string tmpLvlName = luaFileName.Replace(".lua", ".lvl");

			Munger dude = new Munger(this.log_dude);
			dude.AddItem(tmpLuaFile);
			bool deleteWorkspace = true;
			string result = dude.CreateLvl(tempDir, tmpLvlName, "PC", deleteWorkspace);
			if (result.StartsWith("Error"))
			{
				return result;
			}
			else
			{
				// success
				string dest = outputPath + outputFileName;
				if (File.Exists(dest))
					File.Delete(dest);
				
				File.Move(result, dest);
				Log("Moved file to: " + dest, LogType.Info);
				File.Delete(tmpLuaFile);
				return dest;
			}
		}


		private bool SetupMission()
		{
			bool retVal = false;
			string missionName = txt_missionName.Text;
			LastMission = missionName;
			string fileContent = autoLaunchLua.Replace("ABCc_con", missionName);
			if( !String.IsNullOrEmpty(txt_profileName.Text))
				fileContent = fileContent.Replace("profileName = nil", 
					String.Format("profileName = '{0}'",txt_profileName.Text));
			else
			{
				if (MessageBox.Show("Launch with default settings?\r\n" +
						"Press 'no' to specify your profile name on 'Launch Mission' dialog ", "Use default profile settings?",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return false;
			}
			if (!String.IsNullOrEmpty(missionName))
			{
				string outputPath = null;
				string luaFilename = null;
				string outputFileName = null;
				if (this.LaunchPlatform == LaunchPlatform.PPSSPP ) // PPSSPP path
				{
					if (AltAddonFolderExists())
					{
						outputPath = Utilities.EnsureTrailingSlash(prefs.PSPGameLocation);
						outputPath += PSPAddonFolderRelativePath + "999\\";
						luaFilename = "addon999.lua";
						outputFileName = "addon999.lvl";
						if (!Directory.Exists(outputPath))
							Directory.CreateDirectory(outputPath);
						fileContent = fileContent.Replace("ifs_sp_campaign", "ifs_main");
					}
					else
					{
						MessageBox.Show("Alternate addon folder for psp game not found!\nPlease set up the alternate addon system for the PSP game",
							"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
						return false;
					}
				}
				else
				{
					luaFilename = "addme.lua";
					outputPath = Utilities.EnsureTrailingSlash(prefs.GameDirectory);
					
					outputPath += "addon\\zz_ZeroMungeAutoLaunch\\";

					if (!Directory.Exists(outputPath))
						Directory.CreateDirectory(outputPath);
					outputFileName = "addme.script";
				}

				string result = MungeScript(fileContent, outputPath, luaFilename, outputFileName);
				if (File.Exists(result))
				{
					retVal = true;
					Log("Auto Launch file saved to " + result, LogType.Info);
				}
				else
				{
					MessageBox.Show("Error creating auto launch addme!\n"+result, "Error", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Mission Name Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return retVal;
		}

		private void LaunchDebuggerExe()
		{
			if (String.IsNullOrEmpty(prefs.GameDirectory))
			{
				MessageBox.Show("Game path not set. Set Game path to use this feature.", "Error");
				return;
			}

			string programName = prefs.DebuggerExe;
			if (File.Exists(programName))
			{
				string msg = "Launching " + programName + " " + prefs.DebuggerArgs;
				Log(msg, LogType.Info);
				ProcessManager.RunCommand("\"" + programName + "\"", prefs.DebuggerArgs, prefs.GameDirectory);
			}
			else
			{
				string msg = String.Format("Could not find '{0}'\r\n", programName);
				Log(msg, LogType.Warning);
				MessageBox.Show(msg, "Warning");
			}
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
				string programArgs = prefs.PSPGameLocation ;
				ProcessManager.RunCommand("\"" + programName + "\"", programArgs, PPSSPPdir);
			}
			else
			{
				string msg = String.Format("Could not find '{0}'\r\n", programName);
				Log(msg, LogType.Warning);
				MessageBox.Show(msg, "Warning");
			}
		}

		private string GetAutoLaunchFileLocation(LaunchPlatform p)
		{
			string retVal = "";
			if( p== LaunchPlatform.PPSSPP)
			{
				retVal = Utilities.EnsureTrailingSlash( prefs.PSPGameLocation);
				retVal += PSPAddonFolderRelativePath + "999\\addon999.lvl";
			}
			else
			{
				retVal = Utilities.EnsureTrailingSlash( prefs.GameDirectory);
				retVal += "addon\\zz_ZeroMungeAutoLaunch\\addme.script";
			}
			return retVal;
		}

		private void Cleanup()
		{
			try
			{
				// cleanup for PC auto-launch addon
				string pcAutoLaunchFileLocation = GetAutoLaunchFileLocation(LaunchPlatform.ModToolsDebugger);
				if (File.Exists(pcAutoLaunchFileLocation))
				{
					File.Delete(pcAutoLaunchFileLocation);
					int lastSlash = pcAutoLaunchFileLocation.LastIndexOf('\\');
					string pcAddonDir = pcAutoLaunchFileLocation.Substring(0, lastSlash);
					Directory.Delete(pcAddonDir);
				}

				// cleanup for PSP auto-launch addon
				string pspAutoLaunchFileLocation = GetAutoLaunchFileLocation(LaunchPlatform.PPSSPP);
				if (File.Exists(pspAutoLaunchFileLocation))
				{
					File.Delete(pspAutoLaunchFileLocation);
					int lastSlash = pspAutoLaunchFileLocation.LastIndexOf('\\');
					string pspAddonDir = pspAutoLaunchFileLocation.Substring(0, lastSlash);
					string[] dirContents = Directory.GetFiles(pspAddonDir);
					if (Directory.Exists(pspAddonDir) && dirContents.Length == 0)
					{
						Log("Deleting auto-launch folder at:" + pspAddonDir, LogType.Info);
						Directory.Delete(pspAddonDir, true);
					}
					else if (dirContents.Length > 0)
					{
						// it is possible that the user actually used folder '999' in a mod; if so, don't delete everything.
						Log(String.Format("Folder '{0}' not empty, not deleting ", pspAddonDir), LogType.Info);
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Error while cleaning up auto launch mission!\nPlease ensure: autolaunch file is deleted!",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		const string autoLaunchLua = @"
print('addon\\zz_ZeroMungeAutoLaunch\\addme.script: Start')
print('auto-launch script Generated by ZeroMunge')

missionName = 'ABCc_con'
profileName = nil

function autoLaunch()
	print('Function: autoLaunch() ' .. 'mission= ' .. missionName)
	ScriptCB_SetMissionNames({{Map = missionName, dnldable = nil, Side = 1, SideChar = nil, Team1 = 'team1', Team2 = 'team2'}}, false)
	ScriptCB_SetTeamNames(0,0)
	ScriptCB_EnterMission()
end


local origScriptCB_PushScreen = ScriptCB_PushScreen

ScriptCB_PushScreen = function(name, ...)
	if (name == 'ifs_legal') then
		if (profileName) then

			ScriptCB_SetConnectType('wan')
			ScriptCB_CancelLogin()

			ifs_saveop.doOp = 'LoadProfile'
			ifs_saveop.OnSuccess = function()
				print('UOP Debug Script: profile loaded')
				autoLaunch()
			end

			ifs_saveop.OnCancel = function() 
				print('ERROR loading profile..')
				autoLaunch()
			end
			
			ifs_saveop.profile1 = ScriptCB_tounicode(profileName)
			ifs_saveop.profile2 = nil
			
			gPrevMixConfig = ScriptCB_GetMixConfig()
			gPrevEffects   = ScriptCB_EffectsEnabled()

			ifs_movietrans_PushScreen(ifs_saveop)
		else
			autoLaunch()
		end
		return
	else 
		return origScriptCB_PushScreen(name, unpack(arg))
	end
end
print('addon\\zz_ZeroMungeAutoLaunch\\addme.script: End')
";


		const string autoLaunchLua_old = @"
-- 
local autoLaunchMission = 'ABCc_con'
print('addon\\zz_ZeroMungeAutoLaunch\\addme.script: Start')
print('Setting Auto Launch mission to: '.. autoLaunchMission)
local origScriptCB_PushScreen = ScriptCB_PushScreen
ScriptCB_PushScreen = function(name)
	if (name == 'ifs_sp_campaign' ) then 
		ScriptCB_SetMissionNames({ { Map = autoLaunchMission, dnldable = nil, Side = 1, SideChar = nil, Team1 = 'team1', Team2 = 'team2'} }, false)
		ScriptCB_SetTeamNames(0, 0)
		ScriptCB_EnterMission()
	end
	return origScriptCB_PushScreen(name)
end
print('addon\\zz_ZeroMungeAutoLaunch\\addme.script: End')
";

		private void aboutMissionLauncherToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
@"Mission Launcher:
Creates: 

   `addon\\zz_ZeroMungeAutoLaunch\\addme.script` (PC)
           or 
   `addon\\999\\addon999.lvl` (PPSSPP)

to setup the specific mission to launch.

If the ZeroMunge program exists abnormally, you may need to manually clean up the file.
Normal closing of this dialog will remove the auto launch file.

Bonus feature:
You can actually launch a specified mission even if it's not selectalbe in the mission select screen.",
			"About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void alternateAddonGitHubToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/BAD-AL/SWBFII_Alt_Addon_System");
		}

	}

	enum LaunchPlatform
	{
		ModToolsDebugger,
		PPSSPP
	}
}
