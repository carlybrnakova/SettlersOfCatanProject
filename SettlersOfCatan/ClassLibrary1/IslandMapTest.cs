using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;

namespace ClassLibrary1
{
    [TestFixture()]
    class IslandMapTest
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
                    if ((i == 0 || i == 5) && (j < 2 || j > 8)) break;
                    else if ((i == 1 || i == 4) && (j < 1 || j > 9)) break;
                    else Assert.NotNull(map.getIntAtIndex(i, j));
                }
            }
        }

        [Test()]
        public void TestThatTopRowIntersectionsHaveAppropriateLeftAndRightConnections()
        {
            int row = 0;
            for (int i = 2; i <= 8; i++)
            {
                if(i == 2)
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
                    Assert.AreEqual(map.getIntAtIndex(row, i + 1), map.getIntAtIndex(row, i).connections[2].getIntersection()); // Should have connection right-ward
                }
                else if (i == 10)
                {
                    Assert.Null(map.getIntAtIndex(row, i).connections[2].getIntersection()); // Should not have connection right-ward
                    Assert.AreEqual(map.getIntAtIndex(row, i - 1), map.getIntAtIndex(row, i).connections[0].getIntersection()); // Should have connection left-ward                   
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
                if (i % 2 == 0)
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
                if (i % 2 == 0)
                {
                    Assert.AreEqual(map.getIntAtIndex(row - 1, i), map.getIntAtIndex(row, i).connections[1].getIntersection());
                }
                else
                {
                    Assert.Null(map.getIntAtIndex(row, i).connections[1].getIntersection());
                }
            }
        }



    }
}
