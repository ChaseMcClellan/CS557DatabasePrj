namespace CS557DatabasePrj.UI
{
    partial class FrmViewEmployees
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
            employeeBindingSource = new BindingSource(components);
            lblCity = new Label();
            label1 = new Label();
            txtLast = new TextBox();
            lblDate = new Label();
            lblName = new Label();
            txtName = new TextBox();
            dgvEmployee = new DataGridView();
            employeeNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            branchIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            branchDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdByUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedByUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isActiveDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnClose = new Button();
            cmbBranch = new ComboBox();
            cmbUser = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            SuspendLayout();
            // 
            // employeeBindingSource
            // 
            employeeBindingSource.DataSource = typeof(BL.Employee);
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(26, 360);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(30, 15);
            lblCity.TabIndex = 49;
            lblCity.Text = "User";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 276);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 47;
            label1.Text = "Lastname";
            // 
            // txtLast
            // 
            txtLast.Location = new Point(79, 273);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(100, 23);
            txtLast.TabIndex = 46;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(9, 320);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(44, 15);
            lblDate.TabIndex = 45;
            lblDate.Text = "Branch";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(15, 232);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 15);
            lblName.TabIndex = 44;
            lblName.Text = "Firstname";
            // 
            // txtName
            // 
            txtName.Location = new Point(80, 229);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 38;
            // 
            // dgvEmployee
            // 
            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Columns.AddRange(new DataGridViewColumn[] { employeeNumberDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, branchIdDataGridViewTextBoxColumn, userIdDataGridViewTextBoxColumn, branchDataGridViewTextBoxColumn, userDataGridViewTextBoxColumn, createdUtcDataGridViewTextBoxColumn, createdByUserIdDataGridViewTextBoxColumn, updatedUtcDataGridViewTextBoxColumn, updatedByUserIdDataGridViewTextBoxColumn, isActiveDataGridViewCheckBoxColumn, idDataGridViewTextBoxColumn });
            dgvEmployee.DataSource = employeeBindingSource;
            dgvEmployee.Location = new Point(15, 18);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.Size = new Size(736, 150);
            dgvEmployee.TabIndex = 37;
            // 
            // employeeNumberDataGridViewTextBoxColumn
            // 
            employeeNumberDataGridViewTextBoxColumn.DataPropertyName = "EmployeeNumber";
            employeeNumberDataGridViewTextBoxColumn.HeaderText = "EmployeeNumber";
            employeeNumberDataGridViewTextBoxColumn.Name = "employeeNumberDataGridViewTextBoxColumn";
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
            // branchIdDataGridViewTextBoxColumn
            // 
            branchIdDataGridViewTextBoxColumn.DataPropertyName = "BranchId";
            branchIdDataGridViewTextBoxColumn.HeaderText = "BranchId";
            branchIdDataGridViewTextBoxColumn.Name = "branchIdDataGridViewTextBoxColumn";
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            userIdDataGridViewTextBoxColumn.HeaderText = "UserId";
            userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            // 
            // branchDataGridViewTextBoxColumn
            // 
            branchDataGridViewTextBoxColumn.DataPropertyName = "Branch";
            branchDataGridViewTextBoxColumn.HeaderText = "Branch";
            branchDataGridViewTextBoxColumn.Name = "branchDataGridViewTextBoxColumn";
            // 
            // userDataGridViewTextBoxColumn
            // 
            userDataGridViewTextBoxColumn.DataPropertyName = "User";
            userDataGridViewTextBoxColumn.HeaderText = "User";
            userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
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
            // btnDelete
            // 
            btnDelete.Location = new Point(489, 381);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 51);
            btnDelete.TabIndex = 36;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(605, 381);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(105, 51);
            btnUpdate.TabIndex = 35;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(716, 409);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 34;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // cmbBranch
            // 
            cmbBranch.FormattingEnabled = true;
            cmbBranch.Location = new Point(72, 316);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(121, 23);
            cmbBranch.TabIndex = 52;
            // 
            // cmbUser
            // 
            cmbUser.FormattingEnabled = true;
            cmbUser.Location = new Point(72, 357);
            cmbUser.Name = "cmbUser";
            cmbUser.Size = new Size(121, 23);
            cmbUser.TabIndex = 53;
            // 
            // FrmViewEmployees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbUser);
            Controls.Add(cmbBranch);
            Controls.Add(lblCity);
            Controls.Add(label1);
            Controls.Add(txtLast);
            Controls.Add(lblDate);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(dgvEmployee);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnClose);
            Name = "FrmViewEmployees";
            Text = "FrmViewEmployees";
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource employeeBindingSource;
        private Label lblCity;
        private Label label1;
        private TextBox txtLast;
        private Label lblDate;
        private Label lblName;
        private TextBox txtName;
        private DataGridView dgvEmployee;
        private DataGridViewTextBoxColumn employeeNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn branchIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn branchDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdByUserIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedByUserIdDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnClose;
        private ComboBox cmbBranch;
        private ComboBox cmbUser;
    }
}