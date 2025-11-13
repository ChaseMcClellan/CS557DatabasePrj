using System;
using System.Windows.Forms;
using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;

namespace CS557DatabasePrj.UI
{
    public partial class frmCreateBranch : Form
    {
        public frmCreateBranch()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnCreateBranch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Branch name is required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            string name = txtName.Text.Trim();
            string address1 = txtAddress.Text.Trim();
            string address2 = txtAddress2.Text.Trim();
            string city = txtCity.Text.Trim();
            string state = txtState.Text.Trim();
            string postal = txtPostal.Text.Trim();
            string phone = txtPhone.Text.Trim();

            var b = new Branch
            {
                Name = name,
                AddressLine1 = address1,
                AddressLine2 = address2,
                City = city,
                State = state,
                PostalCode = postal,
                Phone = phone
            };

            try
            {
                var repo = new BranchRepository();
                var id = await repo.InsertAsync(b);

                MessageBox.Show("Branch created successfully.",
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
