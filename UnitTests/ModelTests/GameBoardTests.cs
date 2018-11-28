using Boggle.Shared.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.ModelTests
{
    [TestFixture]
    public class GameBoardTests
    {
        public GameBoard Game;

        [SetUp]
        public void Setup()
        {
            Game = new GameBoard();
        }

        [Test]
        public void TestShakeDiceShufflesTheGameGrid()
        {
            Game.ShakeDice();
            string[,] InitialGameGrid = new string[4, 4];
            Game.ShakeDice();

            Assert.AreNotEqual(InitialGameGrid, Game.GameGrid);
        }

    }
}
