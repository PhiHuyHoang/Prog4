using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaOrder
{
    class ViewModel: Bindable
    {
        IPizzaLogic logic = new PizzaLogic();
        public OnePizza Pizza { get; private set; }
        public ObservableCollection<PizzaExtra> AllSizes { get; private set; }
        public ObservableCollection<OnePizza> AllPizzas { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SelectAllCommand { get; private set; }

        public ViewModel()
        {
            // If IsInDesign / DependencyObject
            Pizza = new OnePizza();
            AllSizes = new ObservableCollection<PizzaExtra>();
            AllPizzas = new ObservableCollection<OnePizza>();
            AllSizes.Add(new PizzaExtra(new PizzaExtra("25cm", 1500, false)));
            AllSizes.Add(new PizzaExtra(new PizzaExtra("35cm", 2500, false)));
            AllSizes.Add(new PizzaExtra(new PizzaExtra("45cm", 3500, false)));
            Pizza.Size = AllSizes[1];

            Pizza.Toppings.Add(new PizzaExtra("Cheese", 100, false));
            Pizza.Toppings.Add(new PizzaExtra("Corn", 200, true));
            Pizza.Toppings.Add(new PizzaExtra("Ham", 300, false));
            Pizza.Toppings.Add(new PizzaExtra("Chicken", 400, true));

            SaveCommand = new RelayCommand((obj) => { logic.SavePizza(Pizza, AllPizzas); });
            SelectAllCommand = new RelayCommand((obj) => { logic.SelectAllToppings(Pizza.Toppings); });
        }

    }
}
