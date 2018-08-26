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
	public partial class Updates : Form
	{
		public Prefs prefs = new Prefs();

		public Updates()
		{
			InitializeComponent();
		}


		// When the Updates form has finished loading:
		// Load the prefs.
		private void Updates_Load(object sender, EventArgs e)
		{
			SetToolTips();

			prefs = Utilities.LoadPrefs();

			chk_ShowUpdatePrompt.Checked = prefs.ShowUpdatePromptOnStartup;
		}


		/// <summary>
		/// Sets the form's tooltips.
		/// </summary>
		private void SetToolTips()
		{
			FormTooltips.AutoPopDelay = Properties.Settings.Default.TooltipPopDelay;

			// Updates
			FormTooltips.SetToolTip(btn_Yes, Tooltips.Updates.Yes);
			FormTooltips.SetToolTip(btn_No, Tooltips.Updates.No);
			FormTooltips.SetToolTip(chk_ShowUpdatePrompt, Tooltips.Updates.ShowUpdatePrompt);
		}


		/// <summary>
		/// Opens the update's web page in the user's default browser.
		/// </summary>
		private void GoToUpdate()
		{
			int build = ZeroMunge.latestAppVersion.BuildNum;
			if (build == 0)
				return;
			string url = ZeroMunge.latestAppVersion.DownloadUrl;
			Process.Start(url);
		}


		// When the 'Yes' button is clicked:
		// Save prefs, go to the update web page, and close the form.
		private void btn_Yes_Click(object sender, EventArgs e)
		{
			Utilities.SavePrefs(prefs);
			GoToUpdate();
			Close();
		}


		// When the 'No' button is clicked:
		// Save prefs and close the form.
		private void btn_No_Click(object sender, EventArgs e)
		{
			Utilities.SavePrefs(prefs);
			Close();
		}


		// When the ShowUpdatePrompt checkbox has been checked or unchecked:
		// Store the checked state in the associated preference property.
		private void chk_ShowUpdatePrompt_CheckedChanged(object sender, EventArgs e)
		{
			prefs.ShowUpdatePromptOnStartup = chk_ShowUpdatePrompt.Checked;
		}
	}
}
