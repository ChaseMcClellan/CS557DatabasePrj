using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class frmAddDeposit : Form
    {
        public frmAddDeposit()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbAccount.SelectedItem is not Account account)
            {
                MessageBox.Show("Please select an account.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid deposit amount greater than zero.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var source = cmbSource.Text?.Trim();
            if (string.IsNullOrWhiteSpace(source))
            {
                MessageBox.Show("Please select or enter a deposit source (e.g., Cash, Check #).",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dep = new Deposit
            {
                AccountId = account.Id,
                Amount = amount,
                Source = source,
                ReceivedUtc = DateTime.UtcNow,

                CreatedUtc = DateTime.UtcNow,
                CreatedByUserId = AppSession.CurrentUser.Id,
                IsActive = true
            };

            try
            {
                var repo = new DepositRepository();
                int depId = await repo.InsertAsync(dep);

                MessageBox.Show($"Deposit #{depId} has been recorded and the account balance updated.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error saving the deposit:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
