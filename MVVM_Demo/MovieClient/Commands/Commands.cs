using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieClient.Commands
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;//this is the delegate for execute
        public Command(Action execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();//this invokes the delegate
        }
    }
}
