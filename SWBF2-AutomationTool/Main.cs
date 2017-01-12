using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWBF2_AutomationTool
{
    public partial class AutomationTool : Form
    {
        public AutomationTool()
        {
            InitializeComponent();
        }

        private void AutomationTool_Load(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            lbl_TestLabel.Text = tbox_TestTextBox.Text;
        }
    }
}
