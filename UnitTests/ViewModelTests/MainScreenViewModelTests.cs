﻿using Boggle.Shared.Interfaces;
using Boggle.Shared.ViewModels;
using Moq;
using NUnit.Framework;

namespace UnitTests.ViewModelTests
{
    [TestFixture]
    public class MainScreenViewModelTests
    {
        public MainScreenViewModel vm;
        
        [SetUp]
        public void Setup()
        {
            vm = new MainScreenViewModel(new MainViewModel(), new Mock<IDataService>().Object);
        }

        [Test]
        public void RefreshUsernameCommandTest()
        {
            vm.Username = "Spongebob";
            vm.RefreshUsernameCommand.Execute(null);
            Assert.AreNotEqual("Spongebob", vm.Username);
        }
    }
}
