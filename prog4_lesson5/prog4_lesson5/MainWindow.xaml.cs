using prog4_lesson5.VM;
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

namespace prog4_lesson5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ViewModel vm;
        string currentDir;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string currentDir) : this()
        {
            this.currentDir = currentDir;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (vm.SelectedEntry == null) return;
            if (vm.SelectedEntry.isDir)
            {
                MainWindow win = new MainWindow(vm.SelectedEntry.Name);
                win.Show();
            }
            else
            {
                System.Diagnostics.Process.Start(vm.SelectedEntry.Name);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm = new ViewModel(currentDir);
            DataContext = vm;
        }
    }
}
