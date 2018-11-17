using System;
using Xamarin.Forms;
using Ooui;
using Boggle.Shared.ViewModels;
using System.Diagnostics;

namespace Boggle.Ooui
{
    class Program
    {
        static void Main(string[] args)
        {
            Forms.Init();
            var platformServices = new OouiPlatformServices();
            var vm = new MainViewModel();
            UI.Publish("/", new BogglePage() { BindingContext = vm }.GetOouiElement());

#if DEBUG
            UI.Port = 12345;
            UI.Host = "localhost";
            Process.Start("explorer", $"http://{UI.Host}:{UI.Port}");
            Console.ReadKey();
#endif
        }
    }
}
