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
        Excel.Application App;
        Excel.Workbook Workbook;
        Excel.Worksheet Worksheet;
        Faculty Faculty;
        Group Group;
        Couple Couple;

        public FormMain()
        {
            InitializeComponent();
        }

        
        private void buttonReadSchedule_Click(object sender, EventArgs e)
        {            
            App = new Excel.Application();
            Workbook = App.Workbooks.Open(Directory.GetCurrentDirectory() + @"\schedule.xlsx");
            Faculty = new Faculty
            {
                Groups = new List<Group>()
            };

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
            }
            JObject json = JObject.Parse(JsonConvert.SerializeObject(Faculty));
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\Schedule.json", json.ToString());
            MessageBox.Show("Done");

            App.Quit();
        }

        private void ReadGroup()
        {
            for (var i = 3; i <= 4; i++)
            {
                for (int j = 15; j < 63; j++)
                {
                    Couple = new Couple();
                    var columnIndex = i;
                    var rowIndex = j;
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
    }
}