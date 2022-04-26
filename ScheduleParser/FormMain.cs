using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using ScheduleModels;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ScheduleParser
{
    public partial class FormMain : Form
    {
        Excel.Application ExcelApp;
        Excel.Workbook Workbook;
        Excel.Worksheet Worksheet;
        Excel.Range Range;
        Faculty Faculty;
        Group Group;
        Couple Couple;
        string PathToSchedule = Directory.GetCurrentDirectory() + @"\schedule.xlsx";

        public FormMain()
        {
            InitializeComponent();            
        }
                
        private void buttonReadSchedule_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            fileDialog.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm";

            if (fileDialog.ShowDialog() == DialogResult.OK)
                PathToSchedule = fileDialog.FileName;

            GetSchedule();

            
        }

        private void SerializeSchedule()
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(Faculty));
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\Schedule.json", json.ToString());
            MessageBox.Show("Done");
        }

        private void GetDateOfSheduleUpdate()
        {
            labelLastRenew.Text = "Дата последнего обновления расписания: " + DateTime.Now.ToString();
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\Date of last update.dat", labelLastRenew.Text);
        }

        private void ReadSchedule()
        {            
            for (int r = 1; r <= Workbook.Sheets.Count; r++)
            {
                Worksheet = Workbook.Sheets[r];
                Faculty.FacultyName = Worksheet.Cells[7, "A"].Text.ToString();
                Group = new Group
                {
                    GroupName = Worksheet.Cells[8, "A"].Text.ToString(),
                    GroupId = Worksheet.Name,
                    Couples = new List<Couple>()
                };

                ReadGroup();
                Faculty.Groups.Add(Group);

                progressBarJson.Value++;
            }
        }

        private void ReadGroup()
        {
            for (var columnIndex = 3; columnIndex <= 4; columnIndex++)
            {
                for (var rowIndex = 15; rowIndex < 63; rowIndex++)
                {
                    Couple = new Couple();
                    string fullCoupleName = Worksheet.Cells[rowIndex, columnIndex].Text.ToString();
                    if (fullCoupleName == "" || fullCoupleName == " ")
                    {
                        var temp = Worksheet.Cells[rowIndex, (columnIndex - 1)].Text.ToString();
                        if (columnIndex == 4 && temp != "" && temp != " ")
                            fullCoupleName = temp;
                        else continue;
                    }

                    DefineWeek(rowIndex);
                    DefineSubgroup(columnIndex);
                    DefineDay(rowIndex);
                    DefineNumAndTime(rowIndex);
                    DefineNameTeacherAndAud(fullCoupleName);
                                        
                    Group.Couples.Add(Couple);
                    
                    if (Couple.Week == "1")
                    {
                        Excel.Range cell1 = Worksheet.Cells[rowIndex, columnIndex];
                        Excel.Range cell2 = Worksheet.Cells[rowIndex + 1, columnIndex];
                        Range = (Excel.Range)Worksheet.get_Range(cell1, cell2).Cells;
                        if (!Range.MergeCells)
                        {
                            continue;
                        }
                        Couple temp = new Couple
                        {
                            SubgroupName = Couple.SubgroupName,
                            SubgroupId = Couple.SubgroupId,
                            Week = "2",
                            Day = Couple.Day,
                            CoupleNum = Couple.CoupleNum,
                            TimeBegin = Couple.TimeBegin,
                            TimeEnd = Couple.TimeEnd,
                            CoupleName = Couple.CoupleName,
                            CoupleTeacher = Couple.CoupleTeacher,
                            CoupleAud = Couple.CoupleAud
                        };
                        Group.Couples.Add(temp);
                    }                    
                }
            }
        }

        private void DefineNameTeacherAndAud(string fullCoupleName)
        {
            var coupleName = "";
            for (int i = 0; i < fullCoupleName.Length; i++)
            {
                coupleName += fullCoupleName[i];
                if (fullCoupleName[i] == ')')
                {
                    Couple.CoupleName = coupleName;
                    break;
                }
            }

            var teacherAndAud = fullCoupleName.Substring(coupleName.Length);
            string[] parsedCoupleName = teacherAndAud.Split(new string[] { ", " }, StringSplitOptions.None);
            Couple.CoupleTeacher = parsedCoupleName[1];
            Couple.CoupleAud = parsedCoupleName[2];
        }

        private void DefineNumAndTime(int rowIndex)
        {
            string numAndTime;
            if (Couple.Week == "1") numAndTime = Worksheet.Cells[rowIndex, "B"].Text.ToString();
            else numAndTime = Worksheet.Cells[rowIndex - 1, "B"].Text.ToString();
            Couple.CoupleNum = numAndTime[0].ToString();
            var temp = numAndTime.Replace(" ", "").Substring(5);
            var timeBegin = temp.Split('-')[0];
            var timeEnd = temp.Split('-')[1];
            Couple.TimeBegin = timeBegin.Length == 3 ? timeBegin.Insert(1, ":") : timeBegin.Insert(2, ":");
            Couple.TimeEnd = timeEnd.Length == 3 ? timeEnd.Insert(1, ":") : timeEnd.Insert(2, ":");
        }

        private void DefineSubgroup(int columnIndex)
        {
            Couple.SubgroupId = columnIndex == 3 ? "1" : "2";
            Couple.SubgroupName = columnIndex == 3 ? "Подгруппа 1" : "Подгруппа 2";
        }

        private void DefineWeek(int rowIndex)
        {
            Couple.Week = rowIndex % 2 == 1 ? "1" : "2";            
        }

        private void DefineDay(int rowIndex)
        {
            if (rowIndex >= 15 && rowIndex <= 22) Couple.Day = "monday";
            if (rowIndex >= 23 && rowIndex <= 30) Couple.Day = "tuesday";
            if (rowIndex >= 31 && rowIndex <= 38) Couple.Day = "wednesday";
            if (rowIndex >= 39 && rowIndex <= 46) Couple.Day = "thursday";
            if (rowIndex >= 47 && rowIndex <= 54) Couple.Day = "friday";
            if (rowIndex >= 55 && rowIndex <= 62) Couple.Day = "saturday";
        }

        private void ScanTeachers()
        {
            Faculty fac = JsonConvert.DeserializeObject<Faculty>(File.ReadAllText(
                Directory.GetCurrentDirectory() + @"\Schedule.json"));
            List<string> teachers = new List<string>();
            foreach (var group in fac.Groups)
                foreach (var couple in group.Couples)
                    if (!teachers.Contains(couple.CoupleTeacher.Trim()))
                        teachers.Add(couple.CoupleTeacher.Trim());

            comboBoxChooseTeacher.Items.AddRange(teachers.ToArray());
            comboBoxChooseTeacher.Enabled = true;
        }

        

        private void comboBoxChooseTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxChooseWeek.Enabled = true;
        }

        private void comboBoxChooseWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewTeacherSchedule.Rows.Clear();
            Faculty facultyToRead = JsonConvert.DeserializeObject<Faculty>(File.ReadAllText(
                Directory.GetCurrentDirectory() + @"\Schedule.json"));
            List<TeacherCouple> teacherCouples = new List<TeacherCouple>();
            var teacher = comboBoxChooseTeacher.Text;
            foreach (var group in facultyToRead.Groups)
                foreach (var couple in group.Couples)
                    if (couple.CoupleTeacher == teacher)
                        teacherCouples.Add(new TeacherCouple(couple, group.GroupId));

            teacherCouples = teacherCouples.OrderBy(x => x.Day).ThenBy(x => x.CoupleNum).ToList();
            CreateTeacherSchedule(teacherCouples);
        }

        

        private void CreateTeacherSchedule(List<TeacherCouple> teacherCouples)
        {
            

            int dif = 0;
            for (int i = 0; i < teacherCouples.Count; i++)
            {
                if (comboBoxChooseWeek.Text != teacherCouples[i].Week)
                {
                    dif++;
                    continue;
                }
                DataGridViewRow row = new DataGridViewRow();
                dataGridViewTeacherSchedule.Rows.Add(row);
                row = dataGridViewTeacherSchedule.Rows[i - dif];
                row.Cells[0].Value = TranslateDay(teacherCouples[i].Day.ToString());
                row.Cells[1].Value = teacherCouples[i].CoupleNum;
                row.Cells[2].Value = teacherCouples[i].GroupId;
                row.Cells[3].Value = teacherCouples[i].SubgroupId;
                row.Cells[4].Value = teacherCouples[i].TimeBegin + " - " + teacherCouples[i].TimeEnd;
                row.Cells[5].Value = teacherCouples[i].CoupleName;
                row.Cells[6].Value = teacherCouples[i].CoupleAud;
                //row.Cells[7].Value = DefineDayNum(teacherCouples[i].Day);                
            }
            //dataGridViewTeacherSchedule.Sort(ColumnDayNums, ListSortDirection.Ascending);
        }

        private string TranslateDay(string day)
        {
            switch (day)
            {
                case "Monday":
                    return "Понедельник";
                case "Tuesday":
                    return "Вторник";
                case "Wednesday":
                    return "Среда";
                case "Thursday":
                    return "Четверг";
                case "Friday":
                    return "Пятница";
                case "Saturday":
                    return "Суббота";
            }
            return "error";
        }

        //private string DefineDayNum(string day)
        //{
        //    switch (day)
        //    {
        //        case "monday":
        //            return "1";
        //        case "tuesday":
        //            return "2";
        //        case "wednesday":
        //            return "3";
        //        case "thursday":
        //            return "4";
        //        case "friday":
        //            return "5";
        //        case "saturday":
        //            return "6";
        //    }
        //    return "error";
        //}

        private void GetSchedule()
        {
            ExcelApp = new Excel.Application();
            Workbook = ExcelApp.Workbooks.Open(PathToSchedule);
            Faculty = new Faculty { Groups = new List<Group>() };

            progressBarJson.Maximum = Workbook.Sheets.Count;
            ReadSchedule();
            SerializeSchedule();
            progressBarJson.Value = 0;

            ExcelApp.Quit();

            GetDateOfSheduleUpdate();
            ScanTeachers();
        }            

        private void FormMain_Load(object sender, EventArgs e)
        {
            dataGridViewTeacherSchedule.AutoGenerateColumns = false;
            labelLastRenew.Text =
                File.ReadAllText(Directory.GetCurrentDirectory() + @"\Date of last update.dat");
        }

        private bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dataGridViewTeacherSchedule[column, row];
            DataGridViewCell cell2 = dataGridViewTeacherSchedule[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dataGridViewTeacherSchedule_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dataGridViewTeacherSchedule.AdvancedCellBorderStyle.Top;
            }
        }

        private void dataGridViewTeacherSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }        
    }
}