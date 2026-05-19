using System;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Themes.Disag;

public class Disag : Styles
{
    public Disag(IServiceProvider? serviceProvider = null)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
