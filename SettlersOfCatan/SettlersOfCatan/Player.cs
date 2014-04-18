using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        //only public for testing
        public Hand playerHand;
        private Player playerToTradeWith;
        private int[] toTrade;
        private int[] toReceive;
        private String name;
        private Color color;
        private bool hasWon;
        private World world;

        public Player()
        {
            this.points = 0;
            this.citiesPlayed = 0;
            this.settlementsPlayed = 0;
            this.roadsPlayed = 0;
            this.playerHand = new Hand();
            this.toTrade = new int[5] { 0, 0, 0, 0, 0 };
            this.toReceive = new int[5] { 0, 0, 0, 0, 0 };
            this.playerToTradeWith = null;
            this.hasWon = false;
            this.world = new World();
        }

        public Player(String playerName, Color playerColor, World world1)
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
            this.hasWon = false;
            this.world = world1;
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

        public void proposeTrade(Player player, int[] trade, int[] receive)
        {
            this.toTrade = trade;
            this.toReceive = receive;
            playerToTradeWith = player;
            player.toReceive = trade;
            player.toTrade = receive;
            player.playerToTradeWith = this;
        }

        private bool canAcceptTrade()
        {
            return (this.playerToTradeWith.playerHand.getOre() >= this.toReceive[0] &&
                this.playerToTradeWith.playerHand.getWool() >= this.toReceive[1] &&
                this.playerToTradeWith.playerHand.getLumber() >= this.toReceive[2] &&
                this.playerToTradeWith.playerHand.getGrain() >= this.toReceive[3] &&
                this.playerToTradeWith.playerHand.getBrick() >= this.toReceive[4] &&
                this.playerHand.getOre() >= this.toTrade[0] &&
                this.playerHand.getWool() >= this.toTrade[1] &&
                this.playerHand.getLumber() >= this.toTrade[2] &&
                this.playerHand.getGrain() >= this.toTrade[3] &&
                this.playerHand.getBrick() >= this.toTrade[4]);
        }

        public void tradeCards(int[] trade, int[] receive)
        {
            this.playerHand.modifyOre(receive[0] - trade[0]);
            this.playerHand.modifyWool(receive[1] - trade[1]);
            this.playerHand.modifyLumber(receive[2] - trade[2]);
            this.playerHand.modifyGrain(receive[3] - trade[3]);
            this.playerHand.modifyBrick(receive[4] - trade[4]);
        }

        public void acceptTrade(Player player, int[] trade, int[] receive)
        {
            if (this.canAcceptTrade())
            {
                tradeCards(trade, receive);
                player.tradeCards(receive, trade);
            }
            else
            {
                throw new ArgumentException("Player's cards are such that trade cannot be performed");
            }
        }

        public void declineTrade()
        {
            this.toTrade = new int[] { 0, 0, 0, 0, 0 };
            this.toReceive = new int[] { 0, 0, 0, 0, 0 };
            //this.playerToTradeWith.declineTrade();
            this.playerToTradeWith = null;
        }

        public Hand getHand()
        {
            return playerHand;
        }

        public void incrementPoints(int amount)
        {
            this.points += amount;
            if (this.points >= 10)
                this.hasWon = true;
        }

        public int getPoints()
        {
            return this.points;
        }

        public bool hasWonGame()
        {
            return this.hasWon;
        }


        public void tradeWithBank(String resourceToTradeIn, String resourceToGain)
        {
            if (resourceToTradeIn.ToLower().Equals("ore"))
            {
                if (getHand().getOre() >= 4)
                {
                    try
                    {
                        this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("ore", 4);
                        this.playerHand.modifyOre(-4);
                        modifyResourceInHand(resourceToGain);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                }
            }
            else if (resourceToTradeIn.ToLower().Equals("wool"))
            {
                if (getHand().getWool() >= 4)
                {
                    try
                    {
                        this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("wool", 4);
                        this.playerHand.modifyWool(-4);
                        modifyResourceInHand(resourceToGain);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                }

            }
            else if (resourceToTradeIn.ToLower().Equals("lumber"))
            {
                if (getHand().getLumber() >= 4)
                {
                    try
                    {
                        this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("lumber", 4);
                        this.playerHand.modifyLumber(-4);
                        modifyResourceInHand(resourceToGain);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                }

            }
            else if (resourceToTradeIn.ToLower().Equals("grain"))
            {
                if (getHand().getGrain() >= 4)
                {
                    try
                    {
                        this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("grain", 4);
                        this.playerHand.modifyGrain(-4);
                        modifyResourceInHand(resourceToGain);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                }

            }
            else if (resourceToTradeIn.ToLower().Equals("brick"))
            {
                if (getHand().getBrick() >= 4)
                {
                    try
                    {
                        this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("brick", 4);
                        this.playerHand.modifyBrick(-4);
                        modifyResourceInHand(resourceToGain);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                }
            }
        }

        // Need to know if port trades 2 or 3 resources in for something 
        // but for now, I'm assuming 3 resources
        public void tradeAtPort(int portType, String resourceToGain, String resourceToTrade)
        {
            if (resourceToTrade.ToLower().Equals("ore"))
            {
                if (getHand().getOre() >= 3)
                {
                    try
                    {
                        this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("ore", 3);
                        this.playerHand.modifyOre(-3);
                        modifyResourceInHand(resourceToGain);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                }
            }
            else if (resourceToTrade.ToLower().Equals("wool"))
            {
                if (getHand().getWool() >= 3)
                {
                    try
                    {
                        this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("wool", 3);
                        this.playerHand.modifyWool(-3);
                        modifyResourceInHand(resourceToGain);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                }

            }
            else if (resourceToTrade.ToLower().Equals("lumber"))
            {
                if (getHand().getLumber() >= 3)
                {
                    try
                    {
                        this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("lumber", 3);
                        this.playerHand.modifyLumber(-3);
                        modifyResourceInHand(resourceToGain);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                }

            }
            else if (resourceToTrade.ToLower().Equals("grain"))
            {
                if (getHand().getGrain() >= 3)
                {
                    try
                    {
                        this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("grain", 3);
                        this.playerHand.modifyGrain(-3);
                        modifyResourceInHand(resourceToGain);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                }

            }
            else if (resourceToTrade.ToLower().Equals("brick"))
            {
                if (getHand().getBrick() >= 3)
                {
                    try
                    {
                        this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("brick", 3);
                        this.playerHand.modifyBrick(-3);
                        modifyResourceInHand(resourceToGain);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw;
                    }
                }
            }
        }

        public void tradeForDevCard()
        {
            if (getHand().getOre() >= 1 && getHand().getGrain() >= 1 && getHand().getWool() >= 1)
            {
                try
                {
                    this.world.bank.modifyResource("devcard", -1);
                    this.world.bank.modifyResource("ore", 1);
                    this.world.bank.modifyResource("wool", 1);
                    this.world.bank.modifyResource("grain", 1);
                    this.playerHand.modifyOre(-1);
                    this.playerHand.modifyWool(-1);
                    this.playerHand.modifyGrain(-1);
                    this.playerHand.modifyDevCard(1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }
        }

        private void modifyResourceInHand(String resource)
        {
            if (resource.ToLower().Equals("ore"))
            {
                this.playerHand.modifyOre(1);
            }
            else if (resource.ToLower().Equals("wool"))
            {
                this.playerHand.modifyWool(1);
            } 
            else if (resource.ToLower().Equals("lumber"))
            {
                this.playerHand.modifyLumber(1);
            }
            else if (resource.ToLower().Equals("grain"))
            {
                this.playerHand.modifyGrain(1);
            }
            else if (resource.ToLower().Equals("brick"))
            {
                this.playerHand.modifyBrick(1);
            }
        }

        public void generateOre()
        {
            for (int i = 0; i < this.citiesPlayed; i++)
            {
                try
                {
                    this.world.bank.modifyResource("ore", -2);
                    this.playerHand.modifyOre(2);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }
            
            for (int i = 0; i < this.settlementsPlayed; i++)
            {
                try
                {
                    this.world.bank.modifyResource("ore", -1);
                    this.playerHand.modifyOre(1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }
        }

        public void generateWool()
        {
            for (int i = 0; i < this.citiesPlayed; i++)
            {
                try
                {
                    this.world.bank.modifyResource("wool", -2);
                    this.playerHand.modifyWool(2);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }

            for (int i = 0; i < this.settlementsPlayed; i++)
            {
                try
                {
                    this.world.bank.modifyResource("wool", -1);
                    this.playerHand.modifyWool(1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }
        }

        public void generateLumber()
        {
            for (int i = 0; i < this.citiesPlayed; i++)
            {
                try
                {
                    this.world.bank.modifyResource("lumber", -2);
                    this.playerHand.modifyLumber(2);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }

            for (int i = 0; i < this.settlementsPlayed; i++)
            {
                try
                {
                    this.world.bank.modifyResource("lumber", -1);
                    this.playerHand.modifyLumber(1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }
        }

        public void generateGrain()
        {
            for (int i = 0; i < this.citiesPlayed; i++)
            {
                try
                {
                    this.world.bank.modifyResource("grain", -2);
                    this.playerHand.modifyGrain(2);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }

            for (int i = 0; i < this.settlementsPlayed; i++)
            {
                try
                {
                    this.world.bank.modifyResource("grain", -1);
                    this.playerHand.modifyGrain(1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }
        }
        
        public void generateBrick()
        {
            for (int i = 0; i < this.citiesPlayed; i++)
            {
                try
                {
                    this.world.bank.modifyResource("brick", -2);
                    this.playerHand.modifyBrick(2);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }

            for (int i = 0; i < this.settlementsPlayed; i++)
            {
                try
                {
                    this.world.bank.modifyResource("brick", -1);
                    this.playerHand.modifyBrick(1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }
        }

        public bool canBuildCity()
        {
            if (this.playerHand.getGrain() >= 3 && this.playerHand.getOre() >= 2)
                return true;
            else
                return false;
        }

        public bool canBuildSettlement()
        {
            if (this.playerHand.getBrick() >= 1 && this.playerHand.getGrain() >= 1 && this.playerHand.getLumber() >= 1 && this.playerHand.getWool() >= 1)
                return true;
            else
                return false;
        }

        public bool canBuildRoad()
        {
            if (this.playerHand.getBrick() >=1 && this.playerHand.getLumber() >= 1)
                return true;
            else
                return false;
        }

        public void buildRoad()
        {
            this.playerHand.modifyBrick(-1);
            this.playerHand.modifyLumber(-1);
        }

        public void buildCity()
        {
            this.playerHand.modifyGrain(-3);
            this.playerHand.modifyOre(-2);
        }

        public void buildSettlement()
        {
            this.playerHand.modifyGrain(-1);
            this.playerHand.modifyLumber(-1);
            this.playerHand.modifyBrick(-1);
            this.playerHand.modifyWool(-1);
        }
    }
}
