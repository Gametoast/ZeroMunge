using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZeroMunge
{
	public partial class SetGameDirectoryPrompt : Form
	{
		private ZeroMunge mainForm = null;
		private bool promptResult = false;

		public SetGameDirectoryPrompt(ZeroMunge owner)
		{
			InitializeComponent();
			mainForm = owner;
		}

		
		// When the SetGameDirectoryPrompt form has finished loading:
		// 
		private void SetGameDirectoryPrompt_Load(object sender, EventArgs e)
		{

		}


		// When the 'Yes' button is clicked:
		// Start the SetGameDirectory flow.
		private void btn_Yes_Click(object sender, EventArgs e)
		{
			promptResult = mainForm.Flow_SetGameDirectory_Start();
			Close();
		}


		// When the 'No' button is clicked:
		// Warn the user that the GameDirectory isn't set.
		private void btn_No_Click(object sender, EventArgs e)
		{
			//mainForm.Flow_SetGameDirectory_WarnQuit();
			Close();
		}

		private void SetGameDirectoryPrompt_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (!promptResult)
			{
				mainForm.Flow_SetGameDirectory_WarnQuit();
			}
		}
	}
}
