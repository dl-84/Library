using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Controls.FormField;

/// <inheritdoc/>
public partial class FormFieldControl : UserControl
{
    public static readonly StyledProperty<string?> AllowedPatternProperty = AvaloniaProperty.Register<
        FormFieldControl,
        string?
    >(nameof(AllowedPattern));

    public static readonly StyledProperty<string?> ErrorMessageProperty = AvaloniaProperty.Register<
        FormFieldControl,
        string?
    >(nameof(ErrorMessage));

    public static readonly StyledProperty<bool> IsErrorProperty = AvaloniaProperty.Register<FormFieldControl, bool>(
        nameof(IsError)
    );

    public static readonly StyledProperty<bool> IsInputEnabledProperty = AvaloniaProperty.Register<
        FormFieldControl,
        bool
    >(nameof(IsInputEnabled), true);

    public static readonly StyledProperty<string?> LabelProperty = AvaloniaProperty.Register<FormFieldControl, string?>(
        nameof(Label)
    );

    public static readonly StyledProperty<int> MaxLengthProperty = AvaloniaProperty.Register<FormFieldControl, int>(
        nameof(MaxLength)
    );

    public static readonly StyledProperty<string?> TextProperty = AvaloniaProperty.Register<FormFieldControl, string?>(
        nameof(Text)
    );

    public FormFieldControl()
    {
        InitializeComponent();
        InputTextBox.AddHandler(InputElement.TextInputEvent, OnTextInput, RoutingStrategies.Tunnel);
    }

    public string? AllowedPattern
    {
        get => GetValue(AllowedPatternProperty);
        set => SetValue(AllowedPatternProperty, value);
    }

    public string? ErrorMessage
    {
        get => GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    public bool IsError
    {
        get => GetValue(IsErrorProperty);
        set => SetValue(IsErrorProperty, value);
    }

    public bool IsInputEnabled
    {
        get => GetValue(IsInputEnabledProperty);
        set => SetValue(IsInputEnabledProperty, value);
    }

    public string? Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public int MaxLength
    {
        get => GetValue(MaxLengthProperty);
        set => SetValue(MaxLengthProperty, value);
    }

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    private void OnTextInput(object? sender, TextInputEventArgs e)
    {
        if (AllowedPattern is not null && e.Text is not null && !Regex.IsMatch(e.Text, AllowedPattern))
        {
            e.Handled = true;
        }
    }
}
