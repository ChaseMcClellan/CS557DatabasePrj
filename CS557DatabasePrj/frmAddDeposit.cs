using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class frmAddDeposit : Form
    {
        public frmAddDeposit()
        {
            InitializeComponent();

            this.Load += frmAddDeposit_Load;
            cmbUser.SelectedIndexChanged += cmbUser_SelectedIndexChanged;
        }

        private async void frmAddDeposit_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
            LoadSources();
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

        private void LoadSources()
        {
            cmbSource.Items.Clear();
            cmbSource.Items.AddRange(new object[]
            {
                "Cash",
                "Check",
                "Cashier's Check",
                "Money Order",
                "Mobile Deposit",
                "Wire Transfer",
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
                if (cmbUser.SelectedItem is null)
                {
                    cmbAccount.DataSource = null;
                    return;
                }

                int ownerUserId;

                // Sometimes SelectedValue is already an int, sometimes it's still the User object.
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
                    // Nothing usable yet
                    cmbAccount.DataSource = null;
                    return;
                }

                var acctRepo = new AccountRepository();
                var accounts = (await acctRepo.GetByUserAsync(ownerUserId)).ToList();

                cmbAccount.DataSource = accounts;
                cmbAccount.DisplayMember = "AccountNumber";  // or whatever you prefer
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
