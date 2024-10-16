using OpenSilver.Theming;
using System;
using System.Reflection;
using System.Windows;

namespace OpenSilver.Themes.Modern
{
    public class ModernTheme : Theme
    {
        private Palettes _currentPalette;

        public Palettes CurrentPalette
        {
            get { return _currentPalette; }
            set { _currentPalette = value; }
        }

        public Palette LightPalette { get; set; }

        public Palette DarkPalette { get; set; }

        protected override ResourceDictionary GenerateResources(Assembly assembly)
        {
            string assemblyName = assembly.GetName().Name;

            if (IsSupportedAssembly(assemblyName))
            {
                return CreateDictionary(assemblyName);
            }

            return null;
        }

        private ResourceDictionary CreateDictionary(string assemblyName)
        {
            ResourceDictionary resources = new ResourceDictionary();
            resources.MergedDictionaries.Add(Palette.LoadPalette(
                CurrentPalette == Palettes.Light ? LightPalette ?? Palette.Light
                                                 : DarkPalette ?? Palette.Dark)
                );
            resources.Source = new Uri($"/OpenSilver.Themes.Modern;component/Themes/{assemblyName}.xaml", UriKind.Relative);
            Application.LoadComponent(resources, resources.Source);
            return resources;
        }

        private static bool IsSupportedAssembly(string assemblyName)
        {
            return assemblyName == "OpenSilver" ||
                   assemblyName == "OpenSilver.Controls" ||
                   assemblyName == "OpenSilver.Controls.Toolkit" ||
                   assemblyName == "OpenSilver.Controls.Layout.Toolkit" ||
                   assemblyName == "OpenSilver.Controls.Input" ||
                   assemblyName == "OpenSilver.Controls.Input.Toolkit" ||
                   assemblyName == "OpenSilver.Controls.Data" ||
                   assemblyName == "OpenSilver.Controls.Data.DataForm.Toolkit";
        }

        public enum Palettes
        {
            Light,
            Dark
        }
    }
}
