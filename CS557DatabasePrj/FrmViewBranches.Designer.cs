namespace CS557DatabasePrj.UI
{
    partial class FrmViewBranches
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
            lblDate = new Label();
            lblName = new Label();
            Amount = new Label();
            lblMemo = new Label();
            txtPhone = new TextBox();
            txtPostal = new TextBox();
            txtAddress2 = new TextBox();
            txtName = new TextBox();
            dgvBranch = new DataGridView();
            createdUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdByUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedByUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isActiveDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            branchBindingSource = new BindingSource(components);
            btnDelete = new Button();
            btnUpdate = new Button();
            btnClose = new Button();
            label1 = new Label();
            txtAddress = new TextBox();
            lblCity = new Label();
            txtCity = new TextBox();
            lblState = new Label();
            txtState = new TextBox();
            employeeBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dgvBranch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)branchBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(6, 320);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(55, 15);
            lblDate.TabIndex = 27;
            lblDate.Text = "Address2";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 232);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 25;
            lblName.Text = "Name";
            // 
            // Amount
            // 
            Amount.AutoSize = true;
            Amount.Location = new Point(209, 229);
            Amount.Name = "Amount";
            Amount.Size = new Size(67, 15);
            Amount.TabIndex = 24;
            Amount.Text = "PostalCode";
            // 
            // lblMemo
            // 
            lblMemo.AutoSize = true;
            lblMemo.Location = new Point(234, 263);
            lblMemo.Name = "lblMemo";
            lblMemo.Size = new Size(41, 15);
            lblMemo.TabIndex = 23;
            lblMemo.Text = "Phone";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(282, 260);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 22;
            // 
            // txtPostal
            // 
            txtPostal.Location = new Point(282, 226);
            txtPostal.Name = "txtPostal";
            txtPostal.Size = new Size(100, 23);
            txtPostal.TabIndex = 21;
            // 
            // txtAddress2
            // 
            txtAddress2.Location = new Point(70, 317);
            txtAddress2.Name = "txtAddress2";
            txtAddress2.Size = new Size(100, 23);
            txtAddress2.TabIndex = 20;
            // 
            // txtName
            // 
            txtName.Location = new Point(69, 229);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 19;
            // 
            // dgvBranch
            // 
            dgvBranch.AllowUserToAddRows = false;
            dgvBranch.AllowUserToDeleteRows = false;
            dgvBranch.AutoGenerateColumns = false;
            dgvBranch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBranch.Columns.AddRange(new DataGridViewColumn[] { createdUtcDataGridViewTextBoxColumn, createdByUserIdDataGridViewTextBoxColumn, updatedUtcDataGridViewTextBoxColumn, updatedByUserIdDataGridViewTextBoxColumn, isActiveDataGridViewCheckBoxColumn, idDataGridViewTextBoxColumn });
            dgvBranch.DataSource = branchBindingSource;
            dgvBranch.Location = new Point(12, 18);
            dgvBranch.Name = "dgvBranch";
            dgvBranch.ReadOnly = true;
            dgvBranch.Size = new Size(736, 150);
            dgvBranch.TabIndex = 18;
            // 
            // createdUtcDataGridViewTextBoxColumn
            // 
            createdUtcDataGridViewTextBoxColumn.DataPropertyName = "CreatedUtc";
            createdUtcDataGridViewTextBoxColumn.HeaderText = "CreatedUtc";
            createdUtcDataGridViewTextBoxColumn.Name = "createdUtcDataGridViewTextBoxColumn";
            createdUtcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdByUserIdDataGridViewTextBoxColumn
            // 
            createdByUserIdDataGridViewTextBoxColumn.DataPropertyName = "CreatedByUserId";
            createdByUserIdDataGridViewTextBoxColumn.HeaderText = "CreatedByUserId";
            createdByUserIdDataGridViewTextBoxColumn.Name = "createdByUserIdDataGridViewTextBoxColumn";
            createdByUserIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updatedUtcDataGridViewTextBoxColumn
            // 
            updatedUtcDataGridViewTextBoxColumn.DataPropertyName = "UpdatedUtc";
            updatedUtcDataGridViewTextBoxColumn.HeaderText = "UpdatedUtc";
            updatedUtcDataGridViewTextBoxColumn.Name = "updatedUtcDataGridViewTextBoxColumn";
            updatedUtcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // updatedByUserIdDataGridViewTextBoxColumn
            // 
            updatedByUserIdDataGridViewTextBoxColumn.DataPropertyName = "UpdatedByUserId";
            updatedByUserIdDataGridViewTextBoxColumn.HeaderText = "UpdatedByUserId";
            updatedByUserIdDataGridViewTextBoxColumn.Name = "updatedByUserIdDataGridViewTextBoxColumn";
            updatedByUserIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            isActiveDataGridViewCheckBoxColumn.HeaderText = "IsActive";
            isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            isActiveDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // branchBindingSource
            // 
            branchBindingSource.DataSource = typeof(BL.Branch);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(486, 381);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 51);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(602, 381);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(105, 51);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(713, 409);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 15;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 276);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 29;
            label1.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(70, 273);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 23);
            txtAddress.TabIndex = 28;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(23, 360);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(28, 15);
            lblCity.TabIndex = 31;
            lblCity.Text = "City";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(70, 357);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(100, 23);
            txtCity.TabIndex = 30;
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(12, 399);
            lblState.Name = "lblState";
            lblState.Size = new Size(33, 15);
            lblState.TabIndex = 33;
            lblState.Text = "State";
            // 
            // txtState
            // 
            txtState.Location = new Point(69, 396);
            txtState.Name = "txtState";
            txtState.Size = new Size(100, 23);
            txtState.TabIndex = 32;
            // 
            // employeeBindingSource
            // 
            employeeBindingSource.DataSource = typeof(BL.Employee);
            // 
            // FrmViewBranches
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblState);
            Controls.Add(txtState);
            Controls.Add(lblCity);
            Controls.Add(txtCity);
            Controls.Add(label1);
            Controls.Add(txtAddress);
            Controls.Add(lblDate);
            Controls.Add(lblName);
            Controls.Add(Amount);
            Controls.Add(lblMemo);
            Controls.Add(txtPhone);
            Controls.Add(txtPostal);
            Controls.Add(txtAddress2);
            Controls.Add(txtName);
            Controls.Add(dgvBranch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnClose);
            Name = "FrmViewBranches";
            Text = "FrmViewBranches";
            ((System.ComponentModel.ISupportInitialize)dgvBranch).EndInit();
            ((System.ComponentModel.ISupportInitialize)branchBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbKind;
        private Label lblDate;
        private Label label4;
        private Label lblName;
        private Label Amount;
        private Label lblMemo;
        private TextBox txtPhone;
        private TextBox txtPostal;
        private TextBox txtAddress2;
        private TextBox txtName;
        private DataGridView dgvBranch;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnClose;
        private DataGridViewTextBoxColumn createdUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdByUserIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedByUserIdDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private BindingSource branchBindingSource;
        private Label label1;
        private TextBox txtAddress;
        private Label lblCity;
        private TextBox txtCity;
        private Label lblState;
        private TextBox txtState;
        private BindingSource employeeBindingSource;
    }
}