using System;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class MonopolyForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		private World world;
		private GameScreen gameScreen;
		private Player current;

		public MonopolyForm(World world, GameScreen gs)
		{
			InitializeComponent();
			this.world = world;
			this.gameScreen = gs;
			this.current = this.world.currentPlayer;

			localize();
		}

		private void localize()
		{
			this.Text = rm.GetString(language + "Monopoly");
			this.MonopolyLabel.Text = rm.GetString(language + "MonopolyLabel");
			this.MonopolyButton.Text = rm.GetString(language + "Submit");

			this.MonopolyComboBox.Text = rm.GetString(language + "Resource");
			this.MonopolyComboBox.Items[0] = rm.GetString(language + "Ore");
			this.MonopolyComboBox.Items[1] = rm.GetString(language + "Wool");
			this.MonopolyComboBox.Items[2] = rm.GetString(language + "Lumber");
			this.MonopolyComboBox.Items[3] = rm.GetString(language + "Grain");
			this.MonopolyComboBox.Items[4] = rm.GetString(language + "Brick");
		}

		private void MonopolyButton_Click(object sender, EventArgs e)
		{
			string resource1 = this.MonopolyComboBox.SelectedItem.ToString();
			this.current.playDevCard("monopoly", resource1, null);
			this.gameScreen.updateResourceLabels();
			this.gameScreen.updateDevelopmentCards();
			this.Dispose();
		}
	}
}