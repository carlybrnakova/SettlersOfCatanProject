using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;
using System.Reflection;

namespace ClassLibrary1
{
	internal class HexTest
	{
		private Color GRAIN_COLOR = Color.Gold;
		private Color DESERT_COLOR = Color.Wheat;
		private Color LUMBER_COLOR = Color.ForestGreen;
		private Color ORE_COLOR = Color.Gray;
		private Color WOOL_COLOR = Color.PaleGoldenrod;
		private Color BRICK_COLOR = Color.Chocolate;

		[Test()]
		public void TestHexInitializesProperly()
		{
			var target = new Hex("lumber", LUMBER_COLOR);
			Assert.NotNull(target);
		}

		[Test()]
		public void TestThatHexSetsFields()
		{
			var target = new Hex("wool", GRAIN_COLOR);
			Assert.NotNull(target.getResourceType());
			Assert.NotNull(target.getColor());
		}

		[Test()]
		public void TestHexHasCorrectResourceType()
		{
			var target = new Hex("ore", ORE_COLOR);
			Assert.AreEqual("ore", target.getResourceType());
		}

		[Test()]
		public void TestHexHasCorrectColor()
		{
			var target = new Hex("lumber", LUMBER_COLOR);
			Assert.AreEqual(LUMBER_COLOR, target.getColor());
		}

		[Test()]
		public void TestHexSetsToken()
		{
			var target = new Hex("brick", BRICK_COLOR);
			target.setToken(5);
			Assert.NotNull(typeof (Hex).GetField("token", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[Test()]
		public void TestHexSetsTokenCorrectly()
		{
			var target = new Hex("brick", BRICK_COLOR);
			target.setToken(5);
			Assert.AreEqual(5, target.getToken());
		}
	}
}