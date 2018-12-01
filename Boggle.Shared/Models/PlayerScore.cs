using GalaSoft.MvvmLight;

namespace Boggle.Shared.Models
{
    public class PlayerScore : ObservableObject
    {
        private int _score;
        public int Score { get => _score; set => Set(ref _score, value); }

        private string _username;
        public string Username { get => _username; set => Set(ref _username, value); }
    }
}
