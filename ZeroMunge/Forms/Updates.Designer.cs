namespace ZeroMunge
{
	partial class Updates
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
			this.lbl_Description = new System.Windows.Forms.Label();
			this.btn_Yes = new System.Windows.Forms.Button();
			this.btn_No = new System.Windows.Forms.Button();
			this.cont_Btns = new System.Windows.Forms.Panel();
			this.chk_ShowUpdatePrompt = new System.Windows.Forms.CheckBox();
			this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
			this.cont_Btns.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_Description
			// 
			this.lbl_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_Description.AutoSize = true;
			this.lbl_Description.Location = new System.Drawing.Point(18, 14);
			this.lbl_Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_Description.Name = "lbl_Description";
			this.lbl_Description.Size = new System.Drawing.Size(400, 20);
			this.lbl_Description.TabIndex = 0;
			this.lbl_Description.Text = "An update is available. Do you wish to download it now?";
			// 
			// btn_Yes
			// 
			this.btn_Yes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_Yes.Location = new System.Drawing.Point(0, 0);
			this.btn_Yes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_Yes.Name = "btn_Yes";
			this.btn_Yes.Size = new System.Drawing.Size(112, 35);
			this.btn_Yes.TabIndex = 1;
			this.btn_Yes.Text = "Yes";
			this.btn_Yes.UseVisualStyleBackColor = true;
			this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
			// 
			// btn_No
			// 
			this.btn_No.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_No.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_No.Location = new System.Drawing.Point(123, 0);
			this.btn_No.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_No.Name = "btn_No";
			this.btn_No.Size = new System.Drawing.Size(112, 35);
			this.btn_No.TabIndex = 2;
			this.btn_No.Text = "No";
			this.btn_No.UseVisualStyleBackColor = true;
			this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
			// 
			// cont_Btns
			// 
			this.cont_Btns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cont_Btns.Controls.Add(this.btn_Yes);
			this.cont_Btns.Controls.Add(this.btn_No);
			this.cont_Btns.Location = new System.Drawing.Point(101, 95);
			this.cont_Btns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cont_Btns.Name = "cont_Btns";
			this.cont_Btns.Size = new System.Drawing.Size(235, 35);
			this.cont_Btns.TabIndex = 3;
			// 
			// chk_ShowUpdatePrompt
			// 
			this.chk_ShowUpdatePrompt.AutoSize = true;
			this.chk_ShowUpdatePrompt.Checked = true;
			this.chk_ShowUpdatePrompt.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_ShowUpdatePrompt.Location = new System.Drawing.Point(22, 51);
			this.chk_ShowUpdatePrompt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_ShowUpdatePrompt.Name = "chk_ShowUpdatePrompt";
			this.chk_ShowUpdatePrompt.Size = new System.Drawing.Size(354, 24);
			this.chk_ShowUpdatePrompt.TabIndex = 4;
			this.chk_ShowUpdatePrompt.Text = "Show this prompt when updates are available";
			this.chk_ShowUpdatePrompt.UseVisualStyleBackColor = true;
			this.chk_ShowUpdatePrompt.CheckedChanged += new System.EventHandler(this.chk_ShowUpdatePrompt_CheckedChanged);
			// 
			// Updates
			// 
			this.AcceptButton = this.btn_Yes;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_No;
			this.ClientSize = new System.Drawing.Size(438, 144);
			this.Controls.Add(this.chk_ShowUpdatePrompt);
			this.Controls.Add(this.cont_Btns);
			this.Controls.Add(this.lbl_Description);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(460, 200);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(460, 200);
			this.Name = "Updates";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Updates";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Updates_Load);
			this.cont_Btns.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_Description;
		private System.Windows.Forms.Button btn_Yes;
		private System.Windows.Forms.Button btn_No;
		private System.Windows.Forms.Panel cont_Btns;
		private System.Windows.Forms.CheckBox chk_ShowUpdatePrompt;
		private System.Windows.Forms.ToolTip FormTooltips;
	}
}