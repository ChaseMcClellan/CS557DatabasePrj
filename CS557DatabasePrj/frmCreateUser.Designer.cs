namespace CS557DatabasePrj.UI
{
    partial class frmCreateUser
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
            txtFirst = new TextBox();
            btnSave = new Button();
            txtLast = new TextBox();
            txtPhone = new TextBox();
            txtSSN = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            chkAdmin = new CheckBox();
            lblUsername = new Label();
            lblPassword = new Label();
            lblEmail = new Label();
            lblFirst = new Label();
            lblLast = new Label();
            lblPhone = new Label();
            lblSSN = new Label();
            lblPasswordConfirm = new Label();
            txtPassConfirm = new TextBox();
            cmbBranch = new ComboBox();
            lblBranch = new Label();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(373, 312);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 0;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(112, 196);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(100, 23);
            txtFirst.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(292, 312);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Create User";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtLast
            // 
            txtLast.Location = new Point(112, 238);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(100, 23);
            txtLast.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(317, 43);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 4;
            // 
            // txtSSN
            // 
            txtSSN.Location = new Point(317, 86);
            txtSSN.Name = "txtSSN";
            txtSSN.Size = new Size(100, 23);
            txtSSN.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(112, 46);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(112, 83);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(112, 157);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 8;
            // 
            // chkAdmin
            // 
            chkAdmin.AutoSize = true;
            chkAdmin.Location = new Point(328, 120);
            chkAdmin.Name = "chkAdmin";
            chkAdmin.Size = new Size(78, 19);
            chkAdmin.TabIndex = 9;
            chkAdmin.Text = "Is Admin?";
            chkAdmin.UseVisualStyleBackColor = true;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(46, 49);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 10;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(49, 86);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Password";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(70, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "Email";
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(43, 199);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(64, 15);
            lblFirst.TabIndex = 13;
            lblFirst.Text = "First Name";
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(44, 241);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(63, 15);
            lblLast.TabIndex = 14;
            lblLast.Text = "Last Name";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(223, 46);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(88, 15);
            lblPhone.TabIndex = 15;
            lblPhone.Text = "Phone Number";
            // 
            // lblSSN
            // 
            lblSSN.AutoSize = true;
            lblSSN.Location = new Point(280, 91);
            lblSSN.Name = "lblSSN";
            lblSSN.Size = new Size(31, 15);
            lblSSN.TabIndex = 16;
            lblSSN.Text = "SSN:";
            // 
            // lblPasswordConfirm
            // 
            lblPasswordConfirm.AutoSize = true;
            lblPasswordConfirm.Location = new Point(2, 120);
            lblPasswordConfirm.Name = "lblPasswordConfirm";
            lblPasswordConfirm.Size = new Size(104, 15);
            lblPasswordConfirm.TabIndex = 18;
            lblPasswordConfirm.Text = "Confirm Password";
            // 
            // txtPassConfirm
            // 
            txtPassConfirm.Location = new Point(112, 117);
            txtPassConfirm.Name = "txtPassConfirm";
            txtPassConfirm.Size = new Size(100, 23);
            txtPassConfirm.TabIndex = 17;
            // 
            // cmbBranch
            // 
            cmbBranch.FormattingEnabled = true;
            cmbBranch.Location = new Point(296, 152);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(121, 23);
            cmbBranch.TabIndex = 20;
            // 
            // lblBranch
            // 
            lblBranch.AutoSize = true;
            lblBranch.Location = new Point(240, 157);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(50, 15);
            lblBranch.TabIndex = 21;
            lblBranch.Text = "Branch: ";
            // 
            // frmCreateUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 347);
            Controls.Add(lblBranch);
            Controls.Add(cmbBranch);
            Controls.Add(lblPasswordConfirm);
            Controls.Add(txtPassConfirm);
            Controls.Add(lblSSN);
            Controls.Add(lblPhone);
            Controls.Add(lblLast);
            Controls.Add(lblFirst);
            Controls.Add(lblEmail);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(chkAdmin);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtSSN);
            Controls.Add(txtPhone);
            Controls.Add(txtLast);
            Controls.Add(btnSave);
            Controls.Add(txtFirst);
            Controls.Add(btnExit);
            Name = "frmCreateUser";
            Text = "CreateUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private TextBox txtFirst;
        private Button btnSave;
        private TextBox txtLast;
        private TextBox txtPhone;
        private TextBox txtSSN;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private CheckBox chkAdmin;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblEmail;
        private Label lblFirst;
        private Label lblLast;
        private Label lblPhone;
        private Label lblSSN;
        private Label lblPasswordConfirm;
        private TextBox txtPassConfirm;
        private ComboBox cmbBranch;
        private Label lblBranch;
    }
}