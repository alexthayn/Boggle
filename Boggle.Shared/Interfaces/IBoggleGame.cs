using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.Interfaces
{
    public interface IBoggleGame
    {
        int GetScore();
        void NewGame(string username);
        int CalculateWordScore(string word);
    }
}
