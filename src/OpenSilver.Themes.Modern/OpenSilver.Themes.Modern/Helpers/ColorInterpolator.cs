using System;
using System.Windows;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern
{
    public sealed class ColorInterpolator : DependencyObject
    {
        public Brush BasedOn
        {
            get => (Brush)GetValue(BasedOnProperty);
            set => SetValue(BasedOnProperty, value);
        }

        public static readonly DependencyProperty BasedOnProperty =
            DependencyProperty.Register(
                nameof(BasedOn),
                typeof(object),
                typeof(ColorInterpolator),
                new PropertyMetadata(null, OnChange));

        public Color TargetColor
        {
            get => (Color)GetValue(TargetColorProperty);
            set => SetValue(TargetColorProperty, value);
        }

        public static readonly DependencyProperty TargetColorProperty =
            DependencyProperty.Register(
                nameof(TargetColor),
                typeof(Color),
                typeof(ColorInterpolator),
                new PropertyMetadata(Colors.White, OnChange));

        public double InterpolationRatio
        {
            get => (double)GetValue(InterpolationRatioProperty);
            set => SetValue(InterpolationRatioProperty, value);
        }

        public static readonly DependencyProperty InterpolationRatioProperty =
            DependencyProperty.Register(
                nameof(InterpolationRatio),
                typeof(double),
                typeof(ColorInterpolator),
                new PropertyMetadata(0d, OnChange));

        public double DesaturationRatio
        {
            get => (double)GetValue(DesaturationRatioProperty);
            set => SetValue(DesaturationRatioProperty, value);
        }

        public static readonly DependencyProperty DesaturationRatioProperty =
            DependencyProperty.Register(
                nameof(DesaturationRatio),
                typeof(double),
                typeof(ColorInterpolator),
                new PropertyMetadata(0d, OnChange),
                ValidateDesaturationRatio);

        private static bool ValidateDesaturationRatio(object value)
        {
            double d = (double)value;
            return d >= 0 && d <= 1;
        }

        public Color ResultColor
        {
            get => (Color)GetValue(ResultColorProperty);
            private set => SetValue(ResultColorPropertyKey, value);
        }

        private static readonly DependencyPropertyKey ResultColorPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(ResultColor),
                typeof(Color),
                typeof(ColorInterpolator),
                null);

        public static readonly DependencyProperty ResultColorProperty = ResultColorPropertyKey.DependencyProperty;

        private static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ColorInterpolator)d).UpdateResultColor();
        }

        private void UpdateResultColor()
        {
            Color color = BasedOn switch
            {
                SolidColorBrush solid => solid.Color,
                _ => Colors.White,
            };

            ResultColor = PartiallyDesaturate(InterpolateColor(color, TargetColor, InterpolationRatio), DesaturationRatio);
        }

        private static Color InterpolateColor(Color baseColor, Color targetColor, double ratio)
        {
            Color color = Color.FromArgb(
                (byte)(baseColor.A + (ratio * (targetColor.A - baseColor.A))),
                (byte)(baseColor.R + (ratio * (targetColor.R - baseColor.R))),
                (byte)(baseColor.G + (ratio * (targetColor.G - baseColor.G))),
                (byte)(baseColor.B + (ratio * (targetColor.B - baseColor.B))));

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
