using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProject1
{
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
        }

        //String that is passed from this form specifying username.
        public string Username
        {
            get
            {
                return txtUsername.Text;
            }
        }

        //String that is passed from this form specifying the hashed password.
        public string Password
        {
            get
            {
                return HireDatabaseTools.HashCalculator(txtPassword.Text);
            }
        }

        //String that is passed from this form specifying if the new user is an admin.
        public string IsAdmin
        {
            get
            {
                if (checkAdmin.Checked)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }

        //Closes the form.
        private void btnCancelAddUser_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //Confirms the addition of the user.
        private void btnConfirmAddUser_Click(object sender, EventArgs e)
        {
            //Checks to see if the Password and Confirm Password fields match. If they do, the form is closed.
            if (txtPassword.Text == txtConfPassword.Text)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                txtPassword.Text = "";
                txtConfPassword.Text = "";

                MessageBox.Show("Error: Password and Confirm Password do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
