using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NUnit.Framework;
using SettlersOfCatan;

namespace ClassLibrary1
{
    class MainMenuTest
    {
        [Test()]
        public void TestMainMenuInitializesProperly()
        {
            var target = new SettlersOfCatan.MainMenu();
            Assert.NotNull(target);
        }

        //[Test()]
        //public void Test
    }
}
