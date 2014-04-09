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
        private Color GRAIN_COLOR = Color.Gold;
        private Color DESERT_COLOR = Color.Wheat;
        private Color LUMBER_COLOR = Color.ForestGreen;
        private Color ORE_COLOR = Color.Gray;
        private Color WOOL_COLOR = Color.PaleGoldenrod;
        private Color BRICK_COLOR = Color.Orange;



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
            List<Color> resourceColors = new List<Color>(19)
            {
                GRAIN_COLOR, GRAIN_COLOR, GRAIN_COLOR, GRAIN_COLOR,
                LUMBER_COLOR, LUMBER_COLOR, LUMBER_COLOR, LUMBER_COLOR,
                ORE_COLOR, ORE_COLOR, ORE_COLOR,
                WOOL_COLOR, WOOL_COLOR, WOOL_COLOR, WOOL_COLOR, 
                BRICK_COLOR, BRICK_COLOR, BRICK_COLOR,
                DESERT_COLOR 
            };

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
                        Hex theHex = new Hex();
                        
                    }


                }
            }

        }




            class Hex
        {


        }

    }
}
