using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;
using System.Reflection;

namespace ClassLibrary1
{
    class HexTest
    {

        private Color GRAIN_COLOR = Color.Gold;
        private Color DESERT_COLOR = Color.Wheat;
        private Color LUMBER_COLOR = Color.ForestGreen;
        private Color ORE_COLOR = Color.Gray;
        private Color WOOL_COLOR = Color.PaleGoldenrod;
        private Color BRICK_COLOR = Color.Orange;

        [Test()]
        public void TestHexInitializesProperly()
        {
            var target = new Hex("Forest", LUMBER_COLOR);
            Assert.NotNull(target);
        }

        [Test()]
        public void TestHexSetsFields()
        {
            var target = new Hex("Hills", GRAIN_COLOR);
            Assert.NotNull(typeof(Hex).GetField("type", BindingFlags.NonPublic | BindingFlags.Instance));
            Assert.NotNull(typeof(Hex).GetField("color", BindingFlags.NonPublic | BindingFlags.Instance).ToString());
        }
    }
}
