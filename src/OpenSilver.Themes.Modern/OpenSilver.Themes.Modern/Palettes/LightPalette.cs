using OpenSilver.Internal.Xaml;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern;

public class LightPalette : Palette
{
    public override Color PrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#1157fa");
    public override Color DarkColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#1134fa");
    public override Color SecondaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#ffffff");
    public override Color HoverColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#bababa");
    public override Color FadedColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#bababa");
    public override Color VeryFadedColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#fcfcfc");
    public override Color TextColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#000000");
    public override Color TextOverPrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color PressColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#000000");
    public override Color DisabledColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#a4a8bf");
    public override Color AccentOverlayColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#000000");
    public override Color WatermarkColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFAAAAAA");

    public override double ChartHaloOpacity { get; set; } = 0;

    public override Color ChartGridLineColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#5A999999");
    public override Color ChartLegendForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF373737");
    public override Color ChartAxisTextForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF777777");

    public override Color ChartSeriesColor1 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#1F77B4");
    public override Color ChartSeriesColor2 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF7F0E");
    public override Color ChartSeriesColor3 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#2CA02C");
    public override Color ChartSeriesColor4 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#D62728");
    public override Color ChartSeriesColor5 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#9467BD");
    public override Color ChartSeriesColor6 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#8C564B");
    public override Color ChartSeriesColor7 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#E377C2");
    public override Color ChartSeriesColor8 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#7F7F7F");
    public override Color ChartSeriesColor9 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#BCBD22");
    public override Color ChartSeriesColor10 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#17BECF");
    public override Color ChartSeriesColor11 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#F7B6D2");
    public override Color ChartSeriesColor12 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#C5B0D5");
    public override Color ChartSeriesColor13 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFBB78");
    public override Color ChartSeriesColor14 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#98DF8A");
    public override Color ChartSeriesColor15 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF9896");
}
