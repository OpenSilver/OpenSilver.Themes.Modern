using System;
using System.Windows;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern
{
    public sealed class BrushBuilder : DependencyObject
    {
        public Brush BasedOn
        {
            get => (Brush)GetValue(BasedOnProperty);
            set => SetValue(BasedOnProperty, value);
        }

        public static readonly DependencyProperty BasedOnProperty =
            DependencyProperty.Register(
                nameof(BasedOn),
                typeof(Brush),
                typeof(BrushBuilder),
                new PropertyMetadata(null, OnChange));

        public double BrightnessRatio
        {
            get => (double)GetValue(BrightnessRatioProperty);
            set => SetValue(BrightnessRatioProperty, value);
        }

        public static readonly DependencyProperty BrightnessRatioProperty =
            DependencyProperty.Register(
                nameof(BrightnessRatio),
                typeof(double),
                typeof(BrushBuilder),
                new PropertyMetadata(0.0, OnChange));

        public double DesaturationRatio
        {
            get => (double)GetValue(DesaturationRatioProperty);
            set => SetValue(DesaturationRatioProperty, value);
        }

        public static readonly DependencyProperty DesaturationRatioProperty =
            DependencyProperty.Register(
                nameof(DesaturationRatio),
                typeof(double),
                typeof(BrushBuilder),
                new PropertyMetadata(0.0, OnChange),
                ValidateDesaturationRatio);

        private static bool ValidateDesaturationRatio(object value)
        {
            double d = (double)value;
            return d >= 0 && d <= 1;
        }

        public Brush Brush
        {
            get => (Brush)GetValue(BrushProperty);
            private set => SetValue(BrushPropertyKey, value);
        }

        private static readonly DependencyPropertyKey BrushPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(Brush),
                typeof(Brush),
                typeof(BrushBuilder),
                null);

        public static readonly DependencyProperty BrushProperty = BrushPropertyKey.DependencyProperty;

        private static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((BrushBuilder)d).UpdateBrush();
        }

        private void UpdateBrush()
        {
            Brush basedOn = BasedOn;

            Brush = basedOn switch
            {
                SolidColorBrush solid => new SolidColorBrush(ConvertColor(PartiallyDesaturate(solid.Color, DesaturationRatio))),
                _ => basedOn, // Return original value if the type is not handled
            };
        }

        private Color ConvertColor(Color color)
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

        private static Color PartiallyDesaturate(Color color, double factor)
        {
            if (factor < 0 || factor > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(factor), "Factor must be between 0 and 1.");
            }

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
