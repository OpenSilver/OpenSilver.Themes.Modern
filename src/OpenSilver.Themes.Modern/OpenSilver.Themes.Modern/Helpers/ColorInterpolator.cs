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

        public double Ratio
        {
            get { return (double)GetValue(RatioProperty); }
            set { SetValue(RatioProperty, value); }
        }
        public static readonly DependencyProperty RatioProperty =
            DependencyProperty.Register("Ratio", typeof(double), typeof(ColorInterpolator), new PropertyMetadata(0d, OnChange));

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

            ResultColor = InterpolateColor(color, TargetColor, Ratio);
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
    }
}
