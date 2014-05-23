using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public class Bank
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		private int ore;
		private int wool;
		private int lumber;
		private int grain;
		private int brick;
		private Stack<DevelopmentCard> devCards;

		public Bank()
		{
			this.ore = 19;
			this.wool = 19;
			this.lumber = 19;
			this.grain = 19;
			this.brick = 19;

			this.devCards = new Stack<DevelopmentCard>();

			for (int i = 0; i < 14; i++)
			{
				this.devCards.Push(new Knight());
			}

			for (int i = 0; i < 5; i++)
			{
				this.devCards.Push(new VictoryPointCard());
			}

			for (int i = 0; i < 2; i++)
			{
				this.devCards.Push(new MonopolyCard());
				this.devCards.Push(new RoadBuilderCard());
				this.devCards.Push(new YearOfPlentyCard());
			}

			this.devCards = devCardShuffler();
		}

		private Stack<DevelopmentCard> devCardShuffler()
		{
			Random _rnd = new Random();

			List<DevelopmentCard> devCardList = this.devCards.ToList();

			//make a new list of the wanted type
			List<DevelopmentCard> newList = new List<DevelopmentCard>();

			//for each time we want to shuffle
			for (int i = 0; i < 7; i++)
			{
				//while there are still items in our list
				while (devCardList.Count > 0)
				{
					//get a random number within the list
					int index = _rnd.Next(devCardList.Count);

					//add the item at that position to the new list
					newList.Add(devCardList[index]);

					//and remove it from the old list
					devCardList.RemoveAt(index);
				}

				//then copy all the items back in the old list again
				devCardList.AddRange(newList);

				//and clear the new list
				//to make ready for next shuffling
				newList.Clear();
			}

			// push list onto a stack
			Stack<DevelopmentCard> shuffledCards = new Stack<DevelopmentCard>();
			for (int i = 0; i < 25; i++)
			{
				shuffledCards.Push(devCardList[i]);
			}

			return shuffledCards;
		}

        public void decrementAllResources(int number)
        {
            this.brick -= number;
            this.wool -= number;
            this.lumber -= number;
            this.grain -= number;
            this.ore -= number;
        }

		public bool allResourcesMax()
		{
			return (this.ore + this.wool + this.lumber + this.grain + this.brick == 95 && this.devCards.Count() == 25);
		}

		public int getOreRemaining()
		{
			return this.ore;
		}

		public int getWoolRemaining()
		{
			return this.wool;
		}

		public int getLumberRemaining()
		{
			return this.lumber;
		}

		public int getGrainRemaining()
		{
			return this.grain;
		}

		public int getBrickRemaining()
		{
			return this.brick;
		}

		public int getDevCardRemaining()
		{
			return this.devCards.Count();
		}

		public Stack<DevelopmentCard> getDevCards()
		{
			return this.devCards;
		}

		public void modifyResource(String resource, int amount)
		{
			switch (resource.ToLower())
			{
				case "ore":
				case "mineral":
				{
					if (this.ore + amount < 0 || this.ore + amount > 19)
					{
						throw new ArgumentException(rm.GetString(language + "InvalidOre"));
					}
					this.ore = this.ore + amount;
					break;
				}
				case "wool":
				case "lana":
				{
					if (this.wool + amount < 0 || this.wool + amount > 19)
					{
						throw new ArgumentException(rm.GetString(language + "InvalidWool"));
					}
					this.wool = this.wool + amount;
					break;
				}
				case "lumber":
				case "maderas":
				{
					if (this.lumber + amount < 0 || this.lumber + amount > 19)
					{
						throw new ArgumentException(rm.GetString(language + "InvalidLumber"));
					}
					this.lumber = this.lumber + amount;
					break;
				}
				case "grain":
				case "grano":
				{
					if (this.grain + amount < 0 || this.grain + amount > 19)
					{
						throw new ArgumentException(rm.GetString(language + "InvalidGrain"));
					}
					this.grain = this.grain + amount;
					break;
				}
				case "brick":
				case "ladrillo":
				{
					if (this.brick + amount < 0 || this.brick + amount > 19)
					{
						throw new ArgumentException(rm.GetString(language + "InvalidBrick"));
					}
					this.brick = brick + amount;
					break;
				}
			}
		}

		public List<DevelopmentCard> drawDevCard(int amount)
		{
			if (this.devCards.Count() <= 0)
			{
				throw new ArgumentException(rm.GetString(language + "InvalidDevCards"));
			}

			List<DevelopmentCard> cards = new List<DevelopmentCard>();

			for (int i = 0; i < amount; i++)
			{
				cards.Add(this.devCards.Pop());
			}

			return cards;
		}
	}
}