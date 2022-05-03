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
    }
}
