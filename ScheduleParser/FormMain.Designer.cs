namespace ScheduleParser
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonReadSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReadSchedule
            // 
            this.buttonReadSchedule.Location = new System.Drawing.Point(399, 203);
            this.buttonReadSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReadSchedule.Name = "buttonReadSchedule";
            this.buttonReadSchedule.Size = new System.Drawing.Size(284, 126);
            this.buttonReadSchedule.TabIndex = 0;
            this.buttonReadSchedule.Text = "Прочитать расписание и записать в json";
            this.buttonReadSchedule.UseVisualStyleBackColor = true;
            this.buttonReadSchedule.Click += new System.EventHandler(this.buttonReadSchedule_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.buttonReadSchedule);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReadSchedule;
    }
}

