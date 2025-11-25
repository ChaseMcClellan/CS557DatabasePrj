using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.DB;
using CS557DatabasePrj.DL.Repo;
using CS557DatabasePrj.UI; 
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CS557DatabasePrj
{
    public partial class frmUser : Form
    {
        private static User? currentUser = AppSession.CurrentUser;
        private static List<Account>? accounts = currentUser.Accounts?.ToList();

        public frmUser()
        {
            InitializeComponent();
            if (currentUser != null)
            {
                lblHelloUser.Text = "Hello " + currentUser.FirstName + "!";
                dgvAccounts.DataSource = accounts;


            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppSession.CurrentUser = null;
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Close();
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
                    "SELECT COUNT(*) FROM Accounts WHERE Id = @uid;",
                    new { uid = AppSession.CurrentUser.Id });

                MessageBox.Show(
                    $"DB OK (SELECT 1 = {one}). Accounts for {AppSession.CurrentUser.FirstName}: {accountCount}" + " current user " +
                    "accounts: " + AppSession.CurrentUser.Accounts.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB error: " + ex.Message);
            }
        }
        private async void btnNewcard_Click(object sender, EventArgs e)
        {
            var repository = new CardRepository();

            try
            {
                Card card = new Card
                {
                    AccountId = currentUser.Id,
                    CardNumber = txtCardNumber.Text,
                    ExpiryDate = dtpExpiryDate.Value,
                    Cvv = txtCvv.Text
                };

                await repository.InsertAsync(card);

                MessageBox.Show("Card created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("try again");
            }
        }

        private async void btnNewtransaction_Click(object sender, EventArgs e)
        {
            TransactionRepository repository = new TransactionRepository();

            try
            {
                Transaction transaction = new Transaction
                {
                    AccountId = currentUser.Id,    // THE ACCOUNT THAT OWNS THE TRANSACTION
                    Amount = decimal.Parse(txtAmount.Text),
                };

                await repository.InsertAsync(transaction);

                MessageBox.Show("Transaction saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("try again");
            }
        }


        private async void btnNewLoanPayment_Click(object sender, EventArgs e)
        {
            try
            {
                var repository = new LoanPaymentRepository();
                var accountRepository = new AccountRepository();

                // Load the logged-in user's account from DB
                Account account = await accountRepository.GetByIdAsync(currentUser.Id);

                // Validate the text box input
                if (!decimal.TryParse(txtAmount.Text, out decimal amount))
                {
                    MessageBox.Show("Please enter a valid amount.");
                    return;
                }

                // Create the payment
                LoanPayment loanPayment = new LoanPayment
                {
                    Amount = amount
                };

                // Save to DB
                await repository.InsertAsync(loanPayment, account.Id);

                MessageBox.Show("Payment saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Try again");
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {

        }
    }
}
