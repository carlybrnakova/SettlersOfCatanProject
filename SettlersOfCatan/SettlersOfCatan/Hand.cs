using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlersOfCatan
{
    class Hand
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
            this.ore = 0;
            this.wool = 0;
            this.lumber = 0;
            this.grain = 0;
            this.brick = 0;
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
            this.ore += amount;
        }

        public void modifyWool(int amount)
        {
            this.wool += amount;
        }

        public void modifyLumber(int amount)
        {
            this.lumber += amount;
        }

        public void modifyGrain(int amount)
        {
            this.grain += amount;
        }

        public void modifyBrick(int amount)
        {
            this.brick += amount;
        }
    }
}
