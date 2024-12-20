using OpenSilver.Internal.Xaml;
using System.Windows.Data;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern;

public class LightPalette : Palette
{    
    public override Color BackgroundColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color ContainerBackgroundColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#F9F9F9");

    public override Color PrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#1157fa");
    public override Color ControlBackgroundColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color BorderColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#B5B5B5");
    public override Color AlternateRowColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#F0F0F0");
    public override Color TextColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#000000");
    public override Color TextOnPrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color WatermarkColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFAAAAAA");
    public override Color ErrorColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF5963");

    public override double HoverBrightnessRatio { get; set; } = -20;
    public override double PressBrightnessRatio { get; set; } = -40;

    public override double DisabledInterpolationRatio { get; set; } = 0.2;
    public override double DisabledDesaturationRatio { get; set; } = 0.8;

    public override double ChartHaloOpacity { get; set; } = 0;

    public override BrushEffectMode ChartsBrushEffectMode { get; set; } = BrushEffectMode.Solid;
    public override Color ChartGridLineColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#5A999999");
    public override Color ChartLegendForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF373737");
    public override Color ChartAxisTextForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF777777");

    public override Color ChartSeriesColor1 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#22C87C");
    public override Color ChartSeriesColor2 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#8E67FF");
    public override Color ChartSeriesColor3 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF4963");
    public override Color ChartSeriesColor4 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF9A2D");
    public override Color ChartSeriesColor5 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#ABE165");
    public override Color ChartSeriesColor6 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#2BC9F1");
    public override Color ChartSeriesColor7 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#EF45A5");
    public override Color ChartSeriesColor8 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#E5C701");
    public override Color ChartSeriesColor9 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#AC9C9C");
    public override Color ChartSeriesColor10 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#3FB0FF");
    public override Color ChartSeriesColor11 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF8279");
    public override Color ChartSeriesColor12 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#22CECC");
    public override Color ChartSeriesColor13 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#DDA48B");
    public override Color ChartSeriesColor14 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#4478FA");
    public override Color ChartSeriesColor15 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF7FBB");

    public override double TreeMapContainerOpacity { get; set; } = 0.7;
}
