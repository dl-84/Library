# ConfirmDialog — Avalonia Bestätigungsdialog

Modaler Dialog mit Titel, Nachricht und zwei Buttons (Bestätigen / Abbrechen). Gibt `true` zurück wenn bestätigt, `false` bei Abbruch.

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
ConfirmDialog dialog = new ConfirmDialog
{
    AcceptText = "Löschen",
    CancelButtonColor = AppBrush.Green,
    CancelText = "Abbrechen",
    DialogBackground = AppBrush.Background,
    DialogTitle = "Datei löschen",
    ErrorBrush = AppBrush.Error,
    Message = "Diese Aktion kann nicht rückgängig gemacht werden.",
    PrimaryBrush = AppBrush.Primary,
    SecondaryBrush = AppBrush.PrimaryForeground,
};

bool? result = await dialog.ShowDialog<bool?>(window);

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
| `CancelButtonColor` | `IBrush?` | Rahmen- und Textfarbe des Abbrechen-Buttons |
| `CancelText` | `string?` | Beschriftung des Abbrechen-Buttons |
| `DialogBackground` | `IBrush?` | Hintergrundfarbe des Inhaltsbereichs |
| `DialogTitle` | `string?` | Titeltext im Header |
| `ErrorBrush` | `IBrush?` | Hintergrundfarbe des Bestätigen-Buttons |
| `Message` | `string?` | Nachrichtentext im Inhaltsbereich |
| `PrimaryBrush` | `IBrush?` | Hintergrundfarbe des Headers |
| `SecondaryBrush` | `IBrush?` | Vordergrundfarbe auf primären und Error-Hintergründen |

---

## Rückgabewert

| Wert | Bedeutung |
|---|---|
| `true` | Bestätigen-Button geklickt |
| `false` | Abbrechen-Button geklickt |
| `null` | Dialog anderweitig geschlossen |
