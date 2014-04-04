using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlersOfCatan
{
    public class World
    {
        private int currentPlayer;
        private List<Player> players;
        public Bank bank;

        public World()
        {
            bank = new Bank();
            players = new List<Player>();
        }

        public World(int humans, int computers)
        {
            bank = new Bank();
            players = new List<Player>();
            for (int i = 0; i < humans; i++)
            {
                players.Add(new Player());
            }
            for (int i = 0; i < computers; i++)
            {
                //players.Add(new Computer());
            }
            currentPlayer = 0;
        }

        private void endTurn()
        {
            if (currentPlayer < this.players.Count())
            {
                currentPlayer++;
            }
            else
                currentPlayer = 0;
        }

        private void checkWinner()
        {
            foreach (Player p in this.players){
                if (p.hasWonGame() == true){
                    //declare winner
                }
            }
        }
    }
}
