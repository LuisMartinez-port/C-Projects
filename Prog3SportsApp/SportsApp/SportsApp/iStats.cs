using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public interface iStats
    {
        int Wins { get; set; }
        int Losses { get; set; }
        int MatchesPlayed { get; set; }
        void UpdateStats(bool isWin);
    }
}
