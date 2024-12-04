using OpenSilver.Internal.Xaml;
using System.Windows.Data;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern;

public class LightPalette : Palette
{
    public override Color Theme_PrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#1157fa");
    public override Color Theme_ControlBackgroundColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#ffffff");
    public override Color Theme_BorderColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#bababa");
    public override Color Theme_AlternatingRowBackgroundColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#fcfcfc");
    public override Color Theme_TextColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#000000");
    public override Color Theme_TextOverPrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color Theme_DisabledColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#a4a8bf");
    public override Color Theme_AccentOverlayColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#000000");
    public override Color Theme_WatermarkColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFAAAAAA");

    public override IValueConverter Theme_BrightnessColorConverter { get; set; } = new DarkenColorConverter();


    public override double Theme_ChartHaloOpacity { get; set; } = 0;

    public override Color Theme_ChartGridLineColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#5A999999");
    public override Color Theme_ChartLegendForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF373737");
    public override Color Theme_ChartAxisTextForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF777777");

    public override Color Theme_ChartSeriesColor1 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF5DA0");
    public override Color Theme_ChartSeriesColor2 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#DC364A");
    public override Color Theme_ChartSeriesColor3 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FA7741");
    public override Color Theme_ChartSeriesColor4 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#AC6600");
    public override Color Theme_ChartSeriesColor5 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#B09E00");
    public override Color Theme_ChartSeriesColor6 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#548400");
    public override Color Theme_ChartSeriesColor7 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#2FB44F");
    public override Color Theme_ChartSeriesColor8 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#008F5C");
    public override Color Theme_ChartSeriesColor9 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#00BAB5");
    public override Color Theme_ChartSeriesColor10 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#666666");
    public override Color Theme_ChartSeriesColor11 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#00B3FF");
    public override Color Theme_ChartSeriesColor12 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#0082EE");
    public override Color Theme_ChartSeriesColor13 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#6797FF");
    public override Color Theme_ChartSeriesColor14 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#955AD0");
    public override Color Theme_ChartSeriesColor15 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#999999");

    public override IValueConverter Theme_ChartSeriesColorConverter { get; set; } = new ColorToFlatGradientStopsConverter();

}
