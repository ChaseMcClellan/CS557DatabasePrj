using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class FrmViewBranches : Form
    {
        private List<Branch> _branches = new();

        public FrmViewBranches()
        {
            InitializeComponent();

            this.Load += FrmViewBranches_Load;
            dgvBranch.SelectionChanged += dgvBranch_SelectionChanged;
        }

        // ---------------- FORM LOAD ----------------
        private async void FrmViewBranches_Load(object sender, EventArgs e)
        {
            await ReloadBranchesGridAsync();
        }

        private async Task ReloadBranchesGridAsync()
        {
            try
            {
                var repo = new BranchRepository();
                _branches = (await repo.GetAllAsync()).ToList();

                dgvBranch.AutoGenerateColumns = false;
                dgvBranch.DataSource = null;
                dgvBranch.DataSource = _branches;

                if (dgvBranch.Rows.Count > 0)
                    dgvBranch.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading branches: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBranch_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBranch.CurrentRow?.DataBoundItem is not Branch b)
                return;

            txtName.Text = b.Name;
            txtAddress.Text = b.AddressLine1;
            txtAddress2.Text = b.AddressLine2 ?? string.Empty;
            txtCity.Text = b.City;
            txtState.Text = b.State;
            txtPostal.Text = b.PostalCode;
            txtPhone.Text = b.Phone ?? string.Empty;
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBranch.CurrentRow?.DataBoundItem is not Branch original)
            {
                MessageBox.Show("Please select a branch.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Branch name is required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("City is required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCity.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtState.Text))
            {
                MessageBox.Show("State is required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtState.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPostal.Text))
            {
                MessageBox.Show("Postal code is required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPostal.Focus();
                return;
            }

            var updated = new Branch
            {
                Id = original.Id,

                Name = txtName.Text.Trim(),
                AddressLine1 = txtAddress.Text.Trim(),
                AddressLine2 = string.IsNullOrWhiteSpace(txtAddress2.Text) ? null : txtAddress2.Text.Trim(),
                City = txtCity.Text.Trim(),
                State = txtState.Text.Trim(),
                PostalCode = txtPostal.Text.Trim(),
                Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),

                CreatedUtc = original.CreatedUtc,
                CreatedByUserId = original.CreatedByUserId,

                UpdatedUtc = DateTime.UtcNow,
                UpdatedByUserId = AppSession.CurrentUser.Id,
                IsActive = original.IsActive
            };

            try
            {
                var repo = new BranchRepository();
                bool ok = await repo.UpdateAsync(updated);

                if (!ok)
                {
                    MessageBox.Show("No rows were updated. It may have been deleted by another user.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Branch updated.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await ReloadBranchesGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating branch:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBranch.CurrentRow?.DataBoundItem is not Branch b)
            {
                MessageBox.Show("Please select a branch to delete.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete branch '{b.Name}'?\n" +
                "This action cannot be undone.",
                "Delete Branch",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var repo = new BranchRepository();
                bool ok = await repo.DeleteAsync(b.Id);

                if (!ok)
                {
                    MessageBox.Show("Branch could not be deleted.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Branch deleted.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await ReloadBranchesGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting branch:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
