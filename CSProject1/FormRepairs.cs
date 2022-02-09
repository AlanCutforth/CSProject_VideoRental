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
    public partial class FormRepairs : Form
    {
        private SqlConnection _DBCon;

        private DataTable displayRepairQueue = new DataTable();

        public FormRepairs(SqlConnection DBCon)
        {
            //Initnialises and sets up the database connection, as well as refreshing the listbox that shows the queue via the method refreshQueue()
            InitializeComponent();

            _DBCon = DBCon;

            refreshQueue();
        }

        //Refreshes the listbox showing the queue.
        private void refreshQueue()
        {
            //Sets the data source null for the listbox and then re-sets it to the Item Repair Queue, counting each item in the queue between the top and bottom pointers.
            lbRepairQueue.Items.Clear();
            lbRepairQueue.DisplayMember = "Display";

            for (int i = 0; i <= ItemRepairQueue.length - 1; i++)
            {
                lbRepairQueue.Items.Add(ItemRepairQueue.queueArray[i]);
            }
        }

        //Closes the repair queue window.
        private void btnConfRepairQueue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //Moves an item up in the queue.
        private void btnUp_Click(object sender, EventArgs e)
        {
            //Checks each item in the listbox to find one that matches in the Item Repair Queue, then intiaites the queue's moveUp() method on that item.
            LoanItem RowView = (LoanItem)lbRepairQueue.SelectedItem;

            if (RowView != null)
            {
                for (int i = 0; i <= ItemRepairQueue.length - 1; i++)
                {
                    if (RowView == ItemRepairQueue.queueArray[i])
                    {
                        ItemRepairQueue.MoveUp(i);

                        SqlTransaction tran = _DBCon.BeginTransaction();
                        HireDatabaseTools.SaveRepairQueue(tran);
                        tran.Commit();

                        refreshQueue();
                    }
                }
            }
            else
            {
                MessageBox.Show("No item selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Moves an item down in the queue.
        private void btnDown_Click(object sender, EventArgs e)
        {
            //Checks each item in the listbox to find one that matches in the Item Repair Queue, then intiaites the queue's moveDown() method on that item.
            LoanItem RowView = (LoanItem)lbRepairQueue.SelectedItem;

            if (RowView != null)
            {
                for (int i = 0; i <= ItemRepairQueue.length - 1; i++)
                {
                    if (RowView == ItemRepairQueue.queueArray[i])
                    {
                        ItemRepairQueue.MoveDown(i);

                        SqlTransaction tran = _DBCon.BeginTransaction();
                        HireDatabaseTools.SaveRepairQueue(tran);
                        tran.Commit();

                        refreshQueue();
                    }
                }
            }
            else
            {
                MessageBox.Show("No item selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Marks the top item of the queue repaired.
        private void btnMarkRepaired_Click(object sender, EventArgs e)
        {
            FormGetNumber getNum = new FormGetNumber("How many were repaired?", 1, ItemRepairQueue.Top().Quantity, 1);

            //Checks if the user entered a quantity to mark repaired.
            if (getNum.ShowDialog() == DialogResult.OK)
            {
                //Checks if the user is repairing all items of this type or only a certain quantity.
                if (getNum.Input == ItemRepairQueue.Top().Quantity)
                {
                    SqlTransaction tran = _DBCon.BeginTransaction();

                    try
                    {
                        //Pops the top item from the queue and updates the database to mark this item repaired in the stock table.
                        LoanItem Fixed = new LoanItem();
                        Fixed = ItemRepairQueue.Pop();

                        SqlCommand CmdRepairItem = new SqlCommand("update Stock set Stock.QuantityBroken = 0, Stock.QuantityStock = Stock.QuantityOwned where ItemID = '" + Fixed.ItemId + "'", _DBCon, tran);
                        CmdRepairItem.ExecuteNonQuery();

                        MessageBox.Show("Item(s) repaired!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);               

                        //Saves the repair queue to the database.
                        HireDatabaseTools.SaveRepairQueue(tran);

                        tran.Commit();

                        refreshQueue();
                    }
                    catch (Exception ex)
                    {
                        //An error occured, hence the transaction is rolled back to protect data integrity.
                        tran.Rollback();

                        throw;
                    }
                }
                else if (getNum.Input < ItemRepairQueue.Top().Quantity)
                {
                    SqlTransaction tran = _DBCon.BeginTransaction();

                    try
                    {
                        //Updates the database to mark the given quantity of this item repaired in the stock table, then updates the amount of the top item in the queue that are broken.
                        SqlCommand CmdRepairItem = new SqlCommand("update Stock set Stock.QuantityBroken = Stock.QuantityBroken - '" + getNum.Input + "', Stock.QuantityStock = Stock.QuantityStock + '"
                            + getNum.Input + "' where ItemID = '" + ItemRepairQueue.Top().ItemId + "'", _DBCon, tran);
                        CmdRepairItem.ExecuteNonQuery();

                        ItemRepairQueue.RemoveQty(getNum.Input);

                        MessageBox.Show("Item(s) repaired!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tran.Commit();

                        refreshQueue();
                    }
                    catch(Exception ex)
                    {
                        //An error occured, hence the transaction is rolled back to protect data integrity.
                        tran.Rollback();

                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Number that was entered was greater than the number of broken items of that type or less than 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Marks an item as broken beyond repair.
        private void btnMarkDestroyed_Click(object sender, EventArgs e)
        {
            FormGetNumber getNum = new FormGetNumber("How many were destroyed?", 1, ItemRepairQueue.Top().Quantity, 1);

            //Checks if the user entered a number.
            if (getNum.ShowDialog() == DialogResult.OK)
            {
                //Checks if the user intends to mark all items at the top of the queue as destroyed or only a certain quantity.
                if (getNum.Input == ItemRepairQueue.Top().Quantity)
                {
                    SqlTransaction tran = _DBCon.BeginTransaction();

                    try
                    {
                        //Pops the marked item from the top of the queue, and updates the stock table in the database to account for this loss of stock.
                        LoanItem Destroyed = new LoanItem();
                        Destroyed = ItemRepairQueue.Pop();

                        SqlCommand CmdRepairItem = new SqlCommand("update Stock set Stock.QuantityBroken = 0, Stock.QuantityOwned = Stock.QuantityOwned - " + getNum.Input + ", where ItemID = '" 
                            + Destroyed.ItemId + "'", _DBCon, tran);
                        CmdRepairItem.ExecuteNonQuery();

                        MessageBox.Show("Item(s) marked destroyed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Saves the repair queue to the database.
                        HireDatabaseTools.SaveRepairQueue(tran);

                        tran.Commit();

                        refreshQueue();
                    }
                    catch (Exception ex)
                    {
                        //An error occured, hence the transaction is rolled back to protect data integrity.
                        tran.Rollback();

                        throw;
                    }
                }
                else if (getNum.Input < ItemRepairQueue.Top().Quantity)
                {
                    SqlTransaction tran = _DBCon.BeginTransaction();

                    try
                    {
                        //Updates the stock table in the database, removing the specified quantity of stock from the table and updates the quantity of the top item of the repair queue.
                        SqlCommand CmdDestroyItem = new SqlCommand("update Stock set Stock.QuantityBroken = Stock.QuantityBroken - '" + getNum.Input + "', Stock.QuantityOwned = Stock.QuantityOwned - '" + getNum.Input + "' where ItemID = '" + ItemRepairQueue.Top().ItemId + "'", _DBCon, tran);
                        CmdDestroyItem.ExecuteNonQuery();

                        ItemRepairQueue.RemoveQty(getNum.Input);

                        MessageBox.Show("Item(s) marked destroyed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tran.Commit();

                        refreshQueue();
                    }
                    catch (Exception ex)
                    {
                        //An error occured, hence the transaction is rolled back to protect data integrity.
                        tran.Rollback();

                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Number that was entered was greater than the number of broken items of that type or less than 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
