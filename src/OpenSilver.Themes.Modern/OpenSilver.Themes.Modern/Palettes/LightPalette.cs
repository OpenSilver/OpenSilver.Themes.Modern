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
    public override Color DisabledColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#D4D4D4");
    public override Color WatermarkColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFAAAAAA");

    public override IValueConverter BrightnessColorConverter { get; set; } = new DarkenColorConverter();

    public override double HoverBrightnessRatio { get; set; } = -20;
    public override double PressBrightnessRatio { get; set; } = -40;
    
    public override double ChartHaloOpacity { get; set; } = 0;

    public override BrushEffectMode ChartsBrushEffectMode { get; set; } = BrushEffectMode.Solid;
    public override Color ChartGridLineColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#5A999999");
    public override Color ChartLegendForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF373737");
    public override Color ChartAxisTextForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF777777");

    public override Color ChartSeriesColor1 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF5DA0");
    public override Color ChartSeriesColor2 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#DC364A");
    public override Color ChartSeriesColor3 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FA7741");
    public override Color ChartSeriesColor4 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#AC6600");
    public override Color ChartSeriesColor5 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#B09E00");
    public override Color ChartSeriesColor6 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#548400");
    public override Color ChartSeriesColor7 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#2FB44F");
    public override Color ChartSeriesColor8 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#008F5C");
    public override Color ChartSeriesColor9 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#00BAB5");
    public override Color ChartSeriesColor10 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#666666");
    public override Color ChartSeriesColor11 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#00B3FF");
    public override Color ChartSeriesColor12 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#0082EE");
    public override Color ChartSeriesColor13 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#6797FF");
    public override Color ChartSeriesColor14 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#955AD0");
    public override Color ChartSeriesColor15 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#999999");

    public override IValueConverter ChartSeriesColorConverter { get; set; } = new ColorToFlatGradientStopsConverter();

}
