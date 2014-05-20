using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;

namespace ClassLibrary1
{
	internal class IntersectionTest
	{
		[Test()]
		public void TestThatIntersectionCanGetAndSetPlayerWhoOwnsIt()
		{
			Player player = new Player();
			Intersection intersection = new Intersection(new Point(2, 2));
			intersection.setPlayer(player);
			Assert.AreEqual(player, intersection.getPlayer());
		}

		[Test()]
		public void TestThatResourcesAreGeneratedBasedOnSettlementOrCity()
		{
			Intersection intersection = new Intersection(new Point(2, 2));
			Assert.AreEqual(0, intersection.getNumOfResourcesToGenerate());
			intersection.build(Global_Variables.GAME_PIECE.SETTLEMENT);
			Assert.AreEqual(1, intersection.getNumOfResourcesToGenerate());
			intersection.build(Global_Variables.GAME_PIECE.CITY);
			Assert.AreEqual(2, intersection.getNumOfResourcesToGenerate());
		}
	}
}