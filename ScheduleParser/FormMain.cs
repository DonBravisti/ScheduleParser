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
            Workbook = App.Workbooks.Open("C:/Programs/Microsoft Visual Studio/Projects/ScheduleParser-main/ScheduleParser/bin/Debug/schedule1.xlsm");
            
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

                    if (j % 2 == 1) Couple.Week = "1";
                    else Couple.Week = "2";
                    if (i == 'C')
                    {
                        Couple.SubgroupId = "1";
                        Couple.SubgroupName = "Подгруппа 1";
                    }
                    else
                    {
                        Couple.SubgroupId = "2";
                        Couple.SubgroupName = "Подгруппа 2";
                    }

                    Couple.Day = GetDay(j);

                    string numAndTime;
                    if (Couple.Week == "1") numAndTime = Worksheet.Cells[j, "B"].Text.ToString();
                    else numAndTime = Worksheet.Cells[j - 1, "B"].Text.ToString();
                    Couple.CoupleNum = numAndTime[0].ToString();
                    var temp = numAndTime.Split();
                    Couple.TimeBegin = temp[2].Split('-')[0];
                    Couple.TimeEnd = temp[2].Split('-')[1]; //херня происходит

                    string[] parsedCoupleName = fullCoupleName.Split(new string[] { ", " }, StringSplitOptions.None);
                    Couple.CoupleName = parsedCoupleName[0];
                    Couple.CoupleTeacher = parsedCoupleName[1];
                    Couple.CoupleAud = parsedCoupleName[2];

                    Group.Couples.Add(Couple);
                }
            }
            JObject json = JObject.Parse(JsonConvert.SerializeObject(Group));
            File.WriteAllText(@"C:\Programs\Microsoft Visual Studio\Projects\ScheduleParser-main\ScheduleParser\bin\Debug\Schedule.json", json.ToString());
            MessageBox.Show("Done");

            App.Quit();
        }

        private string GetDay(int j)
        {
            if (j >= 15 && j <= 22) return "monday";
            if (j >= 23 && j <= 30) return "tuesday";
            if (j >= 31 && j <= 38) return "wednesday";
            if (j >= 39 && j <= 46) return "thursday";
            if (j >= 47 && j <= 54) return "friday";
            if (j >= 55 && j <= 62) return "saturday";
            return null;
        }
    }
}
