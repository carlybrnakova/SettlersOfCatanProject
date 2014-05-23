using System;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class RoadBuilderForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		public RoadBuilderForm()
		{
			InitializeComponent();

			this.Text = rm.GetString(language + "RoadBuilder");
			this.PlaceRoadsLabel.Text = rm.GetString(language + "PlaceRoads");
			this.CloseButton.Text = rm.GetString(language + "Close");
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}