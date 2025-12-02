namespace CS557DatabasePrj.UI
{
    partial class frmAddWithdrawl
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
            cmbUser = new ComboBox();
            lblUser = new Label();
            lblSource = new Label();
            cmbSource = new ComboBox();
            txtAmount = new TextBox();
            cmbAccount = new ComboBox();
            btnAdd = new Button();
            lblAmount = new Label();
            lblAccount = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // cmbUser
            // 
            cmbUser.FormattingEnabled = true;
            cmbUser.Location = new Point(65, 26);
            cmbUser.Name = "cmbUser";
            cmbUser.Size = new Size(121, 23);
            cmbUser.TabIndex = 22;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(7, 29);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(30, 15);
            lblUser.TabIndex = 21;
            lblUser.Text = "User";
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.Location = new Point(8, 149);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(43, 15);
            lblSource.TabIndex = 20;
            lblSource.Text = "Source";
            // 
            // cmbSource
            // 
            cmbSource.FormattingEnabled = true;
            cmbSource.Location = new Point(65, 149);
            cmbSource.Name = "cmbSource";
            cmbSource.Size = new Size(121, 23);
            cmbSource.TabIndex = 19;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(65, 103);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 18;
            // 
            // cmbAccount
            // 
            cmbAccount.FormattingEnabled = true;
            cmbAccount.Location = new Point(66, 69);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(121, 23);
            cmbAccount.TabIndex = 17;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(308, 242);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(104, 23);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add Withdrawl";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(8, 106);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(51, 15);
            lblAmount.TabIndex = 15;
            lblAmount.Text = "Amount";
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(8, 72);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(52, 15);
            lblAccount.TabIndex = 14;
            lblAccount.Text = "Account";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(418, 242);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 13;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmAddWithdrawl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 278);
            Controls.Add(cmbUser);
            Controls.Add(lblUser);
            Controls.Add(lblSource);
            Controls.Add(cmbSource);
            Controls.Add(txtAmount);
            Controls.Add(cmbAccount);
            Controls.Add(btnAdd);
            Controls.Add(lblAmount);
            Controls.Add(lblAccount);
            Controls.Add(btnClose);
            Name = "frmAddWithdrawl";
            Text = "frmAddWithdrawl";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbUser;
        private Label lblUser;
        private Label lblSource;
        private ComboBox cmbSource;
        private TextBox txtAmount;
        private ComboBox cmbAccount;
        private Button btnAdd;
        private Label lblAmount;
        private Label lblAccount;
        private Button btnClose;
    }
}