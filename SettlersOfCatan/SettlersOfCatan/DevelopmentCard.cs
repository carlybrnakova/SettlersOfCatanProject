using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlersOfCatan
{
    public abstract class DevelopmentCard
    {
        String name;

        public DevelopmentCard(String type)
        {
            this.name = type;
        }

        public String getType() 
        {
            return this.name;
        }
    }

    public class Knight : DevelopmentCard
    {

        public Knight()
            : base("knight")
        {
            ;
        }

        public void move()
        {

        }

    }

    public class VictoryPointCard : DevelopmentCard
    {

        public VictoryPointCard()
            : base("victoryPoint")
        {
            ;
        }
    }

    public class MonopolyCard : DevelopmentCard
    {
               
        public MonopolyCard()
            : base("monopoly")
        {
            ;
        }
    }

    public class RoadBuilderCard : DevelopmentCard
    {
                
        public RoadBuilderCard()
            : base("roadBuilder")
        {
            ;
        }
    }

    public class YearOfPlentyCard : DevelopmentCard
    {

        public YearOfPlentyCard()
            : base("yearOfPlenty")
        {
            ;
        }
    }

}
