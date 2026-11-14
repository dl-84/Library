using System;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Themes.Fjord;

public class Fjord : Styles
{
    public Fjord(IServiceProvider? serviceProvider = null)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
