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
using Excel = Microsoft.Office.Interop.Excel;

namespace FinalProDoctor
{
    public partial class Sign : Form
    {
        public Sign()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkName(textBox1.Text)== false){
                textBox4.Text = "The user Name is incorrect";
                return;
            }
            if (checkPassword(textBox2.Text) == false){
                textBox4.Text = "The Password must be between 8 and 10 characters, to Contains at least one letter, one digit and one special character (!,#,$, etc.).";
                return;
            }
            if (checkId(textBox3.Text) == false){
                textBox4.Text = "The id number is incorrect";
                return;
            }
            textBox4.Text = "";
            excelWriting();

            Form1 start = new Form1();
            this.Hide();
            start.ShowDialog();
            this.Close();

        }

        public void excelWriting()
        {
            Excel.Application excel = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            //string excelFile = @"C:\Users\Tomer\OneDrive\Desktop\user.xls";
            string currentDir = System.IO.Directory.GetCurrentDirectory() + "\\user.xls";
            string excelFile = @currentDir;
            try
            {
                if (!File.Exists(excelFile))
                {
                    Excel.Application myexcelApplication = new Excel.Application();
                    Excel.Workbook myexcelWorkbook = myexcelApplication.Workbooks.Add();
                    Excel.Worksheet myexcelWorksheet = (Excel.Worksheet)myexcelWorkbook.Sheets.Add();

                    myexcelWorksheet.Cells[1, 1] = "id";
                    myexcelWorksheet.Cells[1, 2] = "user firstName";
                    myexcelWorksheet.Cells[1, 3] = "password";
                    myexcelApplication.ActiveWorkbook.SaveAs(excelFile, Excel.XlFileFormat.xlWorkbookNormal);
                    myexcelWorkbook.Close();
                    myexcelApplication.Quit();
                }

                excel = new Excel.Application { Visible = true, DisplayAlerts = false };

                workbook = excel.Workbooks.Open(excelFile);
                worksheet = (Excel.Worksheet) workbook.Worksheets[1];

                int newRow = worksheet.Range["A" + worksheet.Rows.Count, Type.Missing]
                                      .End[Excel.XlDirection.xlUp].Row + 1;

                // Fill you cells
                worksheet.Cells[newRow, 1] = textBox3.Text;
                worksheet.Cells[newRow, 2] = textBox1.Text;
                worksheet.Cells[newRow, 3] = textBox2.Text;

                // Save changes
                workbook.Save();
            }
            catch (Exception ex) // Or System.Runtime.InteropServices.COMException
            {
                // Handle it or log or do nothing
            }
            finally
            {
                // Close Book and Excel and release COM Object
                workbook?.Close(0);
                excel?.Quit();
            }


        }

        bool checkName(string userName)
        {
            int count = 0, checkChar = 0;
            if (userName.Length < 6 || userName.Length > 8)
                return false;
            for (int i =0; i< userName.Length; i++)
            {
                if ((userName[i] >= '0' && userName[i] <= '9'))
                    count++;
                if ((userName[i] >= 'A' && userName[i] <= 'Z') || (userName[i] >= 'a' && userName[i] <= 'z'))
                    checkChar++;
            }
            if (count > 2)
                return false;

            if ((count+checkChar) != userName.Length)
                return false;

            return true;
        }

        bool checkPassword(string PassWord)
        {
            int count = 0, specialChar = 0,checknum = 0;
            if (PassWord.Length < 8 || PassWord.Length > 10)
                return false;
            for (int i = 0; i < PassWord.Length; i++)
            {
                if ((PassWord[i] >= 'A' && PassWord[i] <= 'Z') || (PassWord[i] >= 'a' && PassWord[i] <= 'z'))
                    count++;
                if ((!Char.IsLetterOrDigit(PassWord[i]) && (!PassWord[i].Equals(" "))))
                    specialChar++;
                if (PassWord[i] >= '0' && PassWord[i] <= '9')
                    checknum++;
            }
            if (count < 1)
                return false;
            if (specialChar < 1)
                return false;
            if (checknum < 1)
                return false;
            if ((count+ specialChar+ checknum) != PassWord.Length)
                return false;
            return true;
        }
        bool checkId(string idcheck)
        {
            if (idcheck.Length != 8)
                return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1_place = new Form1();
            this.Hide();
            form1_place.ShowDialog();
            this.Close();
        }
    }
}
