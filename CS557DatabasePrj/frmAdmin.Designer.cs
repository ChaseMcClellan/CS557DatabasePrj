namespace CS557DatabasePrj
{
    partial class frmAdmin
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
            btnExit = new Button();
            btnLogout = new Button();
            btnNewUser = new Button();
            btnCreateBranch = new Button();
            btnDeposit = new Button();
            btnCreateEmployee = new Button();
            btnViewUser = new Button();
            btnViewEmployees = new Button();
            btnViewBranches = new Button();
            btnTransactions = new Button();
            btnWithdrawl = new Button();
            btnReport = new Button();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(815, 539);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(86, 31);
            btnExit.TabIndex = 0;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(712, 539);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(86, 31);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "<-] Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnNewUser
            // 
            btnNewUser.Location = new Point(45, 43);
            btnNewUser.Margin = new Padding(3, 4, 3, 4);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Size = new Size(203, 108);
            btnNewUser.TabIndex = 2;
            btnNewUser.Text = "Create New User";
            btnNewUser.UseVisualStyleBackColor = true;
            btnNewUser.Click += btnNewUser_Click;
            // 
            // btnCreateBranch
            // 
            btnCreateBranch.Location = new Point(465, 43);
            btnCreateBranch.Margin = new Padding(3, 4, 3, 4);
            btnCreateBranch.Name = "btnCreateBranch";
            btnCreateBranch.Size = new Size(203, 108);
            btnCreateBranch.TabIndex = 3;
            btnCreateBranch.Text = "Create Branch";
            btnCreateBranch.UseVisualStyleBackColor = true;
            btnCreateBranch.Click += btnCreateBranch_Click;
            // 
            // btnDeposit
            // 
            btnDeposit.Location = new Point(675, 43);
            btnDeposit.Margin = new Padding(3, 4, 3, 4);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(203, 108);
            btnDeposit.TabIndex = 4;
            btnDeposit.Text = "Add Deposit";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnCreateEmployee
            // 
            btnCreateEmployee.Location = new Point(255, 43);
            btnCreateEmployee.Margin = new Padding(3, 4, 3, 4);
            btnCreateEmployee.Name = "btnCreateEmployee";
            btnCreateEmployee.Size = new Size(203, 108);
            btnCreateEmployee.TabIndex = 5;
            btnCreateEmployee.Text = "Create Employee";
            btnCreateEmployee.UseVisualStyleBackColor = true;
            btnCreateEmployee.Click += btnCreateEmployee_Click;
            // 
            // btnViewUser
            // 
            btnViewUser.Location = new Point(45, 233);
            btnViewUser.Margin = new Padding(3, 4, 3, 4);
            btnViewUser.Name = "btnViewUser";
            btnViewUser.Size = new Size(203, 108);
            btnViewUser.TabIndex = 6;
            btnViewUser.Text = "View all Users";
            btnViewUser.UseVisualStyleBackColor = true;
            btnViewUser.Click += btnViewUser_Click;
            // 
            // btnViewEmployees
            // 
            btnViewEmployees.Location = new Point(255, 233);
            btnViewEmployees.Margin = new Padding(3, 4, 3, 4);
            btnViewEmployees.Name = "btnViewEmployees";
            btnViewEmployees.Size = new Size(203, 108);
            btnViewEmployees.TabIndex = 7;
            btnViewEmployees.Text = "View All Employees";
            btnViewEmployees.UseVisualStyleBackColor = true;
            btnViewEmployees.Click += btnViewEmployees_Click;
            // 
            // btnViewBranches
            // 
            btnViewBranches.Location = new Point(465, 233);
            btnViewBranches.Margin = new Padding(3, 4, 3, 4);
            btnViewBranches.Name = "btnViewBranches";
            btnViewBranches.Size = new Size(203, 108);
            btnViewBranches.TabIndex = 8;
            btnViewBranches.Text = "View All Branches";
            btnViewBranches.UseVisualStyleBackColor = true;
            btnViewBranches.Click += btnViewBranches_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.Location = new Point(675, 233);
            btnTransactions.Margin = new Padding(3, 4, 3, 4);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Size = new Size(203, 108);
            btnTransactions.TabIndex = 9;
            btnTransactions.Text = "View All Transactions";
            btnTransactions.UseVisualStyleBackColor = true;
            btnTransactions.Click += btnTransactions_Click;
            // 
            // btnWithdrawl
            // 
            btnWithdrawl.Location = new Point(45, 392);
            btnWithdrawl.Margin = new Padding(3, 4, 3, 4);
            btnWithdrawl.Name = "btnWithdrawl";
            btnWithdrawl.Size = new Size(203, 104);
            btnWithdrawl.TabIndex = 10;
            btnWithdrawl.Text = "Add Withdrawl";
            btnWithdrawl.UseVisualStyleBackColor = true;
            btnWithdrawl.Click += btnWithdrawl_Click;
            // 
            // btnReport
            // 
            btnReport.Location = new Point(255, 392);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(203, 104);
            btnReport.TabIndex = 11;
            btnReport.Text = "Create Reconcilliation Report";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnReport);
            Controls.Add(btnWithdrawl);
            Controls.Add(btnTransactions);
            Controls.Add(btnViewBranches);
            Controls.Add(btnViewEmployees);
            Controls.Add(btnViewUser);
            Controls.Add(btnCreateEmployee);
            Controls.Add(btnDeposit);
            Controls.Add(btnCreateBranch);
            Controls.Add(btnNewUser);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmAdmin";
            Text = "frmAdmin";
            ResumeLayout(false);
        }

        #endregion

        private Button btnExit;
        private Button btnLogout;
        private Button btnNewUser;
        private Button btnCreateBranch;
        private Button btnDeposit;
        private Button btnCreateEmployee;
        private Button btnViewUser;
        private Button btnViewEmployees;
        private Button btnViewBranches;
        private Button btnTransactions;
        private Button btnWithdrawl;
        private Button btnReport;
    }
}