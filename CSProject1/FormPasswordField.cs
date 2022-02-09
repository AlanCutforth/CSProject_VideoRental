using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProject1
{
    public partial class FormPasswordField : Form
    {
        private SqlConnection _DBCon;

        public FormPasswordField(SqlConnection DBCon)
        {
            //Sets up the database connection.
            InitializeComponent();

            _DBCon = DBCon;

            //Checks if the current user is an admin. If they are, disables the old password fields as they are not required if an administrator
            //is changing the password for another user.
            if (Session.IsAdmin)
            {
                txtOldPassword.Enabled = false;
                txtConfOldPassword.Enabled = false;
                txtOldPassword.Text = "Not required";
                txtConfOldPassword.Text = "Not required";
            }
            else
            {
                txtOldPassword.PasswordChar = Convert.ToChar("*");
                txtConfOldPassword.PasswordChar = Convert.ToChar("*");
            }
        }

        //Allows the new password the user has entered to be accessed by the form that called this one.
        public string NewPassword
        {
            get
            {
                //Converts entered password into MD5 hash.
                return HireDatabaseTools.HashCalculator(txtNewPassword.Text);
            }
        }

        //Allows the old password the user has entered to be accessed by the form that called this one.
        public string OldPassword
        {
            get
            {
                //Converts entered password into MD5 hash.
                return HireDatabaseTools.HashCalculator(txtOldPassword.Text);
            }
        }

        //Closes the form.
        private void btnCancelPasswordChange_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //Confirms the password change.
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Checks whether any required fields have been left blank or either of the password confirmations do not match up.
            if ((txtConfNewPassword.Text == txtNewPassword.Text) && (txtConfOldPassword.Text == txtOldPassword.Text))
            {
                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //Clears all fields if one was left blank or if either of the password confirmation fields do not match.
                txtConfNewPassword.Text = "";
                txtNewPassword.Text = "";
                if (!Session.IsAdmin)
                {
                    txtConfOldPassword.Text = "";
                    txtOldPassword.Text = "";
                }

                MessageBox.Show("Error: One of the passwords entered does not match it's confirmation. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
