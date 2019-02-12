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

namespace prog4_01_helloworld
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

        private void CalculateClick(object sender, RoutedEventArgs e)
        {
            string s = string.Empty;
            try
            {
                double income = double.Parse(txtIncome.Text);
                double taxPct = double.Parse(txtPct.Text);
                double taxPrepaid = double.Parse(txtPrepaid.Text);

                double result = income * taxPct / 100 - taxPrepaid;
                if(result > 0)
                {
                    s = "MUST PAY " + result;
                }
                else if(result < 0)
                {
                    s = "OVERPAID " + result;
                }
                else
                {
                    s = "ALL IS OK";
                }

            }
            catch(FormatException ex)
            {
                s = "ERROR: NUM A NUMBER";
            }
            catch(OverflowException ex)
            {
                s = "ERROR: TOO BIG NUMBER";
            }
            Title = s;
            MessageBox.Show(s);
        }
    }
}
