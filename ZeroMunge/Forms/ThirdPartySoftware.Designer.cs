﻿namespace ZeroMunge
{
	partial class ThirdPartySoftware
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btn_Accept = new System.Windows.Forms.Button();
			this.wb_Licenses = new System.Windows.Forms.WebBrowser();
			this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// btn_Accept
			// 
			this.btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Accept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Accept.Location = new System.Drawing.Point(663, 524);
			this.btn_Accept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btn_Accept.Name = "btn_Accept";
			this.btn_Accept.Size = new System.Drawing.Size(100, 28);
			this.btn_Accept.TabIndex = 4;
			this.btn_Accept.Text = "OK";
			this.btn_Accept.UseVisualStyleBackColor = true;
			this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
			// 
			// wb_Licenses
			// 
			this.wb_Licenses.AllowNavigation = false;
			this.wb_Licenses.AllowWebBrowserDrop = false;
			this.wb_Licenses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.wb_Licenses.IsWebBrowserContextMenuEnabled = false;
			this.wb_Licenses.Location = new System.Drawing.Point(16, 15);
			this.wb_Licenses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.wb_Licenses.MinimumSize = new System.Drawing.Size(27, 25);
			this.wb_Licenses.Name = "wb_Licenses";
			this.wb_Licenses.Size = new System.Drawing.Size(747, 502);
			this.wb_Licenses.TabIndex = 6;
			this.wb_Licenses.WebBrowserShortcutsEnabled = false;
			this.wb_Licenses.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_Licenses_DocumentCompleted);
			// 
			// ThirdPartySoftware
			// 
			this.AcceptButton = this.btn_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Accept;
			this.ClientSize = new System.Drawing.Size(779, 567);
			this.Controls.Add(this.wb_Licenses);
			this.Controls.Add(this.btn_Accept);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(794, 605);
			this.Name = "ThirdPartySoftware";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Third-party licenses";
			this.Load += new System.EventHandler(this.ThirdPartySoftware_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_Accept;
		private System.Windows.Forms.WebBrowser wb_Licenses;
		private System.Windows.Forms.ToolTip FormTooltips;
	}
}