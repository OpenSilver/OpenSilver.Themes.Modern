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
}
