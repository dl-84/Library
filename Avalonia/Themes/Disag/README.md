# Disag — Avalonia UI Theme

Avalonia-Theme auf Basis der DISAG Markenidentität. Enthält Farb-Tokens, Brush-Keys, Typografie und Control-Styles für alle Standard-Controls.

Eine vollständige visuelle Vorschau aller Farben, Komponenten und Klassen ist unter [`Preview/Theme.html`](Preview/Theme.html) verfügbar.

---

## Einbinden

### 1. Projektreferenz hinzufügen

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Themes\Disag\Disag.csproj" />
</ItemGroup>
```

### 2. App.axaml anpassen

```xml
<Application xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:themes="using:Themes.Disag"
             x:Class="YourApp.App"
             RequestedThemeVariant="Light">

    <Application.Styles>
        <FluentTheme />
        <themes:Disag />
    </Application.Styles>

</Application>
```

---

## Farb-Tokens

Rohe `Color`-Werte aus `Colors.axaml`. Direkt verwendbar als `{DynamicResource …Color}`.

### Markenfarben

| Key | Hex | Bedeutung |
|---|---|---|
| `PrimaryDarkColor` | `#012a38` | DISAG Dunkelgrün-Blau (Primärfarbe) |
| `PrimaryDarkerColor` | `#102330` | Hover-Variante von Primary |
| `NearBlackColor` | `#161922` | Nahezu Schwarz (Überschriften) |
| `SecondaryColor` | `#8fbb32` | DISAG Grün (Sekundärfarbe) |
| `SecondaryDarkColor` | `#8bb820` | Hover-Variante von Secondary |
| `TertiaryColor` | `#2aa5b2` | DISAG Cyan (Tertiärfarbe) |
| `TertiaryDarkColor` | `#228893` | Hover-Variante von Tertiary |
| `NavigationActiveColor` | `#1a404c` | Hintergrund des aktiven Navigations-Eintrags |

### Text

| Key | Hex | Bedeutung |
|---|---|---|
| `TextPrimaryColor` | `#333333` | Fließtext |
| `TextSecondaryColor` | `#626262` | Sekundärer Text |
| `TextMutedColor` | `#bbbbbb` | Dezenter Text, Captions |
| `TextDisabledColor` | `#a6a6a6` | Deaktivierter Text |
| `TextOnDarkColor` | `#f9f9f9` | Text auf dunklem Hintergrund |
| `TextWhiteColor` | `#ffffff` | Reines Weiß |
| `TableHeaderTextColor` | `#5e6e78` | Tabellen-Spaltenheader-Text |

### Hintergründe

| Key | Hex | Bedeutung |
|---|---|---|
| `BackgroundWhiteColor` | `#ffffff` | Reiner weißer Hintergrund |
| `BackgroundLightColor` | `#e9ecf1` | Heller App-Hintergrund |
| `BackgroundSubtleColor` | `#f8f8f8` | Sehr subtiler Hintergrund |
| `BackgroundTintedColor` | `#e9f5fc` | Blau getönter Hintergrund (Hover) |
| `BackgroundMutedColor` | `#eef2f5` | Gedämpfter Hintergrund |

### Semantisch

| Key | Hex | Bedeutung |
|---|---|---|
| `SuccessColor` | `#3baf29` | Erfolg |
| `WarningColor` | `#e5b80d` | Warnung |
| `ErrorColor` | `#962317` | Fehler |

### Rahmen

| Key | Hex | Bedeutung |
|---|---|---|
| `BorderLightColor` | `#ebebeb` | Heller Rahmen |
| `BorderMediumColor` | `#cccccc` | Mittlerer Rahmen |
| `BorderDarkColor` | `#012a38` | Dunkler Rahmen (= Primary) |
| `BorderTableColor` | `#d5dae2` | Trennlinie unter Tabellen-Header |

### Sonstige

| Key | Hex | Bedeutung |
|---|---|---|
| `OverlayColor` | `#99000000` | Halbtransparentes Overlay |

---

## Brush-Keys

Fertige `SolidColorBrush`-Instanzen aus `Brushes.axaml`. Für `DynamicResource`-Bindungen in AXAML und `Application.Current.TryGetResource()` in C#.

### App-Hintergrund

| Key | Bedeutung |
|---|---|
| `AppBackgroundBrush` | Haupt-App-Hintergrund (weiß) |
| `AppBackgroundAltBrush` | Alternativer Hintergrund (hellgrau) |
| `AppBackgroundTintBrush` | Blau getönter Hintergrund (Hover, Tint) |

### Surface

| Key | Bedeutung |
|---|---|
| `SurfaceBrush` | Card- und Panel-Hintergrund (weiß) |
| `SurfaceSubtleBrush` | Subtiler Surface-Hintergrund |

### Primär

| Key | Bedeutung |
|---|---|
| `PrimaryBrush` | DISAG Dunkelgrün-Blau |
| `PrimaryForegroundBrush` | Text auf Primary (weiß) |
| `PrimaryHoverBrush` | Primary Hover-Zustand |

### Sekundär (DISAG Grün)

| Key | Bedeutung |
|---|---|
| `SecondaryBrush` | DISAG Grün |
| `SecondaryForegroundBrush` | Text auf Secondary (weiß) |
| `SecondaryHoverBrush` | Secondary Hover-Zustand |

