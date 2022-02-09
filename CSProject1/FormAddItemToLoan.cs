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
    public partial class FormAddItemToLoan : Form
    {
        
        private SqlConnection _DBCon;

        private List<LoanItem> AlreadyAdded = new List<LoanItem>();
        
        //Creates a new LoanItem that this form will pass back to the FormAddLoan that created it.
        private LoanItem _Item = new LoanItem();
        public LoanItem Item
        {
            get
            {
                return _Item;
            }
        }

        public FormAddItemToLoan(SqlConnection DBCon, List<LoanItem> _ItemList)
        {
            //Sets up the database connection and passes the list of items that have already been added to the loan.
            InitializeComponent();

            _DBCon = DBCon;

            AlreadyAdded = _ItemList;
        }

        private void FormAddItemToLoan_Load(object sender, EventArgs e)
        {
            string AddedIDs = "";

            //Adds the ID of each item that has already been added to the SQL Query to ensure an item can only exist on a loan once (but can have a quantity greater than 1 still).
            foreach (LoanItem i in AlreadyAdded)
            {
                AddedIDs = AddedIDs + " and Stock.ItemID <> " + i.ItemId.ToString();
            }
            SqlCommand CmdAddItemLoan = new SqlCommand("select Stock.ItemName, Stock.ItemID, Stock.QuantityStock, Stock.Cost, Stock.ItemName + ' In stock: ' + cast(Stock.QuantityStock as varchar) as DisplayName" +
                " from Stock where Stock.QuantityStock > 0" + AddedIDs, _DBCon);
            SqlDataAdapter AdptAddItemLoan = new SqlDataAdapter(CmdAddItemLoan);
            DataTable TableLoan = new DataTable();
            AdptAddItemLoan.Fill(TableLoan);

            //Checks to see if there are any items left to add to the loan - if there aren't, the window is closed. The combo box containing item names is then passed the items that are left.
            if (TableLoan.Rows.Count == 0)
            {
                MessageBox.Show("No items in stock or this loan contains every item in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = DialogResult.Cancel;
            }

            cbItemToAdd.DataSource = TableLoan;
            cbItemToAdd.DisplayMember = "DisplayName";

            //Sets the default quantity of this item to add as 1.
            txtQty.Text = "1";
        }

        //Lowers the quantity of this item on this loan by 1.
        private void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(txtQty.Text);

                DataRowView RowView = (DataRowView)cbItemToAdd.SelectedItem;

                if (Convert.ToInt32(txtQty.Text) < 2)
                {
                    MessageBox.Show("Rental of less than 1 item is not possible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtQty.Text = (Convert.ToInt32(txtQty.Text) - 1).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid quantity in the box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Increases the quantity of this item on this loan by 1.
        private void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(txtQty.Text);

                DataRowView RowView = (DataRowView)cbItemToAdd.SelectedItem;

                if ((Convert.ToInt32(txtQty.Text) + 1) > Convert.ToInt32(RowView.Row["QuantityStock"]))
                {
                    MessageBox.Show("The quantity you have chosen is higher than the current stock of the item available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtQty.Text = (Convert.ToInt32(txtQty.Text) + 1).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid quantity in the box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Closes the window.
        private void btnCancelAddItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //Confirms the addition of this item to the loan by setting the LoanItem that belongs to this form to the properties of the item chosen in the combo box, then closes the window.
        public void btnConfAddItem_Click(object sender, EventArgs e)
        {
            DataRowView RowView = (DataRowView)cbItemToAdd.SelectedItem;

            Item.ItemId = Convert.ToInt32(RowView.Row["ItemID"]);
            Item.Quantity = Convert.ToInt32(txtQty.Text);
            Item.Cost = (Convert.ToDecimal(RowView.Row["Cost"]) * Item.Quantity);

            this.DialogResult = DialogResult.OK;
        }
    }
}
