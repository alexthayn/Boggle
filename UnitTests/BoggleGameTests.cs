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
            int scoreReturned = BoggleGame.CalculateWordScore("dictionary");
            Assert.AreEqual(11, scoreReturned);
        }
    }
}
