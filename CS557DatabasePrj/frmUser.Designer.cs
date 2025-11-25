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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            SuspendLayout();
            // 
            // lblHelloUser
            // 
            lblHelloUser.AutoSize = true;
            lblHelloUser.Location = new Point(74, 53);
            lblHelloUser.Margin = new Padding(6, 0, 6, 0);
            lblHelloUser.Name = "lblHelloUser";
            lblHelloUser.Size = new Size(91, 32);
            lblHelloUser.TabIndex = 0;
            lblHelloUser.Text = "Hello {}";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(1276, 823);
            btnExit.Margin = new Padding(6, 6, 6, 6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(139, 49);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(1125, 823);
            btnLogout.Margin = new Padding(6, 6, 6, 6);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(139, 49);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(116, 823);
            btnTestConnection.Margin = new Padding(6, 6, 6, 6);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(139, 49);
            btnTestConnection.TabIndex = 3;
            btnTestConnection.Text = "Debug";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(71, 218);
            lblBalance.Margin = new Padding(6, 0, 6, 0);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(96, 32);
            lblBalance.TabIndex = 4;
            lblBalance.Text = "Balance";
            // 
            // dgvAccounts
            // 
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new Point(581, 53);
            dgvAccounts.Margin = new Padding(6, 6, 6, 6);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.RowHeadersWidth = 82;
            dgvAccounts.Size = new Size(760, 320);
            dgvAccounts.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(809, 823);
            button1.Name = "button1";
            button1.Size = new Size(250, 46);
            button1.TabIndex = 6;
            button1.Text = "NewLoanPayment";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(530, 823);
            button2.Name = "button2";
            button2.Size = new Size(252, 46);
            button2.TabIndex = 7;
            button2.Text = "Newtransaction";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(355, 823);
            button3.Name = "button3";
            button3.Size = new Size(150, 46);
            button3.TabIndex = 8;
            button3.Text = "Newcard";
            button3.UseVisualStyleBackColor = true;
            // 
            // frmUser
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvAccounts);
            Controls.Add(lblBalance);
            Controls.Add(btnTestConnection);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Controls.Add(lblHelloUser);
            Margin = new Padding(6, 6, 6, 6);
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
        private Button button1;
        private Button button2;
        private Button button3;
    }
}