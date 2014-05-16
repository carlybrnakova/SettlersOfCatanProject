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

    public partial class YearOfPlentyForm : Form
    {
        World world;
        GameScreen gameScreen;
        Player current;

        public YearOfPlentyForm(World world, GameScreen gs)
        {
            InitializeComponent();
            this.world = world;
            this.gameScreen = gs;
            this.current = this.world.currentPlayer;
        }

        private void YearOfPlentyButton_Click(object sender, EventArgs e)
        {
            string resource1 = this.YearOfPlentyComboBox1.SelectedItem.ToString();
            string resource2 = this.YearOfPlentyComboBox2.SelectedItem.ToString();
            this.current.playDevCard("yearOfPlenty", resource1, resource2);
            this.gameScreen.updateResourceLabels();
            this.gameScreen.updateDevelopmentCards();
            this.Dispose();
        }
    }
}
