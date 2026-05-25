using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Controls.TitleBar.Buttons;

namespace Controls.TitleBar;

/// <inheritdoc />
public partial class TitleBarControl : UserControl
{
    private Window? _parentWindow;

    /// <summary>
    /// Initializes a new instance of the <see cref="TitleBarControl"/> class.
    /// </summary>
    public TitleBarControl()
    {
        InitializeComponent();
        DockPanel.SetDock(this, Dock.Top);
    }

    /// <inheritdoc />
    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        _parentWindow = TopLevel.GetTopLevel(this) as Window;

        bool isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        MacTrafficLights.IsVisible = isMac;
        WindowControlButtons.IsVisible = !isMac;
    }

    /// <inheritdoc />
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
