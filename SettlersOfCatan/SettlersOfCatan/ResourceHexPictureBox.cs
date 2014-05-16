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

		public ResourceHexPictureBox()
		{
			resourceType = "None";
			this.hasRobber = false;
			this.BackColor = Color.Gold;
			this.Size = HEX_SIZE;
			this.Paint += pictureBox_Paint;
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
				this.Paint += pictureBox_Paint;
				this.isDoubleClick = false;
				this.isFirstClick = true;
			}
		}

		public void paintBlack()
		{
			this.Paint -= paintRobber;
			this.Paint -= pictureBox_Paint;
			this.Paint += pictureBox_Paint;
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

		public void pictureBox_Paint(object sender, PaintEventArgs e)
		{
			this.Paint -= paintRobber;
			Font myFont;
			if (this.token == 6 || this.token == 8)
			{
				myFont = new Font("Arial", 30);
			}
			else
			{
				myFont = new Font("Arial", 15);
			}

			e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Black, new Point(60, 55));
		}

		public void paintRobber(object sender, PaintEventArgs e)
		{
			this.Paint -= pictureBox_Paint;
			Font myFont;
			if (this.token == 6 || this.token == 8)
			{
				myFont = new Font("Arial", 30);
			}
			else
			{
				myFont = new Font("Arial", 15);
			}

			e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Red, new Point(60, 55));
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
					Invalidate();
					this.setHasRobber(true);
					this.world.setPlaceRobber(false);
				}
			}
		}

		void doubleClickTimer_Tick(object sender, EventArgs e)
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