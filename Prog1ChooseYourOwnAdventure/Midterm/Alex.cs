using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    public class Alex : NPC
    {
        //this is a child class  of the NPC class
        //This class will have a unique amount of Treasure they can hold

        public Alex() : base() {
            this.AmountOfTreasure = 1;
            this.NPCName = "Alex";
            this.UpperLimitAuctionValue = 14000;
            this.LowerLimitAuctionValue = 6025;

        }
    }
}
