using OpenSilver.Themes.Modern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ModernThemeTest
{
    public sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Apply theme globally. Controls with a DefaultStyleKey will first try to find a style in this theme,
            // and fall back to the default theme (generic.xaml) if no style could be found.
            //Theme = new ModernTheme() {  CurrentPalette = ModernTheme.Palettes.Dark};

            // Import themes in application resources. Styles are then used implicitely or via static resources.
            //ThemeSelector.SelectTheme(ThemesSelection.Dark);

            var mainPage = new MainPage();
            Window.Current.Content = mainPage;
        }
    }
}
