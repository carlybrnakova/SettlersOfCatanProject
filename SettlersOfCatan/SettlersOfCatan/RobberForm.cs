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
	public partial class RobberForm : Form
	{
		private World world;
		private GameScreen gameScreen;
		
			public RobberForm(World world, GameScreen gs)
		{
			InitializeComponent();
			this.world = world;
			this.gameScreen = gs;

			makeAllHexesClickable();
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

		private void RobberFormButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
