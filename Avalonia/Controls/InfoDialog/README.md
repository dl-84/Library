# InfoDialog — Avalonia Typ-Dialog

Modaler Dialog für Error-, Warning- und Info-Meldungen. Zeigt links ein Icon (SVG-Pfad, Farbe konfigurierbar), rechts den Nachrichtentext. Höhe passt sich automatisch dem Inhalt an, Breite ist fest (480 px).

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\InfoDialog\InfoDialog.csproj" />
</ItemGroup>
```

### 2. Namespace importieren

```csharp
using Controls.InfoDialog;
```

### 3. Dialog öffnen

```csharp
await new InfoDialog
{
    BackgroundColor = AppBrush.Background,
    CloseButtonColor = AppBrush.Green,
    CloseText = "Schließen",
    DialogTitle = "Verbindungsfehler",
    IconBrush = AppBrush.Error,
    IconData = Geometry.Parse("M12 2 ..."),  // SVG-Pfaddaten
    Message = "Die Verbindung konnte nicht hergestellt werden.",
    PrimaryColor = AppBrush.Primary,
    TextColor = AppBrush.PrimaryForeground,
}.ShowDialog(window);
```

`IconData` kann weggelassen werden — der Platz bleibt dann leer bis SVG-Daten hinterlegt werden.

---

## Eigenschaften

| Property | Typ | Beschreibung |
|---|---|---|
| `BackgroundColor` | `IBrush?` | Hintergrundfarbe des Inhaltsbereichs |
| `CloseButtonColor` | `IBrush?` | Hintergrundfarbe des Schließen-Buttons |
| `CloseText` | `string?` | Beschriftung des Schließen-Buttons |
| `DialogTitle` | `string?` | Titeltext im Header |
| `IconBrush` | `IBrush?` | Füllfarbe des Icons (z. B. `ErrorBrush`, `WarningBrush`, `AccentBrush`) |
| `IconData` | `Geometry?` | SVG-Pfadgeometrie für das Icon |
| `Message` | `string?` | Nachrichtentext (bricht automatisch um) |
| `PrimaryColor` | `IBrush?` | Hintergrundfarbe des Headers |
| `TextColor` | `IBrush?` | Vordergrundfarbe auf primären Bereichen |

---

## Icon-Empfehlungen je Typ

| Typ | `IconBrush` |
|---|---|
| Error | `ErrorBrush` |
| Warning | `WarningBrush` |
| Info | `AccentBrush` |
