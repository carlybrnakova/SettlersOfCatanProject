using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Reflection;
using System.Collections.Generic;
using System.Drawing;

namespace ClassLibrary1
{
	internal class WorldTest
	{
		[Test()]
		public void TestWorldInitializesProperly()
		{
			var target = new World();
			Assert.NotNull(target);

			var target2 = new World(2, 2);
			Assert.NotNull(target2);
		}

		[Test()]
		public void TestConstructorWithoutParametersSetsFieldsCorrectly()
		{
			var target = new World();
			Assert.NotNull(target.bank);
			Assert.NotNull(target.players);
		}

		[Test()]
		public void TestConstructorWithParametersSetsFieldsCorrectly()
		{
			var target = new World(2, 2);
			Assert.True(target.bank.allResourcesMax());
			Assert.AreEqual(3, target.players.Count);
			Assert.AreEqual("bob", target.currentPlayer.getName());
		}

		[Test()]
		public void TestEndTurn()
		{
			var target = new World(3, 0);

		    //testing first round
			Assert.AreEqual("bob", target.currentPlayer.getName());
			target.endTurn();
			Assert.AreEqual("joe", target.currentPlayer.getName());
			target.endTurn();
			Assert.AreEqual("Anne", target.currentPlayer.getName());

			// testing second round
			target.endTurn();
			Assert.AreEqual("Anne", target.currentPlayer.getName());
            target.endTurn();
            Assert.AreEqual("joe", target.currentPlayer.getName());
            target.endTurn();
            Assert.AreEqual("bob", target.currentPlayer.getName());
            target.endTurn();
            
            //testing third round
            //player has not rolled
            Assert.AreEqual("bob", target.currentPlayer.getName());
            target.endTurn();
            Assert.AreEqual("bob", target.currentPlayer.getName());
            //playerhas rolled
            target.rollDice();
            target.endTurn();
            Assert.AreEqual("joe", target.currentPlayer.getName());
            target.rollDice();
            target.endTurn();
            Assert.AreEqual("Anne", target.currentPlayer.getName());
            target.rollDice();
            target.endTurn();
            Assert.AreEqual("bob", target.currentPlayer.getName());
		}

		[Test()]
		public void TestThatSettlementGetsBuild()
		{
			World world = new World(3, 0);
			Player player1 = new Player("Meeeeee!", Color.HotPink, world);
			world.addPlayer(player1);
			world.setCurrentPlayer(player1.getName());

			// Give player the resources needed for a settlement
			player1.getHand().modifyBrick(1);
			player1.getHand().modifyGrain(1);
			player1.getHand().modifyLumber(1);
			player1.getHand().modifyWool(1);
			Assert.AreEqual(Color.HotPink, world.tryToBuildAtIntersection(new Point(3, 3)));
			Assert.AreEqual(Global_Variables.GAME_PIECE.SETTLEMENT,
				world.getMap().getIslandMap().getIntAtIndex(3, 3).getPieceType());

			// Give player the resources needed for city
			player1.getHand().modifyOre(5);
			player1.getHand().modifyGrain(5);
			Assert.AreEqual(Color.Black, world.tryToBuildAtIntersection(new Point(3, 3)));
			Assert.AreEqual(Global_Variables.GAME_PIECE.CITY,
				world.getMap().getIslandMap().getIntAtIndex(3, 3).getPieceType());
		}

		[Test()]
		public void TestLargestArmyDoesNotGetSetIfNoOneHasLargestArmy()
		{
			var target = new World(3, 0);

			target.currentPlayer.playerHand.incrementKnightsPlayed();
			target.currentPlayer.playerHand.incrementKnightsPlayed();
			target.endTurn();

			Assert.AreEqual(0, target.largestArmySize);
			Assert.AreEqual(-1, target.largestArmyOwnerIndex);
		}

		[Test()]
		public void TestLargestArmyGetsSetIfNoOneHasLargestArmy()
		{
			var target = new World(3, 0);
			target.endTurn();

			// player 2
			for (int i = 0; i < 3; i++)
			{
				target.currentPlayer.playerHand.incrementKnightsPlayed();
			}

			target.endTurn();

			Assert.AreEqual(3, target.largestArmySize);
			Assert.AreEqual(1, target.largestArmyOwnerIndex);
			Assert.AreEqual(2, target.players[target.largestArmyOwnerIndex].getPoints());
			Assert.IsTrue(target.players[target.largestArmyOwnerIndex].hasLargestArmy);
		}

