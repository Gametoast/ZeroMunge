namespace ZeroMunge
{
	partial class FileCopyForm
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileCopyForm));
			this.btn_copy = new System.Windows.Forms.Button();
			this.chk_checkAll = new System.Windows.Forms.CheckBox();
			this.combo_dest = new System.Windows.Forms.ComboBox();
			this.cxt_dest = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menu_removeSelectedDest = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openDestInExplorer = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.combo_source = new System.Windows.Forms.ComboBox();
			this.cxt_sourceCombo = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menu_removeSelectedSource = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_openSourceInExplorer = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_browseLocal = new System.Windows.Forms.Button();
			this.tree_fileTree = new System.Windows.Forms.TreeView();
			this.group_checkUncheck = new System.Windows.Forms.GroupBox();
			this.btn_generateCopyScript = new System.Windows.Forms.Button();
			this.txt_output = new System.Windows.Forms.TextBox();
			this.btn_listFiles = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.menu_mainStrip = new System.Windows.Forms.MenuStrip();
			this.menu_ftpClient = new System.Windows.Forms.ToolStripMenuItem();
			this.winSCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_about = new System.Windows.Forms.ToolStripMenuItem();
			this.spin_timeout = new System.Windows.Forms.NumericUpDown();
			this.grp_timeout = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.group_copyScripts = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.list_copyScripts = new System.Windows.Forms.ListBox();
			this.cxt_listCopyScripts = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menu_viewSelectedFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_runSelectedFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_deleteSelectedBatchFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_listFilesToCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.cxt_dest.SuspendLayout();
			this.cxt_sourceCombo.SuspendLayout();
			this.group_checkUncheck.SuspendLayout();
			this.menu_mainStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spin_timeout)).BeginInit();
			this.grp_timeout.SuspendLayout();
			this.group_copyScripts.SuspendLayout();
			this.cxt_listCopyScripts.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_copy
			// 
			this.btn_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_copy.Location = new System.Drawing.Point(181, 14);
			this.btn_copy.Name = "btn_copy";
			this.btn_copy.Size = new System.Drawing.Size(129, 39);
			this.btn_copy.TabIndex = 19;
			this.btn_copy.Text = "&Copy to Dest";
			this.btn_copy.UseVisualStyleBackColor = true;
			this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
			// 
			// chk_checkAll
			// 
			this.chk_checkAll.AutoSize = true;
			this.chk_checkAll.Checked = true;
			this.chk_checkAll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_checkAll.Location = new System.Drawing.Point(6, 25);
			this.chk_checkAll.Name = "chk_checkAll";
			this.chk_checkAll.Size = new System.Drawing.Size(168, 24);
			this.chk_checkAll.TabIndex = 17;
			this.chk_checkAll.Text = "Check/Uncheck All";
			this.chk_checkAll.UseVisualStyleBackColor = true;
			this.chk_checkAll.CheckedChanged += new System.EventHandler(this.chk_checkAll_CheckedChanged);
			// 
			// combo_dest
			// 
			this.combo_dest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.combo_dest.ContextMenuStrip = this.cxt_dest;
			this.combo_dest.FormattingEnabled = true;
			this.combo_dest.Items.AddRange(new object[] {
            "ftp://xbox:xbox@192.168.1.158/F/Games/StarWarsBattlefront2/Data/_LVL_XBOX/addon/0" +
                "07",
            "Z:\\PSP\\PSP_GAME\\USRDIR\\data\\_lvl_psp\\addon\\003"});
			this.combo_dest.Location = new System.Drawing.Point(84, 419);
			this.combo_dest.Name = "combo_dest";
			this.combo_dest.Size = new System.Drawing.Size(636, 28);
			this.combo_dest.TabIndex = 16;
			this.combo_dest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.combo_dest_KeyDown);
			// 
			// cxt_dest
			// 
			this.cxt_dest.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.cxt_dest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_removeSelectedDest,
            this.menu_openDestInExplorer});
			this.cxt_dest.Name = "cxt_dest";
			this.cxt_dest.Size = new System.Drawing.Size(261, 68);
			// 
			// menu_removeSelectedDest
			// 
			this.menu_removeSelectedDest.Name = "menu_removeSelectedDest";
			this.menu_removeSelectedDest.Size = new System.Drawing.Size(260, 32);
			this.menu_removeSelectedDest.Text = "Remove Selected Item";
			this.menu_removeSelectedDest.Click += new System.EventHandler(this.menu_removeSelectedDest_Click);
			// 
			// menu_openDestInExplorer
			// 
			this.menu_openDestInExplorer.Name = "menu_openDestInExplorer";
			this.menu_openDestInExplorer.Size = new System.Drawing.Size(260, 32);
			this.menu_openDestInExplorer.Text = "Open in Explorer";
			this.menu_openDestInExplorer.Click += new System.EventHandler(this.openComboTextInExplorer);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 422);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 20);
			this.label2.TabIndex = 15;
			this.label2.Text = "Dest";
			// 
			// combo_source
			// 
			this.combo_source.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.combo_source.ContextMenuStrip = this.cxt_sourceCombo;
			this.combo_source.FormattingEnabled = true;
			this.combo_source.Items.AddRange(new object[] {
            "Z:\\BF2_ModTools\\data_ABC\\_LVL_XBOX"});
			this.combo_source.Location = new System.Drawing.Point(84, 47);
			this.combo_source.Name = "combo_source";
			this.combo_source.Size = new System.Drawing.Size(636, 28);
			this.combo_source.TabIndex = 14;
			this.combo_source.SelectedIndexChanged += new System.EventHandler(this.combo_source_SelectedIndexChanged);
			this.combo_source.KeyDown += new System.Windows.Forms.KeyEventHandler(this.combo_source_KeyDown);
			// 
			// cxt_sourceCombo
			// 
			this.cxt_sourceCombo.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.cxt_sourceCombo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_removeSelectedSource,
            this.menu_openSourceInExplorer});
			this.cxt_sourceCombo.Name = "cxt_sourceCombo";
			this.cxt_sourceCombo.Size = new System.Drawing.Size(257, 68);
			// 
			// menu_removeSelectedSource
			// 
			this.menu_removeSelectedSource.Name = "menu_removeSelectedSource";
			this.menu_removeSelectedSource.Size = new System.Drawing.Size(256, 32);
			this.menu_removeSelectedSource.Text = "Remove SelectedITem";
			this.menu_removeSelectedSource.Click += new System.EventHandler(this.menu_removeSelectedSource_Click);
			// 
			// menu_openSourceInExplorer
			// 
			this.menu_openSourceInExplorer.Name = "menu_openSourceInExplorer";
			this.menu_openSourceInExplorer.Size = new System.Drawing.Size(256, 32);
			this.menu_openSourceInExplorer.Text = "Open in Explorer";
			this.menu_openSourceInExplorer.Click += new System.EventHandler(this.openComboTextInExplorer);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 20);
			this.label1.TabIndex = 13;
			this.label1.Text = "Source";
			// 
			// btn_browseLocal
			// 
			this.btn_browseLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_browseLocal.Location = new System.Drawing.Point(750, 44);
			this.btn_browseLocal.Name = "btn_browseLocal";
			this.btn_browseLocal.Size = new System.Drawing.Size(88, 36);
			this.btn_browseLocal.TabIndex = 12;
			this.btn_browseLocal.Text = "&Browse";
			this.btn_browseLocal.UseVisualStyleBackColor = true;
			this.btn_browseLocal.Click += new System.EventHandler(this.btn_browse_Click);
			// 
			// tree_fileTree
			// 
			this.tree_fileTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tree_fileTree.CheckBoxes = true;
			this.tree_fileTree.Location = new System.Drawing.Point(6, 59);
			this.tree_fileTree.Name = "tree_fileTree";
			this.tree_fileTree.Size = new System.Drawing.Size(304, 255);
			this.tree_fileTree.TabIndex = 21;
			this.tree_fileTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_fileTree_AfterCheck);
			// 
			// group_checkUncheck
			// 
			this.group_checkUncheck.Controls.Add(this.chk_checkAll);
			this.group_checkUncheck.Controls.Add(this.tree_fileTree);
			this.group_checkUncheck.Controls.Add(this.btn_copy);
			this.group_checkUncheck.Location = new System.Drawing.Point(22, 82);
			this.group_checkUncheck.Name = "group_checkUncheck";
			this.group_checkUncheck.Size = new System.Drawing.Size(316, 320);
			this.group_checkUncheck.TabIndex = 22;
			this.group_checkUncheck.TabStop = false;
			this.group_checkUncheck.Text = "Copy To Dest";
			// 
			// btn_generateCopyScript
			// 
			this.btn_generateCopyScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_generateCopyScript.Location = new System.Drawing.Point(750, 111);
			this.btn_generateCopyScript.Name = "btn_generateCopyScript";
			this.btn_generateCopyScript.Size = new System.Drawing.Size(88, 87);
			this.btn_generateCopyScript.TabIndex = 23;
			this.btn_generateCopyScript.Text = "Generate Copy script";
			this.btn_generateCopyScript.UseVisualStyleBackColor = true;
			this.btn_generateCopyScript.Click += new System.EventHandler(this.btn_generateCopyScript_Click);
			// 
			// txt_output
			// 
			this.txt_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_output.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_output.Location = new System.Drawing.Point(22, 453);
			this.txt_output.Multiline = true;
			this.txt_output.Name = "txt_output";
			this.txt_output.ReadOnly = true;
			this.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_output.Size = new System.Drawing.Size(698, 228);
			this.txt_output.TabIndex = 24;
			// 
			// btn_listFiles
			// 
			this.btn_listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_listFiles.Location = new System.Drawing.Point(750, 555);
			this.btn_listFiles.Name = "btn_listFiles";
			this.btn_listFiles.Size = new System.Drawing.Size(88, 74);
			this.btn_listFiles.TabIndex = 25;
			this.btn_listFiles.Text = "List Files at dest";
			this.btn_listFiles.UseVisualStyleBackColor = true;
			this.btn_listFiles.Click += new System.EventHandler(this.btn_listFiles_Click);
			// 
			// btn_clear
			// 
			this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_clear.Location = new System.Drawing.Point(750, 635);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(88, 36);
			this.btn_clear.TabIndex = 26;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = true;
			this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
			// 
			// menu_mainStrip
			// 
			this.menu_mainStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menu_mainStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menu_mainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_ftpClient,
            this.menu_about});
			this.menu_mainStrip.Location = new System.Drawing.Point(0, 0);
			this.menu_mainStrip.Name = "menu_mainStrip";
			this.menu_mainStrip.Size = new System.Drawing.Size(850, 33);
			this.menu_mainStrip.TabIndex = 27;
			this.menu_mainStrip.Text = "menuStrip1";
			// 
			// menu_ftpClient
			// 
			this.menu_ftpClient.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.winSCPToolStripMenuItem});
			this.menu_ftpClient.Name = "menu_ftpClient";
			this.menu_ftpClient.Size = new System.Drawing.Size(103, 29);
			this.menu_ftpClient.Text = "Ftp Client";
			// 
			// winSCPToolStripMenuItem
			// 
			this.winSCPToolStripMenuItem.Name = "winSCPToolStripMenuItem";
			this.winSCPToolStripMenuItem.Size = new System.Drawing.Size(176, 34);
			this.winSCPToolStripMenuItem.Text = "WinSCP";
			this.winSCPToolStripMenuItem.Click += new System.EventHandler(this.winSCPToolStripMenuItem_Click);
			// 
			// menu_about
			// 
			this.menu_about.Name = "menu_about";
			this.menu_about.Size = new System.Drawing.Size(78, 29);
			this.menu_about.Text = "About";
			this.menu_about.Click += new System.EventHandler(this.menu_about_Clicked);
			// 
			// spin_timeout
			// 
			this.spin_timeout.Location = new System.Drawing.Point(12, 25);
			this.spin_timeout.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.spin_timeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.spin_timeout.Name = "spin_timeout";
			this.spin_timeout.Size = new System.Drawing.Size(52, 26);
			this.spin_timeout.TabIndex = 28;
			this.spin_timeout.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// grp_timeout
			// 
			this.grp_timeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.grp_timeout.Controls.Add(this.label3);
			this.grp_timeout.Controls.Add(this.spin_timeout);
			this.grp_timeout.Location = new System.Drawing.Point(738, 422);
			this.grp_timeout.Name = "grp_timeout";
			this.grp_timeout.Size = new System.Drawing.Size(112, 86);
			this.grp_timeout.TabIndex = 29;
			this.grp_timeout.TabStop = false;
			this.grp_timeout.Text = "FTP timeout";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 20);
			this.label3.TabIndex = 29;
			this.label3.Text = "Seconds";
			// 
			// group_copyScripts
			// 
			this.group_copyScripts.Controls.Add(this.label5);
			this.group_copyScripts.Controls.Add(this.label4);
			this.group_copyScripts.Controls.Add(this.list_copyScripts);
			this.group_copyScripts.Location = new System.Drawing.Point(358, 82);
			this.group_copyScripts.Name = "group_copyScripts";
			this.group_copyScripts.Size = new System.Drawing.Size(362, 320);
			this.group_copyScripts.TabIndex = 32;
			this.group_copyScripts.TabStop = false;
			this.group_copyScripts.Text = "Copy Scripts";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Location = new System.Drawing.Point(6, 29);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(169, 22);
			this.label5.TabIndex = 2;
			this.label5.Text = "Right click item to view";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4.Location = new System.Drawing.Point(183, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(175, 22);
			this.label4.TabIndex = 1;
			this.label4.Text = "Double click item to run";
			// 
			// list_copyScripts
			// 
			this.list_copyScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.list_copyScripts.ContextMenuStrip = this.cxt_listCopyScripts;
			this.list_copyScripts.FormattingEnabled = true;
			this.list_copyScripts.IntegralHeight = false;
			this.list_copyScripts.ItemHeight = 20;
			this.list_copyScripts.Location = new System.Drawing.Point(6, 59);
			this.list_copyScripts.Name = "list_copyScripts";
			this.list_copyScripts.Size = new System.Drawing.Size(350, 255);
			this.list_copyScripts.TabIndex = 0;
			this.list_copyScripts.DoubleClick += new System.EventHandler(this.list_copyScripts_DoubleClick);
			// 
			// cxt_listCopyScripts
			// 
			this.cxt_listCopyScripts.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.cxt_listCopyScripts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_viewSelectedFile,
            this.menu_runSelectedFile,
            this.menu_deleteSelectedBatchFile,
            this.menu_listFilesToCopy});
			this.cxt_listCopyScripts.Name = "cxt_listCopyScripts";
			this.cxt_listCopyScripts.Size = new System.Drawing.Size(232, 132);
			// 
			// menu_viewSelectedFile
			// 
			this.menu_viewSelectedFile.Name = "menu_viewSelectedFile";
			this.menu_viewSelectedFile.Size = new System.Drawing.Size(231, 32);
			this.menu_viewSelectedFile.Text = "View selected file";
			this.menu_viewSelectedFile.Click += new System.EventHandler(this.menu_viewSelectedFile_Click);
			// 
			// menu_runSelectedFile
			// 
			this.menu_runSelectedFile.Name = "menu_runSelectedFile";
			this.menu_runSelectedFile.Size = new System.Drawing.Size(231, 32);
			this.menu_runSelectedFile.Text = "Run selected file";
			this.menu_runSelectedFile.Click += new System.EventHandler(this.list_copyScripts_DoubleClick);
			// 
			// menu_deleteSelectedBatchFile
			// 
			this.menu_deleteSelectedBatchFile.Name = "menu_deleteSelectedBatchFile";
			this.menu_deleteSelectedBatchFile.Size = new System.Drawing.Size(231, 32);
			this.menu_deleteSelectedBatchFile.Text = "Delete selected file";
			this.menu_deleteSelectedBatchFile.Click += new System.EventHandler(this.menu_deleteSelectedBatchFile_Click);
			// 
			// menu_listFilesToCopy
			// 
			this.menu_listFilesToCopy.Name = "menu_listFilesToCopy";
			this.menu_listFilesToCopy.Size = new System.Drawing.Size(231, 32);
			this.menu_listFilesToCopy.Text = "List files to copy";
			this.menu_listFilesToCopy.Click += new System.EventHandler(this.menu_listFilesToCopy_Click);
			// 
			// FileCopyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(850, 693);
			this.Controls.Add(this.group_copyScripts);
			this.Controls.Add(this.grp_timeout);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.btn_listFiles);
			this.Controls.Add(this.txt_output);
			this.Controls.Add(this.btn_generateCopyScript);
			this.Controls.Add(this.group_checkUncheck);
			this.Controls.Add(this.combo_dest);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.combo_source);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_browseLocal);
			this.Controls.Add(this.menu_mainStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menu_mainStrip;
			this.MinimumSize = new System.Drawing.Size(872, 749);
			this.Name = "FileCopyForm";
			this.Text = "Copy Files";
			this.cxt_dest.ResumeLayout(false);
			this.cxt_sourceCombo.ResumeLayout(false);
			this.group_checkUncheck.ResumeLayout(false);
			this.group_checkUncheck.PerformLayout();
			this.menu_mainStrip.ResumeLayout(false);
			this.menu_mainStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.spin_timeout)).EndInit();
			this.grp_timeout.ResumeLayout(false);
			this.grp_timeout.PerformLayout();
			this.group_copyScripts.ResumeLayout(false);
			this.group_copyScripts.PerformLayout();
			this.cxt_listCopyScripts.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btn_copy;
		private System.Windows.Forms.CheckBox chk_checkAll;
		private System.Windows.Forms.ComboBox combo_dest;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox combo_source;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_browseLocal;
		private System.Windows.Forms.TreeView tree_fileTree;
		private System.Windows.Forms.GroupBox group_checkUncheck;
		private System.Windows.Forms.Button btn_generateCopyScript;
		private System.Windows.Forms.TextBox txt_output;
		private System.Windows.Forms.Button btn_listFiles;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.MenuStrip menu_mainStrip;
		private System.Windows.Forms.ToolStripMenuItem menu_ftpClient;
		private System.Windows.Forms.ToolStripMenuItem winSCPToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_about;
		private System.Windows.Forms.NumericUpDown spin_timeout;
		private System.Windows.Forms.GroupBox grp_timeout;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ContextMenuStrip cxt_dest;
		private System.Windows.Forms.ToolStripMenuItem menu_removeSelectedDest;
		private System.Windows.Forms.ContextMenuStrip cxt_sourceCombo;
		private System.Windows.Forms.ToolStripMenuItem menu_removeSelectedSource;
		private System.Windows.Forms.GroupBox group_copyScripts;
		private System.Windows.Forms.ListBox list_copyScripts;
		private System.Windows.Forms.ContextMenuStrip cxt_listCopyScripts;
		private System.Windows.Forms.ToolStripMenuItem menu_viewSelectedFile;
		private System.Windows.Forms.ToolStripMenuItem menu_runSelectedFile;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolStripMenuItem menu_openSourceInExplorer;
		private System.Windows.Forms.ToolStripMenuItem menu_openDestInExplorer;
		private System.Windows.Forms.ToolStripMenuItem menu_deleteSelectedBatchFile;
		private System.Windows.Forms.ToolStripMenuItem menu_listFilesToCopy;
	}
}
