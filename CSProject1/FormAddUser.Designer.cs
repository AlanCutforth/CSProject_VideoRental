namespace CSProject1
{
    partial class FormAddUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfPassword = new System.Windows.Forms.TextBox();
            this.btnConfirmAddUser = new System.Windows.Forms.Button();
            this.btnCancelAddUser = new System.Windows.Forms.Button();
            this.checkAdmin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password*:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(260, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 89);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(260, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtConfPassword
            // 
            this.txtConfPassword.Location = new System.Drawing.Point(12, 152);
            this.txtConfPassword.Name = "txtConfPassword";
            this.txtConfPassword.Size = new System.Drawing.Size(260, 20);
            this.txtConfPassword.TabIndex = 5;
            // 
            // btnConfirmAddUser
            // 
            this.btnConfirmAddUser.Location = new System.Drawing.Point(12, 226);
            this.btnConfirmAddUser.Name = "btnConfirmAddUser";
            this.btnConfirmAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmAddUser.TabIndex = 6;
            this.btnConfirmAddUser.Text = "Confirm";
            this.btnConfirmAddUser.UseVisualStyleBackColor = true;
            this.btnConfirmAddUser.Click += new System.EventHandler(this.btnConfirmAddUser_Click);
            // 
            // btnCancelAddUser
            // 
            this.btnCancelAddUser.Location = new System.Drawing.Point(197, 226);
            this.btnCancelAddUser.Name = "btnCancelAddUser";
            this.btnCancelAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAddUser.TabIndex = 7;
            this.btnCancelAddUser.Text = "Cancel";
            this.btnCancelAddUser.UseVisualStyleBackColor = true;
            this.btnCancelAddUser.Click += new System.EventHandler(this.btnCancelAddUser_Click);
            // 
            // checkAdmin
            // 
            this.checkAdmin.AutoSize = true;
            this.checkAdmin.Location = new System.Drawing.Point(12, 192);
            this.checkAdmin.Name = "checkAdmin";
            this.checkAdmin.Size = new System.Drawing.Size(173, 17);
            this.checkAdmin.TabIndex = 8;
            this.checkAdmin.Text = "Make this user an Administrator";
            this.checkAdmin.UseVisualStyleBackColor = true;
            // 
            // FormAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.checkAdmin);
            this.Controls.Add(this.btnCancelAddUser);
            this.Controls.Add(this.btnConfirmAddUser);
            this.Controls.Add(this.txtConfPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddUser";
            this.Text = "New User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfPassword;
        private System.Windows.Forms.Button btnConfirmAddUser;
        private System.Windows.Forms.Button btnCancelAddUser;
        private System.Windows.Forms.CheckBox checkAdmin;
    }
}