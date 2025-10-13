using CS557DatabasePrj.DL.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace CS557DatabasePrj
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Close();
        }










        private async void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = DbConnectionFactory.CreateConnection();
                var one = await conn.ExecuteScalarAsync<int>("SELECT 1;");
                var users = await conn.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Users;");
                MessageBox.Show($"DB OK (SELECT 1 = {one}). Users count = {users}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB error: " + ex.Message);
            }
        }
    }
}
