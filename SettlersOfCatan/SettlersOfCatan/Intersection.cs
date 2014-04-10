using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SettlersOfCatan;

namespace SettlersOfCatan
{
    public class Intersection
    {
        public List<Connection> connections = new List<Connection>(3);
        public List<Hex> resourceHexes = new List<Hex>(3);
        private Point coord;
        private IEnums.GAME_PIECE currentPiece = IEnums.GAME_PIECE.NONE;
        public IEnums.PLAYER_COLOR color;

        public Intersection(Point p)
        {
            coord = p;
            for (int i = 0; i < connections.Capacity; i++)
            {
                connections.Add(new Connection(null));
            }
        }

        public void build(IEnums.GAME_PIECE piece)
        {
            currentPiece = piece;
        }

        public bool hasABuilding()
        {
            if (currentPiece != IEnums.GAME_PIECE.NONE) return true;
            else return false;
        }

        public bool areAllThreeConnectionsAvailableToBuild()
        {
            bool available = true;
            for (int i = 0; i < connections.Count; i++)
            {
                if (connections[i].getIntersection() != null)
                    available = available && !(connections[i].getIntersection().hasABuilding());
            }
            return available;
        }

        public bool canBuildAtIntersection()
        {
            bool canBuild;
            if (this.hasABuilding()) // Cannot build here if this intersection has a building
            {
                canBuild = false;
            }
            else if (this.areAllThreeConnectionsAvailableToBuild()) // We can build here because nobody around already built something!
            {
                canBuild = true;
            }
            else // There is a conflict because a surrounding intersection already has a building
            {
                canBuild = false;
            }
            return canBuild;
        }






       



    }
}
