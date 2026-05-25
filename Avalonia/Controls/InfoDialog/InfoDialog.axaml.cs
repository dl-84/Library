using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Controls.InfoDialog;

/// <summary>
/// A modal dialog for displaying Error, Warning, or Info messages with an icon.
/// </summary>
public partial class InfoDialog : Window
{
    /// <summary>Defines the <see cref="BackgroundColor"/> property.</summary>
    public static readonly StyledProperty<IBrush?> BackgroundColorProperty = AvaloniaProperty.Register<
        InfoDialog,
        IBrush?
    >(nameof(BackgroundColor));

    /// <summary>Defines the <see cref="CloseButtonColor"/> property.</summary>
    public static readonly StyledProperty<IBrush?> CloseButtonColorProperty = AvaloniaProperty.Register<
        InfoDialog,
        IBrush?
    >(nameof(CloseButtonColor));

    /// <summary>Defines the <see cref="CloseText"/> property.</summary>
    public static readonly StyledProperty<string?> CloseTextProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(CloseText)
    );

    /// <summary>Defines the <see cref="DialogTitle"/> property.</summary>
    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(DialogTitle)
    );

    /// <summary>Defines the <see cref="IconBrush"/> property.</summary>
    public static readonly StyledProperty<IBrush?> IconBrushProperty = AvaloniaProperty.Register<InfoDialog, IBrush?>(
        nameof(IconBrush)
    );

    /// <summary>Defines the <see cref="IconData"/> property.</summary>
    public static readonly StyledProperty<Geometry?> IconDataProperty = AvaloniaProperty.Register<
        InfoDialog,
        Geometry?
    >(nameof(IconData));

    /// <summary>Defines the <see cref="Message"/> property.</summary>
    public static readonly StyledProperty<string?> MessageProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(Message)
    );

    /// <summary>Defines the <see cref="PrimaryColor"/> property.</summary>
    public static readonly StyledProperty<IBrush?> PrimaryColorProperty = AvaloniaProperty.Register<
        InfoDialog,
        IBrush?
    >(nameof(PrimaryColor));

    /// <summary>Defines the <see cref="TextColor"/> property.</summary>
    public static readonly StyledProperty<IBrush?> TextColorProperty = AvaloniaProperty.Register<InfoDialog, IBrush?>(
        nameof(TextColor)
    );

    /// <summary>
    /// Initializes a new instance of the <see cref="InfoDialog"/> class.
    /// </summary>
    public InfoDialog()
    {
        InitializeComponent();
        DataContext = this;
    }

    /// <summary>Gets or sets the background brush of the content area.</summary>
    public IBrush? BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    /// <summary>Gets or sets the background brush of the close button.</summary>
    public IBrush? CloseButtonColor
    {
        get => GetValue(CloseButtonColorProperty);
        set => SetValue(CloseButtonColorProperty, value);
    }

    /// <summary>Gets or sets the label of the close button.</summary>
    public string? CloseText
    {
        get => GetValue(CloseTextProperty);
        set => SetValue(CloseTextProperty, value);
    }

    /// <summary>Gets or sets the title shown in the header.</summary>
    public string? DialogTitle
    {
        get => GetValue(DialogTitleProperty);
        set => SetValue(DialogTitleProperty, value);
    }

    /// <summary>Gets or sets the brush used to fill the icon.</summary>
    public IBrush? IconBrush
    {
        get => GetValue(IconBrushProperty);
        set => SetValue(IconBrushProperty, value);
    }

    /// <summary>Gets or sets the SVG path geometry for the icon.</summary>
    public Geometry? IconData
    {
        get => GetValue(IconDataProperty);
        set => SetValue(IconDataProperty, value);
    }

    /// <summary>Gets or sets the message text.</summary>
    public string? Message
    {
        get => GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    /// <summary>Gets or sets the brush used for the header background.</summary>
    public IBrush? PrimaryColor
    {
        get => GetValue(PrimaryColorProperty);
        set => SetValue(PrimaryColorProperty, value);
    }

    /// <summary>Gets or sets the foreground brush used on primary colored areas.</summary>
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
