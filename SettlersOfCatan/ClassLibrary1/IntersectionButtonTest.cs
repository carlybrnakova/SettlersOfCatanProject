using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ClassLibrary1
{
    class IntersectionButtonTest
    {
        [Test()]
        public void TestIntersectionButtonInitializesCorrectly()
        {
            var target = new IntersectionButton(20, 20);
            Assert.NotNull(target);
        }

        [Test()]
        public void TestIntersectionButtonSetsFieldsCorrectly()
        {
            var target = new IntersectionButton(50, 100);
            Assert.AreEqual(50, target.coordinates.X);
            Assert.AreEqual(100, target.coordinates.Y);
        }
    }
}
