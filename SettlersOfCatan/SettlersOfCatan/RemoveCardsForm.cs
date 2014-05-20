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
	public partial class RemoveCardsForm : Form
	{
		private Player player;
		private Hand hand;
		private int numberToRemove;

		public RemoveCardsForm(Player p)
		{
			this.player = p;
			this.hand = p.getHand();
			InitializeComponent();
			updateLabels();
			updateComboBoxes();
		}

		private void updateLabels()
		{
			int totalCards = this.hand.getResources();
			this.numberToRemove = (int)Math.Floor((double)totalCards/2);

			string numberOfCardsInHandString = totalCards.ToString() + " cards, ";
			string amountToRemoveString = this.numberToRemove.ToString() + " cards.";

			this.NumberOfCardsInHandLabel.Text = numberOfCardsInHandString;
			this.AmountToRemoveLabel.Text = amountToRemoveString;
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
				checkAmountIsCorrect();
				this.Dispose();
			}
			catch (ArgumentException ex)
			{
				DialogResult num = MessageBox.Show(ex.Message,
	"Wrong Number of Cards Removed",
	MessageBoxButtons.OK,
	MessageBoxIcon.Exclamation);
			}

		}

		private void checkAmountIsCorrect()
		{
			if (checkComboBoxesUsed())
			{

				int grainToTrade = Convert.ToInt32(this.GrainComboBox.SelectedText);
				int lumberToTrade = Convert.ToInt32(this.LumberComboBox.SelectedText);
				int brickToTrade = Convert.ToInt32(this.BrickComboBox.SelectedText);
				int woolToTrade = Convert.ToInt32(this.WoolComboBox.SelectedText);
				int oreToTrade = Convert.ToInt32(this.OreComboBox.SelectedText);

				if (grainToTrade + lumberToTrade + brickToTrade + woolToTrade + oreToTrade != this.numberToRemove)
				{
					throw new ArgumentException("Make sure your trade in amounts add up to " + this.numberToRemove.ToString());
				}

				tradeWithBank(grainToTrade, lumberToTrade, brickToTrade, woolToTrade, oreToTrade);
			}
			else
			{
				DialogResult num = MessageBox.Show("You must choose a number to remove for each resource.",
"Amount Not Chosen",
MessageBoxButtons.OK,
MessageBoxIcon.Exclamation);
			}
		}

		private bool checkComboBoxesUsed()
		{
			return this.GrainComboBox.SelectedIndex > -1 && this.LumberComboBox.SelectedIndex > -1 && this.BrickComboBox.SelectedIndex > -1 && this.WoolComboBox.SelectedIndex > -1 && this.OreComboBox.SelectedIndex > -1;
		}

		private void tradeWithBank(int grainAmount, int lumberAmount, int brickAmount, int woolAmount, int oreAmount)
		{
			this.player.transferGrain(grainAmount);
			this.player.transferLumber(lumberAmount);
			this.player.transferBrick(brickAmount);
			this.player.transferWool(woolAmount);
			this.player.transferOre(oreAmount);
		}
	}
}
