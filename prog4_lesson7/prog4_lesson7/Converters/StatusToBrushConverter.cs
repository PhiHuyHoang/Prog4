using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace prog4_lesson7
{
    class StatusToBrushConverter : IValueConverter
    {
        // value = VM value = StatusType
        // return Brush = SolidColorBrush
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StatusType stat = (StatusType)value;
            switch(stat)
            {
                default:
                case StatusType.Actice: return Brushes.Green;
                case StatusType.Injured: return Brushes.Red;
                case StatusType.SentToMinors: return Brushes.Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
