using System;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class BankTradeForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		private World world;
		private GameScreen gameScreen;
		private Player current;

		public BankTradeForm(World world, GameScreen gs)
		{
			InitializeComponent();
			this.world = world;
			this.gameScreen = gs;
			this.current = this.world.currentPlayer;
			localize();
		}

		private void localize()
		{
			this.Text = rm.GetString(language + "TradeWithBank");
			this.BankTradePromptLabel.Text = rm.GetString(language + "BankPrompt");
			this.ResourceGainBankComboBox.Text = rm.GetString(language + "ResourceGain");
			this.ResourceTradeBankComboBox.Text = rm.GetString(language + "ResourceTrade"); ;
			this.ResourceGainBankComboBox.Items[0] = this.ResourceTradeBankComboBox.Items[0] = rm.GetString(language + "Ore");
			this.ResourceGainBankComboBox.Items[1] = this.ResourceTradeBankComboBox.Items[1] = rm.GetString(language + "Grain");
			this.ResourceGainBankComboBox.Items[2] = this.ResourceTradeBankComboBox.Items[2] = rm.GetString(language + "Wool");
			this.ResourceGainBankComboBox.Items[3] = this.ResourceTradeBankComboBox.Items[3] = rm.GetString(language + "Brick");
			this.ResourceGainBankComboBox.Items[4] = this.ResourceTradeBankComboBox.Items[4] = rm.GetString(language + "Lumber");
			this.SubmitBankTradeButton.Text = rm.GetString(language + "Submit");
		}

		private void SubmitBankTradeButton_Click(object sender, EventArgs e)
		{
			try
			{
				string trade = this.ResourceTradeBankComboBox.SelectedItem.ToString();
				string gain = this.ResourceGainBankComboBox.SelectedItem.ToString();
				this.current.tradeWithBank(trade, gain);
				this.gameScreen.updateResourceLabels();
				this.Dispose();
			}
			catch (ArgumentException ex)
			{
				DialogResult num = MessageBox.Show(ex.Message,
					rm.GetString(language + "InsufficientResources"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
		}
	}
}