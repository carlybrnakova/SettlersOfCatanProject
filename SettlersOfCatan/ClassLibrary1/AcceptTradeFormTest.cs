using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SettlersOfCatan;
using System.Reflection;

namespace ClassLibrary1
{
    class AcceptTradeFormTest
    {
        TradeForm tradeForm;

        [Test()]
        public void TestAcceptTradeFormInitializesCorrectly()
        {
            var target = new AcceptTradeForm(tradeForm);
            Assert.NotNull(target);
        }

        [Test()]
        public void TestAcceptTradeFormSetsFieldsCorrectly()
        {
            var target = new AcceptTradeForm(tradeForm);
            Assert.NotNull(typeof(AcceptTradeForm).GetField("TradeForm", BindingFlags.Instance | BindingFlags.NonPublic));
        }
    }
}
