using Avalonia;
using Avalonia.Controls;

namespace Controls.CounterCard;

/// <inheritdoc/>
public partial class CounterCardControl : UserControl
{
    public static readonly StyledProperty<string?> InfoTextProperty = AvaloniaProperty.Register<
        CounterCardControl,
        string?
    >(nameof(InfoText));

    public static readonly StyledProperty<bool> IsDangerProperty = AvaloniaProperty.Register<CounterCardControl, bool>(
        nameof(IsDanger)
    );

    public static readonly StyledProperty<string?> LabelProperty = AvaloniaProperty.Register<
        CounterCardControl,
        string?
    >(nameof(Label));

    public static readonly StyledProperty<int> ValueProperty = AvaloniaProperty.Register<CounterCardControl, int>(
        nameof(Value)
    );

    public CounterCardControl()
    {
        InitializeComponent();
    }

    public string? InfoText
    {
        get => GetValue(InfoTextProperty);
        set => SetValue(InfoTextProperty, value);
    }

    public bool IsDanger
    {
        get => GetValue(IsDangerProperty);
        set => SetValue(IsDangerProperty, value);
    }

    public string? Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public int Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
}
