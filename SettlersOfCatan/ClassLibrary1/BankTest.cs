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
            target.modifyResource("devcard", -1);
            Assert.AreEqual(target.getDevCardRemaining(), 24);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyOreThrowsWhenLessThanZero()
        {
            var target = new Bank();
            target.modifyResource("ore", -20);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyWoolThrowsWhenLessThanZero()
        {
            var target = new Bank();
            target.modifyResource("wool", -30);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyLumberThrowsWhenLessThanZero()
        {
            var target = new Bank();
            target.modifyResource("lumber", -25);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyGrainThrowsWhenLessThanZero()
        {
            var target = new Bank();
            target.modifyResource("grain", -55);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyBrickThrowsWhenLessThanZero()
        {
            var target = new Bank();
            target.modifyResource("brick", -160);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyOreThrowsWhenGreaterThan19()
        {
            var target = new Bank();
            target.modifyResource("ore", 2);
        }
       
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyWoolThrowsWhenGreaterThan19()
        {
            var target = new Bank();
            target.modifyResource("wool", 21);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyLumberThrowsWhenGreaterThan19()
        {
            var target = new Bank();
            target.modifyResource("lumber", 1);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyGrainThrowsWhenGreaterThan19()
        {
            var target = new Bank();
            target.modifyResource("grain", 7);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyBrickThrowsWhenGreaterThan19()
        {
            var target = new Bank();
            target.modifyResource("brick", 35);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestModifyDevCardThrowsWhenLessThanOrEqualToZero()
        {
            var target = new Bank();
            target.modifyResource("devcard", -25);
            target.modifyResource("devcard", -1);
        }

    }
}
