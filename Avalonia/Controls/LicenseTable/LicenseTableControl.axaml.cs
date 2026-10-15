using System;
using System.Collections.Generic;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Controls.LicenseTable.Models;

namespace Controls.LicenseTable;

public partial class LicenseTableControl : UserControl
{
    public static readonly StyledProperty<IReadOnlyList<string>?> HeadersProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IReadOnlyList<string>?
    >(nameof(Headers));

    public static readonly StyledProperty<IEnumerable<PackageModel>?> ItemsProperty = AvaloniaProperty.Register<
        LicenseTableControl,
        IEnumerable<PackageModel>?
    >(nameof(Items));

    public LicenseTableControl()
    {
        InitializeComponent();
    }

    public event EventHandler<string>? LicenseContentRequested;

    public IReadOnlyList<string>? Headers
    {
        get => GetValue(HeadersProperty);
        set => SetValue(HeadersProperty, value);
    }

    public IEnumerable<PackageModel>? Items
    {
        get => GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == HeadersProperty)
        {
            IReadOnlyList<string>? headers = change.GetNewValue<IReadOnlyList<string>?>();
            NameHeaderText.Text = headers?.Count > 0 ? headers[0].ToUpperInvariant() : null;
            VersionHeaderText.Text = headers?.Count > 1 ? headers[1].ToUpperInvariant() : null;
            LicenseHeaderText.Text = headers?.Count > 2 ? headers[2].ToUpperInvariant() : null;
            LinkHeaderText.Text = headers?.Count > 3 ? headers[3].ToUpperInvariant() : null;
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
