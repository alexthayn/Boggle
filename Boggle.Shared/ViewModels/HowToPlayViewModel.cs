using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boggle.Shared.ViewModels
{
    public class HowToPlayViewModel : ViewModelBase
    {
        private readonly MainViewModel mainView;

        public HowToPlayViewModel(MainViewModel mainViewModel)
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
