using System;
using System.Windows;
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

        var resources = new ResourceDictionary
        {
            [nameof(PrimaryColor)] = palette.PrimaryColor,
            ["PrimaryBrush"] = new SolidColorBrush(palette.PrimaryColor),

            [nameof(DarkColor)] = palette.DarkColor,
            ["DarkBrush"] = new SolidColorBrush(palette.DarkColor),

            [nameof(SecondaryColor)] = palette.SecondaryColor,
            ["SecondaryBrush"] = new SolidColorBrush(palette.SecondaryColor),

            [nameof(HoverColor)] = palette.HoverColor,
            ["HoverBrush"] = new SolidColorBrush(palette.HoverColor),

            [nameof(FadedColor)] = palette.FadedColor,
            ["FadedBrush"] = new SolidColorBrush(palette.FadedColor),

            [nameof(VeryFadedColor)] = palette.VeryFadedColor,
            ["VeryFadedBrush"] = new SolidColorBrush(palette.VeryFadedColor),

            [nameof(TextColor)] = palette.TextColor,
            ["TextBrush"] = new SolidColorBrush(palette.TextColor),

            [nameof(TextOverPrimaryColor)] = palette.TextOverPrimaryColor,
            ["TextOverPrimaryBrush"] = new SolidColorBrush(palette.TextOverPrimaryColor),

            [nameof(PressColor)] = palette.PressColor,
            ["PressBrush"] = new SolidColorBrush(palette.PressColor),

            [nameof(DisabledColor)] = palette.DisabledColor,
            ["DisabledBrush"] = new SolidColorBrush(palette.DisabledColor),

            [nameof(AccentOverlayColor)] = palette.AccentOverlayColor,
            ["AccentOverlayBrush"] = new SolidColorBrush(palette.AccentOverlayColor),

            [nameof(WatermarkColor)] = palette.WatermarkColor,
            ["WatermarkBrush"] = new SolidColorBrush(palette.WatermarkColor)
        };

        return resources;
    }

    public static Palette Light { get; } = new LightPalette();

    public static Palette Dark { get; } = new DarkPalette();

    public abstract Color PrimaryColor { get; set; }
    public abstract Color DarkColor { get; set; }
    public abstract Color SecondaryColor { get; set; }
    public abstract Color HoverColor { get; set; }
    public abstract Color FadedColor { get; set; }
    public abstract Color VeryFadedColor { get; set; }
    public abstract Color TextColor { get; set; }
    public abstract Color TextOverPrimaryColor { get; set; }
    public abstract Color PressColor { get; set; }
    public abstract Color DisabledColor { get; set; }
    public abstract Color AccentOverlayColor { get; set; }
    public abstract Color WatermarkColor { get; set; }
}
