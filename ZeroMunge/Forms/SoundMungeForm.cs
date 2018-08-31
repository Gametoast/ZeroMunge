using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ZeroMunge
{
	public partial class SoundMungeForm : Form
	{
		public SoundMungeForm()
		{
			InitializeComponent();
		}

		private void SoundMungeForm_Load(object sender, EventArgs e)
		{
			Prompt_AddProject();
		}

		private void btn_Browse_Click(object sender, EventArgs e)
		{
			Prompt_AddProject();
		}

		// After a node has been checked in the TreeView:
		// Check/uncheck all child nodes.
		private void tv_SoundFolders_AfterCheck(object sender, TreeViewEventArgs e)
		{
			// Did the user cause the checked state to change?
			if (e.Action != TreeViewAction.Unknown)
			{
				if (e.Node.Nodes.Count > 0)
				{
					CheckAllChildNodes(e.Node, e.Node.Checked);
				}
			}
		}

		/// <summary>
		/// Recursively sets the checked state of the specified TreeNode's child nodes.
		/// </summary>
		/// <param name="treeNode">Node to set checked state for all children.</param>
		/// <param name="nodeChecked">True, check node. False, uncheck node.</param>
		private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
		{
			foreach (TreeNode node in treeNode.Nodes)
			{
				node.Checked = nodeChecked;
				if (node.Nodes.Count > 0)
				{
					CheckAllChildNodes(node, nodeChecked);
				}
			}
		}
		
		/// <summary>
		/// Open a prompt to select a project folder to add to the TreeView.
		/// </summary>
		private void Prompt_AddProject()
		{
			CommonOpenFileDialog openDlg_AddProjectPrompt = new CommonOpenFileDialog
			{
				Title = "Select Project Folder",
				DefaultDirectory = "C:\\BF2_ModTools",
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

				string soundDir = new DirectoryInfo(path).FullName + "\\Sound";
				string[] soundFolders = Directory.GetDirectories(soundDir);


				tv_SoundFolders.BeginUpdate();

				foreach (string folder in soundFolders)
				{
					tv_SoundFolders.Nodes.Add(new DirectoryInfo(folder).Name.ToLower());

					if (new DirectoryInfo(folder).Name.ToLower() == "worlds")
					{
						foreach (string childFolder in Directory.GetDirectories(soundDir + "\\worlds"))
						{
							tv_SoundFolders.Nodes.GetNodeByValue("worlds").Nodes.Add(new DirectoryInfo(childFolder).Name.ToLower());
						}
					}
				}

				tv_SoundFolders.EndUpdate();
				tv_SoundFolders.ExpandAll();
				tv_SoundFolders.Nodes[0].EnsureVisible();
			}
		}
	}
}
