using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;

namespace Autorunner
{
    public partial class Autorunner : Form
    {
        public Autorunner()
        {
            InitializeComponent();
        }

        private void buttonComplete_Click(object sender, EventArgs e)
        {
            if (checkBoxLaunch.Checked)
            {
                Process.Start("Clock.exe");
            }
            this.Close();
        }
    }
}
