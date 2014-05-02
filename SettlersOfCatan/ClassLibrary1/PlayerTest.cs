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
        public void TestMakeTrade()
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
            player2.makeTrade();
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestmakeTradeThrowsWhenPlayerCannotMakeTrade()
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
            player2.makeTrade();
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

        [Test()]
        public void TestTradeAtPort()
        {
            var target = new Player();
            
            target.incrementCities();
            target.incrementSettlements();
            
            target.generateBrick();
            target.generateGrain();
            target.generateLumber();
            target.generateOre();
            target.generateWool();

            target.tradeAtPort(3, "grain", "brick");
            target.tradeAtPort(3, "lumber", "grain");
            target.tradeAtPort(3, "ore", "lumber");
            target.tradeAtPort(3, "wool", "ore");
            target.tradeAtPort(3, "brick", "wool");

            Assert.AreEqual(1, target.getHand().getGrain());
            Assert.AreEqual(1, target.getHand().getLumber());
            Assert.AreEqual(1, target.getHand().getOre());
            Assert.AreEqual(1, target.getHand().getWool());
            Assert.AreEqual(1, target.getHand().getBrick());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeForGrainAtPortThrowsWhenBankHasNone()
        {
            World world = new World();
            var player1 = new Player("Bob", Color.Red, world);
            var player2 = new Player("Jim", Color.Blue, world);

            player1.incrementSettlements();

            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementSettlements();

            player1.generateGrain();
            player2.generateGrain();
            player2.generateGrain();
            Assert.AreEqual(0, world.bank.getGrainRemaining());

            player1.generateOre();
            player1.generateOre();
            player1.generateOre();
            player1.tradeAtPort(3, "grain", "ore");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeForOreAtPortThrowsWhenBankHasNone()
        {
            World world = new World();
            var player1 = new Player("Bob", Color.Red, world);
            var player2 = new Player("Jim", Color.Blue, world);

            player1.incrementSettlements();

            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementSettlements();

            player1.generateOre();
            player2.generateOre();
            player2.generateOre();
            Assert.AreEqual(0, world.bank.getOreRemaining());

            player1.generateWool();
            player1.generateWool();
            player1.generateWool();
            player1.tradeAtPort(3, "ore", "wool");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeForWoolAtPortThrowsWhenBankHasNone()
        {
            World world = new World();
            var player1 = new Player("Bob", Color.Red, world);
            var player2 = new Player("Jim", Color.Blue, world);

            player1.incrementSettlements();

            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementSettlements();

            player1.generateWool();
            player2.generateWool();
            player2.generateWool();
            Assert.AreEqual(0, world.bank.getWoolRemaining());

            player1.generateLumber();
            player1.generateLumber();
            player1.generateLumber();
            player1.tradeAtPort(3, "wool", "lumber");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeForLumberAtPortThrowsWhenBankHasNone()
        {
            World world = new World();
            var player1 = new Player("Bob", Color.Red, world);
            var player2 = new Player("Jim", Color.Blue, world);

            player1.incrementSettlements();

            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementSettlements();

            player1.generateLumber();
            player2.generateLumber();
            player2.generateLumber();
            Assert.AreEqual(0, world.bank.getLumberRemaining());

            player1.generateBrick();
            player1.generateBrick();
            player1.generateBrick();
            player1.tradeAtPort(3, "lumber", "brick");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeForBrickAtPortThrowsWhenBankHasNone()
        {
            World world = new World();
            var player1 = new Player("Bob", Color.Red, world);
            var player2 = new Player("Jim", Color.Blue, world);

            player1.incrementSettlements();

            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementSettlements();

            player1.generateBrick();
            player2.generateBrick();
            player2.generateBrick();
            Assert.AreEqual(0, world.bank.getBrickRemaining());

            player1.generateGrain();
            player1.generateGrain();
            player1.generateGrain();
            player1.tradeAtPort(3, "brick", "grain");
        }

        [Test()]
        public void TestTradeWithBank()
        {
            var target = new Player();

            target.incrementCities();
            target.incrementCities();

            target.generateBrick();
            target.generateGrain();
            target.generateLumber();
            target.generateOre();
            target.generateWool();

            target.tradeWithBank("grain", "brick");
            target.tradeWithBank("lumber", "grain");
            target.tradeWithBank("ore", "lumber");
            target.tradeWithBank("wool", "ore");
            target.tradeWithBank("brick", "wool");

            Assert.AreEqual(1, target.getHand().getGrain());
            Assert.AreEqual(1, target.getHand().getLumber());
            Assert.AreEqual(1, target.getHand().getOre());
            Assert.AreEqual(1, target.getHand().getWool());
            Assert.AreEqual(1, target.getHand().getBrick());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeWithBankForGrainThrowsWhenBankHasNone()
        {
            World world = new World();
            var player1 = new Player("Bob", Color.Red, world);
            var player2 = new Player("Jim", Color.Blue, world);

            player1.incrementCities();
            player1.incrementCities();

            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementSettlements();

            player2.generateGrain();
            player2.incrementSettlements();
            player2.generateGrain();

            Assert.AreEqual(0, world.bank.getGrainRemaining());

            player1.generateOre();

            player1.tradeWithBank("ore", "grain");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeWithBankForOreThrowsWhenBankHasNone()
        {
            World world = new World();
            var player1 = new Player("Bob", Color.Red, world);
            var player2 = new Player("Jim", Color.Blue, world);

            player1.incrementCities();
            player1.incrementCities();

            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementSettlements();

            player2.generateOre();
            player2.incrementSettlements();
            player2.generateOre();

            Assert.AreEqual(0, world.bank.getOreRemaining());

            player1.generateLumber();

            player1.tradeWithBank("lumber", "ore");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeWithBankForLumberThrowsWhenBankHasNone()
        {
            World world = new World();
            var player1 = new Player("Bob", Color.Red, world);
            var player2 = new Player("Jim", Color.Blue, world);

            player1.incrementCities();
            player1.incrementCities();

            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementSettlements();

            player2.generateLumber();
            player2.incrementSettlements();
            player2.generateLumber();

            Assert.AreEqual(0, world.bank.getLumberRemaining());

            player1.generateWool();

            player1.tradeWithBank("wool", "lumber");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeWithBankForWoolThrowsWhenBankHasNone()
        {
            World world = new World();
            var player1 = new Player("Bob", Color.Red, world);
            var player2 = new Player("Jim", Color.Blue, world);

            player1.incrementCities();
            player1.incrementCities();

            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementSettlements();

            player2.generateWool();
            player2.incrementSettlements();
            player2.generateWool();

            Assert.AreEqual(0, world.bank.getWoolRemaining());

            player1.generateBrick();

            player1.tradeWithBank("brick", "wool");
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeWithBankForBrickThrowsWhenBankHasNone()
        {
            World world = new World();
            var player1 = new Player("Bob", Color.Red, world);
            var player2 = new Player("Jim", Color.Blue, world);

            player1.incrementCities();
            player1.incrementCities();

            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementCities();
            player2.incrementSettlements();

            player2.generateBrick();
            player2.incrementSettlements();
            player2.generateBrick();

            Assert.AreEqual(0, world.bank.getBrickRemaining());

            player1.generateGrain();

            player1.tradeWithBank("grain", "brick");
        }

        [Test()]
        public void TestTradeForDevCard()
        {
            var target = new Player();

            target.incrementSettlements();
            target.generateWool();
            target.generateGrain();
            target.generateOre();

            target.tradeForDevCard();
            Assert.AreEqual(0, target.getHand().getResources());
            Assert.AreEqual(1, target.getHand().getDevCardCount());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTradeForDevCardThrowsWhenBankHasNoDevCards()
        {
            var target = new Player();

            target.incrementCities();
            target.incrementCities();
            target.incrementSettlements();

            for (int i = 0; i < 5; i++)
            {
                target.generateGrain();
                target.generateOre();
                target.generateWool();

                for (int j = 0; j < 5; j++)
                {
                    target.tradeForDevCard();
                }
            }

            target.generateGrain();
            target.generateOre();
            target.generateWool();

            // should generate an exception
            target.tradeForDevCard();
        }

        [Test()]
        public void TestCanBuildRoad()
        {
            var target = new Player();
            Assert.IsFalse(target.canBuildRoad());

            target.incrementSettlements();
            target.generateBrick();
            target.generateLumber();

            Assert.IsTrue(target.canBuildRoad());
        }

        [Test()]
        public void TestCanBuildSettlement()
        {
            var target = new Player();
            Assert.IsFalse(target.canBuildSettlement());

            target.incrementSettlements();
            target.generateBrick();
            target.generateLumber();
            target.generateGrain();
            target.generateWool();

            Assert.IsTrue(target.canBuildSettlement());
        }

        [Test()]
        public void TestCanBuildCity()
        {
            var target = new Player();
            Assert.IsFalse(target.canBuildCity());

            target.incrementCities();
            target.generateGrain();
            target.generateOre();
            target.generateOre();

            Assert.IsTrue(target.canBuildCity());
        }

        [Test()]
        public void TestBuildRoad()
        {
            var target = new Player();

            target.incrementSettlements();
            target.generateBrick();
            target.generateLumber();

            target.buildRoad();

            Assert.AreEqual(0, target.getHand().getBrick());
            Assert.AreEqual(0, target.getHand().getLumber());
        }

        [Test()]
        public void TestBuildSettlement()
        {
            var target = new Player();

            target.incrementSettlements();
            target.generateBrick();
            target.generateLumber();
            target.generateGrain();
            target.generateWool();

            target.buildSettlement();

            Assert.AreEqual(0, target.getHand().getBrick());
            Assert.AreEqual(0, target.getHand().getLumber());
            Assert.AreEqual(0, target.getHand().getWool());
            Assert.AreEqual(0, target.getHand().getGrain());
        }

        [Test()]
        public void TestBuildCity()
        {
            var target = new Player();

            target.incrementCities();
            target.generateGrain();
            target.generateGrain();
            target.generateOre();

            target.buildCity();

            Assert.AreEqual(0, target.getHand().getOre());
            Assert.AreEqual(1, target.getHand().getGrain());
        }

        [Test()]
        public void TestGetRoadsPlayed()
        {
            var target = new Player();
            target.incrementCities();
            target.generateBrick();
            target.generateLumber();

            target.buildRoad();
            target.buildRoad();

            Assert.AreEqual(2, target.getRoadsPlayed());
        }

        [Test()]
        public void TestPlayDevCardOfEachType()
        {
            var world = new World(3, 0);

            var target = world.players[0];
            var target2 = world.players[1];

            target2.incrementCities();
            
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            target.incrementCities();
            
            for (int i = 0; i < 2; i++)
            {
                target.generateGrain();
                target.generateOre();
                target.generateWool();
            }
            
            for (int i = 0; i < 16; i++)
            {
                target.tradeForDevCard();
            }

            for (int i = 0; i < 2; i++)
            {
                target.generateGrain();
                target.generateOre();
                target.generateWool();
            }

            for (int i = 0; i < 9; i++)
            {
                target.tradeForDevCard();
            }

            target2.generateBrick();
            
            Assert.AreEqual(2, target2.playerHand.getBrick());

            Assert.AreEqual(25, target.playerHand.getDevCardCount());
            Assert.AreEqual(0, target.playerHand.getKnights());
            Assert.AreEqual(8, target.getPoints());
            Assert.AreEqual(0, target.playerHand.getBrick());
            Assert.AreEqual(0, target.playerHand.getLumber());
            Assert.AreEqual(0, target.getRoadsPlayed());

            target.playDevCard("knight", null, null);
            target.playDevCard("monopoly", "brick", null);
            target.playDevCard("yearOfPlenty", "brick", "lumber");
            target.playDevCard("victoryPoint", null, null);
            target.playDevCard("roadBuilder", null, null);

            Assert.AreEqual(20, target.playerHand.getDevCardCount());
            Assert.AreEqual(1, target.playerHand.getKnights());
            Assert.AreEqual(9, target.getPoints());
            Assert.AreEqual(3, target.playerHand.getBrick());
            Assert.AreEqual(1, target.playerHand.getLumber());
            Assert.AreEqual(2, target.getRoadsPlayed());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayKnightThrowsExceptionWhenPlayerHasNoKnights()
        {
            var target = new Player();
            target.playDevCard("knight", null, null);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayVictoryPointThrowsExceptionWhenPlayerHasNoVictoryPointCards()
        {
            var target = new Player();
            target.playDevCard("victoryPoint", null, null);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayMonopolyThrowsExceptionWhenPlayerHasNoMonopolyCards()
        {
            var target = new Player();
            target.playDevCard("monopoly", null, null);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayYearOfPlentyThrowsExceptionWhenPlayerHasNoYearOfPlentyCards()
        {
            var target = new Player();
            target.playDevCard("yearOfPlenty", null, null);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlayRoadBuilderThrowsExceptionWhenPlayerHasNoRoadBuilderCards()
        {
            var target = new Player();
            target.playDevCard("roadBuilder", null, null);
        }

    }
}
