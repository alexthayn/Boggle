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
        private object _childViewModel;
        public object ChildViewModel { get => _childViewModel; set => Set(ref _childViewModel, value); }

        private MainScreenViewModel _mainScreenViewModel;
        public MainScreenViewModel MainScreenViewModel { get => _mainScreenViewModel; set => Set(ref _mainScreenViewModel, value); }

        public MainViewModel()
        {
            MainScreenViewModel = new MainScreenViewModel();

            ChildViewModel = MainScreenViewModel;
        }
    }
}
