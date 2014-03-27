using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SettlersOfCatan
{
    class Player
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
        private String name;
        private Color color;

        public Player(String playerName, Color playerColor)
        {
            this.name = playerName;
            this.color = playerColor;
            this.points = 0;
            this.citiesPlayed = 0;
            this.settlementsPlayed = 0;
            this.roadsPlayed = 0;
            this.playerHand = new Hand();
            this.toTrade = new int[5] { 0, 0, 0, 0, 0 };
            this.toReceive = new int[5] { 0, 0, 0, 0, 0 };
            this.playerToTradeWith = null;
        }

        public String getName()
        {
            return this.name;
        }

        public Color getColor()
        {
            return this.color;
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

        public void proposeTrade(Player player, int[] trade, int[] recieve)
        {
            this.toTrade = trade;
            this.toReceive = recieve;
            playerToTradeWith = player;
            player.toReceive = trade;
            player.toTrade = recieve;
        }

        public void acceptTrade()
        {
            this.playerHand.modifyOre(this.toReceive[0] - this.toTrade[0]);
            this.playerHand.modifyWool(this.toReceive[1] - this.toTrade[1]);
            this.playerHand.modifyLumber(this.toReceive[2] - this.toTrade[2]);
            this.playerHand.modifyGrain(this.toReceive[3] - this.toTrade[3]);
            this.playerHand.modifyBrick(this.toReceive[4] - this.toTrade[4]);
            this.playerToTradeWith.acceptTrade();
        }

        public void declineTrade()
        {
            this.toTrade = new int[] {0,0,0,0,0};
            this.toReceive = new int[] {0,0,0,0,0};
            this.playerToTradeWith.declineTrade();
        }
    }
}
