using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class FrmViewEmployees : Form
    {
        private List<Employee> _employees = new();

        public FrmViewEmployees()
        {
            InitializeComponent();

            this.Load += FrmViewEmployees_Load;
            dgvEmployee.SelectionChanged += dgvEmployee_SelectionChanged;
        }

        private async void FrmViewEmployees_Load(object sender, EventArgs e)
        {
            await LoadBranchesAsync();
            await LoadUsersAsync();
            await ReloadEmployeesGridAsync();
        }

        private async Task LoadBranchesAsync()
        {
            try
            {
                var repo = new BranchRepository();
                var branches = (await repo.GetAllAsync()).ToList();

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
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ReloadEmployeesGridAsync()
        {
            try
            {
                var repo = new EmployeeRepository();
                _employees = (await repo.GetAllAsync()).ToList();

                dgvEmployee.AutoGenerateColumns = false;
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = _employees;

                if (dgvEmployee.Rows.Count > 0)
                    dgvEmployee.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow?.DataBoundItem is not Employee emp)
                return;

            txtName.Text = emp.FirstName;
            txtLast.Text = emp.LastName;

            if (cmbBranch.DataSource != null)
            {
                try
                {
                    cmbBranch.SelectedValue = emp.BranchId;
                }
                catch { //ignore
                }
            }

            if (cmbUser.DataSource != null)
            {
                try
                {
                    cmbUser.SelectedValue = emp.UserId;
                }
                catch { //ignore
                }
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow?.DataBoundItem is not Employee original)
            {
                MessageBox.Show("Please select an employee.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("First name is required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLast.Text))
            {
                MessageBox.Show("Last name is required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLast.Focus();
                return;
            }

            if (cmbBranch.SelectedValue == null)
            {
                MessageBox.Show("Please select a branch.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbUser.SelectedValue == null)
            {
                MessageBox.Show("Please select a user.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int branchId = (int)cmbBranch.SelectedValue;
            int userId = (int)cmbUser.SelectedValue;

            var updated = new Employee
            {
                Id = original.Id,

                EmployeeNumber = original.EmployeeNumber,

                FirstName = txtName.Text.Trim(),
                LastName = txtLast.Text.Trim(),
                BranchId = branchId,
                UserId = userId,

                CreatedUtc = original.CreatedUtc,
                CreatedByUserId = original.CreatedByUserId,
                UpdatedUtc = DateTime.UtcNow,
                UpdatedByUserId = AppSession.CurrentUser.Id,
                IsActive = original.IsActive
            };

            try
            {
                var repo = new EmployeeRepository();
                bool ok = await repo.UpdateAsync(updated);

                if (!ok)
                {
                    MessageBox.Show("No rows were updated. It may have been deleted by another user.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Employee updated.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await ReloadEmployeesGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating employee:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow?.DataBoundItem is not Employee emp)
            {
                MessageBox.Show("Please select an employee to delete.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete employee '{emp.FirstName} {emp.LastName}'?",
                "Delete Employee",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var repo = new EmployeeRepository();
                bool ok = await repo.DeleteAsync(emp.Id);

                if (!ok)
                {
                    MessageBox.Show("Employee could not be deleted.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Employee deleted.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await ReloadEmployeesGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting employee:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
