using Boggle.Shared.DataModels;
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

        public MainViewModel()
        {
            var dataService = new SqliteDataService("Boggle.db");
            dataService.AddNewPlayer(new Player { Name = "Spongebob" });
            dataService.AddNewGame(new Game { PlayerId = 1, Score = 10000 });
            dataService.AddNewGame(new Game { PlayerId = 1, Score = 1423 });
            dataService.AddNewGame(new Game { PlayerId = 1, Score = 4554 });
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
