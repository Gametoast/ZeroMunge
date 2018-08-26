using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

		// When the Form is loaded:
		// Open a prompt to select a project folder to add to the TreeView.
		private void EasyFilePicker_Load(object sender, EventArgs e)
		{
			Prompt_AddProject();
		}

		// When the Form is closed:
		// 
		private void EasyFilePicker_FormClosed(object sender, FormClosedEventArgs e)
		{

		}

		// When the 'OK' button is clicked:
		// Add all the checked nodes to the public mungeFilePaths property.
		private void btn_Accept_Click(object sender, EventArgs e)
		{
			try
			{
				// Get all checked nodes
				List<TreeNode> selectedNodes = tv_Files.Nodes.Descendants()
					.Where(n => n.Checked)
					.ToList();

				// Resolve the file path for each node's munge file
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
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (ArgumentNullException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (ArgumentException ex)
			{
				Trace.WriteLine(ex.Message);
			}

			// Close the form
			Close();
		}

		// When the 'Cancel' button is clicked:
		// Close the form.
		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		// When the 'Add Project...' button is clicked:
		// Open a prompt to select a project folder to add to the TreeView.
		private void btn_AddProject_Click(object sender, EventArgs e)
		{
			Prompt_AddProject();
		}

		// After a node has been checked in the TreeView:
		// Check/uncheck all child nodes.
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

		/// <summary>
		/// Open a prompt to select a project folder to add to the TreeView.
		/// </summary>
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
				try
				{
					string path = openDlg_AddProjectPrompt.FileName;
					rootPaths.Add(curRoot, path);

					// Get the project ID
					string projectID = Utilities.GetProjectID(path);
					string projectRoot = new DirectoryInfo(path).Name;

					// Get all the munge files in the project directory
					List<string> mungeFiles = Directory.GetFiles(path + "\\_BUILD", "munge.bat", SearchOption.AllDirectories).ToList();
					mungeFiles.Remove(path + "\\_BUILD\\munge.bat");
					mungeFiles.Remove(path + "\\_BUILD\\Sides\\munge.bat");
					mungeFiles.Remove(path + "\\_BUILD\\Worlds\\munge.bat");


					// Create a list of the munge file directory paths starting at the project folder
					List<string> mungeFileDirs = new List<string>();

					// Addme munge file exists outside of the _BUILD directory
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

					// Populate the TreeView with the munge file directories
					tv_Files.BeginUpdate();

					PopulateTreeView(tv_Files, mungeFileDirs, '\\');

					tv_Files.EndUpdate();
					tv_Files.ExpandAll();

					// Increment the current root index in case the user adds another project
					curRoot++;
				}
				catch (System.Security.SecurityException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (PathTooLongException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (UnauthorizedAccessException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (DirectoryNotFoundException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (IOException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (ArgumentOutOfRangeException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (ArgumentNullException ex)
				{
					Trace.WriteLine(ex.Message);
				}
				catch (ArgumentException ex)
				{
					Trace.WriteLine(ex.Message);
				}
			}
		}

		/// <summary>
		/// Populates a TreeView based on a list of file paths.
		/// 
		/// Adapted from https://stackoverflow.com/a/19332770/3639133
		/// </summary>
		/// <param name="treeView">TreeView control to populate.</param>
		/// <param name="paths">List of paths.</param>
		/// <param name="pathSeparator">Character to split the path.</param>
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
		
		/// <summary>
		/// Gets the root node of the specified TreeNode.
		/// </summary>
		/// <param name="node">TreeNode to get the root node from.</param>
		/// <returns>Root node of the specified TreeNode.</returns>
		private TreeNode GetRootNode(TreeNode node)
		{
			TreeNode parentNode = new TreeNode();

			void CheckNode(TreeNode childNode)
			{
				// Are there more child nodes to go through?
				if (childNode.Level > 1)
					CheckNode(childNode.Parent);
				else
					parentNode = childNode.Parent;
			}

			// Recursively go through the node's child nodes until we reach the root node
			CheckNode(node);

			return parentNode;
		}
	}

	internal static class TreeViewExt
	{
		// Adapted from https://stackoverflow.com/a/26543212/3639133
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
