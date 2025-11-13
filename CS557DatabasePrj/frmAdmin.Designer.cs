namespace CS557DatabasePrj
{
    partial class frmAdmin
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
            btnExit = new Button();
            btnLogout = new Button();
            btnNewUser = new Button();
            btnCreateBranch = new Button();
            btnDeposit = new Button();
            btnCreateEmployee = new Button();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(713, 404);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 0;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(623, 404);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "<-] Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnNewUser
            // 
            btnNewUser.Location = new Point(39, 32);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Size = new Size(178, 23);
            btnNewUser.TabIndex = 2;
            btnNewUser.Text = "Create New User";
            btnNewUser.UseVisualStyleBackColor = true;
            btnNewUser.Click += btnNewUser_Click;
            // 
            // btnCreateBranch
            // 
            btnCreateBranch.Location = new Point(407, 32);
            btnCreateBranch.Name = "btnCreateBranch";
            btnCreateBranch.Size = new Size(178, 23);
            btnCreateBranch.TabIndex = 3;
            btnCreateBranch.Text = "Create Branch";
            btnCreateBranch.UseVisualStyleBackColor = true;
            btnCreateBranch.Click += btnCreateBranch_Click;
            // 
            // btnDeposit
            // 
            btnDeposit.Location = new Point(591, 32);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(178, 23);
            btnDeposit.TabIndex = 4;
            btnDeposit.Text = "Add Deposit";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnCreateEmployee
            // 
            btnCreateEmployee.Location = new Point(223, 32);
            btnCreateEmployee.Name = "btnCreateEmployee";
            btnCreateEmployee.Size = new Size(178, 23);
            btnCreateEmployee.TabIndex = 5;
            btnCreateEmployee.Text = "Create Employee";
            btnCreateEmployee.UseVisualStyleBackColor = true;
            btnCreateEmployee.Click += btnCreateEmployee_Click;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCreateEmployee);
            Controls.Add(btnDeposit);
            Controls.Add(btnCreateBranch);
            Controls.Add(btnNewUser);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Name = "frmAdmin";
            Text = "frmAdmin";
            ResumeLayout(false);
        }

        #endregion

        private Button btnExit;
        private Button btnLogout;
        private Button btnNewUser;
        private Button btnCreateBranch;
        private Button btnDeposit;
        private Button btnCreateEmployee;
    }
}