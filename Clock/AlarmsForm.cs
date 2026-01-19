using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class AlarmsForm : Form
    {
        //AlarmDialog alarm;
        public ListBox List { get => listBoxAlarms; }
        public AlarmsForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point
                (
                    Screen.PrimaryScreen.Bounds.Width - this.Width - 25,
                    Screen.PrimaryScreen.Bounds.Height - this.Height - 560

                );
            //alarm = new AlarmDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AlarmDialog alarmDialog = new AlarmDialog();
            if (alarmDialog.ShowDialog() == DialogResult.OK)
            {
                listBoxAlarms.Items.Add(new Alarm(alarmDialog.Alarm));
            }
        }
        public void SaveAlarmList() 
        {
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            StreamWriter writer = new StreamWriter("Alarms.ini");
            for (int i = 0; i < listBoxAlarms.Items.Count; ++i)
            {
                Alarm alarm = listBoxAlarms.Items[i] as Alarm;
                if (alarm != null)
                {
                    writer.WriteLine(alarm.Date.Year.ToString());
                    writer.WriteLine(alarm.Date.Month.ToString());
                    writer.WriteLine(alarm.Date.Day.ToString());
                    writer.WriteLine(alarm.Date.Hour.ToString());
                    writer.WriteLine(alarm.Date.Minute.ToString());
                    writer.WriteLine(alarm.Date.Second.ToString());
                    writer.WriteLine(alarm.Days.ToString());
                    writer.WriteLine(alarm.Filename.ToString());
                }
            }
        }
        private void listBoxAlarms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxAlarms.Items.Count > 0 && listBoxAlarms.SelectedItems != null)
            {
                AlarmDialog alarm = new AlarmDialog(listBoxAlarms.SelectedItem as Alarm);
                alarm.ShowDialog();
                listBoxAlarms.Items[listBoxAlarms.SelectedIndex] = new Alarm(alarm.Alarm);
            }
            else
            {
                buttonAdd_Click(sender, e);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxAlarms.SelectedIndex;
            listBoxAlarms.Items.RemoveAt(index);
        }
    }
}
