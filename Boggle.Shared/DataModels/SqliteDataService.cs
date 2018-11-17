using Boggle.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.DataModels
{
    public class SqliteDataService : IDataService
    {
        private readonly BoggleDatabaseContext context;
        private readonly string dbPath;

        public SqliteDataService(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            context = new BoggleDatabaseContext(dbPath);
        }
   
        public void AddNewGame(Game g)
        {
            context.Games.Add(g);
            context.SaveChanges();
        }

        public void AddNewPlayer(Player p)
        {
            context.Players.Add(p);
            context.SaveChanges();
        }

        public IEnumerable<Game> GetAllGames()
        {
            List <Game> GamesList = new List<Game>();
            foreach (Game game in context.Games)
                GamesList.Add(game);
            return GamesList;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            List<Player> Players = new List<Player>();
            foreach (Player player in context.Players)
                Players.Add(player);
            return Players;
        }
    }
}
