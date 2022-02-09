using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProject1
{
    public static class HireDatabaseTools
    {
        private static SqlConnection _DBCon;

        public static string SavedPath { get; set; }

        public static void initialiseHireDataBaseTools(SqlConnection DBCon)
        {
            //Sets up the database connection.
            _DBCon = DBCon;
        }

        //Converts the passed string into MD5 hash: for use in user passwords.
        public static string HashCalculator(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }

            return builder.ToString();
        }

        //Returns the item name for the ItemID passed into it: Used for display strings on listboxes etc.
        public static string GetItemName(int id)
        {
            //Checks if the specified item exists.
            SqlCommand CmdGetName = new SqlCommand("select Stock.ItemName from Stock where Stock.ItemID = '" + id + "'", _DBCon);
            SqlDataAdapter AdptGetName = new SqlDataAdapter(CmdGetName);
            DataTable TableGetName = new DataTable();
            AdptGetName.Fill(TableGetName);

            if (TableGetName.Rows.Count > 0)
            {
                return TableGetName.Rows[0]["ItemName"].ToString();
            }
            else
            {
                return "null";
            }
        }

        //Returns the item cost for the ItemIDD passed into it: Used for display strings on listboxes etc.
        public static double GetItemCost(int id, SqlTransaction tran = null)
        {
            //Checks if the specified item exists.
            SqlCommand CmdGetCost = new SqlCommand("select Stock.Cost from Stock where Stock.ItemID = '" + id + "'", _DBCon, tran);
            SqlDataAdapter AdptGetCost = new SqlDataAdapter(CmdGetCost);
            DataTable TableGetCost = new DataTable();
            AdptGetCost.Fill(TableGetCost);

            if (TableGetCost.Rows.Count > 0)
            {
                return Convert.ToDouble(TableGetCost.Rows[0]["Cost"]);
            }
            else
            {
                return -1;
            }
        }

        //Saves the Item Repair Queue to the database.
        public static void SaveRepairQueue(SqlTransaction tran)
        {
            //Removes all records from the ItemRepair table in the database.
            SqlCommand CmdDelQueue = new SqlCommand("delete from ItemRepair", _DBCon, tran);
            CmdDelQueue.ExecuteNonQuery();

            int Sequence = 0;

            foreach (LoanItem item in ItemRepairQueue.queueArray)
            {
                //For each item in the Item Repair Queue, adds a new row into the database containing the ItemID of the item and it's position in the queue (sequence).
                SqlCommand CmdInsertItem = new SqlCommand("insert into ItemRepair (ItemID, Sequence) values ('" + item.ItemId + "', '" + Sequence + "')", _DBCon, tran);
                CmdInsertItem.ExecuteNonQuery();

                Sequence += 1;
            }
        }

        //Loads the Item Repair Queue from the database.
        public static void LoadRepairQueue()
        {
            //Loads all records from the ItemRepair table in the database, as well as the quantity of each of the items that is broken from the Stock table.
            SqlCommand CmdLoadQueue = new SqlCommand("select ItemRepair.*, Stock.QuantityBroken from ItemRepair join Stock on ItemRepair.ItemID = Stock.ItemID order by Sequence", _DBCon);
            SqlDataAdapter AdptLoadQueue = new SqlDataAdapter(CmdLoadQueue);
            DataTable TableLoadQueue = new DataTable();
            AdptLoadQueue.Fill(TableLoadQueue);

            foreach (DataRow Row in TableLoadQueue.Rows)
            {
                //For every row returned from the database in the above query adds the item to the Item Repair Queue.
                LoanItem Item = new LoanItem();
                Item.ItemId = Convert.ToInt32(Row["ItemID"]);
                Item.Quantity = Convert.ToInt32(Row["QuantityBroken"]);

                ItemRepairQueue.Push(Item);
            }
        }
    }
}
