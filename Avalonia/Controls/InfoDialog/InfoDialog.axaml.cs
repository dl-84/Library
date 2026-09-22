using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Svg.Skia;
using Controls.InfoDialog.Enum;

namespace Controls.InfoDialog;

public partial class InfoDialog : Window
{
    public static readonly StyledProperty<string?> CloseTextProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(CloseText)
    );

    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(DialogTitle)
    );

    public static readonly StyledProperty<IconType> IconTypeProperty = AvaloniaProperty.Register<InfoDialog, IconType>(
        nameof(IconType)
    );

    public static readonly StyledProperty<string?> MessageProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(Message)
    );

    public InfoDialog()
    {
        InitializeComponent();
        DataContext = this;
        UpdateIcon();
    }

    public string? CloseText
    {
        get => GetValue(CloseTextProperty);
        set => SetValue(CloseTextProperty, value);
    }

    public string? DialogTitle
    {
        get => GetValue(DialogTitleProperty);
        set => SetValue(DialogTitleProperty, value);
    }

    public IconType IconType
    {
        get => GetValue(IconTypeProperty);
        set => SetValue(IconTypeProperty, value);
    }

    public string? Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

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
