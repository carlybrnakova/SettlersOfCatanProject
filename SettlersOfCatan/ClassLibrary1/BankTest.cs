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
            Bank target = new Bank();
            Assert.True(target.allResourcesMax());
        }

        [Test()]
        public void TestGetResourceRemaining()
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestThatGetResourceThrowsOnBadString()
        {
            var target = new Bank();
            target.getResourceRemaining("water");
        }

        [Test()]
        public void TestModifyResource()
        {
            var target = new Bank();
            target.modifyResource("ore", -2);
            Assert.AreEqual(target.getResourceRemaining("ore"), 17);
            target.modifyResource("wool", -10);
            Assert.AreEqual(target.getResourceRemaining("wool"), 9);
            target.modifyResource("lumber", -19);
            Assert.AreEqual(target.getResourceRemaining("lumber"), 0);
            target.modifyResource("grain", -19);
            target.modifyResource("grain", 5);
            Assert.AreEqual(target.getResourceRemaining("grain"), 5);
            target.modifyResource("brick", -19);
            target.modifyResource("brick", 19);
            Assert.AreEqual(target.getResourceRemaining("brick"), 19);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestModifyResourceThrowsOnBadString()
        {
            var target = new Bank();
            target.modifyResource("fire", 5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyResourceThrowsWhenLessThanZero()
        {
            var target = new Bank();
            target.modifyResource("brick", -20);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyResourceThrowsWhenGreaterThan19()
        {
            var target = new Bank();
            target.modifyResource("ore", 2);
        }
    }
}
