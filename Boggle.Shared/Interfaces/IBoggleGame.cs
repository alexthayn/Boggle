using Boggle.Shared.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Boggle.Shared.Interfaces
{
    public interface IBoggleGame
    {
        ObservableCollection<PlayerGuess> ListOfGuesses { get; }
        List<string> ListOfPossibleAnswers { get; set; }
        double GameTime { get; set; }
        bool IsGameOver { get; set; }
        string[] Row1 { get; set; }
        string[] Row2 { get; set; }
        string[] Row3 { get; set; }
        string[] Row4 { get; set; }

        int GetScore();
        void SubmitGuess(string word);
    }
}
