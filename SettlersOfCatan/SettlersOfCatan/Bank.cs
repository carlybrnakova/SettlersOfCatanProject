using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettlersOfCatan
{
	public class Bank
	{
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
			switch (resource)
			{
				case "ore":
				{
					if (this.ore + amount < 0 || this.ore + amount > 19)
					{
						DialogResult num = MessageBox.Show("There would be an invalid number of ore.",
							"Invalid Number of Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);

						//throw new ArgumentOutOfRangeException("There would be an invalid amount of ore");
					}
					this.ore = this.ore + amount;
					break;
				}
				case "wool":
				{
					if (this.wool + amount < 0 || this.wool + amount > 19)
					{
						DialogResult num = MessageBox.Show("There would be an invalid number of wool.",
							"Invalid Number of Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);

						//throw new ArgumentOutOfRangeException("There would be an invalid amount of wool");
					}
					this.wool = this.wool + amount;
					break;
				}
				case "lumber":
				{
					if (this.lumber + amount < 0 || this.lumber + amount > 19)
					{
						DialogResult num = MessageBox.Show("There would be an invalid number of lumber.",
							"Invalid Number of Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						//throw new ArgumentOutOfRangeException("There would be an invalid amount of lumber");
					}
					this.lumber = this.lumber + amount;
					break;
				}
				case "grain":
				{
					if (this.grain + amount < 0 || this.grain + amount > 19)
					{
						DialogResult num = MessageBox.Show("There would be an invalid number of grain.",
							"Invalid Number of Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						//throw new ArgumentOutOfRangeException("There would be an invalid amount of grain");
					}
					this.grain = this.grain + amount;
					break;
				}
				case "brick":
				{
					if (this.brick + amount < 0 || this.brick + amount > 19)
					{
						DialogResult num = MessageBox.Show("There would be an invalid number of brick.",
							"Invalid Number of Resources",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
						//throw new ArgumentOutOfRangeException("There would be an invalid amount of brick");
					}
					this.brick = brick + amount;
					break;
				}
					//case "devcard":
					//  {
					//    if (this.devCards.Count() <= 0)
					//  {
					//    throw new ArgumentOutOfRangeException("There would be an invalid number of development cards");
					//}
					//for (int i = 0; i < Math.Abs(amount); i++)
					//{
					//  this.devCards.Pop();
					// }
					//break;
					//}
			}
		}

		public List<DevelopmentCard> drawDevCard(int amount)
		{
			if (this.devCards.Count() <= 0)
			{
				DialogResult num = MessageBox.Show("There would be an invalid number of development cards.",
					"Invalid Number of Resources",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				//throw new ArgumentOutOfRangeException("There would be an invalid number of development cards");
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