using Avalonia;
using Avalonia.Controls;

namespace Controls.WaitingDialog;

public partial class WaitingDialog : Window
{
    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<
        WaitingDialog,
        string?
    >(nameof(DialogTitle));

    public static readonly StyledProperty<string?> MessageProperty = AvaloniaProperty.Register<WaitingDialog, string?>(
        nameof(Message)
    );

    public WaitingDialog()
    {
        InitializeComponent();
        DataContext = this;
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
}
