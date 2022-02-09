using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject1
{
    public static class ItemRepairQueue
    {
        public static int length { get; set; } = 0;
        public static LoanItem[] queueArray = new LoanItem[0];

        //Resizes the array.
        public static void Resize(int size)
        {
            Array.Resize<LoanItem>(ref queueArray, size);
        }

        //Returns the top item of the queue without removing it.
        public static LoanItem Top()
        {
            LoanItem topItem = new LoanItem();
            topItem.ItemId = queueArray[0].ItemId;
            topItem.Quantity = queueArray[0].Quantity;
            return topItem;
        }

        //Check if the queue contains a specified item.
        public static bool ContainsItem(int id)
        {
            for (int i = 0; i <= length - 1; i++)
            {
                if (queueArray[i].ItemId == id)
                {
                    return true;
                }
            }

            return false;
        }

        //Pops the top item from the top of the queue, moves all other values up by one to fill the space, and returns the popped item. This only happens if the queue is not empty;
        //if it is, an exception is thrown.
        public static LoanItem Pop()
        {
            if (length > 0)
            {
                LoanItem removed = (LoanItem)queueArray[0].Clone();
                
                for (int i = 0; i <= length - 1; i++)
                {
                    MoveUp(i);
                }

                length -= 1;

                Resize(length);

                return removed;
            }
            else
            {
                throw new System.ArgumentException("queue empty");
            }
        }

        //Adds an item to the bottom of the queue. If the queue already contains the specified item, the quantity of the pushed item is added to the quantity of that item insteaad.
        public static void Push(LoanItem value)
        {
            bool alreadyContains = false;

            //Checks if the queue contains the Pushed item. If it does, updates the quantity for that item.
            if (ContainsItem(value.ItemId))
            {
                for (int i = 0; i <= length - 1; i++)
                {
                    if (queueArray[i].ItemId == value.ItemId)
                    {
                        alreadyContains = true;
                        queueArray[i].Quantity += value.Quantity;
                    }
                }
            }

            //Queue does not contain the pushed item already, hence the queue is resized to fit it and it is added to the queue at the end.
            if (!alreadyContains)
            {
                length += 1;
                Resize(length);
                queueArray[length - 1] = value;
            }
        }
        
        //Moves an item up in the repair queue.
        public static void MoveUp(int place)
        {
            if (place > 0)
            {
                LoanItem oldTop = queueArray[place - 1];
                queueArray[place - 1] = queueArray[place];
                queueArray[place] = oldTop;
            }
        }

        //Moves an item down in the repair queue.
        public static void MoveDown(int place)
        {
            if (place < length - 1)
            {
                LoanItem oldBelow = queueArray[place + 1];
                queueArray[place + 1] = queueArray[place];
                queueArray[place] = oldBelow;
            }
        }

        //Subtracts a certain quantity from the item at the top of the queue.
        public static void RemoveQty(int value)
        {
            //Checks to see if the user is removing the entire quantity from the top of the queue: if they are, Pop is called, else the specified quantity is subtracted
            //from the item at the top of the queue.
            if (value >= queueArray[0].Quantity)
            {
                Pop();
            }
            else
            {
                queueArray[0].Quantity -= value;
            }
        }

        //Returns the place in the queue for a particular BrokenItem.
        public static int GetPlace(LoanItem value)
        {
            //If the selected item is not in the queue, an exception is thrown.
            for (int i = 0; i <= length; i++)
            {
                if (value == queueArray[i])
                {
                    return i;
                }
            }

            throw new System.ArgumentException("not found");
        }
    }
}



