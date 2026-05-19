# Disag — Avalonia UI Theme

Avalonia-Theme auf Basis der DISAG Markenidentität. Enthält Farb-Tokens, Typografie und Control-Styles für alle Standard-Controls.

Eine vollständige visuelle Vorschau aller Farben, Komponenten und Klassen ist unter [`Preview/Theme.html`](Preview/Theme.html) verfügbar.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Themes\Disag\Disag.csproj" />
</ItemGroup>
```

### 2. App.axaml anpassen

```xml
<Application xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:themes="clr-namespace:Themes.Disag;assembly=Disag"
             x:Class="YourApp.App"
             RequestedThemeVariant="Light">

    <Application.Styles>
        <FluentTheme />
        <themes:Disag />
    </Application.Styles>

</Application>
```
