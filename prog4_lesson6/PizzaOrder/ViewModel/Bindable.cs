using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrder
{
    // in MVVM Light : ObservableObject
    // OOP Violation ????
    // class ViewModel : SomeBaseClass, INotifyPropertyChanged -> good
    // class ViewModel : SomeBaseClass, Bindable -> bad
    class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /**
         * class ViewModel : Bindable
         * {
         * 
         *  int totalPrice;
         *  
         *  public int TotalPrice
         *  {
         *      get {return totalPrice;}
         *      set {
         *          totalPrice = value;
         *          OnPropertyChanged("TotalPrice");
         *          
         *          // We use this SetField trick to avoid the above 2 lines in our ViewModel
         *          
         *          // and write this
         *          SetField(ref this, value);
         *      }
         *  }
         * 
         * }
         * 
         * // CTRL + R + E = encapsulate field
         * // propful <TAB><TAB>
         * 
         */
        protected void SetField<T>(ref T field, T value, [CallerMemberName]string name = null)
        {
            field = value;
            OnPropertyChanged(name);
        }
    }
}
