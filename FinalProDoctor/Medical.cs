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
    public partial class Medical : Form
    {
        public Medical()
        {
            InitializeComponent();
        }
        Patient patient1 = null;
        private void button7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Medical_Load(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            float WBC=0;
            float Neut = 0;
            float Lymph = 0;
            float RBC = 0;
            float HCT = 0;
            float Urea = 0;
            float Hb = 0;
            float Crtn = 0;
            float Iron = 0;
            float HDL = 0;
            float AP = 0;

            textBox5.Text = "";
            chart1.Titles.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            if (WBCBox.Text == "")
            {

            }
            else
            {
                try
                {
                    WBC = float.Parse(WBCBox.Text);
                    Neut = float.Parse(NeutBox.Text); 
                    Lymph = float.Parse(LymphBox.Text);
                    RBC = float.Parse(RBCBox.Text);
                    HCT = float.Parse(HCTBox.Text);
                    Urea = float.Parse(UreaBox.Text); 
                    Hb = float.Parse(HbBox.Text); 
                    Crtn = float.Parse(CrtnBox.Text); 
                    Iron = float.Parse(IronBox.Text); 
                }

                catch (FormatException e1)
                {
                    textBox5.Text = "There is a problem in the input data";
                }

                string sex;
                if (checkBox1.Checked)
                    sex = "male";
                else sex = "female";
                
                patient1 = new Patient(textBox1.Text, Int32.Parse(textBox2.Text), sex, checkBox1.Checked, Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));
                patient1.setBloodTest(WBC, Neut, Lymph, RBC, HCT, Urea, Hb, Crtn, Iron, HDL,AP);
            }
            chart1.Series["BloodTest"].Points.AddXY("WBC", WBC);
            chart1.Series["BloodTest"].Points.AddXY("Neut", Neut);
            chart1.Series["BloodTest"].Points.AddXY("Lymph", Lymph);
            chart1.Series["BloodTest"].Points.AddXY("RBC", RBC);
            chart1.Series["BloodTest"].Points.AddXY("HCT", HCT);
            chart1.Series["BloodTest"].Points.AddXY("Urea", Urea);
            chart1.Series["BloodTest"].Points.AddXY("Hb", Hb);
            chart1.Series["BloodTest"].Points.AddXY("Crtn", Crtn);
            chart1.Series["BloodTest"].Points.AddXY("Iron", Iron);
            chart1.Series["BloodTest"].Points.AddXY("HDL", HDL);
            chart1.Series["BloodTest"].Points.AddXY("AP", AP);
            chart1.Titles.Add("BloodTest Result");
        }

        private void WBCBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (patient1 == null)
            {
                MessageBox.Show("There is not patient");
                return;
            }
            richTextBox1.AppendText("Examination for the patient: " + patient1.name +"\n");

            if (patient1.age >= 18)
                analysisForAdult();
            if (patient1.age <= 18 && patient1.age > 3)
                analysisForChildren();
            if (patient1.age <= 3)
                analysisForbaby();


        }
        public void analysisForAdult()
        {
            if(11000 > patient1.WBC)
            {

            }
            if (4500 < patient1.WBC)
            {

            }

            if (54 < patient1.Neut)
            {

            }

            if (28 < patient1.Neut)
            {

            }

            if (52 < patient1.Lymph)
            {

            }

            if (36 < patient1.Lymph)
            {

            }
            if (6 < patient1.Lymph)
            {

            }

            if (4.5 < patient1.Lymph)
            {

            }
            if (6 < patient1.HCT || 4 > patient1.HCT)
            {
                if(patient1.sex == "male")
                {
                    if (54 < patient1.Lymph)
                    {

                    }
                    if (37 > patient1.Lymph)
                    {

                    }
                }
                else
                {
                    if (47 < patient1.Lymph)
                    {

                    }
                    if (33 > patient1.Lymph)
                    {

                    }
                }
            }

            if (43 < patient1.Urea)
            {
                // add if mizrahi to aptient
            }
            if (17 > patient1.Urea)
            {
                // add if mizrahi to aptient
            }

        }
        public void analysisForChildren()
        {
            if (15500 > patient1.WBC)
            {

            }
            if (5500 < patient1.WBC)
            {

            }

            if (54 < patient1.Neut)
            {

            }

            if (28 < patient1.Neut)
            {

            }

            if (52 < patient1.Lymph)
            {

            }

            if (36 < patient1.Lymph)
            {

            }
            if (6 < patient1.Lymph)
            {

            }

            if (4.5 < patient1.Lymph)
            {

            }
            if (6 < patient1.HCT || 4 > patient1.HCT)
            {
                if (patient1.sex == "male")
                {
                    if (54 < patient1.Lymph)
                    {

                    }
                    if (37 > patient1.Lymph)
                    {

                    }
                }
                else
                {
                    if (47 < patient1.Lymph)
                    {

                    }
                    if (33 > patient1.Lymph)
                    {

                    }
                }
            }
            if (43 < patient1.Urea)
            {
                // add if mizrahi to aptient
            }
            if (17 > patient1.Urea)
            {
                // add if mizrahi to aptient
            }
            
        }
        public void analysisForbaby()
        {
            if (17500 > patient1.WBC)
            {

            }
            if (6000 < patient1.WBC)
            {

            }

            if (54 < patient1.Neut)
            {

            }

            if (28 < patient1.Neut)
            {

            }

            if (52 < patient1.Lymph)
            {

            }

            if (36 < patient1.Lymph)
            {

            }
            if (6 < patient1.Lymph)
            {

            }

            if (4.5 < patient1.Lymph)
            {

            }
            if (6 < patient1.HCT || 4 > patient1.HCT)
            {
                if (patient1.sex == "male")
                {
                    if (54 < patient1.Lymph)
                    {

                    }
                    if (37 > patient1.Lymph)
                    {

                    }
                }
                else
                {
                    if (47 < patient1.Lymph)
                    {

                    }
                    if (33 > patient1.Lymph)
                    {

                    }
                }
            }
            if (43 < patient1.Urea)
            {
                // add if mizrahi to aptient
            }
            if (17 > patient1.Urea)
            {
                // add if mizrahi to aptient
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void NeutBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void LymphBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void RBCBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void HCTBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void UreaBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void HbBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void CrtnBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void IronBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
