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

		private Dictionary<int, string> rootPaths = new Dictionary<int, string>();
		private int curRoot = 0;
		public List<string> mungeFilePaths = new List<string>();


		private void EasyFilePicker_Load(object sender, EventArgs e)
		{
			Prompt_AddProject();
		}

		private void EasyFilePicker_FormClosed(object sender, FormClosedEventArgs e)
		{

		}

		private void btn_Accept_Click(object sender, EventArgs e)
		{
			List<TreeNode> selectedNodes = tv_Files.Nodes.Descendants()
				.Where(n => n.Checked)
				.ToList();

			foreach (TreeNode node in selectedNodes)
			{
				string nodePath = node.FullPath;
				string buildPath = "\\_BUILD";
				string fileName = "\\munge.bat";
				if (nodePath.EndsWith("addme", StringComparison.CurrentCultureIgnoreCase))
				{
					buildPath = "";
					fileName = "mungeAddme.bat";
				}
				string partialPath = nodePath.Substring(nodePath.IndexOf('\\'), nodePath.Length - nodePath.IndexOf('\\'));
				string filePath = rootPaths[GetRootNode(node).Index] + buildPath + partialPath + fileName;

				// Add the file to the file list if it exists and is not a template munge script
				if (File.Exists(filePath) 
					&& !filePath.EndsWith("\\_BUILD\\munge.bat") 
					&& !filePath.EndsWith("\\_BUILD\\Sides\\munge.bat") 
					&& !filePath.EndsWith("\\_BUILD\\Worlds\\munge.bat"))
				{
					mungeFilePaths.Add(filePath);
				}
			}

			// Close the form
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
			// Check/uncheck child nodes
			TreeNode node = e.Node;
			if (node.Nodes.Count > 0)
			{
				foreach (TreeNode childNode in node.Nodes)
				{
					childNode.Checked = e.Node.Checked;
				}
			}
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
				rootPaths.Add(curRoot, path);
				curRoot++;

				// Get the project ID
				string projectID = Utilities.GetProjectID(path);
				string projectRoot = new DirectoryInfo(path).Name;

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

				tv_Files.BeginUpdate();

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

		private TreeNode GetRootNode(TreeNode node)
		{
			TreeNode parentNode = new TreeNode();

			void CheckNode(TreeNode childNode)
			{
				if (childNode.Level > 1)
				{
					CheckNode(childNode.Parent);
				}
				else if (childNode.Level == 1 || childNode.Level == 0)
				{
					parentNode = childNode.Parent;
				}
			}

			CheckNode(node);

			return parentNode;
		}
	}

	internal static class TreeViewExt
	{
		internal static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
		{
			foreach (var node in c.OfType<TreeNode>())
			{
				yield return node;

				foreach (var child in node.Nodes.Descendants())
				{
					yield return child;
				}
			}
		}
	}
}
