using Boggle.Shared.Interfaces;
using Boggle.Shared.Models;
using Boggle.Shared.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests.ViewModelTests
{
    [TestFixture]
    public class HighScoresViewModelTests
    {
        public HighScoresViewModel vm;
        public Mock<IDataService> dataService;

        [SetUp]
        public void Setup()
        {
            dataService = new Mock<IDataService>();
            dataService.Setup(a => a.GetPlayerScores()).Returns(
                new List<PlayerScore>() { new PlayerScore() { Score = 1000, Username = "Batman" },
                new PlayerScore() { Score = 120, Username = "Spiderman" }});
            vm = new HighScoresViewModel(new MainViewModel(), dataService.Object);
        }

        [Test]
        public void TestHighScoresAreReturnedCorrectly()
        {
            PlayerScore expectedScore = new PlayerScore() { Score = 1000, Username = "Batman" };

            Assert.IsTrue(expectedScore.Score == vm.ListOfHighScores.First().Score
                && expectedScore.Username == vm.ListOfHighScores.First().Username);
        }
    }
}
