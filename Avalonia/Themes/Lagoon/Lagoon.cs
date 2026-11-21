using System;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Themes.Lagoon;

public class Lagoon : Styles
{
    public Lagoon(IServiceProvider? serviceProvider = null)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
