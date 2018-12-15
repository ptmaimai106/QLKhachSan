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
using System.Data.OleDb;

namespace QLKhachSan
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
           
        }

        SqlConnection sqlCon;

      //  DataTable dtTable;
      //  SqlCommand sqlCmd;
        DangNhap dangNhap_userControl;
        Thoat Thoat;


        string conStr = "LAPTOP-S2H4E83U/SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

        void connectDatabase()
        {
            sqlCon = new SqlConnection();
            sqlCon.ConnectionString = conStr;
            sqlCon.Open();
        }
        private void dangNhap_Click(object sender, EventArgs e)
        {

            dangNhap_userControl = new DangNhap();
            dangNhap_userControl.Dock = DockStyle.Fill;
            this.Controls.Add(dangNhap_userControl);
           // if(dangNhap_userControl.)
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            Thoat = new Thoat();
            Thoat.Dock = DockStyle.Fill;
            this.Controls.Add(Thoat);
          
        }
    }
}
