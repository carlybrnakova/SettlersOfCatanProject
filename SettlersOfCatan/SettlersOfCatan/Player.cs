using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlersOfCatan
{
    public class Player
    {
        private readonly int MAX_CITIES = 4;
        private readonly int MAX_SETTLEMENTS = 5;
        private readonly int MAX_ROADS = 15;

        private int points;
        private int citiesPlayed;
        private int settlementsPlayed;
        private int roadsPlayed;
        private Hand playerHand;

        public int getCitiesRemaining()
        {
            return MAX_CITIES - citiesPlayed;
        }

        public int getSettlementsRemaining()
        {
            return MAX_SETTLEMENTS - settlementsPlayed;
        }

        public int getRoadsRemaining()
        {
            return MAX_ROADS - roadsPlayed;
        }

        public bool incrementCities()
        {
            if (getCitiesRemaining() > 0)
            {
                citiesPlayed++;
                return true;
            }
            else
                return false;
        }

        public bool incrementSettlements()
        {
            if (getSettlementsRemaining() > 0)
            {
                settlementsPlayed++;
                return true;
            }
            else
                return false;
        }

        public bool incrementRoads()
        {
            if (getRoadsRemaining() > 0)
            {
                roadsPlayed++;
                return true;
            }
            else
                return false;
        }
    }
}
