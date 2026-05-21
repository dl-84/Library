using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;

namespace Controls.TitleBar;

/// <inheritdoc />
public partial class TitleBarControl : UserControl
{
    /// <summary>
    /// Defines the <see cref="PrimaryColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> PrimaryColorProperty = AvaloniaProperty.Register<
        TitleBarControl,
        IBrush?
    >(nameof(PrimaryColor));

    /// <summary>
    /// Defines the <see cref="BackgroundColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> BackgroundColorProperty =
        AvaloniaProperty.Register<TitleBarControl, IBrush?>(nameof(BackgroundColor));

    private Window? _parentWindow;

    /// <summary>
    /// Initializes a new instance of the <see cref="TitleBarControl"/> class.
    /// </summary>
    public TitleBarControl()
    {
        InitializeComponent();
        DockPanel.SetDock(this, Dock.Top);
    }

    /// <summary>Gets or sets the primary color used for the sidebar section and button hover backgrounds.</summary>
    public IBrush? PrimaryColor
    {
        get => GetValue(PrimaryColorProperty);
        set => SetValue(PrimaryColorProperty, value);
    }

    /// <summary>Gets or sets the background color used for the content section and button normal backgrounds.</summary>
    public IBrush? BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    /// <inheritdoc />
    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        _parentWindow = TopLevel.GetTopLevel(this) as Window;
        if (_parentWindow is not null)
        {
            _parentWindow.PropertyChanged += OnWindowPropertyChanged;
        }

        bool isMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        MacOsButtons.IsVisible = isMac;
        WindowControlButtons.IsVisible = !isMac;
        UpdateMacMaximizeIcon(false);
        ApplyIconColors();
        ApplyButtonBackgrounds();
    }

    /// <inheritdoc />
    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);

        if (_parentWindow is not null)
        {
            _parentWindow.PropertyChanged -= OnWindowPropertyChanged;
            _parentWindow = null;
        }
    }

    /// <inheritdoc />
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == PrimaryColorProperty || change.Property == BackgroundColorProperty)
        {
            ApplyIconColors();
            ApplyButtonBackgrounds();
        }
    }

    private void ApplyIconColors()
    {
        MinimizeIcon.Foreground = PrimaryColor;
        MaximizeIcon.Stroke = PrimaryColor;
        CloseIcon.Foreground = PrimaryColor;
    }

    private void ApplyButtonBackgrounds()
    {
        MinimizeButton.Background = BackgroundColor;
        MaximizeButton.Background = BackgroundColor;
        CloseButton.Background = BackgroundColor;
    }

    private void OnWindowPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property == Window.WindowStateProperty)
        {
            WindowState newState = (WindowState)e.NewValue!;
            bool maximized = newState is WindowState.Maximized or WindowState.FullScreen;
            MaximizeIcon.Data = Geometry.Parse(
                maximized ? "M3,0 H11 V8 M0,3 H8 V11 H0 Z" : "M0,0 H11 V11 H0 Z"
            );
            UpdateMacMaximizeIcon(maximized);
        }
    }

    private void UpdateMacMaximizeIcon(bool maximized)
    {
        SolidColorBrush iconBrush = new(Color.Parse("#0B6B1F"));
        if (maximized)
        {
            MacMaximizeBorder.Background = new SolidColorBrush(Color.Parse("#2EA44B"));
            MacMaximizeIcon.Width = 9;
            MacMaximizeIcon.Height = 9;
            MacMaximizeIcon.Data = Geometry.Parse(
                "M0,4.5 L4.5,0 L4.5,4.5 Z M4.5,9 L9,4.5 L4.5,4.5 Z"
            );
            MacMaximizeIcon.Fill = iconBrush;
            MacMaximizeIcon.Stroke = null;
        }
        else
        {
            MacMaximizeBorder.Background = new SolidColorBrush(Color.Parse("#35C759"));
            MacMaximizeIcon.Width = 7;
            MacMaximizeIcon.Height = 7;
            MacMaximizeIcon.Data = Geometry.Parse(
                "M0.5,0.5 L5.5,0.5 L0.5,5.5 Z M6.5,6.5 L1.5,6.5 L6.5,1.5 Z"
            );
            MacMaximizeIcon.Fill = iconBrush;
            MacMaximizeIcon.Stroke = null;
        }
    }

    private void OnTitleBarDrag(object? sender, PointerPressedEventArgs e)
    {
        _parentWindow?.BeginMoveDrag(e);
    }

    private void OnMinimizeClicked(object? sender, RoutedEventArgs e)
    {
        if (_parentWindow is not null)
        {
            _parentWindow.WindowState = WindowState.Minimized;
        }
    }

    private void OnMaximizeRestoreClicked(object? sender, RoutedEventArgs e)
    {
        if (_parentWindow is not null)
        {
            _parentWindow.WindowState =
                _parentWindow.WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
        }
    }

    private void OnCloseClicked(object? sender, RoutedEventArgs e)
    {
        _parentWindow?.Close();
    }

    private void OnMinimizeButtonPointerEntered(object? sender, PointerEventArgs e)
    {
        MinimizeButton.Background = PrimaryColor;
        MinimizeIcon.Foreground = BackgroundColor;
    }

    private void OnMinimizeButtonPointerExited(object? sender, PointerEventArgs e)
    {
        MinimizeButton.Background = BackgroundColor;
        MinimizeIcon.Foreground = PrimaryColor;
    }

    private void OnMaximizeButtonPointerEntered(object? sender, PointerEventArgs e)
    {
        MaximizeButton.Background = PrimaryColor;
        MaximizeIcon.Stroke = BackgroundColor;
    }

    private void OnMaximizeButtonPointerExited(object? sender, PointerEventArgs e)
    {
        MaximizeButton.Background = BackgroundColor;
        MaximizeIcon.Stroke = PrimaryColor;
    }

    private void OnCloseButtonPointerEntered(object? sender, PointerEventArgs e)
    {
        CloseButton.Background = new SolidColorBrush(Color.Parse("#C42B1C"));
        CloseIcon.Foreground = BackgroundColor;
    }

    private void OnCloseButtonPointerExited(object? sender, PointerEventArgs e)
    {
        CloseButton.Background = BackgroundColor;
        CloseIcon.Foreground = PrimaryColor;
    }

    private void OnMacButtonsPointerEntered(object? sender, PointerEventArgs e)
    {
        MacCloseIcon.Opacity = 1;
        MacMinimizeIcon.Opacity = 1;
        MacMaximizeIcon.Opacity = 1;
    }

    private void OnMacButtonsPointerExited(object? sender, PointerEventArgs e)
    {
        MacCloseIcon.Opacity = 0;
        MacMinimizeIcon.Opacity = 0;
        MacMaximizeIcon.Opacity = 0;
    }

    private void OnMacCloseClicked(object? sender, PointerPressedEventArgs e)
    {
        _parentWindow?.Close();
    }

    private void OnMacMinimizeClicked(object? sender, PointerPressedEventArgs e)
    {
        if (_parentWindow is not null)
        {
            _parentWindow.WindowState = WindowState.Minimized;
        }
    }

    private void OnMacMaximizeClicked(object? sender, PointerPressedEventArgs e)
    {
        if (_parentWindow is not null)
        {
            _parentWindow.WindowState = _parentWindow.WindowState
                is WindowState.Maximized
                    or WindowState.FullScreen
                ? WindowState.Normal
                : WindowState.Maximized;
            UpdateMacMaximizeIcon(
                _parentWindow.WindowState is WindowState.Maximized or WindowState.FullScreen
            );
        }
    }
}
