using System;
using System.Windows;
using System.Windows.Data;
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
            [nameof(Theme_PrimaryColor)] = palette.Theme_PrimaryColor,
            ["Theme_PrimaryBrush"] = new SolidColorBrush(palette.Theme_PrimaryColor),

            [nameof(Theme_ControlBackgroundColor)] = palette.Theme_ControlBackgroundColor,
            ["Theme_ControlBackgroundBrush"] = new SolidColorBrush(palette.Theme_ControlBackgroundColor),

            [nameof(Theme_BorderColor)] = palette.Theme_BorderColor,
            ["Theme_BorderBrush"] = new SolidColorBrush(palette.Theme_BorderColor),

            [nameof(Theme_AlternatingRowBackgroundColor)] = palette.Theme_AlternatingRowBackgroundColor,
            ["Theme_AlternatingRowBackgroundBrush"] = new SolidColorBrush(palette.Theme_AlternatingRowBackgroundColor),

            [nameof(Theme_TextColor)] = palette.Theme_TextColor,
            ["Theme_TextBrush"] = new SolidColorBrush(palette.Theme_TextColor),

            [nameof(Theme_TextOverPrimaryColor)] = palette.Theme_TextOverPrimaryColor,
            ["Theme_TextOverPrimaryBrush"] = new SolidColorBrush(palette.Theme_TextOverPrimaryColor),

            [nameof(Theme_DisabledColor)] = palette.Theme_DisabledColor,
            ["Theme_DisabledBrush"] = new SolidColorBrush(palette.Theme_DisabledColor),

            [nameof(Theme_AccentOverlayColor)] = palette.Theme_AccentOverlayColor,
            ["Theme_AccentOverlayBrush"] = new SolidColorBrush(palette.Theme_AccentOverlayColor),

            [nameof(Theme_WatermarkColor)] = palette.Theme_WatermarkColor,
            ["Theme_WatermarkBrush"] = new SolidColorBrush(palette.Theme_WatermarkColor),

            [nameof(Theme_BrightnessColorConverter)] = palette.Theme_BrightnessColorConverter,

            [nameof(Theme_ChartHaloOpacity)] = palette.Theme_ChartHaloOpacity,

            //Colors for charts:
            [nameof(Theme_ChartGridLineColor)] = palette.Theme_ChartGridLineColor,
            ["Theme_ChartGridLineBrush"] = new SolidColorBrush(palette.Theme_ChartGridLineColor),
            [nameof(Theme_ChartLegendForeground)] = palette.Theme_ChartLegendForeground,
            ["Theme_ChartLegendForegroundBrush"] = new SolidColorBrush(palette.Theme_ChartLegendForeground),
            [nameof(Theme_ChartAxisTextForeground)] = palette.Theme_ChartAxisTextForeground,
            ["Theme_ChartAxisTextForegroundBrush"] = new SolidColorBrush(palette.Theme_ChartAxisTextForeground),
            [nameof(Theme_ChartSeriesColor1)] = palette.Theme_ChartSeriesColor1,
            [nameof(Theme_ChartSeriesColor2)] = palette.Theme_ChartSeriesColor2,
            [nameof(Theme_ChartSeriesColor3)] = palette.Theme_ChartSeriesColor3,
            [nameof(Theme_ChartSeriesColor4)] = palette.Theme_ChartSeriesColor4,
            [nameof(Theme_ChartSeriesColor5)] = palette.Theme_ChartSeriesColor5,
            [nameof(Theme_ChartSeriesColor6)] = palette.Theme_ChartSeriesColor6,
            [nameof(Theme_ChartSeriesColor7)] = palette.Theme_ChartSeriesColor7,
            [nameof(Theme_ChartSeriesColor8)] = palette.Theme_ChartSeriesColor8,
            [nameof(Theme_ChartSeriesColor9)] = palette.Theme_ChartSeriesColor9,
            [nameof(Theme_ChartSeriesColor10)] = palette.Theme_ChartSeriesColor10,
            [nameof(Theme_ChartSeriesColor11)] = palette.Theme_ChartSeriesColor11,
            [nameof(Theme_ChartSeriesColor12)] = palette.Theme_ChartSeriesColor12,
            [nameof(Theme_ChartSeriesColor13)] = palette.Theme_ChartSeriesColor13,
            [nameof(Theme_ChartSeriesColor14)] = palette.Theme_ChartSeriesColor14,
            [nameof(Theme_ChartSeriesColor15)] = palette.Theme_ChartSeriesColor15,

            [nameof(Theme_ChartSeriesColorConverter)] = palette.Theme_ChartSeriesColorConverter

        };

        return resources;
    }

    public static Palette Light { get; } = new LightPalette();

    public static Palette Dark { get; } = new DarkPalette();

    public abstract Color Theme_PrimaryColor { get; set; }
    public abstract Color Theme_ControlBackgroundColor { get; set; }
    public abstract Color Theme_BorderColor { get; set; }
    public abstract Color Theme_AlternatingRowBackgroundColor { get; set; }
    public abstract Color Theme_TextColor { get; set; }
    public abstract Color Theme_TextOverPrimaryColor { get; set; }
    public abstract Color Theme_DisabledColor { get; set; }
    public abstract Color Theme_AccentOverlayColor { get; set; }
    public abstract Color Theme_WatermarkColor { get; set; }

    public abstract IValueConverter Theme_BrightnessColorConverter { get; set; }


    public abstract double Theme_ChartHaloOpacity { get; set; }
    //Colors for Charts
    public abstract Color Theme_ChartGridLineColor { get; set; }
    public abstract Color Theme_ChartLegendForeground { get; set; }
    public abstract Color Theme_ChartAxisTextForeground { get; set; }
    public abstract Color Theme_ChartSeriesColor1 { get; set; }
    public abstract Color Theme_ChartSeriesColor2 { get; set; }
    public abstract Color Theme_ChartSeriesColor3 { get; set; }
    public abstract Color Theme_ChartSeriesColor4 { get; set; }
    public abstract Color Theme_ChartSeriesColor5 { get; set; }
    public abstract Color Theme_ChartSeriesColor6 { get; set; }
    public abstract Color Theme_ChartSeriesColor7 { get; set; }
    public abstract Color Theme_ChartSeriesColor8 { get; set; }
    public abstract Color Theme_ChartSeriesColor9 { get; set; }
    public abstract Color Theme_ChartSeriesColor10 { get; set; }
    public abstract Color Theme_ChartSeriesColor11 { get; set; }
    public abstract Color Theme_ChartSeriesColor12 { get; set; }
    public abstract Color Theme_ChartSeriesColor13 { get; set; }
    public abstract Color Theme_ChartSeriesColor14 { get; set; }
    public abstract Color Theme_ChartSeriesColor15 { get; set; }

    public abstract IValueConverter Theme_ChartSeriesColorConverter { get; set; }
}
