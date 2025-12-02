namespace CS557DatabasePrj.UI
{
    partial class frmPayLoan
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
            btnCurrentLoanBalance = new Button();
            label2 = new Label();
            label1 = new Label();
            lblCard = new Label();
            dgvAccount = new DataGridView();
            txtAmount = new TextBox();
            dgvLoan = new DataGridView();
            btnPay = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAccount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLoan).BeginInit();
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
            // btnCurrentLoanBalance
            // 
            btnCurrentLoanBalance.Location = new Point(457, 409);
            btnCurrentLoanBalance.Name = "btnCurrentLoanBalance";
            btnCurrentLoanBalance.Size = new Size(137, 29);
            btnCurrentLoanBalance.TabIndex = 18;
            btnCurrentLoanBalance.Text = "Current Loan Balance";
            btnCurrentLoanBalance.UseVisualStyleBackColor = true;
            btnCurrentLoanBalance.Click += btnCurrentLoanBalance_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 412);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 17;
            label2.Text = "Amount to Pay:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 209);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 16;
            label1.Text = "From Which Account:";
            // 
            // lblCard
            // 
            lblCard.AutoSize = true;
            lblCard.Location = new Point(54, 15);
            lblCard.Name = "lblCard";
            lblCard.Size = new Size(143, 15);
            lblCard.TabIndex = 15;
            lblCard.Text = "Select Which Loan to Pay:";
            // 
            // dgvAccount
            // 
            dgvAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccount.Location = new Point(51, 227);
            dgvAccount.Name = "dgvAccount";
            dgvAccount.Size = new Size(698, 150);
            dgvAccount.TabIndex = 14;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(319, 409);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 13;
            // 
            // dgvLoan
            // 
            dgvLoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoan.Location = new Point(51, 40);
            dgvLoan.Name = "dgvLoan";
            dgvLoan.Size = new Size(698, 150);
            dgvLoan.TabIndex = 12;
            // 
            // btnPay
            // 
            btnPay.Location = new Point(632, 415);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(75, 23);
            btnPay.TabIndex = 11;
            btnPay.Text = "Pay Now";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // frmPayLoan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCurrentLoanBalance);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblCard);
            Controls.Add(dgvAccount);
            Controls.Add(txtAmount);
            Controls.Add(dgvLoan);
            Controls.Add(btnPay);
            Controls.Add(btnClose);
            Name = "frmPayLoan";
            Text = "frmPayLoan";
            ((System.ComponentModel.ISupportInitialize)dgvAccount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLoan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btnCurrentLoanBalance;
        private Label label2;
        private Label label1;
        private Label lblCard;
        private DataGridView dgvAccount;
        private TextBox txtAmount;
        private DataGridView dgvLoan;
        private Button btnPay;
    }
}