		[Test()]
		public void TestLargestArmyDoesNotGetSetWhenArmiesAreEqualSize()
		{
			var target = new World(3, 0);
			target.endTurn();

			// player 2
			for (int i = 0; i < 3; i++)
			{
				target.currentPlayer.playerHand.incrementKnightsPlayed();
			}

			target.endTurn();

			Assert.AreEqual(3, target.largestArmySize);
			Assert.AreEqual(1, target.largestArmyOwnerIndex);
			Assert.AreEqual(2, target.players[target.largestArmyOwnerIndex].getPoints());
			Assert.IsTrue(target.players[target.largestArmyOwnerIndex].hasLargestArmy);

			// player 3
			for (int i = 0; i < 3; i++)
			{
				target.currentPlayer.playerHand.incrementKnightsPlayed();
			}
			target.endTurn();

			Assert.AreEqual(3, target.largestArmySize);
			Assert.AreEqual(1, target.largestArmyOwnerIndex);
			Assert.AreEqual(2, target.players[target.largestArmyOwnerIndex].getPoints());
			Assert.IsTrue(target.players[target.largestArmyOwnerIndex].hasLargestArmy);
		}

		[Test()]
		public void TestLargestArmyGetsSetWhenArmyIsLarger()
		{
			var target = new World(3, 0);
			target.endTurn();

			// player 2
			for (int i = 0; i < 3; i++)
			{
				target.currentPlayer.playerHand.incrementKnightsPlayed();
			}

			target.endTurn();

			Assert.AreEqual(3, target.largestArmySize);
			Assert.AreEqual(1, target.largestArmyOwnerIndex);
			Assert.AreEqual(2, target.players[target.largestArmyOwnerIndex].getPoints());
			Assert.IsTrue(target.players[target.largestArmyOwnerIndex].hasLargestArmy);

			// player 3
			for (int i = 0; i < 4; i++)
			{
				target.currentPlayer.playerHand.incrementKnightsPlayed();
			}
			target.endTurn();

			Assert.AreEqual(4, target.largestArmySize);
			Assert.AreEqual(2, target.largestArmyOwnerIndex);
			Assert.AreEqual(0, target.players[target.largestArmyOwnerIndex - 1].getPoints());
			Assert.IsFalse(target.players[target.largestArmyOwnerIndex - 1].hasLargestArmy);
			Assert.AreEqual(2, target.players[target.largestArmyOwnerIndex].getPoints());
			Assert.IsTrue(target.players[target.largestArmyOwnerIndex].hasLargestArmy);
		}

		[Test()]
		public void TestLongestRoadDoesNotGetSetIfNoOneHasLongestRoad()
		{
			var target = new World(3, 0);

			for (int i = 0; i < 4; i++)
			{
				target.currentPlayer.incrementRoads();
			}
			target.endTurn();

			Assert.AreEqual(0, target.longestRoadSize);
			Assert.AreEqual(-1, target.longestRoadOwnerIndex);
		}

		[Test()]
		public void TestLongestRoadGetsSetIfNoOneHasLongestRoad()
		{
			var target = new World(3, 0);
			target.endTurn();

			// player 2
			for (int i = 0; i < 5; i++)
			{
				target.currentPlayer.incrementRoads();
			}

			target.endTurn();

			Assert.AreEqual(5, target.longestRoadSize);
			Assert.AreEqual(1, target.longestRoadOwnerIndex);
			Assert.AreEqual(2, target.players[target.longestRoadOwnerIndex].getPoints());
			Assert.IsTrue(target.players[target.longestRoadOwnerIndex].hasLongestRoad);
		}

