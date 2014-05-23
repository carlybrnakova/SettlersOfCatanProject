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
	public class PortTest
	{
		[Test()]
		public void TestThatPortAddsIntersection()
		{
			var port = new Port("Ore", 2);
			var intersection = new Intersection(new Point(3, 3), port);
			port.addIntersection(intersection);
			Assert.AreEqual(intersection, port.getIntersections().ElementAt(0));
		}

		[Test()]
		public void TestGetTradeAmount()
		{
			var port = new Port("Ore", 2);
			var port1 = new Port("Anything", 3);
			Assert.AreEqual(2, port.getTradeAmount());
			Assert.AreEqual(3, port1.getTradeAmount());
		}

		[Test()]
		public void TestGetResourceType()
		{
			var port = new Port("Ore", 2);
			var port1 = new Port("Anything", 3);
			Assert.AreEqual("Ore", port.getResourceType());
			Assert.AreEqual("Anything", port1.getResourceType());
		}
	}
}