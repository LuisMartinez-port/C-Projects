using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    public class Kyle : NPC
    {
        //this is a child class  of the NPC class
        //This class will have a uniwue amount of Treasure they can hold
        public Kyle() : base() {

            this.AmountOfTreasure = 2;
            this.NPCName = "Kyle";
            this.UpperLimitAuctionValue = 10000;
            this.LowerLimitAuctionValue = 3000;

        }
    }
}
