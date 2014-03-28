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
            return (ore + wool + lumber + grain + brick == 95 && devCards.Count() == 25);
        }

        public int getResourceRemaining(String resource)
        {
            if (resource.ToLower().Equals("ore"))
            {
                return ore;
            }
            else if (resource.ToLower().Equals("wool"))
            {
                return wool;
            }
            else if (resource.ToLower().Equals("lumber"))
            {
                return lumber;
            }
            else if (resource.ToLower().Equals("grain"))
            {
                return grain;
            }
            else if (resource.ToLower().Equals("brick"))
            {
                return brick;
            }
            else if (resource.ToLower().Equals("devcard"))
            {
                return devCards.Count();
            }
          
            throw new ArgumentNullException("Must name a valid resource type");
            
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
            else
            {
                throw new ArgumentNullException("Must name a valid resource type");
            }
        }

        public void tradeFourForOne(Player p, String tradeIn, String payOut)
        {
            if (getResourceRemaining(tradeIn) == 0)
            {
                throw new InvalidOperationException("The bank is out of " + payOut);
            }

            // TODO: increment + decrement cards in player's hand
            if (tradeIn.ToLower().Equals("ore")) {
                if (p.getHand().getOre() >= 4) {
                    p.tradeWithBank("ore");
                }
            }
            else if (tradeIn.ToLower().Equals("wool")) {
            
            } 
            else if (tradeIn.ToLower().Equals("lumber"))
            {
                
            }
            else if (tradeIn.ToLower().Equals("grain"))
            {
                
            }
            else if (tradeIn.ToLower().Equals("brick"))
            {
                
            }
            else if (tradeIn.ToLower().Equals("devcard")) {
            
            }
        }

        public void tradeThreeForOne(Player p, String tradeIn, String payOut)
        {
            if (getResourceRemaining(tradeIn) == 0)
            {
                throw new InvalidOperationException("The bank is out of " + payOut);
            }

            // TODO: increment + decrement cards in player's hand
        }

        public void tradeTwoForOne(Player p, String tradeIn, String payOut)
        {
            if (getResourceRemaining(tradeIn) == 0)
            {
                throw new InvalidOperationException("The bank is out of " + payOut);
            }

            // TODO: increment + decrement cards in player's hand
        }
    }
}
