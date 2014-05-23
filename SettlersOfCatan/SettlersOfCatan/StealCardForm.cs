using System;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class StealCardForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		private World world;
		private Hex robberHex;
		private object playerToStealFrom;

		private bool canDispose = false;

		public StealCardForm(World world)
		{
			this.world = world;
			this.robberHex = world.getRobberHex();
			InitializeComponent();
			updateLabels();
		}

		private void updateLabels()
		{
			int owners = world.getRobberHex().owners.Count;

			for (int i = 0; i < owners; i++)
			{
				if (this.world.getRobberHex().owners[i].getHand().getResources() > 0)
				{
					this.PlayerNameComboBox.Items.Insert(i, world.getRobberHex().owners[i].getName());
				}
			}

			if (this.PlayerNameComboBox.Items.Count == 0)
			{
				this.PlayerNameComboBox.Items.Insert(0, rm.GetString(language + "Nobody"));
			}

			this.Text = rm.GetString(language + "StealCardTitle");
			this.PlayerNameComboBox.Text = rm.GetString(language + "StealCardCombo");
			this.StealCardButton.Text = rm.GetString(language + "Steal");
		}

		private void StealCardButton_Click(object sender, EventArgs e)
		{
			if (this.PlayerNameComboBox.SelectedIndex > -1)
			{
				this.playerToStealFrom = this.PlayerNameComboBox.SelectedItem;
				if (checkChoice())
				{
					this.Dispose();
				}
			}
			else
			{
				DialogResult num = MessageBox.Show(rm.GetString(language + "MustChoosePlayer"),
	rm.GetString(language + "PickSomeone"),
	MessageBoxButtons.OK,
	MessageBoxIcon.Exclamation);
			}
		}

		private bool checkChoice()
		{
			string playerName = (string) this.playerToStealFrom;
			int owners = this.robberHex.owners.Count;

			if (playerName.Equals(rm.GetString(language + "Nobody")))
			{
				this.canDispose = true;
				return true;
			}

			for (int i = 0; i < owners; i++)
			{
				if (this.robberHex.owners[i].getName().Equals(playerName))
				{
					string stolenResource = this.robberHex.owners[i].rob();
					if (stolenResource == "none")
					{
						this.canDispose = true;
						return true;
					}
					else
					{
						this.world.currentPlayer.playerHand.modifyResources(stolenResource, 1);
						this.canDispose = true;
						return true;
					}
				}
			}
			return false;
		}

		private void StealCardsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.canDispose)
			{
				this.Dispose();
			}
			else
			{
				e.Cancel = true;
			}
		}

	}
}
