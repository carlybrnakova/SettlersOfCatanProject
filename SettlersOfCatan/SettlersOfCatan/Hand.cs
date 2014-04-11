using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlersOfCatan
{
    public class Hand
    {
        private int ore;
        private int wool;
        private int lumber;
        private int grain;
        private int brick;
        private int knights;

        private List<DevelopmentCard> devCards;

        public Hand()
        {
            this.ore = 5;
            this.wool = 5;
            this.lumber = 5;
            this.grain = 5;
            this.brick = 5;
            this.devCards = new List<DevelopmentCard>();
            this.knights = 0;
        }

        public int getResources()
        {
            return this.ore + this.wool + this.lumber + this.grain + this.brick;
        }

        public int getOre()
        {
            return this.ore;
        }

        public int getWool()
        {
            return this.wool;
        }

        public int getLumber()
        {
            return this.lumber;
        }

        public int getGrain()
        {
            return this.grain;
        }

        public int getBrick()
        {
            return this.brick;
        }

        public int getKnights()
        {
            return this.knights;
        }

        public void modifyOre(int amount)
        {
            if (this.ore < amount * -1)
                throw new System.ArgumentException("player cannot have negative resources");
            else
                this.ore += amount;
        }

        public void modifyWool(int amount)
        {
            if (this.wool < amount * -1)
                throw new System.ArgumentException("player cannot have negative resources");
            else
                this.wool += amount;
        }

        public void modifyLumber(int amount)
        {
            if (this.lumber < amount * -1)
                throw new System.ArgumentException("player cannot have negative resources");
            else
                this.lumber += amount;
        }

        public void modifyGrain(int amount)
        {
            if (this.grain < amount * -1)
                throw new System.ArgumentException("player cannot have negative resources");
            else
                this.grain += amount;
        }

        public void modifyBrick(int amount)
        {
            if (this.brick < amount * -1)
                throw new System.ArgumentException("player cannot have negative resources");
            else
                this.brick += amount;
        }

        public void modifyDevCard(int amount)
        {
            if (this.devCards.Count() < amount * -1)
                throw new System.ArgumentException("player cannot have negative resources");
            else
                for (int i = 0; i < amount; i++)
                {
                    this.devCards.Add(new DevelopmentCard());
                }
        }
    }
}
