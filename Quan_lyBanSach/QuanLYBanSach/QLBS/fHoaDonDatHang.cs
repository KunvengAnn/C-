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
using COMExcel = Microsoft.Office.Interop.Excel;
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
            command.CommandText = "SELECT a.MA_SA,b.TEN_SA,a.SOLUONG,b.GIABAN,a.GIAMGIA,a.THANH_TIEN FROM C_DATHANG as a ,C_SACH as b WHERE a.MA_DATHANG = '" + txbMaDH.Text + "' AND a.MA_SA = b.MA_SA ";
            adapter.SelectCommand = command; //a.MA_DATHANG,
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
            txtTongTien.Text= GetFieldValues(str);
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
            txtbTenNV.ReadOnly = true;
            txtTenKhHD.ReadOnly = true;
            txtDiaChiKhHD.ReadOnly = true;
            txtDienThoaiKhHD.ReadOnly = true;
            TenSachHD.ReadOnly = true;
            txtDonGiaBanHD.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGiaHD.Text = "0";
            txtTongTien.Text = "0";
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

        public string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();

            }
            reader.Close();
            return ma;
        }

        public fHoaDonDatHang()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Ban co muon tat ko?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
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


        public void ResetValuesHangSach()
        {
            cboMaSachHD.Text = "";
            TenSachHD.Text = "";
            txtDonGiaBanHD.Text = "";
            txtSoLuongSachHD.Text = "";
            txtGiamGiaHD.Text = "";
            txtThanhTien.Text = "";
        }

        //Hàm kiểm tra khoá trùng
        public bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT  MA_DATHANG  FROM DATHANG  WHERE MA_DATHANG =N'" + txbMaDH.Text + "'";
            txtTongTien.Text = "0";
            if (!CheckKey(sql))
            {
                // Mã hóa đơn chưa tồn tại, tiến hành lưu các thông tin chung
                if (cboMaNVHD.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNVHD.Focus();
                    return;
                }
                if (cboMaKhachHangHOADon.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKhachHangHOADon.Focus();
                    return;
                }

                sql = "INSERT INTO DATHANG VALUES (N'" + txbMaDH.Text + "','" +
                         cboMaNVHD.SelectedValue + "',N'" + dtpNgayBanHDLap.Value + "',N'" +
                        cboMaKhachHangHOADon.SelectedValue + "'," + txtTongTien.Text + ")";
                RunSQL(sql);
                
            }

            // Lưu thông tin của các mặt hàng
            if (cboMaSachHD.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSachHD.Focus();
                return;
            }
            if ((txtSoLuongSachHD.Text.Length == 0) || (txtSoLuongSachHD.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongSachHD.Text = "";
                txtSoLuongSachHD.Focus();
                return;
            }
            if (txtGiamGiaHD.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGiaHD.Focus();
                return;
            }
            sql = "SELECT MA_SA FROM C_DATHANG WHERE MA_SA=N'" + cboMaSachHD.SelectedValue + "' AND MA_DATHANG = '" + txbMaDH.Text + "' ";
            /*
            if (CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHangSach();
                cboMaSachHD.Focus();
                return;
            }*/
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(GetFieldValues("SELECT SOLUONG FROM C_SACH WHERE MA_SA = N'" + cboMaSachHD.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoLuongSachHD.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongSachHD.Text = "";
                txtSoLuongSachHD.Focus();
                return;
            }
            sql = "INSERT INTO C_DATHANG VALUES('" + txbMaDH.Text + "', '" + cboMaSachHD.SelectedValue + "', " + txtSoLuongSachHD.Text + ", " + txtDonGiaBanHD.Text + ", " + txtGiamGiaHD.Text + ", " + txtThanhTien.Text + ")";
            RunSQL(sql);
            LoadData();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoLuongSachHD.Text);
            sql = "UPDATE C_SACH SET SOLUONG =" + SLcon + " WHERE MA_SA = N'" + cboMaSachHD.SelectedValue + "' ";
            RunSQL(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(GetFieldValues("SELECT TongTien FROM DATHANG WHERE MA_DATHANG = N'" + txbMaDH.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
            sql = "UPDATE DATHANG SET TongTien =" + Tongmoi + " WHERE MA_DATHANG =N'" + txbMaDH.Text + "'";
            RunSQL(sql);
            txtTongTien.Text = Tongmoi.ToString();
            //lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValuesHangSach();
        }


        private void cboMaKhachHangHOADon_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKhachHangHOADon.Text == "")
            {
                txtTenKhHD.Text = "";
                txtDiaChiKhHD.Text = "";
                txtDienThoaiKhHD.Text = "";
            }
            else
            {
                //khi chon ma nao do se hien ra text
                str = "SELECT TEN_KH FROM KHACHHANG  WHERE MA_KH = N'" + cboMaKhachHangHOADon.SelectedValue + "' ";
                txtTenKhHD.Text = GetFieldValues(str);
                str = "SELECT DIACHI_KH FROM KHACHHANG WHERE MA_KH =N'" + cboMaKhachHangHOADon.SelectedValue + "'";
                txtDiaChiKhHD.Text = GetFieldValues(str);
                str = "SELECT SODT_KH FROM KHACHHANG WHERE MA_KH=N'" + cboMaKhachHangHOADon.SelectedValue + "' ";
                txtDienThoaiKhHD.Text = GetFieldValues(str);
            }
        }

        private void cboMaSachHD_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaSachHD.Text == "")
            {
                TenSachHD.Text = "";
                txtDonGiaBanHD.Text = "";
            }
            else
            {
                // Khi chọn mã hàng thì các thông tin về hàng hiện ra
                str = "SELECT TEN_SA FROM C_SACH WHERE MA_SA =N'" + cboMaSachHD.SelectedValue + "'";
                TenSachHD.Text = GetFieldValues(str);
                str = "SELECT GIABAN FROM C_SACH WHERE MA_SA =N'" + cboMaSachHD.SelectedValue + "'";
                txtDonGiaBanHD.Text = GetFieldValues(str);
            }
        }

        private void txtSoLuongSachHD_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if(txtSoLuongSachHD.Text=="")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuongSachHD.Text);
            if (txtDonGiaBanHD.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBanHD.Text);
            if (txtGiamGiaHD.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGiaHD.Text);
            tt = sl * dg - sl * dg * (gg / 100);
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGiaHD_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoLuongSachHD.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuongSachHD.Text);
            if (txtDonGiaBanHD.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBanHD.Text);
            if (txtGiamGiaHD.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGiaHD.Text);
            tt = sl * dg - sl * dg * (gg / 100);
            txtThanhTien.Text = tt.ToString();
        }

        private void cboMaNVHD_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNVHD.Text == "")
            {
                txtbTenNV.Text = "";
            }
            else
            {
                // Khi chọn Mã nhân viên thì tên nhân viên sẽ tự động hiện ra
                //SELECT TEN_NV FROM NHANVIEN WHERE MA_NV = N'NV01'
                str = "SELECT TEN_NV FROM NHANVIEN WHERE MA_NV =N'" + cboMaNVHD.SelectedValue + "'";
                txtbTenNV.Text = GetFieldValues(str);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            FillCombo("SELECT MA_DATHANG FROM DATHANG", comboBox1, "MA_DATHANG", "MA_DATHANG");
            comboBox1.SelectedIndex = -1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            txbMaDH.Text = comboBox1.Text;
            LoadInfoHoadon();
            LoadData();
            comboBox1.SelectedIndex = -1;
        }

        //Lấy dữ liệu vào bảng
        public DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = connection; //Kết nối cơ sở dữ liệu
            dap.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop Design by Veng Ann";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Veng Ann- Sách";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (079) 5359226 ";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán//SELECT A.MA_DATHANG, A.NGAYLAP,A.TongTien,B.TEN_KH,B.DIACHI_KH,B.DIACHI_KH,C.TEN_NV FROM DATHANG A, KHACHHANG B, NHANVIEN C WHERE A.MA_DATHANG='MD01' AND A.MA_KH=B.MA_KH AND A.MA_NV=C.MA_NV ;
            sql = "SELECT A.MA_DATHANG, A.NGAYLAP,A.TongTien,B.TEN_KH,B.DIACHI_KH,B.DIACHI_KH,C.TEN_NV FROM DATHANG A, KHACHHANG B, " +
                  "NHANVIEN C WHERE A.MA_DATHANG = N'" + txbMaDH.Text + "' AND A.MA_KH=B.MA_KH AND A.MA_NV=C.MA_NV";
            tblThongtinHD = GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng//SELECT B.TEN_SA, A.SOLUONG,B.GIABAN,A.GIAMGIA,A.THANH_TIEN FROM C_DATHANG A, C_SACH B WHERE A.MA_DATHANG='MD01' AND A.MA_SA=B.MA_SA 
            sql = "SELECT B.TEN_SA, A.SOLUONG,B.GIABAN,A.GIAMGIA,A.THANH_TIEN FROM C_DATHANG A, C_SACH B WHERE A.MA_DATHANG= N'" +
                  txbMaDH.Text + "' AND A.MA_SA=B.MA_SA ";
            tblThongtinHang = GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            //exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn bán sách";
            exApp.Visible = true;
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MA_SA,SOLUONG FROM C_DATHANG WHERE MA_DATHANG = N'" + txbMaDH.Text + "'";
                //DataTable tblHang = Functions.GetDataToTable(sql);
                DataTable tableSach = GetDataToTable(sql);
                for (int sach = 0; sach <= tableSach.Rows.Count - 1; sach++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng C_sach trong stock //SELECT SOLUONG FROM C_SACH WHERE MA_SA ='S01'
                    sl = Convert.ToDouble(GetFieldValues("SELECT SOLUONG FROM C_SACH WHERE MA_SA = N'" + tableSach.Rows[sach][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tableSach.Rows[sach][1].ToString());
                    slcon = sl + slxoa;//UPDATE C_SACH SET SOLUONG = 4 WHERE MA_SA = 'S01'
                    sql = "UPDATE C_SACH SET SOLUONG =" + slcon + " WHERE MA_SA= N'" + tableSach.Rows[sach][0].ToString() + "'";
                    RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn HAY chi tiet DatHang//DELETE FROM C_DATHANG WHERE MA_DATHANG
                sql = "DELETE FROM C_DATHANG WHERE MA_DATHANG=N'" + txbMaDH.Text + "'";
                RunSQL(sql);

                //Xóa hóa đơn Hoac MADatHang;
                sql = "DELETE DATHANG WHERE MA_DATHANG=N'" + txbMaDH.Text + "'";
                RunSQL(sql);
                ResetValuesHangSach();
                LoadData();
                //btnXoa.Enabled = false;
                //btnInHoaDon.Enabled = false;
            }
        }

        private void dgvHoaDonDatHang_DoubleClick(object sender, EventArgs e)
        {
            string MaHangxoa,sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            //sql = "SELECT MA_SA,SOLUONG FROM C_DATHANG WHERE MA_DATHANG = N'" + txbMaDH.Text + "'";
            //DataTable tableCTDH = GetDataToTable(sql);
            /*if (dgvHoaDonDatHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }*/
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dgvHoaDonDatHang.CurrentRow.Cells["MA_SA"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dgvHoaDonDatHang.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgvHoaDonDatHang.CurrentRow.Cells["THANH_TIEN"].Value.ToString());
                sql = "DELETE C_DATHANG WHERE MA_DATHANG=N'" + txbMaDH.Text + "' AND MA_SA = N'" + MaHangxoa + "'";
                //Functions.RunSQL(sql); Functions này là hàm connect Database của người ta ;
                RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(GetFieldValues("SELECT SOLUONG FROM C_SACH WHERE MA_SA = N'" + MaHangxoa + "'"));
                slcon = sl + SoLuongxoa;
                sql = "UPDATE C_SACH SET SOLUONG =" + slcon + " WHERE MA_SA = N'" + MaHangxoa + "'";
                RunSQL(sql);

                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(GetFieldValues("SELECT TongTien FROM DATHANG WHERE MA_DATHANG = N'" + txbMaDH.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE DATHANG SET TongTien =" + tongmoi + " WHERE MA_DATHANG = N'" + txbMaDH.Text + "'";
                RunSQL(sql);
                txtTongTien.Text = tongmoi.ToString();
                //lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(tongmoi.ToString());
                LoadData();
            }
        }


    }
}
