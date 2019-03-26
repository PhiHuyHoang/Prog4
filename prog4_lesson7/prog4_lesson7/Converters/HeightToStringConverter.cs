using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace prog4_lesson7
{

    // 212 <=> 2m 13cm
    class HeightToStringConverter : IValueConverter
    {
        //value height int
        //return string Xm Ycm
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int h = (int)value;
            return String.Format("{0}m {1}cm", h / 100, h % 100);
        }

        //value = string: Xm Ycm
        //return height int
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = (string)value;
            string[] parts = input.Split(' ');
            int m = int.Parse(parts[0].Substring(0, parts[0].Length - 1));
            int cm = int.Parse(parts[1].Substring(0, parts[1].Length - 2));
            return m * 100 + cm;
        }
    }
}
