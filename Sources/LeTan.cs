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

namespace WindowsFormsApp1
{
    public partial class LeTan : Form
    {
        List<Panel> listPanel = new List<Panel>();


        SqlConnection sqlCon;
        DataTable dtTable;
        SqlCommand sqlCmd;

        string conStr = "LAPTOP-S2H4E83U/SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
  
        void connectDatabase() 
        {
            sqlCon = new SqlConnection();
            sqlCon.ConnectionString = conStr;
            sqlCon.Open();
        }

        public LeTan()
        {
            InitializeComponent();
            panelDP.Hide();
            panelNP.Hide();
            panelDV.Hide();
            panelHD.Hide();


            BringToFront();
        }

        private void NhanPhong_Click(object sender, EventArgs e)
        {
            Button btn = new Button();

           panelNP.Controls.Add(btn);
             panelDP.Hide();
            panelDV.Hide();
            panelHD.Hide();
            panelNP.Show();
            
          
        }

             

        private void HoaDon_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            panelHD.Controls.Add(btn);


            panelDP.Hide();
            panelNP.Hide();
            panelDV.Hide();
            panelHD.Show();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panelNP_Paint(object sender, PaintEventArgs e)
        {

        }

      


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param Dịch Vụ ="sender"></param>
        /// <param name="e"></param>

        DataGridViewRow Row;

        private void DichVu_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            panelDV.Controls.Add(btn);


            panelDP.Hide();
            panelNP.Hide();
            panelDV.Show();

            connectDatabase();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM DICHVU", sqlCon);

            dtTable = new DataTable();
            sqlDa.Fill(dtTable);
            DV_Dgv1.DataSource = dtTable;

            String ItemRowName = "";

            foreach (DataRow dr in dtTable.Rows)
            {
                if (dr["MALOAIDICHVU"].ToString() != ItemRowName)
                {
                    DV_LoaiDV.Items.Add(dr["MALOAIDICHVU"]);
                }
                ItemRowName = dr["MALOAIDICHVU"].ToString();
            }

            DV_MaPhieu.Text = NP_MaPhieu.Text;

        }

        int GiaTien = 0;
        private void DV_Chon_Click(object sender, EventArgs e)
        {
            if (DV_Soluong.Value.ToString() != "0" && Row != null)
            {
                DV_Dgv2.Rows.Add(Row.Cells[1].Value.ToString(), DV_Soluong.Value.ToString());

                GiaTien += Convert.ToInt32(DV_Soluong.Value)* Convert.ToInt32(Row.Cells[3].Value);
            }
        }

