using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Controls.InfoDialog;

/// <summary>
/// A modal dialog for displaying Info or Warning messages with an icon.
/// </summary>
public partial class InfoDialog : Window
{
    /// <summary>Defines the <see cref="CloseButtonBackground"/> property.</summary>
    public static readonly StyledProperty<IBrush?> CloseButtonBackgroundProperty = AvaloniaProperty.Register<
        InfoDialog,
        IBrush?
    >(nameof(CloseButtonBackground));

    /// <summary>Defines the <see cref="CloseButtonForeground"/> property.</summary>
    public static readonly StyledProperty<IBrush?> CloseButtonForegroundProperty = AvaloniaProperty.Register<
        InfoDialog,
        IBrush?
    >(nameof(CloseButtonForeground));

    /// <summary>Defines the <see cref="CloseText"/> property.</summary>
    public static readonly StyledProperty<string?> CloseTextProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(CloseText)
    );

    /// <summary>Defines the <see cref="DialogBackground"/> property.</summary>
    public static readonly StyledProperty<IBrush?> DialogBackgroundProperty = AvaloniaProperty.Register<
        InfoDialog,
        IBrush?
    >(nameof(DialogBackground));

    /// <summary>Defines the <see cref="DialogForeground"/> property.</summary>
    public static readonly StyledProperty<IBrush?> DialogForegroundProperty = AvaloniaProperty.Register<
        InfoDialog,
        IBrush?
    >(nameof(DialogForeground));

    /// <summary>Defines the <see cref="DialogTitle"/> property.</summary>
    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(DialogTitle)
    );

    /// <summary>Defines the <see cref="HeaderBackground"/> property.</summary>
    public static readonly StyledProperty<IBrush?> HeaderBackgroundProperty = AvaloniaProperty.Register<
        InfoDialog,
        IBrush?
    >(nameof(HeaderBackground));

    /// <summary>Defines the <see cref="HeaderForeground"/> property.</summary>
    public static readonly StyledProperty<IBrush?> HeaderForegroundProperty = AvaloniaProperty.Register<
        InfoDialog,
        IBrush?
    >(nameof(HeaderForeground));

    /// <summary>Defines the <see cref="IconBrush"/> property.</summary>
    public static readonly StyledProperty<IBrush?> IconBrushProperty = AvaloniaProperty.Register<InfoDialog, IBrush?>(
        nameof(IconBrush)
    );

    /// <summary>Defines the <see cref="IconType"/> property.</summary>
    public static readonly StyledProperty<IconType> IconTypeProperty = AvaloniaProperty.Register<InfoDialog, IconType>(
        nameof(IconType)
    );

    /// <summary>Defines the <see cref="Message"/> property.</summary>
    public static readonly StyledProperty<string?> MessageProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(Message)
    );

    /// <summary>
    /// Initializes a new instance of the <see cref="InfoDialog"/> class.
    /// </summary>
    public InfoDialog()
    {
        InitializeComponent();
        DataContext = this;
    }

    /// <summary>Gets or sets the background brush of the close button.</summary>
    public IBrush? CloseButtonBackground
    {
        get => GetValue(CloseButtonBackgroundProperty);
        set => SetValue(CloseButtonBackgroundProperty, value);
    }

    /// <summary>Gets or sets the foreground brush of the close button.</summary>
    public IBrush? CloseButtonForeground
    {
        get => GetValue(CloseButtonForegroundProperty);
        set => SetValue(CloseButtonForegroundProperty, value);
    }

    /// <summary>Gets or sets the label of the close button.</summary>
    public string? CloseText
    {
        get => GetValue(CloseTextProperty);
        set => SetValue(CloseTextProperty, value);
    }

    /// <summary>Gets or sets the background brush of the content area.</summary>
    public IBrush? DialogBackground
    {
        get => GetValue(DialogBackgroundProperty);
        set => SetValue(DialogBackgroundProperty, value);
    }

    /// <summary>Gets or sets the foreground brush of the content area.</summary>
    public IBrush? DialogForeground
    {
        get => GetValue(DialogForegroundProperty);
        set => SetValue(DialogForegroundProperty, value);
    }

    /// <summary>Gets or sets the title shown in the header.</summary>
    public string? DialogTitle
    {
        get => GetValue(DialogTitleProperty);
        set => SetValue(DialogTitleProperty, value);
    }

    /// <summary>Gets or sets the background brush of the header.</summary>
    public IBrush? HeaderBackground
    {
        get => GetValue(HeaderBackgroundProperty);
        set => SetValue(HeaderBackgroundProperty, value);
    }

    /// <summary>Gets or sets the foreground brush of the header.</summary>
    public IBrush? HeaderForeground
    {
        get => GetValue(HeaderForegroundProperty);
        set => SetValue(HeaderForegroundProperty, value);
    }

    /// <summary>Gets or sets the brush used to fill the icon.</summary>
    public IBrush? IconBrush
    {
        get => GetValue(IconBrushProperty);
        set => SetValue(IconBrushProperty, value);
    }

    /// <summary>Gets or sets the icon variant to display.</summary>
    public IconType IconType
    {
        get => GetValue(IconTypeProperty);
        set => SetValue(IconTypeProperty, value);
    }

    /// <summary>Gets or sets the message text.</summary>
    public string? Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    private void OnCloseClicked(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
