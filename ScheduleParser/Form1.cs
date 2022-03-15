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

namespace ScheduleParser
{
    public partial class Form1 : Form
    {
        Excel.Application App;
        Excel.Workbook Workbook;
        Excel.Worksheet Worksheet;
        Faculty Faculty;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            App = new Excel.Application();
            Workbook = App.Workbooks.Open("D:/ПМ-2021/Stas Butov/ScheduleParser/ScheduleParser/bin/Debug/schedule1.xlsm");
            Worksheet = Workbook.Sheets[1];

            Faculty = new Faculty();
        }
    }
}
