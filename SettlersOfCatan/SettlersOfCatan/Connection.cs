using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettlersOfCatan;

namespace SettlersOfCatan
{
    public class Connection
    {
        public Intersection connectedTo;
        private Global_Variables.PLAYER_COLOR roadColor;

        public Connection(Intersection i)
        {
            connectedTo = i;
        }

        public Intersection getIntersection()
        {
            return connectedTo;
        }

    }
}
