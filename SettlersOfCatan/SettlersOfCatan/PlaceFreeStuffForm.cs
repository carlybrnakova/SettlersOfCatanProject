using System;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class PlaceFreeStuffForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		public PlaceFreeStuffForm()
		{
			InitializeComponent();

			this.Text = rm.GetString(language + "UnplacedStuffTitle");
			this.PlaceStuffBeforeEndingLabel.Text = rm.GetString(language + "UnplacedStuffPrompt");
			this.CloseButton.Text = rm.GetString(language + "Close");
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}