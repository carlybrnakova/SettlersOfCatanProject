using System;
using NUnit.Framework;
using SettlersOfCatan;

namespace ClassLibrary1
{
    [TestFixture()]
    public class Class1Test
    {
        [Test()]
        public void TestConstructor()
        {
            Class1 adder = new Class1();
            Assert.NotNull(adder);
        }

        [Test()]
        public void TestAdd()
        {
            Class1 adder = new Class1();
            int i = adder.add(1, 3);
            Assert.AreEqual(4, i);
        }
    }
}
