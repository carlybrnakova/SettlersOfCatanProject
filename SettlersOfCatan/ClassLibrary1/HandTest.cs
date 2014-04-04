using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;


namespace ClassLibrary1
{
    [TestFixture()]
    class HandTest
    {

        Hand hand1 = new Hand();
        [Test()]
        public void testConstructor()
        {
            var hand = new Hand();
            Assert.NotNull(hand);
        }

        //tests for when the resources are at 0
        [Test()]
        public void testOreAt0()
        {
            Assert.AreEqual(0, hand1.getOre());
        }

        [Test()]
        public void testWoolAt0()
        {
            Assert.AreEqual(0, hand1.getWool());
        }

        [Test()]
        public void testLumberAt0()
        {
            Assert.AreEqual(0, hand1.getLumber());
        }

        [Test()]
        public void testGrainAt0()
        {
            Assert.AreEqual(0, hand1.getGrain());
        }

        [Test()]
        public void testBrickAt0()
        {
            Assert.AreEqual(0, hand1.getBrick());
        }

        //tests for when the resources are modified positively
        [Test()]
        public void testModifyOrePos()
        {
            hand1.modifyOre(5);
            Assert.AreEqual(5, hand1.getOre());
        }

        [Test()]
        public void testModifyWoolPos()
        {
            hand1.modifyOre(5);
            Assert.AreEqual(5, hand1.getWool());
        }

        [Test()]
        public void testModifyLumberPos()
        {
            hand1.modifyOre(5);
            Assert.AreEqual(5, hand1.getLumber());
        }

        [Test()]
        public void testModifyGrainPos()
        {
            hand1.modifyOre(5);
            Assert.AreEqual(5, hand1.getGrain());
        }

        [Test()]
        public void testModifyBrickPos()
        {
            hand1.modifyOre(5);
            Assert.AreEqual(5, hand1.getBrick());
        }

        //tests for when the resouces are modified negetively
        [Test()]
        public void testModifyOreNeg()
        {
            hand1.modifyOre(-3);
            Assert.AreEqual(2, hand1.getOre());
        }

        [Test()]
        public void testModifyWoolNeg()
        {
            hand1.modifyOre(-3);
            Assert.AreEqual(2, hand1.getWool());
        }

        [Test()]
        public void testModifyLumberNeg()
        {
            hand1.modifyOre(-3);
            Assert.AreEqual(2, hand1.getLumber());
        }

        [Test()]
        public void testModifyGrainNeg()
        {
            hand1.modifyOre(-3);
            Assert.AreEqual(2, hand1.getGrain());
        }

        [Test()]
        public void testModifyBrickNeg()
        {
            hand1.modifyOre(-3);
            Assert.AreEqual(2, hand1.getBrick());
        }

        //tests for when the resources are modified to go negetive.
        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void testModifyOreNegResult()
        {
            hand1.modifyOre(-5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void testModifyWoolNegResult()
        {
            hand1.modifyOre(-5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void testModifyLumberNegResult()
        {
            hand1.modifyOre(-5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void testModifyGrainNegResult()
        {
            hand1.modifyOre(-5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void testModifyBrickNegResult()
        {
            hand1.modifyOre(-5);
        }
    }
}
