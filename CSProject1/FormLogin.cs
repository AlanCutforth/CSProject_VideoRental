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
    public partial class FormLogin : Form
    {
        private SqlConnection _DBCon;

        public FormLogin(SqlConnection DBCon)
        {
            //Sets up the database connection.
            InitializeComponent();

            _DBCon = DBCon;
        }

        //Allows the string that the user entered into the "Username" field to be accessed by the form that called this one.
        public string Username
        {
            get
            {
                return txtUsername.Text;
            }
        }

        //Allows the string that the user enteredd into the "Password" field to be accessed by the form that called this one.
        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
        }

        //Confirms the details the user has entered and closes the form.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Checks if either the password or the username field have been left blank.
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("You must enter a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Closes the form.
            DialogResult = DialogResult.OK;
        }
    }
}
