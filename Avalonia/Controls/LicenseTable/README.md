# LicenseTable — Avalonia Lizenztabelle

Tabellarisches Control zur Anzeige von NuGet-Paketlizenzen. Zeigt Name, Version, Lizenztyp und Link. Klick auf eine Zeile ohne URL löst das Event `LicenseContentRequested` aus, um den Lizenztext anderweitig anzuzeigen.

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
<lt:LicenseTableControl HeaderBackgroundColor="{DynamicResource PrimaryBrush}"
                        HeaderFontColor="{DynamicResource PrimaryForegroundBrush}"
                        Headers="{Binding ColumnHeaders}"
                        Items="{Binding Packages}"
                        LicenseContentRequested="OnLicenseContentRequested"
                        PrimaryTextColor="{DynamicResource TextPrimaryBrush}"
                        SecondaryTextColor="{DynamicResource TextSecondaryBrush}" />
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
| `HeaderBackgroundColor` | `IBrush?` | Hintergrundfarbe der Kopfzeile |
| `HeaderFontColor` | `IBrush?` | Textfarbe der Kopfzeilen-Labels |
| `Headers` | `IReadOnlyList<string>?` | Spaltenbezeichnungen: [Name, Version, Lizenz, Link] |
| `Items` | `IEnumerable<PackageModel>?` | Anzuzeigende Pakete |
| `PrimaryTextColor` | `IBrush?` | Textfarbe für Name und Version |
| `SecondaryTextColor` | `IBrush?` | Textfarbe für Copyright-Angaben |

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
