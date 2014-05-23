using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettlersOfCatan;
using System.Drawing;

namespace SettlersOfCatan
{
	public class Connection
	{
		public Intersection connectedToLeftOrTop;
        public Intersection connectedToRightOrBot;
		private Color roadColor;
		private bool built;

		public Connection(Intersection rightOrBot, Intersection leftOrTop)
		{
            connectedToRightOrBot = rightOrBot;
			connectedToLeftOrTop = leftOrTop;
			built = false;
			roadColor = Color.White;
		}

		public Intersection getIntersectionLeftOrTop()
		{
			return connectedToLeftOrTop;
		}

        public Intersection getIntersectionRightOrBot()
		{
			return connectedToRightOrBot;
		}

		public void setRoadColor(Color c)
		{
			this.roadColor = c;
		}

		public Color getRoadColor()
		{
			return roadColor;
		}

		public void buildRoad(Color c)
		{
			this.built = true;
			this.roadColor = c;
		}

		public bool isBuilt()
		{
			return built;
		}
	}
}