using Boggle.Shared.DataModels;
using Boggle.Shared.Models;
using System.Collections.Generic;

namespace Boggle.Shared.Interfaces
{
    public interface IDataService
    {
        void AddNewPlayer(Player p);
        void AddNewGame(Game g);
        IEnumerable<Game> GetAllGames();
        IEnumerable<Player> GetAllPlayers();
        IEnumerable<PlayerScore> GetPlayerScores();
    }
}
