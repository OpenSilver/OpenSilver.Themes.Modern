﻿using OpenSilver.Internal.Xaml;
using System.Windows.Data;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern;

public class DarkPalette : Palette
{
    public override Color Theme_PrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#6983b9");
    public override Color Theme_ControlBackgroundColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#434659");
    public override Color Theme_BorderColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#496399");
    public override Color Theme_AlternatingRowBackgroundColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#232639");
    public override Color Theme_TextColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#cad3ff");
    public override Color Theme_TextOverPrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#eef0ff");
    public override Color Theme_DisabledColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#a4a8bf");
    public override Color Theme_AccentOverlayColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color Theme_WatermarkColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFAAAAAA");

    public override IValueConverter Theme_BrightnessColorConverter { get; set; } = new BrightenColorConverter();

    public override double Theme_HoverBrightnessRatio { get; set; } = 20;
    public override double Theme_PressBrightnessRatio { get; set; } = 40;

    public override double Theme_ChartHaloOpacity { get; set; } = 1;

    //Colors for Charts
    public override BrushEffectMode Theme_ChartsBrushEffectMode { get; set; } = BrushEffectMode.Linear;
    public override Color Theme_ChartGridLineColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF1B1B1B");
    public override Color Theme_ChartLegendForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFE5E5E5");
    public override Color Theme_ChartAxisTextForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF777777");

    public override Color Theme_ChartSeriesColor1 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#BB33FF");
    public override Color Theme_ChartSeriesColor2 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#F5FF33");
    public override Color Theme_ChartSeriesColor3 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF6633");
    public override Color Theme_ChartSeriesColor4 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#33FF66");
    public override Color Theme_ChartSeriesColor5 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF1A75");
    public override Color Theme_ChartSeriesColor6 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#33FFE0");
    public override Color Theme_ChartSeriesColor7 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color Theme_ChartSeriesColor8 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF4747");
    public override Color Theme_ChartSeriesColor9 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#3399FF");
    public override Color Theme_ChartSeriesColor10 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF66FF");
    public override Color Theme_ChartSeriesColor11 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFB833");
    public override Color Theme_ChartSeriesColor12 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#8033FF");
    public override Color Theme_ChartSeriesColor13 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#888888");
    public override Color Theme_ChartSeriesColor14 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#CCCCCC");
    public override Color Theme_ChartSeriesColor15 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#57FF33");

    public override IValueConverter Theme_ChartSeriesColorConverter { get; set; } = new ColorToGradientStopsConverter();

    

}
