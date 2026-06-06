# WaitingDialog — Avalonia Warte-Dialog

Modaler Dialog für laufende Operationen. Zeigt einen Titel, eine indeterminate ProgressBar und einen Statustext. Hat keinen Schließen-Button — wird programmatisch via `Close()` geschlossen.

Farben kommen automatisch aus dem Theme via `DynamicResource` — keine Brush-Properties nötig.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\WaitingDialog\WaitingDialog.csproj" />
</ItemGroup>
```

### 2. Namespace importieren

```csharp
using Controls.WaitingDialog;
```

### 3. Dialog öffnen und schließen

```csharp
WaitingDialog dialog = new WaitingDialog
{
    DialogTitle = "Initialisieren",
    Message = "Datenbank wird initialisiert...",
};

_ = dialog.ShowDialog(window);

// ... nach Abschluss:
dialog.Close();
```

---

## Eigenschaften

| Property | Typ | Beschreibung |
|---|---|---|
| `DialogTitle` | `string?` | Titeltext im Header |
| `Message` | `string?` | Statustext unterhalb der ProgressBar |

---

## Theme-Ressourcen

Das Control liest folgende Keys via `DynamicResource` aus dem Theme:

| Key | Verwendung |
|---|---|
| `AppBackgroundAltBrush` | Dialog-Hintergrund und Header-Hintergrund |
| `BorderMediumBrush` | Trennlinie zwischen Header und Inhalt |
| `PrimaryBrush` | Header-Titelfarbe |
| `TextPrimaryBrush` | Statustext |
