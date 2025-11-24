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
            cmbKind = new ComboBox();
            lblDate = new Label();
            label4 = new Label();
            lblName = new Label();
            Amount = new Label();
            lblMemo = new Label();
            txtMemo = new TextBox();
            txtAmount = new TextBox();
            txtDate = new TextBox();
            txtAccount = new TextBox();
            dgvTransactions = new DataGridView();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnClose = new Button();
            branchBindingSource = new BindingSource(components);
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            addressLine1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            addressLine2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            postalCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdByUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedByUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isActiveDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)branchBindingSource).BeginInit();
            SuspendLayout();
            // 
            // cmbKind
            // 
            cmbKind.FormattingEnabled = true;
            cmbKind.Location = new Point(49, 269);
            cmbKind.Name = "cmbKind";
            cmbKind.Size = new Size(121, 23);
            cmbKind.TabIndex = 28;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 305);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(31, 15);
            lblDate.TabIndex = 27;
            lblDate.Text = "Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 272);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 26;
            label4.Text = "Kind";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 227);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 25;
            lblName.Text = "Name";
            // 
            // Amount
            // 
            Amount.AutoSize = true;
            Amount.Location = new Point(199, 226);
            Amount.Name = "Amount";
            Amount.Size = new Size(51, 15);
            Amount.TabIndex = 24;
            Amount.Text = "Amount";
            // 
            // lblMemo
            // 
            lblMemo.AutoSize = true;
            lblMemo.Location = new Point(206, 275);
            lblMemo.Name = "lblMemo";
            lblMemo.Size = new Size(42, 15);
            lblMemo.TabIndex = 23;
            lblMemo.Text = "Memo";
            // 
            // txtMemo
            // 
            txtMemo.Location = new Point(254, 272);
            txtMemo.Name = "txtMemo";
            txtMemo.Size = new Size(100, 23);
            txtMemo.TabIndex = 22;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(256, 223);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 21;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(49, 305);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(100, 23);
            txtDate.TabIndex = 20;
            // 
            // txtAccount
            // 
            txtAccount.Location = new Point(70, 227);
            txtAccount.Name = "txtAccount";
            txtAccount.ReadOnly = true;
            txtAccount.Size = new Size(100, 23);
            txtAccount.TabIndex = 19;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, addressLine1DataGridViewTextBoxColumn, addressLine2DataGridViewTextBoxColumn, cityDataGridViewTextBoxColumn, stateDataGridViewTextBoxColumn, postalCodeDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, createdUtcDataGridViewTextBoxColumn, createdByUserIdDataGridViewTextBoxColumn, updatedUtcDataGridViewTextBoxColumn, updatedByUserIdDataGridViewTextBoxColumn, isActiveDataGridViewCheckBoxColumn, idDataGridViewTextBoxColumn });
            dgvTransactions.DataSource = branchBindingSource;
            dgvTransactions.Location = new Point(12, 18);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.Size = new Size(736, 150);
            dgvTransactions.TabIndex = 18;
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
            // branchBindingSource
            // 
            branchBindingSource.DataSource = typeof(BL.Branch);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // addressLine1DataGridViewTextBoxColumn
            // 
            addressLine1DataGridViewTextBoxColumn.DataPropertyName = "AddressLine1";
            addressLine1DataGridViewTextBoxColumn.HeaderText = "AddressLine1";
            addressLine1DataGridViewTextBoxColumn.Name = "addressLine1DataGridViewTextBoxColumn";
            // 
            // addressLine2DataGridViewTextBoxColumn
            // 
            addressLine2DataGridViewTextBoxColumn.DataPropertyName = "AddressLine2";
            addressLine2DataGridViewTextBoxColumn.HeaderText = "AddressLine2";
            addressLine2DataGridViewTextBoxColumn.Name = "addressLine2DataGridViewTextBoxColumn";
            // 
            // cityDataGridViewTextBoxColumn
            // 
            cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            cityDataGridViewTextBoxColumn.HeaderText = "City";
            cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            // 
            // stateDataGridViewTextBoxColumn
            // 
            stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            stateDataGridViewTextBoxColumn.HeaderText = "State";
            stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            // 
            // postalCodeDataGridViewTextBoxColumn
            // 
            postalCodeDataGridViewTextBoxColumn.DataPropertyName = "PostalCode";
            postalCodeDataGridViewTextBoxColumn.HeaderText = "PostalCode";
            postalCodeDataGridViewTextBoxColumn.Name = "postalCodeDataGridViewTextBoxColumn";
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
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
            // FrmViewBranches
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbKind);
            Controls.Add(lblDate);
            Controls.Add(label4);
            Controls.Add(lblName);
            Controls.Add(Amount);
            Controls.Add(lblMemo);
            Controls.Add(txtMemo);
            Controls.Add(txtAmount);
            Controls.Add(txtDate);
            Controls.Add(txtAccount);
            Controls.Add(dgvTransactions);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnClose);
            Name = "FrmViewBranches";
            Text = "FrmViewBranches";
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ((System.ComponentModel.ISupportInitialize)branchBindingSource).EndInit();
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
        private TextBox txtMemo;
        private TextBox txtAmount;
        private TextBox txtDate;
        private TextBox txtAccount;
        private DataGridView dgvTransactions;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnClose;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addressLine1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addressLine2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn postalCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdByUserIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedByUserIdDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private BindingSource branchBindingSource;
    }
}