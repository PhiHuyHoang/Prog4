using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrder
{
    class PizzaLogic : IPizzaLogic
    {
        public int CalculatePrice(OnePizza pizza)
        {
            int price = pizza.Size.Price;
            foreach (var item in pizza.Toppings)
            {
                if(item.IsSelected)
                {
                    price += item.Price;
                }
            }
            return price;
        }

        public void SavePizza(OnePizza pizza, IList<OnePizza> collection)
        {
            OnePizza clone = new OnePizza();
            clone.Size = new PizzaExtra(pizza.Size.Name, pizza.Size.Price, true);
            foreach (var item in pizza.Toppings)
            {
                if (item.IsSelected)
                {
                    clone.Toppings.Add(new PizzaExtra(item.Name, item.Price, true));
                }
            }
            collection.Add(clone);
        }

        public void SelectAllToppings(IEnumerable<PizzaExtra> toppings)
        {
            foreach (var item in toppings)
            {
                item.IsSelected = true;
            }

            // who is responsible for the clone creation
            // onePizza prototype design pattern
            // viewmodel if no logic/rule/conditions
            // logic if conditions exist

        }
    }
}
