using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomationTool
{
	public partial class Updates : Form
	{
		public Updates()
		{
			InitializeComponent();
		}

		private void GoToUpdate()
		{
			string url = "https://github.com/marth8880/SWBF2-AutomationTool/releases/tag/r" + AutomationTool.latestAppBuild.ToString();
			Process.Start(url);
		}

		private void btn_Yes_Click(object sender, EventArgs e)
		{
			GoToUpdate();
			Close();
		}

		private void btn_No_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
