using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlersOfCatan
{
    public class Bank
    {
        private int ore;
        private int wool;
        private int lumber;
        private int grain;
        private int brick;
        private List<DevelopmentCard> devCards;

        public Bank()
        {
            ore = 19;
            wool = 19;
            lumber = 19;
            grain = 19;
            brick = 19;
            devCards = new List<DevelopmentCard>(25);
            for (int i = 0; i < 25; i++)
            {
                devCards.Add(new DevelopmentCard());
            }
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

        public void modifyResource(String resource, int amount)
        {
            if (resource.ToLower().Equals("ore"))
            {
                if (ore + amount < 0 || ore + amount > 19)
                {
                    throw new ArgumentOutOfRangeException("There would be an invalid amount of ore");
                }
                ore = ore + amount;
            }
            else if (resource.ToLower().Equals("wool"))
            {
                if (wool + amount < 0 || wool + amount > 19)
                {
                    throw new ArgumentOutOfRangeException("There would be an invalid amount of wool");
                }
                wool = wool + amount;
            }
            else if (resource.ToLower().Equals("lumber"))
            {
                if (lumber + amount < 0 || lumber + amount > 19)
                {
                    throw new ArgumentOutOfRangeException("There would be an invalid amount of lumber");
                }
                lumber = lumber + amount;
            }
            else if (resource.ToLower().Equals("grain"))
            {
             if (grain + amount < 0 || grain + amount > 19)
                {
                    throw new ArgumentOutOfRangeException("There would be an invalid amount of grain");
                }
                grain = grain + amount;
            }
            else if (resource.ToLower().Equals("brick"))
            {
                if (brick + amount < 0 || brick + amount > 19)
                {
                    throw new ArgumentOutOfRangeException("There would be an invalid amount of brick");
                }
                brick = brick + amount;
            }
            // Don't know if we need this or not...

            //else if (resource.ToLower().Equals("devcard"))
            //{
            //devCards.Count();
            //}
        }
    }
}
