using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class frmAddWithdrawl : Form
    {
        public frmAddWithdrawl()
        {
            InitializeComponent();

            this.Load += frmAddWithdrawl_Load;
            cmbUser.SelectedIndexChanged += cmbUser_SelectedIndexChanged;
        }

        private async void frmAddWithdrawl_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
            LoadMethods();
            await LoadAccountsForSelectedUserAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                var userRepo = new UserRepository();
                var users = (await userRepo.GetAllAsync()).ToList();

                cmbUser.DataSource = users;
                cmbUser.DisplayMember = "Username";
                cmbUser.ValueMember = "Id";

                if (users.Count > 0)
                    cmbUser.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadMethods()
        {
            cmbSource.Items.Clear();
            cmbSource.Items.AddRange(new object[]
            {
                "ATM",
                "Teller",
                "Online",
                "Other"
            });

            if (cmbSource.Items.Count > 0)
                cmbSource.SelectedIndex = 0;
        }

        private async void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadAccountsForSelectedUserAsync();
        }

        private async Task LoadAccountsForSelectedUserAsync()
        {
            try
            {
                if (cmbUser.SelectedValue == null)
                {
                    cmbAccount.DataSource = null;
                    return;
                }

                int ownerUserId;

                if (cmbUser.SelectedValue is int id)
                {
                    ownerUserId = id;
                }
                else if (cmbUser.SelectedItem is User u)
                {
                    ownerUserId = u.Id;
                }
                else
                {
                    cmbAccount.DataSource = null;
                    return;
                }

                var acctRepo = new AccountRepository();
                var accounts = (await acctRepo.GetByUserAsync(ownerUserId)).ToList();

                cmbAccount.DataSource = accounts;
                cmbAccount.DisplayMember = "AccountNumber";
                cmbAccount.ValueMember = "Id";

                if (accounts.Count > 0)
                    cmbAccount.SelectedIndex = 0;
                else
                    cmbAccount.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading accounts: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbUser.SelectedValue == null)
            {
                MessageBox.Show("Please select a user.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbAccount.SelectedItem is not Account account)
            {
                MessageBox.Show("Please select an account.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid withdrawal amount greater than zero.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var method = cmbSource.Text?.Trim();
            if (string.IsNullOrWhiteSpace(method))
            {
                MessageBox.Show("Please select or enter a withdrawal method (e.g., ATM, Teller).",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var w = new Withdrawal
            {
                AccountId = account.Id,
                Amount = amount,
                Method = method,
                ProcessedUtc = DateTime.UtcNow,

                CreatedUtc = DateTime.UtcNow,
                CreatedByUserId = AppSession.CurrentUser.Id,
                IsActive = true
            };

            try
            {
                var repo = new WithdrawalRepository();
                int wid = await repo.InsertAsync(w);

                MessageBox.Show($"Withdrawal #{wid} has been recorded and the account balance updated.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Insufficient funds"))
            {
                MessageBox.Show("This account has insufficient funds for that withdrawal.",
                                "Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error saving the withdrawal:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
