using System;
using System.Collections.Generic;
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
            Assert.AreEqual(17, target.getOreRemaining());
            target.modifyResource("wool", -10);
            Assert.AreEqual(9, target.getWoolRemaining());
            target.modifyResource("lumber", -19);
            Assert.AreEqual(0, target.getLumberRemaining());
            target.modifyResource("grain", -19);
            target.modifyResource("grain", 5);
            Assert.AreEqual(5, target.getGrainRemaining());
            target.modifyResource("brick", -19);
            target.modifyResource("brick", 19);
            Assert.AreEqual(19 , target.getBrickRemaining());
        }

        [Test()]
        public void TestDrawDevCard()
        {
            var target = new Bank();
            target.drawDevCard(4);
            Assert.AreEqual(21, target.getDevCardRemaining());
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
        public void TestDrawDevCardThrowsWhenLessThanOrEqualToZero()
        {
            var target = new Bank();
            target.drawDevCard(25);
            target.drawDevCard( 1);
        }

        [Test()]
        public void TestDevCardsAreShuffled()
        {
            var target = new Bank();
            Stack<DevelopmentCard> stack = target.getDevCards();
            Assert.IsTrue(checkShuffled(stack));
        }


        private Boolean checkShuffled(Stack<DevelopmentCard> stack)
        {
            int knights = 0;
            int yearOfPlentyCards = 0;
            int monopolyCards = 0;
            int victoryPointCards = 0;
            int roadBuilderCards = 0;

            String cardType = null;

            for (int i = 0; i <= 24; i++)
            {
                cardType = stack.Pop().getType();

                switch (cardType)
                {
                    case "knight":
                        {
                            knights++;
                            break;
                        }
                    case "yearOfPlenty":
                        {
                            yearOfPlentyCards++;
                            break;
                        }
                    case "monopoly":
                        {
                            monopolyCards++;
                            break;
                        }
                    case "victoryPoint":
                        {
                            victoryPointCards++;
                            break;
                        }
                    case "roadBuilder":
                        {
                            roadBuilderCards++;
                            break;
                        }
                }

                if (knights == 14 && yearOfPlentyCards == 0 && monopolyCards == 0 && victoryPointCards == 0 && roadBuilderCards == 0)
                {
                    return false;
                }
            }

            return knights == 14 && yearOfPlentyCards == 2 && monopolyCards == 2 && victoryPointCards == 5 && roadBuilderCards == 2;
        }
    }
}
