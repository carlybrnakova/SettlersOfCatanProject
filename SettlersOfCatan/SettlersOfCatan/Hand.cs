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

        public int getDevCardCount()
        {
            return this.devCards.Count();
        }

        public int getResource(String resourceType)
        {
            switch (resourceType)
            {
                case "ore":
                    return getOre();
                case "wool":
                    return getWool();
                case "lumber":
                    return getLumber();
                case "grain":
                    return getGrain();
                case "brick":
                    return getBrick();
            }
            throw new ArgumentException();
        }

        public void modifyResources(String resourceType, int amount)
        {
            switch (resourceType)
            {
                case "ore":
                    modifyOre(amount);
                    break;
                case "wool":
                    modifyWool(amount);
                    break;
                case "lumber":
                    modifyLumber(amount);
                    break;
                case "grain":
                    modifyGrain(amount);
                    break;
                case "brick":
                    modifyBrick(amount);
                    break;
            }
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

        public void addDevCard(List<DevelopmentCard> cards)
        {
            this.devCards.AddRange(cards);
        }

        public void removeDevCard(String cardType)
        {
            switch (cardType)
            {
                case "knight":
                    {
                        if (devCardsContains("knight"))
                        {
                            var itemToRemove = this.devCards.First(r => r.getType() == "knight");
                            this.devCards.Remove(itemToRemove);
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("You don't have any to remove");
                        }
                    }
                case "victoryPoint":
                    {
                        if (devCardsContains("victoryPoint"))
                        {
                            var itemToRemove = this.devCards.First(r => r.getType() == "victoryPoint");
                            this.devCards.Remove(itemToRemove);
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("You don't have any to remove");
                        }
                    }
                case "monopoly":
                    {
                        if (devCardsContains("monopoly"))
                        {
                            var itemToRemove = this.devCards.First(r => r.getType() == "monopoly");
                            this.devCards.Remove(itemToRemove);
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("You don't have any to remove");
                        }
                    }
                case "roadBuilder":
                    {
                        if (devCardsContains("roadBuilder"))
                        {
                            var itemToRemove = this.devCards.First(r => r.getType() == "roadBuilder");
                            this.devCards.Remove(itemToRemove);
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("You don't have any to remove");
                        }
                    }
                case "yearOfPlenty":
                    {
                        if (devCardsContains("yearOfPlenty"))
                        {
                            var itemToRemove = this.devCards.First(r => r.getType() == "yearOfPlenty");
                            this.devCards.Remove(itemToRemove);
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("You don't have any to remove");
                        }
                    }
            }
        }

        public bool devCardsContains(String cardType)
        {
            while (this.devCards.Count > 0)
            {
                switch (cardType)
                {
                    case "knight":
                        {
                            foreach (DevelopmentCard card in this.devCards)
                            {
                                if (card.getType() == "knight")
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                    case "monopoly":
                        {
                            foreach (DevelopmentCard card in this.devCards)
                            {
                                if (card.getType() == "monopoly")
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                    case "victoryPoint":
                        {
                            foreach (DevelopmentCard card in this.devCards)
                            {
                                if (card.getType() == "victoryPoint")
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                    case "roadBuilder":
                        {
                            foreach (DevelopmentCard card in this.devCards)
                            {
                                if (card.getType() == "roadBuilder")
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                    case "yearOfPlenty":
                        {
                            foreach (DevelopmentCard card in this.devCards)
                            {
                                if (card.getType() == "yearOfPlenty")
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                }
            }
           return false;
        }

        public bool hasRoadResources()
        {
            return (brick >= 1) && (lumber >= 1);
        }

        public bool hasSettlementResources()
        {
            return (brick >= 1) && (grain >= 1) && (wool >= 1) && (lumber >= 1);
        }

        public bool hasCityResources()
        {
            return (grain >= 2) && (ore >= 3);
        }

        public bool hasDevCardResources()
        {
            return (wool >= 1) && (grain >= 1) && (ore >= 1);
        }

        public void incrementKnightsPlayed()
        {
            this.knights++;
        }
    }
}
