using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class MainMenu : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		public MainMenu()
		{
			//this.GameLabel.Text = Resources.ResourceManager.GetString("enNewGame");
			InitializeComponent();
			this.Text = rm.GetString(language + "MainMenuTitlebar");
			this.GameLabel.Text = rm.GetString(language + "Title");
			this.NewGameButton.Text = rm.GetString(language + "NewGame");
			this.RulesButton.Text = rm.GetString(language + "Rules");
		}

		private void NewGameButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			var myForm = new NewGameForm();
			myForm.Closed += (send, args) => this.Close();
			myForm.Show();
		}

		private void RulesButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			var myForm = new RulesForm();
			myForm.Closed += (send, args) => this.Close();
			myForm.Show();
		}
	}
}