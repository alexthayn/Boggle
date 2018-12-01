using Boggle.Shared.Models;
using System.Collections.ObjectModel;

namespace Boggle.Shared.Interfaces
{
    public interface IBoggleGame
    {
        ObservableCollection<PlayerGuess> ListOfGuesses { get; }

        int GetScore();
        void SubmitGuess(string word);
    }
}
