using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class frmPayLoan : Form
    {
        private User? _currentUser;
        private List<Account> _accounts = new();
        private List<Loan> _loans = new();

        public frmPayLoan()
        {
            InitializeComponent();

            this.Load += frmPayLoan_Load;
            dgvAccount.SelectionChanged += dgvAccount_SelectionChanged;
        }

        private async void frmPayLoan_Load(object sender, EventArgs e)
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
            if (_currentUser == null) return;

            try
            {
                var acctRepo = new AccountRepository();
                _accounts = (await acctRepo.GetByUserAsync(_currentUser.Id)).ToList();

                dgvAccount.AutoGenerateColumns = true;
                dgvAccount.DataSource = null;
                dgvAccount.DataSource = _accounts;

                if (dgvAccount.Rows.Count > 0)
                    dgvAccount.Rows[0].Selected = true;
                else
                {
                    dgvLoan.DataSource = null;
                    _loans.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading accounts: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow?.DataBoundItem is not Account acct)
                return;

            await LoadLoansForAccountAsync(acct.Id);
        }

        private async Task LoadLoansForAccountAsync(int accountId)
        {
            try
            {
                var loanRepo = new LoanRepository();
                var loan = await loanRepo.GetByAccountAsync(accountId);

                _loans.Clear();
                if (loan != null)
                    _loans.Add(loan);

                dgvLoan.AutoGenerateColumns = true;
                dgvLoan.DataSource = null;
                dgvLoan.DataSource = _loans;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading loans: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCurrentLoanBalance_Click(object sender, EventArgs e)
        {
            if (dgvLoan.CurrentRow?.DataBoundItem is not Loan loan)
            {
                MessageBox.Show("Please select a loan first.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtAmount.Text = loan.Principal.ToString("0.00");
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("No user is logged in.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvAccount.CurrentRow?.DataBoundItem is not Account acct)
            {
                MessageBox.Show("Please select an account to pay from.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvLoan.CurrentRow?.DataBoundItem is not Loan loan)
            {
                MessageBox.Show("Please select a loan to pay.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid payment amount greater than zero.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var payment = new LoanPayment
            {
                LoanId = loan.Id,
                Amount = amount,
                DueDateUtc = DateTime.UtcNow,
                PaidDateUtc = DateTime.UtcNow,

                PrincipalPortion = amount,
                InterestPortion = 0m,

                Reference = $"Loan payment from Account #{acct.Id}",

                CreatedUtc = DateTime.UtcNow,
                CreatedByUserId = _currentUser.Id,
                IsActive = true
            };

            try
            {
                var payRepo = new LoanPaymentRepository();
                int pid = await payRepo.InsertAsync(payment, acct.Id);

                MessageBox.Show(
                    $"Loan payment recorded (Payment #{pid}).",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await LoadAccountsAsync();
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Insufficient funds"))
            {
                MessageBox.Show("This account has insufficient funds for that loan payment.",
                    "Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing loan payment:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
