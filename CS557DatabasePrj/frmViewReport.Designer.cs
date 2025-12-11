namespace CS557DatabasePrj.UI
{
    partial class frmViewReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBranchName = new Label();
            this.lblReconciliationPeriod = new Label();
            this.dgvReconciliationReport = new DataGridView();
            this.lblTotalAccountsChecked = new Label();
            this.lblAccountsWithDiscrepancies = new Label();
            this.lblAccountsOK = new Label();
            this.lblMinorDiscrepancies = new Label();
            this.lblMajorDiscrepancies = new Label();
            this.lblTotalDiscrepancyAmount = new Label();
            this.btnClose = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvReconciliationReport)).BeginInit();
            this.SuspendLayout();

            // 
            // lblBranchName
            // 
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.Location = new Point(20, 20);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new Size(100, 23);
            this.lblBranchName.Text = "Branch Name:";

            // 
            // lblReconciliationPeriod
            // 
            this.lblReconciliationPeriod.AutoSize = true;
            this.lblReconciliationPeriod.Location = new Point(20, 60);
            this.lblReconciliationPeriod.Name = "lblReconciliationPeriod";
            this.lblReconciliationPeriod.Size = new Size(150, 23);
            this.lblReconciliationPeriod.Text = "Reconciliation Period:";

            // 
            // dgvReconciliationReport
            // 
            this.dgvReconciliationReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReconciliationReport.Location = new Point(20, 100);
            this.dgvReconciliationReport.Name = "dgvReconciliationReport";
            this.dgvReconciliationReport.Size = new Size(900, 300);
            this.dgvReconciliationReport.AutoGenerateColumns = false;
            this.dgvReconciliationReport.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { HeaderText = "Account Number", DataPropertyName = "AccountNumber" },
                new DataGridViewTextBoxColumn { HeaderText = "Owner Name", DataPropertyName = "OwnerName" },
                new DataGridViewTextBoxColumn { HeaderText = "Stored Balance", DataPropertyName = "StoredBalance" },
                new DataGridViewTextBoxColumn { HeaderText = "Calculated Balance", DataPropertyName = "CalculatedBalance" },
                new DataGridViewTextBoxColumn { HeaderText = "Discrepancy", DataPropertyName = "Discrepancy" },
                new DataGridViewTextBoxColumn { HeaderText = "Transaction Count", DataPropertyName = "TransactionCount" },
                new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status" }
            });

            // 
            // lblTotalAccountsChecked
            // 
            this.lblTotalAccountsChecked.AutoSize = true;
            this.lblTotalAccountsChecked.Location = new Point(20, 420);
            this.lblTotalAccountsChecked.Name = "lblTotalAccountsChecked";
            this.lblTotalAccountsChecked.Size = new Size(170, 23);
            this.lblTotalAccountsChecked.Text = "Total Accounts Checked:";

            // 
            // lblAccountsWithDiscrepancies
            // 
            this.lblAccountsWithDiscrepancies.AutoSize = true;
            this.lblAccountsWithDiscrepancies.Location = new Point(20, 460);
            this.lblAccountsWithDiscrepancies.Name = "lblAccountsWithDiscrepancies";
            this.lblAccountsWithDiscrepancies.Size = new Size(220, 23);
            this.lblAccountsWithDiscrepancies.Text = "Accounts with Discrepancies:";

            // 
            // lblAccountsOK
            // 
            this.lblAccountsOK.AutoSize = true;
            this.lblAccountsOK.Location = new Point(20, 500);
            this.lblAccountsOK.Name = "lblAccountsOK";
            this.lblAccountsOK.Size = new Size(150, 23);
            this.lblAccountsOK.Text = "Accounts OK:";

            // 
            // lblMinorDiscrepancies
            // 
            this.lblMinorDiscrepancies.AutoSize = true;
            this.lblMinorDiscrepancies.Location = new Point(20, 540);
            this.lblMinorDiscrepancies.Name = "lblMinorDiscrepancies";
            this.lblMinorDiscrepancies.Size = new Size(170, 23);
            this.lblMinorDiscrepancies.Text = "Minor Discrepancies:";

            // 
            // lblMajorDiscrepancies
            // 
            this.lblMajorDiscrepancies.AutoSize = true;
            this.lblMajorDiscrepancies.Location = new Point(20, 580);
            this.lblMajorDiscrepancies.Name = "lblMajorDiscrepancies";
            this.lblMajorDiscrepancies.Size = new Size(170, 23);
            this.lblMajorDiscrepancies.Text = "Major Discrepancies:";

            // 
            // lblTotalDiscrepancyAmount
            // 
            this.lblTotalDiscrepancyAmount.AutoSize = true;
            this.lblTotalDiscrepancyAmount.Location = new Point(20, 620);
            this.lblTotalDiscrepancyAmount.Name = "lblTotalDiscrepancyAmount";
            this.lblTotalDiscrepancyAmount.Size = new Size(220, 23);
            this.lblTotalDiscrepancyAmount.Text = "Total Discrepancy Amount:";

            // 
            // btnClose
            // 
            this.btnClose.Location = new Point(850, 650);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(75, 30);
            this.btnClose.Text = "Close";
            this.btnClose.Click += BtnClose_Click;

            // 
            // frmViewReport
            // 
            this.ClientSize = new Size(960, 700);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.lblReconciliationPeriod);
            this.Controls.Add(this.dgvReconciliationReport);
            this.Controls.Add(this.lblTotalAccountsChecked);
            this.Controls.Add(this.lblAccountsWithDiscrepancies);
            this.Controls.Add(this.lblAccountsOK);
            this.Controls.Add(this.lblMinorDiscrepancies);
            this.Controls.Add(this.lblMajorDiscrepancies);
            this.Controls.Add(this.lblTotalDiscrepancyAmount);
            this.Controls.Add(this.btnClose);
            this.Name = "frmViewReport";
            this.Text = "Reconciliation Report";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconciliationReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}