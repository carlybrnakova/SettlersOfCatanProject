using System;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class RulesForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		public RulesForm()
		{
			InitializeComponent();
			this.Text = this.RulesLabel.Text = rm.GetString(language + "Rules");
			this.RulesBackButton.Text = rm.GetString(language + "Back");
		}

		private void RulesBackButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			var myForm = new MainMenu();
			myForm.Closed += (send, args) => this.Close();
			myForm.Show();
		}
	}
}