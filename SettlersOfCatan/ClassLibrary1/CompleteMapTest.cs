using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;
using System.Reflection;

namespace ClassLibrary1
{
	internal class CompleteMapTest
	{
		[Test()]
		public void TestCompleteMapInitializesProperly()
		{
			var target = new CompleteMap();
			Assert.NotNull(target);
		}

		[Test()]
		public void TestMapsAreCorrectSize()
		{
			var target = new CompleteMap();
			Assert.AreEqual(66, target.getIslandMap().map.Length);
			Assert.AreEqual(25, target.getHexMap().map.Length);
		}
	}
}