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
        //private const int NUM_OF_INTERSECTION_BUTTONS = 54;
        private const int INTERSECTION_BUTTON_SIZE = 30;
        private const int MAX_INTERSECTION_COLUMNS = 11;
        private const int MAX_INTERSECTION_ROWS = 6;

        private const int MAX_ROAD_ROWS = 11;
        private const int MAX_ROAD_COLUMNS = 10;
        private static Size HORIZONTAL_ROAD_SIZE = new Size(45, 16);
        private static Size VERTICAL_ROAD_SIZE = new Size(16, 120);

        private const int MAX_RESOURCE_HEX_ROWS = 5;
        private const int MAX_RESOURCE_HEX_COLUMNS = 5;
        private const int HEX_SIDE_DIMENSION = 150;

        private const int X_INCREMENT = 75;
        private const int Y_INCREMENT = 150;

        private World world;

       

        // Intersection Grid
        // 7
        // 9
        // 11
        // 11
        // 9
        // 7

        private List<List<IntersectionButton>> intersectionGrid = new List<List<IntersectionButton>>();
        private List<PictureBox> waterHexes = new List<PictureBox>();
        private List<List<ResourceHexPictureBox>> hexGrid = new List<List<ResourceHexPictureBox>>();
        private Button[,] roadGrid = new Button[MAX_ROAD_ROWS,MAX_ROAD_COLUMNS];
        private Panel boardPanel = new Panel();
        //private List<System.Windows.Forms.Button> intersectionButtons = new List<System.Windows.Forms.Button>();

        /** Utility function to determine if a number is even */
        private bool isEven(int n) { return (n % 2 == 0); }

        public GameScreen()
        {
            
            InitializeComponent();

            this.world = new World(3, 0);

            initializeAll();

            initializeBoardPanel();
            //this.world = new World(3,0);
            this.updateResourceLabels();
            this.updateCurrentPlayerNameLabel();
        }

        /** initializeAll()
         * 
         * Initializes all private fields with empty structures to give them
         * the correct dimensions
         */
        private void initializeAll()
        {
            initializeWaterHexes();
            initializeIntersectionGrid();
            initializeHexGrid();
            initializeRoadGrid();
        }

        /** initializeIntersectionGrid()
         * 
         * Initializes the private field intersectionGrid to hold a double array
         * made of Lists containing Buttons
         */
        private void initializeIntersectionGrid()
        {
            for (int r = 0; r < MAX_INTERSECTION_ROWS; r++)
            {
                List<IntersectionButton> l = new List<IntersectionButton>(MAX_INTERSECTION_COLUMNS);
                for (int c = 0; c < MAX_INTERSECTION_COLUMNS; c++)
                {
                    l.Add(new IntersectionButton(r, c));
                }
                intersectionGrid.Add(l);
            }
        }

        /** initializeWaterHexes()
         * 
         * Initializes the waterHexes private field to prepare it for holding
         * all the water hexes that are generated 
         */
        private void initializeWaterHexes()
        {
            for (int i = 0; i < 18; i++)
            {
                waterHexes.Add(new PictureBox());
            }
        }

        /** initializeHexGrid()
         * 
         * Initializes the private field hexGrid just like the intersection buttons
         * to prepare them for actually holding the randomized hexes
         */
        private void initializeHexGrid()
        {
            for (int r = 0; r < MAX_RESOURCE_HEX_ROWS; r++)
            {
                List<ResourceHexPictureBox> l = new List<ResourceHexPictureBox>(MAX_INTERSECTION_COLUMNS);
                for (int c = 0; c < MAX_RESOURCE_HEX_COLUMNS; c++)
                {
                    l.Add(new ResourceHexPictureBox());
                }
                hexGrid.Add(l);
            }
        }

        /** initializeRoadGrid()
         * 
         * Initializes the private fiels roadGrid so that it can be filled
         * with the road buttons
         */
        private void initializeRoadGrid()
        {
            for (int r = 0; r < MAX_ROAD_ROWS; r++)
            {
                for (int c = 0; c < MAX_ROAD_COLUMNS; c++)
                {
                    roadGrid[r, c] = null;
                }
            }
        }

        private void setupRoadGrid()
        {
            int x = 315;
            int y = 70;
            int x_diff = 75;
            int y_diff = 150;
            int col;
            int columnMax = 6;
            // The horizontal-button rows
            for (int r = 0; r < MAX_ROAD_ROWS; r+=2)
            {
                for (col = 0; col < columnMax; col++)
                {
                    RoadButton b = new RoadButton(r, col);
                    b.Size = HORIZONTAL_ROAD_SIZE;
                    b.Location = new Point(x, y);
                    b.BackColor = Color.White;
                    b.Click += roadButton_Click;
                    boardPanel.Controls.Add(b);
                    
                    x += x_diff;
                }
                // Allow more or less buttons for the next row
                if (r < 4) columnMax += 2; 
                else if (r >= 6) columnMax -= 2;

                // Find the correct start positions for the next row
                if (r < 4) x = x - x_diff * (col + 1);
                else if (r >= 6) x = x - x_diff * (col - 1);
                else x = x - x_diff * col;

                y += y_diff;
            }

            // The vertical-button rows
            x = 292;
            y = 90;
            x_diff = 150;
            y_diff = 150;
            columnMax = 4;
            for (int r = 1; r < MAX_ROAD_ROWS; r += 2)
            {
                for (col = 0; col < columnMax; col++)
                {
                    RoadButton b = new RoadButton(r, col);
                    b.Size = VERTICAL_ROAD_SIZE;
                    b.Location = new Point(x, y);
                    b.BackColor = Color.White;
                    b.Click += roadButton_Click;
                    boardPanel.Controls.Add(b);

                    x += x_diff;
                }
                columnMax = (r < 5) ? columnMax + 1 : columnMax - 1;
                y = y + y_diff;
                x = (r <= 4) ? x - x_diff * col - x_diff/2 : x - x_diff * col + x_diff/2;
            }
        }

        private void setupHexGrid()
        {
            // Coordinate variables for plotting buttons in correct locations
            int x = HEX_SIDE_DIMENSION * 2;
            int y = HEX_SIDE_DIMENSION / 2;
            
                for (int c = 0; c < MAX_RESOURCE_HEX_COLUMNS; c++)
                {
                    for (int r = 0; r < MAX_RESOURCE_HEX_ROWS; r++)
                    {
                        ResourceHexPictureBox h;
                        try
                        {
                            h = new ResourceHexPictureBox(world.getHexAtIndex(r, c));
                            
                            if (r == 0 || r == 4) h.Location = new Point(x - HEX_SIDE_DIMENSION, y);
                            else h.Location = new Point(x, y);
                            boardPanel.Controls.Add(h);
                        }
                        catch (NullReferenceException e)
                        {
                            //h = new ResourceHexPictureBox();
                            h = null;
                            /*
                            if ((r == 0 || r == 4) && (c > 2))
                            {
                                h = null;
                            }
                            else if ((r == 1 || r == 3) && (c > 3))
                            {
                                h = null;
                            }
                             * */
                        }
                        hexGrid[r][c] = h;

                        x = (r < 2) ? x - HEX_SIDE_DIMENSION / 2 : x + HEX_SIDE_DIMENSION / 2;
                        y += HEX_SIDE_DIMENSION;
                      
                    }
                    y = HEX_SIDE_DIMENSION / 2;
                    x = HEX_SIDE_DIMENSION * (3 + c);
                }
        }

        private void setupWaterHexes()
        {
            int waterCount = 0;
            int x = 225;
            int x_diff = 150;
            int y = 0;
            int y_diff = 600;

            // Set up top and bottom (short hexes)
            for (int i = 0; i < 4; i++)
            {
                PictureBox pb = new PictureBox();
                pb.BackColor = Color.Blue;
                pb.Size = new Size(150, 75);
                pb.Location = new Point(x, y);
                waterHexes[waterCount] = pb;
                waterCount++;
                boardPanel.Controls.Add(pb);
               
                PictureBox pb2 = new PictureBox();
                pb2.BackColor = Color.Blue;
                pb2.Size = new Size(150, 75);
                pb2.Location = new Point(x, y + 825);
                waterHexes[waterCount] = pb2;
                waterCount++;
                boardPanel.Controls.Add(pb2);
                x += x_diff;
            }

            // Set up the water hexes on the left
            x = 150;
            x_diff = 75;
            y = 75;
            y_diff = 600;
            for (int i = 0; i < 3; i++)
            {
                PictureBox pb = new PictureBox();
                pb.BackColor = Color.Blue;
                pb.Size = new Size(150, 150);
                pb.Location = new Point(x, y);
                waterHexes[waterCount] = pb;
                waterCount++;
                boardPanel.Controls.Add(pb);

                if (i == 2) break;

                PictureBox pb2 = new PictureBox();
                pb2.BackColor = Color.Blue;
                pb2.Size = new Size(150, 150);
                pb2.Location = new Point(x, y + y_diff);
                waterHexes[waterCount] = pb2;
                waterCount++;
                boardPanel.Controls.Add(pb2);

                x -= x_diff;
                y += 150;
                y_diff -= 150 * (i+2);
            }

            // Set up the water hexes on the right
            x = 750;
            x_diff = 75;
            y = 75;
            y_diff = 600;
            for (int i = 0; i < 3; i++)
            {
                PictureBox pb = new PictureBox();
                pb.BackColor = Color.Blue;
                pb.Size = new Size(150, 150);
                pb.Location = new Point(x, y);
                waterHexes[waterCount] = pb;
                waterCount++;
                boardPanel.Controls.Add(pb);

                if (i == 2) break;

                PictureBox pb2 = new PictureBox();
                pb2.BackColor = Color.Blue;
                pb2.Size = new Size(150, 150);
                pb2.Location = new Point(x, y + y_diff);
                waterHexes[waterCount] = pb2;
                waterCount++;
                boardPanel.Controls.Add(pb2);

                x += x_diff;
                y += 150;
                y_diff -= 150 * (i + 2);
            }
        }

        private void initializeBoardPanel()
        {
            boardPanel.Location = new Point(0, 0);
            boardPanel.Size = new Size(1050, 1050);

            setupIntersectionButtons();


            setupRoadGrid();
            setupWaterHexes();
            setupHexGrid();

            this.Controls.Add(boardPanel);
            
        }

        private void setupIntersectionButtons(){

            // Coordinate variables for plotting buttons in correct locations
            int x = 150 - INTERSECTION_BUTTON_SIZE/2;
            int y = 75 - INTERSECTION_BUTTON_SIZE/2;

                for (int r = 0; r < MAX_INTERSECTION_ROWS; r++)
                {
                    for (int c = 0; c < MAX_INTERSECTION_COLUMNS; c++)
                    {
                        IntersectionButton b = new IntersectionButton(r, c);
                        b.BackColor = Color.White;
                        b.Font = new Font("Georgia", 20, FontStyle.Bold | FontStyle.Strikeout);
                        b.Size = new Size(INTERSECTION_BUTTON_SIZE, INTERSECTION_BUTTON_SIZE);
                        b.Location = new Point(x, y);
                        b.Click += intersectionButton_Click;
                        if ((r == 0 || r == 5) && (c < 2 || c > 8))
                        {
                            b = null;
                        }
                        else if ((r == 1 || r == 4) && (c < 1 || c > 9))
                        {
                            b = null;
                        }

                        intersectionGrid[r][c] = b;

                        if(b != null) boardPanel.Controls.Add(b);
                        
                        x += X_INCREMENT;
                    }
                    x = 150 - INTERSECTION_BUTTON_SIZE/2;
                    y += Y_INCREMENT;
                }
        }

        private void ItemToBuildComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox myComboBox = (ComboBox)sender;
            if (myComboBox.SelectedIndex == 0)
            {
                // Show all available road buttons
             
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


        private void intersectionButton_Click(object sender, EventArgs e)
        {
            IntersectionButton theButton = (IntersectionButton)sender;

            Color buttonColor = world.intersectionButtonClicked(theButton.getCoords());
            if (buttonColor != Color.White && buttonColor != Color.Black)
            {
                theButton.BackColor = buttonColor;
            }
            else if (buttonColor == Color.Black)
            {
                theButton.Text = "*";
                theButton.ForeColor = Color.White;
            }

            this.updateResourceLabels();
        }

        private void roadButton_Click(object sender, EventArgs e)
        {
            RoadButton theButton = (RoadButton)sender;

            Color buttonColor = world.roadButtonClicked(theButton.getCoords());
            if (buttonColor != Color.White) theButton.BackColor = buttonColor;

            this.updateResourceLabels();
        }

        public void updateResourceLabels()
        {
            WoolAmountLabel.Text = this.world.currentPlayer.getHand().getWool().ToString();
            BrickAmountLabel.Text = this.world.currentPlayer.getHand().getBrick().ToString();
            LumberAmountLabel.Text = this.world.currentPlayer.getHand().getLumber().ToString();
            OreAmountLabel.Text = this.world.currentPlayer.getHand().getOre().ToString();
            GrainAmountLabel.Text = this.world.currentPlayer.getHand().getGrain().ToString();
        }

        private void EndTurnButton_Click(object sender, EventArgs e)
        {
            this.world.endTurn();
            this.updateResourceLabels();
            this.updateCurrentPlayerNameLabel();
        }

        private void updateCurrentPlayerNameLabel()
        {
            CurrentPlayerNameLabel.Text = this.world.currentPlayer.getName().ToString();
        }

        private void ProposeTradeButton_Click(object sender, EventArgs e)
        {
            Form myForm = new TradeForm(this.world, this);
            myForm.Show();
        }

        private void generateResourcesTest_Click(object sender, EventArgs e)
        {
            this.world.currentPlayer.playerHand.modifyBrick(1);
            this.world.currentPlayer.playerHand.modifyGrain(1);
            this.world.currentPlayer.playerHand.modifyWool(1);
            this.world.currentPlayer.playerHand.modifyOre(1);
            this.world.currentPlayer.playerHand.modifyLumber(1);
            this.updateResourceLabels();
        }

        private void RollDiceButton_Click(object sender, EventArgs e)
        {
            this.world.rollDice();
            this.updateResourceLabels();
            this.RollNumberLabel.Text = this.world.getRollNumber().ToString();
            
        }
    }
}
