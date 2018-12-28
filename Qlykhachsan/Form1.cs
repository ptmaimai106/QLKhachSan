using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PDangNhap.Hide();
            panelDK.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var view = new LeTan();
            view.ShowDialog();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            Button btn = new Button();
            PDangNhap.Controls.Add(btn);
            panelDK.Hide();
            PDangNhap.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var a = new LeTan();
            a.ShowDialog();

           // SqlConnection conn = new SqlConnection();

        }

        private void PDangNhap_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            panelDK.Controls.Add(btn);
            PDangNhap.Hide();
            panelDK.Show();
        }
    }
   
}
