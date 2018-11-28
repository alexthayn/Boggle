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

        private RelayCommand _howToPlayCommand;
        public RelayCommand HowToPlayCommand => _howToPlayCommand ?? (_howToPlayCommand = new RelayCommand(
            () =>
            {
                //Ask user the confirm
                //Save game and return to game after they are done
                mainView.ChildViewModel = mainView.HowToPlayViewModel;
            }));

        private RelayCommand _exitProgramCommand;
        public RelayCommand ExitProgramCommand => _exitProgramCommand ?? (_exitProgramCommand = new RelayCommand(
            () =>
            {
                //Ask user the confirm
                Environment.Exit(0);
            }));

        private RelayCommand _newGameCommand;
        public RelayCommand NewGameCommand => _newGameCommand ?? (_newGameCommand = new RelayCommand(
            () =>
            {
                //Ask user the confirm
                mainView.ChildViewModel = mainView.BoggleGameViewModel;
            }));

        private RelayCommand _endGameCommand;
        public RelayCommand EndGameCommand => _endGameCommand ?? (_endGameCommand = new RelayCommand(
            () =>
            {
                //Ask user the confirm
                mainView.ChildViewModel = mainView.MainScreenViewModel;
                //clean up game here
            }));
    }
}
