using CS557DatabasePrj.BL;
using CS557DatabasePrj.DL.Repo;
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
    public partial class frmViewReport : Form
    {
        private Label lblBranchName;
        private Label lblReconciliationPeriod;
        private DataGridView dgvReconciliationReport;
        private Label lblTotalAccountsChecked;
        private Label lblAccountsWithDiscrepancies;
        private Label lblAccountsOK;
        private Label lblMinorDiscrepancies;
        private Label lblMajorDiscrepancies;
        private Label lblTotalDiscrepancyAmount;
        private Button btnClose;

        public frmViewReport(ReconciliationResults results)
        {
            InitializeComponent();
            DisplayResults(results);
        }



        private void DisplayResults(ReconciliationResults results)
        {
            // Display Branch Info
            lblBranchName.Text = results.BranchInfo.BranchName;
            lblReconciliationPeriod.Text = results.BranchInfo.ReconciliationPeriod;

            // Display Reconciliation Report in DataGridView
            dgvReconciliationReport.DataSource = results.ReconciliationReport;

            // Display Summary
            lblTotalAccountsChecked.Text = $"Total Accounts Checked: {results.Summary.TotalAccountsChecked}";
            lblAccountsWithDiscrepancies.Text = $"Accounts with Discrepancies: {results.Summary.AccountsWithDiscrepancies}";
            lblAccountsOK.Text = $"Accounts OK: {results.Summary.AccountsOK}";
            lblMinorDiscrepancies.Text = $"Minor Discrepancies: {results.Summary.MinorDiscrepancies}";
            lblMajorDiscrepancies.Text = $"Major Discrepancies: {results.Summary.MajorDiscrepancies}";
            lblTotalDiscrepancyAmount.Text = $"Total Discrepancy Amount: {results.Summary.TotalDiscrepancyAmount:C2}";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
