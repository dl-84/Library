using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Controls.ContentDialog;

/// <summary>
/// A modal dialog with a configurable header, content area, and close button.
/// Colors are provided via DynamicResource from the application theme.
/// </summary>
public partial class ContentDialog : Window
{
    /// <summary>Defines the <see cref="CloseText"/> property.</summary>
    public static readonly StyledProperty<string?> CloseTextProperty = AvaloniaProperty.Register<
        ContentDialog,
        string?
    >(nameof(CloseText));

    /// <summary>Defines the <see cref="DialogContent"/> property.</summary>
    public static readonly StyledProperty<object?> DialogContentProperty = AvaloniaProperty.Register<
        ContentDialog,
        object?
    >(nameof(DialogContent));

    /// <summary>Defines the <see cref="DialogTitle"/> property.</summary>
    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<
        ContentDialog,
        string?
    >(nameof(DialogTitle));

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentDialog"/> class.
    /// </summary>
    public ContentDialog()
    {
        InitializeComponent();
        DataContext = this;
    }

    /// <summary>Gets or sets the label of the close button.</summary>
    public string? CloseText
    {
        get => GetValue(CloseTextProperty);
        set => SetValue(CloseTextProperty, value);
    }

    /// <summary>Gets or sets the control displayed in the content area.</summary>
    public object? DialogContent
    {
        get => GetValue(DialogContentProperty);
        set => SetValue(DialogContentProperty, value);
    }

    /// <summary>Gets or sets the title shown in the header.</summary>
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
