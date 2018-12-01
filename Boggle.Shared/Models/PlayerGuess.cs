using GalaSoft.MvvmLight;

namespace Boggle.Shared.Models
{
    public class PlayerGuess : ObservableObject
    {
        private string _guess;
        public string Guess { get => _guess; set => Set(ref _guess, value); }

        private bool _isValidGuess;
        public bool IsValidGuess { get => _isValidGuess; set => Set(ref _isValidGuess, value); }
    }
}
