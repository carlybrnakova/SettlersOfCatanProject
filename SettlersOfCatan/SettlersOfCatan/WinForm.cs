using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class WinForm : Form
	{
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		public WinForm()
		{
			InitializeComponent();

			this.Text = rm.GetString(language + "Congratulations");
			this.WinnerLabel.Text = rm.GetString(language + "Winner");
		}
	}
}