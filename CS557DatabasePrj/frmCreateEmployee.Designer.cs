namespace CS557DatabasePrj.UI
{
    partial class frmCreateEmployee
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
            txtNum = new TextBox();
            txtFirst = new TextBox();
            txtLast = new TextBox();
            lblEmployeeNum = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblBranch = new Label();
            label5 = new Label();
            btnCreateEmployee = new Button();
            cmbBranch = new ComboBox();
            cmbUser = new ComboBox();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(488, 255);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtNum
            // 
            txtNum.Location = new Point(124, 17);
            txtNum.Name = "txtNum";
            txtNum.Size = new Size(100, 23);
            txtNum.TabIndex = 2;
            // 
            // txtFirst
            // 
            txtFirst.Location = new Point(124, 54);
            txtFirst.Name = "txtFirst";
            txtFirst.Size = new Size(100, 23);
            txtFirst.TabIndex = 3;
            // 
            // txtLast
            // 
            txtLast.Location = new Point(124, 92);
            txtLast.Name = "txtLast";
            txtLast.Size = new Size(100, 23);
            txtLast.TabIndex = 4;
            // 
            // lblEmployeeNum
            // 
            lblEmployeeNum.AutoSize = true;
            lblEmployeeNum.Location = new Point(12, 20);
            lblEmployeeNum.Name = "lblEmployeeNum";
            lblEmployeeNum.Size = new Size(106, 15);
            lblEmployeeNum.TabIndex = 8;
            lblEmployeeNum.Text = "Employee Number";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(54, 62);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(59, 15);
            lblFirstName.TabIndex = 9;
            lblFirstName.Text = "Firstname";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(54, 100);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(58, 15);
            lblLastName.TabIndex = 10;
            lblLastName.Text = "Lastname";
            // 
            // lblBranch
            // 
            lblBranch.AutoSize = true;
            lblBranch.Location = new Point(54, 138);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(44, 15);
            lblBranch.TabIndex = 11;
            lblBranch.Text = "Branch";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(54, 172);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 12;
            label5.Text = "User";
            // 
            // btnCreateEmployee
            // 
            btnCreateEmployee.Location = new Point(364, 255);
            btnCreateEmployee.Name = "btnCreateEmployee";
            btnCreateEmployee.Size = new Size(118, 23);
            btnCreateEmployee.TabIndex = 13;
            btnCreateEmployee.Text = "Create Employee";
            btnCreateEmployee.UseVisualStyleBackColor = true;
            btnCreateEmployee.Click += btnCreateEmployee_Click;
            // 
            // cmbBranch
            // 
            cmbBranch.FormattingEnabled = true;
            cmbBranch.Location = new Point(124, 135);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(121, 23);
            cmbBranch.TabIndex = 14;
            // 
            // cmbUser
            // 
            cmbUser.FormattingEnabled = true;
            cmbUser.Location = new Point(124, 172);
            cmbUser.Name = "cmbUser";
            cmbUser.Size = new Size(121, 23);
            cmbUser.TabIndex = 15;
            // 
            // frmCreateEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 290);
            Controls.Add(cmbUser);
            Controls.Add(cmbBranch);
            Controls.Add(btnCreateEmployee);
            Controls.Add(label5);
            Controls.Add(lblBranch);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblEmployeeNum);
            Controls.Add(txtLast);
            Controls.Add(txtFirst);
            Controls.Add(txtNum);
            Controls.Add(btnClose);
            Name = "frmCreateEmployee";
            Text = "CreateEmployee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private TextBox txtNum;
        private TextBox txtFirst;
        private TextBox txtLast;
        private Label lblEmployeeNum;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblBranch;
        private Label label5;
        private Button btnCreateEmployee;
        private ComboBox cmbBranch;
        private ComboBox cmbUser;
    }
}