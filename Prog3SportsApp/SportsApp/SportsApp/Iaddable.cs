using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public interface Iaddable
    {
        void AddPlayer(Player player);
        void RemovePlayer(Player player);
    }
}
