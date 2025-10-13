using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;  // repository namespace
using CS557DatabasePrj.UI;
using Dapper;
using System;
using System.Windows.Forms;

namespace CS557DatabasePrj
{
    public partial class frmLogin : Form
    {
        //Declare the field here (this is what fixes CS0103)
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // optional: DB warm-up
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

                // TEMP password match (until hashing is added)
                if (!string.Equals(password, user.PasswordHash, StringComparison.Ordinal))
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
