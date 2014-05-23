using System;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class FirstFewTurnsForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		public FirstFewTurnsForm()
		{
			InitializeComponent();
			
			this.Text = rm.GetString(language + "FirstFewTitle");
			this.PlaceRoadsAndSettlementsLabel.Text = rm.GetString(language + "FirstFewPrompt");
			this.CloseButton.Text = rm.GetString(language + "Close");
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}