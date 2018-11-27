using Boggle.Shared.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class MainScreenViewModelTests
    {
        public MainScreenViewModel vm;
        
        [SetUp]
        public void Setup()
        {
            vm = new MainScreenViewModel();
        }
    }
}
