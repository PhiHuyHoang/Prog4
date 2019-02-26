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
using System.Windows.Shapes;

namespace prog4_lesson_3
{
    /// <summary>
    /// Interaction logic for WorkerBindingWindow.xaml
    /// </summary>
    public partial class WorkerBindingWindow : Window
    {
        public Worker Worker { get { return DataContext as Worker; } }
        public WorkerBindingWindow()
        {
            InitializeComponent();
        }
        public WorkerBindingWindow(Worker w)
        {
            InitializeComponent();
            DataContext = w;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
