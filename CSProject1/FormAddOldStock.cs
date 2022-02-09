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
    public partial class FormAddOldStock : Form
    {
        private SqlConnection _DBCon;

        public FormAddOldStock(SqlConnection DBCon)
        {
            //Sets up the database connection and gets a list of all items from stock. Their names are then placed into the item picker combo box.
            InitializeComponent();

            _DBCon = DBCon;

            SqlCommand cmdAddItem = new SqlCommand("select * from Stock", _DBCon);
            SqlDataAdapter AdptAddItem = new SqlDataAdapter(cmdAddItem);
            DataTable TableItem = new DataTable();
            AdptAddItem.Fill(TableItem);

            cbOldItem.DataSource = TableItem;
            cbOldItem.DisplayMember = "ItemName";
        }

        //Closes the form.
        private void btnCancelAddOldStock_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnConfAddOldStock_Click(object sender, EventArgs e)
        {
            //Checks if a number of items to add has been specified.
            if (Convert.ToInt32(nudQty.Value) <= 0)
            {
                MessageBox.Show("No quantity specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlTransaction tran = _DBCon.BeginTransaction();

                try
                {
                    //Adds to the QuantityOwned and QuantityStock tables of the stock database using the specified quantity to the item selected in the combo box,
                    //hence increasing the stock of that item.
                    DataRowView RowView = (DataRowView)cbOldItem.SelectedItem;

                    SqlCommand CmdAddToOldStock = new SqlCommand(@"update Stock set QuantityOwned = QuantityOwned + '" + nudQty.Value.ToString() + "', QuantityStock = QuantityStock + '"
                        + nudQty.Value.ToString() + "' where ItemID = '" + RowView.Row["ItemID"] + "'", _DBCon);
                    CmdAddToOldStock.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show("Stock quantity updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
