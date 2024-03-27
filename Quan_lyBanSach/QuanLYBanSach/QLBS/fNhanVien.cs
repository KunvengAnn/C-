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
    public partial class fNhanVien : Form
    {
        SqlConnection connection;
        SqlCommand command;
        String str = "Data Source=DESKTOP-KO9KLMV\\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True;TrustServerCertificate=true";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();//Data Source=DESKTOP-KO9KLMV\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True
        void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT* FROM NHANVIEN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dDgvNhanVien.DataSource = table;
        }

        public fNhanVien()
        {
            InitializeComponent();
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            //txbMaNNGiaoHang.Enabled = false;
            //btnLuuGiaoHang.Enabled = false;
           // btnBoGaioHang.Enabled = false;
            connection = new SqlConnection(str);
            connection.Open();
            //LoadData();
        }

        String Gender = ""; //khai bao de get lay gai tri Gioi Tinh Nam nu;
        private void loadGioiTinh()
        {
            
            if (comboBoxGioiTinh.SelectedIndex == 0)
            {
                Gender = "Nam";
            }
            else if (comboBoxGioiTinh.SelectedIndex == 1)
            {
                Gender = "Nữ";
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            loadGioiTinh();
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO NHANVIEN VALUES ('" + txbMaNV.Text + "',N'" + txTenNV.Text + "',N'" + Gender + "', N'" + textBoxDiaCHI.Text + "','" + maskedTextBoxDienThoai.Text + "')";
                command.ExecuteNonQuery();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            loadGioiTinh();
            //SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command = connection.CreateCommand();
            command.Parameters.AddWithValue("@MA_NV", txbMaNV.Text);
            command.Parameters.AddWithValue("@TEN_NV", txbTenNV.Text);
            command.Parameters.AddWithValue("@GIOITINH", Gender);
            command.Parameters.AddWithValue("@DIACHI", textBoxDiaCHI.Text);
            command.Parameters.AddWithValue("@SODT_NV", maskedTextBoxDienThoai.Text);
            
            // Thiết lập chuỗi lệnh SQL cho command
            command.CommandText = "UPDATE NHANVIEN SET MA_NV=@MA_NV, TEN_NV=@TEN_NV, GIOITINH=@GIOITINH,DIACHI=@DIACHI, SODT_NV=@SODT_NV WHERE MA_NV = @MA_NV";
            // Thực thi lệnh SQL//UPDATE NHANVIEN SET MA_NV='NV03', TEN_NV='Nguyen Van linh', GIOITINH='Nam', DIACHI='Ha Noi',SODT_NV='04747374' WHERE MA_NV ='NV03';
            command.ExecuteNonQuery();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                //de delete from dataGridview;
                command.Parameters.AddWithValue("@MA_NV", txbMaNV.Text);
                command.CommandText = "DELETE FROM NHANVIEN WHERE  MA_NV = @MA_NV";
                command.ExecuteNonQuery();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            loadGioiTinh();
            i = dDgvNhanVien.CurrentRow.Index;
            txbMaNV.Text = dDgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txTenNV.Text = dDgvNhanVien.Rows[i].Cells[1].Value.ToString();
            comboBoxGioiTinh.Text = dDgvNhanVien.Rows[i].Cells[2].Value.ToString();
            textBoxDiaCHI.Text = dDgvNhanVien.Rows[i].Cells[3].Value.ToString();
            maskedTextBoxDienThoai.Text = dDgvNhanVien.Rows[i].Cells[4].Value.ToString();

            dDgvNhanVien.ReadOnly = true;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("bạn có muốn tắt luôn không ?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(rs == DialogResult.OK) 
            {
                this.Dispose();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenNV = txtTim.Text;
            command = connection.CreateCommand();
            command.CommandText = "select * from NHANVIEN where TEN_NV like '" + tenNV + "%'";
            command.ExecuteNonQuery();
            //LoadData();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dDgvNhanVien.DataSource = table;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
