using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Svg.Skia;
using Controls.InfoDialog.Enum;

namespace Controls.InfoDialog;

/// <summary>
/// A modal dialog for displaying Info or Warning messages with an icon.
/// Colors are provided via DynamicResource from the application theme.
/// </summary>
public partial class InfoDialog : Window
{
    /// <summary>Defines the <see cref="CloseText"/> property.</summary>
    public static readonly StyledProperty<string?> CloseTextProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(CloseText)
    );

    /// <summary>Defines the <see cref="DialogTitle"/> property.</summary>
    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(DialogTitle)
    );

    /// <summary>Defines the <see cref="IconType"/> property.</summary>
    public static readonly StyledProperty<IconType> IconTypeProperty = AvaloniaProperty.Register<InfoDialog, IconType>(
        nameof(IconType)
    );

    /// <summary>Defines the <see cref="Message"/> property.</summary>
    public static readonly StyledProperty<string?> MessageProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(Message)
    );

    /// <summary>Initializes a new instance of the <see cref="InfoDialog"/> class.</summary>
    public InfoDialog()
    {
        InitializeComponent();
        DataContext = this;
        UpdateIcon();
    }

    /// <summary>Gets or sets the label of the close button.</summary>
    public string? CloseText
    {
        get => GetValue(CloseTextProperty);
        set => SetValue(CloseTextProperty, value);
    }

    /// <summary>Gets or sets the title shown in the header.</summary>
    public string? DialogTitle
    {
        get => GetValue(DialogTitleProperty);
        set => SetValue(DialogTitleProperty, value);
    }

    /// <summary>Gets or sets the icon variant to display.</summary>
    public IconType IconType
    {
        get => GetValue(IconTypeProperty);
        set => SetValue(IconTypeProperty, value);
    }

    /// <summary>Gets or sets the message text.</summary>
    public string? Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    /// <inheritdoc/>
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IconTypeProperty)
        {
            UpdateIcon();
        }
    }

    private static string BuildCss(IBrush? brush)
    {
        if (brush is SolidColorBrush solid)
        {
            Color color = solid.Color;
            return $"* {{ fill: #{color.R:X2}{color.G:X2}{color.B:X2}; }}";
        }

        return string.Empty;
    }

    private static IBrush? GetThemeBrush(string key)
    {
        if (Application.Current is null)
        {
            return null;
        }

        Application.Current.TryGetResource(key, Application.Current.ActualThemeVariant, out object? resource);
        return resource as IBrush;
    }

    private void OnCloseClicked(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private void UpdateIcon()
    {
        string fileName = IconType == IconType.Info ? "info" : "triangle";
        string brushKey = IconType switch
        {
            IconType.Warning => "WarningBrush",
            IconType.Error => "ErrorBrush",
            _ => "TertiaryBrush",
        };

        IconImage.Source = new SvgImage
        {
            Source = SvgSource.Load($"avares://InfoDialog/Assets/{fileName}.svg", null),
            Css = BuildCss(GetThemeBrush(brushKey)),
        };
    }
}
