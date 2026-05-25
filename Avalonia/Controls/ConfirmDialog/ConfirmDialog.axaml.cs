using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Controls.ConfirmDialog;

/// <summary>
/// A modal confirmation dialog with configurable title, message, and button labels.
/// Returns <c>true</c> when the accept button is clicked, <c>false</c> when cancelled.
/// Colors are provided via DynamicResource from the application theme.
/// </summary>
public partial class ConfirmDialog : Window
{
    /// <summary>Defines the <see cref="AcceptText"/> property.</summary>
    public static readonly StyledProperty<string?> AcceptTextProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        string?
    >(nameof(AcceptText));

    /// <summary>Defines the <see cref="CancelText"/> property.</summary>
    public static readonly StyledProperty<string?> CancelTextProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        string?
    >(nameof(CancelText));

    /// <summary>Defines the <see cref="DialogTitle"/> property.</summary>
    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        string?
    >(nameof(DialogTitle));

    /// <summary>Defines the <see cref="Message"/> property.</summary>
    public static readonly StyledProperty<string?> MessageProperty = AvaloniaProperty.Register<ConfirmDialog, string?>(
        nameof(Message)
    );

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfirmDialog"/> class.
    /// </summary>
    public ConfirmDialog()
    {
        InitializeComponent();
        DataContext = this;
    }

    /// <summary>Gets or sets the label of the accept button.</summary>
    public string? AcceptText
    {
        get => GetValue(AcceptTextProperty);
        set => SetValue(AcceptTextProperty, value);
    }

    /// <summary>Gets or sets the label of the cancel button.</summary>
    public string? CancelText
    {
        get => GetValue(CancelTextProperty);
        set => SetValue(CancelTextProperty, value);
    }

    /// <summary>Gets or sets the title text shown in the dialog header.</summary>
    public string? DialogTitle
    {
        get => GetValue(DialogTitleProperty);
        set => SetValue(DialogTitleProperty, value);
    }

    /// <summary>Gets or sets the message body text.</summary>
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
