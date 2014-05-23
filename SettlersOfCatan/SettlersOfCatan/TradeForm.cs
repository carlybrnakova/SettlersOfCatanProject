using System;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class TradeForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		private World world;
		public GameScreen gameScreen;
		private Player currentPlayer;
		private int currentPlayerNumber;
		private Player nextPlayer1;
		private Player nextPlayer2;
		private int currentPlayerOre;
		private int currentPlayerWool;
		private int currentPlayerGrain;
		private int currentPlayerLumber;
		private int currentPlayerBrick;
		private int player1Ore;
		private int player1Wool;
		private int player1Grain;
		private int player1Lumber;
		private int player1Brick;
		private int player2Ore;
		private int player2Wool;
		private int player2Grain;
		private int player2Lumber;
		private int player2Brick;
		private bool nextPlayer1Checked;
		private bool nextPlayer2Checked;

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
			localize();
			updateCurrentPlayerNameLabel();
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
			if (this.nextPlayer1Checked)
			{
				this.currentPlayer.proposeTrade(this.nextPlayer1,
					new int[]
					{
						this.currentPlayerOre, this.currentPlayerWool, this.currentPlayerLumber, this.currentPlayerGrain,
						this.currentPlayerBrick
					},
					new int[] {this.player1Ore, this.player1Wool, this.player1Lumber, this.player1Grain, this.player1Brick});
                if (!(nextPlayer1 is AI_Player))
                {
                    AcceptTradeForm acceptTradeForm = new AcceptTradeForm(this);
                    acceptTradeForm.Show();
                }
			}
			if (this.nextPlayer2Checked)
			{
				this.currentPlayer.proposeTrade(this.nextPlayer2,
					new int[]
					{
						this.currentPlayerOre, this.currentPlayerWool, this.currentPlayerLumber, this.currentPlayerGrain,
						this.currentPlayerBrick
					},
					new int[] {this.player2Ore, this.player2Wool, this.player2Lumber, this.player2Grain, this.player2Brick});
                if (!(nextPlayer2 is AI_Player))
                {
                    AcceptTradeForm acceptTradeForm = new AcceptTradeForm(this);
                    acceptTradeForm.Show();
                }
			}
		}

		private void localize()
		{
			this.Text = this.ProposeTheTradeButton.Text = rm.GetString(language + "ProposeTrade");
			this.PlayersCategoryLabel.Text = rm.GetString(language + "Players");
			this.ResourcesCategoryLabel.Text = rm.GetString(language + "Materials");
			this.OreCategoryLabel.Text = rm.GetString(language + "Ore");
			this.WoolCategoryLabel.Text = rm.GetString(language + "Wool");
			this.BrickCategoryLabel.Text = rm.GetString(language + "Brick");
			this.LumberCategoryLabel.Text = rm.GetString(language + "Lumber");
			this.GrainCategoryLabel.Text = rm.GetString(language + "Grain");
		}

		public void makeTrade()
		{
			try
			{
				currentPlayer.makeTrade();
				this.gameScreen.updateResourceLabels();
			}
			catch (ArgumentException e)
			{
				DialogResult num = MessageBox.Show(e.Message,
					rm.GetString(language + "InsufficientResources"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
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