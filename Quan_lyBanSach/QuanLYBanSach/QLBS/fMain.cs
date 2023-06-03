using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBS
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhanVien fnv = new fNhanVien();
            this.Hide();
            fnv.ShowDialog();
            this.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            fKhachHang fkhach = new fKhachHang();
            this.Hide(); 
            fkhach.ShowDialog();
            this.Show();
        }

        private void mnuSachHangHoa_Click(object sender, EventArgs e)
        {
           fC_SachHangHoa fs = new fC_SachHangHoa();
            this.Hide();
            fs.ShowDialog();
            this.Show();
        }

        private void hóaĐơnBànHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fHoaDonDatHang fHD = new fHoaDonDatHang();
            this.Hide();
            fHD.ShowDialog();
            this.Show();
            //this.Dispose();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Do you Want To Close Application now??", "Question?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if(rs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tìmKiểmHóaĐơnDặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTimKiemHoaDonDatHang fTim = new fTimKiemHoaDonDatHang();
            this.Hide(); fTim.ShowDialog(); this.Show();
        }
    }
}
