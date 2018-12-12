using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Boggle.WPF.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush retColor = new SolidColorBrush
            {
                Color = System.Windows.Media.Color.FromRgb(0, 0, 0)
            };

            if ((bool)value)
            {
                retColor.Color = System.Windows.Media.Color.FromRgb(11, 102, 35);
            }
            else
            {
                retColor.Color = System.Windows.Media.Color.FromRgb(234, 41, 57);
            }
            return retColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
    }
}
