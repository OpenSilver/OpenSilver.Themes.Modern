using System;
using System.Windows;

namespace OpenSilver.Themes.Modern
{
    public static class FlatDesignProperties
    {
        public static string GetLabel(DependencyObject obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return (string)obj.GetValue(LabelProperty);
        }

        public static void SetLabel(DependencyObject obj, string value)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.RegisterAttached(
                "Label",
                typeof(string),
                typeof(FlatDesignProperties),
                new PropertyMetadata(string.Empty));
    }
}
