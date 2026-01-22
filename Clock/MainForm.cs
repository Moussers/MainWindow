using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using AxWMPLib;

namespace Clock
{
    public partial class MainForm : Form
    {
        FontDialog fontDialog;
        ColorDialog foregroundColorDialog;
        ColorDialog backgroundColorDialog;
        AlarmsForm alarms;
        Alarm alarm;
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point
                (
                Screen.PrimaryScreen.Bounds.Width - this.Width - 25,
                50
                );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            SetVisibility(false);
            fontDialog = new FontDialog();
            foregroundColorDialog = new ColorDialog();
            backgroundColorDialog = new ColorDialog();
            alarms = new AlarmsForm();
            alarm = null;
            LoadSettings();
        }
        void SetVisibility(bool visible) 
        {
            cbShowDate.Visible = visible;
            cbShowWeekday.Visible = visible;
            btnHideControls.Visible = visible;
            this.ShowInTaskbar = visible;
            this.FormBorderStyle = visible ? FormBorderStyle.FixedSingle: FormBorderStyle.None;
            this.TransparencyKey = visible ? Color.Empty: this.BackColor;
        }
        void SaveSettings() 
        {
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            StreamWriter writer = new StreamWriter("Settings.ini");
            writer.WriteLine(this.Location.X);
            writer.WriteLine(this.Location.Y);
            writer.WriteLine(tsmiTopmost.Checked);
            writer.WriteLine(tsmiShowControls.Checked);
            writer.WriteLine(tsmiShowConsole.Checked);
            writer.WriteLine(tsmiShowDate.Checked);
            writer.WriteLine(tsmiShowWeekday.Checked);
            writer.WriteLine(tsmiAutoStart.Checked);
            writer.WriteLine(labelTime.BackColor.ToArgb());
            writer.WriteLine(labelTime.ForeColor.ToArgb());
            writer.WriteLine(fontDialog.FileName);
            writer.WriteLine(labelTime.Font.Size);
            writer.Close();
           //System.Diagnostics.Process.Start("notepad", "Settings.ini");
        }
        void LoadSettings()
        {
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            try
            {
                StreamReader reader = new StreamReader("Settings.ini");

                this.Location = new Point
                    (
                    Convert.ToInt32(reader.ReadLine()),
                    Convert.ToInt32(reader.ReadLine())
                    );

                this.TopMost = tsmiTopmost.Checked = true;
                tsmiTopmost.Checked = bool.Parse(reader.ReadLine());
                tsmiShowControls.Checked = bool.Parse(reader.ReadLine());
                tsmiShowConsole.Checked = bool.Parse(reader.ReadLine());
                tsmiShowDate.Checked = bool.Parse(reader.ReadLine());
                tsmiShowWeekday.Checked = bool.Parse(reader.ReadLine());
                tsmiAutoStart.Checked = bool.Parse(reader.ReadLine());

                labelTime.BackColor = backgroundColorDialog.Color = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
                labelTime.ForeColor = foregroundColorDialog.Color = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));

                fontDialog = new FontDialog(reader.ReadLine(), reader.ReadLine());
                labelTime.Font = fontDialog.Font;

                reader.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Settings issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString
                (
                "hh:mm:ss tt",
                System.Globalization.CultureInfo.InvariantCulture
                );
            if (cbShowDate.Checked) 
            {
                labelTime.Text += "\n";
                labelTime.Text += DateTime.Now.ToString("yyyy.MM.dd");
            }
            if (cbShowWeekday.Checked) 
            {
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
            }
            if (
                alarm != null &&
                (
                   alarm.Date == DateTime.MaxValue ?
                   alarm.Days.Contains((byte)DateTime.Now.DayOfWeek) :
                    CompareDates(alarm.Date, DateTime.Now)
                )
                && alarm.Time.Hours == DateTime.Now.Hour
                && alarm.Time.Minutes == DateTime.Now.Minute
                && alarm.Time.Seconds == DateTime.Now.Second
                )
                MessageBox.Show(alarm.ToString());
            if(DateTime.Now.Second % 5 == 0) alarm = FindNextAlarm();
            notifyIcon.Text = labelTime.Text;
        }
        bool CompareDates(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day;
        }
        Alarm FindNextAlarm()
        {
            Alarm[] actualAlarms = alarms.List.Items.Cast<Alarm>().Where(a => a.Time > DateTime.Now.TimeOfDay).ToArray();
            return actualAlarms.Min();
        }
        private void btnHideControls_Click(object sender, EventArgs e)
        {
            SetVisibility(tsmiShowControls.Checked = false);
        }

        //private void labelTime_MouseHover(object sender, EventArgs e)
        //{
        //    SetVisibility(true);
        //}

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (!TopMost)
            {
                this.TopMost = true;
                this.TopMost = false;
            }
        }

        private void tsmiTopmost_Click(object sender, EventArgs e) => this.TopMost = tsmiTopmost.Checked;

        private void tsmiShowControls_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibility((sender as ToolStripMenuItem).Checked);
            //Sender - это отправитель события (Control, который прислал событие).
            //Если на элемент окна (Control) воздействует пользователь при помощи клавиатуры или мыши,
            //этот Control отправляет событие своему родителю, 
            //а родитель может обрабатывать, или не обрабатывать это событие.
        }

        private void tsmiShowDate_CheckedChanged(object sender, EventArgs e) => cbShowDate.Checked = tsmiShowDate.Checked;

        private void cbShowDate_CheckedChanged(object sender, EventArgs e) => tsmiShowDate.Checked = cbShowDate.Checked;

        private void tsmiShowWeekday_CheckedChanged(object sender, EventArgs e) => cbShowWeekday.Checked = tsmiShowWeekday.Checked;

        private void cbShowWeekday_CheckedChanged(object sender, EventArgs e) => tsmiShowWeekday.Checked = cbShowWeekday.Checked;

        private void tsmiQuit_Click(object sender, EventArgs e) => this.Close();

        private void tsmiForegroundColor_Click(object sender, EventArgs e)
        {
            DialogResult result = foregroundColorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                labelTime.ForeColor = foregroundColorDialog.Color;
            }
        }

        private void tsmiBackgroundColor_Click(object sender, EventArgs e)
        {
            DialogResult result = backgroundColorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                labelTime.BackColor = backgroundColorDialog.Color;
            }
        }
        private void tsmiFont_Click(object sender, EventArgs e)
        {
            fontDialog.Location = new Point
                (
                this.Location.X - fontDialog.Width - 10,
                this.Location.Y
                );
            fontDialog.Font = labelTime.Font;
            DialogResult result = fontDialog.ShowDialog();
            if (result == DialogResult.OK) 
            {
                labelTime.Font = fontDialog.Font;
            }
        }

        private void tsmiAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            string key_name = "ClockPV_521";
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);       //true - открыть ветку на запись
            if (tsmiAutoStart.Checked) rk.SetValue(key_name, Application.ExecutablePath);
            else rk.DeleteValue(key_name, false);                               //false - не бросать исключение, если данная запись остуствует в реестре.
            rk.Dispose();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            alarms.SaveSettingsAalarm();
        }

        private void tsmiAlarms_Click(object sender, EventArgs e)
        {
            alarms.ShowDialog();
        }

        private void tsmiShowConsole_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Checked) AllocConsole();
            else FreeConsole();
        }
        [DllImport("kernel32.dll")]
        public static extern void AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern void FreeConsole();
    }
}
