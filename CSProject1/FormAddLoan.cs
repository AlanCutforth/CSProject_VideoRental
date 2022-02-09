using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class FormAddLoan : Form
    {
        public int currentItemNoToAdd = 0;

        private SqlConnection _DBCon;

        public string newItem = "";
        public int newItemID = 0;
        public int newItemQty = 0;
        public decimal newItemCost = 0;
        public decimal totalCost = 0;

        private List<LoanItem> _Items = new List<LoanItem>();

        public FormAddLoan(SqlConnection DBCon)
        {
            //Sets up the database connection and fills the customer combo box with records from the database.
            InitializeComponent();

            _DBCon = DBCon;

            SqlCommand cmdAddLoan = new SqlCommand("select Customers.Forename + ' ' + Customers.Surname as FullName, Customers.CustomerID from Customers", _DBCon);
            SqlDataAdapter AdptAddLoan = new SqlDataAdapter(cmdAddLoan);
            DataTable TableLoan = new DataTable();
            AdptAddLoan.Fill(TableLoan);

            cbAddLoanCustomer.DataSource = TableLoan;
            cbAddLoanCustomer.DisplayMember = "FullName";
        }

        //Closes the form.
        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //Adds an item.
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //Opens the Add Items to Loan form. The item that is specified, along with the quantity, is stored in the list _Items.
            FormAddItemToLoan addItems = new FormAddItemToLoan(_DBCon, _Items);

            if (addItems.ShowDialog() == DialogResult.OK)
            {
                _Items.Add(addItems.Item);
            }

            RefreshItems();
        }

        //Refreshes the price of the loan and the listbox.
        private void RefreshItems()
        {
            //Checks to see if the user has specified a custom price.
            if (!checkCustomPrice.Checked)
            {
                totalCost = 0;

                //Adds up the total cost of the items and divides it by 4 to get 25% of their total cost. Updates the number picker with this value.
                foreach (LoanItem item in _Items)
                {
                    totalCost = totalCost + item.Cost;
                }

                nudPrice.Value = totalCost / 4;
            }

            lbItems.Items.Clear();
            lbItems.DisplayMember = "DisplayCost";
            //Adds the items in the list _Items to the listbox in the centre of the form that shows the items added so far.
            foreach (LoanItem item in _Items)
            {
                lbItems.Items.Add(item);
            }
        }

        //Confirms the new loan record.
        private void btnConfirmAddLoan_Click(object sender, EventArgs e)
        {
            //Checks to see if any items have been added to the loan.
            if (_Items.Count > 0)
            {
                //Asks the user for confirmation. If they say no, return from add event.
                if (MessageBox.Show("Confirm rental?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                SqlTransaction tran = _DBCon.BeginTransaction();

                DataRowView RowView = (DataRowView)cbAddLoanCustomer.SelectedItem;

                try
                {
                    //Adds a new record into loans and stores the generated LoanID in the integer 'id'
                    SqlCommand cmdAddLoan;
                    cmdAddLoan = new SqlCommand("insert into Loans (CustomerID, LoanDate, Cost, Returned, StaffMember) output inserted.LoanID values ('" + RowView.Row["CustomerID"] +
                        "', '" + dtAddLoan.Text + "', '" + nudPrice.Value + "', 'No', '" + Session.User + "')", _DBCon, tran);

                    int id = Convert.ToInt32(cmdAddLoan.ExecuteScalar());

                    //For each item the user added, a new LoanLine record is created that points to the generated LoanID.
                    foreach (LoanItem item in _Items)
                    {
                        SqlCommand cmdAddLoanLine = new SqlCommand("insert into LoanLine (ItemID, Quantity, LoanID) values ('" + item.ItemId + "', '" + item.Quantity + "', '" + id + "')", _DBCon, tran);
                        cmdAddLoanLine.ExecuteNonQuery();

                        SqlCommand cmdAdjustStock = new SqlCommand("update Stock set QuantityStock = QuantityStock - '" + item.Quantity + "' where ItemID = '" + item.ItemId + "'", _DBCon, tran);
                        cmdAdjustStock.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch (Exception Ex)
                {
                    //A database error occured, hence the transaction is rolled back to protect data integrity.
                    tran.Rollback();

                    throw;
                }

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No items added to loan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Deletes an item from the loan
        private void btnDelItem_Click(object sender, EventArgs e)
        {
            LoanItem Row = (LoanItem)lbItems.SelectedItem;

            //Checks if an item is selected and if the user is sure they want to delete the item. If yes to both, then the item is removed from the list and the listbox is refreshed.
            if ((Row != null) && (MessageBox.Show("Are you sure you want to delete all of item " + HireDatabaseTools.GetItemName(Row.ItemId) + " from this loan?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                _Items.Remove(Row);
            }

            RefreshItems();
        }

        //Changes the number picker to enabled if the user has specified a custom price for this loan.
        private void checkCustomPrice_CheckedChanged(object sender, EventArgs e)
        {
            nudPrice.Enabled = checkCustomPrice.Checked;

            RefreshItems();
        }
    }
}
