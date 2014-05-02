using System;
using NUnit.Framework;
using SettlersOfCatan;
using System.Drawing;
using System.Collections.Generic;


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
        public void TestThatHandHasDevelopmentCardResources_Boundary()
        {
            Hand hand = new Hand();

            // At first it does not have sufficient resources
            Assert.False(hand.hasDevCardResources());

            // Now give it the necessary resources
            hand.modifyWool(1);
            hand.modifyGrain(1);
            hand.modifyOre(1);
            Assert.True(hand.hasDevCardResources());
        }

        [Test()]
        public void TestThatHandHasDevelopmentCardResources_Average()
        {
            Hand hand = new Hand();
            hand.modifyWool(5);
            hand.modifyGrain(5);
            hand.modifyOre(5);
            Assert.True(hand.hasDevCardResources());
        }

        [Test()]
        public void TestThatResourcesGetModified()
        {
            Hand hand = new Hand();
            hand.modifyResources("ore", 3);
            Assert.AreEqual(3, hand.getOre());
            hand.modifyResources("wool", 2);
            Assert.AreEqual(2, hand.getWool());
            hand.modifyResources("lumber", 12);
            Assert.AreEqual(12, hand.getLumber());
            hand.modifyResources("grain", 33);
            Assert.AreEqual(33, hand.getGrain());
            hand.modifyResources("brick", 102);
            Assert.AreEqual(102, hand.getBrick());
        }

        [Test()]
        public void TestIncrementKnightsPlayed()
        {
            var target = new Hand();
            Assert.AreEqual(0, target.getKnights());

            target.incrementKnightsPlayed();
            target.incrementKnightsPlayed();
            Assert.AreEqual(2, target.getKnights());
        }

        [Test()]
        public void TestAddDevCard() 
        {
            var target = new Hand();
            
            List<DevelopmentCard> cards = new List<DevelopmentCard>();
            cards.Add(new Knight());
            cards.Add(new MonopolyCard());
            cards.Add(new VictoryPointCard());
            cards.Add(new RoadBuilderCard());
            cards.Add(new YearOfPlentyCard());

            target.addDevCard(cards);
            
            Assert.AreEqual(5, target.getDevCardCount());
        }

        [Test()]
        public void TestRemoveDevCard() 
        {
            var target = new Hand();

            List<DevelopmentCard> cards = new List<DevelopmentCard>();
            cards.Add(new Knight());
            cards.Add(new MonopolyCard());
            cards.Add(new VictoryPointCard());
            cards.Add(new RoadBuilderCard());
            cards.Add(new YearOfPlentyCard());

            target.addDevCard(cards);

            Assert.AreEqual(5, target.getDevCardCount());

            target.removeDevCard("knight");
            target.removeDevCard("monopoly");
            target.removeDevCard("victoryPoint");
            target.removeDevCard("roadBuilder");
            target.removeDevCard("yearOfPlenty");

            Assert.AreEqual(0, target.getDevCardCount());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveKnightThrowsWhenPlayerHasNoKnights()
        {
            var target = new Hand();
            target.removeDevCard("knight");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveMonoplyThrowsWhenPlayerHasNoMonopolyCards()
        {
            var target = new Hand();
            target.removeDevCard("monopoly");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveVictoryPointThrowsWhenPlayerHasNoVictoryPointCards()
        {
            var target = new Hand();
            target.removeDevCard("victoryPoint");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveYearOfPlentyThrowsWhenPlayerHasNoYearOfPlentyCards()
        {
            var target = new Hand();
            target.removeDevCard("yearOfPlenty");
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveRoadBuilderThrowsWhenPlayerHasNoRoadBuilderCards()
        {
            var target = new Hand();
            target.removeDevCard("roadBuilder");
        }

        [Test()]
        public void TestDevCardsContains()
        {
            var target = new Hand();

            List<DevelopmentCard> cards = new List<DevelopmentCard>();
            cards.Add(new Knight());
            cards.Add(new MonopolyCard());
            cards.Add(new VictoryPointCard());
            cards.Add(new RoadBuilderCard());
            cards.Add(new YearOfPlentyCard());

            target.addDevCard(cards);

            Assert.AreEqual(5, target.getDevCardCount());

            Assert.IsTrue(target.devCardsContains("knight"));
            Assert.IsTrue(target.devCardsContains("monopoly"));
            Assert.IsTrue(target.devCardsContains("victoryPoint"));
            Assert.IsTrue(target.devCardsContains("roadBuilder"));
            Assert.IsTrue(target.devCardsContains("yearOfPlenty"));
        }

        [Test()]
        public void TestDevCardsContainsReturnsFalseWhenCardIsNotInHand()
        {
            var target = new Hand();

            List<DevelopmentCard> knight = new List<DevelopmentCard>();
            knight.Add(new Knight());
            target.addDevCard(knight);
            Assert.IsFalse(target.devCardsContains("monopoly"));

            List<DevelopmentCard> monopoly = new List<DevelopmentCard>();
            monopoly.Add(new MonopolyCard());
            target.addDevCard(monopoly);
            Assert.IsFalse(target.devCardsContains("victoryPoint"));

            List<DevelopmentCard> victoryPoint = new List<DevelopmentCard>();
            victoryPoint.Add(new VictoryPointCard());
            target.addDevCard(victoryPoint);
            Assert.IsFalse(target.devCardsContains("roadBuilder"));

            List<DevelopmentCard> roadBuilder = new List<DevelopmentCard>();
            roadBuilder.Add(new RoadBuilderCard());
            target.addDevCard(roadBuilder);
            Assert.IsFalse(target.devCardsContains("yearOfPlenty"));

            List<DevelopmentCard> yearOfPlenty = new List<DevelopmentCard>();
            yearOfPlenty.Add(new YearOfPlentyCard());
            target.addDevCard(yearOfPlenty);

            target.removeDevCard("knight");
            Assert.IsFalse(target.devCardsContains("knight"));
        }

        [Test()]
        public void TestDevCardsContainsReturnsFalseWhenThereAreNoDevCardsInHand()
        {
            var target = new Hand();
            Assert.IsFalse(target.devCardsContains("buffalo"));
        }

        [Test()]
        public void TestGetResource()
        {
            var target = new Hand();
            target.modifyBrick(2);
            target.modifyGrain(3);
            target.modifyLumber(4);
            target.modifyOre(5);
            target.modifyWool(6);

            Assert.AreEqual(2, target.getResource("brick"));
            Assert.AreEqual(3, target.getResource("grain"));
            Assert.AreEqual(4, target.getResource("lumber"));
            Assert.AreEqual(5, target.getResource("ore"));
            Assert.AreEqual(6, target.getResource("wool"));
        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetResourceThrowsOnInvalidString()
        {
            var target = new Hand();
            target.getResource("ice");
        }
    }
}
