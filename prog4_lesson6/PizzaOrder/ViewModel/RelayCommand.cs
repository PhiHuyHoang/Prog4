using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaOrder
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            // we could send a lambda expression through the constructor to make this true a conditional ;)
            /**
             * 
             *  public RelayCommand(Action<object> toExecute, todo: lambda here)
             *       {
             *           this.ToExecute = toExecute;
             *       }
             * 
             * 
             */
            return true;
        }

        Action<object> ToExecute;

        public RelayCommand(Action<object> toExecute)
        {
            this.ToExecute = toExecute;
        }

        public void Execute(object parameter)
        {
            ToExecute.Invoke(parameter);
        }
    }
}
