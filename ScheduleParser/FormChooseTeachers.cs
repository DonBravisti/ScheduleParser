using ScheduleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleParser
{
    public partial class FormChooseTeachers : Form
    {
        

        public FormChooseTeachers()
        {
            InitializeComponent();
        }

        private void FormChooseTeachers_Load(object sender, EventArgs e)
        {
            FormMain form = new FormMain();
            var teachers = form.CreateTeacherList();

            teachers.Sort();
            foreach (var item in teachers)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = item;
                flowLayoutPanelTeacherTextBoxes.Controls.Add(checkBox);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            List<string> teachers = new List<string>();
            foreach (var item in flowLayoutPanelTeacherTextBoxes.Controls)
            {                
                CheckBox checkBox = (CheckBox)item;
                if (checkBox.Checked)
                    teachers.Add(checkBox.Text);
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Выберите папку, в которую будут сохранены файлы";

            if (!(dialog.ShowDialog() == DialogResult.OK))
                return;
            var path = dialog.SelectedPath + @"\Расписание\";

            FormMain form = new FormMain();
            Directory.CreateDirectory(path);
            foreach (var teacher in teachers)
            {
                var fileName = path + "Расписание для преподавателя " + teacher + ".pdf";
                List<TeacherCouple> teacherCouples = form.CreateCoupleListForChosenTeacher(teacher);
                form.WriteToPDF(fileName, teacherCouples);
            }

            MessageBox.Show("Файлы сохранены");
            this.Close();
        }

        private void buttonChooseAll_Click(object sender, EventArgs e)
        {
            foreach (var control in flowLayoutPanelTeacherTextBoxes.Controls)
            {
                CheckBox checkBox = (CheckBox)control;
                checkBox.Checked = true;
            }
        }
    }
}
