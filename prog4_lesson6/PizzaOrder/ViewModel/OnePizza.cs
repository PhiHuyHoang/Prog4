using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrder
{
    class OnePizza : Bindable
    {
        // Factory? IoC container? Singleton?
        IPizzaLogic logic = new PizzaLogic();

        private PizzaExtra size;

        public PizzaExtra Size
        {
            get { return size; }
            set {
                SetField(ref size, value);
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public int TotalPrice
        {
            get { return logic.CalculatePrice(this); }
        }

        /*
         * IEnumerable<T> (List<T>, Array, Queue....)
         * 
         *         
         * private IEnumerable<int> myArray;

            public IEnumerable<int> MyArray
            {
                get { return myArray; }
                // If we change the collection the event will not be called!!!!!!!
                set { SetField(ref myArray, value); }
            }
         * 
         * 
         * Only use IEnumerable if U sure that the collection will not change, since it will not send event!!!!
         * 
         * 
         * USE ObservableCollection<T>
         *   CollectionChanged event
         *   .Add(), .Remove(), .Clear(), list[23]=xxxx
         * Note: The framework will subscribe for the events! 
         * 95% of the time we use ObservableCollection
         * 
         *  list[23].IsSelected = true -> No CollectionChanged event, but there is a PropertyChanged event called.
         *  
         *  
         *  BindingList<T>
         *      ListChanged event
         *      Event is fired if ANYTHING changes inside 
         *      Useful if we want to catch changes in c#
         */


        public BindingList<PizzaExtra> Toppings { get; private set; }

        public OnePizza()
        {
            Toppings = new BindingList<PizzaExtra>();
            // !BIG! question : when should we refresh the TotalPrice??

            // naiv ways -> refresh always -> now we use this.
            // nice way ->logic sends an event if changes....

            // += <TAB> + <ENTER> to generate method
            Toppings.ListChanged += Toppings_ListChanged;
        }

        private void Toppings_ListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TotalPrice));
            // also in Size.set !!!!
        }
    }
}
