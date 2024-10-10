using System;
using System.IO.IsolatedStorage;
using System.Windows;

namespace OpenSilver.Themes.Modern
{
    public static class ThemeSelector
    {
        private static ThemesSelection _currentTheme;

        public static StyleType StyleType { get; set; } = StyleType.Implicit;

        public static void SelectTheme(ThemesSelection theme)
        {
            _currentTheme = theme;

            ResourceDictionary palette = Palette.LoadPalette(theme == ThemesSelection.Bright ? Palette.Light : Palette.Dark);
            Application.Current.Resources.MergedDictionaries.Add(palette);

            var themeResources = new ResourceDictionary
            {
                Source = new Uri($"/OpenSilver.Themes.Modern;component/StylesDesign.xaml", UriKind.Relative)
            };
            Application.LoadComponent(themeResources, themeResources.Source);
            Application.Current.Resources.MergedDictionaries.Add(themeResources);

            SaveThemeToIsolatedStorage(theme);
        }

        public static void SaveThemeToIsolatedStorage(ThemesSelection value)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings[nameof(ThemesSelection)] = value.ToString();
        }

        //public static void InitializeAI(ThemesSelection themeSelector, StyleType styleType = StyleType.Implicit)
        //{
        //    StyleType = styleType;
        //    SelectTheme(themeSelector);
        //}

        //public static void InitializeAI()
        //{
        //    var themeSelection = RetrieveThemeFromIsolatedStorage();
        //    SelectTheme(themeSelection);
        //}

        public static ThemesSelection GetCurrentTheme()
        {
            if (_currentTheme == ThemesSelection.None)
                _currentTheme = RetrieveThemeFromIsolatedStorage();

            return _currentTheme;
        }

        public static ThemesSelection RetrieveThemeFromIsolatedStorage()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (settings.TryGetValue(nameof(ThemesSelection), out string storedValue))
            {
                return (ThemesSelection)Enum.Parse(typeof(ThemesSelection), storedValue);
            }
            else
            {
                return ThemesSelection.Bright;
            }
        }
    }

    public enum ThemesSelection
    {
        None,
        Dark,
        Bright
    }

    public enum StyleType
    {
        Implicit,
        None
    }
}
