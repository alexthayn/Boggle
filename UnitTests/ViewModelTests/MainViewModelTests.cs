using Boggle.Shared.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class MainViewModelTests
    {
        public MainViewModel vm;

        [SetUp]
        public void Setup()
        {
            vm = new MainViewModel();            
        }

        [Test]
        public void CheckStartupViewIsSetCorrectly()
        {
            Assert.AreEqual(vm.MainScreenViewModel, vm.ChildViewModel);   
        }
    }
}
