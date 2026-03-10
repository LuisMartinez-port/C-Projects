using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingIICraftDemoPages
{
    public class Item
    {
        public string ItemName = "";
        public string ItemDescription = "";
        public double ItemValue = 0;
        public double ItemAmount = 1;
        public string ItemAmountType = "cup(s)";
        string space = "      ";

        public Item() { }

        public Item(string itemName, string itemDescription, double itemValue, double itemAmount, string ItemAmmountType) 
        { 
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemValue = itemValue;
            ItemAmount = itemAmount;
            ItemAmountType = ItemAmmountType;
        }

        public string GetItemDescription()
        {
            return $"{ItemAmount} {ItemAmountType} {ItemName} ({ItemValue.ToString("C")} ea)\n{space}{space}{space}{ItemDescription}\n";
        }
        // 2 tbsp of milk 
        //put amount conversion in 
        //some items should be above average of value
        // sell for 5.00 profit margin 2.00
    }
}
