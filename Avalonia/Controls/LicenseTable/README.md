# LicenseTable — Avalonia Lizenztabelle

Tabellarisches Control zur Anzeige von NuGet-Paketlizenzen. Zeigt Name, Version, Lizenztyp und Link. Klick auf eine Zeile ohne URL löst das Event `LicenseContentRequested` aus, um den Lizenztext anderweitig anzuzeigen.

Farben kommen automatisch aus dem Theme via `DynamicResource` — keine Brush-Properties nötig.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\LicenseTable\LicenseTable.csproj" />
</ItemGroup>
```

### 2. Namespace importieren

```xml
<!-- YourView.axaml -->
xmlns:lt="using:Controls.LicenseTable"
```

### 3. Control einsetzen

```xml
<lt:LicenseTableControl Headers="{Binding ColumnHeaders}"
                        Items="{Binding Packages}"
                        LicenseContentRequested="OnLicenseContentRequested" />
```

### 4. Event behandeln

```csharp
private void OnLicenseContentRequested(object? sender, string content)
{
    // content enthält den Lizenztext der angeklickten Zeile
}
```

---

## Eigenschaften

| Property | Typ | Beschreibung |
|---|---|---|
| `Headers` | `IReadOnlyList<string>?` | Spaltenbezeichnungen: [Name, Version, Lizenz, Link] |
| `Items` | `IEnumerable<PackageModel>?` | Anzuzeigende Pakete |

---

## Events

| Event | Argument | Beschreibung |
|---|---|---|
| `LicenseContentRequested` | `string` | Wird ausgelöst wenn eine Zeile ohne URL geklickt wird; Argument ist der Lizenztext |

---

## Datenmodell

```csharp
// Controls.LicenseTable.PackageModel
PackageModel
{
    string Name
    string Version
    string LicenseType
    string? LicenseUrl
    string? LicenseContent
}
```

---

## Theme-Ressourcen

Das Control liest folgende Keys via `DynamicResource` aus dem Theme:

| Key | Verwendung |
|---|---|
| `SecondaryBrush` | Header-Hintergrund |
| `SecondaryForegroundBrush` | Header-Textfarbe |
| `TextMutedBrush` | Copyright-Text (sekundär) |
| `TextPrimaryBrush` | Name, Version (primär) |
