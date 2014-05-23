using System;
using System.Data.SqlTypes;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class YearOfPlentyForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		private World world;
		private GameScreen gameScreen;
		private Player current;

		public YearOfPlentyForm(World world, GameScreen gs)
		{
			InitializeComponent();
			this.world = world;
			this.gameScreen = gs;
			this.current = this.world.currentPlayer;

			localize();
		}

		private void localize()
		{
			this.Text = rm.GetString(language + "YearOfPlenty");
			this.YearOfPlentyLabel.Text = rm.GetString(language + "PickTwoResources");
			this.YearOfPlentyComboBox1.Text = rm.GetString(language + "Resource") + " 1";
			this.YearOfPlentyComboBox2.Text = rm.GetString(language + "Resource") + " 2";
			this.YearOfPlentyComboBox1.Items[0] = this.YearOfPlentyComboBox2.Items[0] = rm.GetString(language + "Ore");
			this.YearOfPlentyComboBox1.Items[1] = this.YearOfPlentyComboBox2.Items[1] = rm.GetString(language + "Wool");
			this.YearOfPlentyComboBox1.Items[2] = this.YearOfPlentyComboBox2.Items[2] = rm.GetString(language + "Lumber");
			this.YearOfPlentyComboBox1.Items[3] = this.YearOfPlentyComboBox2.Items[3] = rm.GetString(language + "Grain");
			this.YearOfPlentyComboBox1.Items[4] = this.YearOfPlentyComboBox2.Items[4] = rm.GetString(language + "Brick");
			this.YearOfPlentyButton.Text = rm.GetString(language + "Submit");
		}

		private void YearOfPlentyButton_Click(object sender, EventArgs e)
		{
			string resource1 = this.YearOfPlentyComboBox1.SelectedItem.ToString();
			string resource2 = this.YearOfPlentyComboBox2.SelectedItem.ToString();
			this.current.playDevCard("yearOfPlenty", resource1, resource2);
			this.gameScreen.updateResourceLabels();
			this.gameScreen.updateDevelopmentCards();
			this.Dispose();
		}
	}
}