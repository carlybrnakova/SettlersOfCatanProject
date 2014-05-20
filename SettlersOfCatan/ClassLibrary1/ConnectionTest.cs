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
	internal class ConnectionTest
	{
		[Test()]
		public void TestThatRoadColorGetsSet()
		{
			Intersection i = new Intersection(new Point(1, 1));
			Connection c = new Connection(i);
			c.setRoadColor(Color.HotPink);
			Assert.AreEqual(Color.HotPink, c.getRoadColor());
		}
	}
}