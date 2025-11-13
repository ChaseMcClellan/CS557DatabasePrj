namespace CS557DatabasePrj.UI
{
    partial class frmCreateBranch
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
            lblName = new Label();
            lblAddressLine1 = new Label();
            lblAddressLine2 = new Label();
            lblCity = new Label();
            lblState = new Label();
            lblPostal = new Label();
            lblPhone = new Label();
            txtName = new TextBox();
            txtAddress = new TextBox();
            txtAddress2 = new TextBox();
            txtCity = new TextBox();
            txtState = new TextBox();
            txtPostal = new TextBox();
            txtPhone = new TextBox();
            btnCreateBranch = new Button();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(496, 280);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(53, 42);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // lblAddressLine1
            // 
            lblAddressLine1.AutoSize = true;
            lblAddressLine1.Location = new Point(53, 69);
            lblAddressLine1.Name = "lblAddressLine1";
            lblAddressLine1.Size = new Size(83, 15);
            lblAddressLine1.TabIndex = 2;
            lblAddressLine1.Text = "Address Line 1";
            // 
            // lblAddressLine2
            // 
            lblAddressLine2.AutoSize = true;
            lblAddressLine2.Location = new Point(53, 102);
            lblAddressLine2.Name = "lblAddressLine2";
            lblAddressLine2.Size = new Size(83, 15);
            lblAddressLine2.TabIndex = 3;
            lblAddressLine2.Text = "Address Line 2";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(53, 130);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(28, 15);
            lblCity.TabIndex = 4;
            lblCity.Text = "City";
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Location = new Point(53, 161);
            lblState.Name = "lblState";
            lblState.Size = new Size(33, 15);
            lblState.TabIndex = 5;
            lblState.Text = "State";
            // 
            // lblPostal
            // 
            lblPostal.AutoSize = true;
            lblPostal.Location = new Point(53, 188);
            lblPostal.Name = "lblPostal";
            lblPostal.Size = new Size(39, 15);
            lblPostal.TabIndex = 6;
            lblPostal.Text = "Postal";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(53, 215);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(41, 15);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Phone";
            // 
            // txtName
            // 
            txtName.Location = new Point(144, 34);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(144, 64);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 23);
            txtAddress.TabIndex = 9;
            // 
            // txtAddress2
            // 
            txtAddress2.Location = new Point(144, 93);
            txtAddress2.Name = "txtAddress2";
            txtAddress2.Size = new Size(100, 23);
            txtAddress2.TabIndex = 10;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(144, 125);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(100, 23);
            txtCity.TabIndex = 11;
            // 
            // txtState
            // 
            txtState.Location = new Point(144, 156);
            txtState.Name = "txtState";
            txtState.Size = new Size(100, 23);
            txtState.TabIndex = 12;
            // 
            // txtPostal
            // 
            txtPostal.Location = new Point(144, 185);
            txtPostal.Name = "txtPostal";
            txtPostal.Size = new Size(100, 23);
            txtPostal.TabIndex = 13;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(144, 214);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 14;
            // 
            // btnCreateBranch
            // 
            btnCreateBranch.Location = new Point(363, 280);
            btnCreateBranch.Name = "btnCreateBranch";
            btnCreateBranch.Size = new Size(127, 23);
            btnCreateBranch.TabIndex = 15;
            btnCreateBranch.Text = "Create Branch";
            btnCreateBranch.UseVisualStyleBackColor = true;
            btnCreateBranch.Click += btnCreateBranch_Click;
            // 
            // frmCreateBranch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 313);
            Controls.Add(btnCreateBranch);
            Controls.Add(txtPhone);
            Controls.Add(txtPostal);
            Controls.Add(txtState);
            Controls.Add(txtCity);
            Controls.Add(txtAddress2);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Controls.Add(lblPhone);
            Controls.Add(lblPostal);
            Controls.Add(lblState);
            Controls.Add(lblCity);
            Controls.Add(lblAddressLine2);
            Controls.Add(lblAddressLine1);
            Controls.Add(lblName);
            Controls.Add(btnClose);
            Name = "frmCreateBranch";
            Text = "CreateBranch";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Label lblName;
        private Label lblAddressLine1;
        private Label lblAddressLine2;
        private Label lblCity;
        private Label lblState;
        private Label lblPostal;
        private Label lblPhone;
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtAddress2;
        private TextBox txtCity;
        private TextBox txtState;
        private TextBox txtPostal;
        private TextBox txtPhone;
        private Button btnCreateBranch;
    }
}