namespace SWBF2_AutomationTool
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
            this.tbox_TestTextBox = new System.Windows.Forms.TextBox();
            this.lbl_TestLabel = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbox_TestTextBox
            // 
            this.tbox_TestTextBox.Location = new System.Drawing.Point(93, 15);
            this.tbox_TestTextBox.Name = "tbox_TestTextBox";
            this.tbox_TestTextBox.Size = new System.Drawing.Size(279, 20);
            this.tbox_TestTextBox.TabIndex = 1;
            // 
            // lbl_TestLabel
            // 
            this.lbl_TestLabel.AutoSize = true;
            this.lbl_TestLabel.Location = new System.Drawing.Point(90, 55);
            this.lbl_TestLabel.Name = "lbl_TestLabel";
            this.lbl_TestLabel.Size = new System.Drawing.Size(0, 13);
            this.lbl_TestLabel.TabIndex = 2;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(13, 13);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 3;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // AutomationTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl_TestLabel);
            this.Controls.Add(this.tbox_TestTextBox);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "AutomationTool";
            this.Text = "Automation Tool";
            this.Load += new System.EventHandler(this.AutomationTool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbox_TestTextBox;
        private System.Windows.Forms.Label lbl_TestLabel;
        private System.Windows.Forms.Button btn_Submit;
    }
}

