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

        Player player1 = new Player();
        Player player2 = new Player();

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
            Assert.AreEqual(5, universal1.getSettlementsRemaining());
        }

        [Test()]
        public void TestSettlements2()
        {
            universal1.incrementSettlements();
            universal1.incrementSettlements();
            universal1.incrementSettlements();
            Assert.AreEqual(2, universal1.getSettlementsRemaining());
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

        [Test()]
        public void TestRoadsRemaining()
        {
            var target = new Player();
            Assert.AreEqual(15, target.getRoadsRemaining());
        }

        [Test()]
        public void TestIncrementRoads()
        {
            var target = new Player();
            Assert.IsTrue(target.incrementRoads());
            Assert.AreEqual(14, target.getRoadsRemaining());
        }

        [Test()]
        public void TestIncrementRoadsWhenFalse()
        {
            var target = new Player();
            for (int i = 0; i < 15; i++)
            {
                target.incrementRoads();
            }
            Assert.AreEqual(0, target.getRoadsRemaining());
            Assert.IsFalse(target.incrementRoads());
        }

        [Test()]
        public void TestGetHandWhenEmpty()
        {
            var target = new Player();
            Assert.NotNull(target.getHand());
            Assert.AreEqual(0, target.getHand().getResources());
        }

        [Test()]
        public void TestGetPoints()
        {
            var target = new Player();
            Assert.AreEqual(0, target.getPoints());
        }

        [Test()]
        public void TestIncrementPoints()
        {
            var target = new Player();
            target.incrementPoints(1);
            Assert.AreEqual(1, target.getPoints());
        }

        [Test()]
        public void TestHasWonGame()
        {
            var target = new Player();
            target.incrementPoints(9);
            Assert.IsFalse(target.hasWonGame());
            target.incrementPoints(1);
            Assert.IsTrue(target.hasWonGame());
        }

        [Test()]
        public void TestGenerateResourcesWithNoCitiesOrSettlements()
        {
            var target = new Player();
            target.generateBrick();
            target.generateGrain();
            target.generateLumber();
            target.generateOre();
            target.generateWool();
            Assert.AreEqual(0, target.getHand().getResources());
        }

        [Test()]
        public void TestGenerateResourcesWithOnlySettlements()
        {
            var target = new Player();
            target.incrementSettlements();
            target.incrementSettlements();
            Assert.AreEqual(3, target.getSettlementsRemaining());

            target.generateBrick();
            target.generateGrain();
            target.generateLumber();
            target.generateOre();
            target.generateWool();
            
            Assert.AreEqual(2, target.getHand().getBrick());
            Assert.AreEqual(2, target.getHand().getGrain());
            Assert.AreEqual(2, target.getHand().getLumber());
            Assert.AreEqual(2, target.getHand().getOre());
            Assert.AreEqual(2, target.getHand().getWool());
        }

        [Test()]
        public void TestGenerateResourcesWithOnlyCities()
        {
            var target = new Player();
            target.incrementCities();
            target.incrementCities();
            Assert.AreEqual(2, target.getCitiesRemaining());
            
            target.generateBrick();
            target.generateGrain();
            target.generateLumber();
            target.generateOre();
            target.generateWool();

            Assert.AreEqual(4, target.getHand().getBrick());
            Assert.AreEqual(4, target.getHand().getGrain());
            Assert.AreEqual(4, target.getHand().getLumber());
            Assert.AreEqual(4, target.getHand().getOre());
            Assert.AreEqual(4, target.getHand().getWool());
        }

        [Test()]
        public void TestGenerateResourcesWithBothCitiesAndSettlements()
        {
            var target = new Player();
            target.incrementSettlements();
            target.incrementSettlements();
            Assert.AreEqual(3, target.getSettlementsRemaining());

            target.incrementCities();
            target.incrementCities();
            Assert.AreEqual(2, target.getCitiesRemaining());

            target.generateBrick();
            target.generateGrain();
            target.generateLumber();
            target.generateOre();
            target.generateWool();

            Assert.AreEqual(6, target.getHand().getBrick());
            Assert.AreEqual(6, target.getHand().getGrain());
            Assert.AreEqual(6, target.getHand().getLumber());
            Assert.AreEqual(6, target.getHand().getOre());
            Assert.AreEqual(6, target.getHand().getWool());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGenerateBrickWithCitiesThrowsWhenBankHasInsufficientResources()
        {
            var target = new Player();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            Assert.AreEqual(0, target.getCitiesRemaining());

            target.generateBrick();
            target.generateBrick();

            Assert.AreEqual(16, target.getHand().getBrick());

            target.generateBrick();
        }
        
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGenerateGrainWithCitiesThrowsWhenBankHasInsufficientResources()
        {
            var target = new Player();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            Assert.AreEqual(0, target.getCitiesRemaining());

            target.generateGrain();
            target.generateGrain();

            Assert.AreEqual(16, target.getHand().getGrain());

            target.generateGrain();
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGenerateLumberWithCitiesThrowsWhenBankHasInsufficientResources()
        {
            var target = new Player();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            Assert.AreEqual(0, target.getCitiesRemaining());

            target.generateLumber();
            target.generateLumber();

            Assert.AreEqual(16, target.getHand().getLumber());

            target.generateLumber();
        }
        
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGenerateOreWithCitiesThrowsWhenBankHasInsufficientResources()
        {
            var target = new Player();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            Assert.AreEqual(0, target.getCitiesRemaining());

            target.generateOre();
            target.generateOre();

            Assert.AreEqual(16, target.getHand().getOre());

            target.generateOre();
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGenerateWoolWithCitiesThrowsWhenBankHasInsufficientResources()
        {
            var target = new Player();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            Assert.AreEqual(0, target.getCitiesRemaining());

            target.generateWool();
            target.generateWool();

            Assert.AreEqual(16, target.getHand().getWool());

            target.generateWool();
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGenerateBrickWithSettlementsThrowsWhenBankHasInsufficientResources()
        {
            var target = new Player();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            Assert.AreEqual(0, target.getSettlementsRemaining());

            target.generateBrick();
            target.generateBrick();
            target.generateBrick();

            Assert.AreEqual(15, target.getHand().getBrick());

            target.generateBrick();
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGenerateGrainWithSettlementsThrowsWhenBankHasInsufficientResources()
        {
            var target = new Player();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            Assert.AreEqual(0, target.getSettlementsRemaining());

            target.generateGrain();
            target.generateGrain();
            target.generateGrain();

            Assert.AreEqual(15, target.getHand().getGrain());

            target.generateGrain();
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGenerateLumberWithSettlementsThrowsWhenBankHasInsufficientResources()
        {
            var target = new Player();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            Assert.AreEqual(0, target.getSettlementsRemaining());

            target.generateLumber();
            target.generateLumber();
            target.generateLumber();

            Assert.AreEqual(15, target.getHand().getLumber());

            target.generateLumber();
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGenerateOreWithSettlementsThrowsWhenBankHasInsufficientResources()
        {
            var target = new Player();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            Assert.AreEqual(0, target.getSettlementsRemaining());

            target.generateOre();
            target.generateOre();
            target.generateOre();

            Assert.AreEqual(15, target.getHand().getOre());

            target.generateOre();
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGenerateWoolWithSettlementsThrowsWhenBankHasInsufficientResources()
        {
            var target = new Player();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            target.incrementSettlements();
            Assert.AreEqual(0, target.getSettlementsRemaining());

            target.generateWool();
            target.generateWool();
            target.generateWool();

            Assert.AreEqual(15, target.getHand().getWool());

            target.generateWool();
        }
        
        [Test()]
        public void TestProposeTrade()
        {
            var player1 = new Player();
            var player2 = new Player();
            int[] emptyArray = new int[] {0, 0, 0, 0, 0};
            player1.proposeTrade(player2, emptyArray, emptyArray);
        }

        [Test()]
        public void TestTradeCards()
        {
            var target = new Player();
            int[] emptyArray = new int[] { 0, 0, 0, 0, 0 };
            int[] tenArray = new int[] { 10, 10, 10, 10, 10 };
            target.tradeCards(emptyArray, tenArray);
            
            Assert.AreEqual(10, target.getHand().getBrick());
            Assert.AreEqual(10, target.getHand().getOre());
            Assert.AreEqual(10, target.getHand().getWool());
            Assert.AreEqual(10, target.getHand().getLumber());
            Assert.AreEqual(10, target.getHand().getGrain());
        }

        [Test()]
        public void TestAcceptTrade()
        {
            var player1 = new Player();
            var player2 = new Player();
            player1.incrementCities();
            player1.generateOre();
            player2.incrementCities();
            player2.generateBrick();
            int[] player1Hand = new int[] { 2, 0, 0, 0, 0};
            int[] player2Hand = new int[] { 0, 0, 0, 0, 2 };
            player1.proposeTrade(player2, player1Hand, player2Hand);
            player2.acceptTrade(player1, player2Hand, player1Hand);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAcceptTradeThrowsWhenPlayerCannotAcceptTrade()
        {
            var player1 = new Player();
            var player2 = new Player();
            player1.incrementCities();
            player1.generateOre();
            player2.incrementCities();
            player2.generateBrick();
            int[] player1Hand = new int[] { 2, 0, 0, 0, 0 };
            int[] threeBricks = new int[] { 0, 0, 0, 0, 3 };
            player1.proposeTrade(player2, player1Hand, threeBricks);

            // should throw because player2 only has 2 bricks
            player2.acceptTrade(player1, threeBricks, player1Hand);
        }

        [Test()]
        public void TestDeclineTrade()
        {
            var player1 = new Player();
            var player2 = new Player();
            player1.incrementCities();
            player1.generateOre();
            player2.incrementCities();
            player2.generateBrick();
            int[] player1Hand = new int[] { 2, 0, 0, 0, 0 };
            int[] player2Hand = new int[] { 0, 0, 0, 0, 2 };
            player1.proposeTrade(player2, player1Hand, player2Hand);
            player2.declineTrade();
        }
    }
}
