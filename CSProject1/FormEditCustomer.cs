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
    public partial class FormEditCustomer : Form
    {
        private SqlConnection _DBCon;

        private string _CustomerID;

        public FormEditCustomer(SqlConnection DBCon, DataRow Row)
        {
            //Sets up the database connection.
            InitializeComponent();

            _DBCon = DBCon;

            //Sets text boxes and datetime boxes to match the customers existing information
            txtFirstname.Text = Row["Forename"].ToString();
            txtSurname.Text = Row["Surname"].ToString();
            txtAddress.Text = Row["Address"].ToString();
            txtTelephone.Text = Row["Telephone"].ToString();
            txtMobile.Text = Row["Mobile"].ToString();
            txtEmail.Text = Row["Email"].ToString();
            dtDOB.Value = Convert.ToDateTime(Row["BirthDate"]);
            dtJoin.Value = Convert.ToDateTime(Row["JoinDate"]);
            _CustomerID = Row["CustomerID"].ToString();
        }

        //Closes form.
        private void btnCancelEditCustomer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //Confirms the edits made to the customer.
        private void btnConfEditCustomer_Click(object sender, EventArgs e)
        {
            //Checks to see if required fields are blank, and at least one piece of contact information is entered
            if (string.IsNullOrWhiteSpace(txtFirstname.Text) || string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("One of the required fields, marked with an asterisk, has been left blank. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text) && string.IsNullOrWhiteSpace(txtAddress.Text) && string.IsNullOrWhiteSpace(txtTelephone.Text) && string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                MessageBox.Show("No contact details have been added for this customer. Please add at least one contact detail: Address, Email Address, Telephone Number or Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Asks the customer if they are sure they want to make changes
                if (MessageBox.Show("Are you sure you want to make changes to this customer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SqlTransaction tran = _DBCon.BeginTransaction();

                    try
                    {
                        //Updates the customer records with the information from the text boxes and datetime pickers, then closes the window
                        SqlCommand cmdAddCustomer = new SqlCommand(@"update Customers set Forename = '" + txtFirstname.Text + "', Surname = '" + txtSurname.Text + "', BirthDate = '" + this.dtDOB.Value.ToString("MM/dd/yyyy") + "', Address = '" + txtAddress.Text + "', Telephone = '" + txtTelephone.Text + "', Mobile = '" + txtMobile.Text + "', Email = '" + txtEmail.Text + "', JoinDate = '" + this.dtJoin.Value.ToString("MM/dd/yyyy") + "' where CustomerID = '" + _CustomerID + "'", _DBCon);
                        cmdAddCustomer.ExecuteNonQuery();

                        tran.Commit();

                        MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        //An error occured, hence the transaction is rolled back to protect data integrity.
                        tran.Rollback();

                        throw;
                    }
                }
            }
        }
    }
}
