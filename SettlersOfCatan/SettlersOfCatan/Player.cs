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
        private Player playerToTradeWith;
        private int[] toTrade;
        private int[] toReceive;

        public Player()
        {
            points = 0;
            citiesPlayed = 0;
            settlementsPlayed = 0;
            roadsPlayed = 0;
            playerHand = new Hand();
            toTrade = new int[5] { 0, 0, 0, 0, 0 };
            toReceive = new int[5] { 0, 0, 0, 0, 0 };
            playerToTradeWith = null;
        }

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

        public Hand getHand()
        {
            return playerHand;
        }

        public void tradeWithBank(String resource)
        {
            //TODO reference bank inside of World class
        }

        public void tradeAtPort(int portType, String resource)
        {
            //TODO reference bank inside of world class
        }
    }
}
