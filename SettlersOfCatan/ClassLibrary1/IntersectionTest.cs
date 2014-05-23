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

public class IntersectionTest
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

	[Test()]
	public void TestThatPlayerCannotBuildSettlementIfThereIsNoRoadLeadingThere()
	{
		World world = new World(3, 0);
		var player = new Player("annie", Color.Pink, world);
		Assert.False(world.getMap().getIslandMap().getIntAtIndex(3, 3).canBuildAtIntersection(player, 5));
	}

	[Test()]
	public void TestThatIntersectionCanDetemineWhenPlayerHasExistingConnection()
	{
		var world = new World(3, 0);
		Player player = new Player("sam", Color.Turquoise, world);
		player.getHand().incrementAllResources(3);
		world.addPlayer(player);
		world.setCurrentPlayer(player.getName());
		Assert.AreNotEqual(Color.White, world.tryToBuildAtIntersection(new Point(2, 4)));
		Assert.AreNotEqual(Color.White, world.roadButtonClicked(new Point(4, 4)));
		Assert.True(world.getMap().getIslandMap().getIntAtIndex(new Point(2, 5)).playerHasExistingConnection(Color.Turquoise));
	}

	[Test()]
	public void TestIfIntersectionHasPort()
	{
		var target = new Intersection(new Point(4, 4));
		Assert.False(target.hasPort());

		target = new Intersection(new Point(4, 4), new Port("Ore", 2));
		Assert.True(target.hasPort());
	}
}

}