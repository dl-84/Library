# ContentDialog — Avalonia Inhaltsdialog

Modaler Dialog mit konfigurierbarem Header, beliebigem Inhalt-Control und Schließen-Button. Feste Größe (800 × 650), kein Rückgabewert.

Farben kommen automatisch aus dem Theme via `DynamicResource` — keine Brush-Properties nötig.

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
    CloseText = "Schließen",
    DialogContent = myControl,   // beliebiges Avalonia-Control
    DialogTitle = "Einstellungen",
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
| `CloseText` | `string?` | Beschriftung des Schließen-Buttons |
| `DialogContent` | `object?` | Control das im Inhaltsbereich angezeigt wird |
| `DialogTitle` | `string?` | Titeltext im Header |

---

## Theme-Ressourcen

Das Control liest folgende Keys via `DynamicResource` aus dem Theme:

| Key | Verwendung |
|---|---|
| `AppBackgroundAltBrush` | Dialog-Hintergrund |
| `SecondaryBrush` | Header-Hintergrund, Schließen-Button Hintergrund |
| `SecondaryForegroundBrush` | Header- und Button-Textfarbe |
