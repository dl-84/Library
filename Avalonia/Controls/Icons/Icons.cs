using System;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Controls.Icons;

public class Icons : Styles
{
    public Icons(IServiceProvider? serviceProvider = null)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
