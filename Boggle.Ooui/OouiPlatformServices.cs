using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Boggle.Ooui
{
    public class OouiPlatformServices
    {
        public ICommand CreateCommand(Action execute)
        {
            return new Command(execute);
        }

        public ICommand CreateCommand(Action execute, Func<bool> canExecute)
        {
            return new Command(execute, canExecute);
        }

        public void SendMessage(object message)
        {
            throw new NotImplementedException();
        }
    }
}
