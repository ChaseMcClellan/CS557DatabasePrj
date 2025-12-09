namespace CS557DatabasePrj
{
    partial class frmUser
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
            lblHelloUser = new Label();
            btnExit = new Button();
            btnLogout = new Button();
            btnTestConnection = new Button();
            dgvAccounts = new DataGridView();
            btnTransfer = new Button();
            dgvTransactions = new DataGridView();
            btnLoan = new Button();
            lblAccount = new Label();
            lblTransactions = new Label();
            btnPayLoan = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // lblHelloUser
            // 
            lblHelloUser.AutoSize = true;
            lblHelloUser.Location = new Point(12, 25);
            lblHelloUser.Name = "lblHelloUser";
            lblHelloUser.Size = new Size(46, 15);
            lblHelloUser.TabIndex = 0;
            lblHelloUser.Text = "Hello {}";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(1242, 544);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(1161, 544);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(12, 546);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(75, 23);
            btnTestConnection.TabIndex = 3;
            btnTestConnection.Text = "Debug";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // dgvAccounts
            // 
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new Point(254, 42);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.RowHeadersWidth = 82;
            dgvAccounts.Size = new Size(1045, 150);
            dgvAccounts.TabIndex = 5;
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(12, 142);
            btnTransfer.Margin = new Padding(2, 1, 2, 1);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(173, 50);
            btnTransfer.TabIndex = 7;
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // dgvTransactions
            // 
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(254, 283);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersWidth = 82;
            dgvTransactions.Size = new Size(1045, 150);
            dgvTransactions.TabIndex = 9;
            // 
            // btnLoan
            // 
            btnLoan.Location = new Point(12, 76);
            btnLoan.Margin = new Padding(2, 1, 2, 1);
            btnLoan.Name = "btnLoan";
            btnLoan.Size = new Size(173, 50);
            btnLoan.TabIndex = 11;
            btnLoan.Text = "Take out a Loan";
            btnLoan.UseVisualStyleBackColor = true;
            btnLoan.Click += btnLoan_Click;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(257, 18);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(57, 15);
            lblAccount.TabIndex = 13;
            lblAccount.Text = "Accounts";
            // 
            // lblTransactions
            // 
            lblTransactions.AutoSize = true;
            lblTransactions.Location = new Point(254, 254);
            lblTransactions.Name = "lblTransactions";
            lblTransactions.Size = new Size(72, 15);
            lblTransactions.TabIndex = 14;
            lblTransactions.Text = "Transactions";
            // 
            // btnPayLoan
            // 
            btnPayLoan.Location = new Point(11, 206);
            btnPayLoan.Margin = new Padding(2, 1, 2, 1);
            btnPayLoan.Name = "btnPayLoan";
            btnPayLoan.Size = new Size(173, 50);
            btnPayLoan.TabIndex = 15;
            btnPayLoan.Text = "Pay Loan";
            btnPayLoan.UseVisualStyleBackColor = true;
            btnPayLoan.Click += btnPayLoan_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1174, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 16;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // frmUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 579);
            Controls.Add(btnRefresh);
            Controls.Add(btnPayLoan);
            Controls.Add(lblTransactions);
            Controls.Add(lblAccount);
            Controls.Add(btnLoan);
            Controls.Add(dgvTransactions);
            Controls.Add(btnTransfer);
            Controls.Add(dgvAccounts);
            Controls.Add(btnTestConnection);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Controls.Add(lblHelloUser);
            Name = "frmUser";
            Text = "User";
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHelloUser;
        private Button btnExit;
        private Button btnLogout;
        private Button btnTestConnection;
        private DataGridView dgvAccounts;
        private Button btnTransfer;
        private DataGridView dgvTransactions;
        private Button btnLoan;
        private Label lblAccount;
        private Label lblTransactions;
        private Button btnPayLoan;
        private Button btnRefresh;
    }
}