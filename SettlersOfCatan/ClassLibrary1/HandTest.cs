using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;


namespace ClassLibrary1
{
    [TestFixture()]
    class HandTest
    {
        Hand hand0 = new Hand();
        Hand hand1 = new Hand();
        Hand hand2 = new Hand();
        Hand hand3 = new Hand();
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
            Assert.AreEqual(0, hand0.getOre());
        }

        [Test()]
        public void testWoolAt0()
        {
            Assert.AreEqual(0, hand0.getWool());
        }

        [Test()]
        public void testLumberAt0()
        {
            Assert.AreEqual(0, hand0.getLumber());
        }

        [Test()]
        public void testGrainAt0()
        {
            Assert.AreEqual(0, hand0.getGrain());
        }

        [Test()]
        public void testBrickAt0()
        {
            Assert.AreEqual(0, hand0.getBrick());
        }

        [Test()]
        public void testGetResourcesAt0()
        {
            Assert.AreEqual(0, hand0.getResources());
        }

        [Test()]
        public void testGetKnightsAt0()
        {
            Assert.AreEqual(0, hand0.getKnights());
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
            hand1.modifyWool(5);
            Assert.AreEqual(5, hand1.getWool());
        }

        [Test()]
        public void testModifyLumberPos()
        {
            hand1.modifyLumber(5);
            Assert.AreEqual(5, hand1.getLumber());
        }

        [Test()]
        public void testModifyGrainPos()
        {
            hand1.modifyGrain(5);
            Assert.AreEqual(5, hand1.getGrain());
        }

        [Test()]
        public void testModifyBrickPos()
        {
            hand1.modifyBrick(5);
            Assert.AreEqual(5, hand1.getBrick());
        }

        //tests for when the resouces are modified negetively
        [Test()]
        public void testModifyOreNeg()
        {
            hand2.modifyOre(5);
            Assert.AreEqual(5, hand2.getOre());
            hand2.modifyOre(-3);
            Assert.AreEqual(2, hand2.getOre());
        }

        [Test()]
        public void testModifyWoolNeg()
        {
            hand2.modifyWool(5);
            hand2.modifyWool(-3);
            Assert.AreEqual(2, hand2.getWool());
        }

        [Test()]
        public void testModifyLumberNeg()
        {
            hand2.modifyLumber(5);
            hand2.modifyLumber(-3);
            Assert.AreEqual(2, hand2.getLumber());
        }

        [Test()]
        public void testModifyGrainNeg()
        {
            hand2.modifyGrain(5);
            hand2.modifyGrain(-3);
            Assert.AreEqual(2, hand2.getGrain());
        }

        [Test()]
        public void testModifyBrickNeg()
        {
            hand2.modifyBrick(5);
            hand2.modifyBrick(-3);
            Assert.AreEqual(2, hand2.getBrick());
        }

        //tests for when the resources are modified to go negetive.
        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void testModifyOreNegResult()
        {
            hand3.modifyOre(-5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void testModifyWoolNegResult()
        {
            hand3.modifyWool(-5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void testModifyLumberNegResult()
        {
            hand3.modifyLumber(-5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void testModifyGrainNegResult()
        {
            hand3.modifyGrain(-5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void testModifyBrickNegResult()
        {
            hand3.modifyBrick(-5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestModifyDevCardNegResult()
        {
            hand3.modifyDevCard(-1);
        }
    }
}
