using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Transaction = CS557DatabasePrj.BL.Transaction;


namespace CS557DatabasePrj.UI
{
    public partial class FrmViewTransactions : Form
    {
        private List<Transaction> _transactions = new();

        public FrmViewTransactions()
        {
            InitializeComponent();

            this.Load += FrmViewTransactions_Load;
            dgvTransactions.SelectionChanged += dgvTransactions_SelectionChanged;
        }

        private async void FrmViewTransactions_Load(object sender, EventArgs e)
        {
            LoadKindCombo();
            await ReloadTransactionsGridAsync();
        }

        private void LoadKindCombo()
        {
            cmbKind.DataSource = Enum.GetValues(typeof(TransactionKind));
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.CurrentRow?.DataBoundItem is not Transaction selected)
            {
                MessageBox.Show("Please select a transaction first.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to undo this transaction?\n" +
                "This will create a reversing transaction for audit purposes.",
                "Undo Transaction",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var repo = new TransactionRepository();
                int undoId = await repo.UndoAsync(selected, AppSession.CurrentUser.Id);

                MessageBox.Show($"Undo transaction #{undoId} created.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await ReloadTransactionsGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error undoing transaction:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ReloadTransactionsGridAsync()
        {
            try
            {
                var repo = new TransactionRepository();
                _transactions = (await repo.GetAllAsync()).ToList();

                dgvTransactions.AutoGenerateColumns = false;
                dgvTransactions.DataSource = null;
                dgvTransactions.DataSource = _transactions;

                if (dgvTransactions.Rows.Count > 0)
                    dgvTransactions.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void dgvTransactions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTransactions.CurrentRow?.DataBoundItem is not Transaction t)
                return;

            txtAmount.Text = t.Amount.ToString("0.00");

            if (cmbKind.DataSource != null)
                cmbKind.SelectedItem = t.Kind;

            txtDate.Text = t.PostedUtc.ToLocalTime().ToString("yyyy-MM-dd HH:mm");

            txtMemo.Text = t.Memo ?? string.Empty;

            try
            {
                var acctRepo = new AccountRepository();
                var acct = await acctRepo.GetByIdAsync(t.AccountId);
                if (acct != null)
                    txtAccount.Text = $"{acct.AccountNumber} ({acct.AccountType})";
                else
                    txtAccount.Text = t.AccountId.ToString();
            }
            catch
            {
                txtAccount.Text = t.AccountId.ToString();
            }
        }


        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.CurrentRow?.DataBoundItem is not Transaction original)
            {
                MessageBox.Show("Please select a transaction first.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Enum.TryParse<TransactionKind>(cmbKind.SelectedItem?.ToString(), out var kind))
            {
                MessageBox.Show("Please select a valid transaction type.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(txtDate.Text, out var postedLocal))
            {
                MessageBox.Show("Please enter a valid date.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updated = new Transaction
            {
                Id = original.Id,
                AccountId = original.AccountId,
                Kind = kind,
                Amount = amount,
                Memo = txtMemo.Text?.Trim(),
                PostedUtc = postedLocal.ToUniversalTime(),
                RelatedEntityId = original.RelatedEntityId,
                CreatedUtc = original.CreatedUtc,
                CreatedByUserId = original.CreatedByUserId,
                UpdatedUtc = DateTime.UtcNow,
                UpdatedByUserId = AppSession.CurrentUser.Id,
                IsActive = original.IsActive
            };

            try
            {
                var repo = new TransactionRepository();
                await repo.UpdateWithBalanceAsync(original, updated);

                MessageBox.Show("Transaction updated.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await ReloadTransactionsGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating transaction:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