### Tertiär (DISAG Cyan)

| Key | Bedeutung |
|---|---|
| `TertiaryBrush` | DISAG Cyan |
| `TertiaryForegroundBrush` | Text auf Tertiary (weiß) |
| `TertiaryHoverBrush` | Tertiary Hover-Zustand |

### Text

| Key | Bedeutung |
|---|---|
| `TextPrimaryBrush` | Primärer Fließtext |
| `TextSecondaryBrush` | Sekundärer Text |
| `TextMutedBrush` | Dezenter Text, Captions |
| `TextDisabledBrush` | Deaktivierter Text |
| `TextOnDarkBrush` | Text auf dunklem Hintergrund |
| `TextWhiteBrush` | Reines Weiß |
| `TextNearBlackBrush` | Nahezu Schwarz |
| `TableHeaderTextBrush` | Tabellen-Spaltenheader-Text |

### Links

| Key | Bedeutung |
|---|---|
| `LinkBrush` | Link-Farbe (Secondary/Grün) |
| `LinkHoverBrush` | Link Hover-Farbe (Tertiary/Cyan) |

### Eingabefelder

| Key | Bedeutung |
|---|---|
| `InputBackgroundBrush` | Hintergrund von TextBox, ComboBox |
| `InputBorderBrush` | Rahmen im Ruhezustand |
| `InputFocusBorderBrush` | Rahmen bei Fokus (Tertiary/Cyan) |
| `InputForegroundBrush` | Text in Eingabefeldern |
| `InputPlaceholderBrush` | Platzhaltertext |

### Rahmen

| Key | Bedeutung |
|---|---|
| `BorderLightBrush` | Heller Trennrahmen |
| `BorderMediumBrush` | Mittlerer Rahmen |
| `BorderBrandBrush` | Marken-Rahmen (Primary) |
| `BorderTableBrush` | Trennlinie unter Tabellen-Header |

### Navigation

| Key | Bedeutung |
|---|---|
| `NavigationBackgroundBrush` | Navigations-Hintergrund |
| `NavigationForegroundBrush` | Navigations-Text |
| `NavigationActiveBrush` | Aktiver Navigations-Eintrag |
| `NavigationHoverBrush` | Hover-Zustand Navigation |
| `NavigationActiveTextBrush` | Text im aktiven Eintrag |

### Footer

| Key | Bedeutung |
|---|---|
| `FooterBackgroundBrush` | Footer-Hintergrund |
| `FooterForegroundBrush` | Footer-Text |
| `FooterLinkBrush` | Footer-Link |
| `FooterLinkHoverBrush` | Footer-Link Hover |

### Semantisch

| Key | Bedeutung |
|---|---|
| `SuccessBrush` | Erfolg |
| `WarningBrush` | Warnung |
| `ErrorBrush` | Fehler |

### Sonstige

| Key | Bedeutung |
|---|---|
| `OverlayBrush` | Halbtransparentes Dialog-Overlay |

---

## Style-Klassen

### TextBlock

| Klasse | Beschreibung |
|---|---|
| `h1` | Überschrift Ebene 1 (Bold, XLarge) |
| `h2` | Überschrift Ebene 2 (Bold, Large, Primary) |
| `h3` | Überschrift Ebene 3 (SemiBold, MediumLarge, Primary) |
| `h4` | Überschrift Ebene 4 (SemiBold, Medium, Primary) |
| `secondary` | Sekundärer Text (14 px) |
| `muted` | Dezenter Text (12 px) |
| `caption` | Caption (11 px) |
| `label` | Label in Großbuchstaben (11 px, Letter-Spacing, Tertiary) |
| `on-dark` | Text auf dunklem Hintergrund |
| `hint-error` | Fehlerhinweis (12 px, Error) |
| `hint-success` | Erfolgshinweis (12 px, Success) |
| `table-header` | Tabellen-Spaltenheader (FontSizeSmall, Bold, Caps, TableHeader-Foreground) |
| `table-link` | Klickbarer Link in Tabelle (Underline, Tertiary) |

### Button

| Klasse | Beschreibung |
|---|---|
| *(keine)* | Standard-Button (Primary) |
| `accent` | Tertiär/Cyan-Button |
| `green` | Sekundär/Grün-Button |
| `outline` | Umrandeter Button (Primary) |
| `outline-accent` | Umrandeter Button (Tertiary/Cyan) |
| `ghost` | Transparenter Button mit Hover |
| `danger` | Roter Gefahren-Button |
| `small` | Schmalere Breite (120 px) |
| `large` | Breitere Breite (220 px) |

### Border

| Klasse | Beschreibung |
|---|---|
| `card` | Weißer Card-Rahmen mit Border |
| `card-dark` | Dunkle Card (Primary) |
| `card-error` | Rote Card (Error) |
| `card-success` | Grüne Card (Secondary) |
| `card-accent` | Cyan-Card (Tertiary) |

### ProgressBar

| Klasse | Beschreibung |
|---|---|
| *(keine)* | Tertiär/Cyan |
| `primary` | Primary |
| `green` | Sekundär/Grün |
| `success` | Success |
| `warning` | Warning |
| `error` | Error |
