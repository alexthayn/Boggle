using Boggle.Shared.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.Interfaces
{
    public interface IDataService
    {
        void AddNewPlayer(Player p);
        void AddNewGame(Game g);
        IEnumerable<Game> GetAllGames();
    }
}
