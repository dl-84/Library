# SiteActionBar — Avalonia Such- und Aktionsleiste

Suchfeld (mit Clear-Icon) + Add/Edit/Delete-Icons als eine Einheit, für die Kopfzeile über Tabellen-/Listenseiten.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\SiteActionBar\SiteActionBar.csproj" />
</ItemGroup>
```

### 2. Namespace importieren

```xml
<!-- YourView.axaml -->
xmlns:sab="using:Controls.SiteActionBar"
```

### 3. Control einsetzen

```xml
<sab:SiteActionBarControl SearchText="{Binding SearchText}"
                          SearchPlaceholder="{loc:Localization Search}"
                          IsActionEnabled="{Binding IsShooterSelected}"
                          AddRequested="OnAddIconPressed"
                          EditRequested="OnEditIconPressed"
                          DeleteRequested="OnDeleteIconPressed" />
```

Code-behind-Handler nehmen `(object? sender, EventArgs e)` entgegen.

---

## Eigenschaften

| Property | Typ | Beschreibung |
|---|---|---|
| `SearchText` | `string?` | Sucheingabe (Two-Way bindbar) |
| `SearchPlaceholder` | `string?` | Platzhaltertext im Suchfeld |
| `IsActionEnabled` | `bool` | Steuert `IsEnabled` von Edit- und Delete-Icon (Default: `false`) |

## Events

| Event | Beschreibung |
|---|---|
| `AddRequested` | Add-Icon geklickt |
| `EditRequested` | Edit-Icon geklickt |
| `DeleteRequested` | Delete-Icon geklickt |

Der Clear-Button im Suchfeld wird intern behandelt (setzt `SearchText` auf `null`), erzeugt kein eigenes Event.
