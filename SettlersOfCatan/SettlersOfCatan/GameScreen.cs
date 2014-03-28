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
    public partial class GameScreen : Form
    {
        public GameScreen()
        {

            InitializeComponent();

            setupButtons();

        }

        private List<System.Windows.Forms.Button> settlementButtons = new List<System.Windows.Forms.Button>();
        private void setupButtons(){

            Panel p = new Panel();
            p.Location = new Point(0, 0);
            p.Size = new Size(900, 900);
            this.Controls.Add(p);

            for(int i = 0; i < 5; i++){
                Button b = new Button();
                b.BackColor = Color.Red;
                b.Location = new Point(0, i*10);
                settlementButtons.Add(b);
                p.Controls.Add(b);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            //button1.BackColor = Color.Blue;
            //button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Green;
            button2.Height = 30;
            button2.Width = 20;
        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void ItemToBuildComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox myComboBox = (ComboBox)sender;
            if (myComboBox.SelectedIndex == 0)
            {
                // Show all available road buttons
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
            else if (myComboBox.SelectedIndex == 1)
            {
                // Show all available settlement buttons
            }
            else if (myComboBox.SelectedIndex == 2)
            {
                // enable all relevant current settlement buttons to be changed into cities
            }
        }

        private void showOnlyOpenRoadButtons()
        {
            // Disable all city/settlement buttons

            // Hide all unused city/settlement buttons

            // Show and enable all unused road buttons




        }

        private void IntersectionButton_Click(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;


            if (theButton.Width == 30 && theButton.BackColor != System.Drawing.Color.White)
            {
                theButton.Text = "*";
                theButton.ForeColor = Color.White;
                theButton.Enabled = false;
            }

            theButton.BackColor = Color.Orange;
        }

        //private void AddControls(int cNumber) 
        //{ 
            
        //}

        //}


    }
}
