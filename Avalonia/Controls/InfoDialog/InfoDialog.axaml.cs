using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Controls.InfoDialog.Enum;

namespace Controls.InfoDialog;

public partial class InfoDialog : Window
{
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

    private static IBrush? GetThemeBrush(string key)
    {
        if (Application.Current is null)
        {
            return null;
        }

        Application.Current.TryGetResource(key, Application.Current.ActualThemeVariant, out object? resource);
        return resource as IBrush;
    }

    private void OnCloseClicked(object? sender, PointerPressedEventArgs e)
    {
        Close();
    }

    private void UpdateIcon()
    {
        string iconKey = IconType == IconType.Info ? "InfoIcon" : "WarningIcon";
        string brushKey = IconType switch
        {
            IconType.Warning => "WarningBrush",
            IconType.Error => "ErrorBrush",
            _ => "TertiaryBrush",
        };

        IconImage.Data = this.TryFindResource(iconKey, out object? resource) ? resource as Geometry : null;
        IconImage.Foreground = GetThemeBrush(brushKey);
    }
}
