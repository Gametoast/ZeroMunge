namespace ZeroMunge
{
	partial class SaveFileListPrompt
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
			this.btn_Yes = new System.Windows.Forms.Button();
			this.btn_No = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.flp_Buttons = new System.Windows.Forms.FlowLayoutPanel();
			this.img_WarningIcon = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.ertb_DialogText = new System.Windows.Forms.ExRichTextBox();
			this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
			this.flp_Buttons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.img_WarningIcon)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Yes
			// 
			this.btn_Yes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_Yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btn_Yes.Location = new System.Drawing.Point(4, 0);
			this.btn_Yes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.btn_Yes.Name = "btn_Yes";
			this.btn_Yes.Size = new System.Drawing.Size(100, 28);
			this.btn_Yes.TabIndex = 0;
			this.btn_Yes.Text = "Yes";
			this.btn_Yes.UseVisualStyleBackColor = true;
			// 
			// btn_No
			// 
			this.btn_No.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_No.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btn_No.Location = new System.Drawing.Point(112, 0);
			this.btn_No.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.btn_No.Name = "btn_No";
			this.btn_No.Size = new System.Drawing.Size(100, 28);
			this.btn_No.TabIndex = 1;
			this.btn_No.Text = "No";
			this.btn_No.UseVisualStyleBackColor = true;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(220, 0);
			this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(100, 28);
			this.btn_Cancel.TabIndex = 2;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			// 
			// flp_Buttons
			// 
			this.flp_Buttons.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.flp_Buttons.AutoSize = true;
			this.flp_Buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flp_Buttons.Controls.Add(this.btn_Yes);
			this.flp_Buttons.Controls.Add(this.btn_No);
			this.flp_Buttons.Controls.Add(this.btn_Cancel);
			this.flp_Buttons.Location = new System.Drawing.Point(73, 74);
			this.flp_Buttons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.flp_Buttons.Name = "flp_Buttons";
			this.flp_Buttons.Size = new System.Drawing.Size(324, 28);
			this.flp_Buttons.TabIndex = 6;
			// 
			// img_WarningIcon
			// 
			this.img_WarningIcon.Location = new System.Drawing.Point(4, 4);
			this.img_WarningIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.img_WarningIcon.Name = "img_WarningIcon";
			this.img_WarningIcon.Size = new System.Drawing.Size(32, 32);
			this.img_WarningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.img_WarningIcon.TabIndex = 8;
			this.img_WarningIcon.TabStop = false;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.ertb_DialogText, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.img_WarningIcon, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 15);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 52);
			this.tableLayoutPanel1.TabIndex = 9;
			// 
			// ertb_DialogText
			// 
			this.ertb_DialogText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ertb_DialogText.Cursor = System.Windows.Forms.Cursors.Default;
			this.ertb_DialogText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ertb_DialogText.Location = new System.Drawing.Point(44, 4);
			this.ertb_DialogText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ertb_DialogText.Name = "ertb_DialogText";
			this.ertb_DialogText.ReadOnly = true;
			this.ertb_DialogText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.ertb_DialogText.Selectable = false;
			this.ertb_DialogText.Size = new System.Drawing.Size(392, 44);
			this.ertb_DialogText.TabIndex = 10;
			this.ertb_DialogText.Text = "There are unsaved changes to the file list. Would you like to save before closing" +
    "?";
			// 
			// SaveFileListPrompt
			// 
			this.AcceptButton = this.btn_Yes;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(472, 117);
			this.ControlBox = false;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.flp_Buttons);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveFileListPrompt";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Save File List";
			this.Load += new System.EventHandler(this.SaveFileListPrompt_Load);
			this.flp_Buttons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.img_WarningIcon)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btn_Yes;
		private System.Windows.Forms.Button btn_No;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.FlowLayoutPanel flp_Buttons;
		private System.Windows.Forms.PictureBox img_WarningIcon;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ExRichTextBox ertb_DialogText;
		private System.Windows.Forms.ToolTip FormTooltips;
	}
}