# TitleBar — Avalonia Custom Title Bar

Plattformübergreifendes Custom-Titlebar-Control für Avalonia. Zeigt auf macOS native Traffic-Light-Buttons (SVG, Hover-States), auf Windows/Linux eigene Minimize/Maximize/Close-Icons.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\TitleBar\TitleBar.csproj" />
</ItemGroup>
```

### 2. Window konfigurieren

Das Control erwartet ein Fenster ohne nativen Chrome. Folgende Eigenschaften sind am `Window` erforderlich:

```xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:tb="using:Controls.TitleBar"
        Background="Transparent"
        ExtendClientAreaTitleBarHeightHint="-1"
        ExtendClientAreaToDecorationsHint="True"
        TransparencyLevelHint="Transparent"
        WindowDecorations="None">
```

| Eigenschaft | Wert | Warum |
|---|---|---|
| `Background` | `Transparent` | Fensterbereich außerhalb des Inhalts bleibt transparent |
| `ExtendClientAreaToDecorationsHint` | `True` | Avalonia-Inhalt füllt auch die Titelbereich-Zone |
| `ExtendClientAreaTitleBarHeightHint` | `-1` | Kein reservierter Abstand für nativen Titelbereich |
| `TransparencyLevelHint` | `Transparent` | Ermöglicht abgerundete Ecken auf macOS |
| `WindowDecorations` | `None` | Entfernt nativen Rahmen und Traffic Lights |

### 3. Abgerundete Ecken (plattformabhängig)

Auf Windows/Linux zeigt `CornerRadius` weiße Ecken, da das Fenster keinen transparenten Hintergrund erhält. Den Radius im Code-behind anpassen:

```csharp
// MainWindow.axaml
<Border x:Name="RootBorder"
        ClipToBounds="True"
        CornerRadius="10">
    ...
</Border>
```

```csharp
// MainWindow.axaml.cs
public MainWindow()
{
    InitializeComponent();

    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ||
        RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
    {
        RootBorder.CornerRadius = new CornerRadius(0);
    }
}
```

### 4. Control einsetzen

`TitleBarControl` muss als erstes Kind im `DockPanel` stehen (setzt sich selbst auf `Dock.Top`):

```xml
<Window ...>
    <Border x:Name="RootBorder"
            ClipToBounds="True"
            CornerRadius="10">
        <DockPanel>

            <tb:TitleBarControl BackgroundColor="{DynamicResource AppBackgroundAltBrush}"
                                PrimaryColor="{DynamicResource PrimaryBrush}" />

            <!-- restlicher Inhalt -->

        </DockPanel>
    </Border>
</Window>
```

---

## Eigenschaften

| Property | Typ | Beschreibung |
|---|---|---|
| `PrimaryColor` | `IBrush?` | Hintergrund der Sidebar-Seite (links) und Hover-Hintergrund der Windows-Buttons |
| `BackgroundColor` | `IBrush?` | Hintergrund der Content-Seite (rechts) und Normalzustand der Windows-Buttons |

---

## Plattformverhalten

| | macOS | Windows | Linux |
|---|:---:|:---:|:---:|
| Traffic-Light-Buttons (SVG) | ✓ | — | — |
| Windows-Style Buttons | — | ✓ | ✓ |
| Drag-Bereich | ✓ | ✓ | ✓ |
| Minimize | — * | ✓ | ✓ |
| Maximize / Restore | ✓ | ✓ | ✓ |
| Close | ✓ | ✓ | ✓ |

\* Avalonia kann `miniaturize:` auf macOS mit `WindowDecorations="None"` nicht auslösen (Apple ignoriert den Aufruf bei fensterlosen Fenstern). Der Button ist vorhanden, hat aber keine Funktion.
