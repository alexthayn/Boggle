using Boggle.Shared.ViewModels;
using NUnit.Framework;

namespace UnitTests.ViewModelTests
{
    [TestFixture]
    public class BoggleGameViewModelTests
    {
        public MainViewModel mainVM;

        [SetUp]
        public void Setup()
        {
            mainVM = new MainViewModel();       
        }

        [Test]
        public void TestUsernameIsPassedToBoggleGameViewModel()
        {
            mainVM.MainScreenViewModel.Username = "Pancake";
            mainVM.MainScreenViewModel.NewGameCommand.Execute(null);

            Assert.AreEqual("Pancake",mainVM.BoggleGameViewModel.Username);
        }

        [Test]
        public void TestUsernameIsResetWhenUserChangesNameAndStartsNewGame()
        {
            mainVM.MainScreenViewModel.Username = "First";

            //Start Game
            mainVM.MainScreenViewModel.NewGameCommand.Execute(null);
            //End Game
            mainVM.BoggleGameViewModel.EndGameCommand.Execute(null);
            //Reset username
            mainVM.MainScreenViewModel.Username = "Second";
            //Start game
            mainVM.MainScreenViewModel.NewGameCommand.Execute(null);

            Assert.AreEqual("Second",mainVM.BoggleGameViewModel.Username);
        }
    }
}
