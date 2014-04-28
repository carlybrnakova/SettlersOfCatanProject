using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Reflection;
using System.Collections.Generic;
using System.Drawing;

namespace ClassLibrary1
{
    class WorldTest
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
    }
}