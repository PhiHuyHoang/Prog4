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

namespace prog4_prac2_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberClick(object sender, RoutedEventArgs e)
        {
            //txtDisplay.Text += (sender as Button).Content.ToString();
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text += (e.Source as Button).Content.ToString();
        }

        private void DecSepClick(object sender, RoutedEventArgs e)
        {
            if(!txtDisplay.Text.Contains(decSep))
            {
                txtDisplay.Text += decSep;
            }
        }

        private void TxtDisplay_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);
        }

        private void TxtDisplay_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Handled = true mean stop code
            //key allways first charracter
            e.Handled = !char.IsDigit(e.Text[0]) &&( e.Text!=decSep ||
                txtDisplay.Text.Contains(decSep));
        }

        private void GetResultClick(object sender, RoutedEventArgs e)
        {
            try
            {
                lblOp2.Content = double.Parse(txtDisplay.Text);
                double op1 = (double)lblOp1.Content;
                double op2 = (double)lblOp2.Content;
                char oper = (char)lblOperator.Content;
                switch(oper)
                {
                    case '+': lblResult.Content = op1 + op2; break;
                    case '-': lblResult.Content = op1 - op2; break;
                    case '*': lblResult.Content = op1 * op2; break;
                    case '/': lblResult.Content = op1 / op2; break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OperatorClick(object sender, RoutedEventArgs e)
        {
            try
            {
                lblOperator.Content = (sender as Button).Content.ToString()[0];
                lblOp1.Content = double.Parse(txtDisplay.Text);
                txtDisplay.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
