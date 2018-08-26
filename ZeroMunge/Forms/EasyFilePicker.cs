using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ZeroMunge
{
	public partial class EasyFilePicker : Form
	{
		public EasyFilePicker()
		{
			InitializeComponent();
		}

		public List<string> addFiles = new List<string>();

		private void EasyFilePicker_Load(object sender, EventArgs e)
		{
			Prompt_AddProject();
		}

		private void btn_Accept_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btn_AddProject_Click(object sender, EventArgs e)
		{
			Prompt_AddProject();
		}

		private void tv_Files_AfterCheck(object sender, TreeViewEventArgs e)
		{
			// TODO: check/uncheck all children (and subchildren etc.)
		}

		private void Prompt_AddProject()
		{
			CommonOpenFileDialog openDlg_AddProjectPrompt = new CommonOpenFileDialog
			{
				Title = "Select Project Folder",
				InitialDirectory = "J:\\BF2_ModTools",
				IsFolderPicker = true,
				RestoreDirectory = true
			};

			// Auto-detect the munge.bat file inside each selected folder and add it to the file list
			if (openDlg_AddProjectPrompt.ShowDialog() == CommonFileDialogResult.Ok)
			{
				string path = openDlg_AddProjectPrompt.FileName;

				// Get the project ID
				string projectID = Utilities.GetProjectID(path);
				string projectRoot = new DirectoryInfo(path).Name;

				tv_Files.BeginUpdate();

				List<string> mungeFiles = Directory.GetFiles(path + "\\_BUILD", "munge.bat", SearchOption.AllDirectories).ToList();
				mungeFiles.Remove(path + "\\_BUILD\\munge.bat");
				mungeFiles.Remove(path + "\\_BUILD\\Sides\\munge.bat");
				mungeFiles.Remove(path + "\\_BUILD\\Worlds\\munge.bat");


				List<string> mungeFileDirs = new List<string>();

				if (File.Exists(path + "\\addme\\mungeAddme.bat"))
				{
					mungeFileDirs.Add(projectRoot + "\\addme");
				}

				int pathStartIndex = path.Length - projectRoot.Length;
				foreach (string file in mungeFiles)
				{
					string pathToAdd = file
						.Substring(pathStartIndex, file.Length - "\\munge.bat".Length - pathStartIndex)
						.Replace("_BUILD\\", "");
					mungeFileDirs.Add(pathToAdd);
				}

				PopulateTreeView(tv_Files, mungeFileDirs, '\\');

				tv_Files.EndUpdate();
				tv_Files.ExpandAll();
			}
		}

		// Adapted from https://stackoverflow.com/a/19332770/3639133
		private void PopulateTreeView(TreeView treeView, List<string> paths, char pathSeparator)
		{
			TreeNode lastNode = null;
			string subPathAgg;
			foreach (string path in paths)
			{
				subPathAgg = string.Empty;
				foreach (string subPath in path.Split(pathSeparator))
				{
					subPathAgg += subPath + pathSeparator;
					TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
					if (nodes.Length == 0)
						if (lastNode == null)
							lastNode = treeView.Nodes.Add(subPathAgg, subPath);
						else
							lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
					else
						lastNode = nodes[0];
				}
				lastNode = null; // This is the place code was changed

			}
		}
	}
}
