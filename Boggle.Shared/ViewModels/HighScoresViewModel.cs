using Boggle.Shared.DataModels;
using Boggle.Shared.Interfaces;
using Boggle.Shared.Models;
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

        private List<PlayerScore> _listOfHighScores;
        public List<PlayerScore> ListOfHighScores { get => _listOfHighScores; set => Set(ref _listOfHighScores, value); }    
        private readonly IDataService dataService;

        public HighScoresViewModel(MainViewModel mainViewModel, IDataService dataService)
        {
            this.dataService = dataService;
            mainView = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
            ListOfHighScores = dataService.GetPlayerScores().ToList();
        }


        public void Update()
        {
            ListOfHighScores = dataService.GetPlayerScores().ToList();
        }

        private RelayCommand _backToMain;
        public RelayCommand BackToMain => _backToMain ?? (_backToMain = new RelayCommand(
            () =>
            {
                mainView.ChildViewModel = mainView.PreviousViewModel;
            }));
    }
}
