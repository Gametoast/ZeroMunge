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
			this.cont_Prefs = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.interfacePanel = new System.Windows.Forms.Panel();
			this.grp_zeroEditor = new System.Windows.Forms.GroupBox();
			this.btn_browseZeroEditor = new System.Windows.Forms.Button();
			this.txt_zeroEditor = new System.Windows.Forms.TextBox();
			this.grp_editor = new System.Windows.Forms.GroupBox();
			this.btn_browseEditor = new System.Windows.Forms.Button();
			this.txt_editor = new System.Windows.Forms.TextBox();
			this.grp_debugger = new System.Windows.Forms.GroupBox();
			this.lab_debuggerArgs = new System.Windows.Forms.Label();
			this.txt_debuggerArgs = new System.Windows.Forms.TextBox();
			this.btn_browseDebuggerExe = new System.Windows.Forms.Button();
			this.txt_gameDebugger = new System.Windows.Forms.TextBox();
			this.grp_setGameExe = new System.Windows.Forms.GroupBox();
			this.lab_gameExeArgs = new System.Windows.Forms.Label();
			this.txt_gameArgs = new System.Windows.Forms.TextBox();
			this.btn_browseGameExe = new System.Windows.Forms.Button();
			this.txt_gameExe = new System.Windows.Forms.TextBox();
			this.chk_ShowTrayIcon = new System.Windows.Forms.CheckBox();
			this.chk_ShowNotificationPopups = new System.Windows.Forms.CheckBox();
			this.chk_PlayNotificationSounds = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.chk_AutoDetectStagingDir = new System.Windows.Forms.CheckBox();
			this.chk_AutoDetectMungedFiles = new System.Windows.Forms.CheckBox();
			this.chk_AutoSaveEnabled = new System.Windows.Forms.CheckBox();
			this.chk_AutoLoadEnabled = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.num_LogPollingRate = new System.Windows.Forms.NumericUpDown();
			this.lbl_LogPollingRate = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lbl_LogMaxLineCount = new System.Windows.Forms.Label();
			this.num_LogMaxLineCount = new System.Windows.Forms.NumericUpDown();
			this.chk_OutputLogToFile = new System.Windows.Forms.CheckBox();
			this.chk_LogPrintTimestamps = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.chk_CheckForUpdatesOnStartup = new System.Windows.Forms.CheckBox();
			this.chk_ShowUpdatePromptOnStartup = new System.Windows.Forms.CheckBox();
			this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
			this.cont_Prefs.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.interfacePanel.SuspendLayout();
			this.grp_zeroEditor.SuspendLayout();
			this.grp_editor.SuspendLayout();
			this.grp_debugger.SuspendLayout();
			this.grp_setGameExe.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_LogPollingRate)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_LogMaxLineCount)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(657, 806);
			this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(112, 35);
			this.btn_Cancel.TabIndex = 6;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_Accept
			// 
			this.btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Accept.Location = new System.Drawing.Point(535, 806);
			this.btn_Accept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_Accept.Name = "btn_Accept";
			this.btn_Accept.Size = new System.Drawing.Size(112, 35);
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
			this.cont_Prefs.Location = new System.Drawing.Point(18, 18);
			this.cont_Prefs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cont_Prefs.Name = "cont_Prefs";
			this.cont_Prefs.Size = new System.Drawing.Size(751, 781);
			this.cont_Prefs.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox1.Controls.Add(this.interfacePanel);
			this.groupBox1.Location = new System.Drawing.Point(4, 5);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Size = new System.Drawing.Size(743, 422);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Interface";
			// 
			// interfacePanel
			// 
			this.interfacePanel.AutoSize = true;
			this.interfacePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.interfacePanel.Controls.Add(this.grp_zeroEditor);
			this.interfacePanel.Controls.Add(this.grp_editor);
			this.interfacePanel.Controls.Add(this.grp_debugger);
			this.interfacePanel.Controls.Add(this.grp_setGameExe);
			this.interfacePanel.Controls.Add(this.chk_ShowTrayIcon);
			this.interfacePanel.Controls.Add(this.chk_ShowNotificationPopups);
			this.interfacePanel.Controls.Add(this.chk_PlayNotificationSounds);
			this.interfacePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.interfacePanel.Location = new System.Drawing.Point(4, 24);
			this.interfacePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.interfacePanel.Name = "interfacePanel";
			this.interfacePanel.Size = new System.Drawing.Size(735, 393);
			this.interfacePanel.TabIndex = 0;
			// 
			// grp_zeroEditor
			// 
			this.grp_zeroEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.grp_zeroEditor.Controls.Add(this.btn_browseZeroEditor);
			this.grp_zeroEditor.Controls.Add(this.txt_zeroEditor);
			this.grp_zeroEditor.Location = new System.Drawing.Point(4, 328);
			this.grp_zeroEditor.Name = "grp_zeroEditor";
			this.grp_zeroEditor.Size = new System.Drawing.Size(728, 57);
			this.grp_zeroEditor.TabIndex = 6;
			this.grp_zeroEditor.TabStop = false;
			this.grp_zeroEditor.Text = "Set Preferred Zero Editor";
			// 
			// btn_browseZeroEditor
			// 
			this.btn_browseZeroEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_browseZeroEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_browseZeroEditor.Location = new System.Drawing.Point(617, 18);
			this.btn_browseZeroEditor.Name = "btn_browseZeroEditor";
			this.btn_browseZeroEditor.Size = new System.Drawing.Size(105, 35);
			this.btn_browseZeroEditor.TabIndex = 1;
			this.btn_browseZeroEditor.Text = "Browse...";
			this.btn_browseZeroEditor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btn_browseZeroEditor.UseVisualStyleBackColor = true;
			this.btn_browseZeroEditor.Click += new System.EventHandler(this.btn_browseExe_Click);
			// 
			// txt_zeroEditor
			// 
			this.txt_zeroEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_zeroEditor.BackColor = System.Drawing.Color.Azure;
			this.txt_zeroEditor.Location = new System.Drawing.Point(6, 22);
			this.txt_zeroEditor.Name = "txt_zeroEditor";
			this.txt_zeroEditor.Size = new System.Drawing.Size(605, 26);
			this.txt_zeroEditor.TabIndex = 0;
			this.txt_zeroEditor.Leave += new System.EventHandler(this.txt_Leave);
			// 
			// grp_editor
			// 
			this.grp_editor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.grp_editor.Controls.Add(this.btn_browseEditor);
			this.grp_editor.Controls.Add(this.txt_editor);
			this.grp_editor.Location = new System.Drawing.Point(4, 265);
			this.grp_editor.Name = "grp_editor";
			this.grp_editor.Size = new System.Drawing.Size(728, 57);
			this.grp_editor.TabIndex = 5;
			this.grp_editor.TabStop = false;
			this.grp_editor.Text = "Set Preferred Text Editor";
			// 
			// btn_browseEditor
			// 
			this.btn_browseEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_browseEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_browseEditor.Location = new System.Drawing.Point(617, 18);
			this.btn_browseEditor.Name = "btn_browseEditor";
			this.btn_browseEditor.Size = new System.Drawing.Size(105, 35);
			this.btn_browseEditor.TabIndex = 1;
			this.btn_browseEditor.Text = "Browse...";
			this.btn_browseEditor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btn_browseEditor.UseVisualStyleBackColor = true;
			this.btn_browseEditor.Click += new System.EventHandler(this.btn_browseExe_Click);
			// 
			// txt_editor
			// 
			this.txt_editor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_editor.BackColor = System.Drawing.Color.Azure;
			this.txt_editor.Location = new System.Drawing.Point(6, 22);
			this.txt_editor.Name = "txt_editor";
			this.txt_editor.Size = new System.Drawing.Size(605, 26);
			this.txt_editor.TabIndex = 0;
			this.txt_editor.Leave += new System.EventHandler(this.txt_Leave);
			// 
			// grp_debugger
			// 
			this.grp_debugger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.grp_debugger.Controls.Add(this.lab_debuggerArgs);
			this.grp_debugger.Controls.Add(this.txt_debuggerArgs);
			this.grp_debugger.Controls.Add(this.btn_browseDebuggerExe);
			this.grp_debugger.Controls.Add(this.txt_gameDebugger);
			this.grp_debugger.Location = new System.Drawing.Point(4, 166);
			this.grp_debugger.Name = "grp_debugger";
			this.grp_debugger.Size = new System.Drawing.Size(728, 95);
			this.grp_debugger.TabIndex = 4;
			this.grp_debugger.TabStop = false;
			this.grp_debugger.Text = "Set Debugger Exe";
			// 
			// lab_debuggerArgs
			// 
			this.lab_debuggerArgs.AutoSize = true;
			this.lab_debuggerArgs.Location = new System.Drawing.Point(6, 57);
			this.lab_debuggerArgs.Name = "lab_debuggerArgs";
			this.lab_debuggerArgs.Size = new System.Drawing.Size(160, 20);
			this.lab_debuggerArgs.TabIndex = 3;
			this.lab_debuggerArgs.Text = "Args\\ Launch mission";
			// 
			// txt_debuggerArgs
			// 
			this.txt_debuggerArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_debuggerArgs.BackColor = System.Drawing.Color.AliceBlue;
			this.txt_debuggerArgs.Location = new System.Drawing.Point(190, 57);
			this.txt_debuggerArgs.Name = "txt_debuggerArgs";
			this.txt_debuggerArgs.Size = new System.Drawing.Size(421, 26);
			this.txt_debuggerArgs.TabIndex = 2;
			// 
			// btn_browseDebuggerExe
			// 
			this.btn_browseDebuggerExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_browseDebuggerExe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_browseDebuggerExe.Location = new System.Drawing.Point(617, 18);
			this.btn_browseDebuggerExe.Name = "btn_browseDebuggerExe";
			this.btn_browseDebuggerExe.Size = new System.Drawing.Size(105, 35);
			this.btn_browseDebuggerExe.TabIndex = 1;
			this.btn_browseDebuggerExe.Text = "Browse...";
			this.btn_browseDebuggerExe.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btn_browseDebuggerExe.UseVisualStyleBackColor = true;
			this.btn_browseDebuggerExe.Click += new System.EventHandler(this.btn_browseExe_Click);
			// 
			// txt_gameDebugger
			// 
			this.txt_gameDebugger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_gameDebugger.BackColor = System.Drawing.Color.Azure;
			this.txt_gameDebugger.Location = new System.Drawing.Point(6, 22);
			this.txt_gameDebugger.Name = "txt_gameDebugger";
			this.txt_gameDebugger.Size = new System.Drawing.Size(605, 26);
			this.txt_gameDebugger.TabIndex = 0;
			this.txt_gameDebugger.Leave += new System.EventHandler(this.txt_Leave);
			// 
			// grp_setGameExe
			// 
			this.grp_setGameExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grp_setGameExe.Controls.Add(this.lab_gameExeArgs);
			this.grp_setGameExe.Controls.Add(this.txt_gameArgs);
			this.grp_setGameExe.Controls.Add(this.btn_browseGameExe);
			this.grp_setGameExe.Controls.Add(this.txt_gameExe);
			this.grp_setGameExe.Location = new System.Drawing.Point(4, 74);
			this.grp_setGameExe.Name = "grp_setGameExe";
			this.grp_setGameExe.Size = new System.Drawing.Size(728, 95);
			this.grp_setGameExe.TabIndex = 3;
			this.grp_setGameExe.TabStop = false;
			this.grp_setGameExe.Text = "Set Game Exe";
			// 
			// lab_gameExeArgs
			// 
			this.lab_gameExeArgs.AutoSize = true;
			this.lab_gameExeArgs.Location = new System.Drawing.Point(6, 59);
			this.lab_gameExeArgs.Name = "lab_gameExeArgs";
			this.lab_gameExeArgs.Size = new System.Drawing.Size(160, 20);
			this.lab_gameExeArgs.TabIndex = 5;
			this.lab_gameExeArgs.Text = "Args\\ Launch mission";
			// 
			// txt_gameArgs
			// 
			this.txt_gameArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_gameArgs.BackColor = System.Drawing.Color.AliceBlue;
			this.txt_gameArgs.Location = new System.Drawing.Point(190, 57);
			this.txt_gameArgs.Name = "txt_gameArgs";
			this.txt_gameArgs.Size = new System.Drawing.Size(421, 26);
			this.txt_gameArgs.TabIndex = 4;
			// 
			// btn_browseGameExe
			// 
			this.btn_browseGameExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_browseGameExe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_browseGameExe.Location = new System.Drawing.Point(617, 18);
			this.btn_browseGameExe.Name = "btn_browseGameExe";
			this.btn_browseGameExe.Size = new System.Drawing.Size(105, 35);
			this.btn_browseGameExe.TabIndex = 1;
			this.btn_browseGameExe.Text = "Browse...";
			this.btn_browseGameExe.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btn_browseGameExe.UseVisualStyleBackColor = true;
			this.btn_browseGameExe.Click += new System.EventHandler(this.btn_browseExe_Click);
			// 
			// txt_gameExe
			// 
			this.txt_gameExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_gameExe.BackColor = System.Drawing.Color.Azure;
			this.txt_gameExe.Location = new System.Drawing.Point(6, 22);
			this.txt_gameExe.Name = "txt_gameExe";
			this.txt_gameExe.Size = new System.Drawing.Size(605, 26);
			this.txt_gameExe.TabIndex = 0;
			this.txt_gameExe.Leave += new System.EventHandler(this.txt_Leave);
			// 
			// chk_ShowTrayIcon
			// 
			this.chk_ShowTrayIcon.AutoSize = true;
			this.chk_ShowTrayIcon.Checked = true;
			this.chk_ShowTrayIcon.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_ShowTrayIcon.Location = new System.Drawing.Point(4, 5);
			this.chk_ShowTrayIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_ShowTrayIcon.Name = "chk_ShowTrayIcon";
			this.chk_ShowTrayIcon.Size = new System.Drawing.Size(265, 24);
			this.chk_ShowTrayIcon.TabIndex = 0;
			this.chk_ShowTrayIcon.Text = "Show Tray Icon (requires restart)";
			this.chk_ShowTrayIcon.UseVisualStyleBackColor = true;
			this.chk_ShowTrayIcon.CheckedChanged += new System.EventHandler(this.chk_ShowTrayIcon_CheckedChanged);
			// 
			// chk_ShowNotificationPopups
			// 
			this.chk_ShowNotificationPopups.AutoSize = true;
			this.chk_ShowNotificationPopups.Checked = true;
			this.chk_ShowNotificationPopups.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_ShowNotificationPopups.Location = new System.Drawing.Point(4, 39);
			this.chk_ShowNotificationPopups.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_ShowNotificationPopups.Name = "chk_ShowNotificationPopups";
			this.chk_ShowNotificationPopups.Size = new System.Drawing.Size(216, 24);
			this.chk_ShowNotificationPopups.TabIndex = 1;
			this.chk_ShowNotificationPopups.Text = "Show Notification Popups";
			this.chk_ShowNotificationPopups.UseVisualStyleBackColor = true;
			this.chk_ShowNotificationPopups.CheckedChanged += new System.EventHandler(this.chk_ShowNotificationPopups_CheckedChanged);
			// 
			// chk_PlayNotificationSounds
			// 
			this.chk_PlayNotificationSounds.AutoSize = true;
			this.chk_PlayNotificationSounds.Checked = true;
			this.chk_PlayNotificationSounds.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_PlayNotificationSounds.Location = new System.Drawing.Point(277, 5);
			this.chk_PlayNotificationSounds.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_PlayNotificationSounds.Name = "chk_PlayNotificationSounds";
			this.chk_PlayNotificationSounds.Size = new System.Drawing.Size(206, 24);
			this.chk_PlayNotificationSounds.TabIndex = 2;
			this.chk_PlayNotificationSounds.Text = "Play Notification Sounds";
			this.chk_PlayNotificationSounds.UseVisualStyleBackColor = true;
			this.chk_PlayNotificationSounds.CheckedChanged += new System.EventHandler(this.chk_PlayNotificationSounds_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox2.Controls.Add(this.flowLayoutPanel2);
			this.groupBox2.Location = new System.Drawing.Point(401, 437);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox2.Size = new System.Drawing.Size(345, 180);
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
			this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 24);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(337, 151);
			this.flowLayoutPanel2.TabIndex = 0;
			// 
			// chk_AutoDetectStagingDir
			// 
			this.chk_AutoDetectStagingDir.AutoSize = true;
			this.chk_AutoDetectStagingDir.Checked = true;
			this.chk_AutoDetectStagingDir.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_AutoDetectStagingDir.Location = new System.Drawing.Point(4, 5);
			this.chk_AutoDetectStagingDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_AutoDetectStagingDir.Name = "chk_AutoDetectStagingDir";
			this.chk_AutoDetectStagingDir.Size = new System.Drawing.Size(248, 24);
			this.chk_AutoDetectStagingDir.TabIndex = 3;
			this.chk_AutoDetectStagingDir.Text = "Auto-Detect Staging Directory";
			this.chk_AutoDetectStagingDir.UseVisualStyleBackColor = true;
			this.chk_AutoDetectStagingDir.CheckedChanged += new System.EventHandler(this.chk_AutoDetectStagingDir_CheckedChanged);
			// 
			// chk_AutoDetectMungedFiles
			// 
			this.chk_AutoDetectMungedFiles.AutoSize = true;
			this.chk_AutoDetectMungedFiles.Checked = true;
			this.chk_AutoDetectMungedFiles.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_AutoDetectMungedFiles.Location = new System.Drawing.Point(4, 39);
			this.chk_AutoDetectMungedFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_AutoDetectMungedFiles.Name = "chk_AutoDetectMungedFiles";
			this.chk_AutoDetectMungedFiles.Size = new System.Drawing.Size(221, 24);
			this.chk_AutoDetectMungedFiles.TabIndex = 4;
			this.chk_AutoDetectMungedFiles.Text = "Auto-Detect Munged Files";
			this.chk_AutoDetectMungedFiles.UseVisualStyleBackColor = true;
			this.chk_AutoDetectMungedFiles.CheckedChanged += new System.EventHandler(this.chk_AutoDetectMungedFiles_CheckedChanged);
			// 
			// chk_AutoSaveEnabled
			// 
			this.chk_AutoSaveEnabled.AutoSize = true;
			this.chk_AutoSaveEnabled.Checked = true;
			this.chk_AutoSaveEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_AutoSaveEnabled.Location = new System.Drawing.Point(4, 73);
			this.chk_AutoSaveEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_AutoSaveEnabled.Name = "chk_AutoSaveEnabled";
			this.chk_AutoSaveEnabled.Size = new System.Drawing.Size(168, 24);
			this.chk_AutoSaveEnabled.TabIndex = 5;
			this.chk_AutoSaveEnabled.Text = "Auto-Save File List";
			this.chk_AutoSaveEnabled.UseVisualStyleBackColor = true;
			this.chk_AutoSaveEnabled.CheckedChanged += new System.EventHandler(this.chk_AutoSaveEnabled_CheckedChanged);
			// 
			// chk_AutoLoadEnabled
			// 
			this.chk_AutoLoadEnabled.AutoSize = true;
			this.chk_AutoLoadEnabled.Checked = true;
			this.chk_AutoLoadEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_AutoLoadEnabled.Location = new System.Drawing.Point(4, 107);
			this.chk_AutoLoadEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_AutoLoadEnabled.Name = "chk_AutoLoadEnabled";
			this.chk_AutoLoadEnabled.Size = new System.Drawing.Size(214, 24);
			this.chk_AutoLoadEnabled.TabIndex = 6;
			this.chk_AutoLoadEnabled.Text = "Auto-Load Last Save File";
			this.chk_AutoLoadEnabled.UseVisualStyleBackColor = true;
			this.chk_AutoLoadEnabled.CheckedChanged += new System.EventHandler(this.chk_AutoLoadEnabled_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox4.Controls.Add(this.flowLayoutPanel4);
			this.groupBox4.Location = new System.Drawing.Point(12, 437);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox4.Size = new System.Drawing.Size(381, 180);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Output Log";
			// 
			// flowLayoutPanel4
			// 
			this.flowLayoutPanel4.AutoSize = true;
			this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel4.Controls.Add(this.tableLayoutPanel1);
			this.flowLayoutPanel4.Controls.Add(this.tableLayoutPanel2);
			this.flowLayoutPanel4.Controls.Add(this.chk_OutputLogToFile);
			this.flowLayoutPanel4.Controls.Add(this.chk_LogPrintTimestamps);
			this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(4, 24);
			this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Size = new System.Drawing.Size(373, 151);
			this.flowLayoutPanel4.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.num_LogPollingRate, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lbl_LogPollingRate, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 5);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(372, 31);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// num_LogPollingRate
			// 
			this.num_LogPollingRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.num_LogPollingRate.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.num_LogPollingRate.Location = new System.Drawing.Point(186, 2);
			this.num_LogPollingRate.Margin = new System.Windows.Forms.Padding(0);
			this.num_LogPollingRate.Name = "num_LogPollingRate";
			this.num_LogPollingRate.Size = new System.Drawing.Size(186, 26);
			this.num_LogPollingRate.TabIndex = 7;
			// 
			// lbl_LogPollingRate
			// 
			this.lbl_LogPollingRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lbl_LogPollingRate.AutoSize = true;
			this.lbl_LogPollingRate.Location = new System.Drawing.Point(4, 5);
			this.lbl_LogPollingRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_LogPollingRate.Name = "lbl_LogPollingRate";
			this.lbl_LogPollingRate.Size = new System.Drawing.Size(133, 20);
			this.lbl_LogPollingRate.TabIndex = 0;
			this.lbl_LogPollingRate.Text = "Polling Rate (ms):";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.lbl_LogMaxLineCount, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.num_LogMaxLineCount, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 46);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(372, 31);
			this.tableLayoutPanel2.TabIndex = 6;
			// 
			// lbl_LogMaxLineCount
			// 
			this.lbl_LogMaxLineCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lbl_LogMaxLineCount.AutoSize = true;
			this.lbl_LogMaxLineCount.Location = new System.Drawing.Point(4, 5);
			this.lbl_LogMaxLineCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_LogMaxLineCount.Name = "lbl_LogMaxLineCount";
			this.lbl_LogMaxLineCount.Size = new System.Drawing.Size(123, 20);
			this.lbl_LogMaxLineCount.TabIndex = 0;
			this.lbl_LogMaxLineCount.Text = "Max Line Count:";
			// 
			// num_LogMaxLineCount
			// 
			this.num_LogMaxLineCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.num_LogMaxLineCount.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.num_LogMaxLineCount.Location = new System.Drawing.Point(186, 2);
			this.num_LogMaxLineCount.Margin = new System.Windows.Forms.Padding(0);
			this.num_LogMaxLineCount.Name = "num_LogMaxLineCount";
			this.num_LogMaxLineCount.Size = new System.Drawing.Size(186, 26);
			this.num_LogMaxLineCount.TabIndex = 8;
			// 
			// chk_OutputLogToFile
			// 
			this.chk_OutputLogToFile.AutoSize = true;
			this.chk_OutputLogToFile.Checked = true;
			this.chk_OutputLogToFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_OutputLogToFile.Location = new System.Drawing.Point(4, 87);
			this.chk_OutputLogToFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_OutputLogToFile.Name = "chk_OutputLogToFile";
			this.chk_OutputLogToFile.Size = new System.Drawing.Size(135, 24);
			this.chk_OutputLogToFile.TabIndex = 9;
			this.chk_OutputLogToFile.Text = "Output To File";
			this.chk_OutputLogToFile.UseVisualStyleBackColor = true;
			this.chk_OutputLogToFile.CheckedChanged += new System.EventHandler(this.chk_OutputLogToFile_CheckedChanged);
			// 
			// chk_LogPrintTimestamps
			// 
			this.chk_LogPrintTimestamps.AutoSize = true;
			this.chk_LogPrintTimestamps.Checked = true;
			this.chk_LogPrintTimestamps.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_LogPrintTimestamps.Location = new System.Drawing.Point(4, 121);
			this.chk_LogPrintTimestamps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_LogPrintTimestamps.Name = "chk_LogPrintTimestamps";
			this.chk_LogPrintTimestamps.Size = new System.Drawing.Size(157, 24);
			this.chk_LogPrintTimestamps.TabIndex = 10;
			this.chk_LogPrintTimestamps.Text = "Print Timestamps";
			this.chk_LogPrintTimestamps.UseVisualStyleBackColor = true;
			this.chk_LogPrintTimestamps.CheckedChanged += new System.EventHandler(this.chk_LogPrintTimestamps_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox3.Controls.Add(this.flowLayoutPanel3);
			this.groupBox3.Location = new System.Drawing.Point(12, 627);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox3.Size = new System.Drawing.Size(339, 100);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Updates";
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.AutoSize = true;
			this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel3.Controls.Add(this.chk_CheckForUpdatesOnStartup);
			this.flowLayoutPanel3.Controls.Add(this.chk_ShowUpdatePromptOnStartup);
			this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(4, 24);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(331, 71);
			this.flowLayoutPanel3.TabIndex = 0;
			// 
			// chk_CheckForUpdatesOnStartup
			// 
			this.chk_CheckForUpdatesOnStartup.AutoSize = true;
			this.chk_CheckForUpdatesOnStartup.Checked = true;
			this.chk_CheckForUpdatesOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_CheckForUpdatesOnStartup.Location = new System.Drawing.Point(4, 5);
			this.chk_CheckForUpdatesOnStartup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_CheckForUpdatesOnStartup.Name = "chk_CheckForUpdatesOnStartup";
			this.chk_CheckForUpdatesOnStartup.Size = new System.Drawing.Size(255, 24);
			this.chk_CheckForUpdatesOnStartup.TabIndex = 11;
			this.chk_CheckForUpdatesOnStartup.Text = "Check For Updates On Startup";
			this.chk_CheckForUpdatesOnStartup.UseVisualStyleBackColor = true;
			this.chk_CheckForUpdatesOnStartup.CheckedChanged += new System.EventHandler(this.chk_CheckForUpdatesOnStartup_CheckedChanged);
			// 
			// chk_ShowUpdatePromptOnStartup
			// 
			this.chk_ShowUpdatePromptOnStartup.AutoSize = true;
			this.chk_ShowUpdatePromptOnStartup.Checked = true;
			this.chk_ShowUpdatePromptOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_ShowUpdatePromptOnStartup.Location = new System.Drawing.Point(4, 39);
			this.chk_ShowUpdatePromptOnStartup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chk_ShowUpdatePromptOnStartup.Name = "chk_ShowUpdatePromptOnStartup";
			this.chk_ShowUpdatePromptOnStartup.Size = new System.Drawing.Size(269, 24);
			this.chk_ShowUpdatePromptOnStartup.TabIndex = 12;
			this.chk_ShowUpdatePromptOnStartup.Text = "Show Update Prompt On Startup";
			this.chk_ShowUpdatePromptOnStartup.UseVisualStyleBackColor = true;
			this.chk_ShowUpdatePromptOnStartup.CheckedChanged += new System.EventHandler(this.chk_ShowUpdatePromptOnStartup_CheckedChanged);
			// 
			// Preferences
			// 
			this.AcceptButton = this.btn_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(778, 849);
			this.Controls.Add(this.cont_Prefs);
			this.Controls.Add(this.btn_Accept);
			this.Controls.Add(this.btn_Cancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(800, 1000);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(439, 734);
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
			this.interfacePanel.ResumeLayout(false);
			this.interfacePanel.PerformLayout();
			this.grp_zeroEditor.ResumeLayout(false);
			this.grp_zeroEditor.PerformLayout();
			this.grp_editor.ResumeLayout(false);
			this.grp_editor.PerformLayout();
			this.grp_debugger.ResumeLayout(false);
			this.grp_debugger.PerformLayout();
			this.grp_setGameExe.ResumeLayout(false);
			this.grp_setGameExe.PerformLayout();
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
			((System.ComponentModel.ISupportInitialize)(this.num_LogPollingRate)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_LogMaxLineCount)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Panel cont_Prefs;
        private System.Windows.Forms.CheckBox chk_ShowTrayIcon;
        private System.Windows.Forms.CheckBox chk_ShowNotificationPopups;
        private System.Windows.Forms.CheckBox chk_PlayNotificationSounds;
        private System.Windows.Forms.CheckBox chk_AutoDetectStagingDir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel interfacePanel;
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
		private System.Windows.Forms.Label lbl_LogPollingRate;
		private System.Windows.Forms.CheckBox chk_OutputLogToFile;
		private System.Windows.Forms.CheckBox chk_LogPrintTimestamps;
		private System.Windows.Forms.CheckBox chk_CheckForUpdatesOnStartup;
		private System.Windows.Forms.CheckBox chk_AutoSaveEnabled;
		private System.Windows.Forms.CheckBox chk_AutoLoadEnabled;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label lbl_LogMaxLineCount;
		private System.Windows.Forms.NumericUpDown num_LogMaxLineCount;
		private System.Windows.Forms.NumericUpDown num_LogPollingRate;
        private System.Windows.Forms.GroupBox grp_editor;
        private System.Windows.Forms.Button btn_browseEditor;
        private System.Windows.Forms.TextBox txt_editor;
        private System.Windows.Forms.GroupBox grp_debugger;
        private System.Windows.Forms.Button btn_browseDebuggerExe;
        private System.Windows.Forms.TextBox txt_gameDebugger;
        private System.Windows.Forms.GroupBox grp_setGameExe;
        private System.Windows.Forms.Button btn_browseGameExe;
        private System.Windows.Forms.TextBox txt_gameExe;
		private System.Windows.Forms.Label lab_debuggerArgs;
		private System.Windows.Forms.TextBox txt_debuggerArgs;
		private System.Windows.Forms.Label lab_gameExeArgs;
		private System.Windows.Forms.TextBox txt_gameArgs;
		private System.Windows.Forms.GroupBox grp_zeroEditor;
		private System.Windows.Forms.Button btn_browseZeroEditor;
		private System.Windows.Forms.TextBox txt_zeroEditor;
	}
}