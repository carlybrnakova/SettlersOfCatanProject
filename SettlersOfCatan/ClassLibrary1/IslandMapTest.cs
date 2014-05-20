using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;

namespace ClassLibrary1
{
	[TestFixture()]
	internal class IslandMapTest
	{
		/* Test brand new IslandMap */
		private IslandMap map = new IslandMap();

		[Test()]
		public void TestThatNewIslandMapHas3NullsInCorners()
		{
			// Top left corner
			Assert.Null(map.getIntAtIndex(0, 0));
			Assert.Null(map.getIntAtIndex(0, 1));
			Assert.Null(map.getIntAtIndex(1, 0));

			// Top right corner
			Assert.Null(map.getIntAtIndex(0, 9));
			Assert.Null(map.getIntAtIndex(0, 10));
			Assert.Null(map.getIntAtIndex(1, 10));

			// Bottom left corner
			Assert.Null(map.getIntAtIndex(4, 0));
			Assert.Null(map.getIntAtIndex(5, 0));
			Assert.Null(map.getIntAtIndex(5, 1));

			// Bottom right corner
			Assert.Null(map.getIntAtIndex(4, 10));
			Assert.Null(map.getIntAtIndex(5, 9));
			Assert.Null(map.getIntAtIndex(5, 10));
		}

