using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SettlersOfCatan;
using System.Reflection;
using System.Drawing;

namespace ClassLibrary1
{
    class ResourceHexPictureBoxTest
    {
        [Test()]
        public void TestResourceHexPictureBoxInitializesCorrectly()
        {
            var target = new ResourceHexPictureBox();
            Assert.NotNull(target);

            var target2 = new ResourceHexPictureBox("Wool");
            Assert.NotNull(target);
        }

        [Test()]
        public void TestResourceHexPictureBoxWithoutParameterSetsFields()
        {
            var target = new ResourceHexPictureBox();
            Assert.NotNull(typeof(ResourceHexPictureBox).GetField("resourceType", BindingFlags.NonPublic | BindingFlags.Instance));
            Assert.NotNull(typeof(ResourceHexPictureBox).GetField("size", BindingFlags.NonPublic | BindingFlags.Instance));
            Assert.NotNull(typeof(ResourceHexPictureBox).GetField("BackColor", BindingFlags.NonPublic | BindingFlags.Instance));
        }

        [Test()]
        public void TestResourceHexPictureBoxWithParameterSetsFields()
        {
            var target = new ResourceHexPictureBox("Wool");
            Assert.NotNull(typeof(ResourceHexPictureBox).GetField("resourceType", BindingFlags.NonPublic | BindingFlags.Instance));
            Assert.NotNull(typeof(ResourceHexPictureBox).GetField("size", BindingFlags.NonPublic | BindingFlags.Instance));
            Assert.NotNull(typeof(ResourceHexPictureBox).GetField("BackColor", BindingFlags.NonPublic | BindingFlags.Instance));
        }
    }
}
