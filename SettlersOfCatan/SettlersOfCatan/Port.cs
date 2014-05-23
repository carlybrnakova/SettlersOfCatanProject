using System;
using System.Collections.Generic;

namespace SettlersOfCatan
{
	public class Port
	{
		private String resourceType;
		private int tradeAmount;
		private List<Intersection> ints;

		public Port(String r, int amount)
		{
			this.resourceType = r;
			this.tradeAmount = amount;
			this.ints = new List<Intersection>(2);
		}

		public void addIntersection(Intersection i)
		{
			this.ints.Add(i);
		}

		public int getTradeAmount()
		{
			return this.tradeAmount;
		}

		public String getResourceType()
		{
			return this.resourceType;
		}

		public List<Intersection> getIntersections()
		{
			return this.ints;
		}
	}
}