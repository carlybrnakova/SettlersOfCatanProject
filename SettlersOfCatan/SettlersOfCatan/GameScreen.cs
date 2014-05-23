using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
	public partial class GameScreen : Form
	{
		//private const int NUM_OF_INTERSECTION_BUTTONS = 54;
		private ResourceManager rm = Resources.ResourceManager;
		private string language = Global_Variables.language;

		private const int INTERSECTION_BUTTON_SIZE = 30;
		private const int MAX_INTERSECTION_COLUMNS = 11;
		private const int MAX_INTERSECTION_ROWS = 6;


		private static Size HORIZONTAL_ROAD_SIZE = new Size(45, 16);
		private static Size VERTICAL_ROAD_SIZE = new Size(16, 120);

		private const int MAX_RESOURCE_HEX_ROWS = 5;
		private const int MAX_RESOURCE_HEX_COLUMNS = 5;
		private const int HEX_SIDE_DIMENSION = 150;

		private const int X_INCREMENT = 75;
		private const int Y_INCREMENT = 150;

		private World world;

		private Hex robberHex = null;

		public int checkRemoveHalfCount = 0;

		// Intersection Grid
		// 7
		// 9
		// 11
		// 11
		// 9
		// 7

		private List<List<IntersectionButton>> intersectionGrid = new List<List<IntersectionButton>>();
		private List<PictureBox> waterHexes = new List<PictureBox>();
		public List<List<ResourceHexPictureBox>> hexGrid = new List<List<ResourceHexPictureBox>>();
		private Button[,] roadGrid = new Button[Global_Variables.MAX_ROAD_ROWS, Global_Variables.MAX_ROAD_COLUMNS];
		private Panel boardPanel = new Panel();
		//private List<System.Windows.Forms.Button> intersectionButtons = new List<System.Windows.Forms.Button>();

		/** Utility function to determine if a number is even */


		public GameScreen()
		{
			InitializeComponent();

			this.world = new World(3, 0);

			initializeAll();

			initializeBoardPanel();
			//this.world = new World(3,0);
			localize();
			this.updateResourceLabels();
			this.updateCurrentPlayerNameLabel();
			this.updateRoundLabel();
		}

		private void localize()
		{
			this.Text = rm.GetString(language + "Title");

			this.MaterialsLabel.Text = rm.GetString(language + "Materials");
			this.OreLabel.Text = rm.GetString(language + "Ore") + ":";
			this.LumberLabel.Text = rm.GetString(language + "Lumber") + ":";
			this.GrainLabel.Text = rm.GetString(language + "Grain") + ":";
			this.BrickLabel.Text = rm.GetString(language + "Brick") + ":";
			this.WoolLabel.Text = rm.GetString(language + "Wool") + ":";

			this.DevCardsLabel.Text = rm.GetString(language + "DevCards");
			this.RoadBuilderDevCardLabel.Text = rm.GetString(language + "RoadBuilder");
			this.YearOfPlentyDevCardLabel.Text = rm.GetString(language + "YearOfPlenty");
			this.MonopolyDevCardLabel.Text = rm.GetString(language + "Monopoly");
			this.VictoryPointDevCardLabel.Text = rm.GetString(language + "VictoryPoint");
			this.KnightsDevCardLabel.Text = rm.GetString(language + "Knights");

			this.EndTurnButton.Text = rm.GetString(language + "EndTurn");
			this.PointsLabel.Text = rm.GetString(language + "Points");
			this.RoundsLabel.Text = rm.GetString(language + "Rounds");
			this.RollDiceButton.Text = rm.GetString(language + "Roll");
			this.CurrentRollLabel.Text = rm.GetString(language + "CurrentRoll");

			this.BuyDevCardButton.Text = rm.GetString(language + "BuyDevCard");
			this.ProposeTradeButton.Text = rm.GetString(language + "ProposeTrade");
			this.BankTradeButton.Text = rm.GetString(language + "TradeWithBank");
			this.generateResourcesTest.Text = rm.GetString(language + "GenerateTest");
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
					l.Add(new ResourceHexPictureBox(this.world));
				}
				hexGrid.Add(l);
			}
		}

		/** initializeRoadGrid()
         * 
         * Initializes the private fields roadGrid so that it can be filled
         * with the road buttons
         */

		private void initializeRoadGrid()
		{
			for (int r = 0; r < Global_Variables.MAX_ROAD_ROWS; r++)
			{
				for (int c = 0; c < Global_Variables.MAX_ROAD_COLUMNS; c++)
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
			for (int r = 0; r < Global_Variables.MAX_ROAD_ROWS; r += 2)
			{
				for (col = 0; col < columnMax; col++)
				{
					RoadButton b = new RoadButton(r, col);
					setLocationAndColorButton(b, Color.White, x, y);
					setRoadButtonSizeCoordinatesAndClick(b, HORIZONTAL_ROAD_SIZE, r, col);
					roadGrid[r, col] = b;
					boardPanel.Controls.Add(b);

					x += x_diff;
				}
				// Allow more or less buttons for the next row
				if (r < 4) columnMax += 2;
				else if (r >= 6) columnMax -= 2;

				// Find the correct start positions for the next row
				if (r < 4) x = x - x_diff*(col + 1);
				else if (r >= 6) x = x - x_diff*(col - 1);
				else x = x - x_diff*col;

				y += y_diff;
			}

			// The vertical-button rows
			x = 292;
			y = 90;
			x_diff = 150;
			y_diff = 150;
			columnMax = 4;
			for (int r = 1; r < Global_Variables.MAX_ROAD_ROWS; r += 2)
			{
				for (col = 0; col < columnMax; col++)
				{
					RoadButton b = new RoadButton(r, col);
					setLocationAndColorButton(b, Color.White, x, y);
					setRoadButtonSizeCoordinatesAndClick(b, VERTICAL_ROAD_SIZE, r, col);
					roadGrid[r, col] = b;
					boardPanel.Controls.Add(b);

					x += x_diff;
				}
				columnMax = (r < 5) ? columnMax + 1 : columnMax - 1;
				y = y + y_diff;
				x = (r <= 4) ? x - x_diff*col - x_diff/2 : x - x_diff*col + x_diff/2;
			}
		}

		private void setupHexGrid()
		{
			// Coordinate variables for plotting buttons in correct locations
			int x = HEX_SIDE_DIMENSION*2;
			int y = HEX_SIDE_DIMENSION/2;

			for (int c = 0; c < MAX_RESOURCE_HEX_COLUMNS; c++)
			{
				for (int r = 0; r < MAX_RESOURCE_HEX_ROWS; r++)
				{
					ResourceHexPictureBox h;
					try
					{
						h = new ResourceHexPictureBox(world.getHexAtIndex(r, c), this.world);

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

					x = (r < 2) ? x - HEX_SIDE_DIMENSION/2 : x + HEX_SIDE_DIMENSION/2;
					y += HEX_SIDE_DIMENSION;
				}
				y = HEX_SIDE_DIMENSION/2;
				x = HEX_SIDE_DIMENSION*(3 + c);
			}
		}

		private void setupWaterHexes()
		{
			int waterCount = 0;
			int x = 225;
			int x_diff = 150;
			int y = 0;
			int y_diff = 600;

			// Set up top
			PictureBox PB = createWaterHexPictureBox(Color.Blue, 225, 0, new Size(600, 75));
			waterHexes[waterCount] = PB;

			// Add ports for top
			string topText = "v   " + rm.GetString(language + "Anything") + " 3:1   v";
			PB.Controls.Add(createPortLabel(70, 40, false, topText));

			// Add second port for top
			topText = "v   " + rm.GetString(language + "Wool") + " 2:1   v";
			PB.Controls.Add(createPortLabel(300, 40, false, topText));

			waterCount++;
			boardPanel.Controls.Add(PB);

			// Set up bottom
			PictureBox PB2 = createWaterHexPictureBox(Color.Blue, 225, 825, new Size(600, 75));
			waterHexes[waterCount] = PB;

			// Add ports for bottom
			topText = "^   " + rm.GetString(language + "Anything") + " 3:1   ^";
			PB2.Controls.Add(createPortLabel(70, 25, false, topText));

			// Add second port for bottom
			topText = "^   " + rm.GetString(language + "Lumber") + " 2:1   ^";
			PB2.Controls.Add(createPortLabel(295, 25, false, topText));

			waterCount++;
			boardPanel.Controls.Add(PB2);

			// Set up the water hexes on the left
			x = 150;
			x_diff = 75;
			y = 75;
			y_diff = 600;
			for (int i = 0; i < 3; i++)
			{
				PictureBox pb = createWaterHexPictureBox(Color.Blue, x, y, new Size(150, 150));

				// Add port if relevant
				if (waterCount == 4)
				{
					string text = "        -->\n\n\n\n" + rm.GetString(language + "Ore") + " 2:1 \n\n\n\n\n        -->";
					pb.Controls.Add(createPortLabel(80, 10, true, text));
				}

				waterHexes[waterCount] = pb;
				waterCount++;
				boardPanel.Controls.Add(pb);

				if (i == 2) break;

				PictureBox pb2 = createWaterHexPictureBox(Color.Blue, x, y + y_diff, new Size(150, 150));

				// Add port if relevant
				if (waterCount == 5)
				{
					string text = "      -->\n\n\n\n" + rm.GetString(language + "Grain") + " 2:1\n\n\n\n\n      -->";
					pb2.Controls.Add(createPortLabel(90, 10, true, text));
				}
				waterHexes[waterCount] = pb2;
				waterCount++;
				boardPanel.Controls.Add(pb2);

				x -= x_diff;
				y += 150;
				y_diff -= 150*(i + 2);
			}

			// Set up the water hexes on the right
			x = 750;
			x_diff = 75;
			y = 75;
			y_diff = 600;
			for (int i = 0; i < 3; i++)
			{
				PictureBox pb = createWaterHexPictureBox(Color.Blue, x, y, new Size(150, 150));

				// Add port if relevant
				if (waterCount == 7)
				{
					string text = "v  " + rm.GetString(language + "Anything") + " 3:1  v";
					pb.Controls.Add(createPortLabel(10, 110, true, text));
				}
				else if (waterCount == 11)
				{
					string text = "    <--\n\n\n\n " + rm.GetString(language + "Anything") + " 3:1\n\n\n\n\n    <--";
					pb.Controls.Add(createPortLabel(10, 10, true, text));
				}
				waterHexes[waterCount] = pb;
				waterCount++;
				boardPanel.Controls.Add(pb);

				if (i == 2) break;

				PictureBox pb2 = createWaterHexPictureBox(Color.Blue, x, y + y_diff, new Size(150, 150));

				// Add port if relevant
				if (waterCount == 8)
				{
					string text = "^  " + rm.GetString(language + "Brick") + " 2:1  ^";
					pb2.Controls.Add(createPortLabel(10, 20, true, text));
				}
				waterHexes[waterCount] = pb2;
				waterCount++;
				boardPanel.Controls.Add(pb2);

				x += x_diff;
				y += 150;
				y_diff -= 150*(i + 2);
			}
		}

		private Label createPortLabel(int xLocation, int yLocation, bool setSize, string text)
		{
			Label portLabel = new Label();
			if (setSize == true)
			{
				portLabel.Size = new Size(150, 150);
			}

			portLabel.ForeColor = Color.White;
			portLabel.Text = text;
			portLabel.Location = new Point(xLocation, yLocation);
			return portLabel;
		}

		private void addPictureBox(int waterCount, int[] coords, bool top, bool diff)
		{
			int x = coords[0];
			int x_diff = coords[1];
			int y = coords[2];
			int y_diff = coords[3];

			PictureBox pb = new PictureBox();

			if (top == true)
			{
				if (diff == true)
				{
					setPictureBoxColorLocationAndSize(pb, Color.Blue, x, y + y_diff, new Size(150, 75));
				}
				else
				{
					setPictureBoxColorLocationAndSize(pb, Color.Blue, x, y, new Size(150, 75));
				}
			}
			else
			{
				if (diff == true)
				{
					setPictureBoxColorLocationAndSize(pb, Color.Blue, x, y + y_diff, new Size(150, 150));
				}
				else
				{
					setPictureBoxColorLocationAndSize(pb, Color.Blue, x, y, new Size(150, 150));
				}
			}
			waterHexes[waterCount] = pb;
			boardPanel.Controls.Add(pb);
		}

		private PictureBox createWaterHexPictureBox(Color color, int x, int y, Size size)
		{
			PictureBox pb = new PictureBox();
			setPictureBoxColorLocationAndSize(pb, color, x, y, size);
			return pb;
		}

		private void setPictureBoxColorLocationAndSize(PictureBox pb, Color color, int x, int y, Size size)
		{
			pb.BackColor = color;
			pb.Location = new Point(x, y);
			pb.Size = size;
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

		private void setupIntersectionButtons()
		{
			// Coordinate variables for plotting buttons in correct locations
			int x = 150 - INTERSECTION_BUTTON_SIZE/2;
			int y = 75 - INTERSECTION_BUTTON_SIZE/2;

			for (int r = 0; r < MAX_INTERSECTION_ROWS; r++)
			{
				for (int c = 0; c < MAX_INTERSECTION_COLUMNS; c++)
				{
					IntersectionButton b = new IntersectionButton(r, c);
					setLocationAndColorButton(b, Color.White, x, y);
					setIntersectionFontClickAndSize(b);

					if ((r == 0 || r == 5) && (c < 2 || c > 8))
					{
						b = null;
					}
					else if ((r == 1 || r == 4) && (c < 1 || c > 9))
					{
						b = null;
					}

					intersectionGrid[r][c] = b;

					if (b != null) boardPanel.Controls.Add(b);

					x += X_INCREMENT;
				}
				x = 150 - INTERSECTION_BUTTON_SIZE/2;
				y += Y_INCREMENT;
			}
		}

		private void setLocationAndColorButton(Button button, Color color, int x, int y)
		{
			button.BackColor = color;
			button.Location = new Point(x, y);
		}

		private void setIntersectionFontClickAndSize(Button button)
		{
			button.Font = new Font("Georgia", 20, FontStyle.Bold | FontStyle.Strikeout);
			button.Size = new Size(INTERSECTION_BUTTON_SIZE, INTERSECTION_BUTTON_SIZE);
			button.Click += intersectionButton_Click;
		}

        private void setRoadButtonSizeCoordinatesAndClick(RoadButton button, Size size, int x, int y)
        {
            button.Size = size;
            button.Click += roadButton_Click;
            button.coordinates = new Point(x, y);
        }

        private void callIntButtonClick(object sender, EventArgs e, String controlString)
        {
            IntersectionButton theButton = (IntersectionButton)sender;

            Color buttonColor = world.tryToBuildAtIntersection(theButton.getCoords());
            if (buttonColor != Color.White && buttonColor != Color.Black)
            {
                theButton.BackColor = buttonColor;
            }
            else if (buttonColor == Color.Black)
            {
                theButton.Text = "*";
                theButton.ForeColor = Color.White;
                this.world.currentPlayer.incrementCities();
            }

            this.updateResourceLabels();
            this.updatePlayerPoints();
        }
        private void intersectionButton_Click(object sender, EventArgs e)
        {
            callIntButtonClick(sender, e, "none");
		}


        private void callRoadButton_Click(object sender, EventArgs e, Point coords)
        {
            Color buttonColor = new Color();
            RoadButton theButton;
            if (coords.Equals(new Point(-1, -1)))
            {
                theButton = (RoadButton)sender;
                buttonColor = world.roadButtonClicked(theButton.getCoords());
            }
            else
            {
                theButton = (RoadButton)this.roadGrid[coords.X, coords.Y];
                buttonColor = world.roadButtonClicked(coords);
            }
            if (buttonColor != Color.White)
            {
                theButton.BackColor = buttonColor;
                theButton.Enabled = false;
            }
            this.updateResourceLabels();
            this.world.setLongestRoad();
            this.updatePlayerPoints();
            this.Refresh();
        }


		private void roadButton_Click(object sender, EventArgs e)
		{
			callRoadButton_Click(sender, e, new Point(-1, -1));
		}

		public void updateResourceLabels()
		{
			WoolAmountLabel.Text = this.world.currentPlayer.getHand().getWool().ToString();
			BrickAmountLabel.Text = this.world.currentPlayer.getHand().getBrick().ToString();
			LumberAmountLabel.Text = this.world.currentPlayer.getHand().getLumber().ToString();
			OreAmountLabel.Text = this.world.currentPlayer.getHand().getOre().ToString();
			GrainAmountLabel.Text = this.world.currentPlayer.getHand().getGrain().ToString();
		}

		private IntersectionButton getIntButtonAt(Point p)
		{
			IntersectionButton theButton = null;
			List<IntersectionButton>[] intArray = this.intersectionGrid.ToArray();

			foreach (List<IntersectionButton> array in intArray)
			{
				foreach (IntersectionButton b in array)
				{
					if (b != null && b.getCoords().Equals(p))
					{
						theButton = b;
						goto EndLoop;
					}
				}
			}
			EndLoop:
			return theButton;
		}

		private void EndTurnButton_Click(object sender, EventArgs e)
		{
			bool showForm = true;
			// Place stuff if you haven't yet
			if (this.world.currentPlayer.getHand().hasFreeRoadPoints() ||
			    this.world.currentPlayer.getHand().hasFreeSettlementPoints())
			{
				Form myForm = new PlaceFreeStuffForm();
				myForm.Show();
			}
			else
			{
                this.world.endTurn();
                if (this.world.isFirstFewTurnsPhase())
                {
                    this.world.currentPlayer.getHand().modifyFreeRoadPoints(1);
                    this.world.currentPlayer.getHand().modifyFreeSettlementPoints(1);

                    if (this.world.currentPlayer is AI_Player)
                    {
                        String result = ((AI_Player)this.world.currentPlayer).takeYourTurn(this.world.numOfCompletedRounds);
                        if (result == "settlement")
                        {
                            Point coords = ((AI_Player)this.world.currentPlayer).getIntersectionCoordsToBuild();
                            IntersectionButton i = this.getIntButtonAt(coords);
                            this.callIntButtonClick(i, null, result);
                            if (this.world.isFirstFewTurnsPhase())
                            {
                                int y = i.getCoords().Y;
                                if (y == 0 || y == 5) y -= 2;
                                else if (y == 1 || y == 4) y -= 1;

                                Point roadCoords = new Point(i.getCoords().X * 2, y);
                                //Button b = this.getARoadButtonAt(coords);
                                callRoadButton_Click(sender, null, roadCoords);
                            }
                        }
                        showForm = false;
                    }
                    else
                    {
                        showForm = true;
                    }

                    if (showForm)
                    {
                        Form myForm = new FirstFewTurnsForm();
                        myForm.Show();
                    }
                }
                else
                {


                    // Normal routine: check if AI player
                    if (this.world.currentPlayer is AI_Player)
                    {
                        showForm = false;
                        String result = ((AI_Player)this.world.currentPlayer).takeYourTurn(this.world.numOfCompletedRounds);
                        if (result == "road")
                        {
                            Intersection intersection = this.world.catanMap.getIslandMap().getIntAtIndex(this.world.currentPlayer.getSettlementLocations()[0]);
                            while (this.world.catanMap.getIslandMap().getIntAtIndex(intersection.getCoords()).getConnections()[2].getRoadColor() == ((Player)this.world.currentPlayer).getColor())
                            {
                                intersection = this.world.catanMap.getIslandMap().getIntAtIndex(intersection.getCoords()).getConnections()[2].getIntersectionRightOrBot();
                            }
                            int y = intersection.getCoords().Y;
                            if (y == 0 || y == 5) y -= 2;
                            else if (y == 1 || y == 4) y -= 1;

                            Point roadCoords = new Point(intersection.getCoords().X * 2, y);
                            //Button b = this.getARoadButtonAt(coords);
                            callRoadButton_Click(sender, null, roadCoords);
                        }
                    }
                    if (!showForm)
			        {
				    EndTurnButton_Click(sender, e);
			        }

                }


				
			}
            this.updateResourceLabels();
            this.updateCurrentPlayerNameLabel();
            this.updateRoundLabel();
            this.updatePlayerPoints();

			removeRobberText();
			this.Refresh();

		}


		private void updateRoundLabel()
		{
			RoundsLabel.Text = rm.GetString(language + "Rounds") + " " + (this.world.getNumberOfRoundsCompleted() + 1);
		}

		private Button getARoadButtonAt(Point coords)
		{
			Point roadCoords = this.world.catanMap.getIslandMap().getIntAtIndex(coords).connections[1].getCoords();
			return this.roadGrid[roadCoords.X, roadCoords.Y];
		}

		private void updateCurrentPlayerNameLabel()
		{
			CurrentPlayerNameLabel.Text = this.world.currentPlayer.getName().ToString();
			CurrentPlayerNameLabel.ForeColor = this.world.currentPlayer.getColor();
		}

		private void ProposeTradeButton_Click(object sender, EventArgs e)
		{
			Form myForm = new TradeForm(this.world, this);
			myForm.Show();
		}

		private void RollDiceButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.world.rollDice();
				this.updateResourceLabels();
				int roll = this.world.getRollNumber();
				this.RollNumberLabel.Text = roll.ToString();
				if (roll == 7)
				{
					removeRobberText();

					checkRemoveHalf();

					this.world.setPlaceRobber(true);
					RobberForm myForm = new RobberForm(this.world, this);
					myForm.Show();
				}
			}
			catch (ArgumentException ex)
			{
				DialogResult num = MessageBox.Show(ex.Message,
					rm.GetString(language + "InsufficientResources"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
		}

		private void generateResourcesTest_Click(object sender, EventArgs e)
		{
			try
			{
				this.world.givePlayerAllResources(this.world.currentPlayer, 1);
				this.world.bank.decrementAllResources(1);
				this.updateResourceLabels();
			}
			catch (ArgumentException ex)
			{
				DialogResult num = MessageBox.Show(ex.Message,
					"Insufficient Resources",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
		}

		private void checkRemoveHalf()
		{
			this.checkRemoveHalfCount = 0;

			for (int i = this.world.currentPlayerNumber; i < this.world.players.Count; i++)
			{
				if (this.world.players[i].mustRemoveHalf())
				{
					RemoveCardsForm removeForm = new RemoveCardsForm(this.world.players[i], this);
					removeForm.Show();
				}
				this.checkRemoveHalfCount++;
			}

			for (int i = 0; i < this.world.currentPlayerNumber; i++)
			{
				if (this.world.players[i].mustRemoveHalf())
				{
					RemoveCardsForm removeForm = new RemoveCardsForm(this.world.players[i], this);
					removeForm.Show();
				}
				this.checkRemoveHalfCount++;
			}

			if (this.checkRemoveHalfCount != this.world.players.Count)
			{
				throw new ArgumentException(rm.GetString(language + "SomethingWrong"));
			}
		}

		private List<Player> robPlayers()
		{
			List<Player> playersToRob = new List<Player>(3);

			foreach (Player p in this.robberHex.owners)
			{
				if (p != this.world.currentPlayer)
				{
					playersToRob.Add(p);
				}
			}
			return playersToRob;
		}

		private void BuyDevCardButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.world.currentPlayer.tradeForDevCard();
				this.updateResourceLabels();
				this.updateDevelopmentCards();
			}
			catch (ArgumentException ex)
			{
				DialogResult num = MessageBox.Show(ex.Message,
					rm.GetString(language + "InsufficientResources"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
		}

		private void removeRobberText()
		{
			this.robberHex = this.world.getRobberHex();

			for (int i = 0; i < 5; i++)
			{
				for (int j = 1; j < 4; j++)
				{
					if (this.hexGrid[i][j].getHex() != this.world.getRobberHex())
					{
						this.hexGrid[i][j].setHasRobber(false);
					}
				}
			}

			// check outliers: [1][0], [2][0], [3][0], [2][4]
			for (int i = 1; i < 4; i++)
			{
				if (this.hexGrid[i][0].getHex() != this.world.getRobberHex())
				{
					this.hexGrid[i][0].setHasRobber(false);
				}
			}

			if (this.hexGrid[2][4].getHasRobber())
			{
				if (this.hexGrid[2][4].getHex() != this.world.getRobberHex())
				{
					this.hexGrid[2][4].setHasRobber(false);
				}
			}
			//this.Refresh();
		}

		public void updateDevelopmentCards()
		{
			if (this.world.currentPlayer.playerHand.devCardsContains("knight"))
				this.KnightsDevCardLabel.Show();
			else
				this.KnightsDevCardLabel.Hide();

			if (this.world.currentPlayer.playerHand.devCardsContains("monopoly"))
				this.MonopolyDevCardLabel.Show();
			else
				this.MonopolyDevCardLabel.Hide();

			if (this.world.currentPlayer.playerHand.devCardsContains("victoryPoint"))
				this.VictoryPointDevCardLabel.Show();
			else
				this.VictoryPointDevCardLabel.Hide();

			if (this.world.currentPlayer.playerHand.devCardsContains("roadBuilder"))
				this.RoadBuilderDevCardLabel.Show();
			else
				this.RoadBuilderDevCardLabel.Hide();

			if (this.world.currentPlayer.playerHand.devCardsContains("yearOfPlenty"))
				this.YearOfPlentyDevCardLabel.Show();
			else
				this.YearOfPlentyDevCardLabel.Hide();
		}

		private void KnightsDevCardLabel_Click(object sender, EventArgs e)
		{
			try
			{
				this.world.currentPlayer.playDevCard("knight", null, null);
				removeRobberText();
				this.world.setPlaceRobber(true);
				RobberForm myForm = new RobberForm(this.world, this);
				myForm.Show();
				this.updateDevelopmentCards();
			}
			catch (ArgumentException ex)
			{
			}
		}

		private void VictoryPointDevCardLabel_Click(object sender, EventArgs e)
		{
			try
			{
				this.world.currentPlayer.playDevCard("victoryPoint", null, null);
				this.updatePlayerPoints();
				this.updateDevelopmentCards();
			}
			catch (ArgumentException ex)
			{
			}
		}

		private void MonopolyDevCardLabel_Click(object sender, EventArgs e)
		{
			try
			{
				MonopolyForm myForm = new MonopolyForm(this.world, this);
				myForm.Show();
			}
			catch (ArgumentException ex)
			{
			}
		}

		private void RoadBuilderDevCardLabel_Click(object sender, EventArgs e)
		{
			try
			{
				this.world.currentPlayer.playDevCard("roadBuilder", null, null);
				Form myForm = new RoadBuilderForm();
				myForm.Show();
				this.updateDevelopmentCards();
			}
			catch (ArgumentException ex)
			{
			}
		}

		private void YearOfPlentyDevCardLabel_Click(object sender, EventArgs e)
		{
			try
			{
				YearOfPlentyForm myForm = new YearOfPlentyForm(this.world, this);
				myForm.Show();
			}
			catch (ArgumentException ex)
			{
			}
		}

		private void updatePlayerPoints()
		{
			this.PointsAmountLabel.Text = this.world.currentPlayer.getPoints().ToString();
			checkWinner();
		}

		private void checkWinner()
		{
			if (this.world.checkWinner())
			{
				WinForm myForm = new WinForm();
				myForm.Show();
			}
		}

		private void BankTradeButton_Click(object sender, EventArgs e)
		{
			BankTradeForm myForm = new BankTradeForm(this.world, this);
			myForm.Show();
		}
	}
}