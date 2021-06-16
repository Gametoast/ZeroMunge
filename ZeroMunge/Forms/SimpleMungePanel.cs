using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ZeroMunge
{
    public partial class SimpleMungePanel : UserControl
    {
        
        public SimpleMungePanel()
        {
            InitializeComponent();
            SetToolTips();
			MungeAddme = check_addme.Checked;
			AutoCopy = this.check_autoCopy.Checked;
		}

		public bool MissionOnly
		{
			get
			{ 
				if(check_missions.Checked && 
					!check_localization.Checked && 
					!check_sound.Checked &&
					!check_load.Checked && 
					!check_ingame.Checked && 
					!check_movies.Checked && 
					!check_shell.Checked )
				{
					return true;
				}
				return false;
			}
		}

		private Prefs mPrefs = null; 
		public Prefs Prefs
		{
			get { return mPrefs; }
			set
			{
				if (value != mPrefs)
				{
					mPrefs = value;
					OnPrefsChanged();
				}
			}
		}

		private void OnPrefsChanged()
		{
			UpdateOutputFolder();
		}

		public Logger Logger { get; set; }

		public bool MungeAddme { get; private set; }

        public string PCOutputFolder { get; set; }

		private string mMungeDir = "";
		public string MungeDir
		{
			get { return mMungeDir; }
			set
			{
				mMungeDir = value;
				txt_mungeFolder.Text = value;
			}
		}
        public void SetBuildDir(string dir)
        {
			MungeDir = dir;
            LoadMungeOptions(dir);
            combo_side.SelectedIndex = 1; //'NOTHING'
            combo_world.SelectedIndex = 1;//'NOTHING'
		}

        private void SetToolTips()
        {
			FormToolTip.SetToolTip(check_shell,
				"If you're munging 'shell', typically you'll first need to copy the 'BF2_ModTools\\assets\\shell' folder to your 'data_ABC' folder.\n" +
				"(munge.bat /SHELL)");
			FormToolTip.SetToolTip(check_load, "Munge the loading screen data \n" +
				"(munge.bat /LOAD)");
			FormToolTip.SetToolTip(check_sound, "Sound will me munged when this is checked ( munge.bat /SOUND )");
			FormToolTip.SetToolTip(check_movies, "Movies will me munged when this is checked ( munge.bat /MOVIES )");
			FormToolTip.SetToolTip(check_missions, 
				"If this is checked by itself, you are given the option to only munge mission.lvl (will prompt for creating 'mission only' batch file)"
				);
			FormToolTip.SetToolTip(check_localization, "Munge localization stuff [core.lvl] ( munge.bat /COMMON )");
			FormToolTip.SetToolTip(check_ingame,   "ingame.lvl will be munged when this is checked ( munge.bat /COMMON )");
			FormToolTip.SetToolTip(check_addme,  "addme.script will be munged when this is checked ( mungeAddme.bat )");

			FormToolTip.SetToolTip(check_copyIfNewer, "Only copy a file if it is newer than the one already at the deployment location.");
			FormToolTip.SetToolTip(check_autoCopy, "For the PC Munge, automatically copy files after the munge is complete.");

			FormToolTip.SetToolTip(btn_copy, "Copy the files now. For PC, the addme.script will be placed at the root of the addon folder. The LVL files will be placed according to the 'normal' structure." );
			FormToolTip.SetToolTip(btn_browseOutputFolder, "Browse to a folder that you want your files copied to.");
			FormToolTip.SetToolTip(group_mungeFolder, "The target munge folder");

			string overrideDesc = "Run a special munge or clean command (munge/clean from '_BUILD' folder location.)";
			FormToolTip.SetToolTip(group_overrideCommand, overrideDesc);
			FormToolTip.SetToolTip(check_useOverrideCommand, overrideDesc);
			FormToolTip.SetToolTip(txt_overrideCommand, overrideDesc);

			FormToolTip.SetToolTip(combo_side,  "Select the specific 'side' to munge.");
			FormToolTip.SetToolTip(combo_world, "Select the specific 'World' to munge.");

			FormToolTip.SetToolTip(group_platform, "Select the platform to munge");

		}

        private void LoadMungeOptions(string dir)
        {
            AddWorldOptions(dir);
            AddSideOptions(dir);
        }

        private void AddWorldOptions(string dir)
        {
            combo_world.Items.Clear();
            combo_world.Items.Add("EVERYTHING");
            combo_world.Items.Add("NOTHING");

            DirectoryInfo build_world = new DirectoryInfo(dir+ "\\Worlds");

            if (build_world.Exists)
            {
				DirectoryInfo test = null;
                FileInfo[] worldMunges = build_world.GetFiles("munge.bat", SearchOption.AllDirectories);
                foreach (FileInfo info in worldMunges)
                {
                    if (info.Directory.FullName != build_world.FullName)
                    {
						test = new DirectoryInfo(Utilities.EnsureTrailingSlash(dir) + "..\\Worlds\\" + info.Directory.Name);
						if(test.Exists)
							combo_world.Items.Add(info.Directory.Name);
                    }
                }
            }
        }

        private void AddSideOptions(string dir)
        {
            combo_side.Items.Clear();
            combo_side.Items.Add("EVERYTHING");
            combo_side.Items.Add("NOTHING");

            DirectoryInfo build_side = new DirectoryInfo(dir+"\\Sides");

            if (build_side.Exists)
            {
				DirectoryInfo test = null;
				FileInfo[] sideMunges = build_side.GetFiles("munge.bat", SearchOption.AllDirectories);
                foreach (FileInfo info in sideMunges)
                {
                    if (info.Directory.FullName != build_side.FullName)
                    {
						test = new DirectoryInfo(Utilities.EnsureTrailingSlash(dir) + "..\\Sides\\" + info.Directory.Name);
						if (test.Exists)
							combo_side.Items.Add(info.Directory.Name);
                    }
                }
            }
        }

		private void Log(string msg, LogType type)
		{
			if(this.Logger != null)
			{
				Logger.Log(msg, type);
			}
		}
		public event EventHandler PlatformChanged;

		private Platform mPlatform = Platform.PC;

		public Platform Platform
		{
			get { return mPlatform; }
			set
			{
				if (mPlatform != value)
				{
					mPlatform = value;
					//btn_xbox.Checked = btn_pc.Checked = btn_ps2.Checked = false;
					switch (mPlatform)
					{
						case Platform.XBOX: btn_xbox.Checked = true; break;
						case Platform.PC: btn_pc.Checked = true; break;
						case Platform.PS2: btn_ps2.Checked = true; break;
					}
					if (mPlatform == Platform.PC)
						check_autoCopy.Enabled = true;
					else
						check_autoCopy.Enabled = false;
					UpdateOutputFolder();
					if (PlatformChanged != null)
						PlatformChanged(this, EventArgs.Empty);
				}
			}
		}

		public string GetOverrideCommand()
		{
			string retVal = "";
			if (check_useOverrideCommand.Checked)
				retVal = txt_overrideCommand.Text;
			return retVal;
		}

        public string GetOptions()
        {
			if (check_useOverrideCommand.Checked)
			{
				string retVal = "";
				string command = txt_overrideCommand.Text.Trim();
				int loc = command.IndexOf(" ");
				if (loc > -1)
					retVal = command.Substring(loc);
				return retVal;
			}
			else
			{
				string platformOption = String.Format(" /PLATFORM {0} ", Platform.ToString());
				string worldOption = " /WORLD " + combo_world.SelectedItem.ToString().ToUpper();
				string sideOption = " /SIDE " + combo_side.SelectedItem.ToString().ToUpper();
				string binaryOptions = "";

				if (check_missions.Checked || check_ingame.Checked)
					binaryOptions += " /COMMON ";

				if (check_localization.Checked)
					binaryOptions += " /LOCALIZE ";

				if (check_shell.Checked)
					binaryOptions += " /SHELL ";

				if (check_load.Checked)
					binaryOptions += " /LOAD ";

				if (check_sound.Checked)
					binaryOptions += " /SOUND ";

				if (check_movies.Checked)
					binaryOptions += " /MOVIES ";

				string retVal = platformOption + worldOption + sideOption + binaryOptions;
				return retVal;
			}
        }

        private void platform_CheckChanged(object sender, EventArgs e)
		{
			Platform p = Platform.PC;
			if (btn_xbox.Checked) p = Platform.XBOX;
			else if (btn_ps2.Checked) p = Platform.PS2;
			this.Platform = p;	
			
		}

		private void UpdateOutputFolder()
		{
			switch (this.Platform)
			{
				case Platform.PS2: txt_outputFolder.Text = Prefs.PS2CopyFolder; break;
				case Platform.XBOX: txt_outputFolder.Text = Prefs.XboxCopyFolder; break;
				case Platform.PC: txt_outputFolder.Text = PCOutputFolder; break;
			}
		}

		private void check_addme_CheckedChanged(object sender, EventArgs e)
		{
			MungeAddme = check_addme.Checked;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="lvlDir">Expected to be something like 'C:\BF2_ModTools\data_ABC\_LVL_PC'</param>
		/// <param name="targetDir">Expected to be something like '...\GameData\addon\ABC'</param>
		/// <param name="copyOnlyIfNewer">Only copy the file if it's newer</param>
		public void CopyFiles(string lvlDir, string targetDir, bool copyOnlyIfNewer)
		{
			Platform platform = Platform.PC;
			if (lvlDir.ToLower().Contains("ps2"))
				platform = Platform.PS2;
			else if (lvlDir.ToLower().Contains("xbox"))
				platform = Platform.XBOX;

			DirectoryInfo sourceDir = new DirectoryInfo(lvlDir);
			List<FileInfo> sourceLvls = new List<FileInfo>(sourceDir.GetFiles("*.lvl", SearchOption.AllDirectories));
			sourceLvls.AddRange( sourceDir.GetFiles("*.script", SearchOption.AllDirectories));
			sourceLvls.AddRange(sourceDir.GetFiles("*.txt", SearchOption.AllDirectories));

			string copyToDir = Utilities.EnsureTrailingSlash(targetDir);
			if( platform == Platform.PC)
				copyToDir = copyToDir + "data\\_LVL_PC\\";
			
			// copy the files
			string dest = "";
			FileInfo tmp = null;
			int loc = Utilities.EnsureTrailingSlash(sourceDir.FullName).Length;
			int count = 0;
			foreach(FileInfo info in sourceLvls)
			{
				if (platform == Platform.PC && info.Name.Equals("addme.script", StringComparison.OrdinalIgnoreCase))
					dest = Utilities.EnsureTrailingSlash(targetDir) + "addme.script";
				else 
					dest = copyToDir + info.FullName.Substring(loc);
				tmp = new FileInfo(dest);
				if (tmp.Exists && copyOnlyIfNewer)
				{
					if (tmp.LastWriteTime < info.LastWriteTime)
					{
						Log(String.Format("writing file '{0}'",tmp.FullName), LogType.Info);
						info.CopyTo(tmp.FullName, true);
						count++;
					}
					//else Log(String.Format("Skipping file '{0}'", info.FullName.Substring(loc)), LogType.Info);
				}
				else
				{
					if (!tmp.Directory.Exists)
					{
						Log(String.Format("Creating folder: '{0}'", tmp.Directory.FullName), LogType.Info);
						tmp.Directory.Create();
					}
					Log(String.Format("writing file '{0}'", tmp.FullName), LogType.Info);
					info.CopyTo(tmp.FullName, true);
					count++;
				}
			}
			Log(String.Format("Copied {0} files", count), LogType.Info);
		}

		private void btn_copy_Click(object sender, EventArgs e)
		{
			CopyFiles();
		}
		private delegate void NoArgumentDelegate();
		
		public void CopyFiles()
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new NoArgumentDelegate(CopyFiles));
			}
			else
			{
				// we'll need to be careful about copying the files of different platforms.
				string dest = txt_outputFolder.Text;
				DirectoryInfo srcInfo = new DirectoryInfo(Utilities.EnsureTrailingSlash(MungeDir) + "..\\_LVL_" + Platform.ToString());
				CopyFiles(srcInfo.FullName, dest, check_copyIfNewer.Checked);
			}
		}

		private void btn_browseOutputFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				txt_outputFolder.Text = dlg.SelectedPath;
			}
			dlg.Dispose();
		}

		private void txt_outputFolder_TextChanged(object sender, EventArgs e)
		{
			Platform p = this.Platform;
			if (p == Platform.XBOX)
				Prefs.XboxCopyFolder = txt_outputFolder.Text;
			else if (p == Platform.PS2)
				Prefs.PS2CopyFolder = txt_outputFolder.Text;
			else if(p == Platform.PC)
				PCOutputFolder = txt_outputFolder.Text;

			if (p == Platform.PS2 || p == Platform.XBOX)
				Utilities.SavePrefs(Prefs);
		}

		private void check_useOverrideCommand_CheckedChanged(object sender, EventArgs e)
		{
			UpdateState();
		}

		private void UpdateState()
		{
			grp_options.Enabled = grp_world.Enabled = grp_side.Enabled = !check_useOverrideCommand.Checked;
		}

		public bool AutoCopy { get; private set; }
		private void check_autoCopy_CheckedChanged(object sender, EventArgs e)
		{
			AutoCopy = this.check_autoCopy.Checked;
		}

	}
}
