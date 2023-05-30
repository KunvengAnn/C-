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
    public partial class fKhachHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        String str = "Data Source=DESKTOP-KO9KLMV\\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True;TrustServerCertificate=true";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();//Data Source=DESKTOP-KO9KLMV\SQLEXPRESS;Initial Catalog=QLBSO;Integrated Security=True
        void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT* FROM KHACHHANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvKhach.DataSource = table;
        }

        public fKhachHang()
        {
            InitializeComponent();
        }

        private void btncloseKhach_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Ban co muon tat from nay khong?","Thong Bao",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (rs == DialogResult.OK) 
            {
                this.Dispose();
            }
        }

        private void dgvKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvKhach.CurrentRow.Index;
            txtMakhach.Text = dgvKhach.Rows[i].Cells[0].Value.ToString();
            txbTenKhach.Text = dgvKhach.Rows[i].Cells[1].Value.ToString();
            txbDiachiKhach.Text = dgvKhach.Rows[i].Cells[2].Value.ToString();
            mtDienthoaiKhach.Text = dgvKhach.Rows[i].Cells[3].Value.ToString();
            dgvKhach.ReadOnly = true;
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
        }

        private void btnThemK_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO KHACHHANG VALUES ('" + txtMakhach.Text + "',N'" + txbTenKhach.Text + "',N'" + txbDiachiKhach.Text + "', N'" + mtDienthoaiKhach.Text + "')";
                command.ExecuteNonQuery();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditKhach_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command = connection.CreateCommand();
                command.Parameters.AddWithValue("@MA_KH", txtMakhach.Text);
                command.Parameters.AddWithValue("@TEN_KH", txbTenKhach.Text);
                command.Parameters.AddWithValue("@DIACHI_KH", txbDiachiKhach.Text);
                command.Parameters.AddWithValue("@SODT_KH", mtDienthoaiKhach.Text);

                // Thiết lập chuỗi lệnh SQL cho command
                command.CommandText = "UPDATE KHACHHANG SET MA_KH=@MA_KH, TEN_KH=@TEN_KH, DIACHI_KH=@DIACHI_KH,SODT_KH=@SODT_KH WHERE MA_KH = @MA_KH";
                // Thực thi lệnh SQL//UPDATE KHACHHANG SET MA_KH='NV03', TEN_KH='Nguyen Van linh', DIACHI_KH='Nam', SODT_KH='Ha Noi' WHERE MA_KH ='KH03';
                command.ExecuteNonQuery();
                LoadData();
            }catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDeleteKhach_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                //de delete from dataGridview;
                command.Parameters.AddWithValue("@MA_KH", txtMakhach.Text);
                command.CommandText = "DELETE FROM KHACHHANG WHERE  MA_KH = @MA_KH";
                command.ExecuteNonQuery();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string tenKH = txtTimkhach.Text;
                command = connection.CreateCommand();
                command.CommandText = "select * from KHACHHANG where TEN_KH like '" + tenKH + "%'";
                command.ExecuteNonQuery();
                //LoadData();
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgvKhach.DataSource = table;
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERror" + ex.Message, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
