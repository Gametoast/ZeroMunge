namespace ZeroMunge
{
	partial class EasyFilePicker
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node2");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node3");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node4");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node5");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node6");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node10");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node11");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node7", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node12");
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node8", new System.Windows.Forms.TreeNode[] {
            treeNode10});
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Node9");
			System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode9,
            treeNode11,
            treeNode12});
			this.tv_Files = new System.Windows.Forms.TreeView();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_Accept = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_AddProject = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tv_Files
			// 
			this.tv_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tv_Files.CheckBoxes = true;
			this.tv_Files.Location = new System.Drawing.Point(12, 12);
			this.tv_Files.Name = "tv_Files";
			treeNode1.Checked = true;
			treeNode1.Name = "Node2";
			treeNode1.Text = "Node2";
			treeNode2.Name = "Node3";
			treeNode2.Text = "Node3";
			treeNode3.Name = "Node4";
			treeNode3.Text = "Node4";
			treeNode4.Name = "Node5";
			treeNode4.Text = "Node5";
			treeNode5.Name = "Node6";
			treeNode5.Text = "Node6";
			treeNode6.Name = "Node1";
			treeNode6.Text = "Node1";
			treeNode7.Name = "Node10";
			treeNode7.Text = "Node10";
			treeNode8.Name = "Node11";
			treeNode8.Text = "Node11";
			treeNode9.Name = "Node7";
			treeNode9.Text = "Node7";
			treeNode10.Name = "Node12";
			treeNode10.Text = "Node12";
			treeNode11.Name = "Node8";
			treeNode11.Text = "Node8";
			treeNode12.Name = "Node9";
			treeNode12.Text = "Node9";
			treeNode13.Name = "Node0";
			treeNode13.Text = "Node0";
			this.tv_Files.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13});
			this.tv_Files.Size = new System.Drawing.Size(840, 661);
			this.tv_Files.TabIndex = 0;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.btn_Accept);
			this.flowLayoutPanel1.Controls.Add(this.btn_Cancel);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(858, 12);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(136, 661);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// btn_Accept
			// 
			this.btn_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Accept.Location = new System.Drawing.Point(0, 4);
			this.btn_Accept.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
			this.btn_Accept.Name = "btn_Accept";
			this.btn_Accept.Size = new System.Drawing.Size(136, 28);
			this.btn_Accept.TabIndex = 19;
			this.btn_Accept.Text = "OK";
			this.btn_Accept.UseVisualStyleBackColor = true;
			this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(0, 40);
			this.btn_Cancel.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(136, 28);
			this.btn_Cancel.TabIndex = 20;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_AddProject
			// 
			this.btn_AddProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_AddProject.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_AddProject.Location = new System.Drawing.Point(9, 680);
			this.btn_AddProject.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
			this.btn_AddProject.Name = "btn_AddProject";
			this.btn_AddProject.Size = new System.Drawing.Size(136, 28);
			this.btn_AddProject.TabIndex = 21;
			this.btn_AddProject.Text = "Add Project...";
			this.btn_AddProject.UseVisualStyleBackColor = true;
			this.btn_AddProject.Click += new System.EventHandler(this.btn_AddProject_Click);
			// 
			// EasyFilePicker
			// 
			this.AcceptButton = this.btn_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Controls.Add(this.btn_AddProject);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.tv_Files);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "EasyFilePicker";
			this.ShowIcon = false;
			this.Text = "Easy File Picker";
			this.Load += new System.EventHandler(this.EasyFilePicker_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView tv_Files;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		public System.Windows.Forms.Button btn_Accept;
		public System.Windows.Forms.Button btn_Cancel;
		public System.Windows.Forms.Button btn_AddProject;
	}
}