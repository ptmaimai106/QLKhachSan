using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.OleDb;

namespace QLKhachSan
{

    public partial class DangNhap : UserControl 
    {
        SqlConnection sqlCon;

       //   DataTable dtTable;
          SqlCommand sqlCmd;


        string conStr = @"Data Source=LAPTOP-S2H4E83U\SQLEXPRESS;Initial Catalog=quanlykhachsan123;Integrated Security=True";

        void connectDatabase()
        {
            sqlCon = new SqlConnection();
            sqlCon.ConnectionString = conStr;
            sqlCon.Open();
        }

        public DangNhap()
        {
            InitializeComponent();
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dn_Click(object sender, EventArgs e)
        {
            connectDatabase();

            sqlCmd = new SqlCommand("SELECT MANHANVIEN FROM NHANVIEN", sqlCon);

            SqlDataReader Reader = sqlCmd.ExecuteReader();

            if (Reader.HasRows)
            {

                while (Reader.Read())
                {
                    if (Reader[0].ToString() != "" && this.maNV.Text == Reader[0].ToString())
                    {
                        if (Reader[0].ToString().StartsWith("LT"))
                        {

                            sqlCon.Close();
                            LeTan letan = new LeTan();
                            letan.Show();

                            break;
                        
                        }
                    }
                }
                Home home = (Home)this.Parent;

                home.Close();
            }

        }
    }
}
