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
		// these 4 are public for testing
		public int largestArmySize;
		public int largestArmyOwnerIndex;
		public int longestRoadSize;
		public int longestRoadOwnerIndex;
		private int numOfCompletedRounds;
		private int turnCounter;
		private bool placeRobber = false;
		private Hex robberHex;

		public World()
		{
			bank = new Bank();
			players = new List<Player>();

			// Generate a new map for the board
			this.catanMap = new CompleteMap();
			checkRobberHex();
			this.currentRoll = 0;
			this.largestArmySize = 0;
			this.longestRoadSize = 0;
			this.largestArmyOwnerIndex = -1;
			this.longestRoadOwnerIndex = -1;
			this.numOfCompletedRounds = 0;
		}

		public World(int humans, int computers) : this()
		{
			players.Add(new Player("bob", Color.Red, this));
			players.Add(new Player("joe", Color.Blue, this));
			players.Add(new Player("Anne", Color.Green, this));

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
			this.currentPlayer.getHand().modifyFreeRoadPoints(1);
			this.currentPlayer.getHand().modifyFreeSettlementPoints(1);
		}

		private void checkRobberHex()
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 1; j < 4; j++)
				{
					if (this.catanMap.getHexMap().map[i, j].getHasRobber())
					{
						setRobberHex(this.catanMap.getHexMap().map[i, j]);
					}
					else
					{
						this.catanMap.getHexMap().map[i, j].setHasRobber(false);
					}
				}
			}

			// check outliers: [1][0], [2][0], [3][0], [2][4]
			for (int i = 1; i < 4; i++)
			{
				if (this.catanMap.getHexMap().map[i, 0].getHasRobber())
				{
					setRobberHex(this.catanMap.getHexMap().map[i, 0]);
				}
				else
				{
					this.catanMap.getHexMap().map[i, 0].setHasRobber(false);
				}
			}

			if (this.catanMap.getHexMap().map[2, 4].getHasRobber())
			{
				setRobberHex(this.catanMap.getHexMap().map[2, 4]);
			}
			else
			{
				this.catanMap.getHexMap().map[2, 4].setHasRobber(false);
			}
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
            if (numOfCompletedRounds == 0)
            {
                if (currentPlayerNumber < this.players.Count() - 1)
                {
                    currentPlayerNumber++;
                }
                else
                {
                    currentPlayerNumber = this.players.Count() - 1;
                    numOfCompletedRounds++;
                }
            }
            else if (numOfCompletedRounds == 1)
            {
                if (currentPlayerNumber > 0)
                {
                    currentPlayerNumber--;
                }
                else
                {
                    currentPlayerNumber = 0;
                    numOfCompletedRounds++;
                }
            }
            else if (currentPlayer.hasRolled)
            {
                if (currentPlayerNumber < this.players.Count() - 1)
                {
                    currentPlayer.hasRolled = false;
                    currentPlayerNumber++;
                }
                else
                {
                    currentPlayerNumber = 0;
                    numOfCompletedRounds++;
                }
            }
            else
            {
                // pop up error message if player hasn't rolled yet
                DialogResult num = MessageBox.Show("you must roll before ending the turn",
                    "roll the dice",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            currentPlayer = this.players[currentPlayerNumber];
        }

		public int getNumberOfRoundsCompleted()
		{
			return this.numOfCompletedRounds;
		}

		public bool isFirstFewTurnsPhase()
		{
			return this.numOfCompletedRounds < 2;
		}

		private void setLongestRoad()
		{
			int numberOfPlayers = this.players.Count() - 1;

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

		public void setLargestArmy()
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

		public bool checkWinner()
		{
			foreach (Player p in this.players)
			{
				if (p.hasWonGame() == true)
				{
					return true;
				}
			}
			return false;
		}


		public Color tryToBuildAtIntersection(Point coords)
		{
			// Build a settlement
			if (!catanMap.getIslandMap().getIntAtIndex(coords).hasABuilding())
			{
				if (catanMap.getIslandMap()
					.getIntAtIndex(coords)
					.canBuildAtIntersection(this.currentPlayer, this.numOfCompletedRounds))
				{
					if (currentPlayer.getHand().hasSettlementResources())
					{
						// build a settlement here
						this.catanMap.getIslandMap().getIntAtIndex(coords).color = this.currentPlayer.getColor();
						catanMap.getIslandMap().getIntAtIndex(coords).setPlayer(currentPlayer);
						this.catanMap.getIslandMap().buildSettlement(coords);
						currentPlayer.addSettlement(coords);
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
					DialogResult num = MessageBox.Show("You cannot build there.",
						"Insufficient Room to Build",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					return Color.White;
				}
			}
				// Build a city
			else
			{
				if (currentPlayer.getHand().hasCityResources())
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
			Color theColor;

			if (currentPlayer.getHand().hasRoadResources())
			{
				bool flag = false;
				try
				{
					if (coords.X%2 == 0) // Even row
					{
						flag = catanMap.getIslandMap().buildHorizontalRoad(coords, this.currentPlayer);
					}
					else // Odd row
					{
						flag = catanMap.getIslandMap().buildVerticalRoad(coords, this.currentPlayer);
					}
					if (flag)
					{
						theColor = currentPlayer.getColor();
						currentPlayer.buildRoad();
					}
					else theColor = Color.White;
				}
				catch (IndexOutOfRangeException)
				{
					theColor = Color.White;
				}
				catch (NullReferenceException)
				{
					theColor = Color.Black;
				}
			}
			else
			{
				DialogResult num = MessageBox.Show("You do not have enough resources to build a road.",
					"Insufficient Resources",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);

				theColor = Color.White;
			}

			return theColor;
		}

		public void rollDice()
		{
            if (!this.currentPlayer.hasRolled && numOfCompletedRounds >= 2)
            {
                    Random die = new Random();
                    int die1Roll = die.Next(1, 7);
                    int die2Roll = die.Next(1, 7);
                    currentRoll = die1Roll + die2Roll;
                    generateMyResources(currentRoll, false);
            }
            else if (this.currentPlayer.hasRolled)
            {
                DialogResult num = MessageBox.Show("cannot roll the dice more than once.",
                        "rolled already",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult num = MessageBox.Show("cannot roll the dice in the first 2 rounds",
                        "too early to roll",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
            this.currentPlayer.hasRolled = true;
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
			if (!isFirstFewTurnsPhase())
			{
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
		}

		private void giveAllResourcesForThisIntersection(Intersection intersection, bool isItBeginningOfTheGame)
		{
			Hand hand = intersection.getPlayer().getHand();
			int amount = intersection.getNumOfResourcesToGenerate();

			foreach (Hex h in intersection.resourceHexes)
			{
				try
				{
					if (isItBeginningOfTheGame || h.getToken() == currentRoll)
					{
						if (h != this.robberHex)
						{
							hand.modifyResources(h.getResourceType(), amount);
						}
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

		public void incrementTurnCounter()
		{
			this.turnCounter++;
		}

		public bool getPlaceRobber()
		{
			return this.placeRobber;
		}

		public void setPlaceRobber(bool condition)
		{
			this.placeRobber = condition;
			if (condition == false)
			{
				StealCardForm myForm = new StealCardForm(this);
				myForm.Show();
			}
		}

		public Hex getRobberHex()
		{
			return this.robberHex;
		}

		public void setRobberHex(Hex hex)
		{
			this.robberHex = hex;
		}
	}
}