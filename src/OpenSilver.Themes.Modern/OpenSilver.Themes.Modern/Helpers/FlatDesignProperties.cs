using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern
{
    public static class FlatDesignProperties
    {
        public static Brush GetForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ForegroundProperty);
        }

        public static void SetForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ForegroundProperty, value);
        }

        // Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.RegisterAttached("Foreground", typeof(Brush), typeof(FlatDesignProperties), new PropertyMetadata(new SolidColorBrush(Colors.Black)));


        public static string GetLabel(DependencyObject obj)
        {
            return (string)obj.GetValue(LabelProperty);
        }

        public static void SetLabel(DependencyObject obj, string value)
        {
            obj.SetValue(LabelProperty, value);
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.RegisterAttached("Label", typeof(string), typeof(FlatDesignProperties), new PropertyMetadata(null));



    }
}
