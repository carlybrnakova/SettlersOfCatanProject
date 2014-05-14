using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlersOfCatan
{
    public class Port
    {
        String resourceType;
        int tradeAmount;


        public Port(String r, int amount)
        {
            this.resourceType = r;
            this.tradeAmount = amount;
        }



    }
}
