using System;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class NewGameForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		public NewGameForm()
		{
			InitializeComponent();
			this.Text = this.NewGameLabel.Text = rm.GetString(language + "NewGame");
			this.BackButton.Text = rm.GetString(language + "Back");
			this.StartButton.Text = rm.GetString(language + "Start");
			this.NumPlayersComboBox.Text = rm.GetString(language + "NumPlayers");
			this.NumComputersComboBox.Text = rm.GetString(language + "NumComps");
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			var myForm = new GameScreen();
			myForm.Closed += (send, args) => this.Close();
			myForm.Show();
		}
	}
}