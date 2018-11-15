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
            using (var dataContext = new BoggleDatabaseContext())
            {
                dataContext.Players.Add(new Player() { Name = "Spongebob", Id = 0 });
                dataContext.Players.Add(new Player() { Name = "Patrick", Id = 1 });
                dataContext.Players.Add(new Player() { Name = "Squidward", Id = 2 });
                dataContext.Games.Add(new Game() { Id = 0, PlayerId = 0, Score = 100 });
                dataContext.Games.Add(new Game() { Id = 1, PlayerId = 1, Score = 500 });
                dataContext.Games.Add(new Game() { Id = 2, PlayerId = 0, Score = 15200 });
                dataContext.Games.Add(new Game() { Id = 3, PlayerId = 2, Score = 5478 });
                dataContext.SaveChanges();

                foreach (Game game in dataContext.Games)
                    GamesList.Add(game);
            }
        }
    }
}
