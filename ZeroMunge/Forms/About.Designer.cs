namespace ZeroMunge
{
    partial class About
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
			this.btn_Accept = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.lbl_BuildInfo = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pnl_License = new System.Windows.Forms.Panel();
			this.text_License = new System.Windows.Forms.RichTextBox();
			this.lbl_LicensePre = new System.Windows.Forms.Label();
			this.flow_License = new System.Windows.Forms.FlowLayoutPanel();
			this.img_Logo = new System.Windows.Forms.PictureBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.link_Updates = new System.Windows.Forms.LinkLabel();
			this.link_Contact = new System.Windows.Forms.LinkLabel();
			this.link_FrayedWires = new System.Windows.Forms.LinkLabel();
			this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
			this.flowLayoutPanel1.SuspendLayout();
			this.pnl_License.SuspendLayout();
			this.flow_License.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.img_Logo)).BeginInit();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Accept
			// 
			this.btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Accept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Accept.Location = new System.Drawing.Point(377, 346);
			this.btn_Accept.Name = "btn_Accept";
			this.btn_Accept.Size = new System.Drawing.Size(75, 23);
			this.btn_Accept.TabIndex = 3;
			this.btn_Accept.Text = "OK";
			this.btn_Accept.UseVisualStyleBackColor = true;
			this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.lbl_BuildInfo);
			this.flowLayoutPanel1.Controls.Add(this.label3);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 131);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(314, 70);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.label1.Size = new System.Drawing.Size(65, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Zero Munge";
			// 
			// lbl_BuildInfo
			// 
			this.lbl_BuildInfo.AutoSize = true;
			this.lbl_BuildInfo.Location = new System.Drawing.Point(3, 19);
			this.lbl_BuildInfo.Name = "lbl_BuildInfo";
			this.lbl_BuildInfo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.lbl_BuildInfo.Size = new System.Drawing.Size(70, 19);
			this.lbl_BuildInfo.TabIndex = 1;
			this.lbl_BuildInfo.Text = "BUILD_INFO";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 38);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.label3.Size = new System.Drawing.Size(137, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "Developed by Aaron Gilbert";
			// 
			// pnl_License
			// 
			this.pnl_License.Controls.Add(this.text_License);
			this.pnl_License.Location = new System.Drawing.Point(3, 16);
			this.pnl_License.Name = "pnl_License";
			this.pnl_License.Size = new System.Drawing.Size(437, 117);
			this.pnl_License.TabIndex = 3;
			// 
			// text_License
			// 
			this.text_License.Dock = System.Windows.Forms.DockStyle.Fill;
			this.text_License.Location = new System.Drawing.Point(0, 0);
			this.text_License.Name = "text_License";
			this.text_License.ReadOnly = true;
			this.text_License.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.text_License.Size = new System.Drawing.Size(437, 117);
			this.text_License.TabIndex = 0;
			this.text_License.TabStop = false;
			this.text_License.Text = "";
			this.text_License.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.text_License_LinkClicked);
			// 
			// lbl_LicensePre
			// 
			this.lbl_LicensePre.AutoSize = true;
			this.lbl_LicensePre.Location = new System.Drawing.Point(3, 0);
			this.lbl_LicensePre.Name = "lbl_LicensePre";
			this.lbl_LicensePre.Size = new System.Drawing.Size(47, 13);
			this.lbl_LicensePre.TabIndex = 4;
			this.lbl_LicensePre.Text = "License:";
			// 
			// flow_License
			// 
			this.flow_License.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flow_License.Controls.Add(this.lbl_LicensePre);
			this.flow_License.Controls.Add(this.pnl_License);
			this.flow_License.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flow_License.Location = new System.Drawing.Point(12, 207);
			this.flow_License.Name = "flow_License";
			this.flow_License.Size = new System.Drawing.Size(440, 133);
			this.flow_License.TabIndex = 4;
			this.flow_License.WrapContents = false;
			// 
			// img_Logo
			// 
			this.img_Logo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.img_Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.img_Logo.Image = ((System.Drawing.Image)(resources.GetObject("img_Logo.Image")));
			this.img_Logo.Location = new System.Drawing.Point(12, 12);
			this.img_Logo.Name = "img_Logo";
			this.img_Logo.Size = new System.Drawing.Size(440, 113);
			this.img_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.img_Logo.TabIndex = 1;
			this.img_Logo.TabStop = false;
			this.img_Logo.WaitOnLoad = true;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel2.Controls.Add(this.link_Updates);
			this.flowLayoutPanel2.Controls.Add(this.link_Contact);
			this.flowLayoutPanel2.Controls.Add(this.link_FrayedWires);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(332, 131);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.flowLayoutPanel2.Size = new System.Drawing.Size(120, 70);
			this.flowLayoutPanel2.TabIndex = 5;
			// 
			// link_Updates
			// 
			this.link_Updates.AutoSize = true;
			this.link_Updates.Location = new System.Drawing.Point(23, 0);
			this.link_Updates.Name = "link_Updates";
			this.link_Updates.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.link_Updates.Size = new System.Drawing.Size(94, 19);
			this.link_Updates.TabIndex = 0;
			this.link_Updates.TabStop = true;
			this.link_Updates.Text = "Check for updates";
			this.FormTooltips.SetToolTip(this.link_Updates, "Open a link to the application\'s GitHub page where you can check for application " +
        "updates and more.");
			this.link_Updates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Updates_LinkClicked);
			// 
			// link_Contact
			// 
			this.link_Contact.AutoSize = true;
			this.link_Contact.Location = new System.Drawing.Point(73, 19);
			this.link_Contact.Name = "link_Contact";
			this.link_Contact.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.link_Contact.Size = new System.Drawing.Size(44, 19);
			this.link_Contact.TabIndex = 1;
			this.link_Contact.TabStop = true;
			this.link_Contact.Text = "Contact";
			this.FormTooltips.SetToolTip(this.link_Contact, "Send me an e-mail message.");
			this.link_Contact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Contact_LinkClicked);
			// 
			// link_FrayedWires
			// 
			this.link_FrayedWires.AutoSize = true;
			this.link_FrayedWires.Location = new System.Drawing.Point(10, 38);
			this.link_FrayedWires.Name = "link_FrayedWires";
			this.link_FrayedWires.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.link_FrayedWires.Size = new System.Drawing.Size(107, 19);
			this.link_FrayedWires.TabIndex = 2;
			this.link_FrayedWires.TabStop = true;
			this.link_FrayedWires.Text = "Frayed Wires Studios";
			this.FormTooltips.SetToolTip(this.link_FrayedWires, "Open a link to the official web site for Frayed Wires Studios.");
			this.link_FrayedWires.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_FrayedWires_LinkClicked);
			// 
			// About
			// 
			this.AcceptButton = this.btn_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Accept;
			this.ClientSize = new System.Drawing.Size(464, 381);
			this.Controls.Add(this.flowLayoutPanel2);
			this.Controls.Add(this.flow_License);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.img_Logo);
			this.Controls.Add(this.btn_Accept);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(480, 400);
			this.Name = "About";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About Zero Munge";
			this.Load += new System.EventHandler(this.About_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.pnl_License.ResumeLayout(false);
			this.flow_License.ResumeLayout(false);
			this.flow_License.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.img_Logo)).EndInit();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.PictureBox img_Logo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_BuildInfo;
        private System.Windows.Forms.Panel pnl_License;
        private System.Windows.Forms.RichTextBox text_License;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_LicensePre;
        private System.Windows.Forms.FlowLayoutPanel flow_License;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.LinkLabel link_Updates;
        private System.Windows.Forms.LinkLabel link_Contact;
        private System.Windows.Forms.LinkLabel link_FrayedWires;
        private System.Windows.Forms.ToolTip FormTooltips;
    }
}