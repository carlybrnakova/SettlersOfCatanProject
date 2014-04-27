using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    public class World
    {
        public Player currentPlayer;
        public int currentPlayerNumber;
        public List<Player> players;
        public Bank bank;
        private CompleteMap catanMap;
        private int currentRoll;

        public World()
        {
            bank = new Bank();
            players = new List<Player>();
            currentRoll = 0;
        }

        public World(int humans, int computers)
        {
            bank = new Bank();
            players = new List<Player>();
            players.Add(new Player("bob", Color.Red, this));
            players.Add(new Player("joe", Color.Blue, this));
            players.Add(new Player("Anne", Color.Green, this));

            // Generate a new map for the board
            this.catanMap = new CompleteMap();
            this.currentRoll = 0;

            /*
            for (int i = 0; i < humans; i++)
            {
                Player p = new Player
                players.Add(new Player());
            }
            for (int i = 0; i < computers; i++)
            {
                //players.Add(new Computer());
            }
             */
            currentPlayer = this.players[0];
        }

        public void endTurn()
        {
            if (currentPlayerNumber < this.players.Count()-1)
            {
                currentPlayerNumber++;
            }
            else
                currentPlayerNumber = 0;
            currentPlayer = this.players[currentPlayerNumber];
        }

        private void checkWinner()
        {
            foreach (Player p in this.players){
                if (p.hasWonGame() == true){
                    //declare winner
                }
            }
        }

       

        public Color intersectionButtonClicked(Point coords)
        {
            // Build a settlement
            if(!catanMap.getIslandMap().getIntAtIndex(coords).hasABuilding())
            {
                if(catanMap.getIslandMap().getIntAtIndex(coords).canBuildAtIntersection())
                {
                    if(currentPlayer.getHand().hasSettlementResources())
                    {
                        // build a settlement here
                        this.catanMap.getIslandMap().getIntAtIndex(coords).color = this.currentPlayer.getColor();
                        catanMap.getIslandMap().getIntAtIndex(coords).setPlayer(currentPlayer);
                        this.catanMap.getIslandMap().buildSettlement(coords);
                        currentPlayer.buildSettlement();
                        return currentPlayer.getColor();
                    }
                    else
                    {
                        // pop up error message that player does not have necessary resources
                        
                        DialogResult num = MessageBox.Show("You do not have enough resources to build a settlement.",
		                "Insufficient Resources",
		                MessageBoxButtons.OK,
		                MessageBoxIcon.Exclamation);
	
                        return Color.White;
                    }
                }
                else
                {
                    // pop up error message that the surrounding area is not clear
                    DialogResult num = MessageBox.Show("The surrounding intersections are not all clear.",
                    "Insufficient Room to Build",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    return Color.White;
                }
            }
            // Build a city
            else 
            {
                if(currentPlayer.getHand().hasCityResources())
                {
                    // build a city - change button and decrement resources
                    catanMap.getIslandMap().buildCity(coords);
                    currentPlayer.buildCity();

                    return Color.Black;
                }
                else 
                {
                    DialogResult num = MessageBox.Show("You do not have enough resources to build a city.",
                    "Insufficient Resources",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    
                    return Color.White; 
                }
                  
            }            
        }

        public Color roadButtonClicked(Point coords)
        {

            return Color.White;
        }

        public void rollDice()
        {
            Random die = new Random();
            int die1Roll = die.Next(1, 7);
            int die2Roll = die.Next(1, 7);
            currentRoll = die1Roll + die2Roll;
            generateMyResources(currentRoll, false);
        }

        public int getRollNumber()
        {
            return currentRoll;
        }

        // Goes through the whole array of intersections and awards the respective
        // resources to each player settlement by settlement
        private void generateMyResources(int num, bool isItBeginningOfTheGame)
        {
            // For now, give all resources which a settlement/city is on
            IslandMap theMap = catanMap.getIslandMap();
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 11; c++)
                {
                    if (theMap.getIntAtIndex(r, c) != null && theMap.getIntAtIndex(r, c).hasABuilding())
                    {
                        giveAllResourcesForThisIntersection(theMap.getIntAtIndex(r, c), isItBeginningOfTheGame);
                    }
                }
            }
            
        }

        private void giveAllResourcesForThisIntersection(Intersection intersection, bool isItBeginningOfTheGame)
        {
            Hand hand = intersection.getPlayer().getHand();
            int amount = intersection.getNumOfResourcesToGenerate();

            foreach(Hex h in intersection.resourceHexes)
            {
                try
                {
                    if (isItBeginningOfTheGame || h.getToken() == currentRoll)
                    {
                        hand.modifyResources(h.getResourceType(), amount);
                    }
                }
                catch (NullReferenceException)
                {
                    // Do nothing
                }
            }
        }

        public Hex getHexAtIndex(int x, int y)
        {
            return this.catanMap.getHexMap().map[x, y];
        }
    }
}
