using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Controls.ContentDialog;

public partial class ContentDialog : Window
{
    public static readonly StyledProperty<string?> CloseTextProperty = AvaloniaProperty.Register<
        ContentDialog,
        string?
    >(nameof(CloseText));

    public static readonly StyledProperty<object?> DialogContentProperty = AvaloniaProperty.Register<
        ContentDialog,
        object?
    >(nameof(DialogContent));

    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<
        ContentDialog,
        string?
    >(nameof(DialogTitle));

    public ContentDialog()
    {
        InitializeComponent();
        DataContext = this;
    }

    public string? CloseText
    {
        get => GetValue(CloseTextProperty);
        set => SetValue(CloseTextProperty, value);
    }

    public object? DialogContent
    {
        get => GetValue(DialogContentProperty);
        set => SetValue(DialogContentProperty, value);
    }

    public string? DialogTitle
    {
        get => GetValue(DialogTitleProperty);
        set => SetValue(DialogTitleProperty, value);
    }

    private void OnCloseClicked(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
