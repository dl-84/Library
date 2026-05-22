using System.Collections;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace Controls.LicenseTable;

/// <inheritdoc />
public partial class LicenseTableControl : UserControl
{
    /// <summary>
    /// Defines the <see cref="ItemsSource"/> property.
    /// </summary>
    public static readonly StyledProperty<IEnumerable?> ItemsSourceProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IEnumerable?
    >(nameof(ItemsSource));

    /// <summary>
    /// Defines the <see cref="ItemTemplate"/> property.
    /// </summary>
    public static readonly StyledProperty<IDataTemplate?> ItemTemplateProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IDataTemplate?
    >(nameof(ItemTemplate));

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
    /// Gets or sets the items source for the table rows.
    /// </summary>
    public IEnumerable? ItemsSource
    {
        get => GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    /// <summary>
    /// Gets or sets the data template used to render each row.
    /// </summary>
    public IDataTemplate? ItemTemplate
    {
        get => GetValue(ItemTemplateProperty);
        set => SetValue(ItemTemplateProperty, value);
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

        if (change.Property == ItemsSourceProperty)
        {
            RowsControl.ItemsSource = change.GetNewValue<IEnumerable?>();
        }
        else if (change.Property == ItemTemplateProperty)
        {
            RowsControl.ItemTemplate = change.GetNewValue<IDataTemplate?>();
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
}
