using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Controls.TitleBar.Buttons;
using Controls.TitleBar.Services;

namespace Controls.TitleBar.Controls;

/// <inheritdoc/>
public partial class MacTrafficLightsControl : UserControl
{
    private Window? _parentWindow;

    public MacTrafficLightsControl()
    {
        InitializeComponent();
        IsVisible = PlatformInfoService.IsMac;
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        _parentWindow = TopLevel.GetTopLevel(this) as Window;
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
}
