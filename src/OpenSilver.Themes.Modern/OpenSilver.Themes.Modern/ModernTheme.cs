using OpenSilver.Theming;
using System;
using System.Reflection;
using System.Windows;

namespace OpenSilver.Themes.Modern;

public class ModernTheme : Theme
{
    private Palettes _currentPalette;
    public Palettes CurrentPalette
    {
        get { return _currentPalette; }
        set { _currentPalette = value; }
    }

    public LightPalette LightPalette { get; set; }

    public DarkPalette DarkPalette { get; set; }

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
        var resources = new ResourceDictionary();
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
        return assemblyName is
            "OpenSilver" or
            "OpenSilver.Controls" or
            "OpenSilver.Controls.Toolkit" or
            "OpenSilver.Controls.Layout.Toolkit" or
            "OpenSilver.Controls.Input" or
            "OpenSilver.Controls.Input.Toolkit" or
            "OpenSilver.Controls.Data" or
            "OpenSilver.Controls.DataVisualization.Toolkit" or
            "OpenSilver.Controls.Data.DataForm.Toolkit";
    }

    public enum Palettes
    {
        Light,
        Dark
    }
}
