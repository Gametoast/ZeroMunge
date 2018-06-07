namespace ZeroMunge
{
    partial class Preferences
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_Accept = new System.Windows.Forms.Button();
			this.cont_Prefs = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.chk_ShowTrayIcon = new System.Windows.Forms.CheckBox();
			this.chk_ShowNotificationPopups = new System.Windows.Forms.CheckBox();
			this.chk_PlayNotificationSounds = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.chk_AutoDetectStagingDir = new System.Windows.Forms.CheckBox();
			this.chk_AutoDetectMungedFiles = new System.Windows.Forms.CheckBox();
			this.chk_AutoSaveEnabled = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_LogPollingRate = new System.Windows.Forms.TextBox();
			this.chk_OutputLogToFile = new System.Windows.Forms.CheckBox();
			this.chk_LogPrintTimestamps = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.chk_ShowUpdatePromptOnStartup = new System.Windows.Forms.CheckBox();
			this.chk_CheckForUpdatesOnStartup = new System.Windows.Forms.CheckBox();
			this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
			this.chk_AutoLoadEnabled = new System.Windows.Forms.CheckBox();
			this.cont_Prefs.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(197, 397);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 6;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_Accept
			// 
			this.btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Accept.Location = new System.Drawing.Point(116, 397);
			this.btn_Accept.Name = "btn_Accept";
			this.btn_Accept.Size = new System.Drawing.Size(75, 23);
			this.btn_Accept.TabIndex = 5;
			this.btn_Accept.Text = "OK";
			this.btn_Accept.UseVisualStyleBackColor = true;
			this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
			// 
			// cont_Prefs
			// 
			this.cont_Prefs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cont_Prefs.Controls.Add(this.groupBox1);
			this.cont_Prefs.Controls.Add(this.groupBox2);
			this.cont_Prefs.Controls.Add(this.groupBox4);
			this.cont_Prefs.Controls.Add(this.groupBox3);
			this.cont_Prefs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.cont_Prefs.Location = new System.Drawing.Point(12, 12);
			this.cont_Prefs.Name = "cont_Prefs";
			this.cont_Prefs.Size = new System.Drawing.Size(260, 379);
			this.cont_Prefs.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox1.Controls.Add(this.flowLayoutPanel1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(254, 88);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Interface";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.chk_ShowTrayIcon);
			this.flowLayoutPanel1.Controls.Add(this.chk_ShowNotificationPopups);
			this.flowLayoutPanel1.Controls.Add(this.chk_PlayNotificationSounds);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(248, 69);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// chk_ShowTrayIcon
			// 
			this.chk_ShowTrayIcon.AutoSize = true;
			this.chk_ShowTrayIcon.Checked = true;
			this.chk_ShowTrayIcon.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_ShowTrayIcon.Location = new System.Drawing.Point(3, 3);
			this.chk_ShowTrayIcon.Name = "chk_ShowTrayIcon";
			this.chk_ShowTrayIcon.Size = new System.Drawing.Size(179, 17);
			this.chk_ShowTrayIcon.TabIndex = 0;
			this.chk_ShowTrayIcon.Text = "Show Tray Icon (requires restart)";
			this.FormTooltips.SetToolTip(this.chk_ShowTrayIcon, "Whether or not to show the application\'s icon in the system tray. Note: The appli" +
        "cation must be restarted in order for changes to this setting to take effect.");
			this.chk_ShowTrayIcon.UseVisualStyleBackColor = true;
			this.chk_ShowTrayIcon.CheckedChanged += new System.EventHandler(this.chk_ShowTrayIcon_CheckedChanged);
			// 
			// chk_ShowNotificationPopups
			// 
			this.chk_ShowNotificationPopups.AutoSize = true;
			this.chk_ShowNotificationPopups.Checked = true;
			this.chk_ShowNotificationPopups.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_ShowNotificationPopups.Location = new System.Drawing.Point(3, 26);
			this.chk_ShowNotificationPopups.Name = "chk_ShowNotificationPopups";
			this.chk_ShowNotificationPopups.Size = new System.Drawing.Size(148, 17);
			this.chk_ShowNotificationPopups.TabIndex = 1;
			this.chk_ShowNotificationPopups.Text = "Show Notification Popups";
			this.FormTooltips.SetToolTip(this.chk_ShowNotificationPopups, "Whether or not to show notification popups for events such as when a job is compl" +
        "eted or aborted. Note: \'Show Tray Icons\' must be checked in order for this setti" +
        "ng to work.");
			this.chk_ShowNotificationPopups.UseVisualStyleBackColor = true;
			this.chk_ShowNotificationPopups.CheckedChanged += new System.EventHandler(this.chk_ShowNotificationPopups_CheckedChanged);
			// 
			// chk_PlayNotificationSounds
			// 
			this.chk_PlayNotificationSounds.AutoSize = true;
			this.chk_PlayNotificationSounds.Checked = true;
			this.chk_PlayNotificationSounds.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_PlayNotificationSounds.Location = new System.Drawing.Point(3, 49);
			this.chk_PlayNotificationSounds.Name = "chk_PlayNotificationSounds";
			this.chk_PlayNotificationSounds.Size = new System.Drawing.Size(141, 17);
			this.chk_PlayNotificationSounds.TabIndex = 2;
			this.chk_PlayNotificationSounds.Text = "Play Notification Sounds";
			this.FormTooltips.SetToolTip(this.chk_PlayNotificationSounds, "Whether or not to play unique sounds for events such as when a job is started, co" +
        "mpleted, or aborted.");
			this.chk_PlayNotificationSounds.UseVisualStyleBackColor = true;
			this.chk_PlayNotificationSounds.CheckedChanged += new System.EventHandler(this.chk_PlayNotificationSounds_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox2.Controls.Add(this.flowLayoutPanel2);
			this.groupBox2.Location = new System.Drawing.Point(3, 97);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(254, 111);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "File List";
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel2.Controls.Add(this.chk_AutoDetectStagingDir);
			this.flowLayoutPanel2.Controls.Add(this.chk_AutoDetectMungedFiles);
			this.flowLayoutPanel2.Controls.Add(this.chk_AutoSaveEnabled);
			this.flowLayoutPanel2.Controls.Add(this.chk_AutoLoadEnabled);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(248, 92);
			this.flowLayoutPanel2.TabIndex = 0;
			// 
			// chk_AutoDetectStagingDir
			// 
			this.chk_AutoDetectStagingDir.AutoSize = true;
			this.chk_AutoDetectStagingDir.Checked = true;
			this.chk_AutoDetectStagingDir.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_AutoDetectStagingDir.Location = new System.Drawing.Point(3, 3);
			this.chk_AutoDetectStagingDir.Name = "chk_AutoDetectStagingDir";
			this.chk_AutoDetectStagingDir.Size = new System.Drawing.Size(167, 17);
			this.chk_AutoDetectStagingDir.TabIndex = 3;
			this.chk_AutoDetectStagingDir.Text = "Auto-Detect Staging Directory";
			this.FormTooltips.SetToolTip(this.chk_AutoDetectStagingDir, "Whether or not to automatically detect and fill the \'Staging Directory\' field whe" +
        "n a file is added to the file list.");
			this.chk_AutoDetectStagingDir.UseVisualStyleBackColor = true;
			this.chk_AutoDetectStagingDir.CheckedChanged += new System.EventHandler(this.chk_AutoDetectStagingDir_CheckedChanged);
			// 
			// chk_AutoDetectMungedFiles
			// 
			this.chk_AutoDetectMungedFiles.AutoSize = true;
			this.chk_AutoDetectMungedFiles.Checked = true;
			this.chk_AutoDetectMungedFiles.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_AutoDetectMungedFiles.Location = new System.Drawing.Point(3, 26);
			this.chk_AutoDetectMungedFiles.Name = "chk_AutoDetectMungedFiles";
			this.chk_AutoDetectMungedFiles.Size = new System.Drawing.Size(149, 17);
			this.chk_AutoDetectMungedFiles.TabIndex = 4;
			this.chk_AutoDetectMungedFiles.Text = "Auto-Detect Munged Files";
			this.FormTooltips.SetToolTip(this.chk_AutoDetectMungedFiles, "Whether or not to automatically detect and fill the \'Munged Files\' field when a f" +
        "ile is added to the file list.");
			this.chk_AutoDetectMungedFiles.UseVisualStyleBackColor = true;
			this.chk_AutoDetectMungedFiles.CheckedChanged += new System.EventHandler(this.chk_AutoDetectMungedFiles_CheckedChanged);
			// 
			// chk_AutoSaveEnabled
			// 
			this.chk_AutoSaveEnabled.AutoSize = true;
			this.chk_AutoSaveEnabled.Checked = true;
			this.chk_AutoSaveEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_AutoSaveEnabled.Location = new System.Drawing.Point(3, 49);
			this.chk_AutoSaveEnabled.Name = "chk_AutoSaveEnabled";
			this.chk_AutoSaveEnabled.Size = new System.Drawing.Size(114, 17);
			this.chk_AutoSaveEnabled.TabIndex = 5;
			this.chk_AutoSaveEnabled.Text = "Auto-Save File List";
			this.FormTooltips.SetToolTip(this.chk_AutoSaveEnabled, "Whether or not to automatically save the file list\'s contents to file when the ap" +
        "plication exits.");
			this.chk_AutoSaveEnabled.UseVisualStyleBackColor = true;
			this.chk_AutoSaveEnabled.CheckedChanged += new System.EventHandler(this.chk_AutoSaveEnabled_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox4.Controls.Add(this.flowLayoutPanel4);
			this.groupBox4.Location = new System.Drawing.Point(3, 214);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(254, 91);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Output Log";
			// 
			// flowLayoutPanel4
			// 
			this.flowLayoutPanel4.AutoSize = true;
			this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel4.Controls.Add(this.tableLayoutPanel1);
			this.flowLayoutPanel4.Controls.Add(this.chk_OutputLogToFile);
			this.flowLayoutPanel4.Controls.Add(this.chk_LogPrintTimestamps);
			this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 16);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Size = new System.Drawing.Size(248, 72);
			this.flowLayoutPanel4.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.txt_LogPollingRate, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(248, 20);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Polling Rate (ms):";
			this.FormTooltips.SetToolTip(this.label1, "The rate (in milliseconds) at which the contents of the Output Log are updated.");
			// 
			// txt_LogPollingRate
			// 
			this.txt_LogPollingRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_LogPollingRate.Location = new System.Drawing.Point(124, 0);
			this.txt_LogPollingRate.Margin = new System.Windows.Forms.Padding(0);
			this.txt_LogPollingRate.Name = "txt_LogPollingRate";
			this.txt_LogPollingRate.Size = new System.Drawing.Size(124, 20);
			this.txt_LogPollingRate.TabIndex = 1;
			this.FormTooltips.SetToolTip(this.txt_LogPollingRate, "The rate (in milliseconds) at which the contents of the Output Log are updated.");
			// 
			// chk_OutputLogToFile
			// 
			this.chk_OutputLogToFile.AutoSize = true;
			this.chk_OutputLogToFile.Checked = true;
			this.chk_OutputLogToFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_OutputLogToFile.Location = new System.Drawing.Point(3, 29);
			this.chk_OutputLogToFile.Name = "chk_OutputLogToFile";
			this.chk_OutputLogToFile.Size = new System.Drawing.Size(93, 17);
			this.chk_OutputLogToFile.TabIndex = 4;
			this.chk_OutputLogToFile.Text = "Output To File";
			this.FormTooltips.SetToolTip(this.chk_OutputLogToFile, "Whether or not to output the log to a file.s");
			this.chk_OutputLogToFile.UseVisualStyleBackColor = true;
			this.chk_OutputLogToFile.CheckedChanged += new System.EventHandler(this.chk_OutputLogToFile_CheckedChanged);
			// 
			// chk_LogPrintTimestamps
			// 
			this.chk_LogPrintTimestamps.AutoSize = true;
			this.chk_LogPrintTimestamps.Checked = true;
			this.chk_LogPrintTimestamps.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_LogPrintTimestamps.Location = new System.Drawing.Point(3, 52);
			this.chk_LogPrintTimestamps.Name = "chk_LogPrintTimestamps";
			this.chk_LogPrintTimestamps.Size = new System.Drawing.Size(106, 17);
			this.chk_LogPrintTimestamps.TabIndex = 3;
			this.chk_LogPrintTimestamps.Text = "Print Timestamps";
			this.FormTooltips.SetToolTip(this.chk_LogPrintTimestamps, "Whether or not to print timestamps in the Output Log.");
			this.chk_LogPrintTimestamps.UseVisualStyleBackColor = true;
			this.chk_LogPrintTimestamps.CheckedChanged += new System.EventHandler(this.chk_LogPrintTimestamps_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox3.Controls.Add(this.flowLayoutPanel3);
			this.groupBox3.Location = new System.Drawing.Point(3, 311);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(254, 65);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Updates";
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.AutoSize = true;
			this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel3.Controls.Add(this.chk_ShowUpdatePromptOnStartup);
			this.flowLayoutPanel3.Controls.Add(this.chk_CheckForUpdatesOnStartup);
			this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 16);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(248, 46);
			this.flowLayoutPanel3.TabIndex = 0;
			// 
			// chk_ShowUpdatePromptOnStartup
			// 
			this.chk_ShowUpdatePromptOnStartup.AutoSize = true;
			this.chk_ShowUpdatePromptOnStartup.Checked = true;
			this.chk_ShowUpdatePromptOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_ShowUpdatePromptOnStartup.Location = new System.Drawing.Point(3, 3);
			this.chk_ShowUpdatePromptOnStartup.Name = "chk_ShowUpdatePromptOnStartup";
			this.chk_ShowUpdatePromptOnStartup.Size = new System.Drawing.Size(181, 17);
			this.chk_ShowUpdatePromptOnStartup.TabIndex = 3;
			this.chk_ShowUpdatePromptOnStartup.Text = "Show Update Prompt On Startup";
			this.FormTooltips.SetToolTip(this.chk_ShowUpdatePromptOnStartup, "Whether or not to show an update prompt if an update is available.");
			this.chk_ShowUpdatePromptOnStartup.UseVisualStyleBackColor = true;
			this.chk_ShowUpdatePromptOnStartup.CheckedChanged += new System.EventHandler(this.chk_ShowUpdatePromptOnStartup_CheckedChanged);
			// 
			// chk_CheckForUpdatesOnStartup
			// 
			this.chk_CheckForUpdatesOnStartup.AutoSize = true;
			this.chk_CheckForUpdatesOnStartup.Checked = true;
			this.chk_CheckForUpdatesOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_CheckForUpdatesOnStartup.Location = new System.Drawing.Point(3, 26);
			this.chk_CheckForUpdatesOnStartup.Name = "chk_CheckForUpdatesOnStartup";
			this.chk_CheckForUpdatesOnStartup.Size = new System.Drawing.Size(172, 17);
			this.chk_CheckForUpdatesOnStartup.TabIndex = 4;
			this.chk_CheckForUpdatesOnStartup.Text = "Check For Updates On Startup";
			this.FormTooltips.SetToolTip(this.chk_CheckForUpdatesOnStartup, "Whether or not to check for updates on application startup.");
			this.chk_CheckForUpdatesOnStartup.UseVisualStyleBackColor = true;
			this.chk_CheckForUpdatesOnStartup.CheckedChanged += new System.EventHandler(this.chk_CheckForUpdatesOnStartup_CheckedChanged);
			// 
			// chk_AutoLoadEnabled
			// 
			this.chk_AutoLoadEnabled.AutoSize = true;
			this.chk_AutoLoadEnabled.Checked = true;
			this.chk_AutoLoadEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_AutoLoadEnabled.Location = new System.Drawing.Point(3, 72);
			this.chk_AutoLoadEnabled.Name = "chk_AutoLoadEnabled";
			this.chk_AutoLoadEnabled.Size = new System.Drawing.Size(145, 17);
			this.chk_AutoLoadEnabled.TabIndex = 6;
			this.chk_AutoLoadEnabled.Text = "Auto-Load Last Save File";
			this.FormTooltips.SetToolTip(this.chk_AutoLoadEnabled, "Whether or not to automatically load the most recent save file when the applicati" +
        "on starts up.");
			this.chk_AutoLoadEnabled.UseVisualStyleBackColor = true;
			this.chk_AutoLoadEnabled.CheckedChanged += new System.EventHandler(this.chk_AutoLoadEnabled_CheckedChanged);
			// 
			// Preferences
			// 
			this.AcceptButton = this.btn_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(284, 432);
			this.Controls.Add(this.cont_Prefs);
			this.Controls.Add(this.btn_Accept);
			this.Controls.Add(this.btn_Cancel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(300, 471);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 471);
			this.Name = "Preferences";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Preferences";
			this.Load += new System.EventHandler(this.Preferences_Load);
			this.cont_Prefs.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.flowLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel4.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.FlowLayoutPanel cont_Prefs;
        private System.Windows.Forms.CheckBox chk_ShowTrayIcon;
        private System.Windows.Forms.CheckBox chk_ShowNotificationPopups;
        private System.Windows.Forms.CheckBox chk_PlayNotificationSounds;
        private System.Windows.Forms.CheckBox chk_AutoDetectStagingDir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox chk_AutoDetectMungedFiles;
        private System.Windows.Forms.ToolTip FormTooltips;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
		private System.Windows.Forms.CheckBox chk_ShowUpdatePromptOnStartup;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_LogPollingRate;
		private System.Windows.Forms.CheckBox chk_OutputLogToFile;
		private System.Windows.Forms.CheckBox chk_LogPrintTimestamps;
		private System.Windows.Forms.CheckBox chk_CheckForUpdatesOnStartup;
		private System.Windows.Forms.CheckBox chk_AutoSaveEnabled;
		private System.Windows.Forms.CheckBox chk_AutoLoadEnabled;
	}
}