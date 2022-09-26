using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using ScheduleModels;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;
using iText.Kernel;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Kernel.Pdf;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using System.Net;
using MySql.Data.MySqlClient;

namespace ScheduleParser
{
    public partial class FormMain : Form
    {
        Excel.Application ExcelApp;
        Excel.Workbook Workbook;
        Excel.Worksheet Worksheet;
        Faculty Faculty;
        Group Group;
        Couple Couple;
        string PathToSchedule;
        public Dictionary<string, List<TeacherCouple>> TeacherCouplesPairs =
            new Dictionary<string, List<TeacherCouple>>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void SerializeSchedule()
        {
            JObject json = JObject.Parse(JsonConvert.SerializeObject(Faculty));
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\Schedule.json", json.ToString());
            MessageBox.Show("Расписание загружено");
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
                        if (cell1.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle
                            == (int)Excel.XlLineStyle.xlContinuous) continue;
                        //if (!(Worksheet.Cells[rowIndex + 1, columnIndex].Text.ToString() == "" 
                        //    || Worksheet.Cells[rowIndex + 1, columnIndex].Text.ToString() == " "))
                        //    continue;

                        Couple tempCouple = new Couple
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
                        Group.Couples.Add(tempCouple);
                    }
                }
            }
        }

        private void DefineNameTeacherAndAud(string fullCoupleName)
        {
            var coupleName = "";
            var dif = 0;
            for (int i = 0; i < fullCoupleName.Length; i++)
            {
                if (fullCoupleName[i] == ',')
                {
                    dif++;
                    continue;
                }
                coupleName += fullCoupleName[i];
                if (fullCoupleName[i] == ')')
                {
                    Couple.CoupleName = coupleName.Trim();
                    break;
                }
            }

            var teacherAndAud = fullCoupleName.Substring(coupleName.Length + dif);
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
            else if (rowIndex >= 23 && rowIndex <= 30) Couple.Day = "tuesday";
            else if (rowIndex >= 31 && rowIndex <= 38) Couple.Day = "wednesday";
            else if (rowIndex >= 39 && rowIndex <= 46) Couple.Day = "thursday";
            else if (rowIndex >= 47 && rowIndex <= 54) Couple.Day = "friday";
            else if (rowIndex >= 55 && rowIndex <= 62) Couple.Day = "saturday";
        }

        private void ScanTeachers()
        {
            List<string> teachers = CreateTeacherList();

            comboBoxChooseTeacher.Items.AddRange(teachers.ToArray());
            comboBoxChooseTeacher.Enabled = true;
        }

        public List<string> CreateTeacherList()
        {
            comboBoxChooseTeacher.Items.Clear();
            Faculty fac = JsonConvert.DeserializeObject<Faculty>(File.ReadAllText(
                Directory.GetCurrentDirectory() + @"\Schedule.json"));
            List<string> teachers = new List<string>();
            foreach (var group in fac.Groups)
                foreach (var couple in group.Couples)
                    if (!teachers.Contains(couple.CoupleTeacher.Trim()))
                        teachers.Add(couple.CoupleTeacher.Trim());
            return teachers;
        }

        private void comboBoxChooseTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewTeacherSchedule.Rows.Clear();
            var teacher = comboBoxChooseTeacher.Text;
            List<TeacherCouple> teacherCouples = TeacherCouplesPairs[teacher];

            DrawTeacherSchedule(teacherCouples);
        }

        private List<TeacherCouple> DeleteExtraCouples(List<TeacherCouple> teacherCouples)
        {
            List<TeacherCouple> newCouples = new List<TeacherCouple>();
            TeacherCouple couple = new TeacherCouple();
            for (int i = 0; i < teacherCouples.Count; i++)
            {
                if (i != 0 && teacherCouples[i].Day == teacherCouples[i - 1].Day)
                {
                    couple.Day = teacherCouples[i].Day;
                    if (teacherCouples[i].CoupleNum == teacherCouples[i - 1].CoupleNum)
                    {
                        if (teacherCouples[i].CoupleName == teacherCouples[i - 1].CoupleName)
                        {
                            couple.CoupleNum = teacherCouples[i - 1].CoupleNum;
                            couple.Week += couple.Week.Contains(teacherCouples[i - 1].Week) ? "" : " " + teacherCouples[i - 1].Week;
                            couple.GroupId += couple.GroupId.Contains(teacherCouples[i - 1].GroupId) ? "" : " " + teacherCouples[i - 1].GroupId;
                            couple.SubgroupId += couple.SubgroupId.Contains(teacherCouples[i - 1].SubgroupId) ? "" : " " + teacherCouples[i - 1].SubgroupId;
                            couple.TimeBegin = teacherCouples[i - 1].TimeBegin;
                            couple.TimeEnd = teacherCouples[i - 1].TimeEnd;
                            couple.CoupleName = teacherCouples[i - 1].CoupleName;
                            couple.CoupleAud = teacherCouples[i - 1].CoupleAud;

                            if (teacherCouples[i].Week == teacherCouples[i - 1].Week)
                            {
                                couple.CoupleNum = teacherCouples[i].CoupleNum;
                                couple.Week += couple.Week.Contains(teacherCouples[i].Week) ? "" : " " + teacherCouples[i].Week;
                                couple.GroupId += couple.GroupId.Contains(teacherCouples[i].GroupId) ? "" : " " + teacherCouples[i].GroupId;
                                couple.SubgroupId += couple.SubgroupId.Contains(teacherCouples[i].SubgroupId) ? "" : " " + teacherCouples[i].SubgroupId;
                                couple.TimeBegin = teacherCouples[i].TimeBegin;
                                couple.TimeEnd = teacherCouples[i].TimeEnd;
                                couple.CoupleName = teacherCouples[i].CoupleName;
                                couple.CoupleAud = teacherCouples[i].CoupleAud;
                            }
                        }
                        else
                        {
                            MergeWeeksAndSubgroups(couple);
                            newCouples.Add(couple);
                            couple = new TeacherCouple();
                        }
                    }
                    else
                    {
                        couple.CoupleNum = teacherCouples[i - 1].CoupleNum;
                        couple.Week += couple.Week.Contains(teacherCouples[i - 1].Week) ? "" : " " + teacherCouples[i - 1].Week;
                        couple.GroupId += couple.GroupId.Contains(teacherCouples[i - 1].GroupId) ? "" : " " + teacherCouples[i - 1].GroupId;
                        couple.SubgroupId += couple.SubgroupId.Contains(teacherCouples[i - 1].SubgroupId) ? "" : " " + teacherCouples[i - 1].SubgroupId;
                        couple.TimeBegin = teacherCouples[i - 1].TimeBegin;
                        couple.TimeEnd = teacherCouples[i - 1].TimeEnd;
                        couple.CoupleName = teacherCouples[i - 1].CoupleName;
                        couple.CoupleAud = teacherCouples[i - 1].CoupleAud;

                        MergeWeeksAndSubgroups(couple);
                        newCouples.Add(couple);
                        couple = new TeacherCouple();
                    }
                }
                else if (i != 0)
                {
                    couple.Day = teacherCouples[i - 1].Day;
                    couple.CoupleNum = teacherCouples[i - 1].CoupleNum;
                    couple.Week += couple.Week.Contains(teacherCouples[i - 1].Week) ? "" : " " + teacherCouples[i - 1].Week;
                    couple.GroupId += couple.GroupId.Contains(teacherCouples[i - 1].GroupId) ? "" : " " + teacherCouples[i - 1].GroupId;
                    couple.SubgroupId += couple.SubgroupId.Contains(teacherCouples[i - 1].SubgroupId) ? "" : " " + teacherCouples[i - 1].SubgroupId;
                    couple.TimeBegin = teacherCouples[i - 1].TimeBegin;
                    couple.TimeEnd = teacherCouples[i - 1].TimeEnd;
                    couple.CoupleName = teacherCouples[i - 1].CoupleName;
                    couple.CoupleAud = teacherCouples[i - 1].CoupleAud;

                    MergeWeeksAndSubgroups(couple);
                    newCouples.Add(couple);
                    couple = new TeacherCouple();
                }
                if (i == teacherCouples.Count - 1)
                {
                    couple.CoupleNum = teacherCouples[i].CoupleNum;
                    couple.Week += couple.Week.Contains(teacherCouples[i].Week) ? "" : " " + teacherCouples[i].Week;
                    couple.GroupId += couple.GroupId.Contains(teacherCouples[i].GroupId) ? "" : " " + teacherCouples[i].GroupId;
                    couple.SubgroupId += couple.SubgroupId.Contains(teacherCouples[i].SubgroupId) ? "" : " " + teacherCouples[i].SubgroupId;
                    couple.TimeBegin = teacherCouples[i].TimeBegin;
                    couple.TimeEnd = teacherCouples[i].TimeEnd;
                    couple.CoupleName = teacherCouples[i].CoupleName;
                    couple.CoupleAud = teacherCouples[i].CoupleAud;

                    MergeWeeksAndSubgroups(couple);
                    newCouples.Add(couple);
                }

            }
            return newCouples;
        }

        private void MergeWeeksAndSubgroups(TeacherCouple couple)
        {
            if (couple.Week.Contains("1") && couple.Week.Contains("2"))
                couple.Week = "Еженедельно";
            if (couple.SubgroupId.Contains("1") && couple.SubgroupId.Contains("2"))
                couple.SubgroupId = "-";
        }

        private void DrawTeacherSchedule(List<TeacherCouple> teacherCouples)
        {
            for (int i = 0; i < teacherCouples.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                dataGridViewTeacherSchedule.Rows.Add(row);
                row = dataGridViewTeacherSchedule.Rows[i];
                row.Cells[0].Value = TranslateDay(teacherCouples[i].Day.ToString());
                row.Cells[1].Value = teacherCouples[i].CoupleNum;
                row.Cells[2].Value = teacherCouples[i].Week;
                row.Cells[3].Value = teacherCouples[i].GroupId;
                row.Cells[4].Value = teacherCouples[i].SubgroupId;
                row.Cells[5].Value = teacherCouples[i].TimeBegin + " - " + teacherCouples[i].TimeEnd;
                row.Cells[6].Value = teacherCouples[i].CoupleName;
                row.Cells[7].Value = teacherCouples[i].CoupleAud;
            }
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            WindowState = FormWindowState.Maximized;

            string pathToDateFile = Directory.GetCurrentDirectory() + @"\Date of last update.dat";
            if (!File.Exists(pathToDateFile))
                File.WriteAllText(pathToDateFile, "Расписание ещё не загружалось");

            dataGridViewTeacherSchedule.AutoGenerateColumns = false;
            labelLastRenew.Text = File.ReadAllText(pathToDateFile);

            if (File.Exists(Directory.GetCurrentDirectory() + @"\Schedule.json"))
            {
                ScanTeachers();
                GetTeacherCouplesPairs();
            }
        }

        private void GetTeacherCouplesPairs()
        {
            Faculty facultyToRead = JsonConvert.DeserializeObject<Faculty>(File.ReadAllText(
                Directory.GetCurrentDirectory() + @"\Schedule.json"));
            List<TeacherCouple> teacherCouples = new List<TeacherCouple>();
            foreach (string teacher in comboBoxChooseTeacher.Items)
            {
                foreach (var group in facultyToRead.Groups)
                    foreach (var couple in group.Couples)
                        if (couple.CoupleTeacher == teacher)
                            teacherCouples.Add(new TeacherCouple(couple, group.GroupId));

                teacherCouples = teacherCouples.OrderBy(x => x.Day).ThenBy(x => x.CoupleNum)
                    .ThenBy(x => x.Week).ThenBy(x => x.GroupId).ToList();
                teacherCouples = DeleteExtraCouples(teacherCouples);

                TeacherCouplesPairs.Add(teacher, teacherCouples);
                teacherCouples = new List<TeacherCouple>();
            }
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
            if (e.ColumnIndex == 0)
            {
                if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Top = dataGridViewTeacherSchedule.AdvancedCellBorderStyle.Top;
                }
            }
            else
            {
                if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && IsTheSameCellValue(0, e.RowIndex)
                && IsTheSameCellValue(1, e.RowIndex))
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Top = dataGridViewTeacherSchedule.AdvancedCellBorderStyle.Top;
                }
            }
        }

        private void dataGridViewTeacherSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (e.ColumnIndex == 0)
            {
                if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
            else
            {
                if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && IsTheSameCellValue(0, e.RowIndex)
                    && IsTheSameCellValue(1, e.RowIndex))
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }

        private void LoadScheduleMenuItem_Click(object sender, EventArgs e)
        {
            TeacherCouplesPairs = new Dictionary<string, List<TeacherCouple>>();
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Excel Files|*.xlsx;*.xls;*.xlsm"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                PathToSchedule = fileDialog.FileName;
                MessageBox.Show("За ходом операции можно наблюдать в правом верхнем углу",
                    "Расписание загружается");
                GetSchedule();
                GetTeacherCouplesPairs();
            }

            //MySqlConnection mySqlConnection = GetDBConnection("a41035.mysql.mchost.ru", "a41035_1", "a41035_1", "Math535130");
            //mySqlConnection.Open();
            //SendScheduleToServer();
            //mySqlConnection.Close();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendScheduleToServer()
        {
            string json = File.ReadAllText(Directory.GetCurrentDirectory() + @"\Schedule.json");

            string url = @"http://math.nosu.ru/schedule/getAnswer.php";
            string postParameters = "name=updateFacultyMain&json=" + json;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postParameters);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = byteArray.Length;
            using (var writer = httpWebRequest.GetRequestStream())
            {
                writer.Write(byteArray, 0, byteArray.Length);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result);
            }
        }

        public static MySqlConnection GetDBConnection(string host,/* int port, */string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
            + /*";port=" + port + */";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public List<TeacherCouple> CreateCoupleListForChosenTeacher(string teacher)
        {
            // Creating a list of chosen teacher couples
            Faculty facultyToRead = JsonConvert.DeserializeObject<Faculty>(File.ReadAllText(
                Directory.GetCurrentDirectory() + @"\Schedule.json"));
            List<TeacherCouple> teacherCouples = new List<TeacherCouple>();
            foreach (var group in facultyToRead.Groups)
                foreach (var couple in group.Couples)
                    if (couple.CoupleTeacher == teacher)
                        teacherCouples.Add(new TeacherCouple(couple, group.GroupId));

            teacherCouples = teacherCouples.OrderBy(x => x.Day).ThenBy(x => x.CoupleNum)
                .ThenBy(x => x.Week).ThenBy(x => x.GroupId).ToList();
            teacherCouples = DeleteExtraCouples(teacherCouples);
            return teacherCouples;
        }

        public void WriteToPDF(string fileName, List<TeacherCouple> teacherCouples)
        {
            // Creating a PdfWriter object
            PdfWriter writer = new PdfWriter(fileName);

            // Creating a PdfDocument object       
            PdfDocument pdfDoc = new PdfDocument(writer);

            // Creating a Document object      
            iText.Layout.Document doc = new Document(pdfDoc);

            // Creating a table
            Table table = new Table(dataGridViewTeacherSchedule.Columns.Count);

            // Creating a font
            iText.IO.Font.FontProgram fontProgram =
                iText.IO.Font.FontProgramFactory.CreateFont(@"C:\Windows\Fonts\arial.ttf");
            PdfFont font = PdfFontFactory.CreateFont(fontProgram);

            // Creating a header
            string headerText = "Расписание для преподавателя: " + comboBoxChooseTeacher.Text;
            Paragraph header = new Paragraph(headerText)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(15);
            header.SetFont(font);
            doc.Add(header);

            // Adding headers for the table
            for (int i = 0; i < dataGridViewTeacherSchedule.Columns.Count; i++)
            {
                Cell cell = new Cell();
                cell.Add(new Paragraph(dataGridViewTeacherSchedule.Columns[i].HeaderText));
                cell.SetFont(font);
                cell.SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                cell.SetTextAlignment(TextAlignment.CENTER);
                cell.SetFontSize(9);
                table.AddCell(cell);
            }

            // Adding all the over cells
            for (int i = 0; i < teacherCouples.Count; i++)
            {
                bool flag = i != 0 && teacherCouples[i].Day == teacherCouples[i - 1].Day;
                Cell cell = new Cell();
                string cellText = flag ? "" : TranslateDay(teacherCouples[i].Day.ToString());
                cell.Add(new Paragraph(cellText));
                cell.SetFont(font);
                cell.SetBorderBottom(Border.NO_BORDER);
                if (flag) cell.SetBorderTop(Border.NO_BORDER);
                cell.SetTextAlignment(TextAlignment.CENTER);
                cell.SetFontSize(9);
                table.AddCell(cell);

                flag = i != 0 && teacherCouples[i].CoupleNum == teacherCouples[i - 1].CoupleNum
                    && teacherCouples[i].Day == teacherCouples[i - 1].Day;
                cell = new Cell();
                cellText = flag ? "" : teacherCouples[i].CoupleNum;
                cell.Add(new Paragraph(cellText));
                cell.SetFont(font);
                cell.SetBorderBottom(Border.NO_BORDER);
                if (flag) cell.SetBorderTop(Border.NO_BORDER);
                cell.SetTextAlignment(TextAlignment.CENTER);
                cell.SetFontSize(9);
                table.AddCell(cell);

                flag = i != 0 && teacherCouples[i].Week == teacherCouples[i - 1].Week
                    && teacherCouples[i].Day == teacherCouples[i - 1].Day;
                cell = new Cell();
                cellText = /*flag ? "" : */teacherCouples[i].Week;
                cell.Add(new Paragraph(cellText));
                cell.SetFont(font);
                //cell.SetBorderBottom(Border.NO_BORDER);
                //if (flag) cell.SetBorderTop(Border.NO_BORDER);
                cell.SetTextAlignment(TextAlignment.CENTER);
                cell.SetFontSize(9);
                table.AddCell(cell);

                flag = i != 0 && teacherCouples[i].GroupId == teacherCouples[i - 1].GroupId
                    && teacherCouples[i].Day == teacherCouples[i - 1].Day;
                cell = new Cell();
                cellText = flag ? "" : teacherCouples[i].GroupId;
                cell.Add(new Paragraph(cellText));
                cell.SetFont(font);
                cell.SetBorderBottom(Border.NO_BORDER);
                if (flag) cell.SetBorderTop(Border.NO_BORDER);
                cell.SetTextAlignment(TextAlignment.CENTER);
                cell.SetFontSize(9);
                table.AddCell(cell);

                flag = i != 0 && teacherCouples[i].SubgroupId == teacherCouples[i - 1].SubgroupId
                    && teacherCouples[i].Day == teacherCouples[i - 1].Day;
                cell = new Cell();
                cellText = /*flag ? "" : */teacherCouples[i].SubgroupId;
                cell.Add(new Paragraph(cellText));
                cell.SetFont(font);
                //cell.SetBorderBottom(Border.NO_BORDER);
                //if (flag) cell.SetBorderTop(Border.NO_BORDER);
                cell.SetTextAlignment(TextAlignment.CENTER);
                cell.SetFontSize(9);
                table.AddCell(cell);

                flag = i != 0 && teacherCouples[i].TimeBegin == teacherCouples[i - 1].TimeBegin
                    && teacherCouples[i].Day == teacherCouples[i - 1].Day;
                cell = new Cell();
                cellText = flag ? "" : teacherCouples[i].TimeBegin + " - " + teacherCouples[i].TimeEnd;
                cell.Add(new Paragraph(cellText));
                cell.SetFont(font);
                cell.SetBorderBottom(Border.NO_BORDER);
                if (flag) cell.SetBorderTop(Border.NO_BORDER);
                cell.SetTextAlignment(TextAlignment.CENTER);
                cell.SetFontSize(9);
                table.AddCell(cell);

                flag = i != 0 && teacherCouples[i].CoupleName == teacherCouples[i - 1].CoupleName
                    && teacherCouples[i].Day == teacherCouples[i - 1].Day;
                cell = new Cell();
                cellText = flag ? "" : teacherCouples[i].CoupleName;
                cell.Add(new Paragraph(cellText));
                cell.SetFont(font);
                cell.SetBorderBottom(Border.NO_BORDER);
                if (flag) cell.SetBorderTop(Border.NO_BORDER);
                cell.SetTextAlignment(TextAlignment.CENTER);
                cell.SetFontSize(9);
                table.AddCell(cell);

                flag = i != 0 && teacherCouples[i].CoupleAud == teacherCouples[i - 1].CoupleAud
                    && teacherCouples[i].Day == teacherCouples[i - 1].Day;
                cell = new Cell();
                cellText = flag ? "" : teacherCouples[i].CoupleAud;
                cell.Add(new Paragraph(cellText));
                cell.SetFont(font);
                cell.SetBorderBottom(Border.NO_BORDER);
                if (flag) cell.SetBorderTop(Border.NO_BORDER);
                cell.SetTextAlignment(TextAlignment.CENTER);
                cell.SetFontSize(9);
                table.AddCell(cell);
            }

            // Adding Table to document
            table.SetBorder(new SolidBorder(0.5f));
            doc.Add(table);

            // Closing the document       
            doc.Close();


        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.Show();
        }

        private void ExportScheduleForOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Pdf Files|*.pdf",
                FileName = "Расписание для преподавателя " + comboBoxChooseTeacher.Text
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            var fileName = saveFileDialog.FileName;

            var teacher = comboBoxChooseTeacher.Text;
            List<TeacherCouple> teacherCouples = CreateCoupleListForChosenTeacher(teacher);

            WriteToPDF(fileName, teacherCouples);
            MessageBox.Show("Pdf-документ сохранен");
        }

        private void ExportScheduleForSeveralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChooseTeachers form = new FormChooseTeachers();
            form.Show();
        }

        private void ExportTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Книга Excel|*.xlsx",
                FileName = "123"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            var fileName = saveFileDialog.FileName;

            //Копируем шаблон по выбранному пути
            ExcelApp = new Excel.Application();            
            Workbook = ExcelApp.Workbooks.Open(@"C:\Users\Stanislav\Desktop\ScheduleParser-main\ScheduleParser\bin\Debug\TableTemplate.xlsx");
            Workbook.SaveCopyAs(fileName);
            Workbook.Close();

            //Открывем и работаем со скопированным файлом
            Workbook = ExcelApp.Workbooks.Open(fileName);
            Worksheet = Workbook.Sheets[1];

            //Worksheet.Cells[6, "D"] = "hey";
            for (int i = 0; i < comboBoxChooseTeacher.Items.Count; i++)
            {
                Worksheet.Cells[2, i + 3] = comboBoxChooseTeacher.Items[i];
                List<TeacherCouple> teacherCouples = CreateCoupleListForChosenTeacher(comboBoxChooseTeacher.Items[i].ToString());
                for (int j = 3; j <= 24; j++)
                {
                    foreach (var couple in teacherCouples)
                    {
                        //Worksheet.Cells[j, i + 3] = "bla";
                        var shit = TranslateDay(couple.Day.ToString());
                        var shit1 = Worksheet.Cells[j, 2].Text.ToString();
                        var shit2 = couple.CoupleNum;
                        var shit3 = Worksheet.Cells[j, 1].Text.ToString();
                        if (shit == shit1
                            && shit2 == shit3)
                        {
                            Worksheet.Cells[j, i + 3] = couple.CoupleName + ", неделя: " + couple.Week;
                        }
                    }
                }
            }

            //Сохраняем файл после работы
            ExcelApp.Visible = true;
            Workbook.Save();
            //ExcelApp.Quit();
        }
    }
}