using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.DB;
using CS557DatabasePrj.UI;
using Dapper;
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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
            if(AppSession.CurrentUser != null)
            {
                lblHelloUser.Text = "Hello " + AppSession.CurrentUser.FirstName + "!";
                var accounts = AppSession.CurrentUser.Accounts?.ToList() ?? new List<Account>();
                listAccounts.DisplayMember = nameof(Account.AccountNumber);
                listAccounts.ValueMember = nameof(Account.Id);
                listAccounts.DataSource = accounts;
            }
            
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




        private async void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppSession.CurrentUser == null)
                {
                    MessageBox.Show("No user logged in.");
                    return;
                }

                using var conn = DbConnectionFactory.CreateConnection();

                var one = await conn.ExecuteScalarAsync<int>("SELECT 1;");

                var accountCount = await conn.ExecuteScalarAsync<int>(
                    "SELECT COUNT(*) FROM Accounts WHERE Id = @uid;",
                    new { uid = AppSession.CurrentUser.Id });

                MessageBox.Show(
                    $"DB OK (SELECT 1 = {one}). Accounts for {AppSession.CurrentUser.FirstName}: {accountCount}" + " current user " +
                    "accounts: " + AppSession.CurrentUser.Accounts.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB error: " + ex.Message);
            }
        }



    }
}
