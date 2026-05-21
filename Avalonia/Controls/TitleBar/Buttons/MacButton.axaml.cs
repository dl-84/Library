using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Svg.Skia;

namespace Controls.TitleBar.Buttons;

internal partial class MacButton : UserControl
{
    public static readonly StyledProperty<ButtonType> TypeProperty = AvaloniaProperty.Register<MacButton, ButtonType>(
        nameof(Type)
    );

    public static readonly StyledProperty<bool> IsHoveredProperty = AvaloniaProperty.Register<MacButton, bool>(
        nameof(IsHovered)
    );

    public MacButton()
    {
        InitializeComponent();
    }

    public ButtonType Type
    {
        get => GetValue(TypeProperty);
        set => SetValue(TypeProperty, value);
    }

    public bool IsHovered
    {
        get => GetValue(IsHoveredProperty);
        set => SetValue(IsHoveredProperty, value);
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        LoadSources(Type);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == TypeProperty)
        {
            LoadSources((ButtonType)change.NewValue!);
        }
        else if (change.Property == IsHoveredProperty)
        {
            bool hovered = (bool)change.NewValue!;
            NormalState.IsVisible = !hovered;
            HoverState.IsVisible = hovered;
            PressState.IsVisible = false;
        }
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        NormalState.IsVisible = false;
        HoverState.IsVisible = false;
        PressState.IsVisible = true;
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        NormalState.IsVisible = false;
        HoverState.IsVisible = true;
        PressState.IsVisible = false;
    }

    private static SvgImage Load(string path)
    {
        return new SvgImage { Source = SvgSource.Load(path) };
    }

    private void LoadSources(ButtonType type)
    {
        string name = type.ToString();
        NormalState.Source = Load($"avares://TitleBar/Icons/{name}Normal.svg");
        HoverState.Source = Load($"avares://TitleBar/Icons/{name}Hover.svg");
        PressState.Source = Load($"avares://TitleBar/Icons/{name}Press.svg");
    }
}
