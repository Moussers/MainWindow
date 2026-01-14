namespace Clock
{
    partial class AlarmDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmDialog));
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.checkBoxUseDate = new System.Windows.Forms.CheckBox();
            this.labelWeekdays = new System.Windows.Forms.Label();
            this.clbWeekDays = new System.Windows.Forms.CheckedListBox();
            this.labelFilename = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy.MM.dd";
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(12, 48);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 31);
            this.dtpDate.TabIndex = 0;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "HH:mm:ss";
            this.dtpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(215, 48);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(160, 31);
            this.dtpTime.TabIndex = 1;
            // 
            // checkBoxUseDate
            // 
            this.checkBoxUseDate.AutoSize = true;
            this.checkBoxUseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxUseDate.Location = new System.Drawing.Point(12, 12);
            this.checkBoxUseDate.Name = "checkBoxUseDate";
            this.checkBoxUseDate.Size = new System.Drawing.Size(262, 29);
            this.checkBoxUseDate.TabIndex = 2;
            this.checkBoxUseDate.Text = "На определенную дату";
            this.checkBoxUseDate.UseVisualStyleBackColor = true;
            this.checkBoxUseDate.CheckedChanged += new System.EventHandler(this.checkBoxUseDate_CheckedChanged);
            // 
            // labelWeekdays
            // 
            this.labelWeekdays.AutoSize = true;
            this.labelWeekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWeekdays.Location = new System.Drawing.Point(13, 105);
            this.labelWeekdays.Name = "labelWeekdays";
            this.labelWeekdays.Size = new System.Drawing.Size(130, 25);
            this.labelWeekdays.TabIndex = 3;
            this.labelWeekdays.Text = "Дни недели";
            // 
            // clbWeekDays
            // 
            this.clbWeekDays.ColumnWidth = 48;
            this.clbWeekDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clbWeekDays.FormattingEnabled = true;
            this.clbWeekDays.Items.AddRange(new object[] {
            "Пн",
            "Вт",
            "Ср",
            "Чт",
            "Пт",
            "Сб",
            "Вс"});
            this.clbWeekDays.Location = new System.Drawing.Point(18, 145);
            this.clbWeekDays.MultiColumn = true;
            this.clbWeekDays.Name = "clbWeekDays";
            this.clbWeekDays.Size = new System.Drawing.Size(357, 28);
            this.clbWeekDays.TabIndex = 4;
            this.clbWeekDays.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbWeekDays_ItemCheck);
            this.clbWeekDays.SelectedIndexChanged += new System.EventHandler(this.clbWeekDays_SelectedIndexChanged);
            // 
            // labelFilename
            // 
            this.labelFilename.AutoSize = true;
            this.labelFilename.Location = new System.Drawing.Point(18, 193);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(52, 13);
            this.labelFilename.TabIndex = 5;
            this.labelFilename.Text = "Filename:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 232);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(215, 232);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(300, 232);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // AlarmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 269);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelFilename);
            this.Controls.Add(this.clbWeekDays);
            this.Controls.Add(this.labelWeekdays);
            this.Controls.Add(this.checkBoxUseDate);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.dtpDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlarmDialog";
            this.Text = "AlarmDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.CheckBox checkBoxUseDate;
        private System.Windows.Forms.Label labelWeekdays;
        private System.Windows.Forms.CheckedListBox clbWeekDays;
        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}