		[Test()]
		public void TestLongestRoadDoesNotGetSetWhenRoadsAreEqualSize()
		{
			var target = new World(3, 0);
			target.endTurn();

			// player 2
			for (int i = 0; i < 5; i++)
			{
				target.currentPlayer.incrementRoads();
			}

			target.endTurn();

			Assert.AreEqual(5, target.longestRoadSize);
			Assert.AreEqual(1, target.longestRoadOwnerIndex);
			Assert.AreEqual(2, target.players[target.longestRoadOwnerIndex].getPoints());
			Assert.IsTrue(target.players[target.longestRoadOwnerIndex].hasLongestRoad);

			// player 3
			for (int i = 0; i < 5; i++)
			{
				target.currentPlayer.incrementRoads();
			}
			target.endTurn();

			Assert.AreEqual(5, target.longestRoadSize);
			Assert.AreEqual(1, target.longestRoadOwnerIndex);
			Assert.AreEqual(2, target.players[target.longestRoadOwnerIndex].getPoints());
			Assert.IsTrue(target.players[target.longestRoadOwnerIndex].hasLongestRoad);
		}

		[Test()]
		public void TestLongestRoadGetsSetWhenRoadIsLonger()
		{
			var target = new World(3, 0);
			target.endTurn();

			// player 2
			for (int i = 0; i < 5; i++)
			{
				target.currentPlayer.incrementRoads();
			}

			target.endTurn();

			Assert.AreEqual(5, target.longestRoadSize);
			Assert.AreEqual(1, target.longestRoadOwnerIndex);
			Assert.AreEqual(2, target.players[target.longestRoadOwnerIndex].getPoints());
			Assert.IsTrue(target.players[target.longestRoadOwnerIndex].hasLongestRoad);

			// player 3
			for (int i = 0; i < 6; i++)
			{
				target.currentPlayer.incrementRoads();
			}
			target.endTurn();

			Assert.AreEqual(6, target.longestRoadSize);
			Assert.AreEqual(2, target.longestRoadOwnerIndex);
			Assert.AreEqual(0, target.players[target.longestRoadOwnerIndex - 1].getPoints());
			Assert.IsFalse(target.players[target.longestRoadOwnerIndex - 1].hasLongestRoad);
			Assert.AreEqual(2, target.players[target.longestRoadOwnerIndex].getPoints());
			Assert.IsTrue(target.players[target.longestRoadOwnerIndex].hasLongestRoad);
		}

		/*
        [Test()]
        public void TestThatResourcesAreGenerated()
        {
            World w = new World(3, 0);
            Player player1 = new Player("Carly", Color.Purple, w);
           // Hand hand = new Hand();
            Intersection intersection = new Intersection(new Point(2, 2));
            intersection.setPlayer(player1);
            Hex hex1 = new Hex("grain", Color.Bisque);
            hex1.setToken(5);
            intersection.resourceHexes.Add(hex1);
            Hex hex2 = new Hex("lumber", Color.Green);
            hex2.setToken(5);
            intersection.resourceHexes.Add(hex2);

            intersection.build(Global_Variables.GAME_PIECE.SETTLEMENT);

            w.rollDice();
            Assert.AreEqual(1, intersection.getPlayer().getHand().getGrain());
            Assert.AreEqual(1, intersection.getPlayer().getHand().getLumber());

        }
         * */
        [Test()]
        public void TestRounds()
        {
            World w = new World(3, 0);
            int rounds = 0;
            for (int i = 0; i < 9; i++)
            {
                w.rollDice();
                w.endTurn();
                if (i % 3 == 0)
                {
                    rounds++;
                }
            }
            Assert.AreEqual(rounds, w.getNumberOfRoundsCompleted());
        }

        [Test()]
        public void TestTryToBuildAtIntersectionWithoutResources()
        {
            World w = new World(3, 0);
            Player player1 = new Player("Meeeeee!", Color.HotPink, w);
            w.addPlayer(player1);
            w.setCurrentPlayer(player1.getName());
            Color c = w.tryToBuildAtIntersection(new Point(3,3));
            Assert.AreEqual(Color.White, c);
        }

        [Test()]
        public void TestTryToBuildAtIntersectionWithoutSurroundingAreaClear()
        {
            World w = new World(3, 0);
            Player player1 = new Player("Meeeeee!", Color.HotPink, w);
            w.addPlayer(player1);
            w.setCurrentPlayer(player1.getName());

            w.currentPlayer.getHand().incrementAllResources(1);

            w.tryToBuildAtIntersection(new Point(3, 4));
            Color c = w.tryToBuildAtIntersection(new Point(3, 3));
            Assert.AreEqual(Color.White, c);
        }

