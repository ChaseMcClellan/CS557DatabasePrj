using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private async void btnSave_Click(object sender, EventArgs e)
        {

            string user = txtUsername.Text.Trim();
            string first = txtFirst.Text.Trim();
            string last = txtLast.Text.Trim();
            string SSN = txtSSN.Text.Trim();
            string pass = txtPassword.Text;
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            int branchId = (int)cmbBranch.SelectedValue;

            int roleId = chkAdmin.Checked ? 1 : 2;

            var newUser = new User(user, pass, first, last, email, phone, SSN, roleId, branchId);

            try
            {
                var repo = new UserRepository();
                var id = await repo.InsertAsync(newUser);

                MessageBox.Show("User created successfully.",
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
