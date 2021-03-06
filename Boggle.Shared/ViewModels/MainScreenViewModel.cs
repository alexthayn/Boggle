﻿using Boggle.Shared.DataModels;
using Boggle.Shared.Interfaces;
using Boggle.Shared.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Boggle.Shared.ViewModels
{
    public class MainScreenViewModel : ViewModelBase , IDataErrorInfo
    {
        private readonly IBoggleGame TheGame;
        private readonly MainViewModel mainView;
        private readonly IDataService dataService;

        public List<string> GameLengthList => new List<string>() { "3 Min", "5 Min", "10 Min" };

        public string ThreeMinutes => "3 Min";
        public string FiveMinutes => "5 Min";
        public string TenMinutes => "10 Min";

        public string _gameLengthString;
        public string GameLengthString { get => _gameLengthString; set => Set(ref _gameLengthString, value); }

        public MainScreenViewModel(MainViewModel mainViewModel, IDataService dataService)
        {
            mainView = mainViewModel;
            GameTime = 3;
            GameLengthString = ThreeMinutes;
            this.dataService = dataService;
            TheGame = mainView.TheGame;
            Username = GetRandomUsername();
            GamesList = dataService.GetAllGames().ToList();
            Players = dataService.GetAllPlayers().ToList();
        }

        private RelayCommand _refreshUsernameCommand;
        public RelayCommand RefreshUsernameCommand => _refreshUsernameCommand ?? (_refreshUsernameCommand = new RelayCommand(
            () =>
            {
                mainView.PreviousViewModel = this;
                Username = GetRandomUsername();
            }));

        private RelayCommand _howToPlayCommand;
        public RelayCommand HowToPlayCommand => _howToPlayCommand ?? (_howToPlayCommand = new RelayCommand(
            () =>
            {
                mainView.PreviousViewModel = this;
                mainView.ChildViewModel = mainView.HowToPlayViewModel;
            }));

        private RelayCommand _exitProgramCommand;
        public RelayCommand ExitProgramCommand => _exitProgramCommand ?? (_exitProgramCommand = new RelayCommand(
            () =>
            {
                Environment.Exit(0);
            }));

        private RelayCommand _highScoresCommand;
        public RelayCommand HighScoresCommand => _highScoresCommand ?? (_highScoresCommand = new RelayCommand(
            () =>
            {
                mainView.PreviousViewModel = this;
                mainView.HighScoresViewModel.Update();
                mainView.ChildViewModel = mainView.HighScoresViewModel;
            }));

        private RelayCommand _newGameCommand;
        public RelayCommand NewGameCommand => _newGameCommand ?? (_newGameCommand = new RelayCommand(
            () =>
            {
                mainView.PreviousViewModel = this;
                mainView.TheGame = new BoggleGame(Username, GetGameLength());
                mainView.BoggleGameViewModel = new BoggleGameViewModel(mainView, dataService, Username);
                mainView.ChildViewModel = mainView.BoggleGameViewModel;
            }));

        private string _username;
        public string Username { get => _username; set => Set(ref _username, value); }

        private double _gameTime;
        public double GameTime { get => _gameTime; set => Set(ref _gameTime, value); }

        private List<Game> _gamesList;
        public List<Game> GamesList { get => _gamesList; set => Set(ref _gamesList, value); }

        private List<Player> _players;
        public List<Player> Players { get => _players; set => Set(ref _players, value); }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                if (string.IsNullOrEmpty(Username))
                    return "Username field cannot be empty";
                else
                    return string.Empty;
            }
        }

        public double GetGameLength()
        {
            switch (GameLengthString)
            {
                case "3 Min":
                    return 3;
                case "5 Min":
                    return 5;
                case "10 Min":
                    return 10;
                default:
                    return 3;
            }
        }

        //Just a method to set the username randomly if the user doesn't enter one
        public string GetRandomUsername()
        {
            var usernames = new List<string> {
                "bighorn",
                "canary",
                "horse",
                "gorilla",
                "ferret",
                "mare",
                "lynx",
                "orangutan",
                "iguana",
                "gila monster",
                "frog",
                "mule",
                "tapir",
                "mountain goat",
                "cougar",
                "guanaco",
                "leopard",
                "lamb",
                "prairie dog",
                "capybara",
                "sloth",
                "ibex",
                "lizard",
                "lovebird",
                "anteater",
                "walrus",
                "crow",
                "snake",
                "aardvark",
                "eland",
                "raccoon",
                "armadillo",
                "ewe",
                "burro",
                "dormouse",
                "seal",
                "hedgehog",
                "stallion",
                "giraffe",
                "pig",
                "argali",
                "waterbuck",
                "fox",
                "panther",
                "blue crab",
                "newt",
                "zebu",
                "buffalo",
                "dung beetle",
                "dromedary"
            };
            Random rand = new Random();
            int usernameIndex = rand.Next(0, usernames.Count);
            return usernames[usernameIndex];
        }
    }
}
