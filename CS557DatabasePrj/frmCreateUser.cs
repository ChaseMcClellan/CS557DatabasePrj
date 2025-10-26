using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class frmCreateUser : Form
    {


        public frmCreateUser()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //do verifications
            string user = txtUsername.Text;
            string first = txtFirst.Text;
            string last = txtLast.Text;
            string SSN = txtSSN.Text;//hash needed
            string pass = txtPassword.Text;//hash needed
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            int branch = 0;

            int isAdmin = 0;
            if (chkAdmin.Checked) { 
                isAdmin = 1;
            }

            User newUser = new User(user, pass, first, last, email, phone, SSN, isAdmin, branch);
            //UserRepository.InsertAsync(newUser);
        }
    }
}
