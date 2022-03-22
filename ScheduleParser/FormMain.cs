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

        private void button1_Click(object sender, EventArgs e)
        {
            App = new Excel.Application();
            Workbook = App.Workbooks.Open(@"D:\ПМ-2021\Stas Butov\ScheduleParser-main\ScheduleParser\bin\Debug\schedule1.xlsm");
            
            Worksheet = Workbook.Sheets[1];
            Faculty = new Faculty();
            Group = new Group();
            

            Faculty.FacultyName = Worksheet.Cells[7, "A"].Text.ToString();
            Group.GroupName = Worksheet.Cells[8, "A"].Text.ToString();
            Group.GroupId = Worksheet.Name;
            Group.Couples = new List<Couple>();
            for (var i = 'C'; i <= 'D'; i++)
            {
                for (int j = 15; j < 63; j++)
                {
                    Couple = new Couple();
                    string fullCoupleName = Worksheet.Cells[j, i.ToString()].Text.ToString();
                    if (fullCoupleName == "") continue;

                    DefineWeek(j);
                    DefineSubgroup(i);
                    DefineDay(j);
                    DefineNumAndTime(j);
                    DefineNameTeacherAndAud(fullCoupleName);

                    Group.Couples.Add(Couple);
                }
            }
            JObject json = JObject.Parse(JsonConvert.SerializeObject(Group));
            File.WriteAllText(@"D:\ПМ-2021\Stas Butov\ScheduleParser-main\ScheduleParser\bin\Debug\Schedule.json", json.ToString());
            MessageBox.Show("Done");

            App.Quit();
        }

        private void DefineNameTeacherAndAud(string fullCoupleName)
        {
            string[] parsedCoupleName = fullCoupleName.Split(new string[] { ", " }, StringSplitOptions.None);
            Couple.CoupleName = parsedCoupleName[0];
            Couple.CoupleTeacher = parsedCoupleName[1];
            Couple.CoupleAud = parsedCoupleName[2];
        }

        private void DefineNumAndTime(int rowIndex)
        {
            string numAndTime;
            if (Couple.Week == "1") numAndTime = Worksheet.Cells[rowIndex, "B"].Text.ToString();
            else numAndTime = Worksheet.Cells[rowIndex - 1, "B"].Text.ToString();
            Couple.CoupleNum = numAndTime[0].ToString();
            var temp = numAndTime.Split(new string[] { "  ", " " }, StringSplitOptions.None);
            Couple.TimeBegin = temp[2].Split('-')[0];
            Couple.TimeEnd = temp[2].Split('-')[1];
        }

        private void DefineSubgroup(char charColumnIndex)
        {
            if (charColumnIndex == 'C')
            {
                Couple.SubgroupId = "1";
                Couple.SubgroupName = "Подгруппа 1";
            }
            else
            {
                Couple.SubgroupId = "2";
                Couple.SubgroupName = "Подгруппа 2";
            }
        }

        private void DefineWeek(int rowIndex)
        {
            if (rowIndex % 2 == 1) Couple.Week = "1";
            else Couple.Week = "2";
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
