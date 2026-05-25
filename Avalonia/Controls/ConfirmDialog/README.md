# ConfirmDialog — Avalonia Bestätigungsdialog

Modaler Dialog mit Titel, Nachricht und zwei Buttons (Bestätigen / Abbrechen). Gibt `true` zurück wenn bestätigt, `false` bei Abbruch.

Farben kommen automatisch aus dem Theme via `DynamicResource` — keine Brush-Properties nötig.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\ConfirmDialog\ConfirmDialog.csproj" />
</ItemGroup>
```

### 2. Namespace importieren

```csharp
using Controls.ConfirmDialog;
```

### 3. Dialog öffnen

```csharp
bool? result = await new ConfirmDialog
{
    AcceptText = "Löschen",
    CancelText = "Abbrechen",
    DialogTitle = "Datei löschen",
    Message = "Diese Aktion kann nicht rückgängig gemacht werden.",
}.ShowDialog<bool?>(window);

if (result is true)
{
    // Bestätigt
}
```

---

## Eigenschaften

| Property | Typ | Beschreibung |
|---|---|---|
| `AcceptText` | `string?` | Beschriftung des Bestätigen-Buttons |
| `CancelText` | `string?` | Beschriftung des Abbrechen-Buttons |
| `DialogTitle` | `string?` | Titeltext im Header |
| `Message` | `string?` | Nachrichtentext im Inhaltsbereich |

---

## Rückgabewert

| Wert | Bedeutung |
|---|---|
| `true` | Bestätigen-Button geklickt |
| `false` | Abbrechen-Button geklickt |
| `null` | Dialog anderweitig geschlossen |

---

## Theme-Ressourcen

Das Control liest folgende Keys via `DynamicResource` aus dem Theme:

| Key | Verwendung |
|---|---|
| `SecondaryBrush` | Abbrechen-Button Hintergrund |
| `AppBackgroundAltBrush` | Dialog-Hintergrund |
| `ErrorBrush` | Bestätigen-Button Hintergrund |
| `PrimaryBrush` | Header-Hintergrund |
| `PrimaryForegroundBrush` | Header- und Button-Textfarbe |
| `TextPrimaryBrush` | Nachrichtentext |
