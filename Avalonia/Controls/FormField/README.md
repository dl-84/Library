# FormField — Avalonia Formularfeld

Label + TextBox als eine Einheit, für einfache Eingabeformulare (z.B. in Dialogen). Optional Eingabe-Filterung per Regex-Zeichenmuster.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\FormField\FormField.csproj" />
</ItemGroup>
```

### 2. Namespace importieren

```xml
<!-- YourView.axaml -->
xmlns:ff="using:Controls.FormField"
```

### 3. Control einsetzen

```xml
<ff:FormFieldControl Label="Nachname"
                     Text="{Binding Lastname}" />

<ff:FormFieldControl Label="Geburtsjahr"
                     Text="{Binding Birthyear}"
                     AllowedPattern="[0-9]" />

<ff:FormFieldControl Label="ID"
                     Text="{Binding Id}"
                     IsInputEnabled="False" />
```

---

## Eigenschaften

| Property | Typ | Beschreibung |
|---|---|---|
| `Label` | `string?` | Beschriftungstext über dem Eingabefeld |
| `Text` | `string?` | Eingegebener Wert (Two-Way bindbar) |
| `AllowedPattern` | `string?` | Regex-Zeichenmuster — Tastatureingaben, die nicht matchen, werden blockiert (z.B. `"[0-9]"` für Ziffern) |
| `IsInputEnabled` | `bool` | Eingabefeld aktiv/inaktiv (Default: `true`) |
