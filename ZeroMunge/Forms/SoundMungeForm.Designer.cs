namespace ZeroMunge
{
	partial class SoundMungeForm
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
			this.txt_ProjectDirectory = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_Browse = new System.Windows.Forms.Button();
			this.tv_SoundFolders = new System.Windows.Forms.BetterTreeView();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_Close = new System.Windows.Forms.Button();
			this.btn_Apply = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
			this.btn_Help = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txt_ProjectDirectory
			// 
			this.txt_ProjectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_ProjectDirectory.Location = new System.Drawing.Point(6, 19);
			this.txt_ProjectDirectory.Name = "txt_ProjectDirectory";
			this.txt_ProjectDirectory.Size = new System.Drawing.Size(407, 20);
			this.txt_ProjectDirectory.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btn_Browse);
			this.groupBox1.Controls.Add(this.txt_ProjectDirectory);
			this.groupBox1.Location = new System.Drawing.Point(12, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(500, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Project Directory";
			// 
			// btn_Browse
			// 
			this.btn_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Browse.Location = new System.Drawing.Point(419, 17);
			this.btn_Browse.Name = "btn_Browse";
			this.btn_Browse.Size = new System.Drawing.Size(75, 23);
			this.btn_Browse.TabIndex = 0;
			this.btn_Browse.Text = "Browse...";
			this.btn_Browse.UseVisualStyleBackColor = true;
			this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
			// 
			// tv_SoundFolders
			// 
			this.tv_SoundFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tv_SoundFolders.CheckBoxes = true;
			this.tv_SoundFolders.Location = new System.Drawing.Point(13, 80);
			this.tv_SoundFolders.Name = "tv_SoundFolders";
			this.tv_SoundFolders.Size = new System.Drawing.Size(393, 229);
			this.tv_SoundFolders.TabIndex = 6;
			this.tv_SoundFolders.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_SoundFolders_AfterCheck);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.btn_Apply);
			this.flowLayoutPanel1.Controls.Add(this.btn_Close);
			this.flowLayoutPanel1.Controls.Add(this.btn_Help);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(411, 80);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(102, 230);
			this.flowLayoutPanel1.TabIndex = 3;
			// 
			// btn_Close
			// 
			this.btn_Close.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_Close.Location = new System.Drawing.Point(0, 32);
			this.btn_Close.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(102, 23);
			this.btn_Close.TabIndex = 4;
			this.btn_Close.Text = "Close";
			this.btn_Close.UseVisualStyleBackColor = true;
			// 
			// btn_Apply
			// 
			this.btn_Apply.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_Apply.Location = new System.Drawing.Point(0, 3);
			this.btn_Apply.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.btn_Apply.Name = "btn_Apply";
			this.btn_Apply.Size = new System.Drawing.Size(102, 23);
			this.btn_Apply.TabIndex = 3;
			this.btn_Apply.Text = "Apply";
			this.btn_Apply.UseVisualStyleBackColor = true;
			this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Select Sound Folders:";
			// 
			// btn_Help
			// 
			this.btn_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Help.Location = new System.Drawing.Point(0, 61);
			this.btn_Help.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.btn_Help.Name = "btn_Help";
			this.btn_Help.Size = new System.Drawing.Size(102, 23);
			this.btn_Help.TabIndex = 5;
			this.btn_Help.Text = "Help";
			this.btn_Help.UseVisualStyleBackColor = true;
			this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
			// 
			// SoundMungeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 321);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.tv_SoundFolders);
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(385, 360);
			this.Name = "SoundMungeForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Modify Munged Sound Folders";
			this.Load += new System.EventHandler(this.SoundMungeForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txt_ProjectDirectory;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn_Browse;
		private System.Windows.Forms.BetterTreeView tv_SoundFolders;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		public System.Windows.Forms.Button btn_Close;
		public System.Windows.Forms.Button btn_Apply;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip FormTooltips;
		private System.Windows.Forms.Button btn_Help;
	}
}