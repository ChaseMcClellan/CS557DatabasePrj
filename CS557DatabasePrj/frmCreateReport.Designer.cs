namespace CS557DatabasePrj.UI
{
    partial class frmCreateReport
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cboBranch = new ComboBox();
            txtYear = new TextBox();
            txtMonth = new TextBox();
            btnExecute = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 57);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 0;
            label1.Text = "Select Branch";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 1;
            label2.Text = "MM";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 9);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 2;
            label3.Text = "YYYY";
            // 
            // cboBranch
            // 
            cboBranch.FormattingEnabled = true;
            cboBranch.Location = new Point(12, 80);
            cboBranch.Name = "cboBranch";
            cboBranch.Size = new Size(151, 28);
            cboBranch.TabIndex = 3;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(54, 32);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(41, 27);
            txtYear.TabIndex = 4;
            // 
            // txtMonth
            // 
            txtMonth.Location = new Point(12, 32);
            txtMonth.Name = "txtMonth";
            txtMonth.Size = new Size(36, 27);
            txtMonth.TabIndex = 5;
            // 
            // btnExecute
            // 
            btnExecute.BackColor = SystemColors.Window;
            btnExecute.Location = new Point(12, 127);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(151, 29);
            btnExecute.TabIndex = 6;
            btnExecute.Text = "Create Report";
            btnExecute.UseVisualStyleBackColor = false;
            btnExecute.Click += btnExecute_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(205, 198);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(66, 29);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmCreateReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 239);
            Controls.Add(btnClose);
            Controls.Add(btnExecute);
            Controls.Add(txtMonth);
            Controls.Add(txtYear);
            Controls.Add(cboBranch);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmCreateReport";
            Text = "frmCreateReport";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cboBranch;
        private TextBox txtYear;
        private TextBox txtMonth;
        private Button btnExecute;
        private Button btnClose;
    }
}