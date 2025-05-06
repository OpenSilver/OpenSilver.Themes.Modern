using System;
using System.Windows.Media;
using System.Windows;

namespace OpenSilver.Themes.Modern
{
    public sealed class BrushEffectBuilder : DependencyObject
    {
        public Color BasedOn
        {
            get => (Color)GetValue(BasedOnProperty);
            set => SetValue(BasedOnProperty, value);
        }

        public static readonly DependencyProperty BasedOnProperty =
            DependencyProperty.Register(
                nameof(BasedOn),
                typeof(Color),
                typeof(BrushEffectBuilder),
                new PropertyMetadata(Colors.White, OnChange));

        public BrushEffectMode Mode
        {
            get => (BrushEffectMode)GetValue(ModeProperty);
            set => SetValue(ModeProperty, value);
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register(
                nameof(Mode),
                typeof(BrushEffectMode),
                typeof(BrushEffectBuilder),
                new PropertyMetadata(BrushEffectMode.Solid, OnChange),
                ValidateMode);

        private static bool ValidateMode(object value)
        {
            BrushEffectMode mode = (BrushEffectMode)value;
            return mode == BrushEffectMode.Solid || mode == BrushEffectMode.Linear;
        }

        private static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((BrushEffectBuilder)d).UpdateBrush();
        }

        public GradientStopCollection GradientStops
        {
            get => (GradientStopCollection)GetValue(GradientStopsProperty);
            private set => SetValue(GradientStopsPropertyKey, value);
        }

        private static readonly DependencyPropertyKey GradientStopsPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(GradientStops),
                typeof(GradientStopCollection),
                typeof(BrushEffectBuilder),
                null);

        public static readonly DependencyProperty GradientStopsProperty = GradientStopsPropertyKey.DependencyProperty;

        private void UpdateBrush()
        {
            Color basedOn = BasedOn;

            switch (Mode)
            {
                case BrushEffectMode.Linear:
                    // Convert base color to HSL (Hue, Saturation, Lightness)
                    double hue, saturation, lightness;
                    ColorToHsl(basedOn, out hue, out saturation, out lightness);

                    // Create a GradientStopCollection with shifted hues
                    var gradientStops = new GradientStopCollection
                    {
                        new GradientStop(basedOn, 0.0),
                        new GradientStop(HslToColor((hue + 10) % 360, saturation, lightness), 0.5),
                        new GradientStop(HslToColor((hue + 20) % 360, saturation, lightness), 1.0),
                    };

                    GradientStops = gradientStops;
                    break;
                case BrushEffectMode.Solid:
                default:
                    var flatGradientStops = new GradientStopCollection
                    {
                        new GradientStop(basedOn, 0.0),
                    };

                    GradientStops = flatGradientStops;
                    break;
            }
        }

        private static void ColorToHsl(Color color, out double hue, out double saturation, out double lightness)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));

            lightness = (max + min) / 2.0;

            if (max == min)
            {
                hue = saturation = 0; // achromatic
            }
            else
            {
                double delta = max - min;
                saturation = lightness > 0.5 ? delta / (2.0 - max - min) : delta / (max + min);

                if (max == r)
                    hue = (g - b) / delta + (g < b ? 6 : 0);
                else if (max == g)
                    hue = (b - r) / delta + 2;
                else
                    hue = (r - g) / delta + 4;

                hue *= 60;
            }
        }

        private static Color HslToColor(double hue, double saturation, double lightness)
        {
            double c = (1 - Math.Abs(2 * lightness - 1)) * saturation;
            double x = c * (1 - Math.Abs((hue / 60) % 2 - 1));
            double m = lightness - c / 2;

            double r = 0, g = 0, b = 0;

            if (0 <= hue && hue < 60)
            {
                r = c; g = x; b = 0;
            }
            else if (60 <= hue && hue < 120)
            {
                r = x; g = c; b = 0;
            }
            else if (120 <= hue && hue < 180)
            {
                r = 0; g = c; b = x;
            }
            else if (180 <= hue && hue < 240)
            {
                r = 0; g = x; b = c;
            }
            else if (240 <= hue && hue < 300)
            {
                r = x; g = 0; b = c;
            }
            else if (300 <= hue && hue < 360)
            {
                r = c; g = 0; b = x;
            }

            byte rByte = (byte)((r + m) * 255);
            byte gByte = (byte)((g + m) * 255);
            byte bByte = (byte)((b + m) * 255);

            return Color.FromRgb(rByte, gByte, bByte);
        }
    }
}
