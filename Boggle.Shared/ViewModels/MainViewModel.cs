using Boggle.Shared.DataModels;
using Boggle.Shared.Interfaces;
using Boggle.Shared.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Boggle.Shared.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly IDataService dataService;
        private object _childViewModel;
        public object ChildViewModel { get => _childViewModel; set => Set(ref _childViewModel, value); }
        public BoggleGame TheGame;

        private ObservableObject _previousViewModel;
        public ObservableObject PreviousViewModel { get => _previousViewModel; set => Set(ref _previousViewModel, value); }
            
        private MainScreenViewModel _mainScreenViewModel;
        public MainScreenViewModel MainScreenViewModel { get => _mainScreenViewModel; set => Set(ref _mainScreenViewModel, value); }

        private HowToPlayViewModel _howToPlayViewModel;
        public HowToPlayViewModel HowToPlayViewModel { get => _howToPlayViewModel; set => Set(ref _howToPlayViewModel, value); }

        private HighScoresViewModel _highScoresViewModel;
        public HighScoresViewModel HighScoresViewModel { get => _highScoresViewModel; set => Set(ref _highScoresViewModel, value); }

        private BoggleGameViewModel _boggleGameViewModel;
        public BoggleGameViewModel BoggleGameViewModel { get => _boggleGameViewModel; set => Set(ref _boggleGameViewModel, value); }

        public MainViewModel()
        {
            TheGame = new BoggleGame();
            this.dataService = new SqliteDataService("Boggle.db");
            MainScreenViewModel = new MainScreenViewModel(this, TheGame, dataService);
            HowToPlayViewModel = new HowToPlayViewModel(this);
            HighScoresViewModel = new HighScoresViewModel(this, dataService);
            BoggleGameViewModel = new BoggleGameViewModel(this, TheGame, dataService);
            ChildViewModel = MainScreenViewModel;
        }
    }
}
