using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ZeroMunge
{
	using Modules;
	/// <summary>
	/// Form that helps the user create an FTP script to transfer files to the xbox.
	/// </summary>
	public partial class FTPScriptForm : Form
	{
		
		private System.Windows.Forms.ToolTip FormTooltips = new ToolTip();
		/// <summary>
		/// The '_BUILD' folder of the given project.
		/// </summary>
		public string ProjectBuildDir { get; set; }

		public Logger Logger { get; set; }
		private Prefs mPrefs = null;
		public Prefs Prefs
		{
			get { return mPrefs; }
			set
			{
				mPrefs = value;
				OnPrefsChanged();
			}
		}

		private void OnPrefsChanged()
		{
			LoadFtpAddress();
		}

		public FTPScriptForm()
		{
			InitializeComponent();

			// set toolTips
			FormTooltips.SetToolTip(btn_browseLocal, Tooltips.FTPScriptForm.Browse);
			FormTooltips.SetToolTip(btn_generateCopyScript, Tooltips.FTPScriptForm.GenerateScript);
			FormTooltips.SetToolTip(txt_ipAddress, Tooltips.FTPScriptForm.Dest);
			FormTooltips.SetToolTip(txt_remoteFolder, Tooltips.FTPScriptForm.RemoteFolder);
			FormTooltips.SetToolTip(txt_sourceFolder, Tooltips.FTPScriptForm.Source);
		}


		private Regex ftpReg = new Regex("ftp:\\/\\/([a-zA-Z0-9_.]+):([a-zA-Z0-9_.]+)@([0-9.]+)(/[A-Z]/[A-Za-z 0-9/_-]+)");
		private void LoadFtpAddress()
		{
			if (Prefs != null && Prefs.FTPDest != null)
			{
				Match m = ftpReg.Match(Prefs.FTPDest);
				if (m != Match.Empty)
				{
					txt_userName.Text = m.Groups[1].Value.ToString();
					txt_password.Text = m.Groups[2].Value.ToString();
					txt_ipAddress.Text = m.Groups[3].Value.ToString();
					txt_remoteFolder.Text = m.Groups[4].Value.ToString();
				}
			}
		}
		private void SaveFtpAddress()
		{
			// format is like:
			// ftp://xbox:xbox@192.168.1.158/F/Games/StarWarsBattlefront2_TM1_7/Data/_LVL_XBOX/addon/008
			string ftpAddress = String.Format("ftp://{0}:{1}@{2}{3}",
				txt_userName.Text,  txt_password.Text,
				txt_ipAddress.Text, txt_remoteFolder.Text);

			if (!ftpReg.IsMatch(ftpAddress))
				Log(String.Format("Error saving ftp address: {0}", ftpAddress), LogType.Info);
			else
			{
				if (Prefs != null && Prefs.FTPDest != ftpAddress)
				{
					Prefs.FTPDest = ftpAddress;
					Utilities.SavePrefs(Prefs);
				}
			}
		}

		private void Log(string message, LogType type)
		{
			if(Logger != null)
				Logger.Log(message, type);
		}

		delegate void LogCallback(string message, LogType logType);


		#region event handlers 
		private void tree_fileTree_AfterCheck(object sender, TreeViewEventArgs e)
		{
			TreeNode node = e.Node;
			if (node != null && node.Nodes.Count > 0)
			{
				CheckAllTreeNodes(node.Checked, node.Nodes);
			}
		}

		private void btn_close_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void txt_sourceFolder_TextChanged(object sender, EventArgs e)
		{
			PopulateFromFolder(txt_sourceFolder.Text);
		}

		private void chk_checkAll_CheckedChanged(object sender, EventArgs e)
		{
			CheckAllTreeNodes(chk_checkAll.Checked, tree_fileTree.Nodes);
		}
		private void winSCPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://winscp.net/eng/index.php");
		}

		private void btn_generateCopyScript_Click(object sender, EventArgs e)
		{
			GenerateFtpCopyScript();
		}

		private void btn_browse_Click(object sender, EventArgs e)
		{
			BrowseForSourceFolder();
		}

		private void menu_about_Clicked(object sender, EventArgs e)
		{
			MessageBox.Show(" Generate a script to copy files to my Xbox (ftp).",
				"About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void openLocationInExplorer(object sender, EventArgs e)
		{
			Control target = sender as Control;
			string location = target.Text;
			if (Directory.Exists(location))
			{
				ProcessManager.RunCommand("Explorer.exe", "\"" + location + "\"", location);
			}
			else
				MessageBox.Show("Explorer cannot open: " + location, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		#endregion event handlers 

		private void BrowseForSourceFolder()
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Browse to Folder";
			if (Directory.Exists(txt_sourceFolder.Text))
				dlg.SelectedPath = txt_sourceFolder.Text;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				txt_sourceFolder.Text = dlg.SelectedPath;
			}
			dlg.Dispose();
		}

		//populates the tree view from the given folder
		private void PopulateFromFolder(string folder)
		{
			Regex pattern = new Regex("(.*.lvl|.*.mvs|.*.script|.*.txt)");
			tree_fileTree.Nodes.Clear();
			TreeNode node = null;
			if (!Directory.Exists(folder))
				return;
			DirectoryInfo directoryInfo = new DirectoryInfo(folder);
			foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
			{
				if (subdir.GetFiles("*.*", SearchOption.AllDirectories).Length > 0)
					BuildFileTree(subdir, tree_fileTree.Nodes, pattern);
			}
			foreach (FileInfo file in directoryInfo.GetFiles())
			{
				if (pattern.Match(file.Name).Success)
				{
					node = new TreeNode(file.Name);
					node.Tag = file;
					tree_fileTree.Nodes.Add(node);
				}
			}
			CheckAllTreeNodes(chk_checkAll.Checked, tree_fileTree.Nodes);
			PruneEmptyDirNodes(tree_fileTree.Nodes);
		}

		private void PruneEmptyDirNodes(TreeNodeCollection nodes)
		{
			TreeNode node;
			for(int i = nodes.Count-1; i> -1; i-- )
			{
				node = nodes[i];
				PruneEmptyDirNodes(node.Nodes);
				if (node.Tag is DirectoryInfo && node.Nodes.Count == 0)
					nodes.RemoveAt(i);
			}
		}

		private void BuildFileTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe, Regex pattern)
		{
			TreeNode curNode = addInMe.Add(directoryInfo.Name);
			curNode.ToolTipText = directoryInfo.FullName;
			curNode.Tag = directoryInfo;
			foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
			{
				if (subdir.GetFiles("*.*", SearchOption.AllDirectories).Length > 0)
					BuildFileTree(subdir, curNode.Nodes, pattern);
			}
			TreeNode fileNode = null;
			foreach (FileInfo file in directoryInfo.GetFiles())
			{
				if (pattern.Match(file.Name).Success)
				{
					fileNode = new TreeNode(file.Name);
					fileNode.ToolTipText = file.FullName;
					fileNode.Tag = file;
					curNode.Nodes.Add(fileNode);
				}
			}
		}

		private void GenerateFtpCopyScript()
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.RestoreDirectory = true;
			dlg.Title = "Save Ftp copy File as...";
			dlg.FileName = "xbox_copy_ftp.bat";
			dlg.InitialDirectory = String.IsNullOrEmpty(ProjectBuildDir)? txt_sourceFolder.Text: ProjectBuildDir;
			dlg.Filter = "Batch file|*.bat";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				string ftpFileContants = GenerateFtpCommandsForCurtrentState();
				string ftpCommandFilename = dlg.FileName.Replace(".bat", ".ftp_commands.txt");
				DirectoryInfo srcFolder = new DirectoryInfo(txt_sourceFolder.Text);
				string batchFileContents =
					" REM for the FTP 'lcd' command to work properly, we need to ensure we are on the same drive. \r\n" +
					" pushd .\r\n" +
					string.Format(" cd {0} \r\n", srcFolder.Root.ToString().Replace("\\", "")) +
					string.Format(" cd {0} \r\n", srcFolder.FullName) +
					" cd \r\n"+
					string.Format(" ftp -i -s:\"{0}\"\r\n", ftpCommandFilename) +
					" popd \r\n";
					
				File.WriteAllText(ftpCommandFilename, ftpFileContants);
				File.WriteAllText(dlg.FileName, batchFileContents);
				Log(string.Format("Saved FTP copy script to '{0}'",  ftpCommandFilename), LogType.Info);
				Log(string.Format("Saved FTP copy batch file to '{0}'", dlg.FileName), LogType.Info);
				SaveFtpAddress();	// save ftp address if they actually create a script.
			}
			dlg.Dispose();
		}

		/// <summary>
		/// For the given TreeNodeCollection, set the 'Checked' property to 'isChecked' for all the children, grandchildren ...
		/// </summary>
		private void CheckAllTreeNodes(bool isChecked, TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				node.Checked = isChecked;
				CheckAllTreeNodes(isChecked, node.Nodes);
			}
		}

		private string GenerateFtpCommandsForCurtrentState()
		{
			StringBuilder builder = new StringBuilder();
			string user = txt_userName.Text;
			string psswd = txt_password.Text;
			string ipAddr = txt_ipAddress.Text;
			DirectoryInfo sourceDir = new DirectoryInfo(txt_sourceFolder.Text);
			string destDir = txt_remoteFolder.Text;
			
			builder.Append("\r\n! rem -------------- FTP script generated by ZeroMunge -------------- \r\n");
			builder.Append(
@"! rem 
! rem  ------------- FTP quick usage guide:-----------------
! rem open   --> Connect to a remote ftp server
! rem help   --> print out ftp commands
! rem !      --> pass the rest of the line to terminal 
! rem ? <cmd> --> print out information on an ftp command
! rem pwd    --> print working directory of ftp host
! rem cd     --> change to directory on ftp host 
! rem lcd    --> change to directory on local PC
! rem binary --> Use binary data transfer instead of 'text' data transfer
! rem put  <file1> --> upload the specified file to the server at the ftp host working directory
! rem mput <file1> <file2> --> upload multiple files from the current local directory to the ftp host working directory
! rem get <file> --> Get a single file from the ftp server.
! rem mget <file1> <file2> --> Get a multiple files from the ftp server.
! rem mkdir <dirName> --> Make directory on the remote machine. If it already exists, do nothing.
! rem ");
			builder.Append("\r\n");
			builder.Append(string.Format("open {0}\r\n", ipAddr));
			builder.Append(user + "\r\n");
			builder.Append(psswd + "\r\n");
			builder.Append(string.Format("cd  {0}\r\n", destDir));
			//builder.Append("! REM shell 'cd' to the root of the source dir drive just in case the script is being called from another Drive location.\r\n");
			//builder.Append(string.Format("! cd {0}\r\n", sourceDir.Root.ToString().Replace("\\","")));
			builder.Append(string.Format("lcd {0}\r\n", sourceDir.FullName));
			builder.Append("pwd \r\n");
			builder.Append("binary\r\n");
			foreach (TreeNode node in tree_fileTree.Nodes)
				AddFtpCopyInstructions(node, builder);
			builder.Append("\r\nbye\r\n");
			return builder.ToString();
		}

		private void AddFtpCopyInstructions(TreeNode node, StringBuilder builder)
		{
			if (node.Tag is FileInfo)
			{
				if (node.Checked)
				{
					builder.Append(String.Format("put {0}\r\n", node.Text));
				}
			}
			else if (node.Tag is DirectoryInfo && node.Checked)
			{
				builder.Append(String.Format("! REM ------change to the {0} folder --------------\r\n", node.Text));
				builder.Append("mkdir " + node.Text + "\r\n");
				builder.Append("cd " + node.Text + "\r\n");
				builder.Append("lcd " + node.Text + "\r\n");
				builder.Append("pwd \r\n");
				foreach (TreeNode child in node.Nodes)
				{
					AddFtpCopyInstructions(child, builder);
				}
				builder.Append("lcd .. \r\n");
				builder.Append("cd  .. \r\n");
			}
		}

		private void AddLocalCopyInstructions(String destFolder, TreeNodeCollection nodes, StringBuilder builder)
		{
			FileInfo f_info = null;
			string dest = "";
			string createDir = String.Format("if not exist \"{0}\" ( mkdir \"{0}\" ) \r\n", destFolder);
			if (builder.ToString().IndexOf(createDir) < 0)
				builder.Append(createDir);

			// copy the files
			foreach (TreeNode node in nodes)
			{
				f_info = node.Tag as FileInfo;
				if (node.Checked && f_info != null)
				{
					dest = Utilities.EnsureTrailingSlash(destFolder) + node.Text;
					builder.Append(string.Format("copy /Y \"{0}\" \"{1}\"\r\n", f_info.FullName, dest));
				}
			}
			// process the folders
			foreach (TreeNode node in nodes)
			{
				if (node.Tag is DirectoryInfo && node.Checked)
				{
					dest = Utilities.EnsureTrailingSlash(destFolder) + node.Text;
					AddLocalCopyInstructions(dest, node.Nodes, builder);
				}
			}
		}

		private bool HasFiles(TreeNodeCollection parent)
		{
			foreach(TreeNode node in parent)
			{
				if (node.Tag is FileInfo && node.Checked)
					return true;
			}
			foreach(TreeNode node in parent)
			{
				if (node.Tag is DirectoryInfo)
					return HasFiles(node.Nodes);
			}
			return false;
		}

		private void CopyFilesLocal(string destFolder, TreeNodeCollection nodes)
		{
			FileInfo f_info = null;
			string dest = "";
			if (!Directory.Exists(destFolder))
				Directory.CreateDirectory(destFolder);

			// copy the files
			foreach (TreeNode node in nodes)
			{
				f_info = node.Tag as FileInfo;
				if (node.Checked && f_info != null)
				{
					dest = Utilities.EnsureTrailingSlash(destFolder) + node.Text;
					File.Copy(f_info.FullName, dest, true);
				}
			}
			// process the folders
			DirectoryInfo d_info = null;
			foreach (TreeNode node in nodes)
			{
				d_info = node.Tag as DirectoryInfo;
				if (d_info != null)
				{
					dest = Utilities.EnsureTrailingSlash(destFolder) + node.Text;
					CopyFilesLocal(dest, node.Nodes);
				}
			}
		}

		public String SourceFolder
		{
			get { return txt_sourceFolder.Text; }
			set { txt_sourceFolder.Text = value; }
		}
		
		private delegate void SetTextDelegate(Control ctrl, string text);
		private void SetControlText(Control ctrl, string text)
		{
			if (ctrl.InvokeRequired)
				ctrl.Invoke(new SetTextDelegate(SetControlText), new object[] { ctrl, text });
			else
				ctrl.Text = text;
		}

	}
}
