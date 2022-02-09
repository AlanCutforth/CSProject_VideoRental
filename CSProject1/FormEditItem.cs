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
    public partial class FormEditItem : Form
    {
        private SqlConnection _DBCon;

        private string _ItemID;

        public FormEditItem(SqlConnection DBCon, DataRow Row)
        {
            //Sets up the database connection and loads the Item ID, Cost and Name from the passed DataRow Row.
            InitializeComponent();

            _DBCon = DBCon;

            txtItemName.Text = Row["ItemName"].ToString();
            txtCost.Text = Row["Cost"].ToString();
            _ItemID = Row["ItemID"].ToString();
        }

        //Closes the form.
        private void btnCancelEditItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //Confirms the edit of this item.
        private void btnConfEditItem_Click(object sender, EventArgs e)
        {
            //Checks to see whether the required fields have been filled in.
            if(string.IsNullOrWhiteSpace(txtCost.Text) || string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Either the cost or name for this item has been left blank. Please check the fields and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlTransaction tran = _DBCon.BeginTransaction();

                try
                {
                    //Updates the stock database with the changes made to the item.
                    SqlCommand CmdEditItem = new SqlCommand("update Stock set ItemName = '" + txtItemName.Text + "', Cost = '" + txtCost.Text + "' where ItemID = '" + _ItemID + "'", _DBCon);
                    CmdEditItem.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show("Item updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    //An error occured, hence the transaction is rolled back to protect data integrity.
                    tran.Rollback();

                    throw;
                }
            }
        }
    }
}
