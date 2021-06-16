using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using FluentFTP; // https://github.com/robinrodricks/FluentFTP
using System.Net;
using System.Threading;

namespace ZeroMunge
{
	using Modules;

	public partial class FileCopyForm : Form
	{
		private System.Windows.Forms.ToolTip FormTooltips = new ToolTip();
		private string ProjectBuildDir = "";

		public FileCopyForm()
		{
			InitializeComponent();

			// set toolTips
			FormTooltips.SetToolTip(btn_browseLocal, Tooltips.FileCopyForm.Browse);
			FormTooltips.SetToolTip(btn_copy, Tooltips.FileCopyForm.Copy);
			FormTooltips.SetToolTip(btn_generateCopyScript, Tooltips.FileCopyForm.GenerateScript);
			FormTooltips.SetToolTip(btn_listFiles, Tooltips.FileCopyForm.ListRemote);
			FormTooltips.SetToolTip(btn_clear, Tooltips.FileCopyForm.Clear);
			FormTooltips.SetToolTip(combo_dest, Tooltips.FileCopyForm.Dest);
			FormTooltips.SetToolTip(combo_source, Tooltips.FileCopyForm.Source);
			FormTooltips.SetToolTip(list_copyScripts, Tooltips.FileCopyForm.CopyScripts);
			LoadPrefs();
		}

		private void PopulateCopyScriptsListbox()
		{
			list_copyScripts.Items.Clear();
			string tmp;
			List<string> items = new List<string>();
			for(int i = 0; i < combo_source.Items.Count; i++)
			{
				tmp = Utilities.EnsureTrailingSlash(combo_source.Items[i].ToString()) + "_BUILD";
				if (Directory.Exists(tmp) && !items.Contains(tmp))
					items.Add(tmp);
				if (String.IsNullOrEmpty(ProjectBuildDir) && Directory.Exists(tmp))
					ProjectBuildDir = tmp;
			}
			FileInfo[] files;
			DirectoryInfo info;
			foreach(string item in items)
			{
				info = new DirectoryInfo(item);
				files = info.GetFiles("*copy*.bat");
				foreach(FileInfo fileInfo in files)
				{
					list_copyScripts.Items.Add(fileInfo);
				}
			}
		}

		private void LoadPrefs()
		{
			Prefs prefs = Utilities.LoadPrefs();
			string[] dests = prefs.FileCopyFormDests.Split(new char[] { ';' });
			foreach(string dest in dests)
			{
				if (!combo_dest.Items.Contains(dest))
					combo_dest.Items.Add(dest);
			}
			// it's a better user expierence if we load up stuff only from the 'current' project
			// in the 'source' combo box
			//string[] sources = prefs.FileCopyFormSources.Split(new char[] { ';' });
			//foreach (string source in sources)
			//{
			//	if (!combo_source.Items.Contains(source))
			//		combo_source.Items.Add(source);
			//}
		}

		private void SavePrefs()
		{
			StringBuilder dests = new StringBuilder();
			StringBuilder sources = new StringBuilder();
			if (!combo_dest.Items.Contains(combo_dest.Text))
				combo_dest.Items.Add(combo_dest.Text);
			if (!combo_source.Items.Contains(combo_source.Text))
				combo_source.Items.Add(combo_source.Text);
			string current;
			for (int i = 0; i< combo_dest.Items.Count; i++)
			{
				current = combo_dest.Items[i].ToString().Trim();
				if (current.Length > 0)
				{
					dests.Append(current);
					dests.Append(";");
				}
			}
			
			for (int i = 0; i < combo_source.Items.Count; i++)
			{
				current = combo_source.Items[i].ToString().Trim();
				if (current.Length > 0)
				{
					sources.Append(current);
					sources.Append(";");
				}
			}
			Prefs prefs = Utilities.LoadPrefs();
			prefs.FileCopyFormDests = dests.ToString();
			prefs.FileCopyFormSources = sources.ToString();
			Utilities.SavePrefs(prefs);
		}

		protected override void OnLoad(EventArgs e)
		{
			PopulateCopyScriptsListbox();
			base.OnLoad(e);
		}
		protected override void OnClosing(CancelEventArgs e)
		{
			SavePrefs();
			base.OnClosing(e);
		}

