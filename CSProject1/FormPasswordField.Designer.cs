namespace CSProject1
{
    partial class FormPasswordField
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
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtConfOldPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancelPasswordChange = new System.Windows.Forms.Button();
            this.labelCurrentPassword = new System.Windows.Forms.Label();
            this.labelConfCurrentPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConfNewPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(15, 25);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(260, 20);
            this.txtOldPassword.TabIndex = 0;
            // 
            // txtConfOldPassword
            // 
            this.txtConfOldPassword.Location = new System.Drawing.Point(12, 64);
            this.txtConfOldPassword.Name = "txtConfOldPassword";
            this.txtConfOldPassword.Size = new System.Drawing.Size(260, 20);
            this.txtConfOldPassword.TabIndex = 1;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(12, 136);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(260, 20);
            this.txtNewPassword.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 226);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancelPasswordChange
            // 
            this.btnCancelPasswordChange.Location = new System.Drawing.Point(197, 226);
            this.btnCancelPasswordChange.Name = "btnCancelPasswordChange";
            this.btnCancelPasswordChange.Size = new System.Drawing.Size(75, 23);
            this.btnCancelPasswordChange.TabIndex = 4;
            this.btnCancelPasswordChange.Text = "Cancel";
            this.btnCancelPasswordChange.UseVisualStyleBackColor = true;
            this.btnCancelPasswordChange.Click += new System.EventHandler(this.btnCancelPasswordChange_Click);
            // 
            // labelCurrentPassword
            // 
            this.labelCurrentPassword.AutoSize = true;
            this.labelCurrentPassword.Location = new System.Drawing.Point(12, 9);
            this.labelCurrentPassword.Name = "labelCurrentPassword";
            this.labelCurrentPassword.Size = new System.Drawing.Size(97, 13);
            this.labelCurrentPassword.TabIndex = 5;
            this.labelCurrentPassword.Text = "Current Password*:";
            // 
            // labelConfCurrentPassword
            // 
            this.labelConfCurrentPassword.AutoSize = true;
            this.labelConfCurrentPassword.Location = new System.Drawing.Point(12, 48);
            this.labelConfCurrentPassword.Name = "labelConfCurrentPassword";
            this.labelConfCurrentPassword.Size = new System.Drawing.Size(135, 13);
            this.labelConfCurrentPassword.TabIndex = 6;
            this.labelConfCurrentPassword.Text = "Confirm Current Password*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "New Password*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Confirm New Password*:";
            // 
            // txtConfNewPassword
            // 
            this.txtConfNewPassword.Location = new System.Drawing.Point(12, 175);
            this.txtConfNewPassword.Name = "txtConfNewPassword";
            this.txtConfNewPassword.PasswordChar = '*';
            this.txtConfNewPassword.Size = new System.Drawing.Size(260, 20);
            this.txtConfNewPassword.TabIndex = 9;
            // 
            // FormPasswordField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtConfNewPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelConfCurrentPassword);
            this.Controls.Add(this.labelCurrentPassword);
            this.Controls.Add(this.btnCancelPasswordChange);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtConfOldPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Name = "FormPasswordField";
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtConfOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancelPasswordChange;
        private System.Windows.Forms.Label labelCurrentPassword;
        private System.Windows.Forms.Label labelConfCurrentPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfNewPassword;
    }
}