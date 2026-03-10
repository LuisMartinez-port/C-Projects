using ProgrammingIICraftDemoPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT2
{
    internal interface Iaction
    {
        void Buy(Item item, Person person);

        void Sell(Item item, Person person );

    }
}
