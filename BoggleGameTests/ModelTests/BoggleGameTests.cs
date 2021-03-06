﻿using Boggle.Shared.Models;
using NUnit.Framework;
using System;

namespace UnitTests.ModelTests
{
    [TestFixture]
    public class BoggleGameTests
    {
        public BoggleGame BoggleGame;

        [SetUp]
        public void Setup()
        {
            BoggleGame = new BoggleGame("FakeGame");
        }

        [TestCase("Hi", 0)]
        [TestCase("we", 0)]
        [TestCase(".-", 0)]
        public void Test2LetterScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            BoggleGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, BoggleGame.Score);
        }

        [TestCase("pig", 1)]
        [TestCase("cat", 1)]
        [TestCase("Hi!", 0)]
        public void Test3LetterScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            BoggleGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, BoggleGame.Score);
        }

        [TestCase("bear", 1)]
        [TestCase("home", 1)]
        [TestCase("four", 1)]
        public void Test4LetterScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            BoggleGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, BoggleGame.Score);
        }

        [TestCase("start", 2)]
        [TestCase("liter", 2)]
        public void Test5LetterScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            BoggleGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, BoggleGame.Score);
        }

        [TestCase("boring", 3)]
        [TestCase("letter", 3)]
        public void Test6LettersScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            BoggleGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, BoggleGame.Score);
        }

        [TestCase("discuss", 4)]
        [TestCase("adapter", 4)]
        public void Test7LettersScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            BoggleGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, BoggleGame.Score);
        }

        [TestCase("dictionary", 11)]
        [TestCase("solution", 11)]
        public void Test8LettersScoreIsCalulatedCorrectly(string word, int expectedScore)
        {
            BoggleGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, BoggleGame.Score);
        }

        [TestCase("dictionaries", 11)]
        [TestCase("solutions", 11)]
        public void Test8PlusLettersScoreIsCalulatedCorrectly(string word, int expectedScore)
        {
            BoggleGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, BoggleGame.Score);
        }        

        [TestCase("two", 1)]
        [TestCase("word", 1)]
        [TestCase("three", 2)]
        [TestCase("sevens", 3)]
        [TestCase("duplication", 11)]
        public void TestThatNoPointsAreAddedForDuplicateWords(string word, int expectedScore)
        {
            BoggleGame.SubmitGuess(word);
            BoggleGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, BoggleGame.Score);
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

        [Test]
        public void TestThatGameOverFlagIsSetWhenTimeIsUp()
        {
            BoggleGame.RemainingTime = TimeSpan.Zero;          
            Assert.IsTrue(BoggleGame.IsGameOver);
        }
    }
}
