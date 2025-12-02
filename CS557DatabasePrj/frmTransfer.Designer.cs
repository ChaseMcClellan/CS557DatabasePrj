namespace CS557DatabasePrj.UI
{
    partial class frmTransfer
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
            btnTranfer = new Button();
            cmbAccount = new ComboBox();
            cmbToAccount = new ComboBox();
            txtAmount = new TextBox();
            txtMemo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(234, 215);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnTranfer
            // 
            btnTranfer.Location = new Point(153, 215);
            btnTranfer.Name = "btnTranfer";
            btnTranfer.Size = new Size(75, 23);
            btnTranfer.TabIndex = 2;
            btnTranfer.Text = "Transfer";
            btnTranfer.UseVisualStyleBackColor = true;
            // 
            // cmbAccount
            // 
            cmbAccount.FormattingEnabled = true;
            cmbAccount.Location = new Point(84, 35);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(121, 23);
            cmbAccount.TabIndex = 3;
            // 
            // cmbToAccount
            // 
            cmbToAccount.FormattingEnabled = true;
            cmbToAccount.Location = new Point(84, 77);
            cmbToAccount.Name = "cmbToAccount";
            cmbToAccount.Size = new Size(121, 23);
            cmbToAccount.TabIndex = 4;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(84, 120);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 5;
            // 
            // txtMemo
            // 
            txtMemo.Location = new Point(84, 167);
            txtMemo.Name = "txtMemo";
            txtMemo.Size = new Size(100, 23);
            txtMemo.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 39);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 7;
            label1.Text = "Account";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 8;
            label2.Text = "To Account";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 123);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 9;
            label3.Text = "Amount";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 170);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 10;
            label4.Text = "Memo";
            // 
            // frmTransfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 256);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMemo);
            Controls.Add(txtAmount);
            Controls.Add(cmbToAccount);
            Controls.Add(cmbAccount);
            Controls.Add(btnTranfer);
            Controls.Add(btnClose);
            Name = "frmTransfer";
            Text = "frmTransfer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btnTranfer;
        private ComboBox cmbAccount;
        private ComboBox cmbToAccount;
        private TextBox txtAmount;
        private TextBox txtMemo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}