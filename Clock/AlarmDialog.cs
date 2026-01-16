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
        public Alarm Alarm { get; private set; }
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
            Alarm = new Alarm();
        }
        public AlarmDialog(Alarm alarm) : this()
        {
            Alarm = alarm;
            Extract();
        }
        void Extract()
        {
            if (Alarm.Date != DateTime.MaxValue) 
            {
                dtpDate.Value = Alarm.Date;
                checkBoxUseDate.Checked = true;
            }
            dtpDate.Value = Alarm.Date; //Ошибка Value of '12/31/9999 11:59:59 PM' is not valid for 'Value'. 'Value' should be between 'MinDate' and 'MaxDate'.
            dtpTime.Value = Alarm.Time;
            Alarm.Days.Extract(clbWeekDays);
            labelFilename.Text = Alarm.Filename;
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

        private void clbWeekDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbWeekDays.CheckedItems.Count; i++)
            {
                Console.Write($"{clbWeekDays.CheckedItems[i]}\t");
            }
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

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Alarm.Date = checkBoxUseDate.Checked ? dtpDate.Value : DateTime.MaxValue;
            Alarm.Time = dtpDate.Value;
            Alarm.Days = new Week(GetDyasMask());
            Alarm.Filename = labelFilename.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
