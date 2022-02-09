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
    public partial class FormLoanDetails : Form
    {
        private SqlConnection _DBCon;

        private int _LoanID;
        private int _CustomerID;
        private decimal _Cost;
        private bool _Returned;

        public FormLoanDetails(SqlConnection DBCon, DataRow Row)
        {
            //Initalises connection and sets up variables for LoanID, CustomerID, Cost and whether the item has been returned for use later.
            InitializeComponent();

            _DBCon = DBCon;

            _LoanID = Convert.ToInt32(Row["LoanID"]);
            _CustomerID = Convert.ToInt32(Row["CustomerID"]);
            _Cost = Convert.ToDecimal(Row["Cost"]);

            if (Row["Returned"].ToString() == "Yes")
            {
                _Returned = true;
            }
            else
            {
                _Returned = false;
            }

            //Fills loan bar at the top of window

            SqlCommand CmdLoan = new SqlCommand(@"
                select Loans.Cost, Loans.LoanDate, Loans.ReturnDate, Loans.Returned, Customers.Forename, Customers.Surname, Loans.LoanID 
                from Loans join Customers on Customers.CustomerID = Loans.CustomerID where Loans.LoanID = '" + _LoanID + "'", _DBCon);
            SqlDataAdapter AdptLoan = new SqlDataAdapter(CmdLoan);
            DataTable TableLoan = new DataTable();
            AdptLoan.Fill(TableLoan);

            dataGridLoan.DataSource = TableLoan;


            //Fills details box in the middle of window with items from the loan

            loadDetails();
            
            //Fills the customer combo box and override cost text box

            SqlCommand cmdListCustomers = new SqlCommand("select Customers.Forename + ' ' + Customers.Surname as FullName, Customers.CustomerID from Customers", _DBCon);
            SqlDataAdapter AdptListCustomers = new SqlDataAdapter(cmdListCustomers);
            DataTable TableListCustomers = new DataTable();
            AdptListCustomers.Fill(TableListCustomers);

            cbCustomerDetail.DataSource = TableListCustomers;
            cbCustomerDetail.DisplayMember = "FullName";

            txtEditOverrideCost.Text = _Cost.ToString();
        }

        //Clears any loan records that have had all of the items deleted; where the customer is not borriwing any items.
        private void clearEmptyLoan()
        {
            //Loads any LoanLine records that match this Loans ID, and checks if the SQL command brought up any records.
            DataRow RowCustomer = ((DataRowView)cbCustomerDetail.SelectedItem).Row;
            SqlCommand CmdCheckItems = new SqlCommand("select * from LoanLine where LoanLine.LoanID = '" + _LoanID + "'", _DBCon);
            SqlDataAdapter AdptCheckItems = new SqlDataAdapter(CmdCheckItems);
            DataTable TableCheckItems = new DataTable();
            AdptCheckItems.Fill(TableCheckItems);

            if (TableCheckItems.Rows.Count == 0)
            {
                if (MessageBox.Show("The loan record you have edited contains no items. Continuing will remove the record from the system. Are you sure you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    SqlTransaction tran = _DBCon.BeginTransaction();

                    try
                    {
                        //Removes the empty loan record from the database.
                        SqlCommand CmdRemoveEmptyLoan = new SqlCommand("delete from Loans where LoanID = '" + _LoanID + "'", _DBCon, tran);
                        CmdRemoveEmptyLoan.ExecuteNonQuery();

                        tran.Commit();
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

        //Closes the form.
        private void btnCancelDetail_Click(object sender, EventArgs e)
        {
            //Calls clearEmptyLoan() to ensure no loan records are left without items.
            clearEmptyLoan();

            this.DialogResult = DialogResult.Cancel;
        }

        //Loads the LoanLine records for the loan into the data grid on the form.
        private void loadDetails()
        {
            //Loads the details for the items that were rented in the loan record the user selected.
            SqlCommand CmdDetail = new SqlCommand(@"
                select LoanLine.Quantity, LoanLine.LineID, Stock.ItemName, Stock.Cost * LoanLine.Quantity as StackCost from LoanLine join Stock on Stock.ItemID = LoanLine.ItemID where LoanID = '" + _LoanID + "'", _DBCon);
            SqlDataAdapter AdptDetail = new SqlDataAdapter(CmdDetail);
            DataTable TableDetail = new DataTable();
            AdptDetail.Fill(TableDetail);

            dataGridDetails.DataSource = TableDetail;
        }

        //Removes an item (LoanLine) from a loan.
        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {   
            //Checks if a row is selected on the datagrid; proves there are items to delete.
            if (dataGridDetails.CurrentRow != null)
            {
                DataRow Row = ((DataRowView)dataGridDetails.CurrentRow.DataBoundItem).Row;

                if (MessageBox.Show("Are you sure you want to delete " + Row["Quantity"] + " of " + Row["ItemName"] + "from this loan record?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SqlTransaction tran = _DBCon.BeginTransaction();

                    try
                    {
                        //Removes the chosen LoanLine record from the database.
                        SqlCommand CmdRemove = new SqlCommand("delete from LoanLine where LoanLine.LoanID = '" + _LoanID + "' and LoanLine.LineID = '" + Row["LineID"] + "'", _DBCon, tran);
                        CmdRemove.ExecuteNonQuery();

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        //An error occured, hence the transaction is rolled back to protect data integrity.
                        tran.Rollback();

                        throw;
                    }
                }

                //Re-loads the details on the screen so that the changes can be observed.
                loadDetails();
            }
            else
            {
                MessageBox.Show("No item selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Adds an item to the existing loan record.
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            List<LoanItem> _Items = new List<LoanItem>();

            //Calls the Add Item to Loan form in order to get values for the item and quantity the user requires.
            FormAddItemToLoan addItems = new FormAddItemToLoan(_DBCon, _Items);

            if (addItems.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _Items.Add(addItems.Item);

            SqlTransaction tran = _DBCon.BeginTransaction();

            try
            {
                foreach (LoanItem item in _Items)
                {
                    //For every item specified, creates a new LoanLine record in the database and ties it to the Loan ID of the loan being edited.
                    SqlCommand cmdAddLoanLine = new SqlCommand("insert into LoanLine (ItemID, Quantity, LoanID) values ('" + item.ItemId + "', '" + item.Quantity + "', '" + _LoanID + "')", _DBCon, tran);
                    cmdAddLoanLine.ExecuteNonQuery();

                    //For each new LoanLine record added updates the stock to show the items no longer in stock if the loan has not been returned.
                    if (!_Returned)
                    {
                        SqlCommand cmdAdjustStock = new SqlCommand("update Stock set QuantityStock = QuantityStock - " + item.Quantity + " where ItemID = " + item.ItemId, _DBCon, tran);
                        cmdAdjustStock.ExecuteNonQuery();
                    }
                }

                tran.Commit();
            }
            catch(Exception ex)
            {
                //An error occured, hence the transaction is rolled back to protect data integrity.
                tran.Rollback();

                throw;
            }

            //Re-loads the details on the screen so the changes can be observed.
            loadDetails();
        }

        //Checks whether the user has specified they wish to override the cost of the loan, and updates the enabled property of the price textbox accordingly.
        private void checkBoxOverrideCost_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOverrideCost.Checked)
            {
                txtEditOverrideCost.Enabled = true;
            }
            else
            {
                txtEditOverrideCost.Enabled = false;
            }             
        }
        
        //Confirms any changes made to the loan Customer properties or the price of the loan and closes the form.
        private void btnConfirmDetail_Click(object sender, EventArgs e)
        {
            //Ensures there are no loans with no items.
            clearEmptyLoan();

            DataRow RowCustomer = ((DataRowView)cbCustomerDetail.SelectedItem).Row;

            //Checks if any changes have been made to the Customer or price of this loan.
            if ((Convert.ToInt32(RowCustomer["CustomerID"]) != _CustomerID) && (_Cost.ToString() != txtEditOverrideCost.Text))
            {
                SqlTransaction tran = _DBCon.BeginTransaction();

                try
                {
                    //Updates the loan record in the database with the new values specified by the user.
                    SqlCommand CmdUpdateLoan = new SqlCommand("update Loans set Loans.CustomerID = '" + RowCustomer["CustomerID"] + "', Loans.Cost = '" + txtEditOverrideCost.Text + 
                        "' where Loans.LoanID = '" + _LoanID + "'", _DBCon, tran);
                    CmdUpdateLoan.ExecuteNonQuery();

                    MessageBox.Show("Loan record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tran.Commit();
                }
                catch(Exception ex)
                {
                    //An error occured, hence the transaction is rolled back to protect data integrity.
                    tran.Rollback();

                    throw;
                }
            }

            //Closes the form.
            this.DialogResult = DialogResult.OK;
        }
    }

}