		[Test()]
		public void TestThatNewIslandMapHasNoNullsOtherThanTheFourCorners()
		{
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 11; j++)
				{
					Point point = new Point(i, j);
					if ((i == 0 || i == 5) && (j < 2 || j > 8)) Assert.Null(map.getIntAtIndex(point));
					else if ((i == 1 || i == 4) && (j < 1 || j > 9)) Assert.Null(map.getIntAtIndex(point));
					else Assert.NotNull(map.getIntAtIndex(point));
				}
			}
		}

		[Test()]
		public void TestThatTopRowIntersectionsHaveAppropriateLeftAndRightConnections()
		{
			int row = 0;
			for (int i = 2; i <= 8; i++)
			{
				if (i == 2)
				{
					Assert.Null(map.getIntAtIndex(row, i).connections[0].getIntersection()); // Should not have connection left-ward
					Assert.NotNull(map.getIntAtIndex(row, i).connections[2].getIntersection()); // Should have connection right-ward
				}
				else if (i == 8)
				{
					Assert.NotNull(map.getIntAtIndex(row, i).connections[0].getIntersection()); // Should have connection left-ward
					Assert.Null(map.getIntAtIndex(row, i).connections[2].getIntersection()); // Should not have connection right-ward
				}
				else
				{
					Assert.NotNull(map.getIntAtIndex(row, i).connections[0].getIntersection()); // Should have connection left-ward
					Assert.NotNull(map.getIntAtIndex(row, i).connections[2].getIntersection()); // Should have connection right-ward
				}
			}
		}

		[Test()]
		public void TestThatBottomRowIntersectionsHaveAppropriateLeftAndRightConnections()
		{
			int row = 5;
			for (int i = 2; i <= 8; i++)
			{
				if (i == 2)
				{
					Assert.Null(map.getIntAtIndex(row, i).connections[0].getIntersection()); // Should not have connection left-ward
					Assert.NotNull(map.getIntAtIndex(row, i).connections[2].getIntersection()); // Should have connection right-ward
				}
				else if (i == 8)
				{
					Assert.NotNull(map.getIntAtIndex(row, i).connections[0].getIntersection()); // Should have connection left-ward
					Assert.Null(map.getIntAtIndex(row, i).connections[2].getIntersection()); // Should not have connection right-ward
				}
				else
				{
					Assert.NotNull(map.getIntAtIndex(row, i).connections[0].getIntersection()); // Should have connection left-ward
					Assert.NotNull(map.getIntAtIndex(row, i).connections[2].getIntersection()); // Should have connection right-ward
				}
			}
		}

		[Test()]
		public void TestThatThirdRowHasCorrectLeftAndRightConnections()
		{
			int row = 2;
			for (int i = 0; i < 11; i++)
			{
				if (i == 0)
				{
					Assert.Null(map.getIntAtIndex(row, i).connections[0].getIntersection()); // Should not have connection left-ward
					Assert.AreEqual(map.getIntAtIndex(row, i + 1), map.getIntAtIndex(row, i).connections[2].getIntersection());
						// Should have connection right-ward
				}
				else if (i == 10)
				{
					Assert.Null(map.getIntAtIndex(row, i).connections[2].getIntersection()); // Should not have connection right-ward
					Assert.AreEqual(map.getIntAtIndex(row, i - 1), map.getIntAtIndex(row, i).connections[0].getIntersection());
						// Should have connection left-ward                   
				}
				else
				{
					Assert.AreEqual(map.getIntAtIndex(row, i - 1), map.getIntAtIndex(row, i).connections[0].getIntersection());
					Assert.AreEqual(map.getIntAtIndex(row, i + 1), map.getIntAtIndex(row, i).connections[2].getIntersection());
				}
			}
		}

		[Test()]
		public void TestThatThirdRowHasCorrectUpAndDownConnections()
		{
			int row = 2;
			for (int i = 0; i < 11; i++)
			{
				if (i%2 == 0)
				{
					Assert.AreEqual(map.getIntAtIndex(row + 1, i), map.getIntAtIndex(row, i).connections[1].getIntersection());
				}
				else
				{
					Assert.AreEqual(map.getIntAtIndex(row - 1, i), map.getIntAtIndex(row, i).connections[1].getIntersection());
				}
			}
		}

		[Test()]
		public void TestThatBottomRowHasCorrectUpAndDownConnections()
		{
			int row = 5;
			for (int i = 2; i <= 8; i++)
			{
				if (i%2 == 0)
				{
					Assert.AreEqual(map.getIntAtIndex(row - 1, i), map.getIntAtIndex(row, i).connections[1].getIntersection());
				}
				else
				{
					Assert.Null(map.getIntAtIndex(row, i).connections[1].getIntersection());
				}
			}
		}

		[Test()]
		public void
			TestThatSomethingCanBeBuiltAtEmptyIntersectionWithNoSurroundingBuildingsAndThenSurroundingIntersectionsAreLocked()
		{
			Player p = new Player();
			World w = new World();
			// 2, 5
			int x = 2, y = 5;
			Assert.True(map.getIntAtIndex(x, y).canBuildAtIntersection(p, 0));
			Assert.AreEqual(Global_Variables.GAME_PIECE.NONE, map.getIntAtIndex(x, y).getPieceType());
			map.buildSettlement(new Point(x, y));
			Assert.AreEqual(Global_Variables.GAME_PIECE.SETTLEMENT, map.getIntAtIndex(x, y).getPieceType());

			// Make sure none of the surrounding intersections can now be built up
			Assert.False(map.getIntAtIndex(x, y).canBuildAtIntersection(p, 0));
			for (int i = 0; i < 3; i++)
			{
				Assert.False(map.getIntAtIndex(x, y).connections[i].getIntersection().canBuildAtIntersection(p, 0));
			}
		}

		[Test()]
		public void TestThatCityCanBeBuiltFromSettlement()
		{
			Point p = new Point(3, 6);
			Assert.AreEqual(Global_Variables.GAME_PIECE.NONE, map.getIntAtIndex(p).getPieceType());
			map.buildSettlement(p);
			Assert.AreEqual(Global_Variables.GAME_PIECE.SETTLEMENT, map.getIntAtIndex(p).getPieceType());
			map.buildCity(p);
			Assert.AreEqual(Global_Variables.GAME_PIECE.CITY, map.getIntAtIndex(p).getPieceType());
		}

		[Test()]
		public void TestThatCityCannotBeBuiltWithoutSettlementFirst()
		{
			Point p = new Point(3, 3);
			Assert.True(map.getIntAtIndex(p).canBuildAtIntersection(new Player(), 0));
			Assert.False(map.buildCity(p));
		}

		[Test()]
		public void BiggerTestToBuildThreeSettlementsCorrectly()
		{
			int x = 5, y = 4;
			Player p = new Player();

			Assert.True(map.getIntAtIndex(x, y).canBuildAtIntersection(p, 0));
			map.buildSettlement(x, y);

			// Verify all other intersections on hex
			Assert.False(map.getIntAtIndex(x - 1, y).canBuildAtIntersection(p, 0));
			Assert.True(map.getIntAtIndex(x - 2, y).canBuildAtIntersection(p, 0));
			Assert.True(map.getIntAtIndex(x - 2, y - 1).canBuildAtIntersection(p, 0));
			Assert.True(map.getIntAtIndex(x - 1, y - 1).canBuildAtIntersection(p, 0));
			Assert.False(map.getIntAtIndex(x, y - 1).canBuildAtIntersection(p, 0));

			x = 4;
			y = 5;
			Assert.True(map.getIntAtIndex(x, y).canBuildAtIntersection(p, 0));
			map.buildSettlement(x, y);
			map.buildSettlement(x - 1, y + 2);
				// Build on opposite side of hex so only 2 settlements will be allowed rather than 3

			// Verify all other intersections on hex
			Assert.False(map.getIntAtIndex(x, y).canBuildAtIntersection(p, 0));
			Assert.False(map.getIntAtIndex(x - 1, y).canBuildAtIntersection(p, 0));
			Assert.False(map.getIntAtIndex(x - 1, y + 1).canBuildAtIntersection(p, 0));
			Assert.False(map.getIntAtIndex(x - 1, y + 2).canBuildAtIntersection(p, 0));
			Assert.False(map.getIntAtIndex(x, y + 2).canBuildAtIntersection(p, 0));
			Assert.False(map.getIntAtIndex(x, y + 1).canBuildAtIntersection(p, 0));
		}

		[Test()]
		public void TestRoadHasPlayerBuildingAtFirstIntersection()
		{
			// IslandMap newMap = new IslandMap();
			World w = new World(3, 0);
			w.currentPlayer.getHand().incrementAllResources();
			w.tryToBuildAtIntersection(new Point(0, 2));

			bool flag = w.getMap().getIslandMap().roadHasPlayerBuilding(new Point(0, 2), new Point(0, 3), w.currentPlayer);
			Assert.True(flag);
		}

		[Test()]
		public void TestRoadHasPlayerBuildingAtSecondIntersection()
		{
			// IslandMap newMap = new IslandMap();
			World w = new World(3, 0);
			w.currentPlayer.getHand().incrementAllResources();
			w.tryToBuildAtIntersection(new Point(0, 3));

			bool flag = w.getMap().getIslandMap().roadHasPlayerBuilding(new Point(0, 2), new Point(0, 3), w.currentPlayer);
			Assert.True(flag);
		}

		[Test()]
		public void TestBuildHorizontalRoad()
		{
			World w = new World(3, 0);
			w.currentPlayer.getHand().incrementAllResources();
			w.tryToBuildAtIntersection(new Point(0, 3));
			bool flag = w.getMap().getIslandMap().buildHorizontalRoad(new Point(0, 0), w.currentPlayer);
			Assert.True(flag);

			w.currentPlayer.getHand().incrementAllResources();
			w.tryToBuildAtIntersection(new Point(1, 4));
			flag = w.getMap().getIslandMap().buildHorizontalRoad(new Point(2, 2), w.currentPlayer);
			Assert.True(flag);

			w.currentPlayer.getHand().incrementAllResources();
			w.tryToBuildAtIntersection(new Point(3, 5));
			flag = w.getMap().getIslandMap().buildHorizontalRoad(new Point(6, 4), w.currentPlayer);

			flag = w.getMap().getIslandMap().buildHorizontalRoad(new Point(8, 6), w.currentPlayer);
			Assert.False(flag);
		}

		[Test()]
		public void TestBuildVerticalRoad()
		{
			World w = new World(3, 0);
			w.currentPlayer.getHand().incrementAllResources();
			w.currentPlayer.getHand().incrementAllResources();
			w.currentPlayer.getHand().incrementAllResources();
			w.tryToBuildAtIntersection(new Point(1, 5));
			bool flag = w.getMap().getIslandMap().buildVerticalRoad(new Point(3, 2), w.currentPlayer);
			Assert.True(flag);

			flag = w.getMap().getIslandMap().buildHorizontalRoad(new Point(4, 4), w.currentPlayer);
			Assert.True(flag);

			flag = w.getMap().getIslandMap().buildVerticalRoad(new Point(5, 2), w.currentPlayer);
			Assert.True(flag);

			flag = w.getMap().getIslandMap().buildVerticalRoad(new Point(9, 3), w.currentPlayer);
			Assert.False(flag);

			// for testing private method roadHasConnectingRoad
			flag = w.getMap().getIslandMap().buildHorizontalRoad(new Point(4, 5), w.currentPlayer);
			Assert.True(flag);

			flag = w.getMap().getIslandMap().buildHorizontalRoad(new Point(4, 3), w.currentPlayer);
			Assert.True(flag);
		}
	}
}