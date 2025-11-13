using CS557DatabasePrj.BL;
using CS557DatabasePrj.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj
{
    public partial class frmAdmin : Form
    {

        private static User? currentUser = AppSession.CurrentUser;

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppSession.CurrentUser = null;
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Close();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            frmCreateUser frmCreateUser = new frmCreateUser();
            frmCreateUser.Show();
        }
    }
}
