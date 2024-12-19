using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern;

public abstract class Palette
{
    private const string ThemePrefix = "Theme_";

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
        resources[ThemePrefix + nameof(BackgroundColor)] = palette.BackgroundColor;
        resources["Theme_BackgroundBrush"] = new SolidColorBrush(palette.BackgroundColor);

        resources[ThemePrefix + nameof(ContainerBackgroundColor)] = palette.ContainerBackgroundColor;
        resources["Theme_ContainerBackgroundBrush"] = new SolidColorBrush(palette.ContainerBackgroundColor);

        resources[ThemePrefix + nameof(PrimaryColor)] = palette.PrimaryColor;
        resources["Theme_PrimaryBrush"] = new SolidColorBrush(palette.PrimaryColor);

        resources[ThemePrefix + nameof(ControlBackgroundColor)] = palette.ControlBackgroundColor;
        resources["Theme_ControlBackgroundBrush"] = new SolidColorBrush(palette.ControlBackgroundColor);

        resources[ThemePrefix + nameof(BorderColor)] = palette.BorderColor;
        resources["Theme_BorderBrush"] = new SolidColorBrush(palette.BorderColor);

        resources[ThemePrefix + nameof(AlternateRowColor)] = palette.AlternateRowColor;
        resources["Theme_AlternateRowBrush"] = new SolidColorBrush(palette.AlternateRowColor);

        resources[ThemePrefix + nameof(TextColor)] = palette.TextColor;
        resources["Theme_TextBrush"] = new SolidColorBrush(palette.TextColor);

        resources[ThemePrefix + nameof(TextOnPrimaryColor)] = palette.TextOnPrimaryColor;
        resources["Theme_TextOnPrimaryBrush"] = new SolidColorBrush(palette.TextOnPrimaryColor);

        resources[ThemePrefix + nameof(DisabledColor)] = palette.DisabledColor;
        resources["Theme_DisabledBrush"] = new SolidColorBrush(palette.DisabledColor);

        resources[ThemePrefix + nameof(WatermarkColor)] = palette.WatermarkColor;
        resources["Theme_WatermarkBrush"] = new SolidColorBrush(palette.WatermarkColor);

        resources[ThemePrefix + nameof(ErrorColor)] = palette.ErrorColor;
        resources["Theme_ErrorBrush"] = new SolidColorBrush(palette.ErrorColor);

        resources[ThemePrefix + nameof(BrightnessColorConverter)] = palette.BrightnessColorConverter;

        resources[ThemePrefix + nameof(HoverBrightnessRatio)] = palette.HoverBrightnessRatio;
        resources[ThemePrefix + nameof(PressBrightnessRatio)] = palette.PressBrightnessRatio;
        resources[ThemePrefix + nameof(DisabledBrightnessRatio)] = palette.DisabledBrightnessRatio;

        resources[ThemePrefix + nameof(ChartHaloOpacity)] = palette.ChartHaloOpacity;
        resources[ThemePrefix + nameof(TreeMapContainerOpacity)] = palette.TreeMapContainerOpacity;

        //Colors for charts:

        resources[ThemePrefix + nameof(ChartsBrushEffectMode)] = palette.ChartsBrushEffectMode;
        resources[ThemePrefix + nameof(ChartGridLineColor)] = palette.ChartGridLineColor;
        resources["Theme_ChartGridLineBrush"] = new SolidColorBrush(palette.ChartGridLineColor);
        resources[ThemePrefix + nameof(ChartLegendForeground)] = palette.ChartLegendForeground;
        resources["Theme_ChartLegendForegroundBrush"] = new SolidColorBrush(palette.ChartLegendForeground);
        resources[ThemePrefix + nameof(ChartAxisTextForeground)] = palette.ChartAxisTextForeground;
        resources["Theme_ChartAxisTextForegroundBrush"] = new SolidColorBrush(palette.ChartAxisTextForeground);
        resources[ThemePrefix + nameof(ChartSeriesColor1)] = palette.ChartSeriesColor1;
        resources[ThemePrefix + nameof(ChartSeriesColor2)] = palette.ChartSeriesColor2;
        resources[ThemePrefix + nameof(ChartSeriesColor3)] = palette.ChartSeriesColor3;
        resources[ThemePrefix + nameof(ChartSeriesColor4)] = palette.ChartSeriesColor4;
        resources[ThemePrefix + nameof(ChartSeriesColor5)] = palette.ChartSeriesColor5;
        resources[ThemePrefix + nameof(ChartSeriesColor6)] = palette.ChartSeriesColor6;
        resources[ThemePrefix + nameof(ChartSeriesColor7)] = palette.ChartSeriesColor7;
        resources[ThemePrefix + nameof(ChartSeriesColor8)] = palette.ChartSeriesColor8;
        resources[ThemePrefix + nameof(ChartSeriesColor9)] = palette.ChartSeriesColor9;
        resources[ThemePrefix + nameof(ChartSeriesColor10)] = palette.ChartSeriesColor10;
        resources[ThemePrefix + nameof(ChartSeriesColor11)] = palette.ChartSeriesColor11;
        resources[ThemePrefix + nameof(ChartSeriesColor12)] = palette.ChartSeriesColor12;
        resources[ThemePrefix + nameof(ChartSeriesColor13)] = palette.ChartSeriesColor13;
        resources[ThemePrefix + nameof(ChartSeriesColor14)] = palette.ChartSeriesColor14;
        resources[ThemePrefix + nameof(ChartSeriesColor15)] = palette.ChartSeriesColor15;

        resources[ThemePrefix + nameof(ChartSeriesColorConverter)] = palette.ChartSeriesColorConverter;
    }

    internal static Palette Light { get; } = new LightPalette();

    internal static Palette Dark { get; } = new DarkPalette();

    public abstract Color BackgroundColor { get; set; }
    public abstract Color ContainerBackgroundColor { get; set; }

    public abstract Color PrimaryColor { get; set; }
    public abstract Color ControlBackgroundColor { get; set; }
    public abstract Color BorderColor { get; set; }
    public abstract Color AlternateRowColor { get; set; }
    public abstract Color TextColor { get; set; }
    public abstract Color TextOnPrimaryColor { get; set; }
    public abstract Color DisabledColor { get; set; }
    public abstract Color WatermarkColor { get; set; }
    public abstract Color ErrorColor { get; set; }

    public abstract IValueConverter BrightnessColorConverter { get; set; }

    public abstract double HoverBrightnessRatio { get; set; }
    public abstract double PressBrightnessRatio { get; set; }
    public abstract double DisabledBrightnessRatio { get; set; }

    public abstract double ChartHaloOpacity { get; set; }
    public abstract double TreeMapContainerOpacity { get; set; }
    //Colors for Charts

    public abstract BrushEffectMode ChartsBrushEffectMode { get; set; }
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

    public abstract IValueConverter ChartSeriesColorConverter { get; set; }
}
