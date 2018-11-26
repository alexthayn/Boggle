using Boggle.Shared.DataModels;
using Boggle.Shared.Interfaces;
using Boggle.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Boggle.Shared.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private BoggleGame _theGame;
        public BoggleGame TheGame
        {
            get
            {
                return _theGame;
            }
            set
            {
                _theGame = value;
                OnPropertyChanged(nameof(TheGame));
            }
        }
        private readonly IDataService dataService;
        private List<Game> _gamesList;
        public List<Game> GamesList
        {
            get
            {
                return _gamesList;
            }
            set
            {
                _gamesList = value;
                OnPropertyChanged(nameof(GamesList));
            }
        }

        private List<Player> _players;
        public List<Player> Players
        {
            get
            {
                return _players;
            }
            set
            {
                _players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        public MainViewModel() : this(new SqliteDataService("Boggle.db")) { }

        public MainViewModel(IDataService dataService)
        {
            TheGame = new BoggleGame
            {
                Username = GetRandomUsername()
            };
            this.dataService = dataService;
            this.dataService.AddNewPlayer(new Player { Name = "Spongebob" });
            this.dataService.AddNewPlayer(new Player { Name = "Patrick" });
            this.dataService.AddNewPlayer(new Player { Name = "Squidward" });
            this.dataService.AddNewGame(new Game { PlayerId = 3, Score = 10000 });
            this.dataService.AddNewGame(new Game { PlayerId = 1, Score = 1423 });
            this.dataService.AddNewGame(new Game { PlayerId = 1, Score = 4554 });
            this.dataService.AddNewGame(new Game { PlayerId = 2, Score = 89743 });
            GamesList = dataService.GetAllGames().ToList();
            Players = dataService.GetAllPlayers().ToList();
        }

        //Just a fun method to set the username randomly if the user doesn't enter one
        public string GetRandomUsername()
        {
            var usernames = new List<string> { "Skedaddle_Snollygoster", "Batrachomyomachy_Folderol", "Crudivore_Doozy", "Widdershins_Flummox", "Batrachomyomachy_Hootenanny", "Flibbertigibbet_Abibliophobia", "Yahoo_Callipygian", "Malarkey_Cockamamie", "Formication_Gardyloo!", "Troglodyte_Snool",
            "Natasi_Daala_Aurra_Sing","Chewbacca_PROXY","Emperor_Palpatine_Kyp_Durron","General_Crix_Madine_Galen_Marek","Ulic_Qel-Droma_Captain_Rex","Galen_Marek_Darth_Maul","Admiral_Ackbar_Jacen_Solo","Captain_Rex_IG_88","Darth_Nihilus_Dengar","Darth_Maul_Zuckuss",
            "The_Deprogrammer_The_Eternal_Warrior","The_Backstabber_Bounty_Collector","Clone_Commander_Pilot","Pilot_Strike_Team_Specialist","The_Blockade_Runner_Hot_Shot_Pilot","Warstalker_Count","Archon_Agent","Pilot_Butcher's_Bane","Lucky_Keeper_of_Truth","Vice_Commandant_Galactic_City_Savior"};
            Random rand = new Random();
            int usernameIndex = rand.Next(0, usernames.Count);
            return usernames[usernameIndex];
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
