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

        var resources = new ResourceDictionary();
        LoadPalette(palette, resources);

        return resources;
    }

    internal static void LoadPalette(Palette palette, ResourceDictionary resources)
    {
        resources[nameof(Theme_PrimaryColor)] = palette.Theme_PrimaryColor;
        resources["Theme_PrimaryBrush"] = new SolidColorBrush(palette.Theme_PrimaryColor);

        resources[nameof(Theme_ControlBackgroundColor)] = palette.Theme_ControlBackgroundColor;
        resources["Theme_ControlBackgroundBrush"] = new SolidColorBrush(palette.Theme_ControlBackgroundColor);

        resources[nameof(Theme_BorderColor)] = palette.Theme_BorderColor;
        resources["Theme_BorderBrush"] = new SolidColorBrush(palette.Theme_BorderColor);

        resources[nameof(Theme_AlternatingRowBackgroundColor)] = palette.Theme_AlternatingRowBackgroundColor;
        resources["Theme_AlternatingRowBackgroundBrush"] = new SolidColorBrush(palette.Theme_AlternatingRowBackgroundColor);

        resources[nameof(Theme_TextColor)] = palette.Theme_TextColor;
        resources["Theme_TextBrush"] = new SolidColorBrush(palette.Theme_TextColor);

        resources[nameof(Theme_TextOverPrimaryColor)] = palette.Theme_TextOverPrimaryColor;
        resources["Theme_TextOverPrimaryBrush"] = new SolidColorBrush(palette.Theme_TextOverPrimaryColor);

        resources[nameof(Theme_DisabledColor)] = palette.Theme_DisabledColor;
        resources["Theme_DisabledBrush"] = new SolidColorBrush(palette.Theme_DisabledColor);

        resources[nameof(Theme_AccentOverlayColor)] = palette.Theme_AccentOverlayColor;
        resources["Theme_AccentOverlayBrush"] = new SolidColorBrush(palette.Theme_AccentOverlayColor);

        resources[nameof(Theme_WatermarkColor)] = palette.Theme_WatermarkColor;
        resources["Theme_WatermarkBrush"] = new SolidColorBrush(palette.Theme_WatermarkColor);

        resources[nameof(Theme_BrightnessColorConverter)] = palette.Theme_BrightnessColorConverter;

        resources[nameof(Theme_HoverBrightnessRatio)] = palette.Theme_HoverBrightnessRatio;
        resources[nameof(Theme_PressBrightnessRatio)] = palette.Theme_PressBrightnessRatio;

        resources[nameof(Theme_ChartHaloOpacity)] = palette.Theme_ChartHaloOpacity;

        //Colors for charts:
        
        resources[nameof(Theme_ChartsBrushEffectMode)] = palette.Theme_ChartsBrushEffectMode;
        resources[nameof(Theme_ChartGridLineColor)] = palette.Theme_ChartGridLineColor;
        resources["Theme_ChartGridLineBrush"] = new SolidColorBrush(palette.Theme_ChartGridLineColor);
        resources[nameof(Theme_ChartLegendForeground)] = palette.Theme_ChartLegendForeground;
        resources["Theme_ChartLegendForegroundBrush"] = new SolidColorBrush(palette.Theme_ChartLegendForeground);
        resources[nameof(Theme_ChartAxisTextForeground)] = palette.Theme_ChartAxisTextForeground;
        resources["Theme_ChartAxisTextForegroundBrush"] = new SolidColorBrush(palette.Theme_ChartAxisTextForeground);
        resources[nameof(Theme_ChartSeriesColor1)] = palette.Theme_ChartSeriesColor1;
        resources[nameof(Theme_ChartSeriesColor2)] = palette.Theme_ChartSeriesColor2;
        resources[nameof(Theme_ChartSeriesColor3)] = palette.Theme_ChartSeriesColor3;
        resources[nameof(Theme_ChartSeriesColor4)] = palette.Theme_ChartSeriesColor4;
        resources[nameof(Theme_ChartSeriesColor5)] = palette.Theme_ChartSeriesColor5;
        resources[nameof(Theme_ChartSeriesColor6)] = palette.Theme_ChartSeriesColor6;
        resources[nameof(Theme_ChartSeriesColor7)] = palette.Theme_ChartSeriesColor7;
        resources[nameof(Theme_ChartSeriesColor8)] = palette.Theme_ChartSeriesColor8;
        resources[nameof(Theme_ChartSeriesColor9)] = palette.Theme_ChartSeriesColor9;
        resources[nameof(Theme_ChartSeriesColor10)] = palette.Theme_ChartSeriesColor10;
        resources[nameof(Theme_ChartSeriesColor11)] = palette.Theme_ChartSeriesColor11;
        resources[nameof(Theme_ChartSeriesColor12)] = palette.Theme_ChartSeriesColor12;
        resources[nameof(Theme_ChartSeriesColor13)] = palette.Theme_ChartSeriesColor13;
        resources[nameof(Theme_ChartSeriesColor14)] = palette.Theme_ChartSeriesColor14;
        resources[nameof(Theme_ChartSeriesColor15)] = palette.Theme_ChartSeriesColor15;

        resources[nameof(Theme_ChartSeriesColorConverter)] = palette.Theme_ChartSeriesColorConverter;
    }

    internal static Palette Light { get; } = new LightPalette();

    internal static Palette Dark { get; } = new DarkPalette();

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

    public abstract double Theme_HoverBrightnessRatio { get; set; }
    public abstract double Theme_PressBrightnessRatio { get; set; }

    public abstract double Theme_ChartHaloOpacity { get; set; }
    //Colors for Charts
    
    public abstract BrushEffectMode Theme_ChartsBrushEffectMode { get; set; }
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
