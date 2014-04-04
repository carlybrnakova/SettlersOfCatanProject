using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;

namespace ClassLibrary1
{
    [TestFixture()]
    class PlayerTest
    {
        Player universal1 = new Player();

        [Test()]
        public void TestConstructor()
        {
            var player0 = new Player();
            Assert.NotNull(player0);

            String playerName = "player1";
            Color playerColor = Color.Beige;
            var world = new World();
            var player1 = new Player(playerName, playerColor, world);
            Assert.IsTrue(player1.getColor() == playerColor);
            Assert.IsTrue(player1.getName() == playerName);
        }

        [Test()]
        public void TestCities1()
        {
            Assert.AreEqual(4, universal1.getCitiesRemaining());
        }

        [Test()]
        public void TestCities2()
        {
            universal1.incrementCities();
            universal1.incrementCities();
            Assert.AreEqual(2, universal1.getCitiesRemaining());
        }

        [Test()]
        public void TestCities3()
        {
            universal1.incrementCities();
            universal1.incrementCities();
            Assert.AreEqual(0, universal1.getCitiesRemaining());
        }

        [Test()]
        public void TestCitiesOverCap()
        {
            Assert.IsFalse(universal1.incrementCities());
        }

        [Test()]
        public void TestSettlements1()
        {
            Assert.AreEqual(4, universal1.getSettlementsRemaining());
        }

        [Test()]
        public void TestSettlements2()
        {
            universal1.incrementSettlements();
            universal1.incrementSettlements();
            universal1.incrementSettlements();
            Assert.AreEqual(3, universal1.getSettlementsRemaining());
        }

        [Test()]
        public void TestSettlements3()
        {
            universal1.incrementSettlements();
            universal1.incrementSettlements();
            Assert.AreEqual(0, universal1.getSettlementsRemaining());
        }

        [Test()]
        public void TestSettlementsOverCap()
        {
            Assert.IsFalse(universal1.incrementSettlements());
        }

        Player player1 = new Player();
        Player player2 = new Player();
        
        [Test()]
        public void testAcceptTrade()
        {
            //player1.proposeTrade()
        }
    }
}
