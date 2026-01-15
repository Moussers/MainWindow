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
    public partial class AlarmsForm : Form
    {
        AlarmDialog alarm;
        public AlarmsForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point
                (
                    Screen.PrimaryScreen.Bounds.Width - this.Width - 25,
                    Screen.PrimaryScreen.Bounds.Height - this.Height - 560

                );
            alarm = new AlarmDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (alarm.ShowDialog() == DialogResult.OK)
            {
                listBoxAlarms.Items.Add(alarm.Alarm);
            }
        }

        private void listBoxAlarms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxAlarms.SelectedItem == null) 
            {
                return;
            }
            Alarm alarm = listBoxAlarms.SelectedItem as Alarm;
            if (alarm == null)
            {
                MessageBox.Show("Выбранный элемент не является будильником", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AlarmDialog chengingAlarm = new AlarmDialog();
                chengingAlarm.ShowDialog();
            }
        }
    }
}
