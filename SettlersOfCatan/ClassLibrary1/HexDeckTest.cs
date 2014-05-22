using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;
using System.Reflection;

namespace ClassLibrary1
{
	internal class HexDeckTest
	{
		private Color GRAIN_COLOR = Color.Gold;
		private Color DESERT_COLOR = Color.Wheat;
		private Color LUMBER_COLOR = Color.ForestGreen;
		private Color ORE_COLOR = Color.Gray;
		private Color WOOL_COLOR = Color.PaleGoldenrod;
		private Color BRICK_COLOR = Color.Chocolate;

		[Test()]
		public void TestHexDeckInitializesProperly()
		{
			var target = new HexDeck();
			Assert.NotNull(target);
		}

		[Test()]
		public void TestHexDeckIsCorrectSize()
		{
			var target = new HexDeck();
			Assert.AreEqual(19, target.Count);
		}
	}
}