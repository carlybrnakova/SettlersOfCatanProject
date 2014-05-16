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
    public partial class MonopolyForm : Form
    {
        World world;
        GameScreen gameScreen;
        Player current;

        public MonopolyForm(World world, GameScreen gs)
        {
            InitializeComponent();
            this.world = world;
            this.gameScreen = gs;
            this.current = this.world.currentPlayer;
        }

        private void MonopolyButton_Click(object sender, EventArgs e)
        {
            string resource1 = this.MonopolyComboBox.SelectedItem.ToString();
            this.current.playDevCard("monopoly", resource1, null);
            this.gameScreen.updateResourceLabels();
            this.gameScreen.updateDevelopmentCards();
            this.Dispose();
        }
    }
}
