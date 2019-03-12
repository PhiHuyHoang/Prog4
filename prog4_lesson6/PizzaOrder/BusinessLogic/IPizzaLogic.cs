using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrder
{
    interface IPizzaLogic
    {
        int CalculatePrice(OnePizza pizza);
        void SavePizza(OnePizza pizza, IList<OnePizza> collection);
        void SelectAllToppings(IEnumerable<PizzaExtra> toppings);
    }
}
