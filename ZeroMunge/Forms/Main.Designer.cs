namespace ZeroMunge
{
	partial class ZeroMunge
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroMunge));
			this.btn_Run = new System.Windows.Forms.Button();
			this.btn_AddFiles = new System.Windows.Forms.Button();
			this.openDlg_AddFilesPrompt = new System.Windows.Forms.OpenFileDialog();
			this.btn_RemoveFile = new System.Windows.Forms.Button();
			this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
			this.pan_MungedFilesEdit = new System.Windows.Forms.Panel();
			this.status_MungedFilesEdit = new System.Windows.Forms.StatusStrip();
			this.label_MungedFilesEdit = new System.Windows.Forms.ToolStripStatusLabel();
			this.text_MungedFilesEdit = new System.Windows.Forms.RichTextBox();
			this.cmenu_Text = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_ClearLog = new System.Windows.Forms.Button();
			this.btn_OpenMungeLog = new System.Windows.Forms.Button();
			this.btn_SaveLog = new System.Windows.Forms.Button();
			this.btn_AddFolders = new System.Windows.Forms.Button();
			this.btn_AddProject = new System.Windows.Forms.Button();
			this.btn_RemoveAllFiles = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_SetGamePath = new System.Windows.Forms.Button();
			this.text_OutputLog = new System.Windows.Forms.RichTextBox();
			this.saveDlg_SaveLogPrompt = new System.Windows.Forms.SaveFileDialog();
			this.cont_Panels = new System.Windows.Forms.SplitContainer();
			this.mungePanel = new AltUIMungePanel();
			this.data_Files = new System.Windows.Forms.DataGridView();
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
			this.col_IsValid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.cmenu_dataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menu_openProjectFolderInEditor = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openBuildCmd = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openStagingDirectory = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openProjectFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.cmenu_TrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmenu_TrayIcon_Run = new System.Windows.Forms.ToolStripMenuItem();
			this.cmenu_TrayIcon_Cancel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.cmenu_TrayIcon_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.cmenu_TrayIcon_Quit = new System.Windows.Forms.ToolStripMenuItem();
			this.button2 = new System.Windows.Forms.Button();
			this.menu_MainForm = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_alternateUI = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_easyFilePickerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_addFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_addProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_logSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openMungeLog = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openLog = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_copyLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_saveLogAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_openGameLog = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openModToolsExe = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_launchZeroEditor = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openGameExe = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openGameFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openProjectFolder2 = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_launchPPSSPP = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_debugMission = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_createSideMungeFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_createWorldMungeFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_fixWorldMungeScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_fixSoundMungeFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_modifyMungedSoundFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_addMission = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_setGamePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_setPreferredEditor = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_prefsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_strip_platform = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_pcPlatform = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_xboxPlatform = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_ps2Platform = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_viewChangelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_viewLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_viewReadmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_provideFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_provideSuggestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_viewOpenIssuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_gametoastForums = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_Battlefront2API = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_gametoastGithub = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flp_FileButtons = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_EasyFilePicker = new System.Windows.Forms.Button();
			this.btn_clean = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.flp_LogButtons = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_OpenLog = new System.Windows.Forms.Button();
			this.saveDlg_SaveFileListPrompt = new System.Windows.Forms.SaveFileDialog();
			this.openDlg_OpenFileListPrompt = new System.Windows.Forms.OpenFileDialog();
			this.openDlg_CreateSideMungeFolderPrompt = new System.Windows.Forms.OpenFileDialog();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.stat_JobStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.stat_UpdateLink = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.stat_LogLength = new System.Windows.Forms.ToolStripStatusLabel();
			this.stat_LogLines = new System.Windows.Forms.ToolStripStatusLabel();
			this.openDlg_CreateWorldMungeFolderPrompt = new System.Windows.Forms.OpenFileDialog();
			this.pan_MungedFilesEdit.SuspendLayout();
			this.status_MungedFilesEdit.SuspendLayout();
			this.cmenu_Text.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cont_Panels)).BeginInit();
			this.cont_Panels.Panel1.SuspendLayout();
			this.cont_Panels.Panel2.SuspendLayout();
			this.cont_Panels.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.data_Files)).BeginInit();
			this.cmenu_dataGrid.SuspendLayout();
			this.cmenu_TrayIcon.SuspendLayout();
			this.menu_MainForm.SuspendLayout();
			this.flp_FileButtons.SuspendLayout();
			this.flp_LogButtons.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Run
			// 
			this.btn_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Run.Location = new System.Drawing.Point(0, 5);
			this.btn_Run.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_Run.Name = "btn_Run";
			this.btn_Run.Size = new System.Drawing.Size(153, 35);
			this.btn_Run.TabIndex = 0;
			this.btn_Run.Text = "Run";
			this.btn_Run.UseVisualStyleBackColor = true;
			this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
			// 
			// btn_AddFiles
			// 
			this.btn_AddFiles.AccessibleDescription = "";
			this.btn_AddFiles.AllowDrop = true;
			this.btn_AddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_AddFiles.Location = new System.Drawing.Point(0, 140);
			this.btn_AddFiles.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_AddFiles.Name = "btn_AddFiles";
			this.btn_AddFiles.Size = new System.Drawing.Size(153, 35);
			this.btn_AddFiles.TabIndex = 2;
			this.btn_AddFiles.Tag = "";
			this.btn_AddFiles.Text = "Add Files...";
			this.btn_AddFiles.UseVisualStyleBackColor = true;
			this.btn_AddFiles.Click += new System.EventHandler(this.btn_AddFiles_Click);
			// 
			// openDlg_AddFilesPrompt
			// 
			this.openDlg_AddFilesPrompt.Filter = "Supported files|*.bat;*.req";
			this.openDlg_AddFilesPrompt.Multiselect = true;
			this.openDlg_AddFilesPrompt.Title = "Select Files";
			this.openDlg_AddFilesPrompt.FileOk += new System.ComponentModel.CancelEventHandler(this.openDlg_AddFilesPrompt_FileOk);
			// 
			// btn_RemoveFile
			// 
			this.btn_RemoveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_RemoveFile.Location = new System.Drawing.Point(0, 275);
			this.btn_RemoveFile.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_RemoveFile.Name = "btn_RemoveFile";
			this.btn_RemoveFile.Size = new System.Drawing.Size(153, 35);
			this.btn_RemoveFile.TabIndex = 5;
			this.btn_RemoveFile.Text = "Remove";
			this.btn_RemoveFile.UseVisualStyleBackColor = true;
			this.btn_RemoveFile.Click += new System.EventHandler(this.btn_RemoveFile_Click);
			// 
			// pan_MungedFilesEdit
			// 
			this.pan_MungedFilesEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pan_MungedFilesEdit.Controls.Add(this.status_MungedFilesEdit);
			this.pan_MungedFilesEdit.Controls.Add(this.text_MungedFilesEdit);
			this.pan_MungedFilesEdit.Location = new System.Drawing.Point(1162, 462);
			this.pan_MungedFilesEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pan_MungedFilesEdit.Name = "pan_MungedFilesEdit";
			this.pan_MungedFilesEdit.Size = new System.Drawing.Size(539, 260);
			this.pan_MungedFilesEdit.TabIndex = 17;
			this.FormTooltips.SetToolTip(this.pan_MungedFilesEdit, "Enter each file name on a new line.");
			this.pan_MungedFilesEdit.Visible = false;
			// 
			// status_MungedFilesEdit
			// 
			this.status_MungedFilesEdit.BackColor = System.Drawing.SystemColors.Control;
			this.status_MungedFilesEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.status_MungedFilesEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_MungedFilesEdit});
			this.status_MungedFilesEdit.Location = new System.Drawing.Point(0, 226);
			this.status_MungedFilesEdit.Name = "status_MungedFilesEdit";
			this.status_MungedFilesEdit.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
			this.status_MungedFilesEdit.Size = new System.Drawing.Size(537, 32);
			this.status_MungedFilesEdit.SizingGrip = false;
			this.status_MungedFilesEdit.TabIndex = 6;
			// 
			// label_MungedFilesEdit
			// 
			this.label_MungedFilesEdit.Name = "label_MungedFilesEdit";
			this.label_MungedFilesEdit.Size = new System.Drawing.Size(503, 25);
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
			this.text_MungedFilesEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.text_MungedFilesEdit.Name = "text_MungedFilesEdit";
			this.text_MungedFilesEdit.Size = new System.Drawing.Size(535, 218);
			this.text_MungedFilesEdit.TabIndex = 5;
			this.text_MungedFilesEdit.Text = "";
			this.text_MungedFilesEdit.WordWrap = false;
			this.text_MungedFilesEdit.Enter += new System.EventHandler(this.text_MungedFilesEdit_Enter);
			this.text_MungedFilesEdit.Leave += new System.EventHandler(this.text_MungedFilesEdit_Leave);
			// 
			// cmenu_Text
			// 
			this.cmenu_Text.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.cmenu_Text.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1,
            this.selectAllToolStripMenuItem});
			this.cmenu_Text.Name = "cmenu_Text";
			this.cmenu_Text.Size = new System.Drawing.Size(219, 138);
			this.cmenu_Text.Opened += new System.EventHandler(this.cmenu_Text_Opened);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(218, 32);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(218, 32);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(218, 32);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(218, 32);
			this.selectAllToolStripMenuItem.Text = "Select All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
			// 
			// btn_ClearLog
			// 
			this.btn_ClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_ClearLog.Location = new System.Drawing.Point(0, 148);
			this.btn_ClearLog.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_ClearLog.Name = "btn_ClearLog";
			this.btn_ClearLog.Size = new System.Drawing.Size(153, 35);
			this.btn_ClearLog.TabIndex = 11;
			this.btn_ClearLog.Text = "Clear Log";
			this.btn_ClearLog.UseVisualStyleBackColor = true;
			this.btn_ClearLog.Click += new System.EventHandler(this.btn_ClearLog_Click);
			// 
			// btn_OpenMungeLog
			// 
			this.btn_OpenMungeLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_OpenMungeLog.Location = new System.Drawing.Point(0, 13);
			this.btn_OpenMungeLog.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_OpenMungeLog.Name = "btn_OpenMungeLog";
			this.btn_OpenMungeLog.Size = new System.Drawing.Size(153, 35);
			this.btn_OpenMungeLog.TabIndex = 9;
			this.btn_OpenMungeLog.Text = "Open Munge Log";
			this.btn_OpenMungeLog.UseVisualStyleBackColor = true;
			this.btn_OpenMungeLog.Click += new System.EventHandler(this.btn_OpenMungeLog_Click);
			// 
			// btn_SaveLog
			// 
			this.btn_SaveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_SaveLog.Location = new System.Drawing.Point(0, 103);
			this.btn_SaveLog.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_SaveLog.Name = "btn_SaveLog";
			this.btn_SaveLog.Size = new System.Drawing.Size(153, 35);
			this.btn_SaveLog.TabIndex = 10;
			this.btn_SaveLog.Text = "Save Log As...";
			this.btn_SaveLog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btn_SaveLog.UseVisualStyleBackColor = true;
			this.btn_SaveLog.Click += new System.EventHandler(this.btn_SaveLog_Click);
			// 
			// btn_AddFolders
			// 
			this.btn_AddFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_AddFolders.Location = new System.Drawing.Point(0, 185);
			this.btn_AddFolders.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_AddFolders.Name = "btn_AddFolders";
			this.btn_AddFolders.Size = new System.Drawing.Size(153, 35);
			this.btn_AddFolders.TabIndex = 3;
			this.btn_AddFolders.Text = "Add Folders...";
			this.btn_AddFolders.UseVisualStyleBackColor = true;
			this.btn_AddFolders.Click += new System.EventHandler(this.btn_AddFolders_Click);
			// 
			// btn_AddProject
			// 
			this.btn_AddProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_AddProject.Location = new System.Drawing.Point(0, 230);
			this.btn_AddProject.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_AddProject.Name = "btn_AddProject";
			this.btn_AddProject.Size = new System.Drawing.Size(153, 35);
			this.btn_AddProject.TabIndex = 4;
			this.btn_AddProject.Text = "Add Project...";
			this.btn_AddProject.UseVisualStyleBackColor = true;
			this.btn_AddProject.Click += new System.EventHandler(this.btn_AddProject_Click);
			// 
			// btn_RemoveAllFiles
			// 
			this.btn_RemoveAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_RemoveAllFiles.Location = new System.Drawing.Point(0, 320);
			this.btn_RemoveAllFiles.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_RemoveAllFiles.Name = "btn_RemoveAllFiles";
			this.btn_RemoveAllFiles.Size = new System.Drawing.Size(153, 35);
			this.btn_RemoveAllFiles.TabIndex = 6;
			this.btn_RemoveAllFiles.Text = "Remove All";
			this.btn_RemoveAllFiles.UseVisualStyleBackColor = true;
			this.btn_RemoveAllFiles.Click += new System.EventHandler(this.btn_RemoveAllFiles_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Enabled = false;
			this.btn_Cancel.Location = new System.Drawing.Point(0, 50);
			this.btn_Cancel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(153, 35);
			this.btn_Cancel.TabIndex = 1;
			this.btn_Cancel.TabStop = false;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_SetGamePath
			// 
			this.btn_SetGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_SetGamePath.Location = new System.Drawing.Point(0, 365);
			this.btn_SetGamePath.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_SetGamePath.Name = "btn_SetGamePath";
			this.btn_SetGamePath.Size = new System.Drawing.Size(153, 35);
			this.btn_SetGamePath.TabIndex = 7;
			this.btn_SetGamePath.Text = "Set Game Path...";
			this.btn_SetGamePath.UseVisualStyleBackColor = true;
			this.btn_SetGamePath.Visible = false;
			this.btn_SetGamePath.Click += new System.EventHandler(this.btn_SetGamePath_Click);
			// 
			// text_OutputLog
			// 
			this.text_OutputLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.text_OutputLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.text_OutputLog.ForeColor = System.Drawing.Color.Black;
			this.text_OutputLog.Location = new System.Drawing.Point(0, 0);
			this.text_OutputLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.text_OutputLog.Name = "text_OutputLog";
			this.text_OutputLog.ReadOnly = true;
			this.text_OutputLog.Size = new System.Drawing.Size(976, 509);
			this.text_OutputLog.TabIndex = 21;
			this.text_OutputLog.TabStop = false;
			this.text_OutputLog.Text = "";
			this.text_OutputLog.WordWrap = false;
			this.text_OutputLog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.text_OutputLog_LinkClicked);
			this.text_OutputLog.TextChanged += new System.EventHandler(this.text_OutputLog_TextChanged);
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
			this.cont_Panels.Location = new System.Drawing.Point(18, 42);
			this.cont_Panels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cont_Panels.Name = "cont_Panels";
			this.cont_Panels.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// cont_Panels.Panel1
			// 
			this.cont_Panels.Panel1.Controls.Add(this.mungePanel);
			this.cont_Panels.Panel1.Controls.Add(this.data_Files);
			this.cont_Panels.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.cont_Panels.Panel1MinSize = 139;
			// 
			// cont_Panels.Panel2
			// 
			this.cont_Panels.Panel2.Controls.Add(this.text_OutputLog);
			this.cont_Panels.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
			this.cont_Panels.Panel2MinSize = 150;
			this.cont_Panels.Size = new System.Drawing.Size(976, 859);
			this.cont_Panels.SplitterDistance = 338;
			this.cont_Panels.SplitterIncrement = 15;
			this.cont_Panels.SplitterWidth = 12;
			this.cont_Panels.TabIndex = 13;
			// 
			// mungePanel
			// 
			this.mungePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mungePanel.Location = new System.Drawing.Point(0, 0);
			this.mungePanel.Logger = null;
			this.mungePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.mungePanel.MungeDir = "";
			this.mungePanel.Name = "mungePanel";
			this.mungePanel.PCOutputFolder = "";
			this.mungePanel.Platform = Platform.PC;
			this.mungePanel.Prefs = null;
			this.mungePanel.Size = new System.Drawing.Size(980, 338);
			this.mungePanel.TabIndex = 21;
			this.mungePanel.Visible = false;
			// 
			// data_Files
			// 
			this.data_Files.AllowUserToResizeRows = false;
			this.data_Files.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.data_Files.ColumnHeadersHeight = 30;
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
            this.col_IsValid});
			this.data_Files.ContextMenuStrip = this.cmenu_dataGrid;
			this.data_Files.Dock = System.Windows.Forms.DockStyle.Fill;
			this.data_Files.Location = new System.Drawing.Point(0, 0);
			this.data_Files.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.data_Files.Name = "data_Files";
			this.data_Files.RowHeadersWidth = 31;
			this.data_Files.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.data_Files.Size = new System.Drawing.Size(976, 338);
			this.data_Files.TabIndex = 20;
			this.data_Files.TabStop = false;
			this.data_Files.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_Files_CellClick);
			this.data_Files.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_Files_CellContentClick);
			this.data_Files.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_Files_CellValueChanged);
			this.data_Files.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.data_Files_RowsAdded);
			this.data_Files.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.data_Files_RowsRemoved);
			this.data_Files.KeyDown += new System.Windows.Forms.KeyEventHandler(this.data_Files_KeyDown);
			// 
			// col_Enabled
			// 
			this.col_Enabled.HeaderText = "Process";
			this.col_Enabled.MinimumWidth = 8;
			this.col_Enabled.Name = "col_Enabled";
			this.col_Enabled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.col_Enabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.col_Enabled.ToolTipText = "If checked, executes the batch script located at the specified file path.";
			this.col_Enabled.Width = 102;
			// 
			// col_Copy
			// 
			this.col_Copy.HeaderText = "Copy";
			this.col_Copy.MinimumWidth = 8;
			this.col_Copy.Name = "col_Copy";
			this.col_Copy.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.col_Copy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.col_Copy.ToolTipText = "If checked, copies the specified munged files to the staging directory after the " +
    "batch script has finished executing. (PC only)";
			this.col_Copy.Width = 81;
			// 
			// col_File
			// 
			this.col_File.HeaderText = "File Path";
			this.col_File.MinimumWidth = 100;
			this.col_File.Name = "col_File";
			this.col_File.ToolTipText = "File path of the batch script to execute.";
			this.col_File.Width = 107;
			// 
			// col_FileBrowse
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.col_FileBrowse.DefaultCellStyle = dataGridViewCellStyle1;
			this.col_FileBrowse.HeaderText = "";
			this.col_FileBrowse.MinimumWidth = 8;
			this.col_FileBrowse.Name = "col_FileBrowse";
			this.col_FileBrowse.ReadOnly = true;
			this.col_FileBrowse.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.col_FileBrowse.Text = "...";
			this.col_FileBrowse.ToolTipText = "Open a prompt to browse for a new batch script.";
			this.col_FileBrowse.UseColumnTextForButtonValue = true;
			this.col_FileBrowse.Width = 27;
			// 
			// col_Staging
			// 
			this.col_Staging.HeaderText = "Staging Directory";
			this.col_Staging.MinimumWidth = 100;
			this.col_Staging.Name = "col_Staging";
			this.col_Staging.ToolTipText = "Directory to which the munged files are copied after the batch script has finishe" +
    "d executing.";
			this.col_Staging.Width = 167;
			// 
			// col_StagingBrowse
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold);
			this.col_StagingBrowse.DefaultCellStyle = dataGridViewCellStyle2;
			this.col_StagingBrowse.HeaderText = "";
			this.col_StagingBrowse.MinimumWidth = 8;
			this.col_StagingBrowse.Name = "col_StagingBrowse";
			this.col_StagingBrowse.ReadOnly = true;
			this.col_StagingBrowse.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.col_StagingBrowse.Text = "...";
			this.col_StagingBrowse.ToolTipText = "Open a prompt to browse for a new staging directory.";
			this.col_StagingBrowse.UseColumnTextForButtonValue = true;
			this.col_StagingBrowse.Width = 27;
			// 
			// col_MungeDir
			// 
			this.col_MungeDir.HeaderText = "Munge Directory";
			this.col_MungeDir.MinimumWidth = 70;
			this.col_MungeDir.Name = "col_MungeDir";
			this.col_MungeDir.ToolTipText = "Lets Zero Munge know where to copy the associated compiled LVL files from.";
			this.col_MungeDir.Width = 161;
			// 
			// col_MungedFiles
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.col_MungedFiles.DefaultCellStyle = dataGridViewCellStyle3;
			this.col_MungedFiles.HeaderText = "Munged Files";
			this.col_MungedFiles.MinimumWidth = 100;
			this.col_MungedFiles.Name = "col_MungedFiles";
			this.col_MungedFiles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col_MungedFiles.ToolTipText = "Names of files that will be copied to the staging directory after the batch scrip" +
    "t has finished executing. Separate each file name into its own line.";
			this.col_MungedFiles.Width = 140;
			// 
			// col_MungedFilesEdit
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold);
			this.col_MungedFilesEdit.DefaultCellStyle = dataGridViewCellStyle4;
			this.col_MungedFilesEdit.HeaderText = "";
			this.col_MungedFilesEdit.MinimumWidth = 8;
			this.col_MungedFilesEdit.Name = "col_MungedFilesEdit";
			this.col_MungedFilesEdit.ReadOnly = true;
			this.col_MungedFilesEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.col_MungedFilesEdit.Text = "▼";
			this.col_MungedFilesEdit.ToolTipText = "Open a popup to add/remove/edit names of munged files.";
			this.col_MungedFilesEdit.UseColumnTextForButtonValue = true;
			this.col_MungedFilesEdit.Width = 27;
			// 
			// col_IsMungeScript
			// 
			this.col_IsMungeScript.HeaderText = "IsMungeScript";
			this.col_IsMungeScript.MinimumWidth = 8;
			this.col_IsMungeScript.Name = "col_IsMungeScript";
			this.col_IsMungeScript.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.col_IsMungeScript.Width = 118;
			// 
			// col_IsValid
			// 
			this.col_IsValid.HeaderText = "IsValid";
			this.col_IsValid.MinimumWidth = 8;
			this.col_IsValid.Name = "col_IsValid";
			this.col_IsValid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.col_IsValid.Width = 63;
			// 
			// cmenu_dataGrid
			// 
			this.cmenu_dataGrid.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.cmenu_dataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_openProjectFolderInEditor,
            this.menu_openBuildCmd,
            this.menu_openStagingDirectory,
            this.menu_openProjectFolder});
			this.cmenu_dataGrid.Name = "cmenu_dataGrid";
			this.cmenu_dataGrid.Size = new System.Drawing.Size(364, 132);
			// 
			// menu_openProjectFolderInEditor
			// 
			this.menu_openProjectFolderInEditor.Image = global::ZeroMunge.Properties.Resources.TextEditorIcon;
			this.menu_openProjectFolderInEditor.Name = "menu_openProjectFolderInEditor";
			this.menu_openProjectFolderInEditor.Size = new System.Drawing.Size(363, 32);
			this.menu_openProjectFolderInEditor.Text = "Open Project folder in editor";
			this.menu_openProjectFolderInEditor.Click += new System.EventHandler(this.menu_openProjectFolderEditor);
			// 
			// menu_openBuildCmd
			// 
			this.menu_openBuildCmd.Image = global::ZeroMunge.Properties.Resources.CMD;
			this.menu_openBuildCmd.Name = "menu_openBuildCmd";
			this.menu_openBuildCmd.Size = new System.Drawing.Size(363, 32);
			this.menu_openBuildCmd.Text = "Open CMD in project _Build folder";
			this.menu_openBuildCmd.Click += new System.EventHandler(this.menu_openBuildCmd_Click);
			// 
			// menu_openStagingDirectory
			// 
			this.menu_openStagingDirectory.Image = global::ZeroMunge.Properties.Resources.FolderOpen1;
			this.menu_openStagingDirectory.Name = "menu_openStagingDirectory";
			this.menu_openStagingDirectory.Size = new System.Drawing.Size(363, 32);
			this.menu_openStagingDirectory.Text = "Open Staging Directory";
			this.menu_openStagingDirectory.Click += new System.EventHandler(this.menu_openStagingDirectory_Click);
			// 
			// menu_openProjectFolder
			// 
			this.menu_openProjectFolder.Image = global::ZeroMunge.Properties.Resources.FolderOpen1;
			this.menu_openProjectFolder.Name = "menu_openProjectFolder";
			this.menu_openProjectFolder.Size = new System.Drawing.Size(363, 32);
			this.menu_openProjectFolder.Text = "Open Project folder";
			this.menu_openProjectFolder.Click += new System.EventHandler(this.menu_openProjectFolder_Click);
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
			this.cmenu_TrayIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.cmenu_TrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenu_TrayIcon_Run,
            this.cmenu_TrayIcon_Cancel,
            this.toolStripSeparator10,
            this.cmenu_TrayIcon_Open,
            this.cmenu_TrayIcon_Quit});
			this.cmenu_TrayIcon.Name = "cmenu_TrayIcon";
			this.cmenu_TrayIcon.Size = new System.Drawing.Size(136, 138);
			// 
			// cmenu_TrayIcon_Run
			// 
			this.cmenu_TrayIcon_Run.Name = "cmenu_TrayIcon_Run";
			this.cmenu_TrayIcon_Run.Size = new System.Drawing.Size(135, 32);
			this.cmenu_TrayIcon_Run.Text = "Run";
			this.cmenu_TrayIcon_Run.Click += new System.EventHandler(this.cmenu_TrayIcon_Run_Click);
			// 
			// cmenu_TrayIcon_Cancel
			// 
			this.cmenu_TrayIcon_Cancel.Enabled = false;
			this.cmenu_TrayIcon_Cancel.Name = "cmenu_TrayIcon_Cancel";
			this.cmenu_TrayIcon_Cancel.Size = new System.Drawing.Size(135, 32);
			this.cmenu_TrayIcon_Cancel.Text = "Cancel";
			this.cmenu_TrayIcon_Cancel.Click += new System.EventHandler(this.cmenu_TrayIcon_Cancel_Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(132, 6);
			// 
			// cmenu_TrayIcon_Open
			// 
			this.cmenu_TrayIcon_Open.Name = "cmenu_TrayIcon_Open";
			this.cmenu_TrayIcon_Open.Size = new System.Drawing.Size(135, 32);
			this.cmenu_TrayIcon_Open.Text = "Open";
			this.cmenu_TrayIcon_Open.Click += new System.EventHandler(this.cmenu_TrayIcon_Open_Click);
			// 
			// cmenu_TrayIcon_Quit
			// 
			this.cmenu_TrayIcon_Quit.Name = "cmenu_TrayIcon_Quit";
			this.cmenu_TrayIcon_Quit.Size = new System.Drawing.Size(135, 32);
			this.cmenu_TrayIcon_Quit.Text = "Quit";
			this.cmenu_TrayIcon_Quit.Click += new System.EventHandler(this.cmenu_TrayIcon_Quit_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(41, 455);
			this.button2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 35);
			this.button2.TabIndex = 16;
			this.button2.TabStop = false;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// menu_MainForm
			// 
			this.menu_MainForm.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menu_MainForm.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menu_MainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.menu_strip_platform,
            this.helpToolStripMenuItem});
			this.menu_MainForm.Location = new System.Drawing.Point(0, 0);
			this.menu_MainForm.Name = "menu_MainForm";
			this.menu_MainForm.Size = new System.Drawing.Size(1176, 33);
			this.menu_MainForm.TabIndex = 18;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_newToolStripMenuItem,
            this.menu_openToolStripMenuItem,
            this.menu_openRecentToolStripMenuItem,
            this.menu_alternateUI,
            this.menu_saveToolStripMenuItem,
            this.menu_saveAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.menu_exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
			this.fileToolStripMenuItem.Text = "File";
			this.fileToolStripMenuItem.ToolTipText = "Opens a prompt to select a previously-saved file list to import.";
			// 
			// menu_newToolStripMenuItem
			// 
			this.menu_newToolStripMenuItem.Name = "menu_newToolStripMenuItem";
			this.menu_newToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
			this.menu_newToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
			this.menu_newToolStripMenuItem.Text = "New";
			this.menu_newToolStripMenuItem.Click += new System.EventHandler(this.menu_newToolStripMenuItem_Click);
			// 
			// menu_openToolStripMenuItem
			// 
			this.menu_openToolStripMenuItem.Name = "menu_openToolStripMenuItem";
			this.menu_openToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
			this.menu_openToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
			this.menu_openToolStripMenuItem.Text = "Open...";
			this.menu_openToolStripMenuItem.Click += new System.EventHandler(this.menu_openToolStripMenuItem_Click);
			// 
			// menu_openRecentToolStripMenuItem
			// 
			this.menu_openRecentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator11});
			this.menu_openRecentToolStripMenuItem.Enabled = false;
			this.menu_openRecentToolStripMenuItem.Name = "menu_openRecentToolStripMenuItem";
			this.menu_openRecentToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
			this.menu_openRecentToolStripMenuItem.Text = "Open Recent";
			this.menu_openRecentToolStripMenuItem.Visible = false;
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(87, 6);
			// 
			// menu_alternateUI
			// 
			this.menu_alternateUI.Name = "menu_alternateUI";
			this.menu_alternateUI.ShortcutKeys = System.Windows.Forms.Keys.F12;
			this.menu_alternateUI.Size = new System.Drawing.Size(248, 34);
			this.menu_alternateUI.Text = "Alternate UI";
			this.menu_alternateUI.CheckedChanged += new System.EventHandler(this.menu_alternateUI_CheckChanged);
			this.menu_alternateUI.Click += new System.EventHandler(this.menu_alternateUI_Click);
			// 
			// menu_saveToolStripMenuItem
			// 
			this.menu_saveToolStripMenuItem.Name = "menu_saveToolStripMenuItem";
			this.menu_saveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
			this.menu_saveToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
			this.menu_saveToolStripMenuItem.Text = "Save";
			this.menu_saveToolStripMenuItem.Click += new System.EventHandler(this.menu_saveToolStripMenuItem_Click);
			// 
			// menu_saveAsToolStripMenuItem
			// 
			this.menu_saveAsToolStripMenuItem.Name = "menu_saveAsToolStripMenuItem";
			this.menu_saveAsToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.menu_saveAsToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
			this.menu_saveAsToolStripMenuItem.Text = "Save As...";
			this.menu_saveAsToolStripMenuItem.Click += new System.EventHandler(this.menu_saveAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(245, 6);
			// 
			// menu_exitToolStripMenuItem
			// 
			this.menu_exitToolStripMenuItem.Name = "menu_exitToolStripMenuItem";
			this.menu_exitToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Q";
			this.menu_exitToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
			this.menu_exitToolStripMenuItem.Text = "Exit";
			this.menu_exitToolStripMenuItem.Click += new System.EventHandler(this.menu_exitToolStripMenuItem_Click);
			// 
			// actionsToolStripMenuItem
			// 
			this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_runToolStripMenuItem,
            this.menu_cancelToolStripMenuItem,
            this.toolStripSeparator2,
            this.menu_easyFilePickerToolStripMenuItem,
            this.toolStripSeparator12,
            this.menu_addFilesToolStripMenuItem,
            this.menu_addFoldersToolStripMenuItem,
            this.menu_addProjectToolStripMenuItem,
            this.toolStripSeparator3,
            this.menu_removeToolStripMenuItem,
            this.menu_removeAllToolStripMenuItem,
            this.toolStripSeparator14,
            this.menu_logSubToolStripMenuItem,
            this.toolStripSeparator13,
            this.menu_openGameLog,
            this.menu_openModToolsExe,
            this.menu_launchZeroEditor,
            this.menu_openGameExe,
            this.menu_openGameFolder,
            this.menu_openProjectFolder2,
            this.menu_launchPPSSPP,
            this.menu_debugMission});
			this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
			this.actionsToolStripMenuItem.Size = new System.Drawing.Size(87, 29);
			this.actionsToolStripMenuItem.Text = "Actions";
			// 
			// menu_runToolStripMenuItem
			// 
			this.menu_runToolStripMenuItem.Name = "menu_runToolStripMenuItem";
			this.menu_runToolStripMenuItem.ShortcutKeyDisplayString = "F5";
			this.menu_runToolStripMenuItem.Size = new System.Drawing.Size(370, 34);
			this.menu_runToolStripMenuItem.Text = "Run";
			this.menu_runToolStripMenuItem.Click += new System.EventHandler(this.btn_Run_Click);
			// 
			// menu_cancelToolStripMenuItem
			// 
			this.menu_cancelToolStripMenuItem.Enabled = false;
			this.menu_cancelToolStripMenuItem.Name = "menu_cancelToolStripMenuItem";
			this.menu_cancelToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F5";
			this.menu_cancelToolStripMenuItem.Size = new System.Drawing.Size(370, 34);
			this.menu_cancelToolStripMenuItem.Text = "Cancel";
			this.menu_cancelToolStripMenuItem.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(367, 6);
			// 
			// menu_easyFilePickerToolStripMenuItem
			// 
			this.menu_easyFilePickerToolStripMenuItem.Name = "menu_easyFilePickerToolStripMenuItem";
			this.menu_easyFilePickerToolStripMenuItem.Size = new System.Drawing.Size(370, 34);
			this.menu_easyFilePickerToolStripMenuItem.Text = "Easy File Picker";
			this.menu_easyFilePickerToolStripMenuItem.Click += new System.EventHandler(this.btn_EasyFilePicker_Click);
			// 
			// toolStripSeparator12
			// 
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(367, 6);
			// 
			// menu_addFilesToolStripMenuItem
			// 
			this.menu_addFilesToolStripMenuItem.Name = "menu_addFilesToolStripMenuItem";
			this.menu_addFilesToolStripMenuItem.Size = new System.Drawing.Size(370, 34);
			this.menu_addFilesToolStripMenuItem.Text = "Add Files...";
			this.menu_addFilesToolStripMenuItem.Click += new System.EventHandler(this.btn_AddFiles_Click);
			// 
			// menu_addFoldersToolStripMenuItem
			// 
			this.menu_addFoldersToolStripMenuItem.Name = "menu_addFoldersToolStripMenuItem";
			this.menu_addFoldersToolStripMenuItem.Size = new System.Drawing.Size(370, 34);
			this.menu_addFoldersToolStripMenuItem.Text = "Add Folders...";
			this.menu_addFoldersToolStripMenuItem.Click += new System.EventHandler(this.btn_AddFolders_Click);
			// 
			// menu_addProjectToolStripMenuItem
			// 
			this.menu_addProjectToolStripMenuItem.Name = "menu_addProjectToolStripMenuItem";
			this.menu_addProjectToolStripMenuItem.Size = new System.Drawing.Size(370, 34);
			this.menu_addProjectToolStripMenuItem.Text = "Add Project...";
			this.menu_addProjectToolStripMenuItem.Click += new System.EventHandler(this.btn_AddProject_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(367, 6);
			// 
			// menu_removeToolStripMenuItem
			// 
			this.menu_removeToolStripMenuItem.Name = "menu_removeToolStripMenuItem";
			this.menu_removeToolStripMenuItem.Size = new System.Drawing.Size(370, 34);
			this.menu_removeToolStripMenuItem.Text = "Remove";
			this.menu_removeToolStripMenuItem.Click += new System.EventHandler(this.btn_RemoveFile_Click);
			// 
			// menu_removeAllToolStripMenuItem
			// 
			this.menu_removeAllToolStripMenuItem.Name = "menu_removeAllToolStripMenuItem";
			this.menu_removeAllToolStripMenuItem.Size = new System.Drawing.Size(370, 34);
			this.menu_removeAllToolStripMenuItem.Text = "Remove All";
			this.menu_removeAllToolStripMenuItem.Click += new System.EventHandler(this.btn_RemoveAllFiles_Click);
			// 
			// toolStripSeparator14
			// 
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(367, 6);
			// 
			// menu_logSubToolStripMenuItem
			// 
			this.menu_logSubToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_openMungeLog,
            this.menu_openLog,
            this.menu_copyLogToolStripMenuItem,
            this.menu_saveLogAsToolStripMenuItem,
            this.menu_clearLogToolStripMenuItem});
			this.menu_logSubToolStripMenuItem.Name = "menu_logSubToolStripMenuItem";
			this.menu_logSubToolStripMenuItem.Size = new System.Drawing.Size(370, 34);
			this.menu_logSubToolStripMenuItem.Text = "Log";
			// 
			// menu_openMungeLog
			// 
			this.menu_openMungeLog.Name = "menu_openMungeLog";
			this.menu_openMungeLog.Size = new System.Drawing.Size(293, 34);
			this.menu_openMungeLog.Text = "Open Munge Log";
			this.menu_openMungeLog.Click += new System.EventHandler(this.menu_openMungeLog_Click);
			// 
			// menu_openLog
			// 
			this.menu_openLog.Name = "menu_openLog";
			this.menu_openLog.Size = new System.Drawing.Size(293, 34);
			this.menu_openLog.Text = "Open Log";
			this.menu_openLog.Click += new System.EventHandler(this.menu_openLog_Click);
			// 
			// menu_copyLogToolStripMenuItem
			// 
			this.menu_copyLogToolStripMenuItem.Name = "menu_copyLogToolStripMenuItem";
			this.menu_copyLogToolStripMenuItem.Size = new System.Drawing.Size(293, 34);
			this.menu_copyLogToolStripMenuItem.Text = "Copy Log to clipboard";
			this.menu_copyLogToolStripMenuItem.Click += new System.EventHandler(this.btn_CopyLog_Click);
			// 
			// menu_saveLogAsToolStripMenuItem
			// 
			this.menu_saveLogAsToolStripMenuItem.Name = "menu_saveLogAsToolStripMenuItem";
			this.menu_saveLogAsToolStripMenuItem.Size = new System.Drawing.Size(293, 34);
			this.menu_saveLogAsToolStripMenuItem.Text = "Save Log As...";
			this.menu_saveLogAsToolStripMenuItem.Click += new System.EventHandler(this.btn_SaveLog_Click);
			// 
			// menu_clearLogToolStripMenuItem
			// 
			this.menu_clearLogToolStripMenuItem.Name = "menu_clearLogToolStripMenuItem";
			this.menu_clearLogToolStripMenuItem.Size = new System.Drawing.Size(293, 34);
			this.menu_clearLogToolStripMenuItem.Text = "Clear Log";
			this.menu_clearLogToolStripMenuItem.Click += new System.EventHandler(this.btn_ClearLog_Click);
			// 
			// toolStripSeparator13
			// 
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(367, 6);
			// 
			// menu_openGameLog
			// 
			this.menu_openGameLog.Image = global::ZeroMunge.Properties.Resources.TextEditorIcon;
			this.menu_openGameLog.Name = "menu_openGameLog";
			this.menu_openGameLog.Size = new System.Drawing.Size(370, 34);
			this.menu_openGameLog.Text = "Open BFront2.log";
			this.menu_openGameLog.Click += new System.EventHandler(this.openBF2LogToolStripMenuItem_Click);
			// 
			// menu_openModToolsExe
			// 
			this.menu_openModToolsExe.Image = global::ZeroMunge.Properties.Resources.Debugger1;
			this.menu_openModToolsExe.Name = "menu_openModToolsExe";
			this.menu_openModToolsExe.ShortcutKeyDisplayString = "F6";
			this.menu_openModToolsExe.Size = new System.Drawing.Size(370, 34);
			this.menu_openModToolsExe.Text = "Launch Debugger";
			this.menu_openModToolsExe.Click += new System.EventHandler(this.openModtoolsExeToolStripMenuItem_Click);
			// 
			// menu_launchZeroEditor
			// 
			this.menu_launchZeroEditor.Image = global::ZeroMunge.Properties.Resources.ZeroEditorIcon;
			this.menu_launchZeroEditor.Name = "menu_launchZeroEditor";
			this.menu_launchZeroEditor.ShortcutKeyDisplayString = "F10";
			this.menu_launchZeroEditor.Size = new System.Drawing.Size(370, 34);
			this.menu_launchZeroEditor.Text = "Launch Zero Editor";
			this.menu_launchZeroEditor.Click += new System.EventHandler(this.menu_launchZeroEditor_Click);
			// 
			// menu_openGameExe
			// 
			this.menu_openGameExe.Image = global::ZeroMunge.Properties.Resources.BFII_;
			this.menu_openGameExe.Name = "menu_openGameExe";
			this.menu_openGameExe.Size = new System.Drawing.Size(370, 34);
			this.menu_openGameExe.Text = "Launch BattlefrontII.exe";
			this.menu_openGameExe.Click += new System.EventHandler(this.menu_openGameExe_Click);
			// 
			// menu_openGameFolder
			// 
			this.menu_openGameFolder.Image = global::ZeroMunge.Properties.Resources.FolderOpen1;
			this.menu_openGameFolder.Name = "menu_openGameFolder";
			this.menu_openGameFolder.Size = new System.Drawing.Size(370, 34);
			this.menu_openGameFolder.Text = "Open Game Folder";
			this.menu_openGameFolder.Click += new System.EventHandler(this.menu_openGameFolder_Click);
			// 
			// menu_openProjectFolder2
			// 
			this.menu_openProjectFolder2.Image = global::ZeroMunge.Properties.Resources.FolderOpen1;
			this.menu_openProjectFolder2.Name = "menu_openProjectFolder2";
			this.menu_openProjectFolder2.Size = new System.Drawing.Size(370, 34);
			this.menu_openProjectFolder2.Text = "Open Project Folder";
			this.menu_openProjectFolder2.Click += new System.EventHandler(this.menu_openProjectFolder_Click);
			// 
			// menu_launchPPSSPP
			// 
			this.menu_launchPPSSPP.Image = global::ZeroMunge.Properties.Resources.PPSSPP;
			this.menu_launchPPSSPP.Name = "menu_launchPPSSPP";
			this.menu_launchPPSSPP.Size = new System.Drawing.Size(370, 34);
			this.menu_launchPPSSPP.Text = "Launch game in PPSSPP";
			this.menu_launchPPSSPP.Click += new System.EventHandler(this.menu_launchPPSSPP_Click);
			// 
			// menu_debugMission
			// 
			this.menu_debugMission.Image = global::ZeroMunge.Properties.Resources.Debugger1;
			this.menu_debugMission.Name = "menu_debugMission";
			this.menu_debugMission.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.menu_debugMission.Size = new System.Drawing.Size(370, 34);
			this.menu_debugMission.Text = "Launch mission in Debugger";
			this.menu_debugMission.Click += new System.EventHandler(this.launchMissionInDebuggerToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_createSideMungeFolderToolStripMenuItem,
            this.menu_createWorldMungeFolderToolStripMenuItem,
            this.menu_fixWorldMungeScriptsToolStripMenuItem,
            this.menu_fixSoundMungeFilesToolStripMenuItem,
            this.menu_modifyMungedSoundFoldersToolStripMenuItem,
            this.menu_addMission});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// menu_createSideMungeFolderToolStripMenuItem
			// 
			this.menu_createSideMungeFolderToolStripMenuItem.Name = "menu_createSideMungeFolderToolStripMenuItem";
			this.menu_createSideMungeFolderToolStripMenuItem.Size = new System.Drawing.Size(375, 34);
			this.menu_createSideMungeFolderToolStripMenuItem.Text = "Create Side Munge Folders...";
			this.menu_createSideMungeFolderToolStripMenuItem.Click += new System.EventHandler(this.menu_createSideMungeFolderToolStripMenuItem_Click);
			// 
			// menu_createWorldMungeFolderToolStripMenuItem
			// 
			this.menu_createWorldMungeFolderToolStripMenuItem.Name = "menu_createWorldMungeFolderToolStripMenuItem";
			this.menu_createWorldMungeFolderToolStripMenuItem.Size = new System.Drawing.Size(375, 34);
			this.menu_createWorldMungeFolderToolStripMenuItem.Text = "Create World Munge Folders...";
			this.menu_createWorldMungeFolderToolStripMenuItem.Click += new System.EventHandler(this.menu_createWorldMungeFolderToolStripMenuItem_Click);
			// 
			// menu_fixWorldMungeScriptsToolStripMenuItem
			// 
			this.menu_fixWorldMungeScriptsToolStripMenuItem.Name = "menu_fixWorldMungeScriptsToolStripMenuItem";
			this.menu_fixWorldMungeScriptsToolStripMenuItem.Size = new System.Drawing.Size(375, 34);
			this.menu_fixWorldMungeScriptsToolStripMenuItem.Text = "Fix World Munge File...";
			this.menu_fixWorldMungeScriptsToolStripMenuItem.Click += new System.EventHandler(this.menu_fixWorldMungeScriptsToolStripMenuItem_Click);
			// 
			// menu_fixSoundMungeFilesToolStripMenuItem
			// 
			this.menu_fixSoundMungeFilesToolStripMenuItem.Name = "menu_fixSoundMungeFilesToolStripMenuItem";
			this.menu_fixSoundMungeFilesToolStripMenuItem.Size = new System.Drawing.Size(375, 34);
			this.menu_fixSoundMungeFilesToolStripMenuItem.Text = "Fix Sound Munge Files...";
			this.menu_fixSoundMungeFilesToolStripMenuItem.Click += new System.EventHandler(this.menu_fixSoundMungeFilesToolStripMenuItem_Click);
			// 
			// menu_modifyMungedSoundFoldersToolStripMenuItem
			// 
			this.menu_modifyMungedSoundFoldersToolStripMenuItem.Name = "menu_modifyMungedSoundFoldersToolStripMenuItem";
			this.menu_modifyMungedSoundFoldersToolStripMenuItem.Size = new System.Drawing.Size(375, 34);
			this.menu_modifyMungedSoundFoldersToolStripMenuItem.Text = "Modify Munged Sound Folders...";
			this.menu_modifyMungedSoundFoldersToolStripMenuItem.Click += new System.EventHandler(this.menu_modifyMungedSoundFoldersToolStripMenuItem_Click);
			// 
			// menu_addMission
			// 
			this.menu_addMission.Name = "menu_addMission";
			this.menu_addMission.Size = new System.Drawing.Size(375, 34);
			this.menu_addMission.Text = "Add Mission...";
			this.menu_addMission.Click += new System.EventHandler(this.menu_addMission_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_setGamePathToolStripMenuItem,
            this.menu_setPreferredEditor,
            this.toolStripSeparator5,
            this.menu_prefsToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(118, 29);
			this.settingsToolStripMenuItem.Text = "Preferences";
			// 
			// menu_setGamePathToolStripMenuItem
			// 
			this.menu_setGamePathToolStripMenuItem.Name = "menu_setGamePathToolStripMenuItem";
			this.menu_setGamePathToolStripMenuItem.Size = new System.Drawing.Size(295, 34);
			this.menu_setGamePathToolStripMenuItem.Text = "Set Game Path...";
			this.menu_setGamePathToolStripMenuItem.Visible = false;
			this.menu_setGamePathToolStripMenuItem.Click += new System.EventHandler(this.btn_SetGamePath_Click);
			// 
			// menu_setPreferredEditor
			// 
			this.menu_setPreferredEditor.Name = "menu_setPreferredEditor";
			this.menu_setPreferredEditor.Size = new System.Drawing.Size(295, 34);
			this.menu_setPreferredEditor.Text = "Set Preferred Editor...";
			this.menu_setPreferredEditor.Visible = false;
			this.menu_setPreferredEditor.Click += new System.EventHandler(this.setPreferredEditorToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(292, 6);
			this.toolStripSeparator5.Visible = false;
			// 
			// menu_prefsToolStripMenuItem
			// 
			this.menu_prefsToolStripMenuItem.Name = "menu_prefsToolStripMenuItem";
			this.menu_prefsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+P";
			this.menu_prefsToolStripMenuItem.Size = new System.Drawing.Size(295, 34);
			this.menu_prefsToolStripMenuItem.Text = "Set Preferences";
			this.menu_prefsToolStripMenuItem.Click += new System.EventHandler(this.menu_prefsToolStripMenuItem_Click);
			// 
			// menu_strip_platform
			// 
			this.menu_strip_platform.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_pcPlatform,
            this.menu_xboxPlatform,
            this.menu_ps2Platform});
			this.menu_strip_platform.Name = "menu_strip_platform";
			this.menu_strip_platform.Size = new System.Drawing.Size(132, 29);
			this.menu_strip_platform.Text = "Platform (PC)";
			// 
			// menu_pcPlatform
			// 
			this.menu_pcPlatform.Checked = true;
			this.menu_pcPlatform.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menu_pcPlatform.Name = "menu_pcPlatform";
			this.menu_pcPlatform.Size = new System.Drawing.Size(191, 34);
			this.menu_pcPlatform.Tag = "PC";
			this.menu_pcPlatform.Text = "PC";
			this.menu_pcPlatform.Click += new System.EventHandler(this.menu_Platform_Click);
			// 
			// menu_xboxPlatform
			// 
			this.menu_xboxPlatform.Name = "menu_xboxPlatform";
			this.menu_xboxPlatform.Size = new System.Drawing.Size(191, 34);
			this.menu_xboxPlatform.Tag = "XBOX";
			this.menu_xboxPlatform.Text = "XBOX";
			this.menu_xboxPlatform.Click += new System.EventHandler(this.menu_Platform_Click);
			// 
			// menu_ps2Platform
			// 
			this.menu_ps2Platform.Name = "menu_ps2Platform";
			this.menu_ps2Platform.Size = new System.Drawing.Size(191, 34);
			this.menu_ps2Platform.Tag = "PS2";
			this.menu_ps2Platform.Text = "PS2 / PSP";
			this.menu_ps2Platform.Click += new System.EventHandler(this.menu_Platform_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_viewHelpToolStripMenuItem,
            this.toolStripSeparator9,
            this.menu_viewChangelogToolStripMenuItem,
            this.menu_viewLicenseToolStripMenuItem,
            this.menu_viewReadmeToolStripMenuItem,
            this.toolStripSeparator6,
            this.menu_provideFeedbackToolStripMenuItem,
            this.menu_checkForUpdatesToolStripMenuItem,
            this.menu_gametoastForums,
            this.menu_Battlefront2API,
            this.menu_gametoastGithub,
            this.toolStripSeparator7,
            this.menu_aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// menu_viewHelpToolStripMenuItem
			// 
			this.menu_viewHelpToolStripMenuItem.Name = "menu_viewHelpToolStripMenuItem";
			this.menu_viewHelpToolStripMenuItem.ShortcutKeyDisplayString = "F1";
			this.menu_viewHelpToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
			this.menu_viewHelpToolStripMenuItem.Text = "View Help";
			this.menu_viewHelpToolStripMenuItem.Click += new System.EventHandler(this.menu_viewHelpToolStripMenuItem_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(312, 6);
			// 
			// menu_viewChangelogToolStripMenuItem
			// 
			this.menu_viewChangelogToolStripMenuItem.Name = "menu_viewChangelogToolStripMenuItem";
			this.menu_viewChangelogToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
			this.menu_viewChangelogToolStripMenuItem.Text = "View Changelog";
			this.menu_viewChangelogToolStripMenuItem.Click += new System.EventHandler(this.menu_viewChangelogToolStripMenuItem_Click);
			// 
			// menu_viewLicenseToolStripMenuItem
			// 
			this.menu_viewLicenseToolStripMenuItem.Name = "menu_viewLicenseToolStripMenuItem";
			this.menu_viewLicenseToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
			this.menu_viewLicenseToolStripMenuItem.Text = "View License";
			this.menu_viewLicenseToolStripMenuItem.Click += new System.EventHandler(this.menu_viewLicenseToolStripMenuItem_Click);
			// 
			// menu_viewReadmeToolStripMenuItem
			// 
			this.menu_viewReadmeToolStripMenuItem.Name = "menu_viewReadmeToolStripMenuItem";
			this.menu_viewReadmeToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
			this.menu_viewReadmeToolStripMenuItem.Text = "View Readme";
			this.menu_viewReadmeToolStripMenuItem.Click += new System.EventHandler(this.menu_viewReadmeToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(312, 6);
			// 
			// menu_provideFeedbackToolStripMenuItem
			// 
			this.menu_provideFeedbackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_reportBugToolStripMenuItem,
            this.menu_provideSuggestionToolStripMenuItem,
            this.toolStripSeparator8,
            this.menu_viewOpenIssuesToolStripMenuItem});
			this.menu_provideFeedbackToolStripMenuItem.Name = "menu_provideFeedbackToolStripMenuItem";
			this.menu_provideFeedbackToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
			this.menu_provideFeedbackToolStripMenuItem.Text = "Feedback";
			// 
			// menu_reportBugToolStripMenuItem
			// 
			this.menu_reportBugToolStripMenuItem.Name = "menu_reportBugToolStripMenuItem";
			this.menu_reportBugToolStripMenuItem.Size = new System.Drawing.Size(295, 34);
			this.menu_reportBugToolStripMenuItem.Text = "Report a Problem...";
			this.menu_reportBugToolStripMenuItem.Click += new System.EventHandler(this.menu_reportBugToolStripMenuItem_Click);
			// 
			// menu_provideSuggestionToolStripMenuItem
			// 
			this.menu_provideSuggestionToolStripMenuItem.Name = "menu_provideSuggestionToolStripMenuItem";
			this.menu_provideSuggestionToolStripMenuItem.Size = new System.Drawing.Size(295, 34);
			this.menu_provideSuggestionToolStripMenuItem.Text = "Provide a Suggestion...";
			this.menu_provideSuggestionToolStripMenuItem.Click += new System.EventHandler(this.menu_provideSuggestionToolStripMenuItem_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(292, 6);
			// 
			// menu_viewOpenIssuesToolStripMenuItem
			// 
			this.menu_viewOpenIssuesToolStripMenuItem.Name = "menu_viewOpenIssuesToolStripMenuItem";
			this.menu_viewOpenIssuesToolStripMenuItem.Size = new System.Drawing.Size(295, 34);
			this.menu_viewOpenIssuesToolStripMenuItem.Text = "View Open Issues...";
			this.menu_viewOpenIssuesToolStripMenuItem.Click += new System.EventHandler(this.menu_viewOpenIssuesToolStripMenuItem_Click);
			// 
			// menu_checkForUpdatesToolStripMenuItem
			// 
			this.menu_checkForUpdatesToolStripMenuItem.Name = "menu_checkForUpdatesToolStripMenuItem";
			this.menu_checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
			this.menu_checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
			this.menu_checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.menu_checkForUpdatesToolStripMenuItem_Click);
			// 
			// menu_gametoastForums
			// 
			this.menu_gametoastForums.Name = "menu_gametoastForums";
			this.menu_gametoastForums.Size = new System.Drawing.Size(315, 34);
			this.menu_gametoastForums.Text = "Gametoast Forums";
			this.menu_gametoastForums.Click += new System.EventHandler(this.menu_gametoastForums_Click);
			// 
			// menu_Battlefront2API
			// 
			this.menu_Battlefront2API.Name = "menu_Battlefront2API";
			this.menu_Battlefront2API.Size = new System.Drawing.Size(315, 34);
			this.menu_Battlefront2API.Text = "SWBF2 Lua API Reference";
			this.menu_Battlefront2API.Click += new System.EventHandler(this.menu_Battlefront2API_Click);
			// 
			// menu_gametoastGithub
			// 
			this.menu_gametoastGithub.Name = "menu_gametoastGithub";
			this.menu_gametoastGithub.Size = new System.Drawing.Size(315, 34);
			this.menu_gametoastGithub.Text = "Gametoast Github";
			this.menu_gametoastGithub.Click += new System.EventHandler(this.menu_gametoastGithub_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(312, 6);
			// 
			// menu_aboutToolStripMenuItem
			// 
			this.menu_aboutToolStripMenuItem.Name = "menu_aboutToolStripMenuItem";
			this.menu_aboutToolStripMenuItem.ShortcutKeyDisplayString = "F12";
			this.menu_aboutToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
			this.menu_aboutToolStripMenuItem.Text = "About";
			this.menu_aboutToolStripMenuItem.Click += new System.EventHandler(this.menu_aboutToolStripMenuItem_Click);
			// 
			// flp_FileButtons
			// 
			this.flp_FileButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flp_FileButtons.Controls.Add(this.btn_Run);
			this.flp_FileButtons.Controls.Add(this.btn_Cancel);
			this.flp_FileButtons.Controls.Add(this.btn_EasyFilePicker);
			this.flp_FileButtons.Controls.Add(this.btn_AddFiles);
			this.flp_FileButtons.Controls.Add(this.btn_AddFolders);
			this.flp_FileButtons.Controls.Add(this.btn_AddProject);
			this.flp_FileButtons.Controls.Add(this.btn_RemoveFile);
			this.flp_FileButtons.Controls.Add(this.btn_RemoveAllFiles);
			this.flp_FileButtons.Controls.Add(this.btn_SetGamePath);
			this.flp_FileButtons.Controls.Add(this.btn_clean);
			this.flp_FileButtons.Controls.Add(this.button2);
			this.flp_FileButtons.Controls.Add(this.button3);
			this.flp_FileButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flp_FileButtons.Location = new System.Drawing.Point(1010, 42);
			this.flp_FileButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.flp_FileButtons.Name = "flp_FileButtons";
			this.flp_FileButtons.Size = new System.Drawing.Size(153, 545);
			this.flp_FileButtons.TabIndex = 19;
			// 
			// btn_EasyFilePicker
			// 
			this.btn_EasyFilePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_EasyFilePicker.Location = new System.Drawing.Point(0, 95);
			this.btn_EasyFilePicker.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_EasyFilePicker.Name = "btn_EasyFilePicker";
			this.btn_EasyFilePicker.Size = new System.Drawing.Size(153, 35);
			this.btn_EasyFilePicker.TabIndex = 1;
			this.btn_EasyFilePicker.Text = "Easy File Picker";
			this.btn_EasyFilePicker.UseVisualStyleBackColor = true;
			this.btn_EasyFilePicker.Click += new System.EventHandler(this.btn_EasyFilePicker_Click);
			// 
			// btn_clean
			// 
			this.btn_clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_clean.Location = new System.Drawing.Point(0, 410);
			this.btn_clean.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_clean.Name = "btn_clean";
			this.btn_clean.Size = new System.Drawing.Size(153, 35);
			this.btn_clean.TabIndex = 18;
			this.btn_clean.Text = "Clean";
			this.btn_clean.UseVisualStyleBackColor = true;
			this.btn_clean.Click += new System.EventHandler(this.btn_clean_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(4, 500);
			this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(112, 35);
			this.button3.TabIndex = 17;
			this.button3.TabStop = false;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// flp_LogButtons
			// 
			this.flp_LogButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.flp_LogButtons.Controls.Add(this.btn_ClearLog);
			this.flp_LogButtons.Controls.Add(this.btn_SaveLog);
			this.flp_LogButtons.Controls.Add(this.btn_OpenLog);
			this.flp_LogButtons.Controls.Add(this.btn_OpenMungeLog);
			this.flp_LogButtons.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
			this.flp_LogButtons.Location = new System.Drawing.Point(1010, 712);
			this.flp_LogButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.flp_LogButtons.Name = "flp_LogButtons";
			this.flp_LogButtons.Size = new System.Drawing.Size(153, 188);
			this.flp_LogButtons.TabIndex = 20;
			// 
			// btn_OpenLog
			// 
			this.btn_OpenLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_OpenLog.Location = new System.Drawing.Point(0, 58);
			this.btn_OpenLog.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.btn_OpenLog.Name = "btn_OpenLog";
			this.btn_OpenLog.Size = new System.Drawing.Size(153, 35);
			this.btn_OpenLog.TabIndex = 8;
			this.btn_OpenLog.Text = "Open Log";
			this.btn_OpenLog.UseVisualStyleBackColor = true;
			this.btn_OpenLog.Click += new System.EventHandler(this.btn_OpenLog_Click);
			// 
			// saveDlg_SaveFileListPrompt
			// 
			this.saveDlg_SaveFileListPrompt.DefaultExt = "zmd";
			this.saveDlg_SaveFileListPrompt.FileName = "Untitled";
			this.saveDlg_SaveFileListPrompt.Filter = "Zero Munge Data files|*.zmd";
			this.saveDlg_SaveFileListPrompt.Title = "Save File List As";
			this.saveDlg_SaveFileListPrompt.FileOk += new System.ComponentModel.CancelEventHandler(this.saveDlg_SaveFileListPrompt_FileOk);
			// 
			// openDlg_OpenFileListPrompt
			// 
			this.openDlg_OpenFileListPrompt.Filter = "Zero Munge Data files|*.zmd";
			this.openDlg_OpenFileListPrompt.Title = "Open File List";
			// 
			// openDlg_CreateSideMungeFolderPrompt
			// 
			this.openDlg_CreateSideMungeFolderPrompt.Filter = "REQ files|*.req";
			this.openDlg_CreateSideMungeFolderPrompt.InitialDirectory = "C:\\BF2_ModTools";
			this.openDlg_CreateSideMungeFolderPrompt.RestoreDirectory = true;
			this.openDlg_CreateSideMungeFolderPrompt.Title = "Select Side REQ file";
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stat_JobStatus,
            this.stat_UpdateLink,
            this.toolStripStatusLabel1,
            this.stat_LogLength,
            this.stat_LogLines});
			this.statusStrip.Location = new System.Drawing.Point(0, 906);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
			this.statusStrip.Size = new System.Drawing.Size(1176, 36);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 21;
			this.statusStrip.Text = "statusStrip1";
			// 
			// stat_JobStatus
			// 
			this.stat_JobStatus.Name = "stat_JobStatus";
			this.stat_JobStatus.Size = new System.Drawing.Size(88, 29);
			this.stat_JobStatus.Text = "JobStatus";
			// 
			// stat_UpdateLink
			// 
			this.stat_UpdateLink.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.stat_UpdateLink.IsLink = true;
			this.stat_UpdateLink.Name = "stat_UpdateLink";
			this.stat_UpdateLink.Size = new System.Drawing.Size(105, 29);
			this.stat_UpdateLink.Text = "UpdateLink";
			this.stat_UpdateLink.Click += new System.EventHandler(this.stat_UpdateLink_Click);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(799, 29);
			this.toolStripStatusLabel1.Spring = true;
			// 
			// stat_LogLength
			// 
			this.stat_LogLength.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.stat_LogLength.Name = "stat_LogLength";
			this.stat_LogLength.Size = new System.Drawing.Size(90, 29);
			this.stat_LogLength.Text = "length : 0";
			// 
			// stat_LogLines
			// 
			this.stat_LogLines.Name = "stat_LogLines";
			this.stat_LogLines.Size = new System.Drawing.Size(71, 29);
			this.stat_LogLines.Text = "lines : 0";
			// 
			// openDlg_CreateWorldMungeFolderPrompt
			// 
			this.openDlg_CreateWorldMungeFolderPrompt.Filter = "REQ files|*.req";
			this.openDlg_CreateWorldMungeFolderPrompt.InitialDirectory = "C:\\BF2_ModTools";
			this.openDlg_CreateWorldMungeFolderPrompt.RestoreDirectory = true;
			this.openDlg_CreateWorldMungeFolderPrompt.Title = "Select World REQ file";
			// 
			// ZeroMunge
			// 
			this.AcceptButton = this.btn_Run;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(1176, 942);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.flp_LogButtons);
			this.Controls.Add(this.menu_MainForm);
			this.Controls.Add(this.pan_MungedFilesEdit);
			this.Controls.Add(this.cont_Panels);
			this.Controls.Add(this.flp_FileButtons);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menu_MainForm;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MinimumSize = new System.Drawing.Size(1189, 916);
			this.Name = "ZeroMunge";
			this.Text = "Zero Munge";
			this.Activated += new System.EventHandler(this.ZeroMunge_Activated);
			this.Deactivate += new System.EventHandler(this.ZeroMunge_Deactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZeroMunge_FormClosing);
			this.Load += new System.EventHandler(this.ZeroMunge_Load);
			this.Shown += new System.EventHandler(this.ZeroMunge_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZeroMunge_KeyDown);
			this.Resize += new System.EventHandler(this.ZeroMunge_Resize);
			this.pan_MungedFilesEdit.ResumeLayout(false);
			this.pan_MungedFilesEdit.PerformLayout();
			this.status_MungedFilesEdit.ResumeLayout(false);
			this.status_MungedFilesEdit.PerformLayout();
			this.cmenu_Text.ResumeLayout(false);
			this.cont_Panels.Panel1.ResumeLayout(false);
			this.cont_Panels.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cont_Panels)).EndInit();
			this.cont_Panels.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.data_Files)).EndInit();
			this.cmenu_dataGrid.ResumeLayout(false);
			this.cmenu_TrayIcon.ResumeLayout(false);
			this.menu_MainForm.ResumeLayout(false);
			this.menu_MainForm.PerformLayout();
			this.flp_FileButtons.ResumeLayout(false);
			this.flp_LogButtons.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
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
		public System.Windows.Forms.Button btn_ClearLog;
		public System.Windows.Forms.Button btn_OpenMungeLog;
		public System.Windows.Forms.Button btn_SaveLog;
		public System.Windows.Forms.SaveFileDialog saveDlg_SaveLogPrompt;
		public System.Windows.Forms.Button btn_AddFolders;
		public System.Windows.Forms.Button btn_AddProject;
		public System.Windows.Forms.Button btn_RemoveAllFiles;
		public System.Windows.Forms.Button btn_Cancel;
		public System.Windows.Forms.NotifyIcon trayIcon;
		public System.Windows.Forms.ContextMenuStrip cmenu_TrayIcon;
		public System.Windows.Forms.CheckedListBox clist_Files;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btn_SetGamePath;
		private System.Windows.Forms.Button button2;
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
		private System.Windows.Forms.MenuStrip menu_MainForm;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_cancelToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menu_addFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_addFoldersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_addProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menu_removeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_removeAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_setGamePathToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_prefsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_aboutToolStripMenuItem;
		private System.Windows.Forms.FlowLayoutPanel flp_FileButtons;
		private System.Windows.Forms.FlowLayoutPanel flp_LogButtons;
		private System.Windows.Forms.ToolStripMenuItem menu_newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ToolStripMenuItem menu_viewHelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
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
		private System.Windows.Forms.DataGridViewCheckBoxColumn col_IsValid;
		public System.Windows.Forms.SaveFileDialog saveDlg_SaveFileListPrompt;
		public System.Windows.Forms.OpenFileDialog openDlg_OpenFileListPrompt;
		private System.Windows.Forms.ToolStripMenuItem menu_checkForUpdatesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem menu_provideFeedbackToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_reportBugToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_provideSuggestionToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem menu_viewOpenIssuesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem menu_viewChangelogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_viewLicenseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_viewReadmeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cmenu_TrayIcon_Run;
		private System.Windows.Forms.ToolStripMenuItem cmenu_TrayIcon_Cancel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem menu_openRecentToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		public System.Windows.Forms.Button btn_EasyFilePicker;
		private System.Windows.Forms.ToolStripMenuItem menu_easyFilePickerToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_createSideMungeFolderToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openDlg_CreateSideMungeFolderPrompt;
		public System.Windows.Forms.DataGridView data_Files;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
		private System.Windows.Forms.ToolStripMenuItem menu_logSubToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_copyLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_saveLogAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_clearLogToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel stat_LogLength;
		private System.Windows.Forms.ToolStripStatusLabel stat_LogLines;
		public System.Windows.Forms.ToolStripStatusLabel stat_JobStatus;
		private System.Windows.Forms.ToolStripStatusLabel stat_UpdateLink;
		private System.Windows.Forms.ToolStripMenuItem menu_createWorldMungeFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_fixWorldMungeScriptsToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openDlg_CreateWorldMungeFolderPrompt;
		private System.Windows.Forms.ToolStripMenuItem menu_modifyMungedSoundFoldersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_fixSoundMungeFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_openGameLog;
		private System.Windows.Forms.ToolStripMenuItem menu_setPreferredEditor;
		private System.Windows.Forms.ToolStripMenuItem menu_openModToolsExe;
		private System.Windows.Forms.ToolStripMenuItem menu_openGameExe;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.ToolStripMenuItem menu_openGameFolder;
		private System.Windows.Forms.ToolStripMenuItem menu_launchZeroEditor;
		private System.Windows.Forms.ToolStripMenuItem menu_debugMission;
		private System.Windows.Forms.ToolStripMenuItem menu_strip_platform;
		private System.Windows.Forms.ToolStripMenuItem menu_pcPlatform;
		private System.Windows.Forms.ToolStripMenuItem menu_xboxPlatform;
		private System.Windows.Forms.ToolStripMenuItem menu_ps2Platform;
		private System.Windows.Forms.ToolStripMenuItem menu_launchPPSSPP;
		private System.Windows.Forms.ContextMenuStrip cmenu_dataGrid;
		private System.Windows.Forms.ToolStripMenuItem menu_openProjectFolderInEditor;
		private System.Windows.Forms.ToolStripMenuItem menu_openBuildCmd;
		private System.Windows.Forms.ToolStripMenuItem menu_openStagingDirectory;
		private System.Windows.Forms.ToolStripMenuItem menu_gametoastForums;
		private System.Windows.Forms.ToolStripMenuItem menu_gametoastGithub;
		private System.Windows.Forms.ToolStripMenuItem menu_openProjectFolder;
		public System.Windows.Forms.Button btn_clean;
		private System.Windows.Forms.ToolStripMenuItem menu_Battlefront2API;
		private AltUIMungePanel mungePanel;
		private System.Windows.Forms.ToolStripMenuItem menu_alternateUI;
		private System.Windows.Forms.ToolStripMenuItem menu_addMission;
		private System.Windows.Forms.ToolStripMenuItem menu_openProjectFolder2;
		public System.Windows.Forms.Button btn_OpenLog;
		private System.Windows.Forms.ToolStripMenuItem menu_openLog;
		private System.Windows.Forms.ToolStripMenuItem menu_openMungeLog;
	}
}

