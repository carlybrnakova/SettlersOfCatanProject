using System;
using NUnit.Framework;
using SettlersOfCatan;

namespace ClassLibrary1
{
    class BankTest
    {
        [Test()]
        public void TestBankInitializesProperly()
        {
            var target = new Bank();
            Assert.NotNull(target);
        }

        [Test()]
        public void TestConstructorSetsFieldsCorrectly()
        {
            var target = new Bank();
            Assert.AreEqual(target.getResourceRemaining("ore"), 19);
            Assert.AreEqual(target.getResourceRemaining("wool"), 19);
            Assert.AreEqual(target.getResourceRemaining("lumber"), 19);
            Assert.AreEqual(target.getResourceRemaining("grain"), 19);
            Assert.AreEqual(target.getResourceRemaining("brick"), 19);
            Assert.AreEqual(target.getResourceRemaining("devCard"), 25);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThatGetResourcesThrowsOnBadString()
        {
            var target = new Bank();
            target.getResourceRemaining("water");
        }
    }
}
