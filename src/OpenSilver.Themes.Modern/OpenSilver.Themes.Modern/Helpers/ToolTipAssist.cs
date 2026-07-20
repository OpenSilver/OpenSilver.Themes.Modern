using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace OpenSilver.Themes.Modern;

/// <summary>
/// Shows tooltips immediately on hover and toggles them on click (for touch).
/// </summary>
public static class ToolTipAssist
{
    private static readonly DependencyProperty OpenedByClickProperty =
        DependencyProperty.RegisterAttached(
            "OpenedByClick",
            typeof(bool),
            typeof(ToolTipAssist),
            new PropertyMetadata(false));

    private static readonly DependencyProperty OwnerProperty =
        DependencyProperty.RegisterAttached(
            "Owner",
            typeof(UIElement),
            typeof(ToolTipAssist),
            null);

    public static readonly DependencyProperty EnableProperty =
        DependencyProperty.RegisterAttached(
            "Enable",
            typeof(bool),
            typeof(ToolTipAssist),
            new PropertyMetadata(false, OnEnableChanged));

    public static bool GetEnable(DependencyObject obj)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        return (bool)obj.GetValue(EnableProperty);
    }

    public static void SetEnable(DependencyObject obj, bool value)
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        obj.SetValue(EnableProperty, value);
    }

    private static void OnEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not ButtonBase button)
        {
            return;
        }

        if ((bool)e.NewValue)
        {
            button.MouseEnter += OnMouseEnter;
            button.MouseLeave += OnMouseLeave;
            button.Click += OnClick;
            AttachToolTip(button);
        }
        else
        {
            button.MouseEnter -= OnMouseEnter;
            button.MouseLeave -= OnMouseLeave;
            button.Click -= OnClick;
            DetachToolTip(button);
            button.ClearValue(OpenedByClickProperty);
        }
    }

    private static void AttachToolTip(ButtonBase button)
    {
        if (ToolTipService.GetToolTip(button) is not ToolTip toolTip)
        {
            return;
        }

        toolTip.SetValue(OwnerProperty, button);
        toolTip.Opened -= OnToolTipOpened;
        toolTip.Opened += OnToolTipOpened;
    }

    private static void DetachToolTip(ButtonBase button)
    {
        if (ToolTipService.GetToolTip(button) is not ToolTip toolTip)
        {
            return;
        }

        toolTip.Opened -= OnToolTipOpened;
        toolTip.ClearValue(OwnerProperty);
    }

    private static void OnMouseEnter(object sender, MouseEventArgs e)
    {
        if (sender is ButtonBase button && ToolTipService.GetToolTip(button) is ToolTip toolTip)
        {
            Open(button, toolTip);
        }
    }

    private static void OnMouseLeave(object sender, MouseEventArgs e)
    {
        if (sender is ButtonBase button && ToolTipService.GetToolTip(button) is ToolTip toolTip)
        {
            toolTip.IsOpen = false;
            button.ClearValue(OpenedByClickProperty);
        }
    }

    private static void OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is not ButtonBase button || ToolTipService.GetToolTip(button) is not ToolTip toolTip)
        {
            return;
        }

        // After ToolTipService.OnMouseButtonDown, which cancels pending hover opens.
        button.Dispatcher.BeginInvoke(new Action(() =>
        {
            if ((bool)button.GetValue(OpenedByClickProperty) && toolTip.IsOpen)
            {
                toolTip.IsOpen = false;
                button.ClearValue(OpenedByClickProperty);
            }
            else
            {
                Open(button, toolTip);
                button.SetValue(OpenedByClickProperty, true);
            }
        }));
    }

    private static void Open(ButtonBase owner, ToolTip toolTip)
    {
        toolTip.SetValue(OwnerProperty, owner);
        toolTip.IsOpen = true;
        ConfigurePopup(toolTip);
    }

    private static void OnToolTipOpened(object sender, RoutedEventArgs e)
    {
        if (sender is ToolTip toolTip)
        {
            ConfigurePopup(toolTip);
        }
    }

    private static void ConfigurePopup(ToolTip toolTip)
    {
        // ToolTip is the Popup's logical child; its visual parent is PopupRoot.
        if (toolTip.Parent is not Popup popup)
        {
            return;
        }

        popup.StayOpen = false;
        popup.ClosedDueToOutsideClick -= OnOutsideClick;
        popup.ClosedDueToOutsideClick += OnOutsideClick;
    }

    private static void OnOutsideClick(object sender, EventArgs e)
    {
        if (sender is not Popup { Child: ToolTip toolTip })
        {
            return;
        }

        toolTip.IsOpen = false;

        if (toolTip.GetValue(OwnerProperty) is DependencyObject owner)
        {
            owner.ClearValue(OpenedByClickProperty);
        }
    }
}
