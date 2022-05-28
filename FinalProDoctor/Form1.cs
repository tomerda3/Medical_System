using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinalProDoctor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sign start = new Sign();
            this.Hide();
            start.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int password;
            //textBox1.Text = "";
            //textBox2.Text = "";

            

            Excel.Application excel = null;
            excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook wkb = null;
            string currentDir = System.IO.Directory.GetCurrentDirectory() + "\\user.xls";
            string excelFile = @currentDir;
            wkb = Open(excel, excelFile);
            Excel.Range searchedRangeUserName = excel.get_Range("B1", "B12");
            Excel.Range searchedRangePassword = excel.get_Range("C1", "C12");
            string user_name = textBox1.Text;
            string passwordU = textBox2.Text;
            Excel.Range currentFindUserName = searchedRangeUserName.Find(user_name);
            Excel.Range currentFindPass = searchedRangePassword.Find(passwordU);
            wkb.Close(true);
            excel.Quit();

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                textBox3.Text = "The input is empty";
                return;
            }


            if (currentFindUserName == null || currentFindPass == null)
            {

                try
                {
                    // Check here the user firstName is correct.
                    if (currentFindUserName == null)
                    {
                        textBox3.Text = "The user firstName is incorrect";
                        return;
                    }

                    // Check here if the password is correct.
                    if (currentFindPass == null)
                    {
                        textBox3.Text = "The password is incorrect";
                        return;
                    }

                }
                catch (FormatException e1)
                {
                    textBox3.Text = "There is a problem in the input";
                    return;
                }

            }
            else
            {

                textBox3.Clear();
                textBox1.Clear();
                textBox2.Clear();
                Medical start = new Medical();
                this.Hide();
                start.ShowDialog();
                this.Close();
            }


        }
        public static Excel.Workbook Open(Excel.Application excelInstance,
                       string fileName, bool readOnly = false, bool editable = true,
                       bool updateLinks = true)
        {
            try
            {
                Excel.Workbook book = excelInstance.Workbooks.Open(
                fileName, updateLinks, readOnly,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
                return book;
            }

            catch (System.Runtime.InteropServices.COMException e1)
            {
                MessageBox.Show("The file is open elsewhere");
            }

            return null;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1_place = new Form1();
            this.Hide();
            form1_place.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
    public class Patient
    {
        public string firstName;
        public string lastName;
        public int age;
        public string sex;
        public bool smoke;
        public float high;
        public float weight;
        public int origin;
        public string co;
        public string id;
        public bool pregpregnant;
        public bool takedrugs;


        public float WBC =0;
        public float Neut =0;
        public float Lymph =0;
        public float RBC =0;
        public float HCT =0;
        public float Urea =0;
        public float Hb =0;
        public float Crtn =0;
        public float Iron =0;
        public float HDL = 0;
        public float AP = 0;
        public string di = null;
        public string se = null;

        public Patient(string firstName,string lastName, int age, string sex, bool smoke, float high, float weight,int origin, bool pregpregnant, bool takedrugs, string id)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.sex = sex;
            this.smoke = smoke;
            this.high = high;
            this.weight = weight;
            this.origin = origin;
            this.id = id;
            this.pregpregnant = pregpregnant;
            this.takedrugs = takedrugs;

        }
        public Patient()
        {
            this.firstName = "no firstName";
            this.lastName = "no lastname";
            this.age = -1;
            this.sex = "";
            this.smoke = false;
            this.high = -1;
            this.weight = -1;
            this.origin = -1;
            this.id = "00000000";
            this.pregpregnant = false;
            this.takedrugs = false;
        }
        public void setBloodTest(float WBC, float Neut, float Lymph, float RBC, float HCT, float Urea, float Hb, float Crtn, float Iron, float HDL, float AP)
        {
            this.WBC = WBC;
            this.Neut = Neut;
            this.Lymph = Lymph;
            this.RBC = RBC;
            this.HCT = HCT;
            this.Urea = Urea;
            this.Hb = Hb;
            this.Crtn = Crtn;
            this.Iron = Iron;
            this.HDL = HDL;
            this.AP = AP;
        }
        public void setdi(string other)
        {
            this.di = other;
        }
        public void setse(string other)
        {
            this.se = other;
        }
    }

}
