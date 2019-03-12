using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrder
{
    /**
     * Pizza topping and pizzaextra should be in sperate class
     */
    class PizzaExtra : Bindable
    {
        private string name;
        private bool isSelected; // only used when it's topping
        private int price;

        public string Name
        {
            get { return name; }
            set { SetField(ref name, value); }
        }
        
        public int Price
        {
            get { return price; }
            set { SetField(ref price, value); }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set { SetField(ref isSelected, value); }
        }

        public PizzaExtra(string name, int price, bool isSelected)
        {
            this.name = name;
            this.price = price;
            this.isSelected = isSelected;
        }

        public PizzaExtra(PizzaExtra other) : this (other.Name, other.Price, other.IsSelected)
        {}
    }
}
