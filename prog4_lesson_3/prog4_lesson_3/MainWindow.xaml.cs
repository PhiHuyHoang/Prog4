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

namespace prog4_lesson_3
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

        private void AddClick(object sender, RoutedEventArgs e)
        {
            WorkerBindingWindow win = new WorkerBindingWindow();
            if(win.ShowDialog() == true) // Check DialogResult
            {
                // vs ItemSource !!!
                myListBox.Items.Add(win.Worker);
            }
        }

        private void DelClick(object sender, RoutedEventArgs e)
        {
            if (myListBox.SelectedItem == null) return;
            myListBox.Items.Remove(myListBox.SelectedItem);
        }

        private void ModClick(object sender, RoutedEventArgs e)
        {
            if (myListBox.SelectedItems == null) return;
            WorkerBindingWindow win = new WorkerBindingWindow(myListBox.SelectedItem as Worker);
            if(win.ShowDialog() == true)
            {
                myListBox.Items.Refresh();
            }
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            myListBox.Items.Clear();
        }
    }
}
