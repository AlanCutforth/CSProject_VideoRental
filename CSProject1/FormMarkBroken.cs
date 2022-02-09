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
    public partial class FormMarkBroken : Form
    {
        private SqlConnection _DBCon;

        private bool itemSelected = false;

        private int _LoanID;
        private int _CustomerID;
        private decimal _Cost;

        public int MarkedItem { get; set; }
        public int MarkedQty { get; set; }
        public int TotalQtyLoaned { get; set; }

        public FormMarkBroken(SqlConnection DBCon, List<int> AlreadyMarked, DataRow Row, SqlTransaction tran)
        {
            //Initialises and sets up database connection, along with some variables from the selected item from the Main Form.
            InitializeComponent();

            _DBCon = DBCon;

            _LoanID = Convert.ToInt32(Row["LoanID"]);
            _CustomerID = Convert.ToInt32(Row["CustomerID"]);
            _Cost = Convert.ToDecimal(Row["Cost"]);

            //Uses the string AlreadyMarkedString to contain a snippet for adding onto the end of the command that fills the combo box, telling it not to list items that have already been marked broken.
            string AlreadyMarkedString = "";

            foreach(int i in AlreadyMarked)
            {
                AlreadyMarkedString = AlreadyMarkedString + " and LoanLine.ItemID <> '" + i + "'";
            }

            //Fills loan bar at the top of window
            SqlCommand CmdLoan = new SqlCommand(@"
                select Loans.Cost, Loans.LoanDate, Loans.ReturnDate, Loans.Returned, Customers.Forename, Customers.Surname, Loans.LoanID 
                from Loans join Customers on Customers.CustomerID = Loans.CustomerID where Loans.LoanID = '" + _LoanID + "'", _DBCon, tran);
            SqlDataAdapter AdptLoan = new SqlDataAdapter(CmdLoan);
            DataTable TableLoan = new DataTable();
            AdptLoan.Fill(TableLoan);

            dataGridLoan.DataSource = TableLoan;

            //Fills the item selection combo box
            SqlCommand cmdFillItemcb = new SqlCommand("select Stock.ItemName + ' Number Rented: ' + cast(LoanLine.Quantity as varchar) as FullName, LoanLine.LineID, LoanLine.ItemID, LoanLine.Quantity from LoanLine join Stock on Stock.ItemID = LoanLine.ItemID where LoanLine.LoanID = '" + _LoanID + "'" + AlreadyMarkedString, _DBCon, tran);
            SqlDataAdapter AdptFillItemcb = new SqlDataAdapter(cmdFillItemcb);
            DataTable TableFillItemcb = new DataTable();
            AdptFillItemcb.Fill(TableFillItemcb);

            cbItem.DataSource = TableFillItemcb;
            cbItem.DisplayMember = "FullName";
        }

        //Closes the form.
        private void btnCancelMarkBroken_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //Confirms the marking of the chosen item as broken.
        private void btnConfMarkBroken_Click(object sender, EventArgs e)
        {
            //Double checks if the value specified in the number picker is valid, then sets the variables that pass the ItemID and quantity to mark broken to the main form.
            DataRowView RowView = (DataRowView)cbItem.SelectedItem;

            TotalQtyLoaned = Convert.ToInt32(RowView.Row["Quantity"]);

            if (TotalQtyLoaned < nudQty.Value)
            {
                MessageBox.Show("Cannot mark more items broken than were rented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (nudQty.Value < 1)
            {
                MessageBox.Show("Cannot mark 0 or less items broken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MarkedItem = Convert.ToInt32(RowView.Row["ItemID"]);
                MarkedQty = Convert.ToInt32(nudQty.Value);

                this.DialogResult = DialogResult.OK;
            }
        }

        //Fixes the chosen quantity of items if the user tries to increase or decrease it out of bounds.
        private void nudQty_ValueChanged(object sender, EventArgs e)
        {
            if(itemSelected)
            {
                fixQty();
            }
        }

        //Shwos that an item has been selected, then fixes the quantity of the number picker to mathc if needed.
        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemSelected = true;

            fixQty();
        }

        //Fixes the number picker value so it cannot be out of bounds of the number of items loaned.
        private void fixQty()
        {
            DataRowView RowView = (DataRowView)cbItem.SelectedItem;

            if (Convert.ToInt32(RowView.Row["Quantity"]) < nudQty.Value)
            {
                nudQty.Value = Convert.ToInt32(RowView.Row["Quantity"]);
            }
            else if (nudQty.Value < 1)
            {
                nudQty.Value = 1;
            }
        }
    }
}
