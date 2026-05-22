using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Controls.TitleBar.Buttons;

namespace Controls.TitleBar;

/// <inheritdoc />
public partial class TitleBarControl : UserControl
{
    /// <summary>
    /// Defines the <see cref="BackgroundColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> BackgroundColorProperty = AvaloniaProperty.Register<
        TitleBarControl,
        IBrush?
    >(nameof(BackgroundColor));

    /// <summary>
    /// Defines the <see cref="PrimaryColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> PrimaryColorProperty = AvaloniaProperty.Register<
        TitleBarControl,
        IBrush?
    >(nameof(PrimaryColor));

    private Window? _parentWindow;

    /// <summary>
    /// Initializes a new instance of the <see cref="TitleBarControl"/> class.
    /// </summary>
    public TitleBarControl()
    {
        InitializeComponent();
        DockPanel.SetDock(this, Dock.Top);
    }

    /// <summary>
    /// Gets or sets the background color used for the content section and button normal backgrounds.
    /// </summary>
    public IBrush? BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    /// <summary>
    /// Gets or sets the primary color used for the sidebar section and button hover backgrounds.
    /// </summary>
    public IBrush? PrimaryColor
    {
        get => GetValue(PrimaryColorProperty);
        set => SetValue(PrimaryColorProperty, value);
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

    /// <inheritdoc />
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == PrimaryColorProperty)
        {
            SidebarBorder.Background = change.GetNewValue<IBrush?>();
        }
        else if (change.Property == BackgroundColorProperty)
        {
            ContentBorder.Background = change.GetNewValue<IBrush?>();
        }
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
