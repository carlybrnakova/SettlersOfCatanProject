using System;
using SettlersOfCatan;
using NUnit.Framework;
using System.Drawing;

namespace ClassLibrary1
{
    [TestFixture()]
    class ComputerTest
    {
        [Test()]
        public void TestComputerInitializesCorrectly()
        {
            var target = new Computer();
            Assert.NotNull(target);
        }

        [Test()]
        public void TestComputerConstructsNameAndColorCorrectly()
        {
            String computerName = "computer1";
            Color computerColor = Color.White;
            var world = new World();
            Computer computer1 = new Computer(computerName, computerColor, world);
            Assert.AreEqual(computerColor, computer1.getColor());
            Assert.AreEqual(computerName, computer1.getName());
        }

    }
}
