
namespace ScheduleParser
{
    partial class FormChooseTeachers
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
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonChooseAll = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelTeacherTextBoxes = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonCancel);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonChooseAll);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonDone);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(0, 414);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(785, 36);
            this.flowLayoutPanelButtons.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(698, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(84, 30);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonChooseAll
            // 
            this.buttonChooseAll.AutoSize = true;
            this.buttonChooseAll.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChooseAll.Location = new System.Drawing.Point(557, 3);
            this.buttonChooseAll.Name = "buttonChooseAll";
            this.buttonChooseAll.Size = new System.Drawing.Size(135, 30);
            this.buttonChooseAll.TabIndex = 2;
            this.buttonChooseAll.Text = "Выбрать всех";
            this.buttonChooseAll.UseVisualStyleBackColor = true;
            this.buttonChooseAll.Click += new System.EventHandler(this.buttonChooseAll_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.AutoSize = true;
            this.buttonDone.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDone.Location = new System.Drawing.Point(472, 3);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(79, 30);
            this.buttonDone.TabIndex = 1;
            this.buttonDone.Text = "Готово";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 36);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(723, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите преподавателей, для которых будет выгружено расписание";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowLayoutPanelTeacherTextBoxes
            // 
            this.flowLayoutPanelTeacherTextBoxes.AutoScroll = true;
            this.flowLayoutPanelTeacherTextBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTeacherTextBoxes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTeacherTextBoxes.Location = new System.Drawing.Point(0, 36);
            this.flowLayoutPanelTeacherTextBoxes.Name = "flowLayoutPanelTeacherTextBoxes";
            this.flowLayoutPanelTeacherTextBoxes.Size = new System.Drawing.Size(785, 378);
            this.flowLayoutPanelTeacherTextBoxes.TabIndex = 7;
            // 
            // FormChooseTeachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 450);
            this.Controls.Add(this.flowLayoutPanelTeacherTextBoxes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanelButtons);
            this.Name = "FormChooseTeachers";
            this.Text = "Выбор преподавателей";
            this.Load += new System.EventHandler(this.FormChooseTeachers_Load);
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTeacherTextBoxes;
        private System.Windows.Forms.Button buttonChooseAll;
    }
}