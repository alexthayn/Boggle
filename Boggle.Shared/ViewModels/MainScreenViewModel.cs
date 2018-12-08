﻿using Boggle.Shared.DataModels;
using Boggle.Shared.Interfaces;
using Boggle.Shared.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Boggle.Shared.ViewModels
{
    public class MainScreenViewModel : ViewModelBase
    {
        private readonly IBoggleGame TheGame;
        private readonly MainViewModel mainView;
        private readonly IDataService dataService;

        public MainScreenViewModel(MainViewModel mainViewModel, IDataService dataService)
        {
            mainView = mainViewModel;
            GameTime = 3;
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
                mainView.ChildViewModel = mainView.HighScoresViewModel;
            }));

        private RelayCommand _newGameCommand;
        public RelayCommand NewGameCommand => _newGameCommand ?? (_newGameCommand = new RelayCommand(
            () =>
            {
                mainView.PreviousViewModel = this;
                mainView.TheGame = new BoggleGame(Username);
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

        //Just a method to set the username randomly if the user doesn't enter one
        public string GetRandomUsername()
        {
            var usernames = new List<string> { "Skedaddle_Snollygoster", "Batrachomyomachy_Folderol", "Crudivore_Doozy", "Widdershins_Flummox", "Batrachomyomachy_Hootenanny", "Flibbertigibbet_Abibliophobia", "Yahoo_Callipygian", "Malarkey_Cockamamie", "Formication_Gardyloo!", "Troglodyte_Snool",
            "Natasi_Daala_Aurra_Sing","Chewbacca_PROXY","Emperor_Palpatine_Kyp_Durron","General_Crix_Madine_Galen_Marek","Ulic_Qel-Droma_Captain_Rex","Galen_Marek_Darth_Maul","Admiral_Ackbar_Jacen_Solo","Captain_Rex_IG_88","Darth_Nihilus_Dengar","Darth_Maul_Zuckuss",
            "The_Deprogrammer_The_Eternal_Warrior","The_Backstabber_Bounty_Collector","Clone_Commander_Pilot","Pilot_Strike_Team_Specialist","The_Blockade_Runner_Hot_Shot_Pilot","Warstalker_Count","Archon_Agent","Pilot_Butcher's_Bane","Lucky_Keeper_of_Truth","Vice_Commandant_Galactic_City_Savior"};
            Random rand = new Random();
            int usernameIndex = rand.Next(0, usernames.Count);
            return usernames[usernameIndex];
        }
    }
}
