using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;

namespace Boggle.Shared.ViewModels
{
    public class HighScoresViewModel : ViewModelBase
    {
        private readonly MainViewModel mainView;

        public HighScoresViewModel(MainViewModel mainViewModel)
        {
            mainView = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
        }

        private RelayCommand _backToMain;
        public RelayCommand BackToMain => _backToMain ?? (_backToMain = new RelayCommand(
            () =>
            {
                mainView.ChildViewModel = mainView.MainScreenViewModel;
            }));
    }
}
