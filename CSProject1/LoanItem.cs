using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject1
{
    //Class used to store the ItemID, Quantity and Cost of a particular item.
    public class LoanItem: ICloneable
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }

        //Returns a string containing the name of the item and the quantity: Used for display strings in listboxes etc.
        public string Display
        {
            get
            {
                if (ItemId > 0)
                {
                    return HireDatabaseTools.GetItemName(ItemId) + " Qty: " + Quantity;
                }
                else
                {
                    return "null";
                }
            }
        }

        //Returns a string containing the name of the item, the quantity and the cost: Used for display strings in listboxes etc.
        public string DisplayCost
        {
            get
            {
                if (ItemId > 0)
                {
                    return HireDatabaseTools.GetItemName(ItemId) + " Qty: " + Quantity + " Cost: £" + Cost;
                }
                else
                {
                    return "null";
                }
            }
        }

        //Allows the item to be cloned.
        public object Clone()
        {
            LoanItem NewItem = new LoanItem();

            NewItem.ItemId = ItemId;
            NewItem.Quantity = Quantity;

            return NewItem;
        }
    }
}
