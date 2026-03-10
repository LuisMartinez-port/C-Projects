using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    class UserDefinedSport:Sport
    {
        public UserDefinedSport(string name, string description) : base(name, description)
        {
            // Additional logic for a user-defined sport can go here
        }
    }
}
