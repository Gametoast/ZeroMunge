namespace ZeroMunge
{
    partial class AltUIMungePanel
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
			this.group_platform = new System.Windows.Forms.GroupBox();
			this.btn_xbox = new System.Windows.Forms.RadioButton();
			this.btn_ps2 = new System.Windows.Forms.RadioButton();
			this.btn_pc = new System.Windows.Forms.RadioButton();
			this.grp_side = new System.Windows.Forms.GroupBox();
			this.combo_side = new System.Windows.Forms.ComboBox();
			this.grp_world = new System.Windows.Forms.GroupBox();
			this.combo_world = new System.Windows.Forms.ComboBox();
			this.grp_options = new System.Windows.Forms.GroupBox();
			this.check_addme = new System.Windows.Forms.CheckBox();
			this.check_missions = new System.Windows.Forms.CheckBox();
			this.check_common = new System.Windows.Forms.CheckBox();
			this.check_movies = new System.Windows.Forms.CheckBox();
			this.check_load = new System.Windows.Forms.CheckBox();
			this.check_sound = new System.Windows.Forms.CheckBox();
			this.check_shell = new System.Windows.Forms.CheckBox();
			this.group_copyDest = new System.Windows.Forms.GroupBox();
			this.btn_browseOutputFolder = new System.Windows.Forms.Button();
			this.txt_copyDestFolder = new System.Windows.Forms.TextBox();
			this.group_overrideCommand = new System.Windows.Forms.GroupBox();
			this.check_useOverrideCommand = new System.Windows.Forms.CheckBox();
			this.combo_overrideCommand = new System.Windows.Forms.ComboBox();
			this.FormToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.btn_copy = new System.Windows.Forms.Button();
			this.check_copyIfNewer = new System.Windows.Forms.CheckBox();
			this.group_mungeFolder = new System.Windows.Forms.GroupBox();
			this.cxt_menu_mungeFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txt_mungeFolder = new System.Windows.Forms.TextBox();
			this.check_autoCopy = new System.Windows.Forms.CheckBox();
			this.btn_generateFTPScript = new System.Windows.Forms.Button();
			this.cxt_menu_copyDest = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openCopyDestInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cxt_menu_overrideCommand = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openInEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.group_platform.SuspendLayout();
			this.grp_side.SuspendLayout();
			this.grp_world.SuspendLayout();
			this.grp_options.SuspendLayout();
			this.group_copyDest.SuspendLayout();
			this.group_overrideCommand.SuspendLayout();
			this.group_mungeFolder.SuspendLayout();
			this.cxt_menu_mungeFolder.SuspendLayout();
			this.cxt_menu_copyDest.SuspendLayout();
			this.cxt_menu_overrideCommand.SuspendLayout();
			this.SuspendLayout();
			// 
			// group_platform
			// 
			this.group_platform.Controls.Add(this.btn_xbox);
			this.group_platform.Controls.Add(this.btn_ps2);
			this.group_platform.Controls.Add(this.btn_pc);
			this.group_platform.Location = new System.Drawing.Point(3, 11);
			this.group_platform.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.group_platform.Name = "group_platform";
			this.group_platform.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.group_platform.Size = new System.Drawing.Size(242, 68);
			this.group_platform.TabIndex = 3;
			this.group_platform.TabStop = false;
			this.group_platform.Text = "Platform";
			// 
			// btn_xbox
			// 
			this.btn_xbox.AutoSize = true;
			this.btn_xbox.Location = new System.Drawing.Point(153, 29);
			this.btn_xbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_xbox.Name = "btn_xbox";
			this.btn_xbox.Size = new System.Drawing.Size(79, 24);
			this.btn_xbox.TabIndex = 2;
			this.btn_xbox.Text = "XBOX";
			this.btn_xbox.UseVisualStyleBackColor = true;
			this.btn_xbox.CheckedChanged += new System.EventHandler(this.platform_CheckChanged);
			// 
			// btn_ps2
			// 
			this.btn_ps2.AutoSize = true;
			this.btn_ps2.Location = new System.Drawing.Point(76, 29);
			this.btn_ps2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_ps2.Name = "btn_ps2";
			this.btn_ps2.Size = new System.Drawing.Size(64, 24);
			this.btn_ps2.TabIndex = 1;
			this.btn_ps2.Text = "PS2";
			this.btn_ps2.UseVisualStyleBackColor = true;
			this.btn_ps2.CheckedChanged += new System.EventHandler(this.platform_CheckChanged);
			// 
			// btn_pc
			// 
			this.btn_pc.AutoSize = true;
			this.btn_pc.Checked = true;
			this.btn_pc.Location = new System.Drawing.Point(9, 29);
			this.btn_pc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_pc.Name = "btn_pc";
			this.btn_pc.Size = new System.Drawing.Size(55, 24);
			this.btn_pc.TabIndex = 0;
			this.btn_pc.TabStop = true;
			this.btn_pc.Text = "PC";
			this.btn_pc.UseVisualStyleBackColor = true;
			this.btn_pc.CheckedChanged += new System.EventHandler(this.platform_CheckChanged);
			// 
			// grp_side
			// 
			this.grp_side.Controls.Add(this.combo_side);
			this.grp_side.Location = new System.Drawing.Point(256, 91);
			this.grp_side.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grp_side.Name = "grp_side";
			this.grp_side.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grp_side.Size = new System.Drawing.Size(242, 68);
			this.grp_side.TabIndex = 4;
			this.grp_side.TabStop = false;
			this.grp_side.Text = "Side";
			// 
			// combo_side
			// 
			this.combo_side.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.combo_side.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_side.FormattingEnabled = true;
			this.combo_side.Items.AddRange(new object[] {
            "Everything",
            "Nothing"});
			this.combo_side.Location = new System.Drawing.Point(9, 23);
			this.combo_side.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.combo_side.Name = "combo_side";
			this.combo_side.Size = new System.Drawing.Size(222, 28);
			this.combo_side.TabIndex = 0;
			// 
			// grp_world
			// 
			this.grp_world.Controls.Add(this.combo_world);
			this.grp_world.Location = new System.Drawing.Point(3, 91);
			this.grp_world.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grp_world.Name = "grp_world";
			this.grp_world.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grp_world.Size = new System.Drawing.Size(242, 68);
			this.grp_world.TabIndex = 5;
			this.grp_world.TabStop = false;
			this.grp_world.Text = "World";
			// 
			// combo_world
			// 
			this.combo_world.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.combo_world.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_world.FormattingEnabled = true;
			this.combo_world.Items.AddRange(new object[] {
            "Everything",
            "Nothing"});
			this.combo_world.Location = new System.Drawing.Point(9, 23);
			this.combo_world.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.combo_world.Name = "combo_world";
			this.combo_world.Size = new System.Drawing.Size(222, 28);
			this.combo_world.TabIndex = 0;
			// 
			// grp_options
			// 
			this.grp_options.Controls.Add(this.check_addme);
			this.grp_options.Controls.Add(this.check_missions);
			this.grp_options.Controls.Add(this.check_common);
			this.grp_options.Controls.Add(this.check_movies);
			this.grp_options.Controls.Add(this.check_load);
			this.grp_options.Controls.Add(this.check_sound);
			this.grp_options.Controls.Add(this.check_shell);
			this.grp_options.Location = new System.Drawing.Point(4, 168);
			this.grp_options.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grp_options.Name = "grp_options";
			this.grp_options.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grp_options.Size = new System.Drawing.Size(242, 165);
			this.grp_options.TabIndex = 12;
			this.grp_options.TabStop = false;
			this.grp_options.Text = "Munge these";
			// 
			// check_addme
			// 
			this.check_addme.AutoSize = true;
			this.check_addme.Checked = true;
			this.check_addme.CheckState = System.Windows.Forms.CheckState.Checked;
			this.check_addme.Location = new System.Drawing.Point(111, 129);
			this.check_addme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.check_addme.Name = "check_addme";
			this.check_addme.Size = new System.Drawing.Size(86, 24);
			this.check_addme.TabIndex = 19;
			this.check_addme.Text = "Addme";
			this.check_addme.UseVisualStyleBackColor = true;
			this.check_addme.CheckedChanged += new System.EventHandler(this.check_addme_CheckedChanged);
			// 
			// check_missions
			// 
			this.check_missions.AutoSize = true;
			this.check_missions.Checked = true;
			this.check_missions.CheckState = System.Windows.Forms.CheckState.Checked;
			this.check_missions.Location = new System.Drawing.Point(8, 98);
			this.check_missions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.check_missions.Name = "check_missions";
			this.check_missions.Size = new System.Drawing.Size(96, 24);
			this.check_missions.TabIndex = 17;
			this.check_missions.Text = "Missions";
			this.check_missions.UseVisualStyleBackColor = true;
			// 
			// check_common
			// 
			this.check_common.AutoSize = true;
			this.check_common.Checked = true;
			this.check_common.CheckState = System.Windows.Forms.CheckState.Checked;
			this.check_common.Location = new System.Drawing.Point(111, 98);
			this.check_common.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.check_common.Name = "check_common";
			this.check_common.Size = new System.Drawing.Size(99, 24);
			this.check_common.TabIndex = 16;
			this.check_common.Text = "Common";
			this.check_common.UseVisualStyleBackColor = true;
			// 
			// check_movies
			// 
			this.check_movies.AutoSize = true;
			this.check_movies.Location = new System.Drawing.Point(111, 68);
			this.check_movies.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.check_movies.Name = "check_movies";
			this.check_movies.Size = new System.Drawing.Size(84, 24);
			this.check_movies.TabIndex = 15;
			this.check_movies.Text = "Movies";
			this.check_movies.UseVisualStyleBackColor = true;
			// 
			// check_load
			// 
			this.check_load.AutoSize = true;
			this.check_load.Location = new System.Drawing.Point(111, 32);
			this.check_load.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.check_load.Name = "check_load";
			this.check_load.Size = new System.Drawing.Size(71, 24);
			this.check_load.TabIndex = 14;
			this.check_load.Text = "Load";
			this.check_load.UseVisualStyleBackColor = true;
			// 
			// check_sound
			// 
			this.check_sound.AutoSize = true;
			this.check_sound.Location = new System.Drawing.Point(9, 68);
			this.check_sound.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.check_sound.Name = "check_sound";
			this.check_sound.Size = new System.Drawing.Size(82, 24);
			this.check_sound.TabIndex = 13;
			this.check_sound.Text = "Sound";
			this.check_sound.UseVisualStyleBackColor = true;
			// 
			// check_shell
			// 
			this.check_shell.AutoSize = true;
			this.check_shell.Location = new System.Drawing.Point(9, 32);
			this.check_shell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.check_shell.Name = "check_shell";
			this.check_shell.Size = new System.Drawing.Size(70, 24);
			this.check_shell.TabIndex = 12;
			this.check_shell.Text = "Shell";
			this.check_shell.UseVisualStyleBackColor = true;
			// 
			// group_copyDest
			// 
			this.group_copyDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.group_copyDest.Controls.Add(this.btn_browseOutputFolder);
			this.group_copyDest.Controls.Add(this.txt_copyDestFolder);
			this.group_copyDest.Location = new System.Drawing.Point(256, 11);
			this.group_copyDest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.group_copyDest.Name = "group_copyDest";
			this.group_copyDest.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.group_copyDest.Size = new System.Drawing.Size(714, 68);
			this.group_copyDest.TabIndex = 13;
			this.group_copyDest.TabStop = false;
			this.group_copyDest.Text = "Copy Dest";
			// 
			// btn_browseOutputFolder
			// 
			this.btn_browseOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_browseOutputFolder.Location = new System.Drawing.Point(596, 28);
			this.btn_browseOutputFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_browseOutputFolder.Name = "btn_browseOutputFolder";
			this.btn_browseOutputFolder.Size = new System.Drawing.Size(112, 35);
			this.btn_browseOutputFolder.TabIndex = 1;
			this.btn_browseOutputFolder.Text = "Browse";
			this.btn_browseOutputFolder.UseVisualStyleBackColor = true;
			this.btn_browseOutputFolder.Click += new System.EventHandler(this.btn_browseOutputFolder_Click);
			// 
			// txt_copyDestFolder
			// 
			this.txt_copyDestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_copyDestFolder.ContextMenuStrip = this.cxt_menu_copyDest;
			this.txt_copyDestFolder.Location = new System.Drawing.Point(9, 29);
			this.txt_copyDestFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txt_copyDestFolder.Name = "txt_copyDestFolder";
			this.txt_copyDestFolder.Size = new System.Drawing.Size(576, 26);
			this.txt_copyDestFolder.TabIndex = 0;
			this.txt_copyDestFolder.TextChanged += new System.EventHandler(this.txt_outputFolder_TextChanged);
			// 
			// group_overrideCommand
			// 
			this.group_overrideCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.group_overrideCommand.ContextMenuStrip = this.cxt_menu_mungeFolder;
			this.group_overrideCommand.Controls.Add(this.check_useOverrideCommand);
			this.group_overrideCommand.Controls.Add(this.combo_overrideCommand);
			this.group_overrideCommand.Location = new System.Drawing.Point(256, 265);
			this.group_overrideCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.group_overrideCommand.Name = "group_overrideCommand";
			this.group_overrideCommand.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.group_overrideCommand.Size = new System.Drawing.Size(714, 68);
			this.group_overrideCommand.TabIndex = 14;
			this.group_overrideCommand.TabStop = false;
			this.group_overrideCommand.Text = "Override command";
			// 
			// check_useOverrideCommand
			// 
			this.check_useOverrideCommand.AutoSize = true;
			this.check_useOverrideCommand.Location = new System.Drawing.Point(8, 29);
			this.check_useOverrideCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.check_useOverrideCommand.Name = "check_useOverrideCommand";
			this.check_useOverrideCommand.Size = new System.Drawing.Size(94, 24);
			this.check_useOverrideCommand.TabIndex = 15;
			this.check_useOverrideCommand.Text = "Override";
			this.check_useOverrideCommand.UseVisualStyleBackColor = true;
			this.check_useOverrideCommand.CheckedChanged += new System.EventHandler(this.check_useOverrideCommand_CheckedChanged);
			// 
			// combo_overrideCommand
			// 
			this.combo_overrideCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.combo_overrideCommand.ContextMenuStrip = this.cxt_menu_overrideCommand;
			this.combo_overrideCommand.Location = new System.Drawing.Point(122, 28);
			this.combo_overrideCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.combo_overrideCommand.Name = "combo_overrideCommand";
			this.combo_overrideCommand.Size = new System.Drawing.Size(575, 28);
			this.combo_overrideCommand.TabIndex = 0;
			// 
			// btn_copy
			// 
			this.btn_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_copy.Location = new System.Drawing.Point(852, 84);
			this.btn_copy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_copy.Name = "btn_copy";
			this.btn_copy.Size = new System.Drawing.Size(112, 35);
			this.btn_copy.TabIndex = 2;
			this.btn_copy.Text = "Copy Now";
			this.btn_copy.UseVisualStyleBackColor = true;
			this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
			// 
			// check_copyIfNewer
			// 
			this.check_copyIfNewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.check_copyIfNewer.AutoSize = true;
			this.check_copyIfNewer.Checked = true;
			this.check_copyIfNewer.CheckState = System.Windows.Forms.CheckState.Checked;
			this.check_copyIfNewer.Location = new System.Drawing.Point(712, 97);
			this.check_copyIfNewer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.check_copyIfNewer.Name = "check_copyIfNewer";
			this.check_copyIfNewer.Size = new System.Drawing.Size(132, 24);
			this.check_copyIfNewer.TabIndex = 20;
			this.check_copyIfNewer.Text = "Copy if Newer";
			this.check_copyIfNewer.UseVisualStyleBackColor = true;
			// 
			// group_mungeFolder
			// 
			this.group_mungeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.group_mungeFolder.ContextMenuStrip = this.cxt_menu_mungeFolder;
			this.group_mungeFolder.Controls.Add(this.txt_mungeFolder);
			this.group_mungeFolder.Location = new System.Drawing.Point(256, 169);
			this.group_mungeFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.group_mungeFolder.Name = "group_mungeFolder";
			this.group_mungeFolder.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.group_mungeFolder.Size = new System.Drawing.Size(714, 68);
			this.group_mungeFolder.TabIndex = 14;
			this.group_mungeFolder.TabStop = false;
			this.group_mungeFolder.Text = "Munge Folder";
			// 
			// cxt_menu_mungeFolder
			// 
			this.cxt_menu_mungeFolder.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.cxt_menu_mungeFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInExplorerToolStripMenuItem});
			this.cxt_menu_mungeFolder.Name = "cxt_menu_mungeFolder";
			this.cxt_menu_mungeFolder.Size = new System.Drawing.Size(225, 36);
			// 
			// openInExplorerToolStripMenuItem
			// 
			this.openInExplorerToolStripMenuItem.Image = global::ZeroMunge.Properties.Resources.FolderOpen1;
			this.openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
			this.openInExplorerToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
			this.openInExplorerToolStripMenuItem.Text = "Open in Explorer";
			this.openInExplorerToolStripMenuItem.Click += new System.EventHandler(this.openInExplorerToolStripMenuItem_Click);
			// 
			// txt_mungeFolder
			// 
			this.txt_mungeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_mungeFolder.ContextMenuStrip = this.cxt_menu_mungeFolder;
			this.txt_mungeFolder.Enabled = false;
			this.txt_mungeFolder.Location = new System.Drawing.Point(9, 29);
			this.txt_mungeFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txt_mungeFolder.Name = "txt_mungeFolder";
			this.txt_mungeFolder.Size = new System.Drawing.Size(690, 26);
			this.txt_mungeFolder.TabIndex = 0;
			// 
			// check_autoCopy
			// 
			this.check_autoCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.check_autoCopy.AutoSize = true;
			this.check_autoCopy.Checked = true;
			this.check_autoCopy.CheckState = System.Windows.Forms.CheckState.Checked;
			this.check_autoCopy.Location = new System.Drawing.Point(613, 135);
			this.check_autoCopy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.check_autoCopy.Name = "check_autoCopy";
			this.check_autoCopy.Size = new System.Drawing.Size(228, 24);
			this.check_autoCopy.TabIndex = 21;
			this.check_autoCopy.Text = "Copy after Munge (PC only)";
			this.check_autoCopy.UseVisualStyleBackColor = true;
			this.check_autoCopy.CheckedChanged += new System.EventHandler(this.check_autoCopy_CheckedChanged);
			// 
			// btn_generateFTPScript
			// 
			this.btn_generateFTPScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_generateFTPScript.Location = new System.Drawing.Point(852, 124);
			this.btn_generateFTPScript.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btn_generateFTPScript.Name = "btn_generateFTPScript";
			this.btn_generateFTPScript.Size = new System.Drawing.Size(112, 49);
			this.btn_generateFTPScript.TabIndex = 22;
			this.btn_generateFTPScript.Text = "Make FTP Script";
			this.btn_generateFTPScript.UseVisualStyleBackColor = true;
			this.btn_generateFTPScript.Visible = false;
			this.btn_generateFTPScript.Click += new System.EventHandler(this.btn_generateFTPScript_Click);
			// 
			// cxt_menu_copyDest
			// 
			this.cxt_menu_copyDest.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.cxt_menu_copyDest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCopyDestInExplorerToolStripMenuItem});
			this.cxt_menu_copyDest.Name = "cxt_menu_copyDest";
			this.cxt_menu_copyDest.Size = new System.Drawing.Size(313, 36);
			// 
			// openCopyDestInExplorerToolStripMenuItem
			// 
			this.openCopyDestInExplorerToolStripMenuItem.Image = global::ZeroMunge.Properties.Resources.FolderOpen1;
			this.openCopyDestInExplorerToolStripMenuItem.Name = "openCopyDestInExplorerToolStripMenuItem";
			this.openCopyDestInExplorerToolStripMenuItem.Size = new System.Drawing.Size(312, 32);
			this.openCopyDestInExplorerToolStripMenuItem.Text = "Open Copy Dest in Explorer";
			this.openCopyDestInExplorerToolStripMenuItem.Click += new System.EventHandler(this.openCopyDestInExplorerToolStripMenuItem_Click);
			// 
			// cxt_menu_overrideCommand
			// 
			this.cxt_menu_overrideCommand.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.cxt_menu_overrideCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInEditorToolStripMenuItem});
			this.cxt_menu_overrideCommand.Name = "cxt_menu_overrideCommand";
			this.cxt_menu_overrideCommand.Size = new System.Drawing.Size(208, 36);
			// 
			// openInEditorToolStripMenuItem
			// 
			this.openInEditorToolStripMenuItem.Image = global::ZeroMunge.Properties.Resources.TextEditorIcon;
			this.openInEditorToolStripMenuItem.Name = "openInEditorToolStripMenuItem";
			this.openInEditorToolStripMenuItem.Size = new System.Drawing.Size(248, 32);
			this.openInEditorToolStripMenuItem.Text = "Open in Editor";
			this.openInEditorToolStripMenuItem.Click += new System.EventHandler(this.openInEditorToolStripMenuItem_Click);
			// 
			// AltUIMungePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btn_generateFTPScript);
			this.Controls.Add(this.check_autoCopy);
			this.Controls.Add(this.group_mungeFolder);
			this.Controls.Add(this.check_copyIfNewer);
			this.Controls.Add(this.btn_copy);
			this.Controls.Add(this.group_overrideCommand);
			this.Controls.Add(this.group_copyDest);
			this.Controls.Add(this.grp_options);
			this.Controls.Add(this.grp_world);
			this.Controls.Add(this.grp_side);
			this.Controls.Add(this.group_platform);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "AltUIMungePanel";
			this.Size = new System.Drawing.Size(975, 345);
			this.group_platform.ResumeLayout(false);
			this.group_platform.PerformLayout();
			this.grp_side.ResumeLayout(false);
			this.grp_world.ResumeLayout(false);
			this.grp_options.ResumeLayout(false);
			this.grp_options.PerformLayout();
			this.group_copyDest.ResumeLayout(false);
			this.group_copyDest.PerformLayout();
			this.group_overrideCommand.ResumeLayout(false);
			this.group_overrideCommand.PerformLayout();
			this.group_mungeFolder.ResumeLayout(false);
			this.group_mungeFolder.PerformLayout();
			this.cxt_menu_mungeFolder.ResumeLayout(false);
			this.cxt_menu_copyDest.ResumeLayout(false);
			this.cxt_menu_overrideCommand.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox group_platform;
        private System.Windows.Forms.RadioButton btn_xbox;
        private System.Windows.Forms.RadioButton btn_ps2;
        private System.Windows.Forms.RadioButton btn_pc;
        private System.Windows.Forms.GroupBox grp_side;
        private System.Windows.Forms.ComboBox combo_side;
        private System.Windows.Forms.GroupBox grp_world;
        private System.Windows.Forms.ComboBox combo_world;
        private System.Windows.Forms.GroupBox grp_options;
        private System.Windows.Forms.CheckBox check_common;
        private System.Windows.Forms.CheckBox check_movies;
        private System.Windows.Forms.CheckBox check_load;
        private System.Windows.Forms.CheckBox check_sound;
        private System.Windows.Forms.CheckBox check_shell;
        private System.Windows.Forms.GroupBox group_copyDest;
        private System.Windows.Forms.Button btn_browseOutputFolder;
        private System.Windows.Forms.TextBox txt_copyDestFolder;
        private System.Windows.Forms.GroupBox group_overrideCommand;
        private System.Windows.Forms.CheckBox check_useOverrideCommand;
        private System.Windows.Forms.ComboBox combo_overrideCommand;
        private System.Windows.Forms.CheckBox check_missions;
        private System.Windows.Forms.ToolTip FormToolTip;
		private System.Windows.Forms.CheckBox check_addme;
		private System.Windows.Forms.Button btn_copy;
		private System.Windows.Forms.CheckBox check_copyIfNewer;
		private System.Windows.Forms.GroupBox group_mungeFolder;
		private System.Windows.Forms.TextBox txt_mungeFolder;
		private System.Windows.Forms.CheckBox check_autoCopy;
		private System.Windows.Forms.Button btn_generateFTPScript;
		private System.Windows.Forms.ContextMenuStrip cxt_menu_mungeFolder;
		private System.Windows.Forms.ToolStripMenuItem openInExplorerToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip cxt_menu_copyDest;
		private System.Windows.Forms.ToolStripMenuItem openCopyDestInExplorerToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip cxt_menu_overrideCommand;
		private System.Windows.Forms.ToolStripMenuItem openInEditorToolStripMenuItem;
	}
}

