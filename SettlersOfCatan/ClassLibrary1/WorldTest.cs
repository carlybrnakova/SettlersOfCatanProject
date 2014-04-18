using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Reflection;
using System.Collections.Generic;

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
            Assert.NotNull(typeof(World).GetField("players", BindingFlags.Instance | BindingFlags.NonPublic));
        }

        [Test()]
        public void TestConstructorWithParametersSetsFieldsCorrectly()
        {
            var target = new World(2, 2);
            Assert.True(target.bank.allResourcesMax());
            Assert.NotNull(typeof(World).GetField("players", BindingFlags.Instance | BindingFlags.NonPublic));
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
        public void TestCheckWinner()
        {
            
        }    
    }
}