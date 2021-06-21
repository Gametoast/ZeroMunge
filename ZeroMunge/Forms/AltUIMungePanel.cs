using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZeroMunge.Modules;

namespace ZeroMunge
{
    public partial class AltUIMungePanel : UserControl
    {
        
        public AltUIMungePanel()
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
				if( combo_side.Text == "NOTHING" &&
					combo_world.Text == "NOTHING" &&
					check_missions.Checked && 
					!check_common.Checked && 
					!check_sound.Checked &&
					!check_load.Checked && 
					!check_movies.Checked && 
					!check_useOverrideCommand.Checked && 
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
			FormToolTip.SetToolTip(check_shell, Tooltips.AltUIPanel.CheckShell);
			FormToolTip.SetToolTip(check_load, Tooltips.AltUIPanel.CheckLoad);
			FormToolTip.SetToolTip(check_sound, Tooltips.AltUIPanel.CheckSound);
			FormToolTip.SetToolTip(check_movies, Tooltips.AltUIPanel.CheckMovies);
			FormToolTip.SetToolTip(check_missions, Tooltips.AltUIPanel.CheckMissions);
			FormToolTip.SetToolTip(check_common, Tooltips.AltUIPanel.CheckCommon);
			FormToolTip.SetToolTip(check_addme, Tooltips.AltUIPanel.CheckAddme);
			FormToolTip.SetToolTip(check_copyIfNewer, Tooltips.AltUIPanel.CheckCopyIfNewer);
			FormToolTip.SetToolTip(check_autoCopy, Tooltips.AltUIPanel.CheckAutoCopy);
			FormToolTip.SetToolTip(btn_copy, Tooltips.AltUIPanel.ButtonCopy );
			FormToolTip.SetToolTip(btn_browseOutputFolder, Tooltips.AltUIPanel.ButtonBrowseOutputFolder);
			FormToolTip.SetToolTip(group_mungeFolder, Tooltips.AltUIPanel.GroupMungeFolder);
			FormToolTip.SetToolTip(group_overrideCommand, Tooltips.AltUIPanel.OverrideDesc);
			FormToolTip.SetToolTip(check_useOverrideCommand, Tooltips.AltUIPanel.OverrideDesc);
			FormToolTip.SetToolTip(combo_overrideCommand, Tooltips.AltUIPanel.OverrideDesc);
			FormToolTip.SetToolTip(combo_side, Tooltips.AltUIPanel.ComboSide);
			FormToolTip.SetToolTip(combo_world, Tooltips.AltUIPanel.ComboWorld);
			FormToolTip.SetToolTip(group_platform, Tooltips.AltUIPanel.GroupPlatform);
			FormToolTip.SetToolTip(group_copyDest, Tooltips.AltUIPanel.CopyLocationTip);
			FormToolTip.SetToolTip(txt_copyDestFolder, Tooltips.AltUIPanel.CopyLocationTip);
		}

        private void LoadMungeOptions(string dir)
        {
            AddWorldOptions(dir);
            AddSideOptions(dir);
			AddBatchFilesForOverrideCommand(dir);
        }

