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
            this.Hide();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            frmCreateUser frmCreateUser = new frmCreateUser();
            frmCreateUser.Show();
        }

        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            var frm = new frmCreateEmployee();
            frm.Show();
        }

        private void btnCreateBranch_Click(object sender, EventArgs e)
        {
            var frm = new frmCreateBranch();
            frm.Show();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            var frm = new frmAddDeposit();
            frm.Show();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            var frm = new FrmViewUsers();
            frm.Show();
        }

        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            var frm = new FrmViewEmployees();
            frm.Show();
        }

        private void btnViewBranches_Click(object sender, EventArgs e)
        {
            var frm = new FrmViewBranches();
            frm.Show();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            var frm = new FrmViewTransactions();
            frm.Show();
        }

        private void btnWithdrawl_Click(object sender, EventArgs e)
        {
            var frm = new frmAddWithdrawl();
            frm.Show();
        }
    }
}
