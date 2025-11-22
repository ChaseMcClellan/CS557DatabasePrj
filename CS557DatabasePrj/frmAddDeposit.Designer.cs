namespace CS557DatabasePrj.UI
{
    partial class frmAddDeposit
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
            btnClose = new Button();
            lblAccount = new Label();
            lblAmount = new Label();
            btnAdd = new Button();
            cmbAccount = new ComboBox();
            txtAmount = new TextBox();
            cmbSource = new ComboBox();
            lblSource = new Label();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(459, 277);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(32, 49);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(52, 15);
            lblAccount.TabIndex = 2;
            lblAccount.Text = "Account";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(32, 83);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(51, 15);
            lblAmount.TabIndex = 3;
            lblAmount.Text = "Amount";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(349, 277);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(104, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Deposit";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbAccount
            // 
            cmbAccount.FormattingEnabled = true;
            cmbAccount.Location = new Point(90, 46);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(121, 23);
            cmbAccount.TabIndex = 5;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(89, 80);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 6;
            // 
            // cmbSource
            // 
            cmbSource.FormattingEnabled = true;
            cmbSource.Location = new Point(89, 126);
            cmbSource.Name = "cmbSource";
            cmbSource.Size = new Size(121, 23);
            cmbSource.TabIndex = 7;
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.Location = new Point(32, 126);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(43, 15);
            lblSource.TabIndex = 10;
            lblSource.Text = "Source";
            // 
            // frmAddDeposit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 312);
            Controls.Add(lblSource);
            Controls.Add(cmbSource);
            Controls.Add(txtAmount);
            Controls.Add(cmbAccount);
            Controls.Add(btnAdd);
            Controls.Add(lblAmount);
            Controls.Add(lblAccount);
            Controls.Add(btnClose);
            Name = "frmAddDeposit";
            Text = "AddDeposit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Label lblAccount;
        private Label lblAmount;
        private Button btnAdd;
        private ComboBox cmbAccount;
        private TextBox txtAmount;
        private ComboBox cmbSource;
        private Label lblSource;
    }
}