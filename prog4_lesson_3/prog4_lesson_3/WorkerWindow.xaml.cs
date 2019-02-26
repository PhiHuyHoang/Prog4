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
    /// Interaction logic for WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public Worker Worker { get; set; }

        public WorkerWindow(): this (new Worker())
        {

        }

        public WorkerWindow(Worker w)
        {
            InitializeComponent();
            this.Worker = w;
            txtName.Text = Worker.Name;
            txtPhone.Text = Worker.PhoneNumber;
            chkHoliday.IsChecked = Worker.IsOnHoliday;
            chkSick.IsChecked = Worker.IsSick;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            Worker.Name = txtName.Text;
            Worker.PhoneNumber = txtPhone.Text;
            Worker.IsSick = chkSick.IsChecked.Value;
            Worker.IsOnHoliday = chkHoliday.IsChecked.Value;

            DialogResult = true;
            //Close();
        }
    }
}
