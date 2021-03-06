﻿using Boggle.Shared.DataModels;
using Boggle.Shared.Interfaces;
using Boggle.Shared.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTests.ModelTests
{
    [TestFixture]
    public class BoggleSharedTests
    {
        public Mock<IDataService> dataServiceMock;

        [SetUp]
        public void Setup()
        {
            dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(a => a.GetAllPlayers()).Returns(new List<Player>()
            {
                new Player(){Name = "Superman"}
            });

            dataServiceMock.Setup(a => a.GetAllGames()).Returns(new List<Game>()
            {
                new Game(){Score = 10294, PlayerId = 0}
            });
        }

        [Test]
        public void TestDataServiceGetPlayers()
        {           
            var vm = new MainScreenViewModel(new MainViewModel(), dataServiceMock.Object);

            Assert.AreEqual(vm.Players[0].Name, "Superman");
        }

        [Test]
        public void TestDataServiceGetGames()
        {
            var vm = new MainScreenViewModel(new MainViewModel(), dataServiceMock.Object);

            Assert.AreEqual(vm.GamesList[0].Score, 10294);
        }
    }
}
