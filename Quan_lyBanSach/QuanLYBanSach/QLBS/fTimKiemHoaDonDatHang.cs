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
    public partial class fTimKiemHoaDonDatHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        String str = "Data Source=DESKTOP-KO9KLMV\\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True;TrustServerCertificate=true";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();//Data Source=DESKTOP-KO9KLMV\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True
        void LoadData()
        {
            dataGridViewTimKiem.Columns[0].HeaderText = "Mã HĐB";
            dataGridViewTimKiem.Columns[1].HeaderText = "Mã nhân viên";
            dataGridViewTimKiem.Columns[2].HeaderText = "Ngày bán";
            dataGridViewTimKiem.Columns[3].HeaderText = "Mã khách";
            dataGridViewTimKiem.Columns[4].HeaderText = "Tổng tiền";
            //dataGridViewTimKiem.Columns[0].Width = 150;
            //dataGridViewTimKiem.Columns[1].Width = 100;
            //dataGridViewTimKiem.Columns[2].Width = 80;
            //dataGridViewTimKiem.Columns[3].Width = 80;
            //dataGridViewTimKiem.Columns[4].Width = 80;
            //dataGridViewTimKiem.AllowUserToAddRows = false;
            //dataGridViewTimKiem.EditMode = DataGridViewEditMode.EditProgrammatically;
            /*
            command = connection.CreateCommand(); // toi dang tim hieu
            command.CommandText = "SELECT * FROM DATHANG WHERE 1=1 AND MA_DATHANG LIKE N'%"+txtMaHdDHTIm.Text+"%'";
            adapter.SelectCommand = command; //a.MA_DATHANG,
            table.Clear();
            adapter.Fill(table);
            dataGridViewTimKiem.DataSource = table;
            */
        }
        public fTimKiemHoaDonDatHang()
        {
            InitializeComponent();
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maHdDHTim = txtMaHdDHTIm.Text;
            string thang = txtThang.Text;
            string nam = txtNam.Text;
            string maNhanVien = txtMaNhanVien.Text;
            string maKhach = txtMaKhachHangTim.Text;
            string tongTienTim = txtTongTienTim.Text;

            string sql = "SELECT * FROM DATHANG WHERE 1=1";
            if (!string.IsNullOrEmpty(maHdDHTim))
                sql += " AND MA_DATHANG LIKE N'%" + maHdDHTim + "%'";
            if (!string.IsNullOrEmpty(thang))
                sql += " AND MONTH(NGAYLAP) = " + thang;
            if (!string.IsNullOrEmpty(nam))
                sql += " AND YEAR(NGAYLAP) = " + nam;
            if (!string.IsNullOrEmpty(maNhanVien))
                sql += " AND MA_NV LIKE N'%" + maNhanVien + "%'";
            if (!string.IsNullOrEmpty(maKhach))
                sql += " AND MA_KH LIKE N'%" + maKhach + "%'";
            if (!string.IsNullOrEmpty(tongTienTim))
                sql += " AND TongTien <= " + tongTienTim;

            DataTable tblHDB = GetDataToTable(sql);
            int rowCount = tblHDB.Rows.Count;
            if (rowCount > 0)
            {
                MessageBox.Show("Có " + rowCount + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewTimKiem.DataSource = tblHDB;
                LoadData();
            }
            else
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTongTienTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHdDHTIm.Focus();
            
        }
        private void fTimKiemHoaDonDatHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            dataGridViewTimKiem.DataSource = null;
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dataGridViewTimKiem.DataSource = null;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Ban co muon dong khong??", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(rs ==DialogResult.OK)
            {
                this.Dispose();
            }
        }
    }
}
