using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Controls.InfoDialog;

/// <summary>
/// A modal dialog for displaying Info or Warning messages with an icon.
/// Colors are provided via DynamicResource from the application theme.
/// </summary>
public partial class InfoDialog : Window
{
    /// <summary>Defines the <see cref="CloseText"/> property.</summary>
    public static readonly StyledProperty<string?> CloseTextProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(CloseText)
    );

    /// <summary>Defines the <see cref="DialogTitle"/> property.</summary>
    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<InfoDialog, string?>(
        nameof(DialogTitle)
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
