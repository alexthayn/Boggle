using Boggle.Shared.DataModels;
using Boggle.Shared.Interfaces;
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

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
