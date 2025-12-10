using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class frmTransfer : Form
    {
        private User? _currentUser;
        private List<Account> _accounts = new();

        public frmTransfer()
        {
            InitializeComponent();

            this.Load += frmTransfer_Load;
        }

        private async void frmTransfer_Load(object sender, EventArgs e)
        {
            _currentUser = AppSession.CurrentUser;

            if (_currentUser == null)
            {
                MessageBox.Show("No user is logged in.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            await LoadAccountsAsync();
        }

        private async Task LoadAccountsAsync()
        {
            try
            {
                var acctRepo = new AccountRepository();
                _accounts = (await acctRepo.GetByUserAsync(_currentUser!.Id)).ToList();

                if (_accounts.Count == 0)
                {
                    MessageBox.Show("You do not have any accounts to transfer between.",
                        "No Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbAccount.DataSource = null;
                    cmbToAccount.DataSource = null;
                    return;
                }

                cmbAccount.DataSource = _accounts.ToList();
                cmbAccount.DisplayMember = "AccountNumber";
                cmbAccount.ValueMember = "Id";

                cmbToAccount.DataSource = _accounts.ToList();
                cmbToAccount.DisplayMember = "AccountNumber";
                cmbToAccount.ValueMember = "Id";

                if (_accounts.Count > 0)
                    cmbAccount.SelectedIndex = 0;
                if (_accounts.Count > 1)
                    cmbToAccount.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading accounts: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private async void btnTranfer_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("No user is logged in.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbAccount.SelectedItem is not Account fromAcct)
            {
                MessageBox.Show("Please select a 'From' account.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbToAccount.SelectedItem is not Account toAcct)
            {
                MessageBox.Show("Please select a 'To' account.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fromAcct.Id == toAcct.Id)
            {
                MessageBox.Show("The 'From' and 'To' accounts must be different.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid transfer amount greater than zero.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            string memo = txtMemo.Text?.Trim();

            var tr = new Transfer
            {
                FromAccountId = fromAcct.Id,
                ToAccountId = toAcct.Id,
                InitiatedByUserId = _currentUser.Id,
                Amount = amount,
                Memo = memo,
                ExecutedUtc = DateTime.UtcNow,

                CreatedUtc = DateTime.UtcNow,
                CreatedByUserId = _currentUser.Id,
                IsActive = true
            };

            try
            {
                var repo = new TransferRepository();
                int transferId = await repo.InsertAsync(tr);

                MessageBox.Show(
                    $"Transfer #{transferId} completed successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAmount.Clear();
                txtMemo.Clear();
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Insufficient funds"))
            {
                MessageBox.Show("The 'From' account has insufficient funds for this transfer.",
                    "Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing transfer:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
