using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace WindowsFormsApp1
{
    class Data
    {
        

        SqlConnection sqlCon;
        DataTable dtTable;
        SqlCommand sqlCmd;
        string conStr;
      
        Data()
        {
            conStr = @"Data Source=HOANGHOAINHI\SQLEXPRESS;Initial Catalog=QLkhachsan;Integrated Security=True";

            sqlCon = new SqlConnection();
            sqlCon.ConnectionString = conStr;
           
        }

        public void readData(String Name)
        {
            //connectDatabase();
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(Name, sqlCon);

            dtTable = new DataTable();
            sqlDa.Fill(dtTable);

            sqlCon.Close();
        }

        private void DV_HoanThanh()
        {
            sqlCon.Open();

            sqlCmd = new SqlCommand("INSERT INTO PHIEUDICHVU (MAPHIEUDICHVU,  MAPHIEUTHUE, MADICHVU,SOLUONG, THANHTIEN ) VALUES (@MAPHIEUDICHVU,  @MAPHIEUTHUE, @MADICHVU, @SOLUONG, @THANHTIEN)", sqlCon);

         /*   sqlCmd.Parameters.Add("@MAPHIEUTHUE", DV_MaPhieu.Text.ToString());
            sqlCmd.Parameters.Add("@MADICHVU", "OTHERS");
            sqlCmd.Parameters.Add("@SOLUONG", DV_Soluong.Value);
            sqlCmd.Parameters.Add("@THANHTIEN", GiaTien);
*/

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        public void writeData(String Type)
        {
            if(Type == "DV_HoanThanh")
            {
                DV_HoanThanh();
            }
        } 
    }
}
