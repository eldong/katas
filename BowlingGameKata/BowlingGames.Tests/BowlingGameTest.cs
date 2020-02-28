using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGameKata;

namespace BowlingGames.Tests
{
    [TestClass]
    public class BowlingGameTest
    {

  

        public BowlingGameTest()
        {
            //Sg = new BowlingGame();
        }

        private void rollMany(BowlingGame g, int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        private void rollSpare(BowlingGame g)
        {
            g.Roll(6);
            g.Roll(4);
        }

        [TestMethod]
        public void TestBowlingGameClass()
        {
            BowlingGame g = new BowlingGame();
            Assert.IsInstanceOfType(g, typeof(BowlingGame));
        }

        [TestMethod]
        public void TestGutterGame()
        {
            // Arrange 
            BowlingGame g = new BowlingGame();

            // Act
            rollMany(g, 20, 0);
            
            // Asset
            Assert.AreEqual(0, g.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            // Arrange 
            BowlingGame g = new BowlingGame();

            // Act
            rollMany(g, 20, 1);

            // Assert
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            // Arrange 
            BowlingGame g = new BowlingGame();

            rollSpare(g);
            g.Roll(4);
            rollMany(g, 17, 0);
            Assert.AreEqual(18, g.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            // Arrange 
            BowlingGame g = new BowlingGame(); 
            
            // Act
            g.Roll(10);
            g.Roll(4);
            g.Roll(5);
            rollMany(g, 17, 0);

            // Assert
            Assert.AreEqual(28, g.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            // Arrange 
            BowlingGame g = new BowlingGame();

            // Act
            rollMany(g, 12, 10);

            // Assert
            Assert.AreEqual(300, g.Score());
        }

        [TestMethod]
        public void TestRandomGameNoExtraRoll()
        {
            // Arrange 
            BowlingGame g = new BowlingGame();

            // Act
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });

            // Assert
            Assert.AreEqual(131, g.Score());
        }

        [TestMethod]
        public void TestRandomGameWithSpareThenStrikeAtEnd()
        {
            // Arrange 
            BowlingGame g = new BowlingGame();

            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.AreEqual(143, g.Score());
        }

        [TestMethod]
        public void TestRandomGameWithThreeStrikesAtEnd()
        {
            // Arrange 
            BowlingGame g = new BowlingGame();

            // Act
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });

            // Assert
            Assert.AreEqual(163, g.Score());
        }


    }
}
