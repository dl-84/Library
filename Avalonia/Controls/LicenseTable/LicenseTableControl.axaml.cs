using System.Collections.Generic;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace Controls.LicenseTable;

/// <inheritdoc />
public partial class LicenseTableControl : UserControl
{
    /// <summary>
    /// Defines the <see cref="Headers"/> property.
    /// </summary>
    public static readonly StyledProperty<IReadOnlyList<string>?> HeadersProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IReadOnlyList<string>?
    >(nameof(Headers));

    /// <summary>
    /// Defines the <see cref="Items"/> property.
    /// </summary>
    public static readonly StyledProperty<IEnumerable<PackageModel>?> ItemsProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IEnumerable<PackageModel>?
    >(nameof(Items));

    /// <summary>
    /// Initializes a new instance of the <see cref="LicenseTableControl"/> class.
    /// </summary>
    public LicenseTableControl()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gets or sets the column header labels in order: Name, Version, License, Link.
    /// </summary>
    public IReadOnlyList<string>? Headers
    {
        get => GetValue(HeadersProperty);
        set => SetValue(HeadersProperty, value);
    }

    /// <summary>
    /// Gets or sets the items to display as table rows.
    /// </summary>
    public IEnumerable<PackageModel>? Items
    {
        get => GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    /// <inheritdoc />
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == HeadersProperty)
        {
            IReadOnlyList<string>? headers = change.GetNewValue<IReadOnlyList<string>?>();
            NameHeaderText.Text = headers?.Count > 0 ? headers[0] : null;
            VersionHeaderText.Text = headers?.Count > 1 ? headers[1] : null;
            LicenseHeaderText.Text = headers?.Count > 2 ? headers[2] : null;
            LinkHeaderText.Text = headers?.Count > 3 ? headers[3] : null;
        }
        else if (change.Property == ItemsProperty)
        {
            RowsControl.ItemsSource = change.GetNewValue<IEnumerable<PackageModel>?>();
        }
    }

    private void OnPointerLinkClicked(object? sender, PointerPressedEventArgs e)
    {
        if (sender is Control { Tag: string url })
        {
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }
    }
}
