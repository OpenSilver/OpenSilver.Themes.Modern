using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern
{

    public class ColorToFlatGradientStopsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is Color baseColor)
            {
                // Convert base color to HSL (Hue, Saturation, Lightness)
                double hue, saturation, lightness;
                //ColorToHsl(baseColor, out hue, out saturation, out lightness);

                // Create a GradientStopCollection with shifted hues
                var gradientStops = new GradientStopCollection
            {
                new GradientStop() { Color = baseColor, Offset=0.0 },
                //new GradientStop() { Color = HslToColor((hue + 10) % 360, saturation, lightness), Offset=0.5 },
                //new GradientStop() { Color = HslToColor((hue + 20) % 360, saturation, lightness), Offset=1.0 }
            };

                return gradientStops;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}