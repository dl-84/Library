using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Input;

namespace Controls.SiteActionBar;

/// <inheritdoc/>
public partial class SiteActionBarControl : UserControl
{
    public static readonly StyledProperty<string?> AddTooltipProperty = AvaloniaProperty.Register<
        SiteActionBarControl,
        string?
    >(nameof(AddTooltip));

    public static readonly StyledProperty<string?> DeleteTooltipProperty = AvaloniaProperty.Register<
        SiteActionBarControl,
        string?
    >(nameof(DeleteTooltip));

    public static readonly StyledProperty<string?> EditTooltipProperty = AvaloniaProperty.Register<
        SiteActionBarControl,
        string?
    >(nameof(EditTooltip));

    public static readonly StyledProperty<bool> IsActionEnabledProperty = AvaloniaProperty.Register<
        SiteActionBarControl,
        bool
    >(nameof(IsActionEnabled));

    public static readonly StyledProperty<bool> IsEditEnabledProperty = AvaloniaProperty.Register<
        SiteActionBarControl,
        bool
    >(nameof(IsEditEnabled), true);

    public static readonly IValueConverter IsNotEmptyConverter = new FuncValueConverter<string?, bool>(value =>
        !string.IsNullOrEmpty(value)
    );

    public static readonly StyledProperty<bool> IsRefreshVisibleProperty = AvaloniaProperty.Register<
        SiteActionBarControl,
        bool
    >(nameof(IsRefreshVisible));

    public static readonly StyledProperty<string?> RefreshTooltipProperty = AvaloniaProperty.Register<
        SiteActionBarControl,
        string?
    >(nameof(RefreshTooltip));

    public static readonly StyledProperty<string?> SearchPlaceholderProperty = AvaloniaProperty.Register<
        SiteActionBarControl,
        string?
    >(nameof(SearchPlaceholder));

    public static readonly StyledProperty<string?> SearchTextProperty = AvaloniaProperty.Register<
        SiteActionBarControl,
        string?
    >(nameof(SearchText), defaultBindingMode: BindingMode.TwoWay);

    public SiteActionBarControl()
    {
        InitializeComponent();
    }

    public event EventHandler? AddRequested;

    public event EventHandler? DeleteRequested;

    public event EventHandler? EditRequested;

    public event EventHandler? RefreshRequested;

    public string? AddTooltip
    {
        get => GetValue(AddTooltipProperty);
        set => SetValue(AddTooltipProperty, value);
    }

    public string? DeleteTooltip
    {
        get => GetValue(DeleteTooltipProperty);
        set => SetValue(DeleteTooltipProperty, value);
    }

    public string? EditTooltip
    {
        get => GetValue(EditTooltipProperty);
        set => SetValue(EditTooltipProperty, value);
    }

    public bool IsActionEnabled
    {
        get => GetValue(IsActionEnabledProperty);
        set => SetValue(IsActionEnabledProperty, value);
    }

    public bool IsEditEnabled
    {
        get => GetValue(IsEditEnabledProperty);
        set => SetValue(IsEditEnabledProperty, value);
    }

    public bool IsRefreshVisible
    {
        get => GetValue(IsRefreshVisibleProperty);
        set => SetValue(IsRefreshVisibleProperty, value);
    }

    public string? RefreshTooltip
    {
        get => GetValue(RefreshTooltipProperty);
        set => SetValue(RefreshTooltipProperty, value);
    }

    public string? SearchPlaceholder
    {
        get => GetValue(SearchPlaceholderProperty);
        set => SetValue(SearchPlaceholderProperty, value);
    }

    public string? SearchText
    {
        get => GetValue(SearchTextProperty);
        set => SetValue(SearchTextProperty, value);
    }

    private void OnAddIconPressed(object? sender, PointerPressedEventArgs e)
    {
        AddRequested?.Invoke(this, EventArgs.Empty);
    }

    private void OnClearSearchIconPressed(object? sender, PointerPressedEventArgs e)
    {
        SearchText = null;
    }

    private void OnDeleteIconPressed(object? sender, PointerPressedEventArgs e)
    {
        DeleteRequested?.Invoke(this, EventArgs.Empty);
    }

    private void OnEditIconPressed(object? sender, PointerPressedEventArgs e)
    {
        EditRequested?.Invoke(this, EventArgs.Empty);
    }

    private void OnRefreshIconPressed(object? sender, PointerPressedEventArgs e)
    {
        RefreshRequested?.Invoke(this, EventArgs.Empty);
    }
}
