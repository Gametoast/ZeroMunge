namespace AutomationTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cont_Prefs = new System.Windows.Forms.FlowLayoutPanel();
            this.chk_EnableTrayIcon = new System.Windows.Forms.CheckBox();
            this.chk_EnableNotificationPopups = new System.Windows.Forms.CheckBox();
            this.chk_EnableNotificationSounds = new System.Windows.Forms.CheckBox();
            this.cont_Prefs.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(497, 326);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Accept
            // 
            this.btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Accept.Location = new System.Drawing.Point(416, 326);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(75, 23);
            this.btn_Accept.TabIndex = 2;
            this.btn_Accept.Text = "OK";
            this.btn_Accept.UseVisualStyleBackColor = true;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 308);
            this.treeView1.TabIndex = 3;
            // 
            // cont_Prefs
            // 
            this.cont_Prefs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cont_Prefs.Controls.Add(this.chk_EnableTrayIcon);
            this.cont_Prefs.Controls.Add(this.chk_EnableNotificationPopups);
            this.cont_Prefs.Controls.Add(this.chk_EnableNotificationSounds);
            this.cont_Prefs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cont_Prefs.Location = new System.Drawing.Point(139, 12);
            this.cont_Prefs.Name = "cont_Prefs";
            this.cont_Prefs.Size = new System.Drawing.Size(433, 308);
            this.cont_Prefs.TabIndex = 4;
            // 
            // chk_EnableTrayIcon
            // 
            this.chk_EnableTrayIcon.AutoSize = true;
            this.chk_EnableTrayIcon.Checked = true;
            this.chk_EnableTrayIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_EnableTrayIcon.Location = new System.Drawing.Point(3, 3);
            this.chk_EnableTrayIcon.Name = "chk_EnableTrayIcon";
            this.chk_EnableTrayIcon.Size = new System.Drawing.Size(101, 17);
            this.chk_EnableTrayIcon.TabIndex = 0;
            this.chk_EnableTrayIcon.Text = "Show Tray Icon";
            this.chk_EnableTrayIcon.UseVisualStyleBackColor = true;
            this.chk_EnableTrayIcon.CheckedChanged += new System.EventHandler(this.chk_EnableTrayIcon_CheckedChanged);
            // 
            // chk_EnableNotificationPopups
            // 
            this.chk_EnableNotificationPopups.AutoSize = true;
            this.chk_EnableNotificationPopups.Checked = true;
            this.chk_EnableNotificationPopups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_EnableNotificationPopups.Location = new System.Drawing.Point(3, 26);
            this.chk_EnableNotificationPopups.Name = "chk_EnableNotificationPopups";
            this.chk_EnableNotificationPopups.Size = new System.Drawing.Size(148, 17);
            this.chk_EnableNotificationPopups.TabIndex = 1;
            this.chk_EnableNotificationPopups.Text = "Show Notification Popups";
            this.chk_EnableNotificationPopups.UseVisualStyleBackColor = true;
            this.chk_EnableNotificationPopups.CheckedChanged += new System.EventHandler(this.chk_EnableNotificationPopups_CheckedChanged);
            // 
            // chk_EnableNotificationSounds
            // 
            this.chk_EnableNotificationSounds.AutoSize = true;
            this.chk_EnableNotificationSounds.Checked = true;
            this.chk_EnableNotificationSounds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_EnableNotificationSounds.Location = new System.Drawing.Point(3, 49);
            this.chk_EnableNotificationSounds.Name = "chk_EnableNotificationSounds";
            this.chk_EnableNotificationSounds.Size = new System.Drawing.Size(141, 17);
            this.chk_EnableNotificationSounds.TabIndex = 2;
            this.chk_EnableNotificationSounds.Text = "Play Notification Sounds";
            this.chk_EnableNotificationSounds.UseVisualStyleBackColor = true;
            this.chk_EnableNotificationSounds.CheckedChanged += new System.EventHandler(this.chk_EnableNotificationSounds_CheckedChanged);
            // 
            // Preferences
            // 
            this.AcceptButton = this.btn_Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.cont_Prefs);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btn_Accept);
            this.Controls.Add(this.btn_Cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preferences";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Preferences";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.cont_Prefs.ResumeLayout(false);
            this.cont_Prefs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FlowLayoutPanel cont_Prefs;
        private System.Windows.Forms.CheckBox chk_EnableTrayIcon;
        private System.Windows.Forms.CheckBox chk_EnableNotificationPopups;
        private System.Windows.Forms.CheckBox chk_EnableNotificationSounds;
    }
}