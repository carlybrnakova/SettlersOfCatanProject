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


        public ResourceHexPictureBox()
        {
            resourceType = "None";
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
        }

        public ResourceHexPictureBox(Color color)
        {
            resourceType = "None";
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
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Font myFont;
            if (this.token == 6 || this.token == 8)
            {
                myFont = new Font("Arial", 30);
            }
            else
            {
                myFont = new Font("Arial", 15);
            }

            e.Graphics.DrawString(Convert.ToString(this.token), myFont, Brushes.Black, new Point(55, 55));
        }

    }
}
