using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Reflection;
using SettlersOfCatan;

namespace ClassLibrary1
{
    class TradeFormTest
    {
        World world = new World(3, 0);
        GameScreen gameScreen = new GameScreen();

        [Test()]
        public void TestTradeFormInitializesCorrectly()
        {
            var target = new TradeForm(world, gameScreen);
            Assert.NotNull(target);
        }

        [Test()]
        public void TestTradeFormSetsFieldsCorrectly()
        {
            var target = new TradeForm(world, gameScreen);
            Assert.NotNull(typeof(TradeForm).GetField("world", BindingFlags.Instance | BindingFlags.NonPublic));
            Assert.NotNull(typeof(TradeForm).GetField("gameScreen", BindingFlags.Instance | BindingFlags.NonPublic));
            Assert.NotNull(typeof(TradeForm).GetField("currentPlayerNumber", BindingFlags.Instance | BindingFlags.NonPublic));
            Assert.NotNull(typeof(TradeForm).GetField("currentPlayer", BindingFlags.Instance | BindingFlags.NonPublic));
        }

        [Test()]
        public void TestTradeFormMakeTrade()
        {
            var target = new TradeForm(world, gameScreen);
            target.makeTrade();
        }
    }
}
