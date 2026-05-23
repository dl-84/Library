using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Controls.ContentDialog;

/// <summary>
/// A modal dialog with a configurable header, content area, and close button.
/// </summary>
public partial class ContentDialog : Window
{
    /// <summary>
    /// Defines the <see cref="BackgroundColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> BackgroundColorProperty = AvaloniaProperty.Register<
        ContentDialog,
        IBrush?
    >(nameof(BackgroundColor));

    /// <summary>
    /// Defines the <see cref="CloseText"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> CloseTextProperty = AvaloniaProperty.Register<
        ContentDialog,
        string?
    >(nameof(CloseText));

    /// <summary>
    /// Defines the <see cref="DialogContent"/> property.
    /// </summary>
    public static readonly StyledProperty<object?> DialogContentProperty = AvaloniaProperty.Register<
        ContentDialog,
        object?
    >(nameof(DialogContent));

    /// <summary>
    /// Defines the <see cref="DialogTitle"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<
        ContentDialog,
        string?
    >(nameof(DialogTitle));

    /// <summary>
    /// Defines the <see cref="PrimaryColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> PrimaryColorProperty = AvaloniaProperty.Register<
        ContentDialog,
        IBrush?
    >(nameof(PrimaryColor));

    /// <summary>
    /// Defines the <see cref="TextColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> TextColorProperty = AvaloniaProperty.Register<
        ContentDialog,
        IBrush?
    >(nameof(TextColor));

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentDialog"/> class.
    /// </summary>
    public ContentDialog()
    {
        InitializeComponent();
        DataContext = this;
    }

    /// <summary>
    /// Gets or sets the background brush of the content area.
    /// </summary>
    public IBrush? BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    /// <summary>
    /// Gets or sets the label of the close button.
    /// </summary>
    public string? CloseText
    {
        get => GetValue(CloseTextProperty);
        set => SetValue(CloseTextProperty, value);
    }

    /// <summary>
    /// Gets or sets the control displayed in the content area.
    /// </summary>
    public object? DialogContent
    {
        get => GetValue(DialogContentProperty);
        set => SetValue(DialogContentProperty, value);
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
    /// Gets or sets the brush used for the header and close button background.
    /// </summary>
    public IBrush? PrimaryColor
    {
        get => GetValue(PrimaryColorProperty);
        set => SetValue(PrimaryColorProperty, value);
    }

    /// <summary>
    /// Gets or sets the foreground brush used on primary colored areas.
    /// </summary>
    public IBrush? TextColor
    {
        get => GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    private void OnCloseClicked(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
