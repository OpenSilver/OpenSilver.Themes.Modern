using OpenSilver.Internal.Xaml;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern;

public class DarkPalette : Palette
{
    public override Color PrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#6983b9");
    public override Color DarkColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color SecondaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#434659");
    public override Color HoverColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#bababa");
    public override Color FadedColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#496399");
    public override Color VeryFadedColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#232639");
    public override Color TextColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#cad3ff");
    public override Color TextOverPrimaryColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#eef0ff");
    public override Color PressColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color DisabledColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#a4a8bf");
    public override Color AccentOverlayColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
    public override Color WatermarkColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFAAAAAA");



    public override double ChartHaloOpacity { get; set; } = 1;

    //Colors for Charts
    public override Color ChartGridLineColor { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#5A000000");
    public override Color ChartLegendForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFE5E5E5");
    public override Color ChartAxisTextForeground { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FF777777");

    public override Color ChartSeriesColor1 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#B906F7");
    public override Color ChartSeriesColor2 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#0fbfff");
    public override Color ChartSeriesColor3 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#b52724");
    public override Color ChartSeriesColor4 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#b55924");
    public override Color ChartSeriesColor5 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#e6c319");
    public override Color ChartSeriesColor6 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#ace619");
    public override Color ChartSeriesColor7 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#6be619");
    public override Color ChartSeriesColor8 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#19e6a9");
    public override Color ChartSeriesColor9 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#19d2e6");
    public override Color ChartSeriesColor10 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#1945e6");
    public override Color ChartSeriesColor11 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#a919e6");
    public override Color ChartSeriesColor12 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#e619ce");
    public override Color ChartSeriesColor13 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#e61968");
    public override Color ChartSeriesColor14 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#bdbdbd");
    public override Color ChartSeriesColor15 { get; set; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#fcfcfc");
}
