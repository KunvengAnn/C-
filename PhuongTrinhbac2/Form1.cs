using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhuongTrinhbac2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void GiaiPt()
        {
            double A, B, C;
            if (!double.TryParse(txtA.Text, out A) || A == 0)
            {
                MessageBox.Show("A phai la so va khac 0 !!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Thoát khỏi hàm khi A = 0
            }

            if (!double.TryParse(txtB.Text, out B))
            {
                MessageBox.Show("B phai la so nhe!!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Thoát khỏi hàm khi B không phải là số
            }

            if (!double.TryParse(txtC.Text, out C))
            {
                MessageBox.Show("C phai la so nhe!!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Thoát khỏi hàm khi C không phải là số
            }

            double Delta = Math.Pow(B, 2) - 4 * A * C;

            if (Delta > 0)
            {
                double x1 = (-B + Math.Sqrt(Delta)) / (2 * A);
                double x2 = (-B - Math.Sqrt(Delta)) / (2 * A);
                txtKetQua.Text = "Phuong trinh se co 2 nghiem x1=" + x1 + "\tx2=" + x2;
            }
            else if (Delta < 0)
            {
                txtKetQua.Text = "Phuong trinh Vo nghiem!!";
            }
            else
            {
                double x = -B / (2 * A);
                txtKetQua.Text = "Phuong trinh se co 2 nghiem x1=x2=" + x;
            }
        }
        private void btnTinh_Click(object sender, EventArgs e)
        {
            GiaiPt();
        }
    }
}
