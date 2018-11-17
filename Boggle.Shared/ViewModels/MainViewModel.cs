using Boggle.Shared.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Boggle.Shared.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Game> GamesList { set; get; }

        public MainViewModel()
        {
            var dataService = new SqliteDataService("Boggle.db");
            dataService.AddNewPlayer(new Player { Id = 0, Name = "Spongebob" });
            dataService.AddNewGame(new Game { Id = 0, PlayerId = 0, Score = 10000 });
            var GamesList = dataService.GetAllGames();
        }
    }
}
