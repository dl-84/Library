using Avalonia;
using Avalonia.Controls;

namespace Controls.WaitingDialog;

/// <summary>
/// A modal dialog that signals an ongoing operation.
/// Has no close button — close programmatically via <see cref="Window.Close()"/>.
/// </summary>
public partial class WaitingDialog : Window
{
    /// <summary>
    /// Defines the <see cref="DialogTitle"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<
        WaitingDialog,
        string?
    >(nameof(DialogTitle));

    /// <summary>
    /// Defines the <see cref="Message"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> MessageProperty = AvaloniaProperty.Register<WaitingDialog, string?>(
        nameof(Message)
    );

    /// <summary>
    /// Initializes a new instance of the <see cref="WaitingDialog"/> class.
    /// </summary>
    public WaitingDialog()
    {
        InitializeComponent();
        DataContext = this;
    }

    /// <summary>
    /// Gets or sets the title shown in the header.
    /// </summary>
    public string? DialogTitle
    {
        get => GetValue(DialogTitleProperty);
        set => SetValue(DialogTitleProperty, value);
    }

    /// <summary>
    /// Gets or sets the message text shown below the progress bar.
    /// </summary>
    public string? Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }
}
