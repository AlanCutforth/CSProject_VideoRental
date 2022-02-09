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
    public partial class FormAddCustomer : Form
    {
        private SqlConnection _DBCon;

        private bool DOBEntered = false;

        public FormAddCustomer(SqlConnection DBCon)
        {
            //Sets up the database connection and sets the default join date and date of birth to today's date.
            InitializeComponent();

            _DBCon = DBCon;

            this.dtJoin.Value = DateTime.Today;
            this.dtDOB.Value = DateTime.Today;
        }

        private void btnCancelAddCustomer_Click(object sender, EventArgs e)
        {
            //Closes the form.
            this.DialogResult = DialogResult.OK;
        }

        private void btnConfAddCustomer_Click(object sender, EventArgs e)
        {
            //Checks to see if any of the required fields are blank, or if no contact details have been added.
            if (string.IsNullOrWhiteSpace(txtFirstname.Text) || string.IsNullOrWhiteSpace(txtSurname.Text) || (DOBEntered == false))
            {
                MessageBox.Show("One of the required fields, marked with an asterisk, has been left blank. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text) && string.IsNullOrWhiteSpace(txtAddress.Text) && string.IsNullOrWhiteSpace(txtTelephone.Text) && string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                MessageBox.Show("No contact details have been added for this customer. Please add at least one contact detail: Address, Email Address, Telephone Number or Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlTransaction tran = _DBCon.BeginTransaction();

                try
                {
                    //Adds the customer record with the input values.
                    SqlCommand cmdAddCustomer = new SqlCommand(@"insert into Customers values ('" + txtFirstname.Text + "', '" + txtSurname.Text + "', '" + this.dtDOB.Value.ToString("MM/dd/yyyy") +
                        "', '" + txtAddress.Text + "', '" + txtTelephone.Text + "', '" + txtMobile.Text + "', '" + txtEmail.Text + "', '" + this.dtJoin.Value.ToString("MM/dd/yyyy") + "')", _DBCon, tran);

                    cmdAddCustomer.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    //There was a database error, hence the transaction is rolled back to protect data integrity.
                    tran.Rollback();

                    throw;
                }
            }
        }

        private void dtDOB_ValueChanged(object sender, EventArgs e)
        {
            //Checks to see if the date of birth has been entered or left on the default.
            DOBEntered = true;
        }
    }
}
