using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ZeroMunge
{
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

		internal static TreeNode GetNodeByValue(this TreeNodeCollection c, string value)
		{
			foreach (var node in c.OfType<TreeNode>())
			{
				if (node.Text == value)
				{
					return node;
				}
			}

			return null;
		}
	}
}
