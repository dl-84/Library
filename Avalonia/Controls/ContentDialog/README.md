# ContentDialog — Avalonia Inhaltsdialog

Modaler Dialog mit konfigurierbarem Header, beliebigem Inhalt-Control und Schließen-Button. Feste Größe (800 × 650), kein Rückgabewert.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\ContentDialog\ContentDialog.csproj" />
</ItemGroup>
```

### 2. Namespace importieren

```csharp
using Controls.ContentDialog;
```

### 3. Dialog öffnen

```csharp
await new ContentDialog
{
    BackgroundColor = AppBrush.Background,
    CloseButtonColor = AppBrush.Green,
    CloseText = "Schließen",
    DialogContent = myControl,   // beliebiges Avalonia-Control
    DialogTitle = "Einstellungen",
    PrimaryColor = AppBrush.Primary,
    TextColor = AppBrush.PrimaryForeground,
}.ShowDialog(window);
```

Breite überschreiben:

```csharp
new ContentDialog
{
    Width = 1000,
    ...
}
```

---

## Eigenschaften

| Property | Typ | Beschreibung |
|---|---|---|
| `BackgroundColor` | `IBrush?` | Hintergrundfarbe des Inhaltsbereichs |
| `CloseButtonColor` | `IBrush?` | Hintergrundfarbe des Schließen-Buttons |
| `CloseText` | `string?` | Beschriftung des Schließen-Buttons |
| `DialogContent` | `object?` | Control das im Inhaltsbereich angezeigt wird |
| `DialogTitle` | `string?` | Titeltext im Header |
| `PrimaryColor` | `IBrush?` | Hintergrundfarbe des Headers und Schließen-Buttons |
| `TextColor` | `IBrush?` | Vordergrundfarbe auf primären Bereichen |
