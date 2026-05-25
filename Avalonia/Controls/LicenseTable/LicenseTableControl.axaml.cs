using System;
using System.Collections.Generic;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Controls.LicenseTable.Models;

namespace Controls.LicenseTable;

/// <inheritdoc />
public partial class LicenseTableControl : UserControl
{
    /// <summary>
    /// Defines the <see cref="HeaderBackgroundColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> HeaderBackgroundColorProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IBrush?
    >(nameof(HeaderBackgroundColor));

    /// <summary>
    /// Defines the <see cref="HeaderFontColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> HeaderFontColorProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IBrush?
    >(nameof(HeaderFontColor));

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
    /// Defines the <see cref="PrimaryTextColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> PrimaryTextColorProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IBrush?
    >(nameof(PrimaryTextColor));

    /// <summary>
    /// Defines the <see cref="SecondaryTextColor"/> property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> SecondaryTextColorProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IBrush?
    >(nameof(SecondaryTextColor));

    /// <summary>
    /// Initializes a new instance of the <see cref="LicenseTableControl"/> class.
    /// </summary>
    public LicenseTableControl()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Raised when a row with license content (but no license URL) is clicked.
    /// The event argument is the license content string.
    /// </summary>
    public event EventHandler<string>? LicenseContentRequested;

    /// <summary>
    /// Gets or sets the background color of the header row.
    /// </summary>
    public IBrush? HeaderBackgroundColor
    {
        get => GetValue(HeaderBackgroundColorProperty);
        set => SetValue(HeaderBackgroundColorProperty, value);
    }

    /// <summary>
    /// Gets or sets the foreground color of the header labels.
    /// </summary>
    public IBrush? HeaderFontColor
    {
        get => GetValue(HeaderFontColorProperty);
        set => SetValue(HeaderFontColorProperty, value);
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

    /// <summary>
    /// Gets or sets the foreground color for primary row text (name, version).
    /// </summary>
    public IBrush? PrimaryTextColor
    {
        get => GetValue(PrimaryTextColorProperty);
        set => SetValue(PrimaryTextColorProperty, value);
    }

    /// <summary>
    /// Gets or sets the foreground color for secondary row text (copyright).
    /// </summary>
    public IBrush? SecondaryTextColor
    {
        get => GetValue(SecondaryTextColorProperty);
        set => SetValue(SecondaryTextColorProperty, value);
    }

    /// <inheritdoc />
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == HeaderBackgroundColorProperty)
        {
            HeaderBorder.Background = change.GetNewValue<IBrush?>();
        }
        else if (change.Property == HeaderFontColorProperty)
        {
            IBrush? brush = change.GetNewValue<IBrush?>();
            NameHeaderText.Foreground = brush;
            VersionHeaderText.Foreground = brush;
            LicenseHeaderText.Foreground = brush;
            LinkHeaderText.Foreground = brush;
        }
        else if (change.Property == HeadersProperty)
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
        if (sender is not Control control)
        {
            return;
        }

        if (control.Tag is string url)
        {
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            return;
        }

        if (control.DataContext is PackageModel { LicenseContent: { } content })
        {
            LicenseContentRequested?.Invoke(this, content);
        }
    }
}
