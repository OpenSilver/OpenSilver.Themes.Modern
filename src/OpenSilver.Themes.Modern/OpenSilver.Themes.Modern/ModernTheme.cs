using System;
using System.Reflection;
using System.Windows;
using OpenSilver.Theming;

namespace OpenSilver.Themes.Modern;

public class ModernTheme : Theme
{
    private readonly ResourceDictionary _paletteResources;
    private Palettes _currentPalette;
    private LightPalette _lightPalette;
    private DarkPalette _darkPalette;

    public ModernTheme()
    {
        var resources = new ResourceDictionary();
        Application.LoadComponent(resources, new Uri("/OpenSilver.Themes.Modern;component/Styles/Styles.xaml", UriKind.Relative));
        Resources.MergedDictionaries.Add(resources);

        _paletteResources = new ResourceDictionary();
        Resources.MergedDictionaries.Add(_paletteResources);
    }

    public Palettes CurrentPalette
    {
        get => _currentPalette;
        set
        {
            if (_currentPalette == value)
            {
                return;
            }

            _currentPalette = value;

            if (IsSealed)
            {
                LoadPalette();
            }
        }
    }

    public LightPalette LightPalette
    {
        get => _lightPalette;
        set
        {
            if (_lightPalette == value) return;

            _lightPalette = value;

            if (IsSealed && CurrentPalette == Palettes.Light)
            {
                LoadPalette();
            }
        }
    }

    public DarkPalette DarkPalette
    {
        get => _darkPalette;
        set
        {
            if (_darkPalette == value) return;

            _darkPalette = value;

            if (IsSealed && CurrentPalette == Palettes.Dark)
            {
                LoadPalette();
            }
        }
    }

    protected override void OnSealed()
    {
        base.OnSealed();

        LoadPalette();
    }

    protected override ResourceDictionary GenerateResources(Assembly assembly)
    {
        string assemblyName = assembly.GetName().Name;

        if (IsSupportedAssembly(assemblyName))
        {
            return CreateDictionary(assemblyName);
        }

        return null;
    }

    private void LoadPalette()
    {
        Palette palette = CurrentPalette == Palettes.Light ? (LightPalette ?? Palette.Light) : (DarkPalette ?? Palette.Dark);

        _paletteResources.BeginInit();
        Palette.LoadPalette(palette, _paletteResources);
        _paletteResources.EndInit();
    }

    private ResourceDictionary CreateDictionary(string assemblyName)
    {
        var resources = new ResourceDictionary();
        resources.MergedDictionaries.Add(_paletteResources);
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