		private void AddBatchFilesForOverrideCommand(string dir)
		{
			DirectoryInfo build_dir = new DirectoryInfo(dir);
			FileInfo[] batchFiles = build_dir.GetFiles("*.bat", SearchOption.TopDirectoryOnly);
			combo_overrideCommand.Items.Clear();
			foreach(FileInfo info in batchFiles)
			{
				combo_overrideCommand.Items.Add(info.Name);
			}
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
					OnPlatformChanged();
				}
			}
		}

		private void OnPlatformChanged()
		{
			switch (mPlatform)
			{
				case Platform.XBOX:
					btn_xbox.Checked = true;
					break;
				case Platform.PC:
					btn_pc.Checked = true;
					break;
				case Platform.PS2:
					btn_ps2.Checked = true;
					break;
			}
			check_autoCopy.Enabled = (mPlatform == Platform.PC);
			btn_generateFTPScript.Visible = (mPlatform == Platform.XBOX);
			UpdateOutputFolder();
			if (PlatformChanged != null)
				PlatformChanged(this, EventArgs.Empty);
		}

		public bool UseOVerrideCommand
		{
			get { return check_useOverrideCommand.Checked; }
		}
		public string GetOverrideCommand()
		{
			string retVal = "";
			if (check_useOverrideCommand.Checked)
				retVal = combo_overrideCommand.Text;
			return retVal;
		}

        public string GetOptions()
        {
			if (check_useOverrideCommand.Checked)
			{
				string retVal = "";
				string command = combo_overrideCommand.Text.Trim();
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

				if (check_common.Checked || check_missions.Checked)
					binaryOptions += " /COMMON ";

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
			if (Prefs != null)
			{
				switch (this.Platform)
				{
					case Platform.PS2: txt_copyDestFolder.Text = Prefs.PS2CopyFolder; break;
					case Platform.XBOX: txt_copyDestFolder.Text = Prefs.XboxCopyFolder; break;
					case Platform.PC: txt_copyDestFolder.Text = PCOutputFolder; break;
				}
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
			List<FileInfo> filesToCopy = new List<FileInfo>(sourceDir.GetFiles("*.lvl", SearchOption.AllDirectories));
			filesToCopy.AddRange(sourceDir.GetFiles("*.script", SearchOption.AllDirectories));
			filesToCopy.AddRange(sourceDir.GetFiles("*.txt", SearchOption.AllDirectories));
			filesToCopy.AddRange(sourceDir.GetFiles("*.mvs", SearchOption.AllDirectories));
			if (platform == Platform.PC)
			{
				DirectoryInfo addmeDir = new DirectoryInfo(this.MungeDir +"..\\addme\\munged");
				if (addmeDir.Exists)
					filesToCopy.AddRange(addmeDir.GetFiles("addme.script"));
			}

			string copyToDir = Utilities.EnsureTrailingSlash(targetDir);
			if( platform == Platform.PC)
				copyToDir = copyToDir + "data\\_LVL_PC\\";
			
			// copy the files
			string dest = "";
			FileInfo tmp = null;
			int loc = Utilities.EnsureTrailingSlash(sourceDir.FullName).Length;
			int count = 0;
			foreach(FileInfo info in filesToCopy)
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
				string dest = txt_copyDestFolder.Text;
				DirectoryInfo srcInfo = new DirectoryInfo(Utilities.EnsureTrailingSlash(MungeDir) + "..\\_LVL_" + Platform.ToString());
				CopyFiles(srcInfo.FullName, dest, check_copyIfNewer.Checked);
			}
		}

		private void btn_browseOutputFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				txt_copyDestFolder.Text = dlg.SelectedPath;
			}
			dlg.Dispose();
		}

		private void txt_outputFolder_TextChanged(object sender, EventArgs e)
		{
			Platform p = this.Platform;
			if (p == Platform.XBOX)
				Prefs.XboxCopyFolder = txt_copyDestFolder.Text;
			else if (p == Platform.PS2)
				Prefs.PS2CopyFolder = txt_copyDestFolder.Text;
			else if(p == Platform.PC)
				PCOutputFolder = txt_copyDestFolder.Text;

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

		private void btn_generateFTPScript_Click(object sender, EventArgs e)
		{
			FTPScriptForm form = new FTPScriptForm();
			form.ProjectBuildDir = MungeDir;
			form.Prefs = this.Prefs;
			form.SourceFolder = this.txt_copyDestFolder.Text;
			form.Logger = this.Logger;
			form.Show();
		}

		private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string location = txt_mungeFolder.Text;
			if (!Directory.Exists(location))
			{
				MessageBox.Show("Munge folder location doesn't exist. Weird...", "Error");
				return;
			}
			this.Log("Opening Munge Folder...", LogType.Info);
			ProcessManager.RunCommand("explorer.exe", "\"" + location + "\"", null);
		}

		private void openCopyDestInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string location = txt_copyDestFolder.Text;
			if (!Directory.Exists(location))
			{
				MessageBox.Show("Location doesn't exist. ", "Error");
				return;
			}
			this.Log("Opening Copy Dest Folder...", LogType.Info);
			ProcessManager.RunCommand("explorer.exe", "\"" + location + "\"", null);
		}

		private void openInEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string location = Utilities.EnsureTrailingSlash(MungeDir) + combo_overrideCommand.Text;
			if (File.Exists(location))
			{
				this.Log(String.Format("Opening '{0}' ...", location), LogType.Info);
				string editor = Prefs.PreferredTextEditor;
				if (!File.Exists(editor))
					editor = "Notepad.exe";
				ProcessManager.RunCommand(editor, "\"" + location + "\"", null);
			}
			else if (Directory.Exists(location))
			{
				this.Log(String.Format("Opening '{0}' ...", location), LogType.Info);
				ProcessManager.RunCommand("explorer.exe", "\"" + location + "\"", null);
			}
		}
	}
}