        private void DV_LoaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DV_Dgv1 != null)
            {
                if (DV_LoaiDV.SelectedItem.ToString() == "All")
                {
                    DV_Dgv1.DataSource = dtTable;
                }
                else
                {

                    DataView dv = new DataView(dtTable);
                    dv.RowFilter = string.Format("MALOAIDICHVU LIKE '%{0}%'", DV_LoaiDV.SelectedItem.ToString());
                    DV_Dgv1.DataSource = dv;

                }
            }
        }

        private void DV_LoaiDV_KeyUP(object sender, KeyEventArgs e)
        {
            String actual = DV_LoaiDV.Text;
            int index = DV_LoaiDV.FindString(actual);

            bool bo = e.KeyCode == Keys.Back || e.KeyCode == Keys.Left
         || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down
         || e.KeyCode == Keys.Delete || e.KeyCode == Keys.PageDown
         || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.End
         || e.KeyCode == Keys.Home;

            if (bo == true)
                return;

            //this condition means that there is a result
            if (index > -1)
            {
                String found = DV_LoaiDV.Items[index].ToString();
                DV_LoaiDV.SelectedIndex = index;

                DV_LoaiDV.SelectionStart = actual.Length;
                DV_LoaiDV.SelectionLength = found.Length;
                DV_LoaiDV.DroppedDown = true;

            }
        }

        private void DV_Dgv1CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Row = this.DV_Dgv1.Rows[e.RowIndex];

            }
        }

        private void DV_HoanThanh_Click(object sender, EventArgs e)
        {
            connectDatabase();
            sqlCmd = new SqlCommand("INSERT INTO PHIEUDICHVU (MAPHIEUDICHVU,  MAPHIEUTHUE, MADICHVU,SOLUONG, THANHTIEN ) VALUES (@MAPHIEUDICHVU,  @MAPHIEUTHUE, @MADICHVU, @SOLUONG, @THANHTIEN)", sqlCon);
            
            sqlCmd.Parameters.Add("@MAPHIEUTHUE", DV_MaPhieu.Text.ToString());
            sqlCmd.Parameters.Add("@MADICHVU", "OTHERS");
            sqlCmd.Parameters.Add("@SOLUONG", DV_Soluong.Value);
            sqlCmd.Parameters.Add("@THANHTIEN", GiaTien);


            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param Đặt phong ="sender"></param>
        /// <param name="e"></param>

        private void DatPhong_Click(object sender, EventArgs e)
        {

            Button btn = new Button();

            panelDP.Controls.Add(btn);

            panelDV.Hide();
            panelNP.Hide();
            panelHD.Hide();
            panelDP.Show();

            connectDatabase();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM LOAIPHONG", sqlCon);

            dtTable = new DataTable();
            sqlDa.Fill(dtTable);

            String ItemRowName = "";

            foreach (DataRow dr in dtTable.Rows)
            {
                if (dr["TENLOAI"].ToString() != ItemRowName)
                {
                    DP_LoaiPhong.Items.Add(dr["TENLOAI"]);
                }
                ItemRowName = dr["TENLOAI"].ToString();
            }

            
            sqlDa = new SqlDataAdapter("SELECT * FROM PHONG", sqlCon);

            dtTable = new DataTable();
            sqlDa.Fill(dtTable);

            ItemRowName = "";

            foreach (DataRow dr in dtTable.Rows)
            {
                if (dr["MAPHONG"].ToString() != ItemRowName)
                {
                    DP_Phong.Items.Add(dr["MAPHONG"]);
                }
                ItemRowName = dr["MAPHONG"].ToString();
            }

            sqlCon.Close();
        }

        private void DP_DangKi_Click(object sender, EventArgs e)
        {
            connectDatabase();
            sqlCmd = new SqlCommand("INSERT INTO KHACHHANG (CMND, TENKHACHHANG, GIOITINH, DIACHI, SODIENTHOAI) VALUES (@CMND, @TENKHACHHANG, @GIOITINH, @DIACHI, @SODIENTHOAI)", sqlCon);

            sqlCmd.Parameters.Add("@CMND", NP_MaKH.Text.ToString());
            sqlCmd.Parameters.Add("@TENKHACHHANG", NP_TenKH.Text.ToString());
            sqlCmd.Parameters.Add("@GIOITINH", NP_GioiTinh.Text.ToString());
            sqlCmd.Parameters.Add("@DIACHI", NP_DiaChi.Text.ToString());
            sqlCmd.Parameters.Add("@SODIENTHOAI", NP_DienThoai.Text.ToString());


            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            connectDatabase();
            
            sqlCmd = new SqlCommand("INSERT INTO PHIEUDATPHONG (MAPHIEUDAT, MAPHONG, TRANGTHAI, NGAYNHAN, NGAYDI, MAKHACHHANG, MANHANVIEN ) VALUES (@MAPHIEUDAT, @MAPHONG, @TRANGTHAI, @NGAYNHAN, @NGAYDI, @MAKHACHHANG, @MANHANVIEN)", sqlCon);
       
         //   sqlCmd.Parameters.Add("@MAPHIEUDAT", DP_M);
            sqlCmd.Parameters.Add("@MAPHONG", DP_MaPhong.Text.ToString());
            sqlCmd.Parameters.Add("@TRANGTHAI", "DaNhan");
            sqlCmd.Parameters.Add("@NGAYNHAN", DP_NgayDen.Value);
            sqlCmd.Parameters.Add("@NGAYDI", DP_NgayDi.Value);
            sqlCmd.Parameters.Add("@MAKHACHHANG", DP_MaKH.Text.ToString());
            sqlCmd.Parameters.Add("@MANHANVIEN", "letan");
           
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        private void DP_LoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

            connectDatabase();
            sqlCmd = new SqlCommand("SELECT p.MAPHONG FROM LOAIPHONG l, PHONG p WHERE l.TENLOAI = '"+ DP_LoaiPhong.SelectedItem.ToString() + "' AND p.MALOAIPHONG = l.MALOAIPHONG", sqlCon);

            SqlDataReader Reader = sqlCmd.ExecuteReader();

            if (Reader.HasRows)
            {
                DP_Phong.Items.Clear();

                while (Reader.Read())
                {
                   
                    DP_Phong.Items.Add(Reader[0].ToString());
                    
                }
            }

            sqlCon.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param Nhận Phòng="sender"></param>
        /// <param name="e"></param
        string MADP = "";
 
        private void NP_ThuePhong_Click(object sender, EventArgs e)
        {
            connectDatabase();
            sqlCmd = new SqlCommand("INSERT INTO KHACHHANG (CMND, TENKHACHHANG, GIOITINH, DIACHI, SODIENTHOAI) VALUES (@CMND, @TENKHACHHANG, @GIOITINH, @DIACHI, @SODIENTHOAI)", sqlCon);

            sqlCmd.Parameters.Add("@CMND", NP_MaKH.Text.ToString());
            sqlCmd.Parameters.Add("@TENKHACHHANG", NP_TenKH.Text.ToString());
            sqlCmd.Parameters.Add("@GIOITINH", NP_GioiTinh.Text.ToString());
            sqlCmd.Parameters.Add("@DIACHI", NP_DiaChi.Text.ToString());
            sqlCmd.Parameters.Add("@SODIENTHOAI", NP_DienThoai.Text.ToString());


            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            connectDatabase();
            sqlCmd = new SqlCommand("INSERT INTO PHIEUTHUEPHONG (MAPHIEUTHUE, MAPHONG, NGAYDI, MAKHACHHANG, MANHANVIEN, MAPHIEUDAT ) VALUES (@MAPHIEUTHUE, @MAPHONG, @NGAYDI, @MAKHACHHANG, @MANHANVIEN, @MAPHIEUDAT)", sqlCon);
            sqlCmd.Parameters.Add("@MAPHIEUTHUE", NP_MaPhieu.Text.ToString());
            sqlCmd.Parameters.Add("@MAPHONG", NP_Phong.Text.ToString());
            sqlCmd.Parameters.Add("@TRANGTHAI", "DaNhan");
            sqlCmd.Parameters.Add("@NGAYDI", NP_NgayTra.Value);
            sqlCmd.Parameters.Add("@MAKHACHHANG", NP_MaKH.Text.ToString());
            sqlCmd.Parameters.Add("@MANHANVIEN", "letan");
            sqlCmd.Parameters.Add("@MAPHIEUDAT", MADP);

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

        }

        private void NP_TimTTKH_Click(object sender, EventArgs e)
        {
            if (NP_MaKH.Text.ToString() != "")
            {


                connectDatabase();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT p.MAKHACHHANG, k.TENKHACHHANG, k.GIOITINH, k.DIACHI, k.SODIENTHOAI, p.NGAYDI, p.MAPHONG, lp.TENLOAI, p.MAPHIEUDAT FROM PHIEUDATPHONG p, KHACHHANG k, LOAIPHONG lp, PHONG ph WHERE p.NGAYDI >= GETDATE() AND p.MAKHACHHANG LIKE '" + NP_MaKH.Text.ToString()+ "' AND lp.MALOAIPHONG = ph.MALOAIPHONG AND ph.MAPHONG = p.MAPHONG", sqlCon);

                dtTable = new DataTable();
                sqlDa.Fill(dtTable);

                DataView dv = new DataView(dtTable);
                dv.RowFilter = string.Format("MAKHACHHANG LIKE '%{0}%'", NP_MaKH.Text.ToString());

                if(dv.Count > 0)
                {
                    NP_TenKH.Text = dtTable.Rows[0][1].ToString();
                    NP_GioiTinh.Text = dtTable.Rows[0][2].ToString();
                    NP_DiaChi.Text = dtTable.Rows[0][3].ToString();
                    NP_DienThoai.Text = dtTable.Rows[0][4].ToString();
                    NP_NgayTra.Value =Convert.ToDateTime(dtTable.Rows[0][5].ToString());
                    NP_Phong.Text = dtTable.Rows[0][6].ToString();
                    NP_LoaiPhong.Text = dtTable.Rows[0][7].ToString();
                    MADP = dtTable.Rows[0][8].ToString();

                    MessageBox.Show("co ton tai");

                }

                sqlCon.Close();
            }
          
        }

        private void NP_Huy_Click(object sender, EventArgs e)
        {
            NP_DiaChi.Text = "";
            NP_DienThoai.Text = "";
            NP_GioiTinh.Text = "";
            NP_LoaiPhong.Text = "";
            NP_MaKH.Text = "";
            NP_MaPhieu.Text = "";
            NP_Phong.Text = "";
            NP_TenKH.Text = "";
           
            NP_GB1.Refresh();
        }

       
    }
}
