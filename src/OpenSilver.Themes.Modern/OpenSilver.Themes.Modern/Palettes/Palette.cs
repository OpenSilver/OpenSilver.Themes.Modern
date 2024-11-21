using System;
using System.Windows;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern;

public abstract class Palette
{
    public static ResourceDictionary LoadPalette(Palette palette)
    {
        if (palette is null)
        {
            throw new ArgumentNullException(nameof(palette));
        }

        var resources = new ResourceDictionary
        {
            [nameof(PrimaryColor)] = palette.PrimaryColor,
            ["PrimaryBrush"] = new SolidColorBrush(palette.PrimaryColor),

            [nameof(DarkColor)] = palette.DarkColor,
            ["DarkBrush"] = new SolidColorBrush(palette.DarkColor),

            [nameof(SecondaryColor)] = palette.SecondaryColor,
            ["SecondaryBrush"] = new SolidColorBrush(palette.SecondaryColor),

            [nameof(HoverColor)] = palette.HoverColor,
            ["HoverBrush"] = new SolidColorBrush(palette.HoverColor),

            [nameof(FadedColor)] = palette.FadedColor,
            ["FadedBrush"] = new SolidColorBrush(palette.FadedColor),

            [nameof(VeryFadedColor)] = palette.VeryFadedColor,
            ["VeryFadedBrush"] = new SolidColorBrush(palette.VeryFadedColor),

            [nameof(TextColor)] = palette.TextColor,
            ["TextBrush"] = new SolidColorBrush(palette.TextColor),

            [nameof(TextOverPrimaryColor)] = palette.TextOverPrimaryColor,
            ["TextOverPrimaryBrush"] = new SolidColorBrush(palette.TextOverPrimaryColor),

            [nameof(PressColor)] = palette.PressColor,
            ["PressBrush"] = new SolidColorBrush(palette.PressColor),

            [nameof(DisabledColor)] = palette.DisabledColor,
            ["DisabledBrush"] = new SolidColorBrush(palette.DisabledColor),

            [nameof(AccentOverlayColor)] = palette.AccentOverlayColor,
            ["AccentOverlayBrush"] = new SolidColorBrush(palette.AccentOverlayColor),

            [nameof(WatermarkColor)] = palette.WatermarkColor,
            ["WatermarkBrush"] = new SolidColorBrush(palette.WatermarkColor),

            [nameof(ChartHaloOpacity)] = palette.ChartHaloOpacity,

            //Colors for charts:
            [nameof(ChartGridLineColor)] = palette.ChartGridLineColor,
            ["ChartGridLineBrush"] = new SolidColorBrush(palette.ChartGridLineColor),
            [nameof(ChartLegendForeground)] = palette.ChartLegendForeground,
            ["ChartLegendForegroundBrush"] = new SolidColorBrush(palette.ChartLegendForeground),
            [nameof(ChartAxisTextForeground)] = palette.ChartAxisTextForeground,
            ["ChartAxisTextForegroundBrush"] = new SolidColorBrush(palette.ChartAxisTextForeground),
            [nameof(ChartSeriesColor1)] = palette.ChartSeriesColor1,
            [nameof(ChartSeriesColor2)] = palette.ChartSeriesColor2,
            [nameof(ChartSeriesColor3)] = palette.ChartSeriesColor3,
            [nameof(ChartSeriesColor4)] = palette.ChartSeriesColor4,
            [nameof(ChartSeriesColor5)] = palette.ChartSeriesColor5,
            [nameof(ChartSeriesColor6)] = palette.ChartSeriesColor6,
            [nameof(ChartSeriesColor7)] = palette.ChartSeriesColor7,
            [nameof(ChartSeriesColor8)] = palette.ChartSeriesColor8,
            [nameof(ChartSeriesColor9)] = palette.ChartSeriesColor9,
            [nameof(ChartSeriesColor10)] = palette.ChartSeriesColor10,
            [nameof(ChartSeriesColor11)] = palette.ChartSeriesColor11,
            [nameof(ChartSeriesColor12)] = palette.ChartSeriesColor12,
            [nameof(ChartSeriesColor13)] = palette.ChartSeriesColor13,
            [nameof(ChartSeriesColor14)] = palette.ChartSeriesColor14,
            [nameof(ChartSeriesColor15)] = palette.ChartSeriesColor15
        };

        return resources;
    }

    public static Palette Light { get; } = new LightPalette();

    public static Palette Dark { get; } = new DarkPalette();

    public abstract Color PrimaryColor { get; set; }
    public abstract Color DarkColor { get; set; }
    public abstract Color SecondaryColor { get; set; }
    public abstract Color HoverColor { get; set; }
    public abstract Color FadedColor { get; set; }
    public abstract Color VeryFadedColor { get; set; }
    public abstract Color TextColor { get; set; }
    public abstract Color TextOverPrimaryColor { get; set; }
    public abstract Color PressColor { get; set; }
    public abstract Color DisabledColor { get; set; }
    public abstract Color AccentOverlayColor { get; set; }
    public abstract Color WatermarkColor { get; set; }

    public abstract double ChartHaloOpacity { get; set; }
    //Colors for Charts
    public abstract Color ChartGridLineColor { get; set; }
    public abstract Color ChartLegendForeground { get; set; }
    public abstract Color ChartAxisTextForeground { get; set; }
    public abstract Color ChartSeriesColor1 { get; set; }
    public abstract Color ChartSeriesColor2 { get; set; }
    public abstract Color ChartSeriesColor3 { get; set; }
    public abstract Color ChartSeriesColor4 { get; set; }
    public abstract Color ChartSeriesColor5 { get; set; }
    public abstract Color ChartSeriesColor6 { get; set; }
    public abstract Color ChartSeriesColor7 { get; set; }
    public abstract Color ChartSeriesColor8 { get; set; }
    public abstract Color ChartSeriesColor9 { get; set; }
    public abstract Color ChartSeriesColor10 { get; set; }
    public abstract Color ChartSeriesColor11 { get; set; }
    public abstract Color ChartSeriesColor12 { get; set; }
    public abstract Color ChartSeriesColor13 { get; set; }
    public abstract Color ChartSeriesColor14 { get; set; }
    public abstract Color ChartSeriesColor15 { get; set; }
}
