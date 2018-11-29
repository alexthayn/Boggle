using Boggle.Shared.Interfaces;
using Boggle.Shared.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;

namespace Boggle.Shared.ViewModels
{
    public class BoggleGameViewModel : ViewModelBase
    {
        private readonly MainViewModel mainView;
        private readonly IDataService dataService;
        public IBoggleGame TheGame;

        public List<string> _listOfGuesses;
        public List<string> ListOfGuesses
        {
            get => _listOfGuesses;
            set => Set(ref _listOfGuesses, value);
        }

        public string Username;

        public BoggleGameViewModel(MainViewModel mainViewModel, IBoggleGame boggleGame, IDataService dataService)
        {
            mainView = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
            TheGame = boggleGame;
            this.dataService = dataService;
            //Dummy data for testing UI remove later*******************************************************************
            ListOfGuesses = new List<string>() { "hello", "goodbye", "garden","end","begun","area","bear","thick",
                                                    "attention","swept","planned","evidence","salt","liquid",
                                                    "unit","climate","war","pan","twelve","shine",
                                                    "out","again","arrangement","believed","down","energy",
                                                    "family","felt","pen","feet","grass","bone",
                                                    "trouble","too","same","wolf","grass","book",
                                                    "unit","fuel","flag","health","though","heat" };
        }

        public BoggleGameViewModel(MainViewModel mainViewModel, IBoggleGame boggleGame, IDataService dataService, string username) :this(mainViewModel,boggleGame,dataService)
        {
            Username = username;
            TheGame.NewGame(Username);
        }

        private RelayCommand _backToMain;
        public RelayCommand BackToMain => _backToMain ?? (_backToMain = new RelayCommand(
            () =>
            {
                mainView.ChildViewModel = mainView.MainScreenViewModel;
            }));

        private RelayCommand _howToPlayCommand;
        public RelayCommand HowToPlayCommand => _howToPlayCommand ?? (_howToPlayCommand = new RelayCommand(
            () =>
            {
                //Ask user the confirm
                mainView.PreviousViewModel = this;
                mainView.ChildViewModel = mainView.HowToPlayViewModel;
            }));

        private RelayCommand _exitProgramCommand;
        public RelayCommand ExitProgramCommand => _exitProgramCommand ?? (_exitProgramCommand = new RelayCommand(
            () =>
            {
                //Ask user the confirm
                Environment.Exit(0);
            }));

        private RelayCommand _newGameCommand;
        public RelayCommand NewGameCommand => _newGameCommand ?? (_newGameCommand = new RelayCommand(
            () =>
            {
                //Ask user the confirm
                mainView.ChildViewModel = mainView.BoggleGameViewModel;
            }));

        private RelayCommand _endGameCommand;
        public RelayCommand EndGameCommand => _endGameCommand ?? (_endGameCommand = new RelayCommand(
            () =>
            {
                //Ask user the confirm
                mainView.ChildViewModel = mainView.MainScreenViewModel;
                //clean up game here
            }));
    }
}
