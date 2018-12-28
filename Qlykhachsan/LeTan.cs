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

        string conStr = @"Data Source=HOANGHOAINHI\SQLEXPRESS;Initial Catalog=quanlykhachsan123;Integrated Security=True";

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

            /// <summary>
            /// 
            /// </summary>
            /// <param Hoá Đơn ="sender"></param>
            /// <param name="e"></param>

        private void HoaDon_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            panelHD.Controls.Add(btn);


            panelDP.Hide();
            panelNP.Hide();
            panelDV.Hide();
            panelHD.Show();

        }

        private void TimLoaiPhong(String phong) 
        {
            connectDatabase();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT l.MALOAIPHONG, l.TENLOAI, L.DONGIA FROM PHONG p, LOAIPHONG l WHERE p.MAPHONG = '" + phong+ "' AND p.MALOAIPHONG = l.MALOAIPHONG ", sqlCon);

            dtTable = new DataTable();
            sqlDa.Fill(dtTable);

            sqlCon.Close();

        }

        private void TimDichVu(String DichVu)
        {
            connectDatabase();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM PHIEUDICHVU WHERE MAPHIEUDICHVU LIKE '"+DichVu+"'", sqlCon);

            dtTable = new DataTable();
            sqlDa.Fill(dtTable);
            
            sqlCon.Close();

        }

        private void TimPhieuThue(String MaKH)
        {
            connectDatabase();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM PHIEUTHUEPHONG WHERE MAKHACHHANG LIKE '" + MaKH + "'", sqlCon);

            dtTable = new DataTable();
            sqlDa.Fill(dtTable);

            sqlCon.Close();
        }

        private void HD_TimKH_Click(object sender, EventArgs e)
        {
            if(HD_MaKH.Text != "")
            {
                connectDatabase();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM PHIEUTHUEPHONG WHERE MAKHACHHANG = '"+ HD_MaKH.Text +"'", sqlCon);

                dtTable = new DataTable();
                sqlDa.Fill(dtTable);

                DataView dv = new DataView(dtTable);


                sqlCon.Close();
                if (dv.Count > 0)
                {
                    HD_MaPhong.Text = dtTable.Rows[0][1].ToString();
                    var span = Convert.ToDateTime(dtTable.Rows[0][3].ToString()) - Convert.ToDateTime(dtTable.Rows[0][2].ToString());

                    int days = span.Days;
                    HD_SoNgay.Text = days.ToString();
                    HD_MaKH.Text = dtTable.Rows[0][4].ToString();

                    TimPhieuThue(HD_MaKH.Text.ToString());
                    HD_MaPhieu.Text = dtTable.Rows[0][0].ToString();

                    TimLoaiPhong(HD_MaPhong.Text.ToString());
                    HD_TienPhong.Text =Convert.ToString(Convert.ToUInt32(dtTable.Rows[0][2]) * days);

                    TimDichVu(HD_MaPhieu.Text.ToString());
                    HD_TienDV.Text = dtTable.Rows[0][4].ToString();

                    if(HD_GiamGia.Text == "")
                    {
                        HD_GiamGia.Text = "0";
                    }

                    HD_TongTien.Text = Convert.ToString(Convert.ToUInt32(HD_TienPhong.Text) + Convert.ToUInt32(HD_TienDV.Text) - Convert.ToUInt32(HD_GiamGia.Text));

                    HD_ThanhTien.Text = HD_TongTien.Text;
                }
                else
                {
                    MessageBox.Show("Ma khach hang khong ton tai");
                }
            }
        }

        private void HD_ThanhToan_Click(object sender, EventArgs e)
        {
            connectDatabase();


            sqlCmd = new SqlCommand("INSERT INTO HOADON (MAHOADON,  MAPHIEUTHUE, NGAYLAP,MANHANVIEN, TONGTIEN ) VALUES (@MAHOADON,  @MAPHIEUTHUE, @NGAYLAP, @MANHANVIEN, @TONGTIEN)", sqlCon);

            sqlCmd.Parameters.Add("@MAHOADON", HD_MaPhieu.Text.ToString());
            sqlCmd.Parameters.Add("@MAPHIEUTHUE", HD_MaPhieu.Text.ToString());
            sqlCmd.Parameters.Add("@NGAYLAP", HD_NgayLap.Value);
            sqlCmd.Parameters.Add("@MANHANVIEN", HD_MaNV.Text.ToString());
            sqlCmd.Parameters.Add("@TONGTIEN", HD_ThanhTien.Text.ToString());

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        private void HD_HuyBo_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param Dịch Vụ ="sender"></param>
        /// <param name="e"></param>

        DataGridViewRow Row;

        private bool KtraTonTai(String Bang, String Cot, String DuLieu)
        {
       

            connectDatabase();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT SOLUONG, MADICHVU FROM " + Bang + " WHERE " + Cot + " = '" + DuLieu + "'", sqlCon);
            dtTable = new DataTable();
            sqlDa.Fill(dtTable);

            if (dtTable.Rows.Count > 0 )
            {
                DV_Dgv2.DataSource = dtTable;
                sqlCon.Close();
                return true;
            }


            sqlCon.Close();
            return false;
        }

        private void DichVu_Click(object sender, EventArgs e)
        {
            if (NP_MaPhieu.Text == "")
            {
                NP_CBMaPhieu.Show();
            }
            else
            {

                panelDP.Hide();
                panelNP.Hide();
                panelDV.Show();
                
                connectDatabase();
                // sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM DICHVU", sqlCon);

                dtTable = new DataTable();
                sqlDa.Fill(dtTable);
                DV_Dgv1.DataSource = dtTable;

                sqlCon.Close();

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

               // KtraTonTai("PHIEUDICHVU", "MAPHIEUDICHVU", NP_MaPhieu.Text.ToString());
                
            }
        }

        int GiaTien = 0;
        private void DV_Chon_Click(object sender, EventArgs e)
        {
            if (DV_Soluong.Value.ToString() != "0" && Row != null)
            {
                DV_Dgv2.Rows.Add(Row.Cells[1].Value.ToString(), DV_Soluong.Value.ToString());

                GiaTien += Convert.ToInt32(DV_Soluong.Value)* Convert.ToInt32(Row.Cells[3].Value);

                DV_Soluong.Value = 0;
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

        bool DV_HT = false;

        private void DV_HoanThanh_Click(object sender, EventArgs e)
        {
            DV_HT = true;

            panelDV.Hide();
            panelNP.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param Đặt phong ="sender"></param>
        /// <param name="e"></param>

        private bool DP_KiemTraThongTin()
        {
            if (DP_MaKH.Text == "")
            {
                DP_CBMaKH.Show();
                return false;
            }
            else
            {
                DP_CBMaKH.Hide();
            }

            if (DP_TenKH.Text == "")
            {
                DP_CBTenKH.Show();
                return false;
            }
            else
            {
                DP_CBTenKH.Hide();
            }

            if (DP_MaDP.Text == "")
            {
                DP_CBMaDP.Show();
                return false;
            }
            else
            {
                DP_CBMaDP.Hide();
            }
            if (DP_MaPhong.Text == "")
            {
                DP_CBPhong.Show();
                return false;
            }
            else
            {
                DP_CBPhong.Hide();
            }

            if (DP_NgayDen.Value < DateTime.Now || DP_NgayDen.Value >= DP_NgayDi.Value)
            {
                DP_CBNgay.Show();
                return false;
            }

            else
            {
                DP_CBNgay.Hide();
            }
            
            return true;
        }

        private void DatPhong_Click(object sender, EventArgs e)
        {

            Button btn = new Button();

            panelDP.Controls.Add(btn);

            panelDV.Hide();
            panelNP.Hide();
            panelHD.Hide();
            panelDP.Show();

            DP_CBMaDP.Hide();
            DP_CBMaKH.Hide();
            DP_CBNgay.Hide();
            DP_CBPhong.Hide();
            DP_CBTenKH.Hide();


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
                    DP_MaPhong.Items.Add(dr["MAPHONG"]);
                }
                ItemRowName = dr["MAPHONG"].ToString();
            }

            sqlCon.Close();
        }

        private void DP_DangKi_Click(object sender, EventArgs e)
        {
            if (DP_KiemTraThongTin())
            {
                connectDatabase();
                sqlCmd = new SqlCommand("INSERT INTO KHACHHANG (CMND, TENKHACHHANG, GIOITINH, DIACHI, SODIENTHOAI) VALUES (@CMND, @TENKHACHHANG, @GIOITINH, @DIACHI, @SODIENTHOAI)", sqlCon);

                sqlCmd.Parameters.Add("@CMND", DP_MaKH.Text.ToString());
                sqlCmd.Parameters.Add("@TENKHACHHANG", DP_TenKH.Text.ToString());
                sqlCmd.Parameters.Add("@GIOITINH", DP_GioiTinh.Text.ToString());
                sqlCmd.Parameters.Add("@DIACHI", DP_DiaChi.Text.ToString());
                sqlCmd.Parameters.Add("@SODIENTHOAI", DP_DienThoai.Text.ToString());


                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                connectDatabase();

                sqlCmd = new SqlCommand("INSERT INTO PHIEUDATPHONG (MAPHIEUDAT, MAPHONG, TRANGTHAI, NGAYNHAN, NGAYDI, MAKHACHHANG, MANHANVIEN ) VALUES (@MAPHIEUDAT, @MAPHONG, @TRANGTHAI, @NGAYNHAN, @NGAYDI, @MAKHACHHANG, @MANHANVIEN)", sqlCon);


                sqlCmd.Parameters.Add("@MAPHIEUDAT", DP_MaDP.Text.ToString());
                sqlCmd.Parameters.Add("@MAPHONG", DP_MaPhong.Text.ToString());
                sqlCmd.Parameters.Add("@TRANGTHAI", "DaNhan");
                sqlCmd.Parameters.Add("@NGAYNHAN", DP_NgayDen.Value);
                sqlCmd.Parameters.Add("@NGAYDI", DP_NgayDi.Value);
                sqlCmd.Parameters.Add("@MAKHACHHANG", DP_MaKH.Text.ToString());
                sqlCmd.Parameters.Add("@MANHANVIEN", "NV1");

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        private void DP_LoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

            connectDatabase();
            sqlCmd = new SqlCommand("SELECT p.MAPHONG FROM LOAIPHONG l, PHONG p WHERE l.TENLOAI = '"+ DP_LoaiPhong.SelectedItem.ToString() + "' AND p.MALOAIPHONG = l.MALOAIPHONG", sqlCon);

            SqlDataReader Reader = sqlCmd.ExecuteReader();

            if (Reader.HasRows)
            {
                DP_MaPhong.Items.Clear();

                while (Reader.Read())
                {
                   
                    DP_MaPhong.Items.Add(Reader[0].ToString());
                    
                }
            }

            sqlCon.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param Nhận Phòng="sender"></param>
        /// <param name="e"></param

        private bool NP_KiemTraDuLieu()
        {
            if(NP_NgayTra.Value <= DateTime.Now)
            {
                NP_CBNgay.Show();
                return false;
            }
            else
            {
                NP_CBNgay.Hide();
            }

            if(NP_Phong.Text == "")
            {
                NP_CBPhong.Show();
                return false;
            }
            else
            {
                NP_CBPhong.Hide();
            }

            if(NP_MaPhieu.Text == "")
            {
                NP_CBMaPhieu.Show();
                return false;
            }
            else
            {
                NP_CBMaPhieu.Hide();
            }

            if (NP_MaKH.Text == "")
            {
                NP_CBMaKH.Show();
                return false;
            }
            else
            {
                NP_CBMaPhieu.Hide();
            }
            return true;
        }

        private void NhanPhong_Click(object sender, EventArgs e)
        {
            Button btn = new Button();

            panelNP.Controls.Add(btn);
            panelDP.Hide();
            panelDV.Hide();
            panelHD.Hide();
            panelNP.Show();

            NP_CBMaPhieu.Hide();
            NP_CBNgay.Hide();
            NP_CBPhong.Hide();
            NP_CBMaKH.Hide();

            connectDatabase();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM LOAIPHONG", sqlCon);

            dtTable = new DataTable();
            sqlDa.Fill(dtTable);

            String ItemRowName = "";

            foreach (DataRow dr in dtTable.Rows)
            {
                if (dr["TENLOAI"].ToString() != ItemRowName)
                {
                    NP_LoaiPhong.Items.Add(dr["TENLOAI"]);
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
                    NP_Phong.Items.Add(dr["MAPHONG"]);
                }
                ItemRowName = dr["MAPHONG"].ToString();
            }

            sqlCon.Close();

        }

        private void NP_LoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

            connectDatabase();
            sqlCmd = new SqlCommand("SELECT p.MAPHONG FROM LOAIPHONG l, PHONG p WHERE l.TENLOAI = '" + NP_LoaiPhong.SelectedItem.ToString() + "' AND p.MALOAIPHONG = l.MALOAIPHONG", sqlCon);

            SqlDataReader Reader = sqlCmd.ExecuteReader();

            if (Reader.HasRows)
            {
                NP_Phong.Items.Clear();

                while (Reader.Read())
                {

                    NP_Phong.Items.Add(Reader[0].ToString());

                }
            }

            sqlCon.Close();
        }

        string MADP = "";
 
        private void NP_TimTTKH_Click(object sender, EventArgs e)
        {
            if (NP_MaKH.Text.ToString() != "")
            {
                String str = "SELECT p.MAKHACHHANG, k.TENKHACHHANG, k.GIOITINH, k.DIACHI, k.SODIENTHOAI, p.NGAYDI, p.MAPHONG, lp.TENLOAI, p.MAPHIEUDAT FROM PHIEUNHANPHONG p, KHACHHANG k, LOAIPHONG lp, PHONG ph WHERE p.NGAYDI >= GETDATE() AND p.MAKHACHHANG LIKE '" + NP_MaKH.Text.ToString() + "' AND lp.MALOAIPHONG = ph.MALOAIPHONG AND ph.MAPHONG = p.MAPHONG AND p.MAKHACHHANG = k.CMND";

                connectDatabase();
               
                if (NP_R2.Checked == true)
                {
                    str = "SELECT p.MAKHACHHANG, k.TENKHACHHANG, k.GIOITINH, k.DIACHI, k.SODIENTHOAI, p.NGAYDI, p.MAPHONG, lp.TENLOAI, p.MAPHIEUDAT FROM PHIEUDATPHONG p, KHACHHANG k, LOAIPHONG lp, PHONG ph WHERE p.NGAYDI >= GETDATE() AND p.MAKHACHHANG LIKE '" + NP_MaKH.Text.ToString() + "' AND lp.MALOAIPHONG = ph.MALOAIPHONG AND ph.MAPHONG = p.MAPHONG AND p.MAKHACHHANG = k.CMND";
                }

                SqlDataAdapter sqlDa = new SqlDataAdapter(str, sqlCon);

                dtTable = new DataTable();
                sqlDa.Fill(dtTable);

                DataView dv = new DataView(dtTable);
                dv.RowFilter = string.Format("MAKHACHHANG LIKE '%{0}%'", NP_MaKH.Text.ToString());

                sqlCon.Close();
                if (dv.Count > 0)
                {
                    NP_TenKH.Text = dtTable.Rows[0][1].ToString();
                    NP_GioiTinh.Text = dtTable.Rows[0][2].ToString();
                    NP_DiaChi.Text = dtTable.Rows[0][3].ToString();
                    NP_DienThoai.Text = dtTable.Rows[0][4].ToString();
                    NP_NgayTra.Value =Convert.ToDateTime(dtTable.Rows[0][5].ToString());
                    NP_Phong.Text = dtTable.Rows[0][6].ToString();
                    NP_LoaiPhong.Text = dtTable.Rows[0][7].ToString();
                    MADP = dtTable.Rows[0][8].ToString();

                }

            }

        }

        private void NP_ThuePhong_Click(object sender, EventArgs e)
        {
            if (NP_KiemTraDuLieu())
            {
                connectDatabase();
                sqlCmd = new SqlCommand("INSERT INTO KHACHHANG (CMND, TENKHACHHANG, GIOITINH, DIACHI, SODIENTHOAI) VALUES (@CMND, @TENKHACHHANG, @GIOITINH, @DIACHI, @SODIENTHOAI)", sqlCon);

                sqlCmd.Parameters.Add("@TENKHACHHANG", NP_TenKH.Text.ToString());
                sqlCmd.Parameters.Add("@GIOITINH", NP_GioiTinh.Text.ToString());
                sqlCmd.Parameters.Add("@DIACHI", NP_DiaChi.Text.ToString());
                sqlCmd.Parameters.Add("@SODIENTHOAI", NP_DienThoai.Text.ToString());
                sqlCmd.Parameters.Add("@CMND", NP_MaKH.Text.ToString());


                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                connectDatabase();
                if (MADP != "")
                {
                    sqlCmd = new SqlCommand("INSERT INTO PHIEUTHUEPHONG (MAPHIEUTHUE, MAPHONG, NGAYTHUE, NGAYDI, MAKHACHHANG, MANHANVIEN, MAPHIEUDAT ) VALUES (@MAPHIEUTHUE, @MAPHONG, @NGAYTHUE, @NGAYDI, @MAKHACHHANG, @MANHANVIEN, @MAPHIEUDAT)", sqlCon);
                    sqlCmd.Parameters.Add("@MAPHIEUTHUE", NP_MaPhieu.Text.ToString());
                    sqlCmd.Parameters.Add("@MAPHONG", NP_Phong.Text.ToString());
                    sqlCmd.Parameters.Add("@TRANGTHAI", "DaNhan");

                    sqlCmd.Parameters.Add("@NGAYTHUE", DateTime.Now);
                    sqlCmd.Parameters.Add("@NGAYDI", NP_NgayTra.Value);
                    sqlCmd.Parameters.Add("@MAKHACHHANG", NP_MaKH.Text.ToString());
                    sqlCmd.Parameters.Add("@MANHANVIEN", "NV1");
                    sqlCmd.Parameters.Add("@MAPHIEUDAT", MADP);
                }
                else
                {
                    sqlCmd = new SqlCommand("INSERT INTO PHIEUTHUEPHONG (MAPHIEUTHUE, MAPHONG, NGAYTHUE, NGAYDI, MAKHACHHANG, MANHANVIEN ) VALUES (@MAPHIEUTHUE, @MAPHONG, @NGAYTHUE, @NGAYDI, @MAKHACHHANG, @MANHANVIEN)", sqlCon);
                    sqlCmd.Parameters.Add("@MAPHIEUTHUE", NP_MaPhieu.Text.ToString());
                    sqlCmd.Parameters.Add("@MAPHONG", NP_Phong.Text.ToString());
                    sqlCmd.Parameters.Add("@TRANGTHAI", "DaNhan");

                    sqlCmd.Parameters.Add("@NGAYTHUE", DateTime.Now);
                    sqlCmd.Parameters.Add("@NGAYDI", NP_NgayTra.Value);
                    sqlCmd.Parameters.Add("@MAKHACHHANG", NP_MaKH.Text.ToString());
                    sqlCmd.Parameters.Add("@MANHANVIEN", "NV1");
                   
                }
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                if(DV_HT == true)
                {
                    connectDatabase();

                    sqlCmd = new SqlCommand("INSERT INTO PHIEUDICHVU (MAPHIEUDICHVU,  MAPHIEUTHUE, MADICHVU,SOLUONG, THANHTIEN ) VALUES (@MAPHIEUDICHVU,  @MAPHIEUTHUE, @MADICHVU, @SOLUONG, @THANHTIEN)", sqlCon);

                    sqlCmd.Parameters.Add("@MAPHIEUDICHVU", DV_MaPhieu.Text.ToString());
                    sqlCmd.Parameters.Add("@MAPHIEUTHUE", DV_MaPhieu.Text.ToString());
                    sqlCmd.Parameters.Add("@MADICHVU", "DVOT01");
                    sqlCmd.Parameters.Add("@SOLUONG", DV_Soluong.Value);
                    sqlCmd.Parameters.Add("@THANHTIEN", GiaTien);

                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();

                }

                MessageBox.Show("Nhan phong thanh cong");
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
