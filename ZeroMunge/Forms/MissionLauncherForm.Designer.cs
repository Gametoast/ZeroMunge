namespace ZeroMunge
{
	partial class MissionLauncherForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MissionLauncherForm));
			this.label1 = new System.Windows.Forms.Label();
			this.txt_missionName = new System.Windows.Forms.TextBox();
			this.btn_launch = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutMissionLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_close = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mission Name";
			// 
			// txt_missionName
			// 
			this.txt_missionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_missionName.Location = new System.Drawing.Point(12, 68);
			this.txt_missionName.Name = "txt_missionName";
			this.txt_missionName.Size = new System.Drawing.Size(361, 26);
			this.txt_missionName.TabIndex = 1;
			this.txt_missionName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_missionName_KeyDown);
			// 
			// btn_launch
			// 
			this.btn_launch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_launch.Location = new System.Drawing.Point(12, 100);
			this.btn_launch.Name = "btn_launch";
			this.btn_launch.Size = new System.Drawing.Size(361, 33);
			this.btn_launch.TabIndex = 2;
			this.btn_launch.Text = "Launch";
			this.btn_launch.UseVisualStyleBackColor = true;
			this.btn_launch.Click += new System.EventHandler(this.btn_launch_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(385, 36);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMissionLauncherToolStripMenuItem});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 32);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// aboutMissionLauncherToolStripMenuItem
			// 
			this.aboutMissionLauncherToolStripMenuItem.Name = "aboutMissionLauncherToolStripMenuItem";
			this.aboutMissionLauncherToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
			this.aboutMissionLauncherToolStripMenuItem.Text = "About Mission Launcher";
			this.aboutMissionLauncherToolStripMenuItem.Click += new System.EventHandler(this.aboutMissionLauncherToolStripMenuItem_Click);
			// 
			// btn_close
			// 
			this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_close.Location = new System.Drawing.Point(12, 220);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new System.Drawing.Size(361, 42);
			this.btn_close.TabIndex = 4;
			this.btn_close.Text = "Close";
			this.btn_close.UseVisualStyleBackColor = true;
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BackColor = System.Drawing.Color.Azure;
			this.label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(361, 52);
			this.label2.TabIndex = 5;
			this.label2.Text = "Close this Window to clean up Auto launch file";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// MissionLauncherForm
			// 
			this.AcceptButton = this.btn_launch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_close;
			this.ClientSize = new System.Drawing.Size(385, 274);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btn_close);
			this.Controls.Add(this.btn_launch);
			this.Controls.Add(this.txt_missionName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(317, 328);
			this.Name = "MissionLauncherForm";
			this.Text = "Launch Mission";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_missionName;
		private System.Windows.Forms.Button btn_launch;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutMissionLauncherToolStripMenuItem;
		private System.Windows.Forms.Button btn_close;
		private System.Windows.Forms.Label label2;
	}
}