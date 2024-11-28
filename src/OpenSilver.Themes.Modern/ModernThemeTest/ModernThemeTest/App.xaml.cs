using OpenSilver.Themes.Modern;
using System.Windows;

namespace ModernThemeTest
{
    public sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Resources.MergedDictionaries.Add((Theme as ModernTheme).ThemeResources);

            var mainPage = new MainPage();
            Window.Current.Content = mainPage;
        }
    }
}
