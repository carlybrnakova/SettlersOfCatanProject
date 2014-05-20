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
	public partial class BankTradeForm : Form
	{
		private World world;
		private GameScreen gameScreen;
		private Player current;

		public BankTradeForm(World world, GameScreen gs)
		{
			InitializeComponent();
			this.world = world;
			this.gameScreen = gs;
			this.current = this.world.currentPlayer;
		}

		private void SubmitBankTradeButton_Click(object sender, EventArgs e)
		{
			try
			{
				string trade = this.ResourceTradeBankComboBox.SelectedItem.ToString();
				string gain = this.ResourceGainBankComboBox.SelectedItem.ToString();
				this.current.tradeWithBank(trade, gain);
				this.gameScreen.updateResourceLabels();
				this.gameScreen.updateDevelopmentCards();
				this.Dispose();
			}
			catch (ArgumentException ex)
			{
				DialogResult num = MessageBox.Show(ex.Message,
					"Insufficient Resources",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
		}
	}
}