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
            components = new System.ComponentModel.Container();
            lblHelloUser = new Label();
            btnExit = new Button();
            btnLogout = new Button();
            btnTestConnection = new Button();
            lblBalance = new Label();
            dgvAccounts = new DataGridView();
            Newtransaction = new Button();
            Newcard = new Button();
            errorProvider1 = new ErrorProvider(components);
            txtAmount = new TextBox();
            dtpExpiryDate = new DateTimePicker();
            txtCardNumber = new TextBox();
            txtCvv = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
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
            btnExit.Margin = new Padding(6);
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
            btnLogout.Margin = new Padding(6);
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
            btnTestConnection.Margin = new Padding(6);
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
            dgvAccounts.Margin = new Padding(6);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.RowHeadersWidth = 82;
            dgvAccounts.Size = new Size(760, 320);
            dgvAccounts.TabIndex = 5;
            // 
            // Newtransaction
            // 
            Newtransaction.Location = new Point(530, 823);
            Newtransaction.Name = "Newtransaction";
            Newtransaction.Size = new Size(252, 46);
            Newtransaction.TabIndex = 7;
            Newtransaction.Text = "Newtransaction";
            Newtransaction.UseVisualStyleBackColor = true;
            // 
            // Newcard
            // 
            Newcard.Location = new Point(355, 823);
            Newcard.Name = "Newcard";
            Newcard.Size = new Size(150, 46);
            Newcard.TabIndex = 8;
            Newcard.Text = "Newcard";
            Newcard.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(485, 469);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(200, 39);
            txtAmount.TabIndex = 9;
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Location = new Point(751, 632);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(400, 39);
            dtpExpiryDate.TabIndex = 10;
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(469, 556);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(200, 39);
            txtCardNumber.TabIndex = 11;
            // 
            // txtCvv
            // 
            txtCvv.Location = new Point(625, 753);
            txtCvv.Name = "txtCvv";
            txtCvv.Size = new Size(200, 39);
            txtCvv.TabIndex = 12;
            // 
            // frmUser
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(txtCvv);
            Controls.Add(txtCardNumber);
            Controls.Add(dtpExpiryDate);
            Controls.Add(txtAmount);
            Controls.Add(Newcard);
            Controls.Add(Newtransaction);
            Controls.Add(dgvAccounts);
            Controls.Add(lblBalance);
            Controls.Add(btnTestConnection);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Controls.Add(lblHelloUser);
            Margin = new Padding(6);
            Name = "frmUser";
            Text = "User";
            Load += frmUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
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
        private Button Newtransaction;
        private Button Newcard;
        private ErrorProvider errorProvider1;
        private TextBox txtAmount;
        private DateTimePicker dtpExpiryDate;
        private TextBox txtCardNumber;
        private TextBox txtCvv;
    }
}