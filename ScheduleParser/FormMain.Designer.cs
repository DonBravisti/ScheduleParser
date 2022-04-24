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
            this.dataGridViewTeacherSchedule = new System.Windows.Forms.DataGridView();
            this.ColumnDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDayNums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxChooseWeek = new System.Windows.Forms.ComboBox();
            this.progressBarJson = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeacherSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReadSchedule
            // 
            this.buttonReadSchedule.Location = new System.Drawing.Point(770, 13);
            this.buttonReadSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReadSchedule.Name = "buttonReadSchedule";
            this.buttonReadSchedule.Size = new System.Drawing.Size(284, 87);
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
            this.comboBoxChooseTeacher.Size = new System.Drawing.Size(228, 24);
            this.comboBoxChooseTeacher.Sorted = true;
            this.comboBoxChooseTeacher.TabIndex = 1;
            this.comboBoxChooseTeacher.Text = "Выберите преподавателя";
            this.comboBoxChooseTeacher.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseTeacher_SelectedIndexChanged);
            // 
            // buttonScanTeachers
            // 
            this.buttonScanTeachers.Location = new System.Drawing.Point(247, 12);
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
            this.buttonGetTeacherSchedule.Location = new System.Drawing.Point(247, 52);
            this.buttonGetTeacherSchedule.Name = "buttonGetTeacherSchedule";
            this.buttonGetTeacherSchedule.Size = new System.Drawing.Size(206, 23);
            this.buttonGetTeacherSchedule.TabIndex = 3;
            this.buttonGetTeacherSchedule.Text = "Составить расписание";
            this.buttonGetTeacherSchedule.UseVisualStyleBackColor = true;
            this.buttonGetTeacherSchedule.Click += new System.EventHandler(this.buttonGetTeacherSchedule_Click);
            // 
            // dataGridViewTeacherSchedule
            // 
            this.dataGridViewTeacherSchedule.AllowUserToAddRows = false;
            this.dataGridViewTeacherSchedule.AllowUserToDeleteRows = false;
            this.dataGridViewTeacherSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTeacherSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeacherSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDay,
            this.ColumnNum,
            this.ColumnGroup,
            this.ColumnSubgroup,
            this.ColumnTime,
            this.ColumnName,
            this.ColumnAud,
            this.ColumnDayNums});
            this.dataGridViewTeacherSchedule.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewTeacherSchedule.Location = new System.Drawing.Point(0, 166);
            this.dataGridViewTeacherSchedule.Name = "dataGridViewTeacherSchedule";
            this.dataGridViewTeacherSchedule.ReadOnly = true;
            this.dataGridViewTeacherSchedule.RowHeadersVisible = false;
            this.dataGridViewTeacherSchedule.RowHeadersWidth = 51;
            this.dataGridViewTeacherSchedule.RowTemplate.Height = 24;
            this.dataGridViewTeacherSchedule.Size = new System.Drawing.Size(1067, 361);
            this.dataGridViewTeacherSchedule.TabIndex = 4;
            // 
            // ColumnDay
            // 
            this.ColumnDay.HeaderText = "День недели";
            this.ColumnDay.MinimumWidth = 6;
            this.ColumnDay.Name = "ColumnDay";
            this.ColumnDay.ReadOnly = true;
            this.ColumnDay.Width = 113;
            // 
            // ColumnNum
            // 
            this.ColumnNum.HeaderText = "Номер пары";
            this.ColumnNum.MinimumWidth = 6;
            this.ColumnNum.Name = "ColumnNum";
            this.ColumnNum.ReadOnly = true;
            this.ColumnNum.Width = 109;
            // 
            // ColumnGroup
            // 
            this.ColumnGroup.HeaderText = "Группа";
            this.ColumnGroup.MinimumWidth = 6;
            this.ColumnGroup.Name = "ColumnGroup";
            this.ColumnGroup.ReadOnly = true;
            this.ColumnGroup.Width = 84;
            // 
            // ColumnSubgroup
            // 
            this.ColumnSubgroup.HeaderText = "Подгруппа";
            this.ColumnSubgroup.MinimumWidth = 6;
            this.ColumnSubgroup.Name = "ColumnSubgroup";
            this.ColumnSubgroup.ReadOnly = true;
            this.ColumnSubgroup.Width = 107;
            // 
            // ColumnTime
            // 
            this.ColumnTime.HeaderText = "Время";
            this.ColumnTime.MinimumWidth = 6;
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            this.ColumnTime.Width = 79;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Название предмета";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 154;
            // 
            // ColumnAud
            // 
            this.ColumnAud.HeaderText = "Аудитория";
            this.ColumnAud.MinimumWidth = 6;
            this.ColumnAud.Name = "ColumnAud";
            this.ColumnAud.ReadOnly = true;
            this.ColumnAud.Width = 108;
            // 
            // ColumnDayNums
            // 
            this.ColumnDayNums.HeaderText = "Column1";
            this.ColumnDayNums.MinimumWidth = 6;
            this.ColumnDayNums.Name = "ColumnDayNums";
            this.ColumnDayNums.ReadOnly = true;
            this.ColumnDayNums.Visible = false;
            this.ColumnDayNums.Width = 92;
            // 
            // comboBoxChooseWeek
            // 
            this.comboBoxChooseWeek.Enabled = false;
            this.comboBoxChooseWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxChooseWeek.FormattingEnabled = true;
            this.comboBoxChooseWeek.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBoxChooseWeek.Location = new System.Drawing.Point(13, 50);
            this.comboBoxChooseWeek.Name = "comboBoxChooseWeek";
            this.comboBoxChooseWeek.Size = new System.Drawing.Size(228, 24);
            this.comboBoxChooseWeek.TabIndex = 5;
            this.comboBoxChooseWeek.Text = "Выберите неделю";
            this.comboBoxChooseWeek.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseWeek_SelectedIndexChanged);
            // 
            // progressBarJson
            // 
            this.progressBarJson.Location = new System.Drawing.Point(770, 107);
            this.progressBarJson.Name = "progressBarJson";
            this.progressBarJson.Size = new System.Drawing.Size(285, 23);
            this.progressBarJson.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 527);
            this.Controls.Add(this.progressBarJson);
            this.Controls.Add(this.comboBoxChooseWeek);
            this.Controls.Add(this.dataGridViewTeacherSchedule);
            this.Controls.Add(this.buttonGetTeacherSchedule);
            this.Controls.Add(this.buttonScanTeachers);
            this.Controls.Add(this.comboBoxChooseTeacher);
            this.Controls.Add(this.buttonReadSchedule);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Парсер расписания";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeacherSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReadSchedule;
        private System.Windows.Forms.ComboBox comboBoxChooseTeacher;
        private System.Windows.Forms.Button buttonScanTeachers;
        private System.Windows.Forms.Button buttonGetTeacherSchedule;
        private System.Windows.Forms.DataGridView dataGridViewTeacherSchedule;
        private System.Windows.Forms.ComboBox comboBoxChooseWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAud;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDayNums;
        private System.Windows.Forms.ProgressBar progressBarJson;
    }
}

