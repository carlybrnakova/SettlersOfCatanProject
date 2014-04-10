using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettlersOfCatan;

namespace SettlersOfCatan
{
    public class CompleteMap
    {
        private IslandMap theIslandMap;
        private HexMap theHexMap;

        public CompleteMap()
        {
            theIslandMap = new IslandMap();
            theHexMap = new HexMap();
            linkMapsForResources();
        }

        private void linkMapsForResources()
        {
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 11; c++)
                {
                    if(r
                }
            }


        }




    }
}
