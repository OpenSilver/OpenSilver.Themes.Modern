using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OpenSilver.Themes.Modern
{
    public static class InkPresenterExtensions
    {
        private static readonly DependencyProperty BorderInstanceProperty =
           DependencyProperty.RegisterAttached(
               "BorderInstance",
               typeof(Border),
               typeof(InkPresenterExtensions),
               new PropertyMetadata(null));

        private static void SetBorderInstance(DependencyObject obj, Border value) =>
            obj.SetValue(BorderInstanceProperty, value);

        private static Border GetBorderInstance(DependencyObject obj) =>
            (Border)obj.GetValue(BorderInstanceProperty);


        public static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.RegisterAttached(
                "BorderBrush", typeof(Brush), typeof(InkPresenterExtensions),
                new PropertyMetadata(default(Brush), OnBorderBrushChanged));

        public static void SetBorderBrush(UIElement element, Brush value)
        {
            element.SetValue(BorderBrushProperty, value);
        }

        public static Brush GetBorderBrush(UIElement element)
        {
            return (Brush)element.GetValue(BorderBrushProperty);
        }

        private static void OnBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ApplyBorder(d);
        }

        public static readonly DependencyProperty BorderThicknessProperty =
    DependencyProperty.RegisterAttached(
        "BorderThickness", typeof(Thickness), typeof(InkPresenterExtensions),
        new PropertyMetadata(default(Thickness), OnBorderThicknessChanged));

        public static void SetBorderThickness(UIElement element, Thickness value)
        {
            element.SetValue(BorderThicknessProperty, value);
        }

        public static Thickness GetBorderThickness(UIElement element)
        {
            return (Thickness)element.GetValue(BorderThicknessProperty);
        }

        private static void OnBorderThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ApplyBorder(d);
        }

        private static void ApplyBorder(DependencyObject dependencyObject)
        {

            if (dependencyObject is InkPresenter inkPresenter)
            {
                var parent = VisualTreeHelper.GetParent(inkPresenter);
                if (parent == null)
                {
                    inkPresenter.Loaded += (sender, args) => ApplyOrUpdateBorder(inkPresenter);
                }
                else
                {
                    try
                    {
                        ApplyOrUpdateBorder(inkPresenter);

                    }
                    catch
                    {
                        // Ignore, basically it will be trying to update the border before it is created
                    }
                }

            }
        }

        private static void ApplyOrUpdateBorder(InkPresenter inkPresenter)
        {
            var parent = VisualTreeHelper.GetParent(inkPresenter) as Panel;
            if (parent == null)
                return;


            parent.Children.Remove(inkPresenter);

            var existingBorder = GetBorderInstance(inkPresenter);
            if (existingBorder == null)
            {
                var border = new Border
                {
                    Width = inkPresenter.Width,
                    Height = inkPresenter.Height,
                    HorizontalAlignment = inkPresenter.HorizontalAlignment,
                    VerticalAlignment = inkPresenter.VerticalAlignment,
                    Background = inkPresenter.Background,
                    Visibility = inkPresenter.Visibility,
                    IsEnabled = inkPresenter.IsEnabled,
                    Margin = inkPresenter.Margin,
                    Child = inkPresenter,
                    CornerRadius = new CornerRadius(4),
                };
                SetBorderInstance(inkPresenter, border);

                Canvas.SetLeft(border, Canvas.GetLeft(inkPresenter));
                Canvas.SetTop(border, Canvas.GetTop(inkPresenter));
                Canvas.SetZIndex(border, Canvas.GetZIndex(inkPresenter) + 1);

                inkPresenter.Margin = new Thickness(0);
                inkPresenter.Width = 0;
                inkPresenter.Height = 0;
                Canvas.SetLeft(inkPresenter, 0);
                Canvas.SetTop(inkPresenter, 0);
                parent.Children.Add(border);
            }

            var borderInstance = GetBorderInstance(inkPresenter);
            if (borderInstance != null)
            {
                borderInstance.BorderBrush = GetBorderBrush(inkPresenter);
                borderInstance.BorderThickness = GetBorderThickness(inkPresenter);
            }
        }
    }
}
