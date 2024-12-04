using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern
{
    public class DarkenColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string percentageString && double.TryParse(percentageString, out double percentage))
            {
                switch (value)
                {
                    case Color color:
                        return ConvertColor(color, percentage);

                    case SolidColorBrush brush:
                        Color brushColor = ConvertColor(brush.Color, percentage); 
                        return new SolidColorBrush(brushColor);

                    default:
                        return value; // Return original value if the type is not handled
                }
            }

            return value; // Return original value if conversion fails
        }

        private Color ConvertColor(Color color, double percentage)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentOutOfRangeException("Percentage must be between 0 and 100.");

            double factor = 1 - (percentage / 100);

            // Clamp the RGB values to ensure they stay within valid bounds (0-255)
            byte r = (byte)(color.R * factor);
            byte g = (byte)(color.G * factor);
            byte b = (byte)(color.B * factor);

            return Color.FromArgb(color.A, r, g, b);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
