using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaOrder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         Checkbox Change ==> Write PizzaExtra.IsSelected ==> PropertyChanged Event
         Subscriber1: UI => READ PizzaExtra.IsSelected => NoChange, no action needed
         CheckBox.IsChecked <= Bidding => PizzaExtra.IsSelected
         Subscriber2: BindingList => ListChanged event 
         Subscriber1: UI => No changed, no action

         Subscriber2: the OnePizza class => raise Property Changed (Total Price) SUbscriber UI => READ Pizza.TotalPrice => Displays new price 

         */
    }
}
