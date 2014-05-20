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

			// first player
			Assert.AreEqual("bob", target.currentPlayer.getName());
			target.endTurn();
			Assert.AreEqual("joe", target.currentPlayer.getName());
			target.endTurn();
			Assert.AreEqual("Anne", target.currentPlayer.getName());

			// should set current player back to bob
			target.endTurn();
			Assert.AreEqual("bob", target.currentPlayer.getName());
		}

		[Test()]
		public void TestDiceRolling()
		{
			World world = new World();
			world.rollDice();
			Assert.GreaterOrEqual(world.getRollNumber(), 2);
			Assert.LessOrEqual(world.getRollNumber(), 12);
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

            w.currentPlayer.playerHand.modifyBrick(1);
            w.currentPlayer.playerHand.modifyGrain(1);
            w.currentPlayer.playerHand.modifyWool(1);
            w.currentPlayer.playerHand.modifyOre(1);
            w.currentPlayer.playerHand.modifyLumber(1);

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

            w.currentPlayer.playerHand.modifyBrick(1);
            w.currentPlayer.playerHand.modifyGrain(1);
            w.currentPlayer.playerHand.modifyWool(1);
            w.currentPlayer.playerHand.modifyOre(1);
            w.currentPlayer.playerHand.modifyLumber(1);

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
        }
    }
}