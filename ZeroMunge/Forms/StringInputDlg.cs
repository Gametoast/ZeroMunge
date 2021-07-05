using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;

namespace ZeroMunge
{
	/// <summary>
	/// Summary description for StringInputDlg.
	/// </summary>
	public class StringInputDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button mOkButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mUserInput;
		private string result = "";
		private System.Windows.Forms.Button mCancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StringInputDlg(string title, string message, string initialText)
		{
			InitializeComponent();
			this.Text= title;
			this.label1.Text = message;
			this.mUserInput.Text= initialText;
			this.mUserInput.SelectAll();
		}
		/// <summary>
		/// Returns null string on cancel.
		/// </summary>
		public static string GetString(string title, string message)
		{
			string ret = null;
			StringInputDlg sid = new StringInputDlg(title, message,"");
			if( sid.ShowDialog() == DialogResult.OK)
				ret = sid.getResult();
			sid.Dispose();
			return ret;
		}
		/// <summary>
		/// Returns null string on cancel.
		/// </summary>
		public static string GetString(string title, string message, string initialText)
		{
			string ret = null;
			StringInputDlg sid = new StringInputDlg(title, message, initialText);
			if (sid.ShowDialog() == DialogResult.OK)
				ret = sid.getResult();
			sid.Dispose();
			return ret;
		}

		public string getResult()
		{
			return result;
		}

        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringInputDlg));
			this.mOkButton = new System.Windows.Forms.Button();
			this.mCancelButton = new System.Windows.Forms.Button();
			this.mUserInput = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mOkButton
			// 
			this.mOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.mOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.mOkButton.Location = new System.Drawing.Point(220, 216);
			this.mOkButton.Name = "mOkButton";
			this.mOkButton.Size = new System.Drawing.Size(67, 32);
			this.mOkButton.TabIndex = 1;
			this.mOkButton.Text = "OK";
			this.mOkButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// mCancelButton
			// 
			this.mCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.mCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.mCancelButton.Location = new System.Drawing.Point(308, 216);
			this.mCancelButton.Name = "mCancelButton";
			this.mCancelButton.Size = new System.Drawing.Size(86, 32);
			this.mCancelButton.TabIndex = 2;
			this.mCancelButton.Text = "Cancel";
			this.mCancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// mUserInput
			// 
			this.mUserInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mUserInput.Location = new System.Drawing.Point(56, 153);
			this.mUserInput.Name = "mUserInput";
			this.mUserInput.Size = new System.Drawing.Size(338, 26);
			this.mUserInput.TabIndex = 0;
			this.mUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userInput_KeyDown);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(56, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(338, 126);
			this.label1.TabIndex = 3;
			// 
			// StringInputDlg
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.mCancelButton;
			this.ClientSize = new System.Drawing.Size(436, 260);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mUserInput);
			this.Controls.Add(this.mCancelButton);
			this.Controls.Add(this.mOkButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(398, 183);
			this.Name = "StringInputDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "StringInputDlg";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion


		private void userInput_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) 
		{
			if(e.KeyCode == Keys.Enter)
			{
				//result = userInput.Text;
				okButton_Click(sender, new System.EventArgs());
			}
		}

		private void okButton_Click(object sender, System.EventArgs e) 
		{
			result = mUserInput.Text;
			this.DialogResult = DialogResult.OK;
		}

		private void cancelButton_Click(object sender, System.EventArgs e) 
		{
			result = "";
			this.Close();
		}
	}
}
