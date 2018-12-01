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
            TheGame = new BoggleGame("new user");
            this.dataService = new SqliteDataService("Boggle.db");
            this.dataService.AddNewPlayer(new Player { Name = "Spongebob" });
            this.dataService.AddNewPlayer(new Player { Name = "Patrick" });
            this.dataService.AddNewPlayer(new Player { Name = "Squidward" });
            this.dataService.AddNewGame(new Game { PlayerId = 3, Score = 10000 });
            this.dataService.AddNewGame(new Game { PlayerId = 1, Score = 1423 });
            this.dataService.AddNewGame(new Game { PlayerId = 1, Score = 4554 });
            this.dataService.AddNewGame(new Game { PlayerId = 2, Score = 89743 });
            MainScreenViewModel = new MainScreenViewModel(this, dataService);
            HowToPlayViewModel = new HowToPlayViewModel(this);
            HighScoresViewModel = new HighScoresViewModel(this, dataService);
            BoggleGameViewModel = new BoggleGameViewModel(this, dataService);
            ChildViewModel = MainScreenViewModel;
        }
    }
}
