namespace ZeroMunge
{
	partial class EasyFilePicker
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_Accept = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_AddProject = new System.Windows.Forms.Button();
			this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
			this.tv_Files = new System.Windows.Forms.BetterTreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_Help = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.btn_Accept);
			this.flowLayoutPanel1.Controls.Add(this.btn_Cancel);
			this.flowLayoutPanel1.Controls.Add(this.btn_Help);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(358, 29);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(102, 192);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// btn_Accept
			// 
			this.btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Accept.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_Accept.Location = new System.Drawing.Point(0, 3);
			this.btn_Accept.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.btn_Accept.Name = "btn_Accept";
			this.btn_Accept.Size = new System.Drawing.Size(102, 23);
			this.btn_Accept.TabIndex = 0;
			this.btn_Accept.Text = "OK";
			this.btn_Accept.UseVisualStyleBackColor = true;
			this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(0, 32);
			this.btn_Cancel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(102, 23);
			this.btn_Cancel.TabIndex = 1;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_AddProject
			// 
			this.btn_AddProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_AddProject.Location = new System.Drawing.Point(9, 323);
			this.btn_AddProject.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.btn_AddProject.Name = "btn_AddProject";
			this.btn_AddProject.Size = new System.Drawing.Size(102, 23);
			this.btn_AddProject.TabIndex = 2;
			this.btn_AddProject.Text = "Add Project...";
			this.btn_AddProject.UseVisualStyleBackColor = true;
			this.btn_AddProject.Click += new System.EventHandler(this.btn_AddProject_Click);
			// 
			// tv_Files
			// 
			this.tv_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tv_Files.CheckBoxes = true;
			this.tv_Files.Location = new System.Drawing.Point(12, 29);
			this.tv_Files.Name = "tv_Files";
			this.tv_Files.Size = new System.Drawing.Size(341, 288);
			this.tv_Files.TabIndex = 3;
			this.tv_Files.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_Files_AfterCheck);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Select which items to add to the file list:";
			// 
			// btn_Help
			// 
			this.btn_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Help.Location = new System.Drawing.Point(0, 61);
			this.btn_Help.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.btn_Help.Name = "btn_Help";
			this.btn_Help.Size = new System.Drawing.Size(102, 23);
			this.btn_Help.TabIndex = 2;
			this.btn_Help.Text = "Help";
			this.btn_Help.UseVisualStyleBackColor = true;
			this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
			// 
			// EasyFilePicker
			// 
			this.AcceptButton = this.btn_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(468, 358);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tv_Files);
			this.Controls.Add(this.btn_AddProject);
			this.Controls.Add(this.flowLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(484, 397);
			this.Name = "EasyFilePicker";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Easy File Picker";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EasyFilePicker_FormClosed);
			this.Load += new System.EventHandler(this.EasyFilePicker_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		public System.Windows.Forms.Button btn_Accept;
		public System.Windows.Forms.Button btn_Cancel;
		public System.Windows.Forms.Button btn_AddProject;
		private System.Windows.Forms.ToolTip FormTooltips;
		private System.Windows.Forms.BetterTreeView tv_Files;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_Help;
	}
}