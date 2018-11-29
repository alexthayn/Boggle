using Boggle.Shared.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class BoggleGameTests
    {
        public BoggleGame BoggleGame;

        [SetUp]
        public void Setup()
        {
            BoggleGame = new BoggleGame();
            BoggleGame.NewGame("FakeGame");
        }

        [Test]
        public void Test2LetterScoreIsCalculatedCorrectly()
        {
            int scoreReturned = BoggleGame.CalculateWordScore("Hi");
            Assert.AreEqual(0, scoreReturned);
        }

        [Test]
        public void Test3LetterScoreIsCalculatedCorrectly()
        {
            int scoreReturned = BoggleGame.CalculateWordScore("pig");
            Assert.AreEqual(1, scoreReturned);
        }

        [Test]
        public void Test4LetterScoreIsCalculatedCorrectly()
        {
            int scoreReturned = BoggleGame.CalculateWordScore("bear");
            Assert.AreEqual(1, scoreReturned);
        }

        [Test]
        public void Test5LetterScoreIsCalculatedCorrectly()
        {
            int scoreReturned = BoggleGame.CalculateWordScore("start");
            Assert.AreEqual(2, scoreReturned);
        }

        [Test]
        public void Test6LettersScoreIsCalculatedCorrectly()
        {
            int scoreReturned = BoggleGame.CalculateWordScore("boring");
            Assert.AreEqual(3, scoreReturned);
        }

        [Test]
        public void Test7LettersScoreIsCalculatedCorrectly()
        {
            int scoreReturned = BoggleGame.CalculateWordScore("discuss");
            Assert.AreEqual(4, scoreReturned);
        }

        [Test]
        public void Test8LettersScoreIsCalulatedCorrectly()
        {
            int scoreReturned = BoggleGame.CalculateWordScore("dictionary");
            Assert.AreEqual(11, scoreReturned);
        }

        [Test]
        public void Test8PlusLettersScoreIsCalulatedCorrectly()
        {
            int scoreReturned = BoggleGame.CalculateWordScore("dictionaries");
            Assert.AreEqual(11, scoreReturned);
        }        

        [Test]
        public void TestGameBoardRow0Column0IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[0][0];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row1[0]);
        }

        [Test]
        public void TestGameBoardRow0Column1IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[0][1];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row1[1]);
        }

        [Test]
        public void TestGameBoardRow0Column2IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[0][2];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row1[2]);
        }

        [Test]
        public void TestGameBoardRow0Column3IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[0][3];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row1[3]);
        }

        [Test]
        public void TestGameBoardRow1Column0IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[1][0];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row2[0]);
        }

        [Test]
        public void TestGameBoardRow1Column1IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[1][1];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row2[1]);
        }

        [Test]
        public void TestGameBoardRow1Column2IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[1][2];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row2[2]);
        }

        [Test]
        public void TestGameBoardRow1Column3IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[1][3];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row2[3]);
        }

        [Test]
        public void TestGameBoardRow2Column0IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[2][0];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row3[0]);
        }

        [Test]
        public void TestGameBoardRow2Column1IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[2][1];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row3[1]);
        }

        [Test]
        public void TestGameBoardRow2Column2IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[2][2];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row3[2]);
        }

        [Test]
        public void TestGameBoardRow2Column3IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[2][3];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row3[3]);
        }

        [Test]
        public void TestGameBoardRow3Column0IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[3][0];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row4[0]);
        }

        [Test]
        public void TestGameBoardRow3Column1IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[3][1];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row4[1]);
        }

        [Test]
        public void TestGameBoardRow3Column2IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[3][2];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row4[2]);
        }

        [Test]
        public void TestGameBoardRow3Column3IsSetCorrectly()
        {
            string expectedDieValue = BoggleGame.GameBoard.GameGrid[3][3];

            Assert.AreEqual(expectedDieValue, BoggleGame.Row4[3]);
        }
    }
}
