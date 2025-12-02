using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.DB;
using CS557DatabasePrj.DL.Repo;
using CS557DatabasePrj.UI;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj
{
    public partial class frmUser : Form
    {
        private User? _currentUser;
        private List<Account> _accounts = new();
        private List<Transaction> _transactions = new();

        public frmUser()
        {
            InitializeComponent();

            this.Load += frmUser_Load;
            dgvAccounts.SelectionChanged += dgvAccounts_SelectionChanged;
        }

        private async void frmUser_Load(object? sender, EventArgs e)
        {
            _currentUser = AppSession.CurrentUser;

            if (_currentUser == null)
            {
                MessageBox.Show("No user is logged in.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblHelloUser.Text = "Hello " + _currentUser.FirstName + "!";

            await LoadAccountsAsync();
        }

        private async Task LoadAccountsAsync()
        {
            if (_currentUser == null) return;

            try
            {
                var acctRepo = new AccountRepository();
                _accounts = (await acctRepo.GetByUserAsync(_currentUser.Id)).ToList();

                dgvAccounts.AutoGenerateColumns = true;
                dgvAccounts.DataSource = null;
                dgvAccounts.DataSource = _accounts;

                if (dgvAccounts.Rows.Count > 0)
                    dgvAccounts.Rows[0].Selected = true;
                else
                {
                    dgvTransactions.DataSource = null;
                    _transactions.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading accounts: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvAccounts_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow?.DataBoundItem is not Account acct)
                return;

            await LoadTransactionsAsync(acct.Id);
        }

        private async Task LoadTransactionsAsync(int accountId)
        {
            try
            {
                var txRepo = new TransactionRepository();
                _transactions = (await txRepo.GetByAccountAsync(accountId, limit: 50)).ToList();

                dgvTransactions.AutoGenerateColumns = true;
                dgvTransactions.DataSource = null;
                dgvTransactions.DataSource = _transactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppSession.CurrentUser = null;
            var loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        //test
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
                    "SELECT COUNT(*) FROM Accounts WHERE OwnerUserId = @uid;",
                    new { uid = AppSession.CurrentUser.Id });

                MessageBox.Show(
                    $"DB OK (SELECT 1 = {one}). Accounts for {AppSession.CurrentUser.FirstName}: {accountCount}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB error: " + ex.Message);
            }
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            var frm = new frmAddLoan();
            frm.Show();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            var frm = new frmTransfer();
            frm.Show();
        }

        private void btnPayLoan_Click(object sender, EventArgs e)
        {
            var frm = new frmPayLoan();
            frm.Show();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            int? selectedAccountId = null;

            if (dgvAccounts.CurrentRow?.DataBoundItem is Account acct)
            {
                selectedAccountId = acct.Id;
            }

            await LoadAccountsAsync();

            if (selectedAccountId.HasValue && dgvAccounts.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvAccounts.Rows)
                {
                    if (row.DataBoundItem is Account a && a.Id == selectedAccountId.Value)
                    {
                        row.Selected = true;
                        dgvAccounts.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else if (dgvAccounts.Rows.Count > 0)
            {
                dgvAccounts.Rows[0].Selected = true;
                dgvAccounts.CurrentCell = dgvAccounts.Rows[0].Cells[0];
            }
        }

    }
}
