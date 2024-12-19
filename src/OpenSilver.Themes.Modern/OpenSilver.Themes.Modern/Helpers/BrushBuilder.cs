using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern
{
    internal class BrushBuilder : DependencyObject
    {
        public Brush BasedOn
        {
            get { return (Brush)GetValue(BasedOnProperty); }
            set { SetValue(BasedOnProperty, value); }
        }
        public static readonly DependencyProperty BasedOnProperty =
            DependencyProperty.Register("BasedOn", typeof(Brush), typeof(BrushBuilder), new PropertyMetadata(null, OnChange));

        public double BrightnessRatio
        {
            get { return (double)GetValue(BrightnessRatioProperty); }
            set { SetValue(BrightnessRatioProperty, value); }
        }
        public static readonly DependencyProperty BrightnessRatioProperty =
            DependencyProperty.Register("BrightnessRatio", typeof(double), typeof(BrushBuilder), new PropertyMetadata(0d, OnChange));

        public double DesaturationRatio
        {
            get { return (double)GetValue(DesaturationRatioProperty); }
            set { SetValue(DesaturationRatioProperty, value); }
        }
        public static readonly DependencyProperty DesaturationRatioProperty =
            DependencyProperty.Register("DesaturationRatio", typeof(double), typeof(BrushBuilder), new PropertyMetadata(0d, OnChange));

        public Brush Brush
        {
            get { return (Brush)GetValue(BrushProperty); }
            set { SetValue(BrushProperty, value); }
        }
        public static readonly DependencyProperty BrushProperty =
            DependencyProperty.Register("Brush", typeof(Brush), typeof(BrushBuilder), new PropertyMetadata(null));


        private static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BrushBuilder builder = (BrushBuilder)d;
            builder.UpdateBrush();
        }

        void UpdateBrush()
        {
            if (BasedOn != null)
            {
                switch (BasedOn)
                {
                    //Comment this for now.
                    //case Color color:
                    //    return ConvertColor(color);

                    case SolidColorBrush brush:
                        //Color brushColor = ConvertColor(brush.Color);
                        //brushColor = PartiallyDesaturate(brushColor, DesaturationRatio);
                        Color brushColor = PartiallyDesaturate(brush.Color, DesaturationRatio);
                        brushColor = ConvertColor(brushColor);
                        Brush = new SolidColorBrush(brushColor);
                        break;

                    default:
                        Brush = BasedOn; // Return original value if the type is not handled
                        break;
                }
            }
        }

        Color ConvertColor(Color color)
        {
            if (BrightnessRatio < 0) // Darken the color
            {
                double factor = 1 + (BrightnessRatio / 100);

                // Clamp the RGB values to ensure they stay within valid bounds (0-255)
                byte r = (byte)(color.R * factor);
                byte g = (byte)(color.G * factor);
                byte b = (byte)(color.B * factor);

                return Color.FromArgb(color.A, r, g, b);
            }
            else if (BrightnessRatio > 0) //Brighten the color
            {
                double factor = BrightnessRatio / 100;

                // Clamp the RGB values to ensure they stay within valid bounds (0-255)
                byte r = (byte)(color.R + (255 - color.R) * factor);
                byte g = (byte)(color.G + (255 - color.G) * factor);
                byte b = (byte)(color.B + (255 - color.B) * factor);

                return Color.FromArgb(color.A, r, g, b);
            }
            return color;
        }

        Color PartiallyDesaturate(Color color, double factor)
        {
            if (factor < 0 || factor > 1)
                throw new ArgumentOutOfRangeException(nameof(factor), "Factor must be between 0 and 1.");

            // Convert the color to grayscale
            byte gray = (byte)((color.R * 0.3) + (color.G * 0.59) + (color.B * 0.11));

            // Blend the original color with the grayscale value
            byte r = (byte)(color.R + (gray - color.R) * factor);
            byte g = (byte)(color.G + (gray - color.G) * factor);
            byte b = (byte)(color.B + (gray - color.B) * factor);

            return Color.FromRgb(r, g, b);
        }
    }
}
