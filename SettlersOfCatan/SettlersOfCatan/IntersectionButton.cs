using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SettlersOfCatan
{
    public class IntersectionButton : Button
    {
        public Point coordinates;

        public IntersectionButton(int x, int y)
        {
            this.coordinates = new Point(x, y);
        }

        public Point getCoords()
        {
            return this.coordinates;
        }
    }

    public class RoadButton : Button
    {
        public Point coordinates;

        public RoadButton(int x, int y)
        {
            this.coordinates = new Point(x, y);
        }

        public Point getCoords()
        {
            return this.coordinates;
        }


    }
}
