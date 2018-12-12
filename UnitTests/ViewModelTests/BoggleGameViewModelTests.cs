using Boggle.Shared.DataModels;
using Boggle.Shared.ViewModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTests.ViewModelTests
{
    [TestFixture]
    public class BoggleGameViewModelTests
    {
        public BoggleGameViewModel vm;

        [SetUp]
        public void Setup()
        {
            vm = new BoggleGameViewModel(new MainViewModel(), new SqliteDataService("Test.db"));
            vm.TheGame.ListOfPossibleAnswers = new List<string>() { "ANSWER" };
        }

        [Test]
        public void TestUsernameIsPassedToBoggleGameViewModel()
        {
            vm.Username = "Pancake";
            vm.NewGameCommand.Execute(null);

            Assert.AreEqual("Pancake",vm.Username);
        }

        [Test]
        public void TestUsernameIsResetWhenUserChangesNameAndStartsNewGame()
        {
            vm.Username = "First";

            //Start Game
            vm.NewGameCommand.Execute(null);
            //End Game
            vm.EndGameCommand.Execute(null);
            //Reset username
            vm.Username = "Second";
            //Start game
            vm.NewGameCommand.Execute(null);

            Assert.AreEqual("Second",vm.Username);
        }
        
        [Test]
        public void TestSubmitGuessCommandClearsTextBox()
        {
            vm.UserGuess = "MyGuess";
            vm.SubmitGuessCommand.Execute(null);
            Assert.AreEqual("", vm.UserGuess);
        }

        [Test]
        public void TestSubmitGuessCommandAddGuessToListOfGuesses()
        {
            vm.UserGuess = "cookies";
            vm.SubmitGuessCommand.Execute(null);
            var Game = vm.TheGame;
            Assert.AreEqual("cookies", Game.ListOfGuesses[0].Guess);
        }

        [Test]
        public void TestGiveHintCommandAddsAWordToTheUserGuess()
        {
            vm.UserGuess = "Spongebob";
            vm.GiveHintCommand.Execute(null);
            Assert.AreEqual(vm.TheGame.ListOfPossibleAnswers[0], vm.UserGuess.ToUpper());
        }
    }
}
