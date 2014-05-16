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
		

		public ResourceHexPictureBox()
		{
			resourceType = "None";
			this.hasRobber = false;
			//this.BackColor = Color.FromArgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));
			this.BackColor = Color.Gold;
			this.Size = HEX_SIZE;
			this.Paint += pictureBox_Paint;
		}

		public ResourceHexPictureBox(String type)
		{
			resourceType = type;
			//this.BackColor = Color.FromArgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));
			this.BackColor = Color.Gold;
			this.Size = HEX_SIZE;
			this.Paint += pictureBox_Paint;

			doubleClickTimer.Interval = 100;

			if (resourceType == "Desert")
			{
				setHasRobber(true);
			}
			else
			{
				setHasRobber(false);
			}
		}

		public ResourceHexPictureBox(Color color)
		{
			resourceType = "None";
			this.hasRobber = false;
			//this.BackColor = Color.FromArgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));
			this.BackColor = color;
			this.Size = HEX_SIZE;
			this.Paint += pictureBox_Paint;
		}

		public ResourceHexPictureBox(Hex hex)
		{
			resourceType = hex.getResourceType();
			//this.BackColor = Color.FromArgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));
			this.BackColor = hex.getColor();
			this.token = hex.getToken();
			this.Size = HEX_SIZE;
			this.Paint += pictureBox_Paint;

			doubleClickTimer.Interval = 100;

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

		private void pictureBox_Paint(object sender, PaintEventArgs e)
		{
			this.Paint -= paintRobber;
			Font myFont;
			if (this.token == 6 || this.token == 8)
			{
				myFont = new Font("Arial", 30);
				e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Black, new Point(55, 55));
			}
			else if (this.token >= 10)
			{
				myFont = new Font("Arial", 15);
				e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Black, new Point(61, 59));
			}
			else
			{
				myFont = new Font("Arial", 15);
				e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Black, new Point(67, 59));
			}

			//e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Black, new Point(60, 55));
		}

		public void paintRobber(object sender, PaintEventArgs e)
		{
			this.Paint -= pictureBox_Paint;
			Font myFont;
			if (this.token == 6 || this.token == 8)
			{
				myFont = new Font("Arial", 30);
				e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Red, new Point(55, 55));
			}
			else if (this.token >= 10)
			{
				myFont = new Font("Arial", 15);
				e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Red, new Point(61, 59));
			}
			else
			{
				myFont = new Font("Arial", 15);
				e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Red, new Point(67, 59));
			}

			//e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Red, new Point(60, 55));
		}

		/*
		private void placeRobber_SingleClick(object sender, EventArgs e)
		{

		}

		private void placeRobber_DoubleClick(object sender, EventArgs e)
		{
			MouseEventArgs me = e as MouseEventArgs;
			int now = System.Environment.TickCount;
			
			// handle click event
			if (me.Button == MouseButtons.Left)
			{
				DialogResult confirm = MessageBox.Show("Are you sure you want to place the robber here?", "Confirm",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);
				if (confirm == DialogResult.Yes)
				{
					// user clicked yes
					if (getHasRobber() == false)
					{
						setHasRobber(true);
					}
					else
					{
						// already had robber

					}
				}
				else
				{
					// user clicked no

				}
			}
		}

		protected override void OnClick(EventArgs e)
		{
			int now = System.Environment.TickCount;
			// A double-click is detected if the the time elapsed
			// since the last click is within DoubleClickTime.
			if (now - previousClick <= SystemInformation.DoubleClickTime)
			{
				// Raise the DoubleClick event.
				if (DoubleClick != null)
					DoubleClick(this, EventArgs.Empty);
			}
			// Set previousClick to now so that 
			// subsequent double-clicks can be detected.
			previousClick = now;
			// Allow the base class to raise the regular Click event.
			base.OnClick(e);
		}

		// Event handling code for the DoubleClick event.
		protected new virtual void OnDoubleClick(EventArgs e)
		{
			if (this.DoubleClick != null)
				this.DoubleClick(this, e);
		}
		 */

		// Detect a valid single click or double click. 
		void ResourceHex_MouseDown(object sender, MouseEventArgs e)
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
				this.Paint += paintRobber;
				Invalidate();
				isDoubleClick = true;
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