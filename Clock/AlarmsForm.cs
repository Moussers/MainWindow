using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Clock
{
    public partial class AlarmsForm : Form
    {
        private int NumberAlarms { get; set; }
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
            ReadSettingsAalrm();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AlarmDialog alarmDialog = new AlarmDialog();
            if (alarmDialog.ShowDialog() == DialogResult.OK)
            {
                listBoxAlarms.Items.Add(new Alarm(alarmDialog.Alarm));
            }
        }
        public void ReadSettingsAalrm()
        {
            listBoxAlarms.Items.Clear();
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            StreamReader reader = new StreamReader("Alarms.ini");
            if (int.TryParse(reader.ReadLine(), out int alarms))
            {
                NumberAlarms = alarms;
            }
            for (int i = 0; i < NumberAlarms; ++i) 
            {
                Alarm alarm = new Alarm();
                if (
                    int.TryParse(reader.ReadLine(), out int year) &&
                    int.TryParse(reader.ReadLine(), out int month) &&
                    int.TryParse(reader.ReadLine(), out int day) &&
                    int.TryParse(reader.ReadLine(), out int hours) &&
                    int.TryParse(reader.ReadLine(), out int minutes) &&
                    int.TryParse(reader.ReadLine(), out int seconds) && 
                    byte.TryParse(reader.ReadLine(), out byte days)
                    ) 
                {
                    if (year == 9999) 
                    {
                        year = DateTime.Now.Year;
                    }
                    alarm.Time = new TimeSpan(hours, minutes, seconds);
                    alarm.Date = new DateTime(year, month, day);
                    alarm.Days = new Week(days);
                    alarm.Filename = reader.ReadLine();
                    listBoxAlarms.Items.Add(alarm);
                
                }
            }
        }
        public void SaveSettingsAalarm() 
        {
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            StreamWriter writer = new StreamWriter("Alarms.ini");
            NumberAlarms = listBoxAlarms.Items.Count;
            writer.WriteLine(NumberAlarms);
            for (int i = 0; i < NumberAlarms; ++i)
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
                    writer.WriteLine((alarm.Days.GetMask()).ToString());
                    writer.WriteLine(alarm.Filename.ToString());
                }
            }
            writer.Close();
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
