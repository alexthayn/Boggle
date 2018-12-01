using Boggle.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.Interfaces
{
    public interface IBoggleGame
    {
        int GetScore();
        int CalculateWordScore(string word);
    }
}
