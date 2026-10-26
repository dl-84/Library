using System;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Controls.TitleBar.Buttons;

namespace Controls.TitleBar;

/// <inheritdoc/>
public partial class TitleBarControl : UserControl
{
    public static readonly StyledProperty<IBrush?> ContentBackgroundProperty = AvaloniaProperty.Register<
        TitleBarControl,
        IBrush?
    >(nameof(ContentBackground));

    private Window? _parentWindow;

    public TitleBarControl()
    {
        InitializeComponent();
        DockPanel.SetDock(this, Dock.Top);
    }

    /// <summary>
    /// Gets or sets the content background.
    /// </summary>
    public IBrush? ContentBackground
    {
        get => GetValue(ContentBackgroundProperty);
        set => SetValue(ContentBackgroundProperty, value);
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        _parentWindow = TopLevel.GetTopLevel(this) as Window;

        bool isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        MacTrafficLights.IsVisible = isMac;
        WindowControlButtons.IsVisible = !isMac;

        if (ContentBackground is not null)
        {
            ContentBorder.Background = ContentBackground;
        }
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);
        _parentWindow = null;
    }

    private void OnMacButtonPressed(object? sender, PointerPressedEventArgs e)
    {
        if (_parentWindow is null || sender is not MacButton button)
        {
            return;
        }

        switch (button.Type)
        {
            case ButtonType.MacClose:
                _parentWindow.Close();
                break;
            case ButtonType.MacMinimize:
                _parentWindow.WindowState = WindowState.Minimized;
                break;
            case ButtonType.MacMaximize:
                _parentWindow.WindowState = _parentWindow.WindowState is WindowState.Maximized or WindowState.FullScreen
                    ? WindowState.Normal
                    : WindowState.Maximized;
                break;
            case ButtonType.WinClose:
            case ButtonType.WinMinimize:
            case ButtonType.WinMaximize:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnMacButtonsPointerEntered(object? sender, PointerEventArgs e)
    {
        MacCloseIcon.IsHovered = true;
        MacMinimizeIcon.IsHovered = true;
        MacMaximizeIcon.IsHovered = true;
    }

    private void OnMacButtonsPointerExited(object? sender, PointerEventArgs e)
    {
        MacCloseIcon.IsHovered = false;
        MacMinimizeIcon.IsHovered = false;
        MacMaximizeIcon.IsHovered = false;
    }

    private void OnTitleBarDrag(object? sender, PointerPressedEventArgs e)
    {
        _parentWindow?.BeginMoveDrag(e);
    }

    private void OnWinButtonPressed(object? sender, PointerPressedEventArgs e)
    {
        if (_parentWindow is null || sender is not WinButton button)
        {
            return;
        }

        switch (button.Type)
        {
            case ButtonType.WinClose:
                _parentWindow.Close();
                break;
            case ButtonType.WinMinimize:
                _parentWindow.WindowState = WindowState.Minimized;
                break;
            case ButtonType.WinMaximize:
                _parentWindow.WindowState =
                    _parentWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                break;
        }
    }
}
