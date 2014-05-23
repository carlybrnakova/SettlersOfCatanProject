using System;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class RemoveCardsForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		private Player player;
		private GameScreen gameScreen;
		private Hand hand;
		private int numberToRemove;
		private bool canDispose = true;

		public RemoveCardsForm(Player p, GameScreen gs)
		{
			this.player = p;
			this.gameScreen = gs;
			this.hand = p.getHand();
			InitializeComponent();
			updateLabels();
			updateComboBoxes();
		}

		private void updateLabels()
		{
			int totalCards = this.hand.getResources();
			this.numberToRemove = (int) Math.Floor((double) totalCards/2);

			string name = this.player.getName();
			string numberOfCardsInHandString = totalCards.ToString() + " " + rm.GetString(language + "Cards") + ", ";
			string amountToRemoveString = this.numberToRemove.ToString() + " " + rm.GetString(language + "Cards") + ".";

			this.PlayerNameLabel.Text = name;
			this.NumberOfCardsInHandLabel.Text = numberOfCardsInHandString;
			this.AmountToRemoveLabel.Text = amountToRemoveString;
			localize();
		}

		private void localize()
		{
			this.Text = rm.GetString(language + "RemoveCardsTitle");
			this.InstructionLabel.Text = rm.GetString(language + "InstructionLabel");
			this.RemoveInstructionLabel.Text = rm.GetString(language + "RemoveInstructionLabel");
			this.OreLabel.Text = rm.GetString(language + "Ore");
			this.WoolLabel.Text = rm.GetString(language + "Wool");
			this.GrainLabel.Text = rm.GetString(language + "Grain");
			this.BrickLabel.Text = rm.GetString(language + "Brick");
			this.LumberLabel.Text = rm.GetString(language + "Lumber");
			this.RemoveCardsButton.Text = rm.GetString(language + "Remove");
			this.OreComboBox.Text =
				this.WoolComboBox.Text =
					this.LumberComboBox.Text =
						this.GrainComboBox.Text = this.BrickComboBox.Text = rm.GetString(language + "RemoveAmount");
		}

		private void updateComboBoxes()
		{
			for (int i = 0; i <= this.hand.getOre(); i++)
			{
				this.OreComboBox.Items.Add(i);
			}

			for (int i = 0; i <= this.hand.getBrick(); i++)
			{
				this.BrickComboBox.Items.Add(i);
			}

			for (int i = 0; i <= this.hand.getWool(); i++)
			{
				this.WoolComboBox.Items.Add(i);
			}

			for (int i = 0; i <= this.hand.getLumber(); i++)
			{
				this.LumberComboBox.Items.Add(i);
			}

			for (int i = 0; i <= this.hand.getGrain(); i++)
			{
				this.GrainComboBox.Items.Add(i);
			}
		}

		private void RemoveCardsButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (checkAmountIsCorrect())
				{
					this.gameScreen.updateResourceLabels();
					this.Close();
				}
			}
			catch (ArgumentException ex)
			{
				this.canDispose = false;
				DialogResult num = MessageBox.Show(ex.Message,
					rm.GetString(language + "WrongNumberOfCards"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				//this.canDispose = false;
			}
		}

		private bool checkAmountIsCorrect()
		{
			if (checkComboBoxesUsed())
			{
				int grainToTrade = Convert.ToInt32(this.GrainComboBox.SelectedItem);
				int lumberToTrade = Convert.ToInt32(this.LumberComboBox.SelectedItem);
				int brickToTrade = Convert.ToInt32(this.BrickComboBox.SelectedItem);
				int woolToTrade = Convert.ToInt32(this.WoolComboBox.SelectedItem);
				int oreToTrade = Convert.ToInt32(this.OreComboBox.SelectedItem);

				if (grainToTrade + lumberToTrade + brickToTrade + woolToTrade + oreToTrade != this.numberToRemove)
				{
					throw new ArgumentException(rm.GetString(language + "WrongTradeIn") + this.numberToRemove.ToString() + "!");
				}

				tradeWithBank(grainToTrade, lumberToTrade, brickToTrade, woolToTrade, oreToTrade);
				return true;
			}
			else
			{
				DialogResult num = MessageBox.Show(rm.GetString(language + "ChooseEachResource"),
					rm.GetString(language + "AmountNotChosen"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				return false;
			}
		}

		private bool checkComboBoxesUsed()
		{
			return this.GrainComboBox.SelectedIndex > -1 && this.LumberComboBox.SelectedIndex > -1 &&
			       this.BrickComboBox.SelectedIndex > -1 && this.WoolComboBox.SelectedIndex > -1 &&
			       this.OreComboBox.SelectedIndex > -1;
		}

		private void tradeWithBank(int grainAmount, int lumberAmount, int brickAmount, int woolAmount, int oreAmount)
		{
			this.player.transferGrain(grainAmount);
			this.player.transferLumber(lumberAmount);
			this.player.transferBrick(brickAmount);
			this.player.transferWool(woolAmount);
			this.player.transferOre(oreAmount);
		}

		private void RemoveCardsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.canDispose)
			{
				this.gameScreen.updateResourceLabels();
				e.Cancel = false;
			}
			else
			{
				e.Cancel = true;
			}
		}
	}
}