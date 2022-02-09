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
    public partial class FormAddNewStock : Form
    {
        private SqlConnection _DBCon;

        public FormAddNewStock(SqlConnection DBCon)
        {
            //Sets up database connection.
            InitializeComponent();

            _DBCon = DBCon;
        }

        //Closes the form.
        private void btnCancelAddNewItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //Confirms the addition of a new item.
        private void btnConfAddNewItem_Click(object sender, EventArgs e)
        {
            //Checks to see if any of the required fields have been left blank.
            if (string.IsNullOrEmpty(txtItemName.Text) || nudCost.Value <= 0 || ((Convert.ToInt32(nudQty.Value) <= 0)))
            {
                MessageBox.Show("A required field has been left blank. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlTransaction tran = _DBCon.BeginTransaction();

                try
                {
                    //Adds a new stock item with the specified parameters into the stock database table.
                    SqlCommand CmdAddNewStock = new SqlCommand("insert into Stock (ItemName, QuantityOwned, QuantityStock, Cost, QuantityBroken) values ('" + txtItemName.Text +
                        "', '" + nudQty.Value.ToString() + "', '" + nudQty.Value.ToString() + "', '" + nudCost.Value.ToString() + "', '0')", _DBCon);
                    CmdAddNewStock.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show("New item added to stock successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
