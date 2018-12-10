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

        public void AddNewGame(string username, int score)
        {
            int userId;
            if (CheckIfUserExists(username) == false)
            {
                AddPlayer(new Player { Name = username });
            }

            userId = GetIdOfUsername(username);
            AddNewGame(new Game { PlayerId = userId, Score = score });
        }

        private void AddNewGame(Game g)
        {
            context.Games.Add(g);
            context.SaveChanges();
        }

        private void AddPlayer(Player p)
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

        public IEnumerable<string> GetAllPlayerUsernames()
        {
            List<string> Players = new List<string>();
            foreach (Player player in context.Players)
                Players.Add(player.Name);
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

        private string GetUsernameById(int id)
        {
            List<Player> Players = GetAllPlayers().ToList();
            return Players?.Find(p => p.Id == id).Name;
        }

        private int GetIdOfUsername(string username)
        {
            if (!CheckIfUserExists(username))
            {
                AddPlayer(new Player { Name = username });
            }

            List<Player> Players = GetAllPlayers().ToList();
            return (int)Players?.Find(p => p.Name == username).Id;
        }

        private bool CheckIfUserExists(string username)
        {
            List<string> Players = GetAllPlayerUsernames().ToList();
            if (Players.Contains(username))
                return true;            
            return false;
        }
    }
}
