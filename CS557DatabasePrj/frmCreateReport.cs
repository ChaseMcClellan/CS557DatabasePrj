using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS557DatabasePrj.UI
{
    public partial class frmCreateReport : Form
    {
        public frmCreateReport()
        {
            InitializeComponent();
            this.Load += frmCreateReport_Load;
            btnClose.Click += btnClose_Click;
        }

        private async void frmCreateReport_Load(object sender, EventArgs e)
        {
            await LoadBranchesAsync();
        }

        private async Task LoadBranchesAsync()
        {
            try
            {
                var repo = new BranchRepository();
                var branches = (await repo.GetAllAsync()).ToList();

                cboBranch.DataSource = branches;
                cboBranch.DisplayMember = "Name";
                cboBranch.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading branches: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            // Validate input
            if (!ValidateInput(out int year, out int month, out int branchId))
                return;

            try
            {
                // Use the new repository
                var repo = new ReconciliationRepository();
                var results = await repo.GetReportAsync(year, month, branchId);

                if (results == null)
                {
                    MessageBox.Show("No data returned for the selected branch and period.",
                        "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Show the results in the report viewer form
                var resultsForm = new frmViewReport(results);
                resultsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput(out int year, out int month, out int branchId)
        {
            year = 0;
            month = 0;
            branchId = 0;

            if (cboBranch.SelectedValue == null)
            {
                MessageBox.Show("Please select a branch.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtYear.Text, out year) || !int.TryParse(txtMonth.Text, out month))
            {
                MessageBox.Show("Invalid year or month format.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            branchId = (int)cboBranch.SelectedValue;
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
