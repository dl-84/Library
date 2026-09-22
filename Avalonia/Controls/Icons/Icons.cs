using System;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Controls.Icons;

/// <summary>
/// Provides shared <see cref="Avalonia.Media.StreamGeometry"/> icon resources (e.g. Add, Edit,
/// Delete) for use with <see cref="Avalonia.Controls.PathIcon"/> across the application.
/// </summary>
public class Icons : Styles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Icons"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public Icons(IServiceProvider? serviceProvider = null)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
