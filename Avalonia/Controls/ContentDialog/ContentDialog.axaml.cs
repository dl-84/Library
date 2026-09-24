using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Input.Platform;
using Avalonia.Interactivity;

namespace Controls.ContentDialog;

/// <inheritdoc/>
public partial class ContentDialog : Window
{
    public static readonly StyledProperty<string?> CopyTextProperty = AvaloniaProperty.Register<ContentDialog, string?>(
        nameof(CopyText)
    );

    public static readonly StyledProperty<object?> DialogContentProperty = AvaloniaProperty.Register<
        ContentDialog,
        object?
    >(nameof(DialogContent));

    public static readonly StyledProperty<string?> DialogTitleProperty = AvaloniaProperty.Register<
        ContentDialog,
        string?
    >(nameof(DialogTitle));

    public static readonly StyledProperty<bool> IsDangerProperty = AvaloniaProperty.Register<ContentDialog, bool>(
        nameof(IsDanger)
    );

    public static readonly StyledProperty<string?> SubmitTextProperty = AvaloniaProperty.Register<
        ContentDialog,
        string?
    >(nameof(SubmitText));

    public ContentDialog()
    {
        InitializeComponent();
        DataContext = this;
    }

    public string? CopyText
    {
        get => GetValue(CopyTextProperty);
        set => SetValue(CopyTextProperty, value);
    }

    public object? DialogContent
    {
        get => GetValue(DialogContentProperty);
        set => SetValue(DialogContentProperty, value);
    }

    public string? DialogTitle
    {
        get => GetValue(DialogTitleProperty);
        set => SetValue(DialogTitleProperty, value);
    }

    public bool IsDanger
    {
        get => GetValue(IsDangerProperty);
        set => SetValue(IsDangerProperty, value);
    }

    public string? SubmitText
    {
        get => GetValue(SubmitTextProperty);
        set => SetValue(SubmitTextProperty, value);
    }

    private void OnCancelClicked(object? sender, PointerPressedEventArgs e)
    {
        Close(false);
    }

    private void OnCopyClicked(object? sender, PointerPressedEventArgs e)
    {
        _ = CopyToClipboardAsync();
    }

    private void OnSubmitClicked(object? sender, RoutedEventArgs e)
    {
        Close(true);
    }

    private async Task CopyToClipboardAsync()
    {
        if (CopyText is not null && Clipboard is not null)
        {
            await Clipboard.SetTextAsync(CopyText);
        }
    }
}
