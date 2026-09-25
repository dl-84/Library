# CounterCard — Avalonia Zähler-Kachel

Card mit Icon, Label und Zahlenwert, z.B. für Zähler-Übersichten. Optional in Fehler-Darstellung (Label rot).

Farben kommen automatisch aus dem Theme via `DynamicResource` — keine Brush-Properties nötig.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Controls\CounterCard\CounterCard.csproj" />
</ItemGroup>
```

### 2. Namespace importieren

```xml
<!-- YourView.axaml -->
xmlns:sc="using:Controls.CounterCard"
```

### 3. Control einsetzen

```xml
<sc:CounterCardControl Label="Empfangene Schüsse"
                    Value="{Binding ReceivedShots}" />

<sc:CounterCardControl Label="Analysefehler"
                    Value="{Binding ParsedShotErrors}"
                    IsDanger="True" />
```

---

## Eigenschaften

| Property | Typ | Beschreibung |
|---|---|---|
| `Label` | `string?` | Beschriftungstext links |
| `Value` | `int` | Anzuzeigender Zählerwert rechts |
| `IsDanger` | `bool` | Label rot einfärben (Default: `false`) |
