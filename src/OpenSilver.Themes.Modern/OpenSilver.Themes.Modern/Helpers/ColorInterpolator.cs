using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.DataVisualization;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern
{
    internal class ColorInterpolator : DependencyObject
    {
        public object BaseColor
        {
            get { return (object)GetValue(BaseColorProperty); }
            set { SetValue(BaseColorProperty, value); }
        }
        public static readonly DependencyProperty BaseColorProperty =
            DependencyProperty.Register("BaseColor", typeof(object), typeof(ColorInterpolator), new PropertyMetadata(null, OnChange));

        public Color TargetColor
        {
            get { return (Color)GetValue(TargetColorProperty); }
            set { SetValue(TargetColorProperty, value); }
        }
        public static readonly DependencyProperty TargetColorProperty =
            DependencyProperty.Register("TargetColor", typeof(Color), typeof(ColorInterpolator), new PropertyMetadata(Colors.White, OnChange));

        public double InterpolationRatio
        {
            get { return (double)GetValue(InterpolationRatioProperty); }
            set { SetValue(InterpolationRatioProperty, value); }
        }
        public static readonly DependencyProperty InterpolationRatioProperty =
            DependencyProperty.Register("InterpolationRatio", typeof(double), typeof(ColorInterpolator), new PropertyMetadata(0d, OnChange));

        public double DesaturationRatio
        {
            get { return (double)GetValue(DesaturationRatioProperty); }
            set { SetValue(DesaturationRatioProperty, value); }
        }
        public static readonly DependencyProperty DesaturationRatioProperty =
            DependencyProperty.Register("DesaturationRatio", typeof(double), typeof(ColorInterpolator), new PropertyMetadata(0d, OnChange));

        public Color ResultColor
        {
            get { return (Color)GetValue(ResultColorProperty); }
            set { SetValue(ResultColorProperty, value); }
        }
        public static readonly DependencyProperty ResultColorProperty =
            DependencyProperty.Register("ResultColor", typeof(Color), typeof(ColorInterpolator), new PropertyMetadata(null));


        private static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorInterpolator builder = (ColorInterpolator)d;
            builder.UpdateResultColor();
        }

        void UpdateResultColor()
        {
            Color color = Colors.White;
            switch (BaseColor)
            {
                case Color:
                    color = (Color)BaseColor;
                    break;
                case SolidColorBrush brush:
                    color = brush.Color;
                    break;
                default:
                    break;
            }

            ResultColor = PartiallyDesaturate(InterpolateColor(color, TargetColor, InterpolationRatio), DesaturationRatio);
        }

        Color InterpolateColor(Color baseColor, Color targetColor, double ratio)
        {

            Color color = Color.FromArgb(
                (byte)(baseColor.A + (ratio * (targetColor.A - baseColor.A))),
                (byte)(baseColor.R + (ratio * (targetColor.R - baseColor.R))),
                (byte)(baseColor.G + (ratio * (targetColor.G - baseColor.G))),
                (byte)(baseColor.B + (ratio * (targetColor.B - baseColor.B))));

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
