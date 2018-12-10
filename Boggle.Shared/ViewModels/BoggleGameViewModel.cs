﻿using Boggle.Shared.Interfaces;
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
        private IBoggleGame _theGame;
        public IBoggleGame TheGame { get => _theGame; set => Set(ref _theGame, value); }

        private string _userGuess;
        public string UserGuess { get => _userGuess; set => Set(ref _userGuess, value); }

        public string Username;

        public BoggleGameViewModel(MainViewModel mainViewModel, IDataService dataService)
        {
            UserGuess = "";            
            mainView = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
            TheGame = mainView.TheGame;
            this.dataService = dataService;
        }

        public BoggleGameViewModel(MainViewModel mainViewModel, IDataService dataService, string username) :this(mainViewModel,dataService)
        {
            Username = username;
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
                mainView.TheGame = new BoggleGame(Username);
                mainView.BoggleGameViewModel = new BoggleGameViewModel(mainView, dataService);
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

        private RelayCommand _submitGuessCommand;
        public RelayCommand SubmitGuessCommand => _submitGuessCommand ?? (_submitGuessCommand = new RelayCommand(
            () =>
            {
                if (UserGuess != "")
                {
                    TheGame.SubmitGuess(UserGuess.Trim());
                    UserGuess = "";
                }
            }));

        //private RelayCommand _submitGuessCommand;
        //public RelayCommand SubmitGuessCommand => _submitGuessCommand ?? (_submitGuessCommand = new RelayCommand(
        //    () =>
        //    {
        //        //Ask user the confirm
        //        if (UserGuess?.Equals("");
        //        //clean up game here
        //    }));
    }
}
