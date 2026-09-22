# Icons — Avalonia Icon-Geometrien

Stellt wiederverwendbare `StreamGeometry`-Ressourcen für `PathIcon` bereit (z.B. Add, Edit, Delete). Geometrien sind reine Formdaten und damit theme-unabhängig — die Farbgebung (grau normal, Akzentfarbe bei Hover, gedimmt bei `:disabled`) kommt über die `PathIcon.icon-action`-Klasse aus dem Disag-Theme.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\Icons\Icons.csproj" />
</ItemGroup>
```

### 2. In App.axaml registrieren

```xml
<!-- App.axaml -->
<Application xmlns:icons="using:Controls.Icons" ...>
    <Application.Styles>
        <FluentTheme />
        <themes:Disag />
        <icons:Icons />
    </Application.Styles>
</Application>
```

Danach stehen die Geometrien app-weit als `StaticResource` zur Verfügung — keine erneute Einbindung pro View nötig.

### 3. Icon einsetzen

```xml
<PathIcon Classes="icon-action"
          Width="20"
          Height="20"
          Data="{StaticResource EditIcon}"
          PointerPressed="OnEditIconPressed" />
```

Ohne die `icon-action`-Klasse (aus dem Disag-Theme) bleibt das Icon ungefärbt bzw. nutzt die Standard-Vordergrundfarbe von `PathIcon`.

---

## Verfügbare Geometrien

| Resource Key | Bedeutung |
|---|---|
| `AddIcon` | Plus-Symbol (neuer Eintrag) |
| `DatabaseIcon` | Datenbank-Symbol |
| `DeleteIcon` | Papierkorb-Symbol (löschen) |
| `EditIcon` | Stift-Symbol (bearbeiten) |
| `HeartPulseIcon` | Puls-Symbol (Verbindungstest) |
| `NetworkWiredIcon` | Netzwerk-Symbol |

Neue Icons ergänzen: Pfaddaten (`d`-Attribut) aus dem Quell-SVG als `<StreamGeometry x:Key="...">` in `Icons.axaml` einfügen.

---

## Theme-Ressourcen

Die Geometrien selbst lesen keine Theme-Ressourcen. Die zugehörige `PathIcon.icon-action`-Style (Disag-Theme) nutzt:

| Key | Verwendung |
|---|---|
| `TextMutedBrush` | Icon-Farbe im Normalzustand |
| `SecondaryBrush` | Icon-Farbe bei Hover |
