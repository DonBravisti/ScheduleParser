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
            this.comboBoxChooseTeacher = new System.Windows.Forms.ComboBox();
            this.buttonScanTeachers = new System.Windows.Forms.Button();
            this.buttonGetTeacherSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReadSchedule
            // 
            this.buttonReadSchedule.Location = new System.Drawing.Point(770, 13);
            this.buttonReadSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReadSchedule.Name = "buttonReadSchedule";
            this.buttonReadSchedule.Size = new System.Drawing.Size(284, 126);
            this.buttonReadSchedule.TabIndex = 0;
            this.buttonReadSchedule.Text = "Прочитать расписание и записать в json";
            this.buttonReadSchedule.UseVisualStyleBackColor = true;
            this.buttonReadSchedule.Click += new System.EventHandler(this.buttonReadSchedule_Click);
            // 
            // comboBoxChooseTeacher
            // 
            this.comboBoxChooseTeacher.Enabled = false;
            this.comboBoxChooseTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxChooseTeacher.FormattingEnabled = true;
            this.comboBoxChooseTeacher.Location = new System.Drawing.Point(13, 13);
            this.comboBoxChooseTeacher.Name = "comboBoxChooseTeacher";
            this.comboBoxChooseTeacher.Size = new System.Drawing.Size(171, 24);
            this.comboBoxChooseTeacher.Sorted = true;
            this.comboBoxChooseTeacher.TabIndex = 1;
            this.comboBoxChooseTeacher.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseTeacher_SelectedIndexChanged);
            // 
            // buttonScanTeachers
            // 
            this.buttonScanTeachers.Location = new System.Drawing.Point(190, 13);
            this.buttonScanTeachers.Name = "buttonScanTeachers";
            this.buttonScanTeachers.Size = new System.Drawing.Size(206, 23);
            this.buttonScanTeachers.TabIndex = 2;
            this.buttonScanTeachers.Text = "Найти преподавателей";
            this.buttonScanTeachers.UseVisualStyleBackColor = true;
            this.buttonScanTeachers.Click += new System.EventHandler(this.buttonScanTeachers_Click);
            // 
            // buttonGetTeacherSchedule
            // 
            this.buttonGetTeacherSchedule.Enabled = false;
            this.buttonGetTeacherSchedule.Location = new System.Drawing.Point(190, 53);
            this.buttonGetTeacherSchedule.Name = "buttonGetTeacherSchedule";
            this.buttonGetTeacherSchedule.Size = new System.Drawing.Size(206, 23);
            this.buttonGetTeacherSchedule.TabIndex = 3;
            this.buttonGetTeacherSchedule.Text = "Составить расписание";
            this.buttonGetTeacherSchedule.UseVisualStyleBackColor = true;
            this.buttonGetTeacherSchedule.Click += new System.EventHandler(this.buttonGetTeacherSchedule_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.buttonGetTeacherSchedule);
            this.Controls.Add(this.buttonScanTeachers);
            this.Controls.Add(this.comboBoxChooseTeacher);
            this.Controls.Add(this.buttonReadSchedule);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReadSchedule;
        private System.Windows.Forms.ComboBox comboBoxChooseTeacher;
        private System.Windows.Forms.Button buttonScanTeachers;
        private System.Windows.Forms.Button buttonGetTeacherSchedule;
    }
}

