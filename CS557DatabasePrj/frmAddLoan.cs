using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class frmAddLoan : Form
    {
        private User? _currentUser;
        private List<Account> _accounts = new();

        public frmAddLoan()
        {
            InitializeComponent();

            this.Load += frmAddLoan_Load;
        }

        private async void frmAddLoan_Load(object sender, EventArgs e)
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
            LoadTermOptions();
        }

        private async Task LoadAccountsAsync()
        {
            try
            {
                var acctRepo = new AccountRepository();
                _accounts = (await acctRepo.GetByUserAsync(_currentUser!.Id)).ToList();

                cmbAccount.DataSource = _accounts;
                cmbAccount.DisplayMember = "AccountNumber";
                cmbAccount.ValueMember = "Id";

                if (_accounts.Count > 0)
                    cmbAccount.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading accounts: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTermOptions()
        {
            cmbTerm.Items.Clear();
            cmbTerm.Items.Add("12");
            cmbTerm.Items.Add("24");
            cmbTerm.Items.Add("36");

            if (cmbTerm.Items.Count > 0)
                cmbTerm.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("No user is logged in.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbAccount.SelectedItem is not Account account)
            {
                MessageBox.Show("Please select an account for this loan.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrinciple.Text, out decimal principal) || principal <= 0)
            {
                MessageBox.Show("Please enter a valid principal amount greater than zero.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrinciple.Focus();
                return;
            }

            if (cmbTerm.SelectedItem == null || !int.TryParse(cmbTerm.SelectedItem.ToString(), out int termMonths))
            {
                MessageBox.Show("Please select a valid loan term (in months).",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal annualRate = 0.065m;
            txtRate.Text = annualRate.ToString();
            var loan = new Loan
            {
                AccountId = account.Id,
                Principal = principal,
                AnnualInterestRate = annualRate,
                TermMonths = termMonths,
                StartUtc = DateTime.UtcNow,
                Status = LoanStatus.Pending,
                CreatedUtc = DateTime.UtcNow,
                CreatedByUserId = _currentUser.Id,
                IsActive = true
            };

            try
            {
                var loanRepo = new LoanRepository();
                int loanId = await loanRepo.InsertAsync(loan);

                var acctRepo = new AccountRepository();
                await acctRepo.ApplyLoanFundingAsync(account.Id, principal, _currentUser.Id, loanId);

                MessageBox.Show($"Loan #{loanId} created successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating loan:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
