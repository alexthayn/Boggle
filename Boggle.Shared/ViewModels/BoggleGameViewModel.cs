using GalaSoft.MvvmLight.Command;
using System;

namespace Boggle.Shared.ViewModels
{
    public class BoggleGameViewModel
    {
        private readonly MainViewModel mainView;

        public BoggleGameViewModel(MainViewModel mainViewModel)
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
