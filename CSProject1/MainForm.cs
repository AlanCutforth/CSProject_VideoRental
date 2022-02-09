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
    public partial class MainForm : Form
    {
        //Sets up variables to be used: User for the currently logged in username, IsAdmin to check whether the logged in user is an administrator.
        private SqlConnection _DBCon;

        string currentView;

        public MainForm()
        {
            InitializeComponent();

            //Sets up database connction
            _DBCon = new SqlConnection("Data Source=.;Initial Catalog=HireDatabase;User ID=sa;Password=test1");

            _DBCon.Open();

            //Passes the database connection to the HireDatabaseTools class to be used later. Loads the repair queue from the database.
            HireDatabaseTools.initialiseHireDataBaseTools(_DBCon);
            HireDatabaseTools.LoadRepairQueue();

            mainViewTable.ReadOnly = true;
            mainViewTable.AllowUserToAddRows = false;
        }

        //Checks to see if the user is logged in -- if they are not, they are prompted to log in.
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!Login())
            {
                Close();
                return;
            }
        }

        //Returns true if the user is logged in, or false if they are not.
        private bool Login()
        {
            bool loggedin = false;

            while (!loggedin)
            {
                FormLogin newLogin = new FormLogin(_DBCon);

                if (newLogin.ShowDialog() == DialogResult.OK)
                {
                    //Checks the database to see whether a user with the username and password that was passed back from the FormLogin exists.
                    string hash = HireDatabaseTools.HashCalculator(newLogin.Password);

                    SqlCommand CmdCheckLogin = new SqlCommand("select * from Users where Username = '" + newLogin.Username + "' and Password = '" + hash + "'", _DBCon);
                    SqlDataAdapter AdptCheckLogin = new SqlDataAdapter(CmdCheckLogin);
                    DataTable TableCheckLogin = new DataTable();
                    AdptCheckLogin.Fill(TableCheckLogin);

                    if (TableCheckLogin.Rows.Count != 1)
                    {
                        MessageBox.Show("Incorrect Username or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Sets loggedin to true and tests whether the user is an admin. If they are, sets IsAdmin to true.
                        loggedin = true;
                        Session.User = newLogin.Username;
                        lbLogin.Text = "Logged in as: " + Session.User;

                        SqlCommand CmdCheckAdmin = new SqlCommand("select * from Users where Username = '" + newLogin.Username + "' and Password = '" + hash + "' and Admin = 'Yes'", _DBCon);
                        SqlDataAdapter AdptCheckAdmin = new SqlDataAdapter(CmdCheckAdmin);
                        DataTable TableCheckAdmin = new DataTable();
                        AdptCheckAdmin.Fill(TableCheckAdmin);
                        if (TableCheckAdmin.Rows.Count > 0)
                        {
                            Session.IsAdmin = true;
                            btnStaff.Text = "Manage Users";
                        }
                        else
                        {
                            btnStaff.Text = "Change Password";
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            return loggedin;
        }

        //Causes the loans tab to show when the program is loaded initially.
        private void MainForm_Load(object sender, EventArgs e)
        {
            btnLoans_Click(sender, e);
        }

        //Refreshes the main view table of the program.
        private void RefreshGrid(string Search = null)
        {
            //Checks which table is being viewed and calls the appropriate load method.
            if (currentView == "loans")
            {
                LoadLoans(Search);
            }
            else if (currentView == "customers")
            {
                LoadCustomers(Search);
            }
            else if (currentView == "stock")
            {
                LoadStock(Search);
            }
        }

        //Loads the loan records onto the main view table from the database. 
        private void btnLoans_Click(object sender, EventArgs e)
        {
            //Sets the current view to loans, and loads the loan records onto the main view table. Sets the buttons that do not apply to loans as disabled and the others enabled.
            currentView = "loans";

            LoadLoans();
        
            gbCurrentView.Text = "Currently Viewing: Loans";

            btnAdd.Text = "New Loan";
            btnRemove.Text = "Delete Loan Record";
            btnEdit.Text = "Edit Loan";
            btnReturned.Enabled = true;
            btnShowItems.Enabled = true;
            btnMarkLost.Enabled = false;
        }

        //Loads the loan records onto the main view table from the database. 
        private void LoadLoans(string Search = null)
        {
            //If the string Search is not null, only loan records containing that string will be shown
            string sql = @"
                select Loans.LoanID, Loans.Cost, Loans.LoanDate, Loans.ReturnDate, Loans.Returned, Customers.Forename, Customers.Surname, Customers.CustomerID 
                from Loans join Customers on Customers.CustomerID = Loans.CustomerID";

            if (!string.IsNullOrWhiteSpace(Search))
            {
                sql += @" join LoanLine on LoanLine.LoanID = Loans.LoanID join Stock on LoanLine.ItemID = Stock.ItemID where Customers.Forename like '%" + Search + "%' or Customers.Surname " +
                    "like '%" + Search + "%' or Stock.ItemName like '%" + Search + "%' or Loans.StaffMember like '%" + Search + "%'";
            }

            SqlCommand Cmd = new SqlCommand(sql, _DBCon);
            SqlDataAdapter Adpt = new SqlDataAdapter(Cmd);
            DataTable Table = new DataTable();
            Adpt.Fill(Table);

            mainViewTable.DataSource = Table;
        }

        //Loads the customer records onto the main view screen. 
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            //Sets the current view to customers, and loads the customer records onto the main view screen. Sets the buttons that do not apply to customers to disabled and the others to enabled.
            currentView = "customers";

            LoadCustomers();

            gbCurrentView.Text = "Currently Viewing: Customers";


            btnAdd.Text = "New Customer";
            btnRemove.Text = "Delete Customer";
            btnEdit.Text = "Edit Customer";
            btnReturned.Enabled = false;
            btnShowItems.Enabled = false;
            btnMarkLost.Enabled = false;
        }

        //Loads the customer records onto the main view screen. 
        private void LoadCustomers(string Search = null)
        {
            //If the string Search is not null, only customer records containing that string will show up.
            string sql = @"
                select Customers.Forename, Customers.Surname, Customers.BirthDate, Customers.Address, Customers.Telephone, Customers.Mobile, Customers.Email, Customers.JoinDate,
                Customers.CustomerID from Customers";

            if (!string.IsNullOrWhiteSpace(Search))
            {
                sql += @" where Customers.Forename like '%" + Search + "%' or Customers.Surname like '%" + Search + "%' or Customers.Address like '%" + Search + "%' or Customers.Mobile like " +
                    "'%" + Search + "%' or Customers.Telephone like '%" + Search + "%' or Customers.Email like '%" + Search + "%'";
            }

            SqlCommand Cmd = new SqlCommand(sql, _DBCon);
            SqlDataAdapter Adpt = new SqlDataAdapter(Cmd);
            DataTable Table = new DataTable();
            Adpt.Fill(Table);
            mainViewTable.DataSource = Table;
        }

        //Loads the stock records onto the main view table. 
        private void btnStock_Click(object sender, EventArgs e)
        {
            //Sets the current view to stock and loads the stock records onto the main view table. Sets the buttons that do not apply to stock to disabled and the rest enabled.
            currentView = "stock";

            LoadStock();
            
            gbCurrentView.Text = "Currently Viewing: Stock";

            btnAdd.Text = "New Stock";
            btnRemove.Text = "Delete Stock Record";
            btnEdit.Text = "Edit Stock Record";
            btnReturned.Enabled = false;
            btnShowItems.Enabled = false;
            btnMarkLost.Enabled = true;
        }

        //Loads the stock records onto the main view table.
        private void LoadStock(string Search = null)
        {
            //If the string Search is not null only records containing that string will show up.
            string sql = "select Stock.ItemName, Stock.QuantityOwned, Stock.QuantityStock, Stock.QuantityBroken, Stock.Cost, Stock.ItemID from Stock";

            if (!string.IsNullOrWhiteSpace(Search))
            {
                sql += @" where Stock.ItemName like '%" + Search + "%'";
            }

            SqlCommand Cmd = new SqlCommand(sql, _DBCon);
            SqlDataAdapter Adpt = new SqlDataAdapter(Cmd);
            DataTable Table = new DataTable();
            Adpt.Fill(Table);

            mainViewTable.DataSource = Table;
        }

        //Adds a new record to the currently selected table.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //The string currentView is checked to find which table is currently being viewed. The appropriate add record form
            //is then shown and the grid refreshed.
            if (currentView == "loans")
            { 
                FormAddLoan newLoan = new FormAddLoan(_DBCon);

                newLoan.ShowDialog();

                RefreshGrid();
            }
            else if (currentView == "customers")
            {
                FormAddCustomer newCustomer = new FormAddCustomer(_DBCon);

                newCustomer.ShowDialog();

                RefreshGrid();
            }
            else if (currentView == "stock")
            {
                FormNewOrOldStock choice = new FormNewOrOldStock();

                choice.ShowDialog();

                if (choice.DialogResult == DialogResult.Yes)
                {
                    FormAddNewStock newStock = new FormAddNewStock(_DBCon);

                    newStock.ShowDialog();
                }
                else if (choice.DialogResult == DialogResult.No)
                {
                    //Checks to see if there are any items; if there are not, there are no existing items to add to.
                    if (mainViewTable.Rows.Count > 0)
                    {
                        FormAddOldStock newStock = new FormAddOldStock(_DBCon);

                        newStock.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No existing items to add stock to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                RefreshGrid();
            }
        }

        //Loads the Manage Users form.
        private void btnStaff_Click(object sender, EventArgs e)
        {
            FormManageUsers manageUsers = new FormManageUsers(_DBCon);

            manageUsers.ShowDialog();
        }

        //Loads the form that shows details of the loan.
        private void btnShowItems_Click(object sender, EventArgs e)
        {
            //Calls the loan details method if the current view is loans, then refreshes the main view table.
            if (currentView == "loans")
            {
                ShowLoanDetails();
            }

            RefreshGrid();
        }

        //Loads the form that shows details of the loan.
        private void ShowLoanDetails()
        {
            if (mainViewTable.CurrentRow != null)
            {
                DataRow Row = ((DataRowView)mainViewTable.CurrentRow.DataBoundItem).Row;

                FormLoanDetails newLoanDetails = new FormLoanDetails(_DBCon, Row);

                newLoanDetails.ShowDialog();
            }
        }

        //Causes the edit form for a record to show up if it was double clicked on the main view table.
        private void mainViewTable_DoubleClick(object sender, EventArgs e)
        {
            if (currentView == "loans")
            {
                //Shows the details of the loan
                ShowLoanDetails();

                RefreshGrid();
            }
            else if ((currentView == "customers") || (currentView == "stock"))
            {
                //Opens the edit window
                btnEdit_Click(sender, e);
            }
        }

        //Marks a loan as returned.
        private void btnReturned_Click(object sender, EventArgs e)
        {
            //Checks to see if the current view is loans and if the main view table has a loan selected.
            if ((currentView == "loans") && (mainViewTable.CurrentRow != null))
            {
                DataRow RowLoan = ((DataRowView)mainViewTable.CurrentRow.DataBoundItem).Row;

                //Cancells the return if the loan has already been marked as returned.
                if (RowLoan["Returned"].ToString() == "Yes")
                {
                    MessageBox.Show("This loan has already been returned.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Loads all the LoanLine records that correspond to the loan the user is marking as returned.
                SqlCommand CmdGetLoanLine = new SqlCommand("select * from LoanLine where LoanID = '" + Convert.ToInt32(RowLoan["LoanID"]) + "'", _DBCon);
                SqlDataAdapter AdptGetLoanLine = new SqlDataAdapter(CmdGetLoanLine);
                DataTable TableLoanLines = new DataTable();
                AdptGetLoanLine.Fill(TableLoanLines);

                //Checks to see if the loan contains at least one item.
                if (TableLoanLines.Rows.Count > 0)
                {
                    int ItemsToMark = TableLoanLines.Rows.Count;

                    SqlTransaction tran = _DBCon.BeginTransaction();

                    List<int> BrokenList = new List<int>();

                    DialogResult moreBrokenItems = MessageBox.Show("Mark any items broken?", "Broken Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    double Penalty = 0;
                    double overdueMultiplier;

                    try
                    {
                        if (moreBrokenItems == DialogResult.Yes)
                        {
                            while (moreBrokenItems == DialogResult.Yes)
                            {
                                //Prompts the user to enter which item they wish to mark as broken. Adds this item to the list of BrokenItems that was added in this return.
                                FormMarkBroken markBroken = new FormMarkBroken(_DBCon, BrokenList, RowLoan, tran);
                                if (markBroken.ShowDialog() == DialogResult.Cancel)
                                {
                                    //If the user presses cancel on the mark broken form.
                                    tran.Rollback();

                                    MessageBox.Show("Loan marked as returned", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    return;
                                }
                                BrokenList.Add(markBroken.MarkedItem);

                                //Loads the LoanLine records for this loan that contain the specified item.
                                SqlCommand CmdGetThisLine = new SqlCommand("select * from LoanLine where LoanLine.ItemID = " + markBroken.MarkedItem + " and LoanLine.LoanID = " 
                                    + Convert.ToInt32(RowLoan["LoanID"]), _DBCon, tran);
                                SqlDataAdapter AdptGetThisLine = new SqlDataAdapter(CmdGetThisLine);
                                DataTable TableThisLoanLine = new DataTable();
                                AdptGetThisLine.Fill(TableThisLoanLine);

                                //Updates the stock table to move the specified item and quantity into the broken column.
                                SqlCommand CmdMarkBroken = new SqlCommand("update Stock set Stock.QuantityStock = Stock.QuantityStock + " + (Convert.ToInt32(TableThisLoanLine.Rows[0]["Quantity"]) - markBroken.MarkedQty) +
                                    ", Stock.QuantityBroken = Stock.QuantityBroken + " + markBroken.MarkedQty + " where Stock.ItemID = " + markBroken.MarkedItem, _DBCon, tran);
                                CmdMarkBroken.ExecuteNonQuery();

                                //Adds the item to the Item Repair Queue, and saves the Item Repair Queue to the database.
                                LoanItem item = new LoanItem();
                                item.ItemId = markBroken.MarkedItem;
                                item.Quantity = markBroken.MarkedQty;
                                ItemRepairQueue.Push(item);
                                HireDatabaseTools.SaveRepairQueue(tran);

                                ItemsToMark -= 1;

                                //Checks if there are any more items in the loan that have not been marked as broken. If there are, the user is asked if they wish to mark any more
                                //items from this loan returned.
                                if (ItemsToMark > 0)
                                {
                                    moreBrokenItems = MessageBox.Show("Mark any more items broken?", "Broken Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                }
                                else
                                {
                                    moreBrokenItems = DialogResult.No;
                                }
                            }
                        }

                        //Adds up the cost of all the items that have been marked broken in this loan, as the customer has to pay full price for an item if they break it.
                        foreach (int i in BrokenList)
                        {
                            Penalty += HireDatabaseTools.GetItemCost(i, tran);
                        }

                        //Checks to see if the loan is overdue, and if it is, which overdue price penalty it falls into.
                        if (Convert.ToDateTime(RowLoan["LoanDate"]).AddDays(90) < DateTime.Today)
                        {
                            //Since the cost of a loan is 25% of the cost of the items, this multiplier causes the loan to cost 125% of the total cost of the items, but removes
                            //the broken item penalty as the customer is already paying more than the items are worth.
                            overdueMultiplier = 5;
                            Penalty = 0;
                            MessageBox.Show("Loan is overdue by more than 3 months. Applying full penalty of 125% item cost and waiving repair penalty.", "Overdue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (Convert.ToDateTime(RowLoan["LoanDate"]).AddDays(30) < DateTime.Today)
                        {
                            overdueMultiplier = 1.40;
                            MessageBox.Show("Loan is overdue by more than 1 month. Applying 40% penalty.", "Overdue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //Loan is not overdue, hence the multiplier is 1 to keep the price the same.
                            overdueMultiplier = 1;
                        }

                        for (int i = 0; i <= TableLoanLines.Rows.Count - 1; i++)
                        {
                            //Updates the stock table to return all the items that have not been marked broken.
                            if (!BrokenList.Contains(Convert.ToInt32(TableLoanLines.Rows[i]["ItemID"])))
                            {
                                SqlCommand CmdReturnItem = new SqlCommand("update Stock set Stock.QuantityStock = Stock.QuantityStock + " + TableLoanLines.Rows[i]["Quantity"] + 
                                    " where Stock.ItemID = " + TableLoanLines.Rows[i]["ItemID"], _DBCon, tran);
                                CmdReturnItem.ExecuteNonQuery();
                            }
                        }

                        //Marks the loan record as returned, updates the price with any penalties, and sets the date to today's date.
                        SqlCommand CmdReturnLoan = new SqlCommand("update Loans set Loans.Returned = 'Yes', Loans.ReturnDate = '" + (DateTime.Today).ToString("s") +
                                        "', Loans.Cost = (Loans.Cost + " + Penalty + ") * (" + overdueMultiplier + ") where Loans.LoanID = '" + RowLoan["LoanID"] + "'", _DBCon, tran);
                        CmdReturnLoan.ExecuteNonQuery();

                        tran.Commit();

                        MessageBox.Show("Loan marked as returned", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        //An error occured with the database, hence the transaction is rolled back to protect data integrity.
                        tran.Rollback();

                        throw;
                    }
                }
            }

            RefreshGrid();
        }

        //Edits a record.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Checks to see if a record is selected on the main view table. If it is, the appropriate edit form is loaded.
            if (mainViewTable.CurrentRow != null)
            {
                if (currentView == "customers")
                {
                    DataRow Row = ((DataRowView)mainViewTable.CurrentRow.DataBoundItem).Row;

                    FormEditCustomer editCustomer = new FormEditCustomer(_DBCon, Row);
                    editCustomer.ShowDialog();

                    RefreshGrid();
                }
                else if (currentView == "stock")
                {
                    DataRow Row = ((DataRowView)mainViewTable.CurrentRow.DataBoundItem).Row;

                    FormEditItem editItem = new FormEditItem(_DBCon, Row);
                    editItem.ShowDialog();

                    RefreshGrid();
                }
                else if (currentView == "loans")
                {
                    ShowLoanDetails();

                    RefreshGrid();
                }
            }
        }

        //Removes a record.
        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Checks to see if a record is selected. If it is, checks to see which table the user is currently viewing.
            if (mainViewTable.CurrentRow != null)
            {
                if (currentView == "loans")
                {
                    DataRow Row = ((DataRowView)mainViewTable.CurrentRow.DataBoundItem).Row;

                    if (MessageBox.Show("Are you sure you want to remove this loan record? Once deleted it cannot be recovered.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        SqlTransaction tran = _DBCon.BeginTransaction();

                        try
                        {
                            //Loads any LoanLine records associated with the loan the user is trying to delete. The stock table is then updated to return all the items they contain to keep data integrity.
                            SqlCommand CmdGetMissingQuantity = new SqlCommand("select LoanLine.* from LoanLine where LoanLine.LoanID = '" + Row["LoanID"] + "'", _DBCon, tran);
                            SqlDataAdapter AdptGetMissingQuantity = new SqlDataAdapter(CmdGetMissingQuantity);
                            DataTable TableGetMissingQuantity = new DataTable();
                            AdptGetMissingQuantity.Fill(TableGetMissingQuantity);

                            if (TableGetMissingQuantity.Rows.Count > 0)
                            {
                                for (int i = 0; i <= TableGetMissingQuantity.Rows.Count - 1; i++)
                                {
                                    SqlCommand CmdFixQuantity = new SqlCommand("update Stock set Stock.QuantityStock = Stock.QuantityStock + " + TableGetMissingQuantity.Rows[i]["Quantity"] + " where Stock.ItemID = " + TableGetMissingQuantity.Rows[i]["ItemID"], _DBCon, tran);
                                    CmdFixQuantity.ExecuteNonQuery();
                                }
                            }

                            //All LoanLine records and the loan record itself are removed from the database.
                            SqlCommand CmdDelLines = new SqlCommand("delete from LoanLine where LoanLine.LoanID = '" + Row["LoanID"] + "'", _DBCon, tran);
                            SqlCommand CmdDelLoan = new SqlCommand("delete from Loans where Loans.LoanID = '" + Row["LoanID"] + "'", _DBCon, tran);
                            
                            CmdDelLines.ExecuteNonQuery();
                            CmdDelLoan.ExecuteNonQuery();

                            MessageBox.Show("Loan record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            tran.Commit();

                            RefreshGrid();
                        }
                        catch (Exception ex)
                        {
                            //There was a database error, hence the transaction is rolled back to protect data integrity.
                            tran.Rollback();

                            throw;
                        }
                    }
                }
                else if (currentView == "customers")
                {
                    //Checks to see if there are any loan records using this customer record.
                    DataRow Row = ((DataRowView)mainViewTable.CurrentRow.DataBoundItem).Row;

                    SqlCommand CmdCheckUseCustomer = new SqlCommand("select * from Loans where Loans.CustomerID = '" + Row["CustomerID"] + "'", _DBCon);
                    SqlDataAdapter AdptCheckUseCustomer = new SqlDataAdapter(CmdCheckUseCustomer);
                    DataTable TableCheckUseCustomer = new DataTable();
                    AdptCheckUseCustomer.Fill(TableCheckUseCustomer);

                    if (TableCheckUseCustomer.Rows.Count > 0)
                    {
                        MessageBox.Show("This customer cannot be deleted as they are part of at least one loan record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure you want to remove this customer record? Once deleted it cannot be recovered.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            SqlTransaction tran = _DBCon.BeginTransaction();

                            try
                            {
                                //Deletes the customer record from the database.
                                SqlCommand CmdDelCustomer = new SqlCommand("delete from Customers where Customers.CustomerID = '" + Row["CustomerID"] + "'", _DBCon, tran);
                                CmdDelCustomer.ExecuteNonQuery();

                                MessageBox.Show("Customer record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                tran.Commit();

                                btnCustomers_Click(sender, e);                                
                            }
                            catch (Exception ex)
                            {
                                //There was a database error, hence the transaction is rolled back to protect data integrity.
                                tran.Rollback();

                                throw;
                            }
                        }
                    }
                }
                else if (currentView == "stock")
                {
                    //Checks to see if there are any LoanLine records that contain this item.
                    DataRow Row = ((DataRowView)mainViewTable.CurrentRow.DataBoundItem).Row;

                    SqlCommand CmdCheckUseStock = new SqlCommand("select * from LoanLine where LoanLine.ItemID = '" + Row["ItemID"] + "'", _DBCon);
                    SqlDataAdapter AdptCheckUseStock = new SqlDataAdapter(CmdCheckUseStock);
                    DataTable TableCheckUseStock = new DataTable();
                    AdptCheckUseStock.Fill(TableCheckUseStock);

                    //If there are no LoanLine records that contain this item and this item is not in the Item Repair Queue, proceed with the deletion.
                    if ((TableCheckUseStock.Rows.Count > 0) || ItemRepairQueue.ContainsItem(Convert.ToInt32(Row["ItemID"])))
                    {
                        MessageBox.Show("This item cannot be deleted as it is part of at least one loan record, or is in the repair queue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure you want to remove this item record? Once deleted it cannot be recovered.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            SqlTransaction tran = _DBCon.BeginTransaction();

                            try
                            {
                                //Deletes the stock record.
                                SqlCommand CmdDelStock = new SqlCommand("delete from Stock where Stock.ItemID = '" + Row["ItemID"] + "'", _DBCon, tran);
                                CmdDelStock.ExecuteNonQuery();

                                MessageBox.Show("Item record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                tran.Commit();

                                btnStock_Click(sender, e);
                            }
                            catch (Exception ex)
                            {
                                //There was a database error, hence the transaction is rolled back to protect data integrity.
                                tran.Rollback();

                                throw;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No row selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Opens the Item Repair Queue form.
        private void btnRepair_Click(object sender, EventArgs e)
        {
            //Checks to see whether the Item Repair Queue is empty. If it isn't, the Item Repair Queue form is shown.
            if (ItemRepairQueue.length == 0)
            {
                MessageBox.Show("No items in need of repair.", "No broken items", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FormRepairs showRepairs = new FormRepairs(_DBCon);
                showRepairs.ShowDialog();
            }

            RefreshGrid();
        }

        //Sets the search string when the search button is pressed.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshGrid(txtSearch.Text);
        }

        //Checks to see if the search string is empty, if it is the main view table is returned to normal.
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                RefreshGrid();
            }
        }

        //Clears the search string, returns the main view table to normal.
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";

            RefreshGrid();
        }

        //Marks an item as lost.
        private void btnMarkLost_Click(object sender, EventArgs e)
        {
            //Checks to see if a record is selected on the main view table.
            if (mainViewTable.CurrentRow != null)
            {
                DataRow Row = ((DataRowView)mainViewTable.CurrentRow.DataBoundItem).Row;

                if (Convert.ToInt32(Row["QuantityStock"]) > 0)
                {
                    //Prompts the user for the number of this item they would like to mark as lost.
                    FormGetNumber getNum = new FormGetNumber("How many of item " + Row["ItemName"] + " would you like to mark as lost?", 1, Convert.ToInt32(Row["QuantityStock"]), 1);

                    //Cancels if the user pressed cancel on the form that allows them to input a number.
                    if (getNum.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }

                    SqlTransaction tran = _DBCon.BeginTransaction();

                    try
                    {
                        //Removes the input amount of said item from the stock table in the database.
                        SqlCommand CmdMarkLost = new SqlCommand("update Stock set Stock.QuantityStock = Stock.QuantityStock - " + getNum.Input + ", Stock.QuantityOwned = Stock.QuantityOwned - "
                            + getNum.Input + " where Stock.ItemID = " + Row["ItemID"], _DBCon, tran);
                        CmdMarkLost.ExecuteNonQuery();

                        tran.Commit();

                        MessageBox.Show("Items marked as lost", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        //There was a database error, hence the transaction is rolled back to protect data integrity.
                        tran.Rollback();

                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("No items of this type current in stock that can be marked as lost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No item selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshGrid();
        }
    }
}
