﻿using System;
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
        // these 4 are public for testing
        public int largestArmySize;
        public int largestArmyOwnerIndex;
        public int longestRoadSize;
        public int longestRoadOwnerIndex;

        public World()
        {
            bank = new Bank();
            players = new List<Player>();

            // Generate a new map for the board
            this.catanMap = new CompleteMap();
            this.currentRoll = 0;
            this.largestArmySize = 0;
            this.longestRoadSize = 0;
            this.largestArmyOwnerIndex = -1;
            this.longestRoadOwnerIndex = -1;
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
            this.largestArmySize = 0;
            this.longestRoadSize = 0;
            this.largestArmyOwnerIndex = -1;
            this.longestRoadOwnerIndex = -1;

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

        public void addPlayer(Player p)
        {
            this.players.Add(p);
        }

        public void setCurrentPlayer(String s)
        {
            int i = 0;
            foreach (Player p in players)
            {
                if (p.getName() == s)
                {
                    currentPlayer = p;
                    currentPlayerNumber = i;
                    break;
                }
                i++;
            }
        }

        public void endTurn()
        {
            setLongestRoad();
            setLargestArmy();
            if (currentPlayerNumber < this.players.Count()-1)
            {
                currentPlayerNumber++;
            }
            else
                currentPlayerNumber = 0;
            currentPlayer = this.players[currentPlayerNumber];
        }

        private void setLongestRoad()
        {
            int numberOfPlayers = this.players.Count()-1;
            
            // loop through current player and players at higher indices
            for (int i = this.currentPlayerNumber; i <= numberOfPlayers; i++)
            {
                // if no one has the longest road yet
                if (this.longestRoadSize == 0)
                {
                    if (this.players[i].getRoadsPlayed() == 5)
                    {
                        this.longestRoadSize = 5;
                        this.longestRoadOwnerIndex = i;
                        this.players[i].hasLongestRoad = true;
                        this.players[i].incrementPoints(2);
                    }
                }
                // if someone has the longest road already
                else
                {
                    // updates the longest road size
                    this.longestRoadSize = this.players[this.longestRoadOwnerIndex].getRoadsPlayed();

                    // see if anyone besides the current longest road owner has a longer road
                    if (this.players[i].getRoadsPlayed() > this.longestRoadSize)
                    {
                        // set previous owner's longest road boolean to false and set new owner's boolean to true
                        // also decrement previous owner's points by 2 and increment new owner's points by 2
                        this.players[this.longestRoadOwnerIndex].hasLongestRoad = false;
                        this.players[this.longestRoadOwnerIndex].incrementPoints(-2);
                        this.longestRoadSize = this.players[i].getRoadsPlayed();
                        this.longestRoadOwnerIndex = i;
                        this.players[i].hasLongestRoad = true;
                        this.players[i].incrementPoints(2);
                    }
                }
            }

        }

        private void setLargestArmy()
        {
            int numberOfPlayers = this.players.Count() - 1;

            // loop through current player and players at higher indices
            for (int i = this.currentPlayerNumber; i <= numberOfPlayers; i++)
            {
                // if no one has the largest army yet
                if (this.largestArmySize == 0)
                {
                    if (this.players[i].getHand().getKnights() == 3)
                    {
                        this.largestArmySize = 3;
                        this.largestArmyOwnerIndex = i;
                        this.players[i].hasLargestArmy = true;
                        this.players[i].incrementPoints(2);
                    }
                }
                // if someone has the largest army already
                else
                {
                    // updates the largest army size
                    this.largestArmySize = this.players[this.largestArmyOwnerIndex].getHand().getKnights();

                    // see if anyone besides the current largest army owner has a larger army
                    if (this.players[i].getHand().getKnights() > this.largestArmySize)
                    {
                        // set previous owner's largest army boolean to false and set new owner's boolean to true
                        // also decrement previous owner's points by 2 and increment new owner's points by 2
                        this.players[this.largestArmyOwnerIndex].hasLargestArmy = false;
                        this.players[this.largestArmyOwnerIndex].incrementPoints(-2);
                        this.largestArmySize = this.players[i].getHand().getKnights();
                        this.largestArmyOwnerIndex = i;
                        this.players[i].hasLargestArmy = true;
                        this.players[i].incrementPoints(2);
                    }
                }
            }
        }

        private void checkWinner()
        {
            foreach (Player p in this.players){
                if (p.hasWonGame() == true){
                    //declare winner
                }
            }
        }

       

        public Color tryToBuildAtIntersection(Point coords)
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

        public CompleteMap getMap()
        {
            return this.catanMap;
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
