using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project1_Student
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        String str = "Data Source=DESKTOP-KO9KLMV\\SQLEXPRESS;Initial Catalog=project1;Integrated Security=True;TrustServerCertificate=true";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT* FROM SINHVIEN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {// ham cua dataGridview khi click vao
            int i;
            i = dataGridView1.CurrentRow.Index;
            txt_Id.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_Masv.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_Ten.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_lop.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_diem.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt_DiaChi.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            dataGridView1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {// ham Add them Sinh vien vao dataGridview cua button Add khi bam thi no se them vao database ;
            command = connection.CreateCommand();
            command.CommandText = " INSERT INTO SINHVIEN VALUES('" + txt_Id.Text + "','" + txt_Masv.Text + "','" + txt_Ten.Text + "','" + txt_lop.Text + "','" + txt_diem.Text + "','" + txt_DiaChi.Text + "')";
            command.ExecuteNonQuery();
            LoadData();
        }
        private void button4_Click(object sender, EventArgs e)
        {// ham Delete cua button delete khi bam thi delete;
            command = connection.CreateCommand();
            //de delete from dataGridview;
            command.Parameters.AddWithValue("@Id", txt_Id.Text);
            command.CommandText = "DELETE FROM SINHVIEN WHERE Id = @Id";
            command.ExecuteNonQuery();
            LoadData();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {//ham button Edit
            //B1
            //*Tạo command
            //SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command = connection.CreateCommand();
            command.Parameters.AddWithValue("@Id", txt_Id.Text);
            command.Parameters.AddWithValue("@MaSV", txt_Masv.Text);
            command.Parameters.AddWithValue("@TenSV", txt_Ten.Text);
            command.Parameters.AddWithValue("@Lop", txt_lop.Text);
            command.Parameters.AddWithValue("@Diem", txt_diem.Text);
            command.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text);
            // Thiết lập chuỗi lệnh SQL cho command
            command.CommandText = "UPDATE SINHVIEN SET MaSv=@MaSv, TenSv=@TenSv, LOP=@LOP,Diem=@Diem, DiaChi=@DiaChi WHERE Id = @Id";
            // Thực thi lệnh SQL
            command.ExecuteNonQuery();
            LoadData();

        }
        private void button1_Click(object sender, EventArgs e)
        {//button Clear data tu cac textbox thuc hien nhu sau:
            txt_Id.Text = "";
            txt_Masv.Text = "";
            txt_Ten.Text = "";
            txt_lop.Text = "";
            txt_diem.Text = "";
            txt_DiaChi.Text = "";
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to Leave now?", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txt_Tim_kiem_TextChanged(object sender, EventArgs e)
        {
            string ten = txt_Tim_kiem.Text;
            command = connection.CreateCommand();
            command.CommandText = "select * from SINHVIEN where TenSv like '"+ten+"%'";
            command.ExecuteNonQuery();
            //LoadData();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}