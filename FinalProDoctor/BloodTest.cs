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
    public partial class BloodTest : Form
    {
        public BloodTest()
        {
            InitializeComponent();
        }

        private void APBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            float WBC =0;
            float Neut =0;
            float Lymph =0;
            float RBC =0;
            float HCT =0;
            float Urea =0;
            float Hb =0;
            float Crtn =0;
            float Iron =0;
            float HDL =0;
            float AP =0;

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
                HDL = float.Parse(HDLBox.Text);
                AP = float.Parse(APBox.Text);

            }

            catch (FormatException e1)
            {
                textBox3.Text = "There is a problem in the input data";
                return;
            }

            Medical.instance.setBlood(WBC, Neut, Lymph, RBC, HCT, Urea, Hb, Crtn, Iron, HDL, AP);
            this.Hide();
/*            Medical start = new Medical();
            start.insertBlood(WBC, Neut, Lymph, RBC, HCT, Urea, Hb, Crtn, Iron, HDL, AP);
            this.Hide();
            this.Close();*/
        }
    }
    
}