        [Test()]
        public void TestTryToBuildCityAtIntersectionWithoutEnoughResources()
        {
            World w = new World(3, 0);
            Player player1 = new Player("Meeeeee!", Color.HotPink, w);
            w.addPlayer(player1);
            w.setCurrentPlayer(player1.getName());

            w.currentPlayer.getHand().incrementAllResources(1);

            w.tryToBuildAtIntersection(new Point(3, 4));
            Color c = w.tryToBuildAtIntersection(new Point(3, 4));
            Assert.AreEqual(Color.White, c);
        }

        [Test()]
        public void TestGenerateResourcesWithRequiredNumberOfRounds()
        {
            World w = new World(3, 0);
            int rounds = 0;
            for (int i = 0; i < 9; i++)
            {
                w.endTurn();
                if (i % 3 == 0)
                {
                    rounds++;
                }
            }
            Assert.AreEqual(rounds - 1, w.getNumberOfRoundsCompleted());
        }

        [Test()]
        public void TestCheckWinnerMethod()
        {
            World w = new World(3, 0);
            Player player1 = new Player("Meeeeee!", Color.HotPink, w);
            Player player2 = new Player("Meeeeee!2", Color.Red, w);
            w.addPlayer(player1);
            w.addPlayer(player2);
            Assert.IsFalse(w.checkWinner());
            player2.incrementPoints(20);
            Assert.IsTrue(w.checkWinner());
        }


        //still working on it
        [Test()]
        public void TestRoadButtonClicked()
        {
            World w = new World(3, 0);
            Player player1 = new Player("Meeeeee!", Color.HotPink, w);
            w.addPlayer(player1);
            w.setCurrentPlayer(player1.getName());
            Color C = w.roadButtonClicked(new Point(2, 2));
            //insufficiant resources
            Assert.AreEqual(Color.White, C);

            w.currentPlayer.getHand().incrementAllResources(1);
            w.currentPlayer.getHand().incrementAllResources(1);
            w.currentPlayer.getHand().incrementAllResources(1);
            w.currentPlayer.getHand().incrementAllResources(1);
            w.currentPlayer.getHand().incrementAllResources(1);

            //point without adjoining settlement
            C = w.roadButtonClicked(new Point(3, 2));
            Assert.AreEqual(Color.White, C);
            //even point with resources
            w.tryToBuildAtIntersection(new Point(0, 3));
            C = w.roadButtonClicked(new Point(0, 0));
            Assert.AreEqual(Color.HotPink, C);
            //odd point with resources
            w.tryToBuildAtIntersection(new Point(1, 5));
            C = w.roadButtonClicked(new Point(3, 2));
            Assert.AreEqual(Color.HotPink, C);
            //point that is not in the grid
            C = w.roadButtonClicked(new Point(50, 2));
            Assert.AreEqual(Color.White, C);
            //point that has not been initialized
            w.catanMap = null;
            C = w.roadButtonClicked(new Point(3, 2));
            Assert.AreEqual(Color.Black, C);
        }

        [Test()]
        public void testRollDice()
        {
            World w = new World(3, 0);
            Player player1 = new Player("Meeeeee!", Color.HotPink, w);
            w.addPlayer(player1);
            w.setCurrentPlayer(player1.getName());
            //test without completeing early rounds
            w.rollDice();
            Assert.IsFalse(w.currentPlayer.hasRolled);
            //test extra roll without completeing early rounds
            w.rollDice();
            Assert.IsFalse(w.currentPlayer.hasRolled);
            w.numOfCompletedRounds = 5;
            //test first roll after early rounds
            w.rollDice();
            Assert.IsTrue(w.currentPlayer.hasRolled);
            //test extra roll after early rounds
            w.rollDice();
            Assert.IsTrue(w.currentPlayer.hasRolled);
        }

        [Test()]
        public void testGetRollNumber()
        {
            World w = new World(3, 0);
            Player player1 = new Player("Meeeeee!", Color.HotPink, w);
            w.addPlayer(player1);
            w.setCurrentPlayer(player1.getName());
            //test getting roll number without rolling
            Assert.AreEqual(0, w.getRollNumber());
            w.numOfCompletedRounds = 5;
            //test getting roll number after rolling
            w.rollDice();
            Assert.IsTrue(w.getRollNumber() < 13 && w.getRollNumber() > 1);
        }

        [Test()]
        public void TestThatPlayerCanGetAllResources()
        {

        }
    }
}