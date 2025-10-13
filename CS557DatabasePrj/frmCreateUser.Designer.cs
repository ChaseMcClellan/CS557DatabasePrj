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
            textBox1 = new TextBox();
            lstBranch = new ListView();
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
            chkAdmin.Location = new Point(334, 121);
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
            // textBox1
            // 
            textBox1.Location = new Point(112, 117);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 17;
            // 
            // lstBranch
            // 
            lstBranch.Location = new Point(285, 170);
            lstBranch.Name = "lstBranch";
            lstBranch.Size = new Size(121, 97);
            lstBranch.TabIndex = 19;
            lstBranch.UseCompatibleStateImageBehavior = false;
            // 
            // frmCreateUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 347);
            Controls.Add(lstBranch);
            Controls.Add(lblPasswordConfirm);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private ListView lstBranch;
    }
}