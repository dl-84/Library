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
    /// Defines the <see cref="Items"/> property.
    /// </summary>
    public static readonly StyledProperty<IEnumerable<PackageModel>?> ItemsProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IEnumerable<PackageModel>?
    >(nameof(Items));

    /// <summary>
    /// Defines the <see cref="LicenseColumnHeader"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> LicenseColumnHeaderProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        string?
    >(nameof(LicenseColumnHeader));

    /// <summary>
    /// Defines the <see cref="LinkColumnHeader"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> LinkColumnHeaderProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        string?
    >(nameof(LinkColumnHeader));

    /// <summary>
    /// Defines the <see cref="NameColumnHeader"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> NameColumnHeaderProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        string?
    >(nameof(NameColumnHeader));

    /// <summary>
    /// Defines the <see cref="VersionColumnHeader"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> VersionColumnHeaderProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        string?
    >(nameof(VersionColumnHeader));

    /// <summary>
    /// Initializes a new instance of the <see cref="LicenseTableControl"/> class.
    /// </summary>
    public LicenseTableControl()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gets or sets the items to display as table rows.
    /// </summary>
    public IEnumerable<PackageModel>? Items
    {
        get => GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    /// <summary>
    /// Gets or sets the header text for the license column.
    /// </summary>
    public string? LicenseColumnHeader
    {
        get => GetValue(LicenseColumnHeaderProperty);
        set => SetValue(LicenseColumnHeaderProperty, value);
    }

    /// <summary>
    /// Gets or sets the header text for the link column.
    /// </summary>
    public string? LinkColumnHeader
    {
        get => GetValue(LinkColumnHeaderProperty);
        set => SetValue(LinkColumnHeaderProperty, value);
    }

    /// <summary>
    /// Gets or sets the header text for the name column.
    /// </summary>
    public string? NameColumnHeader
    {
        get => GetValue(NameColumnHeaderProperty);
        set => SetValue(NameColumnHeaderProperty, value);
    }

    /// <summary>
    /// Gets or sets the header text for the version column.
    /// </summary>
    public string? VersionColumnHeader
    {
        get => GetValue(VersionColumnHeaderProperty);
        set => SetValue(VersionColumnHeaderProperty, value);
    }

    /// <inheritdoc />
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == ItemsProperty)
        {
            RowsControl.ItemsSource = change.GetNewValue<IEnumerable<PackageModel>?>();
        }
        else if (change.Property == LicenseColumnHeaderProperty)
        {
            LicenseHeaderText.Text = change.GetNewValue<string?>();
        }
        else if (change.Property == LinkColumnHeaderProperty)
        {
            LinkHeaderText.Text = change.GetNewValue<string?>();
        }
        else if (change.Property == NameColumnHeaderProperty)
        {
            NameHeaderText.Text = change.GetNewValue<string?>();
        }
        else if (change.Property == VersionColumnHeaderProperty)
        {
            VersionHeaderText.Text = change.GetNewValue<string?>();
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
