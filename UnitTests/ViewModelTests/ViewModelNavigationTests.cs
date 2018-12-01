using Boggle.Shared.Interfaces;
using Boggle.Shared.Models;
using Boggle.Shared.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.ViewModelTests
{
    [TestFixture]
    public class ViewModelNavigationTests
    {
        public MainViewModel mvm;
        public MainScreenViewModel msvm;
        public BoggleGameViewModel bgvm;

        [SetUp]
        public void Setup()
        {
            mvm = new MainViewModel();
            msvm = new MainScreenViewModel(mvm, new Mock<IDataService>().Object);
            bgvm = new BoggleGameViewModel(mvm, new Mock<IDataService>().Object);
        }
      
        // Main Screen Navigation        
        [Test]
        public void TestNewGameCommandNavigationFromMainScreen()
        {
            msvm.NewGameCommand.Execute(null);

            Assert.AreEqual(mvm.BoggleGameViewModel, mvm.ChildViewModel);
        }

        [Test]
        public void TestHighScoreCommandNavigationFromMainScreen()
        {
            msvm.HighScoresCommand.Execute(null);

            Assert.AreEqual(mvm.HighScoresViewModel, mvm.ChildViewModel);
        }

        [Test]
        public void TestHowToPlayCommandNavigationFromMainScreen()
        {
            msvm.HowToPlayCommand.Execute(null);

            Assert.AreEqual(mvm.HowToPlayViewModel, mvm.ChildViewModel);
        }

        // Game mode navigation
        [Test]
        public void TestNewGameCommandNavigationFromGameScreen()
        {
            bgvm.NewGameCommand.Execute(null);

            Assert.AreEqual(mvm.BoggleGameViewModel, mvm.ChildViewModel);
        }

        [Test]
        public void TestHowToPlayCommandNavigationFromGameScreen()
        {
            bgvm.HowToPlayCommand.Execute(null);

            Assert.AreEqual(mvm.HowToPlayViewModel, mvm.ChildViewModel);
        }
    }
}
