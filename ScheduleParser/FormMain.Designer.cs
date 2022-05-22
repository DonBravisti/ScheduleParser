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
            this.comboBoxChooseTeacher = new System.Windows.Forms.ComboBox();
            this.dataGridViewTeacherSchedule = new System.Windows.Forms.DataGridView();
            this.ColumnDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBarJson = new System.Windows.Forms.ProgressBar();
            this.labelLastRenew = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadScheduleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportScheduleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeacherSchedule)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxChooseTeacher
            // 
            this.comboBoxChooseTeacher.Enabled = false;
            this.comboBoxChooseTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxChooseTeacher.FormattingEnabled = true;
            this.comboBoxChooseTeacher.Location = new System.Drawing.Point(3, 9);
            this.comboBoxChooseTeacher.Name = "comboBoxChooseTeacher";
            this.comboBoxChooseTeacher.Size = new System.Drawing.Size(228, 24);
            this.comboBoxChooseTeacher.Sorted = true;
            this.comboBoxChooseTeacher.TabIndex = 1;
            this.comboBoxChooseTeacher.Text = "Выберите преподавателя";
            this.comboBoxChooseTeacher.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseTeacher_SelectedIndexChanged);
            // 
            // dataGridViewTeacherSchedule
            // 
            this.dataGridViewTeacherSchedule.AllowUserToAddRows = false;
            this.dataGridViewTeacherSchedule.AllowUserToDeleteRows = false;
            this.dataGridViewTeacherSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTeacherSchedule.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewTeacherSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeacherSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDay,
            this.ColumnNum,
            this.ColumnWeek,
            this.ColumnGroup,
            this.ColumnSubgroup,
            this.ColumnTime,
            this.ColumnName,
            this.ColumnAud});
            this.dataGridViewTeacherSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTeacherSchedule.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTeacherSchedule.Name = "dataGridViewTeacherSchedule";
            this.dataGridViewTeacherSchedule.ReadOnly = true;
            this.dataGridViewTeacherSchedule.RowHeadersVisible = false;
            this.dataGridViewTeacherSchedule.RowHeadersWidth = 51;
            this.dataGridViewTeacherSchedule.RowTemplate.Height = 24;
            this.dataGridViewTeacherSchedule.Size = new System.Drawing.Size(1067, 463);
            this.dataGridViewTeacherSchedule.TabIndex = 4;
            this.dataGridViewTeacherSchedule.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTeacherSchedule_CellFormatting);
            this.dataGridViewTeacherSchedule.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewTeacherSchedule_CellPainting);
            // 
            // ColumnDay
            // 
            this.ColumnDay.FillWeight = 99.85379F;
            this.ColumnDay.HeaderText = "День недели";
            this.ColumnDay.MinimumWidth = 6;
            this.ColumnDay.Name = "ColumnDay";
            this.ColumnDay.ReadOnly = true;
            // 
            // ColumnNum
            // 
            this.ColumnNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnNum.HeaderText = "Номер пары";
            this.ColumnNum.MinimumWidth = 6;
            this.ColumnNum.Name = "ColumnNum";
            this.ColumnNum.ReadOnly = true;
            this.ColumnNum.Width = 109;
            // 
            // ColumnWeek
            // 
            this.ColumnWeek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnWeek.HeaderText = "Неделя";
            this.ColumnWeek.MinimumWidth = 6;
            this.ColumnWeek.Name = "ColumnWeek";
            this.ColumnWeek.ReadOnly = true;
            this.ColumnWeek.Width = 87;
            // 
            // ColumnGroup
            // 
            this.ColumnGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnGroup.HeaderText = "Группа";
            this.ColumnGroup.MinimumWidth = 6;
            this.ColumnGroup.Name = "ColumnGroup";
            this.ColumnGroup.ReadOnly = true;
            this.ColumnGroup.Width = 84;
            // 
            // ColumnSubgroup
            // 
            this.ColumnSubgroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnSubgroup.HeaderText = "Подгруппа";
            this.ColumnSubgroup.MinimumWidth = 6;
            this.ColumnSubgroup.Name = "ColumnSubgroup";
            this.ColumnSubgroup.ReadOnly = true;
            this.ColumnSubgroup.Width = 107;
            // 
            // ColumnTime
            // 
            this.ColumnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTime.HeaderText = "Время";
            this.ColumnTime.MinimumWidth = 6;
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            this.ColumnTime.Width = 79;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnName.FillWeight = 68.83992F;
            this.ColumnName.HeaderText = "Название предмета";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 154;
            // 
            // ColumnAud
            // 
            this.ColumnAud.FillWeight = 131.3056F;
            this.ColumnAud.HeaderText = "Аудитория";
            this.ColumnAud.MinimumWidth = 6;
            this.ColumnAud.Name = "ColumnAud";
            this.ColumnAud.ReadOnly = true;
            // 
            // progressBarJson
            // 
            this.progressBarJson.Dock = System.Windows.Forms.DockStyle.Right;
            this.progressBarJson.Location = new System.Drawing.Point(836, 0);
            this.progressBarJson.Name = "progressBarJson";
            this.progressBarJson.Size = new System.Drawing.Size(231, 36);
            this.progressBarJson.TabIndex = 6;
            // 
            // labelLastRenew
            // 
            this.labelLastRenew.AutoSize = true;
            this.labelLastRenew.Location = new System.Drawing.Point(243, 12);
            this.labelLastRenew.Name = "labelLastRenew";
            this.labelLastRenew.Size = new System.Drawing.Size(234, 17);
            this.labelLastRenew.TabIndex = 8;
            this.labelLastRenew.Text = "Дата и время последней загрузки";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.AboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadScheduleMenuItem,
            this.ExportScheduleMenuItem,
            this.toolStripMenuItem2,
            this.ExitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(59, 26);
            this.FileMenuItem.Text = "Файл";
            // 
            // LoadScheduleMenuItem
            // 
            this.LoadScheduleMenuItem.Name = "LoadScheduleMenuItem";
            this.LoadScheduleMenuItem.Size = new System.Drawing.Size(247, 26);
            this.LoadScheduleMenuItem.Text = "Загрузить расписание";
            this.LoadScheduleMenuItem.Click += new System.EventHandler(this.LoadScheduleMenuItem_Click);
            // 
            // ExportScheduleMenuItem
            // 
            this.ExportScheduleMenuItem.Name = "ExportScheduleMenuItem";
            this.ExportScheduleMenuItem.Size = new System.Drawing.Size(247, 26);
            this.ExportScheduleMenuItem.Text = "Экспорт расписания";
            this.ExportScheduleMenuItem.Click += new System.EventHandler(this.ExportScheduleMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(244, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(247, 26);
            this.ExitMenuItem.Text = "Выход";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(118, 26);
            this.AboutMenuItem.Text = "О программе";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // LoadScheduleToolStripMenuItem
            // 
            this.LoadScheduleToolStripMenuItem.Name = "LoadScheduleToolStripMenuItem";
            this.LoadScheduleToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // ExportScheduleToolStripMenuItem
            // 
            this.ExportScheduleToolStripMenuItem.Name = "ExportScheduleToolStripMenuItem";
            this.ExportScheduleToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(6, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxChooseTeacher);
            this.panel1.Controls.Add(this.progressBarJson);
            this.panel1.Controls.Add(this.labelLastRenew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 36);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewTeacherSchedule);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 463);
            this.panel2.TabIndex = 11;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 527);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1085, 574);
            this.Name = "FormMain";
            this.Text = "Парсер расписания";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeacherSchedule)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxChooseTeacher;
        private System.Windows.Forms.DataGridView dataGridViewTeacherSchedule;
        private System.Windows.Forms.ProgressBar progressBarJson;
        private System.Windows.Forms.Label labelLastRenew;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadScheduleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportScheduleMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAud;
    }
}

