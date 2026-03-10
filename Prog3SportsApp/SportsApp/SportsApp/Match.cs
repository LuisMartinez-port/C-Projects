using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public class Match
    {
        public Player Team1 { get; private set; }
        public Player Team2 { get; private set; }
        public DateTime DateTime { get; private set; }
        public int Team1Score { get; private set; }
        public int Team2Score { get; private set; }
        public Player? Winner { get; private set; }

        public Match(Player team1, Player team2, DateTime dateTime)
        {
            Team1 = team1;
            Team2 = team2;
            DateTime = dateTime;
        }

        public void UpdateScore(int team1Score, int team2Score)
        {
            Team1Score = team1Score;
            Team2Score = team2Score;

            // Determine winner
            if (team1Score > team2Score)
            {
                Winner = Team1;
                Team1.UpdateStats(true);
                Team2.UpdateStats(false);
            }
            else if (team2Score > team1Score)
            {
                Winner = Team2;
                Team2.UpdateStats(true);
                Team1.UpdateStats(false);
            }
        }

        public string MatchDescription => $"{Team1.Name} vs {Team2.Name} on {DateTime:MM-dd-yyyy}";

        public override string ToString()
        {
            string result = $"{DateTime:MM-dd-yyyy}: {Team1.Name} vs {Team2.Name} - Score: {Team1Score}:{Team2Score}";
            if (Winner != null)
                result += $" | Winner: {Winner.Name}";
            return result;
        }
    }


}
