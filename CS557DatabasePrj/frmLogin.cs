using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using CS557DatabasePrj.Security;
using CS557DatabasePrj.UI;
using Dapper;
using System;
using System.Windows.Forms;

namespace CS557DatabasePrj
{
    public partial class frmLogin : Form
    {
        private readonly UserRepository _users = new UserRepository();

        public frmLogin()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
            CancelButton = btnExit;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }

            try
            {
                var user = await _users.GetByUsernameAsync(username);
                if (user is null || !user.IsActive)
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }

                bool valid = CryptoService.VerifyPassword(password, user.PasswordHash);

                if (!valid)
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }

                // Success — store session and show next form
                AppSession.CurrentUser = user;

                Form nextForm = (user.RoleId == 1) ? new frmAdmin() : new frmUser();

                nextForm.FormClosed += (s, _) => this.Close();
                nextForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}");
            }
        }
    }
}
