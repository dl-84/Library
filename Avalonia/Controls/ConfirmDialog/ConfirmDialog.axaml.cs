using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Controls.ConfirmDialog;

/// <summary>
/// A modal confirmation dialog with configurable title, message, buttons, and colors.
/// Returns <c>true</c> when the accept button is clicked, <c>false</c> when cancelled.
/// </summary>
public partial class ConfirmDialog : Window
{
    /// <summary>
    /// Defines the <see cref="AcceptText"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> AcceptTextProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        string?
    >(nameof(AcceptText));

    /// <summary>
    /// Defines the <see cref="CancelText"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> CancelTextProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        string?
    >(nameof(CancelText));

    /// <summary>
    /// Defines the <see cref="DialogBackground"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> DialogBackgroundProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        IBrush?
    >(nameof(DialogBackground));

    /// <summary>
    /// Defines the <see cref="DialogTitle"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        string?
    >(nameof(DialogTitle));

    /// <summary>
    /// Defines the <see cref="ErrorBrush"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> ErrorBrushProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        IBrush?
    >(nameof(ErrorBrush));

    /// <summary>
    /// Defines the <see cref="Message"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> MessageProperty = AvaloniaProperty.Register<ConfirmDialog, string?>(
        nameof(Message)
    );

    /// <summary>
    /// Defines the <see cref="PrimaryBrush"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> PrimaryBrushProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        IBrush?
    >(nameof(PrimaryBrush));

    /// <summary>
    /// Defines the <see cref="SecondaryBrush"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> SecondaryBrushProperty = AvaloniaProperty.Register<
        ConfirmDialog,
        IBrush?
    >(nameof(SecondaryBrush));

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfirmDialog"/> class.
    /// </summary>
    public ConfirmDialog()
    {
        InitializeComponent();
        DataContext = this;
    }

    /// <summary>
    /// Gets or sets the label of the accept button.
    /// </summary>
    public string? AcceptText
    {
        get => GetValue(AcceptTextProperty);
        set => SetValue(AcceptTextProperty, value);
    }

    /// <summary>
    /// Gets or sets the label of the cancel button.
    /// </summary>
    public string? CancelText
    {
        get => GetValue(CancelTextProperty);
        set => SetValue(CancelTextProperty, value);
    }

    /// <summary>
    /// Gets or sets the background brush of the dialog content area.
    /// </summary>
    public IBrush? DialogBackground
    {
        get => GetValue(DialogBackgroundProperty);
        set => SetValue(DialogBackgroundProperty, value);
    }

    /// <summary>
    /// Gets or sets the title text shown in the dialog header.
    /// </summary>
    public string? DialogTitle
    {
        get => GetValue(DialogTitleProperty);
        set => SetValue(DialogTitleProperty, value);
    }

    /// <summary>
    /// Gets or sets the brush used for the accept button background.
    /// </summary>
    public IBrush? ErrorBrush
    {
        get => GetValue(ErrorBrushProperty);
        set => SetValue(ErrorBrushProperty, value);
    }

    /// <summary>
    /// Gets or sets the message body text.
    /// </summary>
    public string? Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    /// <summary>
    /// Gets or sets the brush used for the header background and cancel button border.
    /// </summary>
    public IBrush? PrimaryBrush
    {
        get => GetValue(PrimaryBrushProperty);
        set => SetValue(PrimaryBrushProperty, value);
    }

    /// <summary>
    /// Gets or sets the foreground brush used on primary and error colored backgrounds.
    /// </summary>
    public IBrush? SecondaryBrush
    {
        get => GetValue(SecondaryBrushProperty);
        set => SetValue(SecondaryBrushProperty, value);
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
