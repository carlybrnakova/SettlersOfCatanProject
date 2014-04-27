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
                    // IF: row is even and col is even (ex: row = 2, col = 4)
                    // THEN: the three hexes are:
                            // [row - 1][col/2 - 1] ex: [1][1]
                            // [row][col/2] ex: [2][2]
                            // [row][col/2 - 1] ex: [2][1]
                    if (r % 2 == 0 && c % 2 == 0)
                    {
                        if (theIslandMap.map[r, c] != null)
                        {
                            try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r - 1, c / 2 - 1]); }
                            catch (IndexOutOfRangeException) { }
                            try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r, c / 2]); }
                            catch (IndexOutOfRangeException) { }
                            try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r, c / 2 - 1]); }
                            catch (IndexOutOfRangeException) { }
                        }
                    }
                    // IF: row is even and col is odd (ex: row = 2, col = 5)
                    // THEN: the three hexes are:
                            // [row - 1][col/2] ex: [1][2]
                            // [row - 1][col/2 - 1] ex: [1][1]
                            // [row][col/2] ex: [2][2]
                    else if (r % 2 == 0 && c % 2 != 0)
                    {
                        if (theIslandMap.map[r, c] != null)
                        {
                            try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r - 1, c / 2]); }
                            catch (IndexOutOfRangeException) { }
                            try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r - 1, c / 2 - 1]); }
                            catch (IndexOutOfRangeException) { }
                           // try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r, c / 2]); }
                           // catch (IndexOutOfRangeException) { }
                            theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r, c / 2]);
                        }
                    }
                    // IF: row is odd and col is odd (ex: row = 3, col = 7)
                    // THEN: the three hexes are:
                            // [row - 1][col/2] ex: [2][3]
                            // [row][col/2] ex: [3][3]
                            // [row][col/2 - 1] ex: [3][2]
                    else if (r % 2 != 0 && c % 2 != 0)
                    {
                        if (theIslandMap.map[r, c] != null)
                        {
                            theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r - 1, c / 2]);
                           // try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r - 1, c / 2]); }
                           // catch (IndexOutOfRangeException) { }
                            try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r, c / 2]); }
                            catch (IndexOutOfRangeException) { }
                            try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r, c / 2 - 1]); }
                            catch (IndexOutOfRangeException) { }
                        }
                    }
                    // IF: row is odd and col is even (ex: row = 3, col = 4)
                    // THEN: the three hexes are:
                            // [row - 1][col/2 - 1] ex: [2][1]
                            // [row - 1][col/2] ex: [2][2]
                            // [row][col/2 - 1] ex: [3][1]
                    else if (r % 2 != 0 && c % 2 == 0)
                    {
                        if (theIslandMap.map[r, c] != null)
                        {
                            try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r - 1, c / 2 - 1]); }
                            catch (IndexOutOfRangeException) { }
                            try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r - 1, c / 2]); }
                            catch (IndexOutOfRangeException) { }
                            try { theIslandMap.map[r, c].resourceHexes.Add(theHexMap.map[r, c / 2 - 1]); }
                            catch (IndexOutOfRangeException) { }
                        }
                    }
                }
            }


        }

        public IslandMap getIslandMap()
        {
            return this.theIslandMap;
        }

        public HexMap getHexMap()
        {
            return this.theHexMap;
        }
    }
}
