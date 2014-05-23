using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SettlersOfCatan;

namespace SettlersOfCatan
{
	public static class Global_Variables
	{
		public enum GAME_PIECE
		{
			NONE,
			SETTLEMENT,
			CITY
		};

		public enum PLAYER_COLOR
		{
			NONE,
			PLAYER1_COLOR,
			PLAYER2_COLOR,
			PLAYER3_COLOR,
			PLAYER4_COLOR
		};

		public const int MAX_ROAD_ROWS = 11;
		public const int MAX_ROAD_COLUMNS = 10;
	}


	public class IslandMap
	{
		public Intersection[,] map = new Intersection[6, 11];

		public IslandMap()
		{
			initMap();
			setupConnections();
		}

		private void initMap()
		{
			for (int r = 0; r < 6; r++)
			{
				for (int c = 0; c < 11; c++)
				{
					// 3:1 ports
					if ((r == 0 && (c == 2 || c == 3)) ||
					    (r == 1 && (c == 8 || c == 9)) ||
					    ((r == 2 || r == 3) && c == 10) ||
					    (r == 5 && (c == 2 || c == 3)))
					{
						map[r, c] = new Intersection(new Point(r, c), new Port("Anything", 3));
					}
						// Resource ports
					else if (r == 0 && (c == 5 || c == 6))
					{
						map[r, c] = new Intersection(new Point(r, c), new Port("Wool", 2));
					}
					else if ((r == 1 || r == 2) && c == 1)
					{
						map[r, c] = new Intersection(new Point(r, c), new Port("Ore", 2));
					}
					else if ((r == 3 || r == 4) && c == 1)
					{
						map[r, c] = new Intersection(new Point(r, c), new Port("Grain", 2));
					}
					else if (r == 4 && (c == 8 || c == 9))
					{
						map[r, c] = new Intersection(new Point(r, c), new Port("Brick", 2));
					}
					else if (r == 5 && (c == 5 || c == 6))
					{
						map[r, c] = new Intersection(new Point(r, c), new Port("Lumber", 2));
					}
						// An intersection that doesn't have any ports
					else
					{
						map[r, c] = new Intersection(new Point(r, c));
					}
				}
			}
		}

		private void setupConnections()
		{
			for (int r = 0; r < 6; r++)
			{
				for (int c = 0; c < 11; c++)
				{
					// Ignore the four corners of the grid that do not actually get used on the board
					if (((r == 0 || r == 5) && (c < 2 || c > 8)) || ((r == 1 || r == 4) && (c < 1 || c > 9)))
					{
						map[r, c] = null;
					}
					else
					{
						// Does not have a left connection (connection1)
						if (((r == 0 || r == 5) && (c == 2)) || ((r == 1 || r == 4) && (c == 1)) || ((r == 2 || r == 3) && (c == 0)))
						{
							map[r, c].connections[0] = new Connection(null);
							map[r, c].connections[2] = new Connection(map[r, c + 1]);
							//map[r, c].connections.RemoveAt(0);
						}
							// Does not have a right connection (connection3)
						else if (((r == 0 || r == 5) && (c == 8)) || ((r == 1 || r == 4) && (c == 9)) || ((r == 2 || r == 3) && (c == 10)))
						{
							map[r, c].connections[0] = new Connection(map[r, c - 1]);
							//map[r, c].connections.RemoveAt(2);
							map[r, c].connections[2] = new Connection(null);
						}
						else
						{
							// Left (connection1) and right (connection3) connections
							map[r, c].connections[0] = new Connection(map[r, c - 1]);
							map[r, c].connections[2] = new Connection(map[r, c + 1]);
						}

						int mapRow;
						if ((r == 0 || r == 5) && c%2 == 1)
						{
							map[r, c].connections[1] = new Connection(null);
							//map[r, c].connections.RemoveAt(1);
						}
						else
						{
							// Determine if top or bottom connection (connection2)
							if ((r + c)%2 == 0) mapRow = r + 1; // Connect downward 
							else mapRow = r - 1; // Connect upward

							map[r, c].connections[1] = new Connection(map[mapRow, c]);
						}
					}
				}
			}
		}

		public bool buildHorizontalRoad(Point coords, Player player)
		{
			int xVal = coords.X;
			int yVal = coords.Y;
			int intRow, intCol = 0;
			intRow = xVal/2;
			if (xVal == 0 || xVal == 10)
			{
				intCol = yVal + 2;
			}
			else if (xVal == 2 || xVal == 8)
			{
				intCol = yVal + 1;
			}
			else if (xVal == 4 || xVal == 6)
			{
				intCol = yVal;
			}
			else
			{
			} // throw exception?

			if (roadHasBuildingOrConnectingRoad(new Point(intRow, intCol), new Point(intRow, intCol + 1), player))
			{
				map[intRow, intCol].connections[2].buildRoad(player.getColor(), coords);
				map[intRow, intCol + 1].connections[0].buildRoad(player.getColor(), coords);
				return true;
			}
			else return false;
		}

