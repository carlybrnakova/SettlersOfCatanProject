using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SettlersOfCatan;

namespace SettlersOfCatan
{
    public class HexMap
    {
        public Hex[,] map = new Hex[5, 5];

        public HexMap()
        {
            initMap();
            setupMap();
        }

        private void initMap()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    map[i, j] = null;
                }
            }
        }

        private void setupMap()
        {
            /*
            List<Color> resourceColors = new List<Color>(19) 
            {
                GRAIN_COLOR, GRAIN_COLOR, GRAIN_COLOR, GRAIN_COLOR,
                LUMBER_COLOR, LUMBER_COLOR, LUMBER_COLOR, LUMBER_COLOR,
                ORE_COLOR, ORE_COLOR, ORE_COLOR,
                WOOL_COLOR, WOOL_COLOR, WOOL_COLOR, WOOL_COLOR, 
                BRICK_COLOR, BRICK_COLOR, BRICK_COLOR,
                DESERT_COLOR 
            };
             * */

            HexDeck hexDeck = new HexDeck();
            Random rand = new Random();
            int randomIndex = rand.Next(0, hexDeck.Count);
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if ((r == 0 && (c == 0 || c == 4))
                        || (c == 4 && (r == 1 || r == 3))
                        || (r == 4 && (c == 0 || c == 4)))
                    {
                        map[r, c] = null;
                    }
                    else
                    {
                        Hex theHex;
                        randomIndex = rand.Next(0, hexDeck.Count);
                        theHex = hexDeck.ElementAt(randomIndex);

                        map[r, c] = theHex;
                        hexDeck.RemoveAt(randomIndex);
                    }
                }
            }

        }
        

    }







    public class Hex
    {
        private String type;
        private Color color;

        public Hex(String terrainType, Color c)
        {
            this.type = terrainType;
            this.color = c;
        }

    }



    class HexDeck : List<Hex>
    {
        //private List<Hex> allHexes = new List<Hex>(19);
        private Color GRAIN_COLOR = Color.Gold;
        private Color DESERT_COLOR = Color.Wheat;
        private Color LUMBER_COLOR = Color.ForestGreen;
        private Color ORE_COLOR = Color.Gray;
        private Color WOOL_COLOR = Color.PaleGoldenrod;
        private Color BRICK_COLOR = Color.Orange;



        public HexDeck()
        {
            addAllHexes();
        }



        private void addAllHexes()
        {
            addAllForest(); // Lumber
            addAllHills(); // Brick
            addAllMountains(); // Ore
            addAllFields(); // Grain
            addAllPasture(); // Wool
            addDesert();
        }

        private void addAllForest()
        {
            for (int i = 0; i < 4; i++)
            {
                this.Add(new Hex("Forest", LUMBER_COLOR));
            }
        }

        private void addAllHills()
        {
            for (int i = 0; i < 3; i++)
            {
                this.Add(new Hex("Hills", BRICK_COLOR));
            }
        }

        private void addAllMountains()
        {
            for (int i = 0; i < 3; i++)
            {
                this.Add(new Hex("Mountain", ORE_COLOR));
            }
        }

        private void addAllFields()
        {
            for (int i = 0; i < 4; i++)
            {
                this.Add(new Hex("Fields", GRAIN_COLOR));
            }
        }

        private void addAllPasture()
        {
            for (int i = 0; i < 4; i++)
            {
                this.Add(new Hex("Pasture", WOOL_COLOR));
            }
        }

        private void addDesert()
        {

            this.Add(new Hex("Desert", DESERT_COLOR));
        }


    }
}
