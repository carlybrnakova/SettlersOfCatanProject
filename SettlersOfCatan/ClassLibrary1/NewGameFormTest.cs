using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SettlersOfCatan;

namespace ClassLibrary1
{
    class NewGameFormTest
    {
        [Test()]
        public void TestNewGameFormInitializesCorrectly()
        {
            var target = new NewGameForm();
            Assert.NotNull(target);
        }
    }
}
