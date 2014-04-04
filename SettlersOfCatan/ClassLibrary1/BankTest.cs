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
            Assert.AreEqual(target.getOreRemaining(), 19);
            Assert.AreEqual(target.getWoolRemaining(), 19);
            Assert.AreEqual(target.getLumberRemaining(), 19);
            Assert.AreEqual(target.getGrainRemaining(), 19);
            Assert.AreEqual(target.getBrickRemaining(), 19);
            Assert.AreEqual(target.getDevCardRemaining(), 25);
        }

        [Test()]
        public void TestModifyResource()
        {
            var target = new Bank();
            target.modifyResource("ore", -2);
            Assert.AreEqual(target.getOreRemaining(), 17);
            target.modifyResource("wool", -10);
            Assert.AreEqual(target.getWoolRemaining(), 9);
            target.modifyResource("lumber", -19);
            Assert.AreEqual(target.getLumberRemaining(), 0);
            target.modifyResource("grain", -19);
            target.modifyResource("grain", 5);
            Assert.AreEqual(target.getGrainRemaining(), 5);
            target.modifyResource("brick", -19);
            target.modifyResource("brick", 19);
            Assert.AreEqual(target.getBrickRemaining(), 19);
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
