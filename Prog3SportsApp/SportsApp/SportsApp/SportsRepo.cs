using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp
{
    public class SportsRepo : iSportsRepo
    {

        private List<Sport> sports = new List<Sport>();

        public void AddSport(Sport sport)
        {
            sports.Add(sport);
        }

        public void RemoveSport(Sport sport)
        {
            sports.Remove(sport);
        }

        public List<Sport> GetAllSports()
        {
            return sports;
        }
        public void UpdateSport(Sport sport)
        {
            var existingsport = sports.FirstOrDefault(s => s.Name == sport.Name);
            if(existingsport != null)
            {
                existingsport.Players= sport.Players;
                existingsport.Description= sport.Description;
            }
            else
            {
                sports.Add(sport);
            }

        }



        public SportsRepo()
        {
            sports.Add(new Wrestling());
            sports.Add(new StreetBall());
            sports.Add(new AirHockey());
            sports.Add(new Chess());

        }
    }
}

