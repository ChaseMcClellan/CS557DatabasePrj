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
            lblBalance = new Label();
            dgvAccounts = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            SuspendLayout();
            // 
            // lblHelloUser
            // 
            lblHelloUser.AutoSize = true;
            lblHelloUser.Location = new Point(40, 25);
            lblHelloUser.Name = "lblHelloUser";
            lblHelloUser.Size = new Size(46, 15);
            lblHelloUser.TabIndex = 0;
            lblHelloUser.Text = "Hello {}";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(687, 386);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(606, 386);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(105, 386);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(75, 23);
            btnTestConnection.TabIndex = 3;
            btnTestConnection.Text = "Debug";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(38, 102);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(48, 15);
            lblBalance.TabIndex = 4;
            lblBalance.Text = "Balance";
            // 
            // dgvAccounts
            // 
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new Point(313, 25);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.Size = new Size(409, 150);
            dgvAccounts.TabIndex = 5;
            // 
            // frmUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvAccounts);
            Controls.Add(lblBalance);
            Controls.Add(btnTestConnection);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Controls.Add(lblHelloUser);
            Name = "frmUser";
            Text = "User";
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHelloUser;
        private Button btnExit;
        private Button btnLogout;
        private Button btnTestConnection;
        private Label lblBalance;
        private DataGridView dgvAccounts;
    }
}