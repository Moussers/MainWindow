using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

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
                AllocConsole();
                Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..");
                Console.WriteLine(Directory.GetCurrentDirectory());
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
                foreach (string i in files) 
                {
                    Console.WriteLine(i);
                }
                Process.Start("Clock.exe");
            }
            this.Close();
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }
}
