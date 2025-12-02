namespace CS557DatabasePrj.UI
{
    partial class frmAddLoan
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
            btnAdd = new Button();
            txtRate = new TextBox();
            label1 = new Label();
            lblPrinciple = new Label();
            txtPrinciple = new TextBox();
            lblTerm = new Label();
            cmbTerm = new ComboBox();
            cmbAccount = new ComboBox();
            lblAccount = new Label();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(323, 198);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(242, 198);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Loan";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtRate
            // 
            txtRate.Location = new Point(136, 24);
            txtRate.Name = "txtRate";
            txtRate.ReadOnly = true;
            txtRate.Size = new Size(100, 23);
            txtRate.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 4;
            label1.Text = "Current Interest Rate:";
            // 
            // lblPrinciple
            // 
            lblPrinciple.AutoSize = true;
            lblPrinciple.Location = new Point(12, 102);
            lblPrinciple.Name = "lblPrinciple";
            lblPrinciple.Size = new Size(53, 15);
            lblPrinciple.TabIndex = 6;
            lblPrinciple.Text = "Principle";
            // 
            // txtPrinciple
            // 
            txtPrinciple.Location = new Point(68, 99);
            txtPrinciple.Name = "txtPrinciple";
            txtPrinciple.Size = new Size(100, 23);
            txtPrinciple.TabIndex = 5;
            // 
            // lblTerm
            // 
            lblTerm.AutoSize = true;
            lblTerm.Location = new Point(22, 142);
            lblTerm.Name = "lblTerm";
            lblTerm.Size = new Size(33, 15);
            lblTerm.TabIndex = 8;
            lblTerm.Text = "Term";
            // 
            // cmbTerm
            // 
            cmbTerm.FormattingEnabled = true;
            cmbTerm.Location = new Point(66, 139);
            cmbTerm.Name = "cmbTerm";
            cmbTerm.Size = new Size(121, 23);
            cmbTerm.TabIndex = 9;
            // 
            // cmbAccount
            // 
            cmbAccount.FormattingEnabled = true;
            cmbAccount.Location = new Point(71, 64);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(121, 23);
            cmbAccount.TabIndex = 11;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(13, 67);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(52, 15);
            lblAccount.TabIndex = 10;
            lblAccount.Text = "Account";
            // 
            // frmAddLoan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 233);
            Controls.Add(cmbAccount);
            Controls.Add(lblAccount);
            Controls.Add(cmbTerm);
            Controls.Add(lblTerm);
            Controls.Add(lblPrinciple);
            Controls.Add(txtPrinciple);
            Controls.Add(label1);
            Controls.Add(txtRate);
            Controls.Add(btnAdd);
            Controls.Add(btnClose);
            Name = "frmAddLoan";
            Text = "frmAddLoan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btnAdd;
        private TextBox txtRate;
        private Label label1;
        private Label lblPrinciple;
        private TextBox txtPrinciple;
        private Label lblTerm;
        private ComboBox cmbTerm;
        private ComboBox cmbAccount;
        private Label lblAccount;
    }
}