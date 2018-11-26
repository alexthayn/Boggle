using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.Interfaces
{
    public interface IBoggleGame
    {
        void SetUsername(string username);
        int GetScore();
        void NewGame();
        int CalculateWordScore(string word);
    }
}
