using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            /*            //int password;
                        //textBox1.Text = "";
                        //textBox2.Text = "";
                        if (textBox1.Text == "natlia")
                        {
                            textBox3.Text = "The user name is incorrect" ;
                            return;
                        }

                        if (Int32.Parse(textBox2.Text) > 3000)
                        {
                            textBox3.Text = "The password is incorrect";
                            return;
                        }

                        *//*
                        Read from the file.
                        *//*

                        textBox3.Clear();
                        textBox1.Clear();
                        textBox2.Clear();*/
            Medical start = new Medical();
            this.Hide();
            start.ShowDialog();
            this.Close();

        }

    }
    public class Patient
    {
        public string name;
        public int age;
        public string sex;
        public bool smoke;
        public int high;
        public int weight;
        public string origin;

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


        public Patient(string name, int age, string sex, bool smoke, int high, int weight,string origin)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
            this.smoke = smoke;
            this.high = high;
            this.weight = weight;
            this.origin = origin;
        }
        public Patient()
        {
            this.name = "no name";
            this.age = -1;
            this.sex = "";
            this.smoke = false;
            this.high = -1;
            this.weight = -1;
            this.origin = "no origin";
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
    }

}
