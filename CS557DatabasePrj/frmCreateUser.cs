using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using CS557DatabasePrj.Security;

namespace CS557DatabasePrj.UI
{
    public partial class frmCreateUser : Form
    {
        public frmCreateUser()
        {
            InitializeComponent();
            this.Load += frmCreateUser_Load;
        }

        private async void frmCreateUser_Load(object sender, EventArgs e)
        {
            await LoadBranchesAsync();
        }

        private async Task LoadBranchesAsync()
        {
            try
            {
                var branchRepo = new BranchRepository();
                var branches = (await branchRepo.GetAllAsync()).ToList();

                cmbBranch.DataSource = branches;
                cmbBranch.DisplayMember = "Name";
                cmbBranch.ValueMember = "Id";
                if (branches.Count > 0)
                    cmbBranch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading branches: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GenerateAccountNumber()
        {
            return DateTime.Now.Ticks.ToString();
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {

            string user = txtUsername.Text.Trim();
            string first = txtFirst.Text.Trim();
            string last = txtLast.Text.Trim();
            string rawPassword = txtPassword.Text;
            string passwordHash = CryptoService.HashPassword(rawPassword);

            string rawSSN = txtSSN.Text.Trim();
            string ssnHash = string.IsNullOrWhiteSpace(rawSSN)
                ? null
                : CryptoService.HashSSN(rawSSN);
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            int branchId = (int)cmbBranch.SelectedValue;

            int roleId = chkAdmin.Checked ? 1 : 2;

            var newUser = new User(user, passwordHash, first, last, email, phone, ssnHash, roleId, branchId);

            try
            {
                var userRepo = new UserRepository();
                int newUserId = await userRepo.InsertAsync(newUser);
                var accountRepo = new AccountRepository();

                var checkingAccount = new Account
                {
                    OwnerUserId = newUserId,
                    BranchId = branchId,
                    AccountType = AccountType.Checking,
                    CurrentBalance = 0m,
                    CurrencyCode = "USD",
                    AccountNumber = GenerateAccountNumber()
                };

                var savingsAccount = new Account
                {
                    OwnerUserId = newUserId,
                    BranchId = branchId,
                    AccountType = AccountType.Savings,
                    CurrentBalance = 0m,
                    CurrencyCode = "USD",
                    AccountNumber = GenerateAccountNumber()
                };

                await accountRepo.InsertAsync(checkingAccount);
                await accountRepo.InsertAsync(savingsAccount);

                MessageBox.Show("User and default accounts created successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB insert error: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
