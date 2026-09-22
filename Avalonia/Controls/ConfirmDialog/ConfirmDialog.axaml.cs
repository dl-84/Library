using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Controls.ConfirmDialog;

public partial class ConfirmDialog : Window
{
    public static readonly StyledProperty<string?> AcceptTextProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        string?
    >(nameof(AcceptText));

    public static readonly StyledProperty<string?> CancelTextProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        string?
    >(nameof(CancelText));

    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        string?
    >(nameof(DialogTitle));

    public static readonly StyledProperty<string?> MessageProperty = AvaloniaProperty.Register<ConfirmDialog, string?>(
        nameof(Message)
    );

    public ConfirmDialog()
    {
        InitializeComponent();
        DataContext = this;
    }

    public string? AcceptText
    {
        get => GetValue(AcceptTextProperty);
        set => SetValue(AcceptTextProperty, value);
    }

    public string? CancelText
    {
        get => GetValue(CancelTextProperty);
        set => SetValue(CancelTextProperty, value);
    }

    public string? DialogTitle
    {
        get => GetValue(DialogTitleProperty);
        set => SetValue(DialogTitleProperty, value);
    }

    public string? Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    private void OnAcceptClicked(object? sender, RoutedEventArgs e)
    {
        Close(true);
    }

    private void OnCancelClicked(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }
}