		internal void ClearLog()
		{
			txt_output.Clear();
		}

		delegate void LogCallback(string message, LogType logType);

		internal void Log(string msg, LogType type)
		{
			if (txt_output.InvokeRequired)
			{
				LogCallback cb = new LogCallback(Log);
				BeginInvoke(cb, new object[] { msg, type });
			}
			else
			{
				txt_output.AppendText(string.Format("[{0}] {1}\r\n", type.ToString(), msg));
			}
		}

		#region event handlers 
		private void tree_fileTree_AfterCheck(object sender, TreeViewEventArgs e)
		{
			TreeNode node = e.Node;
			if (node != null && node.Nodes.Count > 0)
			{
				CheckAllTreeNodes(node.Checked, node.Nodes);
			}
		}

		private void combo_source_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				PopulateFromFolder(combo_source.Text);
			}
		}

		private void menu_removeSelectedDest_Click(object sender, EventArgs e)
		{
			int index = combo_dest.SelectedIndex;
			if (index > -1)
				combo_dest.Items.RemoveAt(index);
		}

		private void menu_removeSelectedSource_Click(object sender, EventArgs e)
		{
			int index = combo_source.SelectedIndex;
			if (index > -1)
				combo_source.Items.RemoveAt(index);
		}

		private void btn_copy_Click(object sender, EventArgs e)
		{
			CopyFiles();
		}
		private void chk_checkAll_CheckedChanged(object sender, EventArgs e)
		{
			CheckAllTreeNodes(chk_checkAll.Checked, tree_fileTree.Nodes);
		}
		private void winSCPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://winscp.net/eng/index.php");
		}
		private void combo_dest_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ListFiles();
			}
		}
		private void btn_listFiles_Click(object sender, EventArgs e)
		{
			ListFiles();
		}

		private void btn_clear_Click(object sender, EventArgs e)
		{
			ClearLog();
		}

		private void btn_generateCopyScript_Click(object sender, EventArgs e)
		{
			if (combo_dest.Text.StartsWith("ftp:", StringComparison.OrdinalIgnoreCase))
				GenerateFtpCopyScript();
			else
				GenerateLocalCopyScript();
		}

		private void btn_browse_Click(object sender, EventArgs e)
		{
			BrowseSource();
		}

		private void combo_source_SelectedIndexChanged(object sender, EventArgs e)
		{
			string source = combo_source.Text;
			PopulateFromFolder(source);
		}

		#endregion event handlers 
		private void BrowseSource()
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Browse to Folder";
			if (Directory.Exists(combo_source.Text))
				dlg.SelectedPath = combo_source.Text;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				combo_source.Text = dlg.SelectedPath;
			}
			dlg.Dispose();
		}

		private void PopulateFromFolder(string folder)
		{
			Regex pattern = new Regex("(.*.lvl|.*.mvs|.*.script)");
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
			dlg.InitialDirectory = String.IsNullOrEmpty(ProjectBuildDir)? combo_source.Text: ProjectBuildDir;
			dlg.Filter = "Batch file|*.bat";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				string ftpFileContants = GenerateFtpCommandsForCurtrentState();
				string ftpCommandFilename = dlg.FileName.Replace(".bat", ".ftp_commands.txt");
				string batchFileContents = String.Format(" ftp -i -s:\"{0}\"", ftpCommandFilename);
				File.WriteAllText(ftpCommandFilename, ftpFileContants);
				File.WriteAllText(dlg.FileName, batchFileContents);
				Log(string.Format("Saved FTP copy script to '{0}'",dlg.FileName), LogType.Info);
				PopulateCopyScriptsListbox();
			}
			dlg.Dispose();
		}

		private void GenerateLocalCopyScript()
		{
			if (combo_dest.Text.Length > 0)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.RestoreDirectory = true;
				dlg.Title = "Save copy script as...";
				dlg.FileName = "copy_mod.bat";
				dlg.InitialDirectory = String.IsNullOrEmpty(ProjectBuildDir) ? combo_source.Text : ProjectBuildDir;
				dlg.Filter = "Batch file|*.bat";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					string batchFileContents = GenerateLocalCopyCommandsForCurtrentState();
					File.WriteAllText(dlg.FileName, batchFileContents);
					Log(string.Format("Saved copy script to '{0}'", dlg.FileName), LogType.Info);
				}
				dlg.Dispose();
				PopulateCopyScriptsListbox();
			}
			else
			{
				MessageBox.Show("Dest is empty","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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
			Match m = ftpReg.Match(combo_dest.Text);
			if (m.Success)
			{
				string user = m.Groups[1].ToString();
				string psswd = m.Groups[2].ToString();
				string ipAddr = m.Groups[3].ToString();
				string sourceDir = combo_source.Text;
				string destDir = combo_dest.Text.Substring(m.Length);

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
! rem "			);
				builder.Append("\r\n");
				builder.Append(string.Format("open {0}\r\n", ipAddr));
				builder.Append(user + "\r\n");
				builder.Append(psswd + "\r\n");
				builder.Append(string.Format("cd  {0}\r\n", destDir));
				builder.Append(string.Format("lcd {0}\r\n", sourceDir));
				builder.Append("pwd \r\n");
				builder.Append("binary\r\n");
				foreach (TreeNode node in tree_fileTree.Nodes)
					AddFtpCopyInstructions(node, builder);
				builder.Append("\r\nbye\r\n");
			}
			return builder.ToString();
		}

		private string GenerateLocalCopyCommandsForCurtrentState()
		{
			StringBuilder builder = new StringBuilder();
			Match m = ftpReg.Match(combo_dest.Text);
			if (!m.Success)
			{
				string sourceDir = combo_source.Text;
				string destDir = combo_dest.Text.Substring(m.Length);
				builder.Append("\r\n");
				builder.Append("echo -------------- Copy script generated by ZeroMunge -------------- \r\n");
				AddLocalCopyInstructions(combo_dest.Text, tree_fileTree.Nodes, builder);
				builder.Append("echo -------------- done copying files ------------------------------ \r\n");
				builder.Append("REM  uncomment the line below to check output \r\n");
				builder.Append("REM  set /p UserInput=press enter to continue... \r\n");
			}
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

		/// <summary>
		/// Perform a copy operation from source folder to dest folder (can be FTP or local).
		/// </summary>
		private void CopyFiles()
		{
			string source = combo_source.Text;
			string dest = combo_dest.Text;
			if (dest.StartsWith("ftp", StringComparison.OrdinalIgnoreCase))
				CopyFilesFtp(dest);
			else
				CopyFilesLocal(dest, tree_fileTree.Nodes);
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

		private Regex ftpReg = new Regex("ftp:\\/\\/([a-zA-Z0-9_.]+):([a-zA-Z0-9_.]+)@([0-9.]+)");

		
		public ComboBox.ObjectCollection SourceFolders
		{
			get { return combo_source.Items; }
		}

		private void CopyFilesFtp(string dest)
		{
			//ftp://xbox:xbox@192.168.1.158/F/Games/StarWarsBattlefront2_TM1_7/Data/_LVL_XBOX/addon/007
			Match m = ftpReg.Match(dest);
			if (!m.Success)
			{
				MessageBox.Show("Error! Invalid FTP url. Check FTP url and try again.\n" +
					"FTP address should look something like:\n" +
					" 'ftp://xbox:xbox@192.168.1.122/F/Games/StarWarsBattlefront2/Data/_LVL_XBOX/addon/777'\r\n",
					"FTP address error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string user = m.Groups[1].ToString();
			string psswd = m.Groups[2].ToString();
			string ipAddr = m.Groups[3].ToString();
			string destDir = dest.Substring(m.Length);

			FtpClient client = null; //https://github.com/robinrodricks/FluentFTP
			try
			{
				client = new FtpClient(ipAddr);
				client.ConnectTimeout = (int)spin_timeout.Value * 1000;
				client.Credentials = new NetworkCredential(user, psswd);
				Log("Connecting to:" + ipAddr, LogType.Info);
				DateTime start = DateTime.Now;
				client.Connect();
				Log("Connected", LogType.Info);

				UploadFiles(client, destDir, tree_fileTree.Nodes);
				Log("Done Uploading Files", LogType.Info);
				DateTime end = DateTime.Now;
				Log(String.Format("Total upload time: {0} seconds", (end - start).TotalSeconds), LogType.Info);
			}
			catch (Exception e)
			{
				Log(e.Message, LogType.Error);
				MessageBox.Show(e.Message + e.GetType(),
						"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				if (client != null)
				{
					client.Dispose();
				}
			}
		}

		private void UploadFiles(FtpClient client, string destDir, TreeNodeCollection nodes)
		{
			client.CreateDirectory(destDir);
			client.SetWorkingDirectory(destDir);
			FileInfo f_info = null;
			foreach (TreeNode node in nodes)
			{
				f_info = node.Tag as FileInfo;
				if (node.Checked && f_info != null)
				{
					Log(String.Format("transferring '{0}/{1}'", destDir, f_info.Name), LogType.Info);
					client.UploadFile(f_info.FullName, f_info.Name);
				}
			}
			f_info = null;

			DirectoryInfo d_info = null;
			string path = "";
			foreach (TreeNode node in nodes)
			{
				d_info = node.Tag as DirectoryInfo;
				if (d_info != null)
				{
					path = destDir;
					if (!path.EndsWith("/")) path += "/";
					path += d_info.Name;
					UploadFiles(client, path, node.Nodes);
				}
			}
		}

		private void ListLocalFilesAtDest()
		{
			string destFolder = combo_dest.Text;
			if(!Directory.Exists(destFolder))
			{
				Log(String.Format("Folder '{0}' does not exist!", destFolder), LogType.Error);
				return;
			}
			StringBuilder builder = new StringBuilder();
			builder.Append(String.Format("\r\nListing of {0}\r\n",	destFolder));
			DirectoryInfo info = new DirectoryInfo(destFolder);
			foreach (DirectoryInfo d_info in info.GetDirectories())
			{
				builder.Append(string.Format("[{0}]\r\n", d_info.Name));
			}
			foreach (FileInfo f_info in info.GetFiles())
			{
				builder.Append(string.Format("{0}\r\n",f_info.Name));
			}
			Log(builder.ToString(), LogType.Info);
		}

		private void ListRemoteFiles()
		{
			string dest = combo_dest.Text;
			//ftp://xbox:xbox@192.168.1.158/F/Games/StarWarsBattlefront2_TM1_7/Data/_LVL_XBOX/addon/007
			Match m = ftpReg.Match(dest);
			if (!m.Success)
			{
				MessageBox.Show("Error! Invalid FTP url. Check FTP url and try again.\n" +
					"FTP address should look something like:\n" +
					" 'ftp://xbox:xbox@192.168.1.122/F/Games/StarWarsBattlefront2/Data/_LVL_XBOX/addon/777'\r\n",
					"FTP address error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string user = m.Groups[1].ToString();
			string psswd = m.Groups[2].ToString();
			string ipAddr = m.Groups[3].ToString();
			string destDir = dest.Substring(m.Length);
			FtpClient client = null;

			try
			{
				client = new FtpClient(ipAddr);
				client.Credentials = new NetworkCredential(user, psswd);
				client.ConnectTimeout = (int)spin_timeout.Value * 1000;
				Log("Connecting to:" + ipAddr, LogType.Info);

				client.Connect();
				Log("CConnected to:" + ipAddr, LogType.Info);
				client.SetWorkingDirectory(destDir);
				StringBuilder builder = new StringBuilder();
				string files = "";
				foreach (FtpListItem item in client.GetListing())
				{
					if (item.Type == FtpFileSystemObjectType.File)
						files = files + item.Name + "\r\n";
					else
						builder.Append(string.Format("[{0}]\r\n", item.Name));
				}
				builder.Append(files);
				Log(string.Format("Listing of '{0}':\r\n{1}", destDir, builder.ToString()), LogType.Info);
			}
			catch (Exception e)
			{
				Log(e.Message, LogType.Error);
				MessageBox.Show(e.Message,
						"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				if (client != null)
				{
					client.Dispose();
				}
			}
		}

		private void ListFiles()
		{
			if (combo_dest.Text.StartsWith("ftp:", StringComparison.OrdinalIgnoreCase))
				ListRemoteFiles();
			else
				ListLocalFilesAtDest();
		}


		private delegate void SetTextDelegate(Control ctrl, string text);
		private void SetControlText(Control ctrl, string text)
		{
			if (ctrl.InvokeRequired)
				ctrl.Invoke(new SetTextDelegate(SetControlText), new object[] { ctrl, text });
			else
				ctrl.Text = text;
		}

		private void menu_about_Clicked(object sender, EventArgs e)
		{
			MessageBox.Show(
@"This is intended to be a useful copy file dialog. The intended purpose is to assist a BattleFront II Console Modder with common file copy tasks.
Such as:

    1. Quickly copy my files to my Xbox (ftp).
    2. Generate a script to copy files to my Xbox (ftp).
    3. Quickly copy my files to my PSP/PS2/XBox 360 mod game folder.
    4. Generate A script to copy my files to my PSP/PS2/XBox 360 mod game folder.
    5. Quickly run copy scripts (stored in project '_BUILD' directory).

It is not intended to be a full-featured FTP client program or full-featured Windows Explorer.
For a full Featured FTP client program use 'WinSCP'. 
", "About", MessageBoxButtons.OK, MessageBoxIcon.Information
			);
		}

		private void list_copyScripts_DoubleClick(object sender, EventArgs e)
		{
			FileInfo batchFile = list_copyScripts.SelectedItem as FileInfo;
			if( batchFile != null )
			{
				Log("Running "+ batchFile.Name, LogType.Info);
				ProcessManager.RunCommand(batchFile.FullName, "", batchFile.Directory.FullName);
			}
		}

		private void menu_viewSelectedFile_Click(object sender, EventArgs e)
		{
			FileInfo batchFile = list_copyScripts.SelectedItem as FileInfo;
			if (batchFile != null)
			{
				String program = Utilities.LoadPrefs().PreferredTextEditor;
				if (String.IsNullOrEmpty(program))
					program = "Notepad.exe";
				Log("opening " + batchFile.Name, LogType.Info);
				ProcessManager.RunCommand(program, "\""+batchFile.FullName+"\"", batchFile.Directory.FullName);
			}
		}


		private void menu_deleteSelectedBatchFile_Click(object sender, EventArgs e)
		{
			FileInfo batchFile = list_copyScripts.SelectedItem as FileInfo;
			if (batchFile != null)
			{
				if (MessageBox.Show("Delete file: '" + batchFile.Name + "' ?", "Delete file?", 
					MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
				{
					Log("Deleting " + batchFile.Name, LogType.Info);
					File.Delete(batchFile.FullName);
					PopulateCopyScriptsListbox();
				}
			}
		}

		private void openComboTextInExplorer(object sender, EventArgs e)
		{
			ComboBox target = sender as ComboBox;
			string location = target.Text;
			if (Directory.Exists(location))
			{
				Log("Opening folder " + location, LogType.Info);
				ProcessManager.RunCommand("Explorer.exe", "\"" + location + "\"", location);
			}
			else
				MessageBox.Show("Explorer cannot open: " + location, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void menu_listFilesToCopy_Click(object sender, EventArgs e)
		{
			Regex interestionFileRegex = new Regex("([a-zA-Z0-9_]+\\.lvl|[a-zA-Z0-9_]+\\.script)");
			Regex ftpFileRegex = new Regex("([a-zA-Z0-9_\\.]+ftp_commands\\.txt)");
			// list the files that will be copied in the script
			// for ftp, look through the companion ftp copy file
			String output = "";
			FileInfo info = list_copyScripts.SelectedItem as FileInfo;
			if(info != null)
			{
				String contents = File.ReadAllText(info.FullName);
				if(ftpFileRegex.IsMatch(contents))
				{
					Match match = ftpFileRegex.Match(contents);
					string fileName = Utilities.EnsureTrailingSlash( info.DirectoryName) + match.ToString();
					if (File.Exists(fileName))
						contents = File.ReadAllText(fileName);
				}
				MatchCollection mc = interestionFileRegex.Matches(contents);
				string current = "";
				foreach(Match m in mc)
				{
					current = m.Groups[1].ToString();
					if( output.IndexOf(current) == -1)
						output += (current +"\r\n");
				}
				Log("================================\r\n" + output +
					"================================", LogType.Info);
			}

		}
	}
}
