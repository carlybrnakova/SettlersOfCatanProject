using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SettlersOfCatan
{
	public class Player
	{
		private readonly int MAX_CITIES = 4;
		private readonly int MAX_SETTLEMENTS = 5;
		private readonly int MAX_ROADS = 15;

		private int points = 0;
		private int citiesPlayed = 0;
		private int settlementsPlayed = 0;
		private int roadsPlayed = 0;
		//only public for testing
		public Hand playerHand = new Hand();
		private Player playerToTradeWith = null;
		private int[] toTrade = new int[5] {0, 0, 0, 0, 0};
		private int[] toReceive = new int[5] {0, 0, 0, 0, 0};
		private String name;
		private Color color;
		private bool hasWon = false;
		private World world;
		public bool hasLongestRoad;
		public bool hasLargestArmy;
        public List<List<Connection>> roads = new List<List<Connection>>();
        public int longestRoadIndex;
        public bool hasRolled;
		private List<Point> settlementLocations = new List<Point>();
        private List<Port> ports;

		public Player()
		{
			this.world = new World();
			this.hasLongestRoad = false;
			this.hasLargestArmy = false;

            this.hasRolled = false;
            this.ports = new List<Port>();
            this.longestRoadIndex = 0;
            this.roads.Add(new List<Connection>());
		}

		public Player(String playerName, Color playerColor, World world1) : this()
		{
			this.name = playerName;
			this.color = playerColor;
			this.world = world1;

			this.hasLongestRoad = false;
			this.hasLargestArmy = false;
            this.ports = new List<Port>();
            this.longestRoadIndex = 0;
		}

        public void addPort(Port p)
        {
            this.ports.Add(p);
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

		public bool incrementCities()
		{
			if (getCitiesRemaining() > 0)
			{
				citiesPlayed++;
				if (settlementsPlayed > 0)
				{
					settlementsPlayed--;
				}
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
			this.playerToTradeWith = player;
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

		public void makeTrade()
		{
			if (this.canAcceptTrade())
			{
				tradeCards(this.toTrade, this.toReceive);
				this.playerToTradeWith.tradeCards(this.playerToTradeWith.toTrade, this.playerToTradeWith.toReceive);
				this.declineTrade();
			}
			else
			{
				/*
				DialogResult num = MessageBox.Show("You do not have enough resources to make that trade.",
					"Insufficient Resources",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				 */

				throw new ArgumentException("Player's cards are such that trade cannot be performed");
			}
		}

		public void declineTrade()
		{
			this.toTrade = new int[] {0, 0, 0, 0, 0};
			this.toReceive = new int[] {0, 0, 0, 0, 0};
			this.playerToTradeWith.toTrade = new int[] {0, 0, 0, 0, 0};
			this.playerToTradeWith.toReceive = new int[] {0, 0, 0, 0, 0};
			this.playerToTradeWith.playerToTradeWith = null;
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

		public bool mustRemoveHalf()
		{
			return this.playerHand.getResources() > 7;
		}

        public bool hasAResourcePort()
        {
            for (int i = 0; i < this.ports.Count; i++)
            {
                if (this.ports[i].getResourceType() != "Anything")
                {
                    return true;
                }
            }
            return false;
        }

        public bool hasAFreePort()
        {
            for (int i = 0; i < this.ports.Count; i++)
            {
                if (this.ports[i].getResourceType() == "Anything")
                {
                    return true;
                }
            }
            return false;
        }

        public List<String> listAllResourcePortsForThisPlayer()
        {
            List<String> theResources = new List<String>(5);
            for (int i = 0; i < this.ports.Count; i++)
            {
                if (this.ports[i].getResourceType() != "Anything")
                {
                    theResources.Add(this.ports[i].getResourceType().ToLower());
                }
            }
            return theResources;
        }

        public void tradeWithBank(String resourceToTradeIn, String resourceToGain)
		{
            int amountToTradeIn = 4;
            if (this.hasAResourcePort())
            {
                List<String> allResources = listAllResourcePortsForThisPlayer();
                if (allResources.Contains(resourceToTradeIn))
                {
                    amountToTradeIn = 2;
                }
            }
            if (this.hasAFreePort() && amountToTradeIn == 4)
            {
                amountToTradeIn = 3;
            }
			if (resourceToTradeIn.ToLower().Equals("ore"))
			{
                if (getHand().getOre() >= amountToTradeIn)
				{
					try
					{
						this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("ore", amountToTradeIn);
                        this.playerHand.modifyOre(-amountToTradeIn);
						modifyResourceInHand(resourceToGain);
					}
					catch (ArgumentOutOfRangeException)
					{
						/*
						DialogResult num = MessageBox.Show("There isn't enough ore to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 */

						//return Color.White;
						throw;
					}
				}
				else
				{
					/*
					DialogResult num = MessageBox.Show("You don't have enough ore to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
					 * */
					throw new ArgumentOutOfRangeException("You don't have enough ore.");
				}
			}
			else if (resourceToTradeIn.ToLower().Equals("wool"))
			{
                if (getHand().getWool() >= amountToTradeIn)
				{
					try
					{
						this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("wool", amountToTradeIn);
                        this.playerHand.modifyWool(-amountToTradeIn);
						modifyResourceInHand(resourceToGain);
					}
					catch (ArgumentOutOfRangeException)
					{
						/*
						DialogResult num = MessageBox.Show("There isn't enough wool to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 */
						throw;
					}
				}
				else
				{
					/*
					DialogResult num = MessageBox.Show("You don't have enough wool to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
					 */
					throw new ArgumentOutOfRangeException("You don't have enough wool.");
				}
			}
			else if (resourceToTradeIn.ToLower().Equals("lumber"))
			{
                if (getHand().getLumber() >= amountToTradeIn)
				{
					try
					{
						this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("lumber", amountToTradeIn);
                        this.playerHand.modifyLumber(-amountToTradeIn);
						modifyResourceInHand(resourceToGain);
					}
					catch (ArgumentOutOfRangeException)
					{
						/*
						DialogResult num = MessageBox.Show("There isn't enough lumber to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 * */
						throw;
					}
				}
				else
				{
					/*
					DialogResult num = MessageBox.Show("You don't have enough lumber to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
					 */
					throw new ArgumentOutOfRangeException("You don't have enough lumber.");
				}
			}
			else if (resourceToTradeIn.ToLower().Equals("grain"))
			{
                if (getHand().getGrain() >= amountToTradeIn)
				{
					try
					{
						this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("grain", amountToTradeIn);
                        this.playerHand.modifyGrain(-amountToTradeIn);
						modifyResourceInHand(resourceToGain);
					}
					catch (ArgumentOutOfRangeException)
					{
						/*
						DialogResult num = MessageBox.Show("There isn't enough grain to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 */
						throw;
					}
				}
				else
				{
					/*
					DialogResult num = MessageBox.Show("You don't have enough grain to make that trade.",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					 */
					throw new ArgumentOutOfRangeException("You don't have enough grain.");
				}
			}
			else if (resourceToTradeIn.ToLower().Equals("brick"))
			{
                if (getHand().getBrick() >= amountToTradeIn)
				{
					try
					{
						this.world.bank.modifyResource(resourceToGain, -1);
                        this.world.bank.modifyResource("brick", amountToTradeIn);
                        this.playerHand.modifyBrick(-amountToTradeIn);
						modifyResourceInHand(resourceToGain);
					}
					catch (ArgumentOutOfRangeException)
					{
						/*
						DialogResult num = MessageBox.Show("There isn't enough brick to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 */
						throw;
					}
				}
				else
				{
					/*
					DialogResult num = MessageBox.Show("You don't have enough brick to make that trade.",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					 */
					throw new ArgumentOutOfRangeException("You don't have enough brick.");
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
						/*
						DialogResult num = MessageBox.Show("There isn't enough ore to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 */
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
						/*
						DialogResult num = MessageBox.Show("There isn't enough wool to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 */
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
						/*
						DialogResult num = MessageBox.Show("There isn't enough lumber to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						*/
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
						/*
						DialogResult num = MessageBox.Show("There isn't enough grain to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 */
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
						/*
						DialogResult num = MessageBox.Show("There isn't enough brick to make that trade.",
							"Insufficient Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						*/
						throw;
					}
				}
			}
		}

		public void tradeForDevCard()
		{
			if (this.playerHand.getOre() >= 1 && this.playerHand.getGrain() >= 1 && this.playerHand.getWool() >= 1)
			{
				try
				{
					List<DevelopmentCard> cards = this.world.bank.drawDevCard(1);
					this.world.bank.modifyResource("ore", 1);
					this.world.bank.modifyResource("wool", 1);
					this.world.bank.modifyResource("grain", 1);
					this.playerHand.modifyOre(-1);
					this.playerHand.modifyWool(-1);
					this.playerHand.modifyGrain(-1);
					this.playerHand.addDevCard(cards);
				}
				catch (ArgumentOutOfRangeException)
				{
					/*
					DialogResult num = MessageBox.Show("There aren't any more development cards.",
						"Can't Get Development Cards",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					 */
					throw;
				}
			}
		}

		private void modifyResourceInHand(String resource)
		{
			switch (resource)
			{
				case "ore":
				{
					this.playerHand.modifyOre(1);
					break;
				}
				case "wool":
				{
					this.playerHand.modifyWool(1);
					break;
				}
				case "lumber":
				{
					this.playerHand.modifyLumber(1);
					break;
				}
				case "grain":
				{
					this.playerHand.modifyGrain(1);
					break;
				}
				case "brick":
				{
					this.playerHand.modifyBrick(1);
					break;
				}
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
					/*
					DialogResult num = MessageBox.Show("There isn't enough ore to generate more",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					*/
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
					/*
					DialogResult num = MessageBox.Show("There isn't enough ore to generate more",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					*/
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
					/*
					DialogResult num = MessageBox.Show("There isn't enough wool to generate more",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					*/
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
					/*
					DialogResult num = MessageBox.Show("There isn't enough wool to generate more",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					*/
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
					/*
					DialogResult num = MessageBox.Show("There isn't enough lumber to generate more",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					*/
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
					/*
					DialogResult num = MessageBox.Show("There isn't enough lumber to generate more",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					*/
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
					/*
					DialogResult num = MessageBox.Show("There isn't enough grain to generate more",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					*/
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
					/*
					DialogResult num = MessageBox.Show("There isn't enough grain to generate more",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					*/
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
					/*
					DialogResult num = MessageBox.Show("There isn't enough brick to generate more",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					*/
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
					/*
					DialogResult num = MessageBox.Show("There isn't enough brick to generate more",
						"Insufficient Resources",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
					*/
					throw;
				}
			}
		}

		public bool canBuildCity()
		{
			return (this.playerHand.hasCityResources());
		}

		public bool canBuildSettlement()
		{
			return (this.playerHand.hasSettlementResources());
		}

		public bool canBuildRoad()
		{
			return (this.playerHand.hasRoadResources());
		}

		public void buildRoad()
		{
			if (this.getHand().hasFreeRoadPoints())
				this.getHand().modifyFreeRoadPoints(-1);
			else
			{
				this.playerHand.modifyBrick(-1);
				this.playerHand.modifyLumber(-1);
			}
			incrementRoads();
		}

		public void addSettlement(Point coords)
		{
			this.settlementLocations.Add(coords);
			buildSettlement();
		}

		public void buildSettlement()
		{
			if (this.getHand().hasFreeSettlementPoints())
			{
				this.getHand().modifyFreeSettlementPoints(-1);
			}
			else
			{
				this.playerHand.modifyGrain(-1);
				this.playerHand.modifyLumber(-1);
				this.playerHand.modifyBrick(-1);
				this.playerHand.modifyWool(-1);
			}
			incrementSettlements();
			incrementPoints(1);
		}

		public void buildCity()
		{
			this.playerHand.modifyGrain(-2);
			this.playerHand.modifyOre(-3);
			incrementCities();
			incrementPoints(1); // One point is already counted for the settlement that was there
		}

		public List<Point> getSettlementLocations()
		{
			return this.settlementLocations;
		}

		public int getRoadsPlayed()
		{
			return this.roadsPlayed;
		}

		public void playDevCard(String cardType, String resourceOne, String resourceTwo)
		{
			switch (cardType)
			{
				case "knight":
				{
					if (this.playerHand.devCardsContains("knight"))
					{
						this.playerHand.incrementKnightsPlayed();
						this.playerHand.removeDevCard("knight");
						break;
					}
					else
					{
						/*
						DialogResult num = MessageBox.Show("You don't have any knights to play.",
							"No Knights to Play",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						*/
						throw new ArgumentException("You don't have any Knights to play.");
						break;
					}
				}
				case "victoryPoint":
				{
					if (this.playerHand.devCardsContains("victoryPoint"))
					{
						incrementPoints(1);
						this.playerHand.removeDevCard("victoryPoint");
						break;
					}
					else
					{
						/*
						DialogResult num = MessageBox.Show("You don't have any victory point cards to play.",
							"No Points Gained",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						*/
						throw new ArgumentException("You don't have any Victory Point cards to play.");
						break;
					}
				}
				case "roadBuilder":
				{
					if (this.playerHand.devCardsContains("roadBuilder"))
					{
						this.getHand().modifyFreeRoadPoints(2);
						this.playerHand.removeDevCard("roadBuilder");
						break;
					}
					else
					{
						/*
						DialogResult num = MessageBox.Show("You don't have any year of road builder cards to play.",
							"Construction Halted",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 */
						throw new ArgumentException("You don't have any Road Builder cards to play.");
					}
				}
				case "monopoly":
				{
					if (this.playerHand.devCardsContains("monopoly"))
					{
						int resourceAmount = 0;

						for (int i = 0; i < this.world.players.Count(); i++)
						{
							if (i != this.world.currentPlayerNumber)
							{
								int amountLost = this.world.players[i].playerHand.getResource(resourceOne);
								resourceAmount += amountLost;
								this.world.players[i].playerHand.modifyResources(resourceOne, -amountLost);
							}
						}
						this.playerHand.modifyResources(resourceOne, resourceAmount);
						this.playerHand.removeDevCard("monopoly");
						break;
					}
					else
					{
						/*
						DialogResult num = MessageBox.Show("You don't have any monopoly cards to play.",
							"No Monopolizing",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 */
						throw new ArgumentException("You don't have any Monopoly cards to play.");
						break;
					}
				}
				case "yearOfPlenty":
				{
					if (this.playerHand.devCardsContains("yearOfPlenty"))
					{
						this.playerHand.modifyResources(resourceOne, 1);
						this.playerHand.modifyResources(resourceTwo, 1);
						this.world.bank.modifyResource(resourceOne, -1);
						this.world.bank.modifyResource(resourceTwo, -1);
						this.playerHand.removeDevCard("yearOfPlenty");
						break;
					}
					else
					{
						/*
						DialogResult num = MessageBox.Show("You don't have any year of plenty cards to play.",
							"Year of Scarcity",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						 */
						throw new ArgumentException("You don't have any Year of Plenty cards to play");
						break;
					}
				}
			}
		}

        public void addConnection(Connection spot)
        {
            bool wasAdded = false;
            int roadsIndex = 0;
            List<List<Connection>> addedRoads = new List<List<Connection>>();
            foreach(List<Connection> intList in roads)
            {
                int intListIndex = 0;
                foreach (Connection road in intList)
                {

                    if ((road.getIntersectionLeftOrTop().getConnections()[0] == spot || road.getIntersectionRightOrBot().getConnections()[0] == spot || 
                        road.getIntersectionLeftOrTop().getConnections()[1] == spot || road.getIntersectionRightOrBot().getConnections()[1] == spot || 
                        road.getIntersectionLeftOrTop().getConnections()[2] == spot || road.getIntersectionRightOrBot().getConnections()[2] == spot ||
                        spot.getIntersectionLeftOrTop().getConnections()[0] == road || spot.getIntersectionRightOrBot().getConnections()[0] == road ||
                        spot.getIntersectionLeftOrTop().getConnections()[1] == road || spot.getIntersectionRightOrBot().getConnections()[1] == road ||
                        spot.getIntersectionLeftOrTop().getConnections()[2] == road || spot.getIntersectionRightOrBot().getConnections()[2] == road) & intListIndex == intList.Count - 1)
                    {
                        intList.Add(spot);
                        wasAdded = true;
                        if (intList.Count() > roads[this.longestRoadIndex].Count())
                        {
                            longestRoadIndex = roadsIndex;
                        }
                        break;
                    }
                    else if ((road.getIntersectionLeftOrTop().getConnections()[0] == spot || road.getIntersectionRightOrBot().getConnections()[0] == spot ||
                        road.getIntersectionLeftOrTop().getConnections()[1] == spot || road.getIntersectionRightOrBot().getConnections()[1] == spot ||
                        road.getIntersectionLeftOrTop().getConnections()[2] == spot || road.getIntersectionRightOrBot().getConnections()[2] == spot ||
                        spot.getIntersectionLeftOrTop().getConnections()[0] == road || spot.getIntersectionRightOrBot().getConnections()[0] == road ||
                        spot.getIntersectionLeftOrTop().getConnections()[1] == road || spot.getIntersectionRightOrBot().getConnections()[1] == road ||
                        spot.getIntersectionLeftOrTop().getConnections()[2] == road || spot.getIntersectionRightOrBot().getConnections()[2] == road) & intListIndex != intList.Count - 1)
                    {
                        List<Connection> newList = new List<Connection>();
                        for (int i = 0; i <= intListIndex; i++){
                            newList.Add(intList[i]);
                        }
                        newList.Add(spot);
                        addedRoads.Add(newList);
                        wasAdded = true;
                        if (newList.Count() > roads[this.longestRoadIndex].Count()){
                            longestRoadIndex = roadsIndex;
                        }
                    }
                    intListIndex++;
                }
                roadsIndex++;
            }
            if (addedRoads.Count != 0)
            {
                foreach (List<Connection> road in addedRoads)
                {
                    roads.Add(road);
                }
            }
            if (!wasAdded)
            {
                roads.Add(new List<Connection> { spot });
            }
        }

        public int getLengthOfLongestRoad()
        {
            return this.roads[this.longestRoadIndex].Count();
        }

		public void transferGrain(int amount)
		{
			this.playerHand.modifyGrain(-amount);
			this.world.bank.modifyResource("grain", amount);
		}

		public void transferOre(int amount)
		{
			this.playerHand.modifyOre(-amount);
			this.world.bank.modifyResource("ore", amount);
		}

		public void transferWool(int amount)
		{
			this.playerHand.modifyWool(-amount);
			this.world.bank.modifyResource("wool", amount);
		}

		public void transferLumber(int amount)
		{
			this.playerHand.modifyLumber(-amount);
			this.world.bank.modifyResource("lumber", amount);
		}

		public void transferBrick(int amount)
		{
			this.playerHand.modifyBrick(-amount);
			this.world.bank.modifyResource("brick", amount);
		}

		public string rob()
		{
			List<string> resources = new List<string>();

			if (this.playerHand.getBrick() > 0)
			{
				resources.Add("brick");
			}

			if (this.playerHand.getGrain() > 0)
			{
				resources.Add("grain");
			}
			
			if (this.playerHand.getWool() > 0)
			{
				resources.Add("wool");
			}
			
			if (this.playerHand.getOre() > 0)
			{
				resources.Add("ore");
			}
			
			if (this.playerHand.getLumber() > 0)
			{
				resources.Add("lumber");
			}

			return pickString(resources);
		}

		public string pickString(List<string> resources)
		{
			if (!resources.Any())
			{
				return "none";
			}

			Random rand = new Random();
			int index = rand.Next(0, resources.Count);
			string resource = resources[index];

			this.playerHand.modifyResources(resource, -1);
			return resource;
		}

	}
}