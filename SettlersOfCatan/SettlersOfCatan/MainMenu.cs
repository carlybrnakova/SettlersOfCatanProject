using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettlersOfCatan
{
	public partial class MainMenu : Form
	{
		public MainMenu()
		{
			this.GameLabel.Text = English.NewGame;
			InitializeComponent();
		}

		private void NewGameButton_Click(object sender, EventArgs e)
		{
			Form myForm = new NewGameForm();
			myForm.Show();
		}

		private void RulesButton_Click(object sender, EventArgs e)
		{
			Form myForm = new RulesForm();
			myForm.Show();
		}
	}
}