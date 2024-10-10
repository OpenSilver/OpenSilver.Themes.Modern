using System;
using System.Windows;
using System.Windows.Media;
using OpenSilver.Internal.Xaml;

namespace OpenSilver.Themes.Modern
{
    public abstract class Palette
    {
        public static ResourceDictionary LoadPalette(Palette palette)
        {
            if (palette is null)
            {
                throw new ArgumentNullException(nameof(palette));
            }

            var resources = new ResourceDictionary();

            resources[nameof(PrimaryColor)] = palette.PrimaryColor;
            resources["PrimaryBrush"] = new SolidColorBrush(palette.PrimaryColor);

            resources[nameof(DarkColor)] = palette.DarkColor;
            resources["DarkBrush"] = new SolidColorBrush(palette.DarkColor);

            resources[nameof(SecondaryColor)] = palette.SecondaryColor;
            resources["SecondaryBrush"] = new SolidColorBrush(palette.SecondaryColor);

            resources[nameof(HoverColor)] = palette.HoverColor;
            resources["HoverBrush"] = new SolidColorBrush(palette.HoverColor);

            resources[nameof(FadedColor)] = palette.FadedColor;
            resources["FadedBrush"] = new SolidColorBrush(palette.FadedColor);

            resources[nameof(VeryFadedColor)] = palette.VeryFadedColor;
            resources["VeryFadedBrush"] = new SolidColorBrush(palette.VeryFadedColor);

            resources[nameof(TextColor)] = palette.TextColor;
            resources["TextBrush"] = new SolidColorBrush(palette.TextColor);

            resources[nameof(PressColor)] = palette.PressColor;
            resources["PressBrush"] = new SolidColorBrush(palette.PressColor);

            resources[nameof(DisabledColor)] = palette.DisabledColor;
            resources["DisabledBrush"] = new SolidColorBrush(palette.DisabledColor);

            resources[nameof(AccentOverlayColor)] = palette.AccentOverlayColor;
            resources["AccentOverlayBrush"] = new SolidColorBrush(palette.AccentOverlayColor);

            resources[nameof(WatermarkColor)] = palette.WatermarkColor;
            resources["WatermarkBrush"] = new SolidColorBrush(palette.WatermarkColor);

            return resources;
        }

        public static Palette Light { get; } = new LightPalette();

        public static Palette Dark { get; } = new DarkPalette();

        public abstract Color PrimaryColor { get; }
        public abstract Color DarkColor { get; }
        public abstract Color SecondaryColor { get; }
        public abstract Color HoverColor { get; }
        public abstract Color FadedColor { get; }
        public abstract Color VeryFadedColor { get; }
        public abstract Color TextColor { get; }
        public abstract Color PressColor { get; }
        public abstract Color DisabledColor { get; }
        public abstract Color AccentOverlayColor { get; }
        public abstract Color WatermarkColor { get; }

        private sealed class LightPalette : Palette
        {
            public override Color PrimaryColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#1157fa");
            public override Color DarkColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#1134fa");
            public override Color SecondaryColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#ffffff");
            public override Color HoverColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#bababa");
            public override Color FadedColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#bababa");
            public override Color VeryFadedColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#fcfcfc");
            public override Color TextColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#000000");
            public override Color PressColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#000000");
            public override Color DisabledColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#a4a8bf");
            public override Color AccentOverlayColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#000000");
            public override Color WatermarkColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFAAAAAA");
        }

        private sealed class DarkPalette : Palette
        {
            public override Color PrimaryColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#1E2025");
            public override Color DarkColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#1E1025");
            public override Color SecondaryColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#ffffff");
            public override Color HoverColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#bababa");
            public override Color FadedColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#bababa");
            public override Color VeryFadedColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#0c0c0c");
            public override Color TextColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
            public override Color PressColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
            public override Color DisabledColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#a4a8bf");
            public override Color AccentOverlayColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFFFFF");
            public override Color WatermarkColor { get; } = RuntimeHelpers.ConvertFromInvariantString<Color>("#FFAAAAAA");
        }
    }
}
