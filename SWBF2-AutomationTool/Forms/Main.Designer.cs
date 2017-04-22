namespace AutomationTool
{
    partial class AutomationTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutomationTool));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Run = new System.Windows.Forms.Button();
            this.btn_AddFiles = new System.Windows.Forms.Button();
            this.openDlg_AddFilesPrompt = new System.Windows.Forms.OpenFileDialog();
            this.btn_RemoveFile = new System.Windows.Forms.Button();
            this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
            this.btn_ClearLog = new System.Windows.Forms.Button();
            this.btn_CopyLog = new System.Windows.Forms.Button();
            this.btn_SaveLog = new System.Windows.Forms.Button();
            this.btn_AddFolders = new System.Windows.Forms.Button();
            this.btn_AddProject = new System.Windows.Forms.Button();
            this.btn_RemoveAllFiles = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_SetGamePath = new System.Windows.Forms.Button();
            this.pan_MungedFilesEdit = new System.Windows.Forms.Panel();
            this.status_MungedFilesEdit = new System.Windows.Forms.StatusStrip();
            this.label_MungedFilesEdit = new System.Windows.Forms.ToolStripStatusLabel();
            this.text_MungedFilesEdit = new System.Windows.Forms.RichTextBox();
            this.text_OutputLog = new System.Windows.Forms.RichTextBox();
            this.lbl_OutputLogLines = new System.Windows.Forms.Label();
            this.saveDlg_SaveLogPrompt = new System.Windows.Forms.SaveFileDialog();
            this.cont_Panels = new System.Windows.Forms.SplitContainer();
            this.data_Files = new System.Windows.Forms.DataGridView();
            this.lbl_OutputLogChars = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmenu_TrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmenu_TrayIcon_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenu_TrayIcon_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.openDlg_SelectGameExePrompt = new System.Windows.Forms.OpenFileDialog();
            this.cmenu_Text = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.col_Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Copy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_File = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_FileBrowse = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_Staging = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_StagingBrowse = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_MungeDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MungedFiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MungedFilesEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_IsMungeScript = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsValid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pan_MungedFilesEdit.SuspendLayout();
            this.status_MungedFilesEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cont_Panels)).BeginInit();
            this.cont_Panels.Panel1.SuspendLayout();
            this.cont_Panels.Panel2.SuspendLayout();
            this.cont_Panels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_Files)).BeginInit();
            this.cmenu_TrayIcon.SuspendLayout();
            this.cmenu_Text.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Run
            // 
            this.btn_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Run.Location = new System.Drawing.Point(669, 12);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(102, 23);
            this.btn_Run.TabIndex = 0;
            this.btn_Run.Text = "Run";
            this.FormTooltips.SetToolTip(this.btn_Run, "Executes each file in the list in order.");
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // btn_AddFiles
            // 
            this.btn_AddFiles.AccessibleDescription = "";
            this.btn_AddFiles.AllowDrop = true;
            this.btn_AddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddFiles.Location = new System.Drawing.Point(669, 70);
            this.btn_AddFiles.Name = "btn_AddFiles";
            this.btn_AddFiles.Size = new System.Drawing.Size(102, 23);
            this.btn_AddFiles.TabIndex = 1;
            this.btn_AddFiles.Tag = "";
            this.btn_AddFiles.Text = "Add Files...";
            this.FormTooltips.SetToolTip(this.btn_AddFiles, "Opens a prompt to add files to the list of files.");
            this.btn_AddFiles.UseVisualStyleBackColor = true;
            this.btn_AddFiles.Click += new System.EventHandler(this.btn_AddFiles_Click);
            // 
            // openDlg_AddFilesPrompt
            // 
            this.openDlg_AddFilesPrompt.Filter = "Batch files|*.bat";
            this.openDlg_AddFilesPrompt.Title = "Select Files";
            this.openDlg_AddFilesPrompt.FileOk += new System.ComponentModel.CancelEventHandler(this.openDlg_AddFilesPrompt_FileOk);
            // 
            // btn_RemoveFile
            // 
            this.btn_RemoveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RemoveFile.Location = new System.Drawing.Point(669, 157);
            this.btn_RemoveFile.Name = "btn_RemoveFile";
            this.btn_RemoveFile.Size = new System.Drawing.Size(102, 23);
            this.btn_RemoveFile.TabIndex = 4;
            this.btn_RemoveFile.Text = "Remove";
            this.FormTooltips.SetToolTip(this.btn_RemoveFile, "Removes the selected file.");
            this.btn_RemoveFile.UseVisualStyleBackColor = true;
            this.btn_RemoveFile.Click += new System.EventHandler(this.btn_RemoveFile_Click);
            // 
            // btn_ClearLog
            // 
            this.btn_ClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ClearLog.Location = new System.Drawing.Point(669, 526);
            this.btn_ClearLog.Name = "btn_ClearLog";
            this.btn_ClearLog.Size = new System.Drawing.Size(102, 23);
            this.btn_ClearLog.TabIndex = 8;
            this.btn_ClearLog.Text = "Clear Log";
            this.FormTooltips.SetToolTip(this.btn_ClearLog, "Clears the contents of the output log.");
            this.btn_ClearLog.UseVisualStyleBackColor = true;
            this.btn_ClearLog.Click += new System.EventHandler(this.btn_ClearLog_Click);
            // 
            // btn_CopyLog
            // 
            this.btn_CopyLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CopyLog.Location = new System.Drawing.Point(669, 468);
            this.btn_CopyLog.Name = "btn_CopyLog";
            this.btn_CopyLog.Size = new System.Drawing.Size(102, 23);
            this.btn_CopyLog.TabIndex = 6;
            this.btn_CopyLog.Text = "Copy Log";
            this.FormTooltips.SetToolTip(this.btn_CopyLog, "Copies the contents of the output log window to the clipboard.");
            this.btn_CopyLog.UseVisualStyleBackColor = true;
            this.btn_CopyLog.Click += new System.EventHandler(this.btn_CopyLog_Click);
            // 
            // btn_SaveLog
            // 
            this.btn_SaveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveLog.Location = new System.Drawing.Point(669, 497);
            this.btn_SaveLog.Name = "btn_SaveLog";
            this.btn_SaveLog.Size = new System.Drawing.Size(102, 23);
            this.btn_SaveLog.TabIndex = 7;
            this.btn_SaveLog.Text = "Save Log As...";
            this.btn_SaveLog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FormTooltips.SetToolTip(this.btn_SaveLog, "Opens a prompt to save the contents of the output log to a new file.");
            this.btn_SaveLog.UseVisualStyleBackColor = true;
            this.btn_SaveLog.Click += new System.EventHandler(this.btn_SaveLog_Click);
            // 
            // btn_AddFolders
            // 
            this.btn_AddFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddFolders.Location = new System.Drawing.Point(669, 99);
            this.btn_AddFolders.Name = "btn_AddFolders";
            this.btn_AddFolders.Size = new System.Drawing.Size(102, 23);
            this.btn_AddFolders.TabIndex = 2;
            this.btn_AddFolders.Text = "Add Folders...";
            this.FormTooltips.SetToolTip(this.btn_AddFolders, "Opens a prompt to add folders containing munge.bat files to the file list.");
            this.btn_AddFolders.UseVisualStyleBackColor = true;
            this.btn_AddFolders.Click += new System.EventHandler(this.btn_AddFolders_Click);
            // 
            // btn_AddProject
            // 
            this.btn_AddProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddProject.Location = new System.Drawing.Point(669, 128);
            this.btn_AddProject.Name = "btn_AddProject";
            this.btn_AddProject.Size = new System.Drawing.Size(102, 23);
            this.btn_AddProject.TabIndex = 3;
            this.btn_AddProject.Text = "Add Project...";
            this.FormTooltips.SetToolTip(this.btn_AddProject, "Opens a prompt to select a project folder whose common munge.bat files will be ad" +
        "ded to the file list.");
            this.btn_AddProject.UseVisualStyleBackColor = true;
            this.btn_AddProject.Click += new System.EventHandler(this.btn_AddProject_Click);
            // 
            // btn_RemoveAllFiles
            // 
            this.btn_RemoveAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RemoveAllFiles.Location = new System.Drawing.Point(669, 186);
            this.btn_RemoveAllFiles.Name = "btn_RemoveAllFiles";
            this.btn_RemoveAllFiles.Size = new System.Drawing.Size(102, 23);
            this.btn_RemoveAllFiles.TabIndex = 5;
            this.btn_RemoveAllFiles.Text = "Remove All";
            this.btn_RemoveAllFiles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.FormTooltips.SetToolTip(this.btn_RemoveAllFiles, "Removes all files from the file list.");
            this.btn_RemoveAllFiles.UseVisualStyleBackColor = true;
            this.btn_RemoveAllFiles.Click += new System.EventHandler(this.btn_RemoveAllFiles_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Enabled = false;
            this.btn_Cancel.Location = new System.Drawing.Point(669, 41);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(102, 23);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.Text = "Cancel";
            this.FormTooltips.SetToolTip(this.btn_Cancel, "Stops processing files. WARNING: Canceling a munge is strongly NOT recommended.");
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_SetGamePath
            // 
            this.btn_SetGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SetGamePath.Location = new System.Drawing.Point(669, 244);
            this.btn_SetGamePath.Name = "btn_SetGamePath";
            this.btn_SetGamePath.Size = new System.Drawing.Size(102, 23);
            this.btn_SetGamePath.TabIndex = 15;
            this.btn_SetGamePath.Text = "Set Game Path...";
            this.FormTooltips.SetToolTip(this.btn_SetGamePath, "Opens a prompt to point Zero Munge to Star Wars Battlefront II\'s GameData directo" +
        "ry.");
            this.btn_SetGamePath.UseVisualStyleBackColor = true;
            this.btn_SetGamePath.Click += new System.EventHandler(this.btn_SetGamePath_Click);
            // 
            // pan_MungedFilesEdit
            // 
            this.pan_MungedFilesEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_MungedFilesEdit.Controls.Add(this.status_MungedFilesEdit);
            this.pan_MungedFilesEdit.Controls.Add(this.text_MungedFilesEdit);
            this.pan_MungedFilesEdit.Location = new System.Drawing.Point(775, 300);
            this.pan_MungedFilesEdit.Name = "pan_MungedFilesEdit";
            this.pan_MungedFilesEdit.Size = new System.Drawing.Size(360, 170);
            this.pan_MungedFilesEdit.TabIndex = 17;
            this.FormTooltips.SetToolTip(this.pan_MungedFilesEdit, "Enter each file name on a new line.");
            this.pan_MungedFilesEdit.Visible = false;
            // 
            // status_MungedFilesEdit
            // 
            this.status_MungedFilesEdit.BackColor = System.Drawing.SystemColors.Control;
            this.status_MungedFilesEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_MungedFilesEdit});
            this.status_MungedFilesEdit.Location = new System.Drawing.Point(0, 146);
            this.status_MungedFilesEdit.Name = "status_MungedFilesEdit";
            this.status_MungedFilesEdit.Size = new System.Drawing.Size(358, 22);
            this.status_MungedFilesEdit.SizingGrip = false;
            this.status_MungedFilesEdit.TabIndex = 6;
            // 
            // label_MungedFilesEdit
            // 
            this.label_MungedFilesEdit.Name = "label_MungedFilesEdit";
            this.label_MungedFilesEdit.Size = new System.Drawing.Size(334, 17);
            this.label_MungedFilesEdit.Text = "Press Enter to begin a new line. Press Ctrl+Enter to accept text.";
            // 
            // text_MungedFilesEdit
            // 
            this.text_MungedFilesEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_MungedFilesEdit.BackColor = System.Drawing.SystemColors.Info;
            this.text_MungedFilesEdit.ContextMenuStrip = this.cmenu_Text;
            this.text_MungedFilesEdit.Location = new System.Drawing.Point(0, 0);
            this.text_MungedFilesEdit.Name = "text_MungedFilesEdit";
            this.text_MungedFilesEdit.Size = new System.Drawing.Size(358, 143);
            this.text_MungedFilesEdit.TabIndex = 5;
            this.text_MungedFilesEdit.Text = "";
            this.text_MungedFilesEdit.WordWrap = false;
            // 
            // text_OutputLog
            // 
            this.text_OutputLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_OutputLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_OutputLog.ForeColor = System.Drawing.Color.Black;
            this.text_OutputLog.Location = new System.Drawing.Point(0, 0);
            this.text_OutputLog.MaxLength = 20000;
            this.text_OutputLog.Name = "text_OutputLog";
            this.text_OutputLog.ReadOnly = true;
            this.text_OutputLog.Size = new System.Drawing.Size(651, 286);
            this.text_OutputLog.TabIndex = 5;
            this.text_OutputLog.TabStop = false;
            this.text_OutputLog.Text = "";
            this.text_OutputLog.WordWrap = false;
            this.text_OutputLog.TextChanged += new System.EventHandler(this.text_OutputLog_TextChanged);
            // 
            // lbl_OutputLogLines
            // 
            this.lbl_OutputLogLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_OutputLogLines.AutoSize = true;
            this.lbl_OutputLogLines.Location = new System.Drawing.Point(666, 447);
            this.lbl_OutputLogLines.Name = "lbl_OutputLogLines";
            this.lbl_OutputLogLines.Size = new System.Drawing.Size(44, 13);
            this.lbl_OutputLogLines.TabIndex = 6;
            this.lbl_OutputLogLines.Text = "Lines: 0";
            // 
            // saveDlg_SaveLogPrompt
            // 
            this.saveDlg_SaveLogPrompt.DefaultExt = "log";
            this.saveDlg_SaveLogPrompt.FileName = "ZeroMunge_OutputLog";
            this.saveDlg_SaveLogPrompt.Filter = "Log files|*.log";
            this.saveDlg_SaveLogPrompt.Title = "Save Log As";
            this.saveDlg_SaveLogPrompt.FileOk += new System.ComponentModel.CancelEventHandler(this.saveDlg_SaveLogPrompt_FileOk);
            // 
            // cont_Panels
            // 
            this.cont_Panels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cont_Panels.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.cont_Panels.Location = new System.Drawing.Point(12, 12);
            this.cont_Panels.Name = "cont_Panels";
            this.cont_Panels.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // cont_Panels.Panel1
            // 
            this.cont_Panels.Panel1.Controls.Add(this.data_Files);
            this.cont_Panels.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.cont_Panels.Panel1MinSize = 139;
            // 
            // cont_Panels.Panel2
            // 
            this.cont_Panels.Panel2.Controls.Add(this.text_OutputLog);
            this.cont_Panels.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.cont_Panels.Panel2MinSize = 150;
            this.cont_Panels.Size = new System.Drawing.Size(651, 537);
            this.cont_Panels.SplitterDistance = 243;
            this.cont_Panels.SplitterIncrement = 15;
            this.cont_Panels.SplitterWidth = 8;
            this.cont_Panels.TabIndex = 13;
            // 
            // data_Files
            // 
            this.data_Files.AllowUserToResizeRows = false;
            this.data_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.data_Files.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Enabled,
            this.col_Copy,
            this.col_File,
            this.col_FileBrowse,
            this.col_Staging,
            this.col_StagingBrowse,
            this.col_MungeDir,
            this.col_MungedFiles,
            this.col_MungedFilesEdit,
            this.col_IsMungeScript,
            this.IsValid});
            this.data_Files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_Files.Location = new System.Drawing.Point(0, 0);
            this.data_Files.Name = "data_Files";
            this.data_Files.RowHeadersWidth = 31;
            this.data_Files.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.data_Files.Size = new System.Drawing.Size(651, 243);
            this.data_Files.TabIndex = 4;
            this.data_Files.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_Files_CellClick);
            this.data_Files.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_Files_CellContentClick);
            this.data_Files.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_Files_CellValueChanged);
            this.data_Files.KeyDown += new System.Windows.Forms.KeyEventHandler(this.data_Files_KeyDown);
            // 
            // lbl_OutputLogChars
            // 
            this.lbl_OutputLogChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_OutputLogChars.AutoSize = true;
            this.lbl_OutputLogChars.Location = new System.Drawing.Point(666, 429);
            this.lbl_OutputLogChars.Name = "lbl_OutputLogChars";
            this.lbl_OutputLogChars.Size = new System.Drawing.Size(52, 13);
            this.lbl_OutputLogChars.TabIndex = 14;
            this.lbl_OutputLogChars.Text = "Length: 0";
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.cmenu_TrayIcon;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Zero Munge";
            this.trayIcon.Visible = true;
            this.trayIcon.BalloonTipClicked += new System.EventHandler(this.trayIcon_BalloonTipClicked);
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // cmenu_TrayIcon
            // 
            this.cmenu_TrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenu_TrayIcon_Open,
            this.cmenu_TrayIcon_Quit});
            this.cmenu_TrayIcon.Name = "cmenu_TrayIcon";
            this.cmenu_TrayIcon.Size = new System.Drawing.Size(104, 48);
            // 
            // cmenu_TrayIcon_Open
            // 
            this.cmenu_TrayIcon_Open.Name = "cmenu_TrayIcon_Open";
            this.cmenu_TrayIcon_Open.Size = new System.Drawing.Size(103, 22);
            this.cmenu_TrayIcon_Open.Text = "Open";
            this.cmenu_TrayIcon_Open.Click += new System.EventHandler(this.cmenu_TrayIcon_Open_Click);
            // 
            // cmenu_TrayIcon_Quit
            // 
            this.cmenu_TrayIcon_Quit.Name = "cmenu_TrayIcon_Quit";
            this.cmenu_TrayIcon_Quit.Size = new System.Drawing.Size(103, 22);
            this.cmenu_TrayIcon_Quit.Text = "Quit";
            this.cmenu_TrayIcon_Quit.Click += new System.EventHandler(this.cmenu_TrayIcon_Quit_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(670, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openDlg_SelectGameExePrompt
            // 
            this.openDlg_SelectGameExePrompt.Filter = "BattlefrontII.exe|BattlefrontII.exe";
            this.openDlg_SelectGameExePrompt.Title = "Select Game Executable";
            this.openDlg_SelectGameExePrompt.FileOk += new System.ComponentModel.CancelEventHandler(this.openDlg_SelectGameExePrompt_FileOk);
            // 
            // cmenu_Text
            // 
            this.cmenu_Text.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1,
            this.selectAllToolStripMenuItem});
            this.cmenu_Text.Name = "cmenu_Text";
            this.cmenu_Text.Size = new System.Drawing.Size(165, 98);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // col_Enabled
            // 
            this.col_Enabled.HeaderText = "Process";
            this.col_Enabled.Name = "col_Enabled";
            this.col_Enabled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_Enabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_Enabled.ToolTipText = "If checked, executes the batch script located at the specified file path.";
            this.col_Enabled.Width = 53;
            // 
            // col_Copy
            // 
            this.col_Copy.HeaderText = "Copy";
            this.col_Copy.Name = "col_Copy";
            this.col_Copy.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_Copy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_Copy.ToolTipText = "If checked, copies the specified munged files to the staging directory after the " +
    "batch script has finished executing.";
            this.col_Copy.Width = 37;
            // 
            // col_File
            // 
            this.col_File.HeaderText = "File Path";
            this.col_File.MinimumWidth = 100;
            this.col_File.Name = "col_File";
            this.col_File.ToolTipText = "File path of the batch script to execute.";
            this.col_File.Width = 265;
            // 
            // col_FileBrowse
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_FileBrowse.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_FileBrowse.HeaderText = "";
            this.col_FileBrowse.Name = "col_FileBrowse";
            this.col_FileBrowse.ReadOnly = true;
            this.col_FileBrowse.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_FileBrowse.Text = "...";
            this.col_FileBrowse.ToolTipText = "Open a prompt to browse for a new batch script.";
            this.col_FileBrowse.UseColumnTextForButtonValue = true;
            this.col_FileBrowse.Width = 30;
            // 
            // col_Staging
            // 
            this.col_Staging.HeaderText = "Staging Directory";
            this.col_Staging.MinimumWidth = 100;
            this.col_Staging.Name = "col_Staging";
            this.col_Staging.ToolTipText = "Directory to which the munged files are copied after the batch script has finishe" +
    "d executing.";
            this.col_Staging.Width = 265;
            // 
            // col_StagingBrowse
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_StagingBrowse.DefaultCellStyle = dataGridViewCellStyle10;
            this.col_StagingBrowse.HeaderText = "";
            this.col_StagingBrowse.Name = "col_StagingBrowse";
            this.col_StagingBrowse.ReadOnly = true;
            this.col_StagingBrowse.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_StagingBrowse.Text = "...";
            this.col_StagingBrowse.ToolTipText = "Open a prompt to browse for a new staging directory.";
            this.col_StagingBrowse.UseColumnTextForButtonValue = true;
            this.col_StagingBrowse.Width = 30;
            // 
            // col_MungeDir
            // 
            this.col_MungeDir.HeaderText = "Munge Directory";
            this.col_MungeDir.MinimumWidth = 70;
            this.col_MungeDir.Name = "col_MungeDir";
            this.col_MungeDir.Width = 265;
            // 
            // col_MungedFiles
            // 
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_MungedFiles.DefaultCellStyle = dataGridViewCellStyle11;
            this.col_MungedFiles.HeaderText = "Munged Files";
            this.col_MungedFiles.MinimumWidth = 100;
            this.col_MungedFiles.Name = "col_MungedFiles";
            this.col_MungedFiles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_MungedFiles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_MungedFiles.ToolTipText = "Names of files that will be copied to the staging directory after the batch scrip" +
    "t has finished executing. Separate each file name into its own line.";
            this.col_MungedFiles.Width = 170;
            // 
            // col_MungedFilesEdit
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_MungedFilesEdit.DefaultCellStyle = dataGridViewCellStyle12;
            this.col_MungedFilesEdit.HeaderText = "";
            this.col_MungedFilesEdit.Name = "col_MungedFilesEdit";
            this.col_MungedFilesEdit.ReadOnly = true;
            this.col_MungedFilesEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_MungedFilesEdit.Text = "▼";
            this.col_MungedFilesEdit.ToolTipText = "Open a popup to add/remove/edit names of munged files.";
            this.col_MungedFilesEdit.UseColumnTextForButtonValue = true;
            this.col_MungedFilesEdit.Width = 20;
            // 
            // col_IsMungeScript
            // 
            this.col_IsMungeScript.HeaderText = "IsMungeScript";
            this.col_IsMungeScript.Name = "col_IsMungeScript";
            this.col_IsMungeScript.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_IsMungeScript.Width = 50;
            // 
            // IsValid
            // 
            this.IsValid.HeaderText = "IsValid";
            this.IsValid.Name = "IsValid";
            this.IsValid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsValid.Width = 50;
            // 
            // AutomationTool
            // 
            this.AcceptButton = this.btn_Run;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pan_MungedFilesEdit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_SetGamePath);
            this.Controls.Add(this.lbl_OutputLogChars);
            this.Controls.Add(this.cont_Panels);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_RemoveAllFiles);
            this.Controls.Add(this.btn_AddProject);
            this.Controls.Add(this.btn_AddFolders);
            this.Controls.Add(this.btn_SaveLog);
            this.Controls.Add(this.btn_CopyLog);
            this.Controls.Add(this.btn_ClearLog);
            this.Controls.Add(this.lbl_OutputLogLines);
            this.Controls.Add(this.btn_RemoveFile);
            this.Controls.Add(this.btn_AddFiles);
            this.Controls.Add(this.btn_Run);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AutomationTool";
            this.Text = "Zero Munge";
            this.Load += new System.EventHandler(this.AutomationTool_Load);
            this.Resize += new System.EventHandler(this.AutomationTool_Resize);
            this.pan_MungedFilesEdit.ResumeLayout(false);
            this.pan_MungedFilesEdit.PerformLayout();
            this.status_MungedFilesEdit.ResumeLayout(false);
            this.status_MungedFilesEdit.PerformLayout();
            this.cont_Panels.Panel1.ResumeLayout(false);
            this.cont_Panels.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cont_Panels)).EndInit();
            this.cont_Panels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_Files)).EndInit();
            this.cmenu_TrayIcon.ResumeLayout(false);
            this.cmenu_Text.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer cont_Panels;
        private System.Windows.Forms.ToolStripMenuItem cmenu_TrayIcon_Open;
        private System.Windows.Forms.ToolStripMenuItem cmenu_TrayIcon_Quit;
        public System.Windows.Forms.Button btn_Run;
        public System.Windows.Forms.Button btn_AddFiles;
        public System.Windows.Forms.OpenFileDialog openDlg_AddFilesPrompt;
        public System.Windows.Forms.Button btn_RemoveFile;
        public System.Windows.Forms.ToolTip FormTooltips;
        public System.Windows.Forms.RichTextBox text_OutputLog;
        public System.Windows.Forms.Label lbl_OutputLogLines;
        public System.Windows.Forms.Button btn_ClearLog;
        public System.Windows.Forms.Button btn_CopyLog;
        public System.Windows.Forms.Button btn_SaveLog;
        public System.Windows.Forms.SaveFileDialog saveDlg_SaveLogPrompt;
        public System.Windows.Forms.Button btn_AddFolders;
        public System.Windows.Forms.Button btn_AddProject;
        public System.Windows.Forms.Button btn_RemoveAllFiles;
        public System.Windows.Forms.Button btn_Cancel;
        public System.Windows.Forms.Label lbl_OutputLogChars;
        public System.Windows.Forms.NotifyIcon trayIcon;
        public System.Windows.Forms.ContextMenuStrip cmenu_TrayIcon;
        public System.Windows.Forms.CheckedListBox clist_Files;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView data_Files;
        private System.Windows.Forms.Button btn_SetGamePath;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.OpenFileDialog openDlg_SelectGameExePrompt;
        private System.Windows.Forms.RichTextBox text_MungedFilesEdit;
        private System.Windows.Forms.Panel pan_MungedFilesEdit;
        private System.Windows.Forms.StatusStrip status_MungedFilesEdit;
        private System.Windows.Forms.ToolStripStatusLabel label_MungedFilesEdit;
        private System.Windows.Forms.ContextMenuStrip cmenu_Text;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Enabled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Copy;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_File;
        private System.Windows.Forms.DataGridViewButtonColumn col_FileBrowse;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Staging;
        private System.Windows.Forms.DataGridViewButtonColumn col_StagingBrowse;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MungeDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MungedFiles;
        private System.Windows.Forms.DataGridViewButtonColumn col_MungedFilesEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_IsMungeScript;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsValid;
    }
}

