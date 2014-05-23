using System;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class AcceptTradeForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;
        private GameScreen gameScreen;

		private TradeForm TradeForm;

		public AcceptTradeForm(TradeForm tradeForm)
		{
			this.TradeForm = tradeForm;
            gameScreen = tradeForm.gameScreen;
			InitializeComponent();
			localize();
		}

		private void localize()
		{
			this.Text = rm.GetString(language + "AcceptFormTitle");
			this.AcceptTheTradeLabel.Text = rm.GetString(language + "AcceptTradePrompt");
			this.AcceptTradeButton.Text = rm.GetString(language + "AcceptTradeButton");
			this.DeclineTradeButton.Text = rm.GetString(language + "DeclineTradeButton");
		}

		private void AcceptTradeButton_Click(object sender, EventArgs e)
		{
			this.TradeForm.makeTrade();
			this.Close();
            this.gameScreen.updateResourceLabels();
		}

		private void DeclineTradeButton_Click(object sender, EventArgs e)
		{
			this.TradeForm.declineTrade();
			this.Close();
		}
	}
}