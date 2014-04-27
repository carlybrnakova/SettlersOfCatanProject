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



        public ResourceHexPictureBox()
        {
            resourceType = "None";
            //this.BackColor = Color.FromArgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));
            this.BackColor = Color.Gold;
            this.Size = HEX_SIZE;
        }

        public ResourceHexPictureBox(String type)
        {
            resourceType = type;
            //this.BackColor = Color.FromArgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));
            this.BackColor = Color.Gold;
            this.Size = HEX_SIZE;
        }

        public ResourceHexPictureBox(Color color)
        {
            resourceType = "None";
            //this.BackColor = Color.FromArgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));
            this.BackColor = color;
            this.Size = HEX_SIZE;
        }

    }
}
