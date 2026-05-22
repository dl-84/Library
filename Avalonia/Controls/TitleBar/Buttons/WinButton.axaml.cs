using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Svg.Skia;

namespace Controls.TitleBar.Buttons;

internal partial class WinButton : UserControl
{
    public static readonly StyledProperty<IBrush?> BackgroundColorProperty = AvaloniaProperty.Register<
        WinButton,
        IBrush?
    >(nameof(BackgroundColor));

    public static readonly StyledProperty<IBrush?> PrimaryColorProperty = AvaloniaProperty.Register<WinButton, IBrush?>(
        nameof(PrimaryColor)
    );

    public static readonly StyledProperty<ButtonType> TypeProperty = AvaloniaProperty.Register<WinButton, ButtonType>(
        nameof(Type)
    );

    public WinButton()
    {
        InitializeComponent();
    }

    public IBrush? BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    public IBrush? PrimaryColor
    {
        get => GetValue(PrimaryColorProperty);
        set => SetValue(PrimaryColorProperty, value);
    }

    public ButtonType Type
    {
        get => GetValue(TypeProperty);
        set => SetValue(TypeProperty, value);
    }

    protected override void OnPointerEntered(PointerEventArgs e)
    {
        base.OnPointerEntered(e);
        Background = Type == ButtonType.WinClose ? new SolidColorBrush(Color.FromRgb(0xC4, 0x2B, 0x1C)) : PrimaryColor;
        UpdateImage(BackgroundColor);
    }

    protected override void OnPointerExited(PointerEventArgs e)
    {
        base.OnPointerExited(e);
        Background = BackgroundColor;
        UpdateImage(PrimaryColor);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (
            change.Property == TypeProperty
            || change.Property == PrimaryColorProperty
            || change.Property == BackgroundColorProperty
        )
        {
            Background = BackgroundColor;
            UpdateImage(PrimaryColor);
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
