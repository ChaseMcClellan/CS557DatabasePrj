using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;

namespace CS557DatabasePrj.UI
{
    public partial class frmCreateEmployee : Form
    {
        public frmCreateEmployee()
        {
            InitializeComponent();
            this.Load += frmCreateEmployee_Load;
        }

        // ---------- Load picklists when form opens ----------
        private async void frmCreateEmployee_Load(object sender, EventArgs e)
        {
            await LoadBranchesAsync();
            await LoadUsersAsync();
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
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNum.Text))
            {
                MessageBox.Show("Employee number is required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNum.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirst.Text))
            {
                MessageBox.Show("First name is required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtFirst.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLast.Text))
            {
                MessageBox.Show("Last name is required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLast.Focus();
                return;
            }
            if (cmbBranch.SelectedValue == null)
            {
                MessageBox.Show("Please select a branch.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (cmbUser.SelectedValue == null)
            {
                MessageBox.Show("Please select a user.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string empNum = txtNum.Text.Trim();
            string first = txtFirst.Text.Trim();
            string last = txtLast.Text.Trim();

            int branchId = (int)cmbBranch.SelectedValue;
            int userId = (int)cmbUser.SelectedValue;

            var emp = new Employee
            {
                EmployeeNumber = empNum,
                FirstName = first,
                LastName = last,
                BranchId = branchId,
                UserId = userId
            };

            try
            {
                var repo = new EmployeeRepository();
                var id = await repo.InsertAsync(emp);

                MessageBox.Show("Employee created successfully.",
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
