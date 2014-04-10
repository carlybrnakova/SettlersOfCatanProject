using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SettlersOfCatan
{
    public class World
    {
        public Player currentPlayer;
        private int currentPlayerNumber;
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
            players.Add(new Player("bob", Color.Red, this));
            players.Add(new Player("joe", Color.Blue, this));
            players.Add(new Player("Anne", Color.Green, this));

            /*
            for (int i = 0; i < humans; i++)
            {
                Player p = new Player
                players.Add(new Player());
            }
            for (int i = 0; i < computers; i++)
            {
                //players.Add(new Computer());
            }
             */
            currentPlayer = this.players[0];
        }

        public void endTurn()
        {
            if (currentPlayerNumber < this.players.Count()-1)
            {
                currentPlayerNumber++;
            }
            else
                currentPlayerNumber = 0;
            currentPlayer = this.players[currentPlayerNumber];
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
