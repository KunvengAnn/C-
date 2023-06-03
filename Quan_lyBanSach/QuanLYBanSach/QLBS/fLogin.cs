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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Ann" && txtPassword.Text == "123")
            {
                MessageBox.Show("Login succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fMain fM = new fMain();
                this.Hide();
                fM.Show();
            }
            else
            {
                MessageBox.Show("Invalid User or Password!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = "";
                txtUser.Text = "";
            }
        }
    }
}
