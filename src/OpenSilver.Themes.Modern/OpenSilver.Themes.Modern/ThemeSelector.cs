using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenSilver.Themes.Modern
{
    static public class ThemeSelector
    {
        static string _assemblyName;
        static ThemesSelection _currentTheme;

        public static StyleType StyleType { get; set; } = StyleType.Implicit;

        static ThemeSelector()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            _assemblyName = currentAssembly.GetName().Name;
        }

        public static void ApplyApplicationStyle()
        {
            LoadResourceFile("StylesDesign.xaml");
        }

        static public void SelectTheme(ThemesSelection theme)
        {
            _currentTheme = theme;
            LoadResourceFile($"Themes/{theme.ToString()}Theme.xaml");
            ApplyApplicationStyle();
            SaveThemeToIsolatedStorage(theme);
        }


        static void LoadResourceFile(string path)
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri($"/{_assemblyName};component/{path}", UriKind.Relative)
            };
            Application.LoadComponent(resource, resource.Source);
            Application.Current.Resources.MergedDictionaries.Add(resource);
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
