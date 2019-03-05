using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prog4_lesson5.VM
{
    class RelayCommand : ICommand
    {
        // void Something(object parameter)
        //parameter = xaml command parameter
        Action<object> methodToExcute;
        public RelayCommand(Action<object> methodToExcute)
        {
            this.methodToExcute = methodToExcute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            methodToExcute.Invoke(parameter);
        }
    }
}
