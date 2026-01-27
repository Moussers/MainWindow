namespace Autorunner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Autorunner));
            this.labelnfo = new System.Windows.Forms.Label();
            this.checkBoxLaunch = new System.Windows.Forms.CheckBox();
            this.buttonComplete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelnfo
            // 
            this.labelnfo.AutoSize = true;
            this.labelnfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelnfo.Location = new System.Drawing.Point(22, 35);
            this.labelnfo.Name = "labelnfo";
            this.labelnfo.Size = new System.Drawing.Size(445, 25);
            this.labelnfo.TabIndex = 0;
            this.labelnfo.Text = "Поздравляем, Вы устанвили ClockPV_521! ";
            // 
            // checkBoxLaunch
            // 
            this.checkBoxLaunch.AutoSize = true;
            this.checkBoxLaunch.Checked = true;
            this.checkBoxLaunch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLaunch.Location = new System.Drawing.Point(27, 79);
            this.checkBoxLaunch.Name = "checkBoxLaunch";
            this.checkBoxLaunch.Size = new System.Drawing.Size(220, 17);
            this.checkBoxLaunch.TabIndex = 1;
            this.checkBoxLaunch.Text = "Запустить установленную программу!";
            this.checkBoxLaunch.UseVisualStyleBackColor = true;
            // 
            // buttonComplete
            // 
            this.buttonComplete.Location = new System.Drawing.Point(384, 124);
            this.buttonComplete.Name = "buttonComplete";
            this.buttonComplete.Size = new System.Drawing.Size(83, 23);
            this.buttonComplete.TabIndex = 2;
            this.buttonComplete.Text = "Завершить";
            this.buttonComplete.UseVisualStyleBackColor = true;
            this.buttonComplete.Click += new System.EventHandler(this.buttonComplete_Click);
            // 
            // Autorunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 169);
            this.Controls.Add(this.buttonComplete);
            this.Controls.Add(this.checkBoxLaunch);
            this.Controls.Add(this.labelnfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Autorunner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заврешение установки";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelnfo;
        private System.Windows.Forms.CheckBox checkBoxLaunch;
        private System.Windows.Forms.Button buttonComplete;
    }
}

