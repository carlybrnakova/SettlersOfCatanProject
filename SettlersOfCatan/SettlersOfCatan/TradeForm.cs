using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    public partial class TradeForm : Form
    {
        World world;
        GameScreen gameScreen;
        Player currentPlayer;
        int currentPlayerNumber;
        Player nextPlayer1;
        Player nextPlayer2;
        int currentPlayerOre;
        int currentPlayerWool;
        int currentPlayerGrain;
        int currentPlayerLumber;
        int currentPlayerBrick;
        int player1Ore;
        int player1Wool;
        int player1Grain;
        int player1Lumber;
        int player1Brick;
        int player2Ore;
        int player2Wool;
        int player2Grain;
        int player2Lumber;
        int player2Brick;
        bool nextPlayer1Checked;
        bool nextPlayer2Checked;

        public TradeForm(World world, GameScreen gameScreen)
        {
            this.world = world;
            this.gameScreen = gameScreen;
            this.currentPlayerNumber = this.world.currentPlayerNumber;
            this.currentPlayer = this.world.currentPlayer;

            int nextPlayerNumber = this.currentPlayerNumber + 1;
            if (nextPlayerNumber == this.world.players.Count())
            {
                nextPlayerNumber = 0;
            }
            this.nextPlayer1 = world.players[nextPlayerNumber];
            nextPlayerNumber++;
            if (nextPlayerNumber == this.world.players.Count())
            {
                nextPlayerNumber = 0;
            }
            this.nextPlayer2 = world.players[nextPlayerNumber];

            nextPlayer1Checked = false;
            nextPlayer2Checked = false;
            InitializeComponent();
            NextPlayer1Label.Text = this.nextPlayer1.getName();
            NextPlayer2Label.Text = this.nextPlayer2.getName();
        }

        private void updateCurrentPlayerNameLabel()
        {
            CurrentPlayerNameLabel.Text = this.world.currentPlayer.getName().ToString();
        }

        private void ProposeTheTradeButton_Click(object sender, EventArgs e)
        {
            this.currentPlayerOre = Convert.ToInt32(CurrentPlayerOreTextBox.Text);
            this.currentPlayerWool = Convert.ToInt32(CurrentPlayerWoolTextBox.Text);
            this.currentPlayerGrain = Convert.ToInt32(CurrentPlayerGrainTextBox.Text);
            this.currentPlayerLumber = Convert.ToInt32(CurrentPlayerLumberTextBox.Text);
            this.currentPlayerBrick = Convert.ToInt32(CurrentPlayerBrickTextBox.Text);
            this.player1Ore = Convert.ToInt32(NextPlayer1OreTextBox.Text);
            this.player1Wool = Convert.ToInt32(NextPlayer1WoolTextBox.Text);
            this.player1Grain = Convert.ToInt32(NextPlayer1GrainTextBox.Text);
            this.player1Lumber = Convert.ToInt32(NextPlayer1LumberTextBox.Text);
            this.player1Brick = Convert.ToInt32(NextPlayer1BrickTextBox.Text);
            this.player2Ore = Convert.ToInt32(NextPlayer2OreTextBox.Text);
            this.player2Wool = Convert.ToInt32(NextPlayer2WoolTextBox.Text);
            this.player2Grain = Convert.ToInt32(NextPlayer2GrainTextBox.Text);
            this.player2Lumber = Convert.ToInt32(NextPlayer2LumberTextBox.Text);
            this.player2Brick = Convert.ToInt32(NextPlayer2BrickTextBox.Text);
            if (this.nextPlayer1Checked){
                this.currentPlayer.proposeTrade(this.nextPlayer1, new int[] {this.currentPlayerOre, this.currentPlayerWool, this.currentPlayerLumber, this.currentPlayerGrain, this.currentPlayerBrick}, new int[]{this.player1Ore, this.player1Wool, this.player1Lumber, this.player1Grain, this.player1Brick});
                AcceptTradeForm acceptTradeForm = new AcceptTradeForm(this);
                acceptTradeForm.Show();
            }
            if (this.nextPlayer2Checked)
            {
                this.currentPlayer.proposeTrade(this.nextPlayer2, new int[] { this.currentPlayerOre, this.currentPlayerWool, this.currentPlayerLumber, this.currentPlayerGrain, this.currentPlayerBrick }, new int[] { this.player2Ore, this.player2Wool, this.player2Lumber, this.player2Grain, this.player2Brick });
                AcceptTradeForm acceptTradeForm = new AcceptTradeForm(this);
                acceptTradeForm.Show();
            }
        }

        public void makeTrade()
        {
            currentPlayer.makeTrade();
            this.gameScreen.updateResourceLabels();
        }

        public void declineTrade()
        {
            currentPlayer.declineTrade();
        }

        private void NextPlayer1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            nextPlayer1Checked = !nextPlayer1Checked;
        }

        private void NextPlayer2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            nextPlayer2Checked = !nextPlayer2Checked;
        }
    }
}
