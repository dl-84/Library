# TextEditor — Avalonia JSON-Editor

Wrapper um AvaloniaEdit mit JSON-Syntax-Highlighting (TextMate, LightPlus-Theme), Zeilennummern und optionalem Read-only-Modus. Unterstützt Two-Way-Binding auf `Text` und meldet Änderungen über `IsModified`.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\TextEditor\TextEditor.csproj" />
</ItemGroup>
```

### 2. Namespace importieren

```xml
<!-- YourView.axaml -->
xmlns:editor="using:Controls.JsonEditor"
```

### 3. Control einsetzen

```xml
<editor:JsonEditorControl Text="{Binding JsonContent}"
                          IsReadOnly="False" />
```

### 4. Code-behind (optional)

```csharp
JsonEditorControl editor = new JsonEditorControl
{
    IsReadOnly = true,
    Text = jsonString,
};
```

---

## Eigenschaften

| Property | Typ | Bindung | Beschreibung |
|---|---|---|---|
| `Text` | `string` | Two-Way | JSON-Inhalt des Editors |
| `IsReadOnly` | `bool` | One-Way | Sperrt Bearbeitung wenn `true` |
| `IsModified` | `bool` | Read-only | `true` sobald Inhalt seit letztem Laden geändert wurde |

---

## Hinweise

- Hintergrundfarbe ist fest auf `White` gesetzt — passend zum LightPlus TextMate-Theme
- `IsModified` wird automatisch auf `false` zurückgesetzt wenn `Text` von außen gesetzt wird
- Undo-Stack wird beim externen Setzen von `Text` geleert (`MarkAsOriginalFile`)
