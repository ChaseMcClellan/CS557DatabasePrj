namespace CS557DatabasePrj.UI
{
    partial class FrmViewUsers
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
            dgvUser = new DataGridView();
            usernameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            passwordHashDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ssnHashDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roleIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            homeBranchIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            homeBranchDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdByUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedByUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isActiveDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userBindingSource = new BindingSource(components);
            btnDelete = new Button();
            btnUpdate = new Button();
            btnClose = new Button();
            lblBranch = new Label();
            cmbBranch = new ComboBox();
            lblSSN = new Label();
            lblPhone = new Label();
            lblLast = new Label();
            lblFirst = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            chkAdmin = new CheckBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            txtSSN = new TextBox();
            txtPhone = new TextBox();
            txtLast = new TextBox();
            txtFirst = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvUser
            // 
            dgvUser.AutoGenerateColumns = false;
            dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUser.Columns.AddRange(new DataGridViewColumn[] { usernameDataGridViewTextBoxColumn, passwordHashDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, ssnHashDataGridViewTextBoxColumn, roleIdDataGridViewTextBoxColumn, homeBranchIdDataGridViewTextBoxColumn, roleDataGridViewTextBoxColumn, homeBranchDataGridViewTextBoxColumn, createdUtcDataGridViewTextBoxColumn, createdByUserIdDataGridViewTextBoxColumn, updatedUtcDataGridViewTextBoxColumn, updatedByUserIdDataGridViewTextBoxColumn, isActiveDataGridViewCheckBoxColumn, idDataGridViewTextBoxColumn });
            dgvUser.DataSource = userBindingSource;
            dgvUser.Location = new Point(15, 18);
            dgvUser.Name = "dgvUser";
            dgvUser.Size = new Size(736, 150);
            dgvUser.TabIndex = 57;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            // 
            // passwordHashDataGridViewTextBoxColumn
            // 
            passwordHashDataGridViewTextBoxColumn.DataPropertyName = "PasswordHash";
            passwordHashDataGridViewTextBoxColumn.HeaderText = "PasswordHash";
            passwordHashDataGridViewTextBoxColumn.Name = "passwordHashDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            // 
            // ssnHashDataGridViewTextBoxColumn
            // 
            ssnHashDataGridViewTextBoxColumn.DataPropertyName = "SsnHash";
            ssnHashDataGridViewTextBoxColumn.HeaderText = "SsnHash";
            ssnHashDataGridViewTextBoxColumn.Name = "ssnHashDataGridViewTextBoxColumn";
            // 
            // roleIdDataGridViewTextBoxColumn
            // 
            roleIdDataGridViewTextBoxColumn.DataPropertyName = "RoleId";
            roleIdDataGridViewTextBoxColumn.HeaderText = "RoleId";
            roleIdDataGridViewTextBoxColumn.Name = "roleIdDataGridViewTextBoxColumn";
            // 
            // homeBranchIdDataGridViewTextBoxColumn
            // 
            homeBranchIdDataGridViewTextBoxColumn.DataPropertyName = "HomeBranchId";
            homeBranchIdDataGridViewTextBoxColumn.HeaderText = "HomeBranchId";
            homeBranchIdDataGridViewTextBoxColumn.Name = "homeBranchIdDataGridViewTextBoxColumn";
            // 
            // roleDataGridViewTextBoxColumn
            // 
            roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            roleDataGridViewTextBoxColumn.HeaderText = "Role";
            roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            // 
            // homeBranchDataGridViewTextBoxColumn
            // 
            homeBranchDataGridViewTextBoxColumn.DataPropertyName = "HomeBranch";
            homeBranchDataGridViewTextBoxColumn.HeaderText = "HomeBranch";
            homeBranchDataGridViewTextBoxColumn.Name = "homeBranchDataGridViewTextBoxColumn";
            // 
            // createdUtcDataGridViewTextBoxColumn
            // 
            createdUtcDataGridViewTextBoxColumn.DataPropertyName = "CreatedUtc";
            createdUtcDataGridViewTextBoxColumn.HeaderText = "CreatedUtc";
            createdUtcDataGridViewTextBoxColumn.Name = "createdUtcDataGridViewTextBoxColumn";
            // 
            // createdByUserIdDataGridViewTextBoxColumn
            // 
            createdByUserIdDataGridViewTextBoxColumn.DataPropertyName = "CreatedByUserId";
            createdByUserIdDataGridViewTextBoxColumn.HeaderText = "CreatedByUserId";
            createdByUserIdDataGridViewTextBoxColumn.Name = "createdByUserIdDataGridViewTextBoxColumn";
            // 
            // updatedUtcDataGridViewTextBoxColumn
            // 
            updatedUtcDataGridViewTextBoxColumn.DataPropertyName = "UpdatedUtc";
            updatedUtcDataGridViewTextBoxColumn.HeaderText = "UpdatedUtc";
            updatedUtcDataGridViewTextBoxColumn.Name = "updatedUtcDataGridViewTextBoxColumn";
            // 
            // updatedByUserIdDataGridViewTextBoxColumn
            // 
            updatedByUserIdDataGridViewTextBoxColumn.DataPropertyName = "UpdatedByUserId";
            updatedByUserIdDataGridViewTextBoxColumn.HeaderText = "UpdatedByUserId";
            updatedByUserIdDataGridViewTextBoxColumn.Name = "updatedByUserIdDataGridViewTextBoxColumn";
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            isActiveDataGridViewCheckBoxColumn.HeaderText = "IsActive";
            isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(BL.User);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(489, 381);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 51);
            btnDelete.TabIndex = 56;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(605, 381);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(105, 51);
            btnUpdate.TabIndex = 55;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(716, 409);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 54;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblBranch
            // 
            lblBranch.AutoSize = true;
            lblBranch.Location = new Point(248, 308);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(50, 15);
            lblBranch.TabIndex = 76;
            lblBranch.Text = "Branch: ";
            // 
            // cmbBranch
            // 
            cmbBranch.FormattingEnabled = true;
            cmbBranch.Location = new Point(304, 303);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(121, 23);
            cmbBranch.TabIndex = 75;
            // 
            // lblSSN
            // 
            lblSSN.AutoSize = true;
            lblSSN.Location = new Point(288, 242);
            lblSSN.Name = "lblSSN";
            lblSSN.Size = new Size(31, 15);
            lblSSN.TabIndex = 72;
            lblSSN.Text = "SSN:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(231, 197);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(88, 15);
            lblPhone.TabIndex = 71;
            lblPhone.Text = "Phone Number";
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(52, 351);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(63, 15);
            lblLast.TabIndex = 70;
            lblLast.Text = "Last Name";
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(51, 309);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(64, 15);
            lblFirst.TabIndex = 69;
            lblFirst.Text = "First Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(78, 270);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 68;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(57, 237);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 67;
            lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(54, 200);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 66;
            lblUsername.Text = "Username";
            // 
            // chkAdmin
            // 
            chkAdmin.AutoSize = true;
            chkAdmin.Location = new Point(336, 271);
            chkAdmin.Name = "chkAdmin";
            chkAdmin.Size = new Size(78, 19);
            chkAdmin.TabIndex = 65;
            chkAdmin.Text = "Is Admin?";
            chkAdmin.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 267);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 64;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 234);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 63;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(120, 197);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 62;
            // 
            // txtSSN
            // 
            txtSSN.Location = new Point(325, 237);
            txtSSN.Name = "txtSSN";
            txtSSN.Size = new Size(100, 23);
            txtSSN.TabIndex = 61;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(325, 194);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 60;
            // 
            // txtLast
            // 
            txtLast.Location = new Point(120, 348);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(100, 23);
            txtLast.TabIndex = 59;
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(120, 306);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(100, 23);
            txtFirst.TabIndex = 58;
            // 
            // FrmViewUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblBranch);
            Controls.Add(cmbBranch);
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
            Controls.Add(txtFirst);
            Controls.Add(dgvUser);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnClose);
            Name = "FrmViewUsers";
            Text = "FrmViewUsers";
            ((System.ComponentModel.ISupportInitialize)dgvUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvUser;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn passwordHashDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ssnHashDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roleIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn homeBranchIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn homeBranchDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdByUserIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedByUserIdDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private BindingSource userBindingSource;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnClose;
        private Label lblBranch;
        private ComboBox cmbBranch;
        private Label lblSSN;
        private Label lblPhone;
        private Label lblLast;
        private Label lblFirst;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblUsername;
        private CheckBox chkAdmin;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private TextBox txtSSN;
        private TextBox txtPhone;
        private TextBox txtLast;
        private TextBox txtFirst;
    }
}