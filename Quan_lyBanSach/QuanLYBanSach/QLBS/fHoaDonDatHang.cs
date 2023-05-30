//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBS
{
    public partial class fHoaDonDatHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        String str = "Data Source=DESKTOP-KO9KLMV\\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True;TrustServerCertificate=true";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();//Data Source=DESKTOP-KO9KLMV\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True
        void LoadData()
        {
            command = connection.CreateCommand(); // toi dang tim hieu
            command.CommandText = "SELECT a.MA_DATHANG,b.TEN_SA,a.SOLUONG,b.GIABAN,a.GIAMGIA,a.THANH_TIEN FROM C_DATHANG as a ,C_SACH as b WHERE a.MA_DATHANG = '"+txbMaDH+"' AND a.MA_SA = b.MA_SA ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvHoaDonDatHang.DataSource = table;
        }

        void LoadInfoHoadon()
        {//nạp chỉ tiết hóa đơn
            string str;
            str = "SELECT NGAYLAP  FROM DATHANG  WHERE MA_DATHANG = '" + txbMaDH.Text + "'";
            dtpNgayBanHDLap.Value = DateTime.Parse(GetFieldValues(str));
            str = "SELECT MA_NV FROM DATHANG WHERE MA_DATHANG = '" + txbMaDH.Text + "'";
            cboMaNVHD.Text = GetFieldValues(str);
            str = "SELECT MA_KH FROM DATHANG WHERE MA_DATHANG = '" + txbMaDH.Text + "'";
            cboMaKhachHangHOADon.Text = GetFieldValues(str);
            str = "SELECT TongTien FROM DATHANG WHERE MA_DATHANG = '" + txbMaDH.Text + "'";

        }

        void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {

            SqlDataAdapter dap = new SqlDataAdapter(sql, connection);
            DataTable table1 = new DataTable();
            dap.Fill(table1);
            cbo.DataSource = table1;
            cbo.ValueMember = ma; // Trường giá trị
            cbo.DisplayMember = ten; // Trường hiển thị
        }
        private void fHoaDonDatHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            FillCombo("SELECT MA_KH, TEN_KH FROM KHACHHANG", cboMaKhachHangHOADon, "MA_KH", "MA_KH");
            cboMaKhachHangHOADon.SelectedIndex = -1;
            FillCombo("SELECT MA_NV, TEN_NV FROM NHANVIEN ", cboMaNVHD, "MA_NV", "MA_NV");
            cboMaNVHD.SelectedIndex = -1;
            FillCombo("SELECT MA_SA, TEN_SA FROM C_SACH", cboMaSachHD, "MA_SA", "MA_SA");
            cboMaSachHD.SelectedIndex = -1;

            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txbMaDH.Text != "")
            {
                LoadInfoHoadon();
                //btnXoa.Enabled = true;
                //btnInHoaDon.Enabled = true;
            }
            LoadData();
        }




         string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                ma = reader.GetValue(0).ToString();
                reader.Close();
            }
            return ma;
        }
        

        

        public fHoaDonDatHang()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Ban co muon tat ko?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(rs==DialogResult.OK)
            {
                this.Dispose();
            } 
        }


        //Hàm thực hiện câu lệnh SQL
         void RunSQL(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = connection; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT  MA_DATHANG  FROM DATHANG  WHERE MA_DATHANG = '"+txbMaDH.Text+"'";
            /*
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgayBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNgayBan.Focus();
                    return;
                }
                if (cboMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNhanVien.Focus();
                    return;
                }
                if (cboMaKhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKhach.Focus();
                    return;
                }
                */

            /*
            sql = "INSERT INTO tblHDBan(MaHDBan, NgayBan, MaNhanVien, MaKhach, TongTien) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" +
                    Functions.ConvertDateTime(txtNgayBan.Text.Trim()) + "',N'" + cboMaNhanVien.SelectedValue + "',N'" +
                    cboMaKhach.SelectedValue + "'," + txtTongTien.Text + ")";
            */   

            //co the loi voi Date ngay lap ban HOa don
            sql = "INSERT INTO DATHANG VALUES('" + txbMaDH.Text + "', '" + cboMaNVHD.SelectedValue + "', '" + dtpNgayBanHDLap.Text + "', '" + cboMaKhachHangHOADon.SelectedValue + "', " + txtTongTien.Text + ") ";
            RunSQL(sql); //xong


            /*
            // Lưu thông tin của các mặt hàng
            if (cboMaHang == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHang.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            */

            //sql = "SELECT MaHang FROM tblChiTietHDBan WHERE MaHang=N'" + cboMaHang.SelectedValue + "' AND MaHDBan = N'" + txtMaHDBan.Text.Trim() + "'";

            sql = "SELECT MA_SA FROM C_DATHANG WHERE MA_SA=N'"+cboMaSachHD.SelectedValue+"' AND MA_DATHANG = '"+txbMaDH.Text+"' ";
            //xong
            /*if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMaHang.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM tblHang WHERE MaHang = N'" + cboMaHang.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            */
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?//SELECT SOLUONG FROM C_SACH WHERE MA_SA =N'S01' 
            sl = Convert.ToDouble(GetFieldValues("SELECT SOLUONG FROM C_SACH WHERE MA_SA = N'" + cboMaSachHD.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoLuongSachHD.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng hay sách này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongSachHD.Text = "";
                txtSoLuongSachHD.Focus();
                return;
            }
            //xong


            //sql = "INSERT INTO tblChiTietHDBan(MaHDBan,MaHang,SoLuong,DonGia, GiamGia,ThanhTien) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cboMaHang.SelectedValue + "'," + txtSoLuong.Text + "," + txtDonGiaBan.Text + "," + txtGiamGia.Text + "," + txtThanhTien.Text + ")";
            sql = "INSERT INTO C_DATHANG VALUES('"+txbMaDH.Text+"', '"+cboMaSachHD.SelectedValue+"', "+txtSoLuongSachHD.Text+", "+txtDonGiaHD.Text+", "+txtGiamGiaHD.Text+", "+txtThanhTien.Text+")";
            RunSQL(sql);
            LoadData(); //load dataGridview
            //xong

            //Functions.RunSQL(sql); //nay la tham khao tren mang;
            //LoadDataGridView();



            // Cập nhật lại số lượng của mặt hàng hay sach (C_Sach) vào bảng (cua toi la C_sach)tblHang
            SLcon = sl - Convert.ToDouble(txtSoLuongSachHD.Text);
            //sql = "UPDATE tblHang SET SoLuong =" + SLcon + " WHERE MaHang= N'" + cboMaHang.SelectedValue + "'";
            sql = "UPDATE C_SACH SET SOLUONG ="+SLcon+" WHERE MA_SA = N'"+cboMaSachHD.SelectedValue+"' ";
            RunSQL(sql);
            //xong
            //Functions.RunSQL(sql);


            // Cập nhật lại tổng tiền cho hóa đơn bán
            //tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'"));
            //cua toi ko co ham functions (la chuoi connect sql); //SELECT TongTien FROM DATHANG WHERE MA_DATHANG =N'MD02'
            tong = Convert.ToDouble(GetFieldValues("SELECT TongTien FROM DATHANG WHERE MA_DATHANG = N'" + txbMaDH.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
            //xong

            //sql = "UPDATE tblHDBan SET TongTien =" + Tongmoi + " WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
            sql = "UPDATE DATHANG SET TongTien ="+Tongmoi+" WHERE MA_DATHANG =N'"+txbMaDH.Text+"'";
            RunSQL(sql);
            txtTongTien.Text = Tongmoi.ToString();
            //Functions.RunSQL(sql);
            //txtTongTien.Text = Tongmoi.ToString();
            //lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
            //ResetValuesHang();
            //btnXoa.Enabled = true;
            //btnThem.Enabled = true;
            //btnInHoaDon.Enabled = true;
        }
    }
}
