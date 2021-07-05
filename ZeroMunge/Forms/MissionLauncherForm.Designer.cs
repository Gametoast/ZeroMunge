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
			this.alternateAddonGitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutMissionLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_close = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.grp_platform = new System.Windows.Forms.GroupBox();
			this.btn_ppsspp = new System.Windows.Forms.RadioButton();
			this.btn_modToolsDebugger = new System.Windows.Forms.RadioButton();
			this.grp_autoLaunchLocation = new System.Windows.Forms.GroupBox();
			this.txt_autoLaunchFileLocation = new System.Windows.Forms.TextBox();
			this.txt_profileName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.grp_platform.SuspendLayout();
			this.grp_autoLaunchLocation.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 99);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mission Name";
			// 
			// txt_missionName
			// 
			this.txt_missionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_missionName.Location = new System.Drawing.Point(124, 96);
			this.txt_missionName.Name = "txt_missionName";
			this.txt_missionName.Size = new System.Drawing.Size(456, 26);
			this.txt_missionName.TabIndex = 2;
			this.txt_missionName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_missionName_KeyDown);
			// 
			// btn_launch
			// 
			this.btn_launch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_launch.Location = new System.Drawing.Point(12, 173);
			this.btn_launch.Name = "btn_launch";
			this.btn_launch.Size = new System.Drawing.Size(568, 33);
			this.btn_launch.TabIndex = 4;
			this.btn_launch.Text = "Launch ModTools debugger";
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
			this.menuStrip1.Size = new System.Drawing.Size(592, 33);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alternateAddonGitHubToolStripMenuItem,
            this.aboutMissionLauncherToolStripMenuItem});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// alternateAddonGitHubToolStripMenuItem
			// 
			this.alternateAddonGitHubToolStripMenuItem.Name = "alternateAddonGitHubToolStripMenuItem";
			this.alternateAddonGitHubToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
			this.alternateAddonGitHubToolStripMenuItem.Text = "Alternate Addon GitHub";
			this.alternateAddonGitHubToolStripMenuItem.Click += new System.EventHandler(this.alternateAddonGitHubToolStripMenuItem_Click);
			// 
			// aboutMissionLauncherToolStripMenuItem
			// 
			this.aboutMissionLauncherToolStripMenuItem.Name = "aboutMissionLauncherToolStripMenuItem";
			this.aboutMissionLauncherToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
			this.aboutMissionLauncherToolStripMenuItem.Text = "About Mission Launcher";
			this.aboutMissionLauncherToolStripMenuItem.Click += new System.EventHandler(this.aboutMissionLauncherToolStripMenuItem_Click);
			// 
			// btn_close
			// 
			this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_close.Location = new System.Drawing.Point(12, 406);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new System.Drawing.Size(568, 42);
			this.btn_close.TabIndex = 5;
			this.btn_close.Text = "Close";
			this.btn_close.UseVisualStyleBackColor = true;
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BackColor = System.Drawing.Color.Azure;
			this.label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 338);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(568, 52);
			this.label2.TabIndex = 5;
			this.label2.Text = "Close this Window to clean up Auto launch file";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// grp_platform
			// 
			this.grp_platform.Controls.Add(this.btn_ppsspp);
			this.grp_platform.Controls.Add(this.btn_modToolsDebugger);
			this.grp_platform.Location = new System.Drawing.Point(16, 36);
			this.grp_platform.Name = "grp_platform";
			this.grp_platform.Size = new System.Drawing.Size(564, 54);
			this.grp_platform.TabIndex = 10;
			this.grp_platform.TabStop = false;
			this.grp_platform.Text = "Launch Platform";
			// 
			// btn_ppsspp
			// 
			this.btn_ppsspp.AutoSize = true;
			this.btn_ppsspp.Location = new System.Drawing.Point(214, 24);
			this.btn_ppsspp.Name = "btn_ppsspp";
			this.btn_ppsspp.Size = new System.Drawing.Size(96, 24);
			this.btn_ppsspp.TabIndex = 1;
			this.btn_ppsspp.Text = "PPSSPP";
			this.btn_ppsspp.UseVisualStyleBackColor = true;
			this.btn_ppsspp.CheckedChanged += new System.EventHandler(this.btn_modToolsDebugger_CheckedChanged);
			// 
			// btn_modToolsDebugger
			// 
			this.btn_modToolsDebugger.AutoSize = true;
			this.btn_modToolsDebugger.Checked = true;
			this.btn_modToolsDebugger.Location = new System.Drawing.Point(11, 24);
			this.btn_modToolsDebugger.Name = "btn_modToolsDebugger";
			this.btn_modToolsDebugger.Size = new System.Drawing.Size(182, 24);
			this.btn_modToolsDebugger.TabIndex = 0;
			this.btn_modToolsDebugger.TabStop = true;
			this.btn_modToolsDebugger.Text = "Mod Tools Debugger";
			this.btn_modToolsDebugger.UseVisualStyleBackColor = true;
			this.btn_modToolsDebugger.CheckedChanged += new System.EventHandler(this.btn_modToolsDebugger_CheckedChanged);
			// 
			// grp_autoLaunchLocation
			// 
			this.grp_autoLaunchLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grp_autoLaunchLocation.Controls.Add(this.txt_autoLaunchFileLocation);
			this.grp_autoLaunchLocation.Location = new System.Drawing.Point(12, 219);
			this.grp_autoLaunchLocation.Name = "grp_autoLaunchLocation";
			this.grp_autoLaunchLocation.Size = new System.Drawing.Size(568, 78);
			this.grp_autoLaunchLocation.TabIndex = 8;
			this.grp_autoLaunchLocation.TabStop = false;
			this.grp_autoLaunchLocation.Text = "Auto-launch file location";
			// 
			// txt_autoLaunchFileLocation
			// 
			this.txt_autoLaunchFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_autoLaunchFileLocation.Location = new System.Drawing.Point(6, 25);
			this.txt_autoLaunchFileLocation.Name = "txt_autoLaunchFileLocation";
			this.txt_autoLaunchFileLocation.ReadOnly = true;
			this.txt_autoLaunchFileLocation.Size = new System.Drawing.Size(556, 26);
			this.txt_autoLaunchFileLocation.TabIndex = 0;
			// 
			// txt_profileName
			// 
			this.txt_profileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_profileName.Location = new System.Drawing.Point(124, 128);
			this.txt_profileName.Name = "txt_profileName";
			this.txt_profileName.Size = new System.Drawing.Size(456, 26);
			this.txt_profileName.TabIndex = 3;
			this.txt_profileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_missionName_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 131);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "Profile Name";
			// 
			// MissionLauncherForm
			// 
			this.AcceptButton = this.btn_launch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_close;
			this.ClientSize = new System.Drawing.Size(592, 460);
			this.Controls.Add(this.txt_profileName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.grp_autoLaunchLocation);
			this.Controls.Add(this.grp_platform);
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
			this.grp_platform.ResumeLayout(false);
			this.grp_platform.PerformLayout();
			this.grp_autoLaunchLocation.ResumeLayout(false);
			this.grp_autoLaunchLocation.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem alternateAddonGitHubToolStripMenuItem;
		private System.Windows.Forms.GroupBox grp_platform;
		private System.Windows.Forms.RadioButton btn_ppsspp;
		private System.Windows.Forms.RadioButton btn_modToolsDebugger;
		private System.Windows.Forms.GroupBox grp_autoLaunchLocation;
		private System.Windows.Forms.TextBox txt_autoLaunchFileLocation;
		private System.Windows.Forms.TextBox txt_profileName;
		private System.Windows.Forms.Label label3;
	}
}