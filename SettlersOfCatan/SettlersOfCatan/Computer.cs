using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace SettlersOfCatan
{
    public class Computer : Player
    {
        
        public Computer() : base()
        {
        }

        public Computer(String computerName, Color computerColor, World world) : 
            base(computerName, computerColor, world)
        {
        }


    }
}
