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
	public partial class ChooseLanguageForm : Form
	{
		public ChooseLanguageForm()
		{
			InitializeComponent();
		}

		private void AmericanFlag_Click(object sender, EventArgs e)
		{
			// default language is English so no need to set language

			this.Hide();
			var myForm = new MainMenu();
			myForm.Closed += (send, args) => this.Close();
			myForm.Show();
		}

		private void SpanishFlag_Click(object sender, EventArgs e)
		{
			// set language
			Global_Variables.language = "Spanish";

			this.Hide();
			var myForm = new MainMenu();
			myForm.Closed += (send, args) => this.Close();
			myForm.Show();
		}
	}
}