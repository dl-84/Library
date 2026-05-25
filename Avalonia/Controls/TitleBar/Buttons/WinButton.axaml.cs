using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Svg.Skia;

namespace Controls.TitleBar.Buttons;

internal partial class WinButton : UserControl
{
    public static readonly StyledProperty<ButtonType> TypeProperty = AvaloniaProperty.Register<WinButton, ButtonType>(
        nameof(Type)
    );

    public WinButton()
    {
        InitializeComponent();
    }

    public ButtonType Type
    {
        get => GetValue(TypeProperty);
        set => SetValue(TypeProperty, value);
    }

    protected override void OnPointerEntered(PointerEventArgs e)
    {
        base.OnPointerEntered(e);
        Background =
            Type == ButtonType.WinClose
                ? new SolidColorBrush(Color.FromRgb(0xC4, 0x2B, 0x1C))
                : GetThemeBrush("PrimaryBrush");
        UpdateImage(GetThemeBrush("AppBackgroundAltBrush"));
    }

    protected override void OnPointerExited(PointerEventArgs e)
    {
        base.OnPointerExited(e);
        Background = GetThemeBrush("AppBackgroundAltBrush");
        UpdateImage(GetThemeBrush("PrimaryBrush"));
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == TypeProperty)
        {
            Background = GetThemeBrush("AppBackgroundAltBrush");
            UpdateImage(GetThemeBrush("PrimaryBrush"));
        }
    }

    private static string BuildCss(IBrush? brush)
    {
        if (brush is SolidColorBrush solid)
        {
            Color color = solid.Color;
            return $"* {{ stroke: #{color.R:X2}{color.G:X2}{color.B:X2}; }}";
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

    private void UpdateImage(IBrush? iconBrush)
    {
        string name = Type.ToString();
        ButtonImage.Source = new SvgImage
        {
            Source = SvgSource.Load($"avares://TitleBar/Icons/{name}Normal.svg", null),
            Css = BuildCss(iconBrush),
        };
    }
}
