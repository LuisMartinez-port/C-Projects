using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public interface iTeam : Iaddable
    {
        string Name { get; set; }
        void AddPlayer(Player player);
        void RemovePlayer(Player player);
    }
}
