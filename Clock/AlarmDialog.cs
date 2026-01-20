using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            for (int i = 0; i < 7; ++i)
            {
                clbWeekDays.SetItemChecked(i, true);
            }
        }
        private void SetCurrentAlarm(int alarmIndex)
        {
            for (int i = 0; i < 7; ++i)
            {
                if (i == alarmIndex)
                {
                    clbWeekDays.SetItemCheckState(alarmIndex, CheckState.Checked);
                }
            }
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
            dtpTime.Value = DateTime.Now.Date + Alarm.Time;
            if (checkBoxUseDate.Checked) Alarm.Days = new Week(0);
            else Alarm.Days.Extract(clbWeekDays);
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
            if (clbWeekDays.CheckedIndices.Count == 0)
            {
                DayOfWeek currentDay = DateTime.Now.DayOfWeek;
                SetCurrentAlarm((int)currentDay);
            }
            //else this.buttonOK.DialogResult = DialogResult.OK;
            Alarm.Date = checkBoxUseDate.Checked ? dtpDate.Value : DateTime.MaxValue;
            Alarm.Time = dtpTime.Value.TimeOfDay;
            Alarm.Days = new Week(GetDyasMask());
            //Alarm.Days = new Week(checkBoxUseDate.Checked ? (byte)0 : GetDyasMask());
            Alarm.Filename = labelFilename.Text;
            
        }
        //public void DropDialogResult()
        //{
        //    this.buttonOK.DialogResult = DialogResult.OK;
        //}
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
