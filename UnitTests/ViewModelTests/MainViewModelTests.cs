using Boggle.Shared.ViewModels;
using NUnit.Framework;

namespace UnitTests.ViewModelTests
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
