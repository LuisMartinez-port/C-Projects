using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFirstSprint2_Luis
{
    public class Deck
    {
        public float Width;
        public string Brand;
        public bool isOffGround;

        public string About()
        {
            return $"Deck that is made by {Brand}, it also has a width of {Width} inches";
        }
        public void Pop()
        {
            //gets board in air

            isOffGround = true;
            
        }

       

    }
}
