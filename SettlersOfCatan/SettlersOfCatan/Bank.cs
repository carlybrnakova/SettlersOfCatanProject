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
            {
                throw new ArgumentException("Must name a valid resource type");
            }
        }

        public void tradeFourForOne(Player p, String tradeIn, String payOut)
        {
            if (getResourceRemaining(tradeIn) == 0)
            {
                throw new InvalidOperationException("The bank is out of " + payOut);
            }

            // TODO: increment + decrement cards in player's hand
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
