namespace CS557DatabasePrj.UI
{
    partial class FrmViewTransactions
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
            btnClose = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvTransactions = new DataGridView();
            accountIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            kindDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            amountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            memoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            postedUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            relatedEntityIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            accountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdByUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedUtcDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            updatedByUserIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isActiveDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            transactionBindingSource = new BindingSource(components);
            transactionRepositoryBindingSource = new BindingSource(components);
            txtAccount = new TextBox();
            txtDate = new TextBox();
            txtAmount = new TextBox();
            txtMemo = new TextBox();
            lblMemo = new Label();
            Amount = new Label();
            lblAccount = new Label();
            label4 = new Label();
            lblDate = new Label();
            cmbKind = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transactionBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transactionRepositoryBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(713, 415);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(602, 387);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(105, 51);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(486, 387);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 51);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Columns.AddRange(new DataGridViewColumn[] { accountIdDataGridViewTextBoxColumn, kindDataGridViewTextBoxColumn, amountDataGridViewTextBoxColumn, memoDataGridViewTextBoxColumn, postedUtcDataGridViewTextBoxColumn, relatedEntityIdDataGridViewTextBoxColumn, accountDataGridViewTextBoxColumn, createdUtcDataGridViewTextBoxColumn, createdByUserIdDataGridViewTextBoxColumn, updatedUtcDataGridViewTextBoxColumn, updatedByUserIdDataGridViewTextBoxColumn, isActiveDataGridViewCheckBoxColumn, idDataGridViewTextBoxColumn });
            dgvTransactions.DataSource = transactionBindingSource;
            dgvTransactions.Location = new Point(12, 24);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.Size = new Size(736, 150);
            dgvTransactions.TabIndex = 3;
            // 
            // accountIdDataGridViewTextBoxColumn
            // 
            accountIdDataGridViewTextBoxColumn.DataPropertyName = "AccountId";
            accountIdDataGridViewTextBoxColumn.HeaderText = "AccountId";
            accountIdDataGridViewTextBoxColumn.Name = "accountIdDataGridViewTextBoxColumn";
            // 
            // kindDataGridViewTextBoxColumn
            // 
            kindDataGridViewTextBoxColumn.DataPropertyName = "Kind";
            kindDataGridViewTextBoxColumn.HeaderText = "Kind";
            kindDataGridViewTextBoxColumn.Name = "kindDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // memoDataGridViewTextBoxColumn
            // 
            memoDataGridViewTextBoxColumn.DataPropertyName = "Memo";
            memoDataGridViewTextBoxColumn.HeaderText = "Memo";
            memoDataGridViewTextBoxColumn.Name = "memoDataGridViewTextBoxColumn";
            // 
            // postedUtcDataGridViewTextBoxColumn
            // 
            postedUtcDataGridViewTextBoxColumn.DataPropertyName = "PostedUtc";
            postedUtcDataGridViewTextBoxColumn.HeaderText = "PostedUtc";
            postedUtcDataGridViewTextBoxColumn.Name = "postedUtcDataGridViewTextBoxColumn";
            // 
            // relatedEntityIdDataGridViewTextBoxColumn
            // 
            relatedEntityIdDataGridViewTextBoxColumn.DataPropertyName = "RelatedEntityId";
            relatedEntityIdDataGridViewTextBoxColumn.HeaderText = "RelatedEntityId";
            relatedEntityIdDataGridViewTextBoxColumn.Name = "relatedEntityIdDataGridViewTextBoxColumn";
            // 
            // accountDataGridViewTextBoxColumn
            // 
            accountDataGridViewTextBoxColumn.DataPropertyName = "Account";
            accountDataGridViewTextBoxColumn.HeaderText = "Account";
            accountDataGridViewTextBoxColumn.Name = "accountDataGridViewTextBoxColumn";
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
            // transactionBindingSource
            // 
            transactionBindingSource.DataSource = typeof(BL.Transaction);
            // 
            // transactionRepositoryBindingSource
            // 
            transactionRepositoryBindingSource.DataSource = typeof(DL.Repo.TransactionRepository);
            // 
            // txtAccount
            // 
            txtAccount.Location = new Point(70, 233);
            txtAccount.Name = "txtAccount";
            txtAccount.ReadOnly = true;
            txtAccount.Size = new Size(100, 23);
            txtAccount.TabIndex = 4;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(49, 311);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(100, 23);
            txtDate.TabIndex = 6;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(256, 229);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 7;
            // 
            // txtMemo
            // 
            txtMemo.Location = new Point(254, 278);
            txtMemo.Name = "txtMemo";
            txtMemo.Size = new Size(100, 23);
            txtMemo.TabIndex = 8;
            // 
            // lblMemo
            // 
            lblMemo.AutoSize = true;
            lblMemo.Location = new Point(206, 281);
            lblMemo.Name = "lblMemo";
            lblMemo.Size = new Size(42, 15);
            lblMemo.TabIndex = 9;
            lblMemo.Text = "Memo";
            // 
            // Amount
            // 
            Amount.AutoSize = true;
            Amount.Location = new Point(199, 232);
            Amount.Name = "Amount";
            Amount.Size = new Size(51, 15);
            Amount.TabIndex = 10;
            Amount.Text = "Amount";
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(12, 233);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(52, 15);
            lblAccount.TabIndex = 11;
            lblAccount.Text = "Account";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 278);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 12;
            label4.Text = "Kind";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 311);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(31, 15);
            lblDate.TabIndex = 13;
            lblDate.Text = "Date";
            // 
            // cmbKind
            // 
            cmbKind.FormattingEnabled = true;
            cmbKind.Location = new Point(49, 275);
            cmbKind.Name = "cmbKind";
            cmbKind.Size = new Size(121, 23);
            cmbKind.TabIndex = 14;
            // 
            // FrmViewTransactions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbKind);
            Controls.Add(lblDate);
            Controls.Add(label4);
            Controls.Add(lblAccount);
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
            Name = "FrmViewTransactions";
            Text = "FrmViewTransactions";
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ((System.ComponentModel.ISupportInitialize)transactionBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)transactionRepositoryBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvTransactions;
        private DataGridViewTextBoxColumn accountIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kindDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn memoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn postedUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn relatedEntityIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn accountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdByUserIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedUtcDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn updatedByUserIdDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private BindingSource transactionBindingSource;
        private BindingSource transactionRepositoryBindingSource;
        private TextBox txtAccount;
        private TextBox txtKind;
        private TextBox txtDate;
        private TextBox txtAmount;
        private TextBox txtMemo;
        private Label lblMemo;
        private Label Amount;
        private Label lblAccount;
        private Label label4;
        private Label lblDate;
        private ComboBox cmbKind;
    }
}