using OpenSilver.Internal.Xaml;
using System.Windows.Data;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern;

public class DarkPalette : Palette
{
    public override Color BackgroundColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#000000");
    public override Color ContainerBackgroundColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#0D0D0D");

    public override Color PrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#0C68E9");
    public override Color ControlBackgroundColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#141414");
    public override Color BorderColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#303030");
    public override Color AlternateRowColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#212121");
    public override Color TextColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#DEDEDE");
    public override Color TextOnPrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color DisabledColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#171717");
    public override Color WatermarkColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#575757");

    public override IValueConverter BrightnessColorConverter { get; set; } = new BrightenColorConverter();

    public override double HoverBrightnessRatio { get; set; } = 20;
    public override double PressBrightnessRatio { get; set; } = 40;

    public override double ChartHaloOpacity { get; set; } = 1;

    //Colors for Charts
    public override BrushEffectMode ChartsBrushEffectMode { get; set; } = BrushEffectMode.Linear;
    public override Color ChartGridLineColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF1B1B1B");
    public override Color ChartLegendForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFE5E5E5");
    public override Color ChartAxisTextForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF777777");

    public override Color ChartSeriesColor1 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#BB33FF");
    public override Color ChartSeriesColor2 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#F5FF33");
    public override Color ChartSeriesColor3 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF6633");
    public override Color ChartSeriesColor4 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#33FF66");
    public override Color ChartSeriesColor5 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF1A75");
    public override Color ChartSeriesColor6 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#33FFE0");
    public override Color ChartSeriesColor7 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color ChartSeriesColor8 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF4747");
    public override Color ChartSeriesColor9 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#3399FF");
    public override Color ChartSeriesColor10 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF66FF");
    public override Color ChartSeriesColor11 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFB833");
    public override Color ChartSeriesColor12 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#8033FF");
    public override Color ChartSeriesColor13 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#888888");
    public override Color ChartSeriesColor14 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#CCCCCC");
    public override Color ChartSeriesColor15 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#57FF33");

    public override IValueConverter ChartSeriesColorConverter { get; set; } = new ColorToGradientStopsConverter();

    

}
