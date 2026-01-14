using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class AlarmDialog : Form
    {
        OpenFileDialog fileDialog;
        public AlarmDialog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point
                (
                    Screen.PrimaryScreen.Bounds.Width - this.Width - 230,
                    Screen.PrimaryScreen.Bounds.Height - this.Height - 610
                );
            dtpDate.Enabled = false;
            fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All sound files (*.mp3;*.flac;*.flacc;*.ape;*.wav;*.ogg;*.wma)" +
                "|*.mp3;*.flac;*.flacc;*.ape;*.wav;*.ogg;*.wma|" +
                "mp3 files (*.mp3)|*.mp3|Flac files (.flac)|" +
                "*.flac;*.flacc|APE files (.ape)|*.ape|WAV files (.wav)|" +
                "*.wav|OGG files (.ogg)|*.ogg|WMA files (.wma)|*.wma";
        }

        private void checkBoxUseDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = (sender as CheckBox).Checked;
            clbWeekDays.Enabled = !dtpDate.Enabled;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                labelFilename.Text = fileDialog.FileName;
            }
        }

        private void clbWeekDays_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void clbWeekDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbWeekDays.CheckedItems.Count; i++)
                Console.Write($"{clbWeekDays.CheckedItems[i]}\t");
            Console.WriteLine();
            byte days = 0;
            for (int i = 0; i < clbWeekDays.CheckedItems.Count; i++)
            {
                days |= (byte)(1 << clbWeekDays.CheckedIndices[i]);
                Console.Write($"{clbWeekDays.CheckedIndices[i]}\t");
            }
            Console.WriteLine($"Days mask: {days}");
            Console.WriteLine("\n-----------------------------------\n");
        }
        byte GetDyasMask() 
        {
            byte days = 0;
            for (int i = 0; i < clbWeekDays.CheckedItems.Count; i++)
                days |= (byte)(1 << clbWeekDays.CheckedIndices[i]);
            return days;
        }
    }
}
