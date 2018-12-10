using Boggle.Shared.DataModels;
using Boggle.Shared.Models;
using System.Collections.Generic;

namespace Boggle.Shared.Interfaces
{
    public interface IDataService
    {        
        void AddNewGame(string username, int score);
        IEnumerable<Game> GetAllGames();
        IEnumerable<Player> GetAllPlayers();
        IEnumerable<PlayerScore> GetPlayerScores();
    }
}
