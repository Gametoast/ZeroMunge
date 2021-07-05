namespace ZeroMunge
{
	partial class FTPScriptForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTPScriptForm));
			this.chk_checkAll = new System.Windows.Forms.CheckBox();
			this.txt_remoteFolder = new System.Windows.Forms.TextBox();
			this.txt_sourceFolder = new System.Windows.Forms.TextBox();
			this.cxt_sourceCombo = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menu_openSourceInExplorer = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_browseLocal = new System.Windows.Forms.Button();
			this.tree_fileTree = new System.Windows.Forms.TreeView();
			this.group_checkUncheck = new System.Windows.Forms.GroupBox();
			this.btn_generateCopyScript = new System.Windows.Forms.Button();
			this.menu_mainStrip = new System.Windows.Forms.MenuStrip();
			this.menu_ftpClient = new System.Windows.Forms.ToolStripMenuItem();
			this.winSCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_about = new System.Windows.Forms.ToolStripMenuItem();
			this.group_dest = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_password = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txt_userName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_ipAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.group_sourceFolder = new System.Windows.Forms.GroupBox();
			this.btn_close = new System.Windows.Forms.Button();
			this.cxt_sourceCombo.SuspendLayout();
			this.group_checkUncheck.SuspendLayout();
			this.menu_mainStrip.SuspendLayout();
			this.group_dest.SuspendLayout();
			this.group_sourceFolder.SuspendLayout();
			this.SuspendLayout();
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
			// txt_remoteFolder
			// 
			this.txt_remoteFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_remoteFolder.Location = new System.Drawing.Point(14, 177);
			this.txt_remoteFolder.Name = "txt_remoteFolder";
			this.txt_remoteFolder.Size = new System.Drawing.Size(574, 26);
			this.txt_remoteFolder.TabIndex = 16;
			this.txt_remoteFolder.Text = "/F/Games/StarWarsBattlefront2/Data/_LVL_XBOX/addon/500";
			// 
			// txt_sourceFolder
			// 
			this.txt_sourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_sourceFolder.ContextMenuStrip = this.cxt_sourceCombo;
			this.txt_sourceFolder.Location = new System.Drawing.Point(7, 23);
			this.txt_sourceFolder.Name = "txt_sourceFolder";
			this.txt_sourceFolder.Size = new System.Drawing.Size(477, 26);
			this.txt_sourceFolder.TabIndex = 14;
			this.txt_sourceFolder.TextChanged += new System.EventHandler(this.txt_sourceFolder_TextChanged);
			// 
			// cxt_sourceCombo
			// 
			this.cxt_sourceCombo.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.cxt_sourceCombo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_openSourceInExplorer});
			this.cxt_sourceCombo.Name = "cxt_sourceCombo";
			this.cxt_sourceCombo.Size = new System.Drawing.Size(217, 36);
			// 
			// menu_openSourceInExplorer
			// 
			this.menu_openSourceInExplorer.Name = "menu_openSourceInExplorer";
			this.menu_openSourceInExplorer.Size = new System.Drawing.Size(216, 32);
			this.menu_openSourceInExplorer.Text = "Open in Explorer";
			this.menu_openSourceInExplorer.Click += new System.EventHandler(this.openLocationInExplorer);
			// 
			// btn_browseLocal
			// 
			this.btn_browseLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_browseLocal.Location = new System.Drawing.Point(490, 18);
			this.btn_browseLocal.Name = "btn_browseLocal";
			this.btn_browseLocal.Size = new System.Drawing.Size(88, 36);
			this.btn_browseLocal.TabIndex = 12;
			this.btn_browseLocal.Text = "&Browse";
			this.btn_browseLocal.UseVisualStyleBackColor = true;
			this.btn_browseLocal.Click += new System.EventHandler(this.btn_browse_Click);
			// 
			// tree_fileTree
			// 
			this.tree_fileTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tree_fileTree.CheckBoxes = true;
			this.tree_fileTree.Location = new System.Drawing.Point(6, 59);
			this.tree_fileTree.Name = "tree_fileTree";
			this.tree_fileTree.Size = new System.Drawing.Size(304, 256);
			this.tree_fileTree.TabIndex = 21;
			this.tree_fileTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_fileTree_AfterCheck);
			// 
			// group_checkUncheck
			// 
			this.group_checkUncheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.group_checkUncheck.Controls.Add(this.chk_checkAll);
			this.group_checkUncheck.Controls.Add(this.tree_fileTree);
			this.group_checkUncheck.Location = new System.Drawing.Point(22, 111);
			this.group_checkUncheck.Name = "group_checkUncheck";
			this.group_checkUncheck.Size = new System.Drawing.Size(316, 321);
			this.group_checkUncheck.TabIndex = 22;
			this.group_checkUncheck.TabStop = false;
			this.group_checkUncheck.Text = "Files to copy";
			// 
			// btn_generateCopyScript
			// 
			this.btn_generateCopyScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_generateCopyScript.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.btn_generateCopyScript.Location = new System.Drawing.Point(457, 121);
			this.btn_generateCopyScript.Name = "btn_generateCopyScript";
			this.btn_generateCopyScript.Size = new System.Drawing.Size(149, 87);
			this.btn_generateCopyScript.TabIndex = 23;
			this.btn_generateCopyScript.Text = "Generate FTP  script";
			this.btn_generateCopyScript.UseVisualStyleBackColor = false;
			this.btn_generateCopyScript.Click += new System.EventHandler(this.btn_generateCopyScript_Click);
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
			this.menu_mainStrip.Size = new System.Drawing.Size(623, 33);
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
			// group_dest
			// 
			this.group_dest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.group_dest.Controls.Add(this.txt_remoteFolder);
			this.group_dest.Controls.Add(this.label2);
			this.group_dest.Controls.Add(this.txt_password);
			this.group_dest.Controls.Add(this.label5);
			this.group_dest.Controls.Add(this.txt_userName);
			this.group_dest.Controls.Add(this.label4);
			this.group_dest.Controls.Add(this.txt_ipAddress);
			this.group_dest.Controls.Add(this.label1);
			this.group_dest.Location = new System.Drawing.Point(12, 437);
			this.group_dest.Name = "group_dest";
			this.group_dest.Size = new System.Drawing.Size(594, 215);
			this.group_dest.TabIndex = 30;
			this.group_dest.TabStop = false;
			this.group_dest.Text = "Dest";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 149);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(177, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Copy To Remote Folder";
			// 
			// txt_password
			// 
			this.txt_password.Location = new System.Drawing.Point(211, 106);
			this.txt_password.Name = "txt_password";
			this.txt_password.Size = new System.Drawing.Size(166, 26);
			this.txt_password.TabIndex = 5;
			this.txt_password.Text = "xbox";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(207, 83);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 20);
			this.label5.TabIndex = 4;
			this.label5.Text = "Password";
			// 
			// txt_userName
			// 
			this.txt_userName.Location = new System.Drawing.Point(14, 106);
			this.txt_userName.Name = "txt_userName";
			this.txt_userName.Size = new System.Drawing.Size(166, 26);
			this.txt_userName.TabIndex = 3;
			this.txt_userName.Text = "xbox";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(87, 20);
			this.label4.TabIndex = 2;
			this.label4.Text = "User name";
			// 
			// txt_ipAddress
			// 
			this.txt_ipAddress.Location = new System.Drawing.Point(14, 50);
			this.txt_ipAddress.Name = "txt_ipAddress";
			this.txt_ipAddress.Size = new System.Drawing.Size(363, 26);
			this.txt_ipAddress.TabIndex = 1;
			this.txt_ipAddress.Text = "192.168.1.158";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP Address";
			// 
			// group_sourceFolder
			// 
			this.group_sourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.group_sourceFolder.Controls.Add(this.txt_sourceFolder);
			this.group_sourceFolder.Controls.Add(this.btn_browseLocal);
			this.group_sourceFolder.Location = new System.Drawing.Point(22, 45);
			this.group_sourceFolder.Name = "group_sourceFolder";
			this.group_sourceFolder.Size = new System.Drawing.Size(584, 60);
			this.group_sourceFolder.TabIndex = 31;
			this.group_sourceFolder.TabStop = false;
			this.group_sourceFolder.Text = "Source Folder";
			// 
			// btn_close
			// 
			this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_close.Location = new System.Drawing.Point(480, 659);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new System.Drawing.Size(126, 36);
			this.btn_close.TabIndex = 15;
			this.btn_close.Text = "Close";
			this.btn_close.UseVisualStyleBackColor = true;
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// FTPScriptForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(623, 701);
			this.Controls.Add(this.btn_close);
			this.Controls.Add(this.group_sourceFolder);
			this.Controls.Add(this.group_dest);
			this.Controls.Add(this.btn_generateCopyScript);
			this.Controls.Add(this.group_checkUncheck);
			this.Controls.Add(this.menu_mainStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menu_mainStrip;
			this.MinimumSize = new System.Drawing.Size(645, 757);
			this.Name = "FTPScriptForm";
			this.Text = "Generate FTP Script";
			this.cxt_sourceCombo.ResumeLayout(false);
			this.group_checkUncheck.ResumeLayout(false);
			this.group_checkUncheck.PerformLayout();
			this.menu_mainStrip.ResumeLayout(false);
			this.menu_mainStrip.PerformLayout();
			this.group_dest.ResumeLayout(false);
			this.group_dest.PerformLayout();
			this.group_sourceFolder.ResumeLayout(false);
			this.group_sourceFolder.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox chk_checkAll;
		private System.Windows.Forms.TextBox txt_remoteFolder;
		private System.Windows.Forms.TextBox txt_sourceFolder;
		private System.Windows.Forms.Button btn_browseLocal;
		private System.Windows.Forms.TreeView tree_fileTree;
		private System.Windows.Forms.GroupBox group_checkUncheck;
		private System.Windows.Forms.Button btn_generateCopyScript;
		private System.Windows.Forms.MenuStrip menu_mainStrip;
		private System.Windows.Forms.ToolStripMenuItem menu_ftpClient;
		private System.Windows.Forms.ToolStripMenuItem winSCPToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menu_about;
		private System.Windows.Forms.ContextMenuStrip cxt_sourceCombo;
		private System.Windows.Forms.ToolStripMenuItem menu_openSourceInExplorer;
		private System.Windows.Forms.GroupBox group_dest;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_password;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txt_userName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_ipAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox group_sourceFolder;
		private System.Windows.Forms.Button btn_close;
	}
}
