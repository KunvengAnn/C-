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
    public partial class fC_SachHangHoa : Form
    {

        SqlConnection connection;
        SqlCommand command;
        String str = "Data Source=DESKTOP-KO9KLMV\\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True;TrustServerCertificate=true";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();//Data Source=DESKTOP-KO9KLMV\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True
        void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT* FROM C_SACH";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvSach.DataSource = table;
        }
        public fC_SachHangHoa()
        {
            InitializeComponent();
        }
        private void fC_SachHangHoa_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
        }
        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvSach.CurrentRow.Index;
            txtMaSach.Text = dgvSach.Rows[i].Cells[0].Value.ToString();
            txbTenSach.Text = dgvSach.Rows[i].Cells[1].Value.ToString();
            txtSoluongsach.Text = dgvSach.Rows[i].Cells[2].Value.ToString();
            txtDongiaNhap.Text = dgvSach.Rows[i].Cells[3].Value.ToString();
            txtDongiaBan.Text = dgvSach.Rows[i].Cells[4].Value.ToString();
            txtGhiChuSach.Text = dgvSach.Rows[i].Cells[5].Value.ToString();
            dgvSach.ReadOnly = true;
            
        }

        private void btnThemSAch_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO C_SACH VALUES ('" + txtMaSach.Text + "',N'" + txbTenSach.Text + "','" + txtSoluongsach.Text + "', '" + txtDongiaNhap.Text + "','"+ txtDongiaBan.Text+ "',N'"+ txtGhiChuSach.Text+ "')";
                command.ExecuteNonQuery();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnDeleteSach_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                //de delete from dataGridview;
                command.Parameters.AddWithValue("@MA_SA", txtMaSach.Text);
                command.CommandText = "DELETE FROM C_SACH WHERE  MA_SA = @MA_SA";
                command.ExecuteNonQuery(); //DELETE FROM C_SACH WHERE MA_SA='D95'
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditSach_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command = connection.CreateCommand();
                command.Parameters.AddWithValue("@MA_SA", txtMaSach.Text);
                command.Parameters.AddWithValue("@TEN_SA", txbTenSach.Text);
                command.Parameters.AddWithValue("@SOLUONG", txtSoluongsach.Text);
                command.Parameters.AddWithValue("@GIANHAP", Double.Parse(txtDongiaNhap.Text));
                command.Parameters.AddWithValue("@GIABAN", Double.Parse(txtDongiaBan.Text));
                command.Parameters.AddWithValue("@GHICHU", txtGhiChuSach.Text);
                // Thiết lập chuỗi lệnh SQL cho command
                command.CommandText = "UPDATE C_SACH SET MA_SA=@MA_SA, TEN_SA=@TEN_SA, SOLUONG=@SOLUONG,GIANHAP=@GIANHAP,GIABAN=@GIABAN,GHICHU=@GHICHU WHERE MA_SA = @MA_SA";
                // Thực thi lệnh SQL//UPDATE C_SACH SET MA_SA='S05', TEN_SA='Nguyen Van linh', SOLUONG=3, GIANHAP=200.0, GIABAN=300.0, GHICHU=NULL WHERE MA_SA ='S05';

                command.ExecuteNonQuery();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btncloseSach_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Ban co muon tat form nay ko?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(rs==DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = TimByTenSach.Text;
                if (string.IsNullOrEmpty(TimByTenSach.Text))
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu vào tìm!!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                command = connection.CreateCommand();
                command.CommandText = "select * from C_SACH where TEN_SA like '" + ten + "%'";
                command.ExecuteNonQuery();
                //LoadData();
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgvSach.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERror" + ex.Message, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
