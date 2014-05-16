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
	public partial class NewGameForm : Form
	{
		public NewGameForm()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			Form gameScreen = new GameScreen();
			gameScreen.Show();
		}
	}
}