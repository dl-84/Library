using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Controls.TitleBar.Buttons;
using Controls.TitleBar.Services;

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
        WindowControlButtons.IsVisible = !PlatformInfoService.IsMac;

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
