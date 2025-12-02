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
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(713, 404);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 0;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(623, 404);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "<-] Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnNewUser
            // 
            btnNewUser.Location = new Point(39, 32);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Size = new Size(178, 81);
            btnNewUser.TabIndex = 2;
            btnNewUser.Text = "Create New User";
            btnNewUser.UseVisualStyleBackColor = true;
            btnNewUser.Click += btnNewUser_Click;
            // 
            // btnCreateBranch
            // 
            btnCreateBranch.Location = new Point(407, 32);
            btnCreateBranch.Name = "btnCreateBranch";
            btnCreateBranch.Size = new Size(178, 81);
            btnCreateBranch.TabIndex = 3;
            btnCreateBranch.Text = "Create Branch";
            btnCreateBranch.UseVisualStyleBackColor = true;
            btnCreateBranch.Click += btnCreateBranch_Click;
            // 
            // btnDeposit
            // 
            btnDeposit.Location = new Point(591, 32);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(178, 81);
            btnDeposit.TabIndex = 4;
            btnDeposit.Text = "Add Deposit";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnCreateEmployee
            // 
            btnCreateEmployee.Location = new Point(223, 32);
            btnCreateEmployee.Name = "btnCreateEmployee";
            btnCreateEmployee.Size = new Size(178, 81);
            btnCreateEmployee.TabIndex = 5;
            btnCreateEmployee.Text = "Create Employee";
            btnCreateEmployee.UseVisualStyleBackColor = true;
            btnCreateEmployee.Click += btnCreateEmployee_Click;
            // 
            // btnViewUser
            // 
            btnViewUser.Location = new Point(39, 175);
            btnViewUser.Name = "btnViewUser";
            btnViewUser.Size = new Size(178, 81);
            btnViewUser.TabIndex = 6;
            btnViewUser.Text = "View all Users";
            btnViewUser.UseVisualStyleBackColor = true;
            btnViewUser.Click += btnViewUser_Click;
            // 
            // btnViewEmployees
            // 
            btnViewEmployees.Location = new Point(223, 175);
            btnViewEmployees.Name = "btnViewEmployees";
            btnViewEmployees.Size = new Size(178, 81);
            btnViewEmployees.TabIndex = 7;
            btnViewEmployees.Text = "View All Employees";
            btnViewEmployees.UseVisualStyleBackColor = true;
            btnViewEmployees.Click += btnViewEmployees_Click;
            // 
            // btnViewBranches
            // 
            btnViewBranches.Location = new Point(407, 175);
            btnViewBranches.Name = "btnViewBranches";
            btnViewBranches.Size = new Size(178, 81);
            btnViewBranches.TabIndex = 8;
            btnViewBranches.Text = "View All Branches";
            btnViewBranches.UseVisualStyleBackColor = true;
            btnViewBranches.Click += btnViewBranches_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.Location = new Point(591, 175);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Size = new Size(178, 81);
            btnTransactions.TabIndex = 9;
            btnTransactions.Text = "View All Transactions";
            btnTransactions.UseVisualStyleBackColor = true;
            btnTransactions.Click += btnTransactions_Click;
            // 
            // btnWithdrawl
            // 
            btnWithdrawl.Location = new Point(39, 294);
            btnWithdrawl.Name = "btnWithdrawl";
            btnWithdrawl.Size = new Size(178, 78);
            btnWithdrawl.TabIndex = 10;
            btnWithdrawl.Text = "Add Withdrawl";
            btnWithdrawl.UseVisualStyleBackColor = true;
            btnWithdrawl.Click += btnWithdrawl_Click;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}