		public bool buildVerticalRoad(Point coords, Player player)
		{
			int xVal = coords.X;
			int yVal = coords.Y;
			int intRow, intCol = 0;
			intRow = xVal/2;
			if (xVal == 1 || xVal == 9)
			{
				intCol = yVal*2 + 2;
			}
			else if (xVal == 3 || xVal == 7)
			{
				intCol = yVal*2 + 1;
			}
			else if (xVal == 5)
			{
				intCol = yVal*2;
			}
			else
			{
			} // Throw exception?

			if (roadHasBuildingOrConnectingRoad(new Point(intRow, intCol), new Point(intRow + 1, intCol), player))
			{
				map[intRow, intCol].connections[1].buildRoad(player.getColor(), coords);
				map[intRow + 1, intCol].connections[1].buildRoad(player.getColor(), coords);
				return true;
			}
			else return false;
		}

		private bool roadHasBuildingOrConnectingRoad(Point p1, Point p2, Player player)
		{
			return roadHasPlayerBuilding(p1, p2, player) || roadHasConnectingRoad(p1, p2, player);
		}

		public bool roadHasPlayerBuilding(Point connection1, Point connection2, Player thePlayer)
		{
			bool flag;
			bool hasBuilding = false;
			bool buildingIsCorrectPlayer = false;

			if (map[connection1.X, connection1.Y].hasABuilding())
			{
				hasBuilding = true;
				buildingIsCorrectPlayer = map[connection1.X, connection1.Y].getPlayer() == thePlayer;
			}
			else if (map[connection2.X, connection2.Y].hasABuilding())
			{
				hasBuilding = true;
				buildingIsCorrectPlayer = map[connection2.X, connection2.Y].getPlayer() == thePlayer;
			}

			flag = hasBuilding && buildingIsCorrectPlayer;
			return flag;
		}

		private bool roadHasConnectingRoad(Point p1, Point p2, Player player)
		{
			bool flag;
			bool hasRoad = false;
			bool roadIsCorrectPlayer = false;

			if (map[p1.X, p1.Y].connections[0].isBuilt())
			{
				hasRoad = true;
				roadIsCorrectPlayer = map[p1.X, p1.Y].connections[0].getRoadColor() == player.getColor();
			}

			if (map[p1.X, p1.Y].connections[1].isBuilt() && !roadIsCorrectPlayer)
			{
				hasRoad = true;
				roadIsCorrectPlayer = map[p1.X, p1.Y].connections[1].getRoadColor() == player.getColor();
			}

			if (map[p1.X, p1.Y].connections[2].isBuilt() && !roadIsCorrectPlayer)
			{
				hasRoad = true;
				roadIsCorrectPlayer = map[p1.X, p1.Y].connections[2].getRoadColor() == player.getColor();
			}

			if (map[p2.X, p2.Y].connections[1].isBuilt() && !roadIsCorrectPlayer)
			{
				hasRoad = true;
				roadIsCorrectPlayer = map[p2.X, p2.Y].connections[1].getRoadColor() == player.getColor();
			}

			if (map[p2.X, p2.Y].connections[2].isBuilt() && !roadIsCorrectPlayer)
			{
				hasRoad = true;
				roadIsCorrectPlayer = map[p2.X, p2.Y].connections[2].getRoadColor() == player.getColor();
			}

			if (map[p2.X, p2.Y].connections[0].isBuilt() && !roadIsCorrectPlayer)
			{
				hasRoad = true;
				roadIsCorrectPlayer = map[p2.X, p2.Y].connections[0].getRoadColor() == player.getColor();
			}


			flag = hasRoad && roadIsCorrectPlayer && !hasOtherPlayerIntersection(p1, player);
			return flag;
		}

		private bool hasOtherPlayerIntersection(Point p1, Player player)
		{
			return map[p1.X, p1.Y].hasABuilding() && map[p1.X, p1.Y].color != player.getColor();
		}

		/*
        public void setupRoadConnections()
        {
            int col;
            int columnMax = 6;
            // The horizontal roads
            for (int r = 0; r < Global_Variables.MAX_ROAD_ROWS; r += 2)
            {
                for (col = 0; col < columnMax; col++)
                {
                    if (r == 0 || r == 10)
                    {
                        map[r/2, col + 2].connections
                    }

                }
                // Allow more or less buttons for the next row
                if (r < 4) columnMax += 2;
                else if (r >= 6) columnMax -= 2;
            }

        }
        */

		public Intersection getIntAtIndex(int x, int y)
		{
			Intersection i = map[x, y];
			return i;
		}

		public Intersection getIntAtIndex(Point p)
		{
			Intersection i = map[p.X, p.Y];
			return i;
		}

		public void buildSettlement(int x, int y)
		{
			map[x, y].build(Global_Variables.GAME_PIECE.SETTLEMENT);
		}

		public void buildSettlement(Point p)
		{
			map[p.X, p.Y].build(Global_Variables.GAME_PIECE.SETTLEMENT);
		}

		public bool buildCity(Point p)
		{
			if (!map[p.X, p.Y].hasABuilding())
			{
				return false;
			}
			else
			{
				map[p.X, p.Y].build(Global_Variables.GAME_PIECE.CITY);
				return true;
			}
		}
	}
}
