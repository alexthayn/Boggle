using Boggle.Shared.DataModels;
using Boggle.Shared.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Boggle.Shared.ViewModels
{
    public class HighScoresViewModel : ViewModelBase
    {
        private readonly MainViewModel mainView;
        public List<Game> ListOfHighScores;
        private IDataService dataService;

        public HighScoresViewModel(MainViewModel mainViewModel, IDataService dataService)
        {
            this.dataService = dataService;
            mainView = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
            ListOfHighScores = dataService.GetAllGames().ToList();
        }

        private RelayCommand _backToMain;
        public RelayCommand BackToMain => _backToMain ?? (_backToMain = new RelayCommand(
            () =>
            {
                mainView.ChildViewModel = mainView.MainScreenViewModel;
            }));
    }
}
