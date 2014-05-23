using System;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class RobberForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		private World world;
		private GameScreen gameScreen;

		public RobberForm(World world, GameScreen gs)
		{
			InitializeComponent();
			this.world = world;
			this.gameScreen = gs;
			localize();

			makeAllHexesClickable();
		}

		private void localize()
		{
			this.Text = rm.GetString(language + "Instructions");
			this.RobberFormDoubleClickLabel.Text = rm.GetString(language + "DoubleClick");
			this.ReminderLabelRobberForm.Text = rm.GetString(language + "RobberReminder");
			this.RobberFormNoteLabel.Text = rm.GetString(language + "RobberNote");
			this.RobberFormButton.Text = rm.GetString(language + "Close");
		}

		public void makeAllHexesClickable()
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 1; j < 4; j++)
				{
					this.gameScreen.hexGrid[i][j].setClickable(true);
				}
			}

			this.gameScreen.hexGrid[1][0].setClickable(true);
			this.gameScreen.hexGrid[2][0].setClickable(true);
			this.gameScreen.hexGrid[2][4].setClickable(true);
			this.gameScreen.hexGrid[3][0].setClickable(true);
		}

		public void makeAllHexesNotHaveRobber()
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 1; j < 4; j++)
				{
					this.gameScreen.hexGrid[i][j].setHasRobber(false);
				}
			}

			this.gameScreen.hexGrid[1][0].setHasRobber(false);
			this.gameScreen.hexGrid[2][0].setHasRobber(false);
			this.gameScreen.hexGrid[2][4].setHasRobber(false);
			this.gameScreen.hexGrid[3][0].setHasRobber(false);
		}

		private void RobberFormButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}