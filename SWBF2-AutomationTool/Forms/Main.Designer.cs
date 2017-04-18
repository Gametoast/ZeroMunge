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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.col_Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_File = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_FileBrowse = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_Staging = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_StagingBrowse = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_MungeDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MungedFiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MungedFilesEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.text_MungedFilesEdit_TEMPLATE = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cont_Panels)).BeginInit();
            this.cont_Panels.Panel1.SuspendLayout();
            this.cont_Panels.Panel2.SuspendLayout();
            this.cont_Panels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_Files)).BeginInit();
            this.cmenu_TrayIcon.SuspendLayout();
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
            this.col_File,
            this.col_FileBrowse,
            this.col_Staging,
            this.col_StagingBrowse,
            this.col_MungeDir,
            this.col_MungedFiles,
            this.col_MungedFilesEdit});
            this.data_Files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_Files.Location = new System.Drawing.Point(0, 0);
            this.data_Files.Name = "data_Files";
            this.data_Files.RowHeadersWidth = 31;
            this.data_Files.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.data_Files.ShowEditingIcon = false;
            this.data_Files.Size = new System.Drawing.Size(651, 243);
            this.data_Files.TabIndex = 4;
            this.data_Files.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_Files_CellClick);
            this.data_Files.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_Files_CellContentClick);
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
            // col_Enabled
            // 
            this.col_Enabled.HeaderText = "";
            this.col_Enabled.Name = "col_Enabled";
            this.col_Enabled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_Enabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_Enabled.Width = 22;
            // 
            // col_File
            // 
            this.col_File.HeaderText = "Munge Script Path";
            this.col_File.MinimumWidth = 100;
            this.col_File.Name = "col_File";
            this.col_File.Width = 265;
            // 
            // col_FileBrowse
            // 
            dataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle69.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_FileBrowse.DefaultCellStyle = dataGridViewCellStyle69;
            this.col_FileBrowse.HeaderText = "";
            this.col_FileBrowse.Name = "col_FileBrowse";
            this.col_FileBrowse.ReadOnly = true;
            this.col_FileBrowse.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_FileBrowse.Text = "...";
            this.col_FileBrowse.UseColumnTextForButtonValue = true;
            this.col_FileBrowse.Width = 30;
            // 
            // col_Staging
            // 
            this.col_Staging.HeaderText = "Staging Directory";
            this.col_Staging.MinimumWidth = 100;
            this.col_Staging.Name = "col_Staging";
            this.col_Staging.Width = 265;
            // 
            // col_StagingBrowse
            // 
            dataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle70.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_StagingBrowse.DefaultCellStyle = dataGridViewCellStyle70;
            this.col_StagingBrowse.HeaderText = "";
            this.col_StagingBrowse.Name = "col_StagingBrowse";
            this.col_StagingBrowse.ReadOnly = true;
            this.col_StagingBrowse.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_StagingBrowse.Text = "...";
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
            dataGridViewCellStyle71.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_MungedFiles.DefaultCellStyle = dataGridViewCellStyle71;
            this.col_MungedFiles.HeaderText = "Munged Files";
            this.col_MungedFiles.MinimumWidth = 100;
            this.col_MungedFiles.Name = "col_MungedFiles";
            this.col_MungedFiles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_MungedFiles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_MungedFiles.Width = 170;
            // 
            // col_MungedFilesEdit
            // 
            dataGridViewCellStyle72.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle72.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_MungedFilesEdit.DefaultCellStyle = dataGridViewCellStyle72;
            this.col_MungedFilesEdit.HeaderText = "";
            this.col_MungedFilesEdit.Name = "col_MungedFilesEdit";
            this.col_MungedFilesEdit.ReadOnly = true;
            this.col_MungedFilesEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_MungedFilesEdit.Text = "...";
            this.col_MungedFilesEdit.UseColumnTextForButtonValue = true;
            this.col_MungedFilesEdit.Width = 30;
            // 
            // text_MungedFilesEdit_TEMPLATE
            // 
            this.text_MungedFilesEdit_TEMPLATE.BackColor = System.Drawing.SystemColors.Info;
            this.text_MungedFilesEdit_TEMPLATE.Location = new System.Drawing.Point(0, 0);
            this.text_MungedFilesEdit_TEMPLATE.Name = "text_MungedFilesEdit_TEMPLATE";
            this.text_MungedFilesEdit_TEMPLATE.Size = new System.Drawing.Size(220, 120);
            this.text_MungedFilesEdit_TEMPLATE.TabIndex = 5;
            this.text_MungedFilesEdit_TEMPLATE.Text = "";
            this.text_MungedFilesEdit_TEMPLATE.Visible = false;
            this.text_MungedFilesEdit_TEMPLATE.WordWrap = false;
            // 
            // AutomationTool
            // 
            this.AcceptButton = this.btn_Run;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.text_MungedFilesEdit_TEMPLATE);
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
            this.cont_Panels.Panel1.ResumeLayout(false);
            this.cont_Panels.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cont_Panels)).EndInit();
            this.cont_Panels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_Files)).EndInit();
            this.cmenu_TrayIcon.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Enabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_File;
        private System.Windows.Forms.DataGridViewButtonColumn col_FileBrowse;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Staging;
        private System.Windows.Forms.DataGridViewButtonColumn col_StagingBrowse;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MungeDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MungedFiles;
        private System.Windows.Forms.DataGridViewButtonColumn col_MungedFilesEdit;
        private System.Windows.Forms.RichTextBox text_MungedFilesEdit_TEMPLATE;
    }
}

