using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SettlersOfCatan;

namespace SettlersOfCatan
{
	public class ResourceHexPictureBox : PictureBox
	{
		private String resourceType;
		private readonly Size HEX_SIZE = new Size(150, 150);
		//private static readonly Random r = new Random();
		private int token;
		private bool hasRobber;
		private Timer doubleClickTimer = new Timer();
		private bool isFirstClick = true;
		private bool isDoubleClick = false;
		private bool clickable = false;
		private int milliseconds = 0;
		private World world;
		private Hex hex = null;
		private Color color = Color.White;

		public ResourceHexPictureBox()
		{
			resourceType = "None";
			this.hasRobber = false;
			this.BackColor = Color.Gold;
			this.Size = HEX_SIZE;
			this.Paint += paintNormal;
		}

		public ResourceHexPictureBox(String type) : this()
		{
			resourceType = type;

			doubleClickTimer.Interval = 100;
			checkDesert();
		}

		public ResourceHexPictureBox(Color color) : this()
		{
			this.BackColor = color;
		}

		public ResourceHexPictureBox(Hex hex, World world) : this()
		{
			resourceType = hex.getResourceType();
			this.BackColor = hex.getColor();
			this.token = hex.getToken();
			this.world = world;
			this.hex = hex;

			doubleClickTimer.Interval = 100;
			checkDesert();
		}

		public ResourceHexPictureBox(World world) : this()
		{
			this.world = world;
		}

		private void checkDesert()
		{
			if (resourceType == "Desert")
			{
				setHasRobber(true);
			}
			else
			{
				setHasRobber(false);
			}
		}

		public Hex getHex()
		{
			return this.hex;
		}

		public void setHasRobber(bool condition)
		{
			this.hasRobber = condition;
			//removePaint();
			if (condition == true)
			{
				this.Paint += paintRobber;
				this.isFirstClick = false;
				this.isDoubleClick = true;
			}
			else
			{
				this.Paint += paintNormal;
				this.isDoubleClick = false;
				this.isFirstClick = true;
				this.hex.setHasRobber(false);
			}
		}

		public bool getHasRobber()
		{
			return this.hasRobber;
		}

		public void setClickable(bool condition)
		{
			this.clickable = condition;
			if (condition == true)
			{
				doubleClickTimer.Tick +=
					new EventHandler(doubleClickTimer_Tick);
				this.MouseDown += new MouseEventHandler(ResourceHex_MouseDown);
			}
			else
			{
				doubleClickTimer.Tick -=
					new EventHandler(doubleClickTimer_Tick);
				this.MouseDown -= new MouseEventHandler(ResourceHex_MouseDown);
			}
		}

		public void paintNormal(object sender, PaintEventArgs e)
		{
			//this.Paint -= paintRobber;
			Font myFont;
			if (this.token == 6 || this.token == 8)
			{
				myFont = new Font("Arial", 30);
			}
			else
			{
				myFont = new Font("Arial", 15);
			}
			e.Graphics.Clear(this.BackColor);
			e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Black, new Point(60, 55));
			this.color = Color.Black;
			//this.hex.setHasRobber(false);
		}

		public void paintRobber(object sender, PaintEventArgs e)
		{
			//this.Paint -= paintNormal;
			Font myFont;
			if (this.color == Color.Black || this.color == Color.White)
			{
				if (this.token == 6 || this.token == 8)
				{
					myFont = new Font("Arial", 30);
				}
				else
				{
					myFont = new Font("Arial", 15);
				}
				e.Graphics.Clear(this.BackColor);
				e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Red, new Point(60, 55));
				this.color = Color.Red;
				this.world.setRobberHex(this.hex);
			}
		}

		// Detect a valid single click or double click. 
		private void ResourceHex_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.world.getPlaceRobber())
			{
				// This is the first mouse click. 
				if (isFirstClick)
				{
					isFirstClick = false;

					// Start the double click timer.
					doubleClickTimer.Start();
				}

					// This is the second mouse click. 
				else
				{
					if (!this.getHasRobber())
					{
						this.setHasRobber(true);
						this.world.setPlaceRobber(false);
						Invalidate();
					}
					else
					{
						DialogResult num = MessageBox.Show("You can't place the Robber on the same hex.",
							"Must Move the Robber",
							MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation);
					}
				}
			}
		}

		private void doubleClickTimer_Tick(object sender, EventArgs e)
		{
			milliseconds += 100;

			// The timer has reached the double click time limit. 
			if (milliseconds >= SystemInformation.DoubleClickTime)
			{
				doubleClickTimer.Stop();

				// Allow the MouseDown event handler to process clicks again.
				isFirstClick = true;
				isDoubleClick = false;
				milliseconds = 0;
			}
		}
	}
}