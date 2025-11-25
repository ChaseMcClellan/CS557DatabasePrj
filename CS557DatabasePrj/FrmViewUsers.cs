using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class FrmViewUsers : Form
    {
        private List<User> _users = new();

        public FrmViewUsers()
        {
            InitializeComponent();

            this.Load += FrmViewUsers_Load;
            dgvUser.SelectionChanged += dgvUser_SelectionChanged;
        }

        private async void FrmViewUsers_Load(object sender, EventArgs e)
        {
            await LoadBranchesAsync();
            await ReloadUsersGridAsync();
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

        private async Task ReloadUsersGridAsync()
        {
            try
            {
                var repo = new UserRepository();
                _users = (await repo.GetAllAsync()).ToList();

                dgvUser.AutoGenerateColumns = false;
                dgvUser.DataSource = null;
                dgvUser.DataSource = _users;

                if (dgvUser.Rows.Count > 0)
                    dgvUser.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUser.CurrentRow?.DataBoundItem is not User u)
                return;

            txtUsername.Text = u.Username;
            txtFirst.Text = u.FirstName;
            txtLast.Text = u.LastName;
            txtEmail.Text = u.Email ?? "";
            txtPhone.Text = u.Phone ?? "";
            txtSSN.Text = u.SsnHash ?? "";

            chkAdmin.Checked = u.RoleId == 1;

            if (u.HomeBranchId != null)
            {
                try
                {
                    cmbBranch.SelectedValue = u.HomeBranchId;
                }
                catch
                {
                    cmbBranch.SelectedIndex = -1;
                }
            }
            else
            {
                cmbBranch.SelectedIndex = -1;
            }

            txtPassword.Text = "";
            txtPassConfirm.Text = "";
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUser.CurrentRow?.DataBoundItem is not User original)
            {
                MessageBox.Show("Please select a user first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirst.Text))
            {
                MessageBox.Show("First name is required.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtFirst.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLast.Text))
            {
                MessageBox.Show("Last name is required.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtLast.Focus();
                return;
            }

            int? branchId = cmbBranch.SelectedValue != null
                ? (int?)cmbBranch.SelectedValue
                : null;

            int roleId = chkAdmin.Checked ? 1 : 2;

            var updated = new User
            {
                Id = original.Id,

                Username = txtUsername.Text.Trim(),
                FirstName = txtFirst.Text.Trim(),
                LastName = txtLast.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                SsnHash = string.IsNullOrWhiteSpace(txtSSN.Text) ? null : txtSSN.Text.Trim(),

                RoleId = roleId,
                HomeBranchId = branchId,

                // Keep original password unless new one is entered
                PasswordHash = string.IsNullOrWhiteSpace(txtPassword.Text)
                    ? original.PasswordHash
                    : txtPassword.Text,

                CreatedUtc = original.CreatedUtc,
                CreatedByUserId = original.CreatedByUserId,
                UpdatedUtc = DateTime.UtcNow,
                UpdatedByUserId = AppSession.CurrentUser.Id,
                IsActive = original.IsActive
            };

            try
            {
                var repo = new UserRepository();
                bool ok = await repo.UpdateAsync(updated);

                if (!ok)
                {
                    MessageBox.Show("User could not be updated.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("User updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await ReloadUsersGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUser.CurrentRow?.DataBoundItem is not User u)
            {
                MessageBox.Show("Please select a user to delete.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete user '{u.Username}'?",
                "Delete User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var repo = new UserRepository();
                bool ok = await repo.DeleteAsync(u.Id);

                if (!ok)
                {
                    MessageBox.Show("User could not be deleted.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("User deleted.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await ReloadUsersGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
