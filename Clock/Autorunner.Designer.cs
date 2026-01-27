namespace Clock
{
    partial class Autorunner
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
            this.checkBoxLaunch = new System.Windows.Forms.CheckBox();
            this.buttonComplete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxLaunch
            // 
            this.checkBoxLaunch.AutoSize = true;
            this.checkBoxLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxLaunch.Location = new System.Drawing.Point(39, 110);
            this.checkBoxLaunch.Name = "checkBoxLaunch";
            this.checkBoxLaunch.Size = new System.Drawing.Size(294, 24);
            this.checkBoxLaunch.TabIndex = 1;
            this.checkBoxLaunch.Text = "Запусить установочную программу";
            this.checkBoxLaunch.UseVisualStyleBackColor = true;
            // 
            // buttonComplete
            // 
            this.buttonComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonComplete.Location = new System.Drawing.Point(379, 196);
            this.buttonComplete.Name = "buttonComplete";
            this.buttonComplete.Size = new System.Drawing.Size(106, 31);
            this.buttonComplete.TabIndex = 2;
            this.buttonComplete.Text = "Завершить";
            this.buttonComplete.UseVisualStyleBackColor = true;
            this.buttonComplete.Click += new System.EventHandler(this.buttonComplete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(34, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поздравляем, Вы установили ClockPV_521!";
            // 
            // Autorunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 239);
            this.Controls.Add(this.buttonComplete);
            this.Controls.Add(this.checkBoxLaunch);
            this.Controls.Add(this.label1);
            this.Name = "Autorunner";
            this.Text = "Завершение установки";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxLaunch;
        private System.Windows.Forms.Button buttonComplete;
        private System.Windows.Forms.Label label1;
    }
}