using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// NOTE: This file is deprecated and only being kept only for historical purposes (and for the CenterControlLocationX method).

namespace ZeroMunge
{
	public partial class SaveFileListPrompt : Form
	{
		public SaveFileListPrompt()
		{
			InitializeComponent();
		}

		private void SaveFileListPrompt_Load(object sender, EventArgs e)
		{
			SetToolTips();

			// Set warning icon
			img_WarningIcon.Image = SystemIcons.Warning.ToBitmap();

			// Center button container
			flp_Buttons.Location = CenterControlLocationX(flp_Buttons);
		}

		/// <summary>
		/// Sets the form's tooltips.
		/// </summary>
		private void SetToolTips()
		{
			FormTooltips.AutoPopDelay = Properties.Settings.Default.TooltipPopDelay;

			// Save File List Prompt
			FormTooltips.SetToolTip(btn_Yes, Tooltips.SaveFileListPrompt.Yes);
			FormTooltips.SetToolTip(btn_No, Tooltips.SaveFileListPrompt.No);
			FormTooltips.SetToolTip(btn_Cancel, Tooltips.SaveFileListPrompt.Cancel);
		}

		// Returns a Point that positions the specified control in the center of the parent form.
		private Point CenterControlLocationX(Control control)
		{
			int controlWidth = control.Size.Width;
			int formWidth = this.Size.Width;
			int formCenter = formWidth / 2;

			return new Point
			{
				X = formCenter - controlWidth / 2,
				Y = control.Location.Y
			};
		}
	}
}

namespace System.Windows.Forms
{
	// Source: https://stackoverflow.com/a/39592157/3639133
	public class ExRichTextBox : RichTextBox
	{
		public ExRichTextBox()
		{
			Selectable = true;
		}
		const int WM_SETFOCUS = 0x0007;
		const int WM_KILLFOCUS = 0x0008;
		[DefaultValue(true)]
		public bool Selectable { get; set; }
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == WM_SETFOCUS && !Selectable)
				m.Msg = WM_KILLFOCUS;

			base.WndProc(ref m);
		}
	}
}
