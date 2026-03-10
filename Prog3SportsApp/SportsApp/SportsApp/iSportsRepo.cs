using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public interface iSportsRepo
    {
        void AddSport(Sport sport);
        void RemoveSport(Sport sport);
        List<Sport> GetAllSports();
        void UpdateSport(Sport sport);
    }

    public interface iTeamRepo
    {
        void AddTeam(Team team);
        Team? GetTeamByName(string name);
        IEnumerable<Team> GetTeamsBySport(Sport sport);
        List<Team> GetAllTeams();
        void LoadTeamsFromFile(string filePath);
    }

}
