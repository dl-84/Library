# InfoDialog — Avalonia Typ-Dialog

Modaler Dialog für Info- und Warnmeldungen. Zeigt links ein Icon (Farbe und Form vom `IconType` abgeleitet), rechts den Nachrichtentext. Höhe passt sich automatisch dem Inhalt an, Breite ist fest (480 px).

Farben kommen automatisch aus dem Theme via `DynamicResource` — keine Brush-Properties nötig.

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
    CloseText = "Schließen",
    DialogTitle = "Verbindungsfehler",
    IconType = IconType.Warning,
    Message = "Die Verbindung konnte nicht hergestellt werden.",
}.ShowDialog(window);
```

---

## Eigenschaften

| Property | Typ | Beschreibung |
|---|---|---|
| `CloseText` | `string?` | Beschriftung des Schließen-Buttons |
| `DialogTitle` | `string?` | Titeltext im Header |
| `IconType` | `IconType` | `Info` (grün) oder `Warning` (rot) |
| `Message` | `string?` | Nachrichtentext (bricht automatisch um) |

---

## Theme-Ressourcen

Das Control liest folgende Keys via `DynamicResource` aus dem Theme:

| Key | Verwendung |
|---|---|
| `AccentGreenBrush` | Schließen-Button Hintergrund, Info-Icon Farbe |
| `AppBackgroundAltBrush` | Dialog-Hintergrund |
| `ErrorBrush` | Warning-Icon Farbe |
| `PrimaryBrush` | Header-Hintergrund |
| `PrimaryForegroundBrush` | Header- und Button-Textfarbe |
| `TextPrimaryBrush` | Nachrichtentext |
