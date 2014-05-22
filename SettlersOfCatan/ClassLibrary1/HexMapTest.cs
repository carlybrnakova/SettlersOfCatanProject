using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;
using System.Reflection;

namespace ClassLibrary1
{
	internal class HexMapTest
	{
		[Test()]
		public void TestHexMapInitializesProperly()
		{
			var target = new HexMap();
			Assert.NotNull(target);
		}

		[Test()]
		public void TestHexMapIsCorrectSize()
		{
			var target = new HexMap();
			Assert.AreEqual(25, target.map.Length);
		}
	}
}