using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettlersOfCatan;
using NUnit.Framework;

namespace ClassLibrary1
{
    class RulesFormTest
    {
        [Test()]
        public void TestRulesFormConstructsCorrectly()
        {
            var target = new RulesForm();
            Assert.NotNull(target);
        }
    }
}
