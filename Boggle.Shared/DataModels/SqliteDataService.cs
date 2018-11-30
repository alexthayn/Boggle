using Boggle.Shared.Interfaces;
using Boggle.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<PlayerScore> GetPlayerScores()
        {
            List<Game> Games = GetAllGames().ToList();
            List<PlayerScore> HighScores = new List<PlayerScore>();

            //Sort the games from highest to lowest score
            Games = Games.OrderByDescending(s => s.Score).ToList();
            foreach(Game g in Games)
            {
                HighScores.Add(new PlayerScore() { Score = g.Score, Username = GetUsernameById(g.PlayerId)});
            }

            return HighScores;
        } 

        public string GetUsernameById(int id)
        {
            List<Player> Players = GetAllPlayers().ToList();
            return Players?.Find(p => p.Id == id).Name;
        }
    }
}
