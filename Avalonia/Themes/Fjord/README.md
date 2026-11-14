# Fjord — Avalonia Theme

Eigenständiges Theme auf Grundlage der freigegebenen Fjord-Vorschau, in der
Ressourcen-/Style-Struktur des vorhandenen Disag-Themes. Das Original wird nicht
benötigt und nicht verändert.

## Voraussetzungen

- .NET SDK 10; Zielplattform `net10.0`.
- Avalonia **12.1.1**, Fluent **12.1.1**, Inter **12.1.1**.
- Avalonia.Controls.DataGrid **12.1.2**. Dieses Paket verlangt Avalonia >= 12.1.0;
  die hier verwendete Kombination ist damit kompatibel und wurde kompiliert und geladen.
- NuGet-Zugriff beim ersten Restore.

`Fjord.csproj` bringt alle Theme-Abhängigkeiten transitiv mit. Bestehende
Avalonia-Paketversionen der Anwendung entsprechend vereinheitlichen. Die
Desktop-/Mobile-Plattformpakete bleiben Aufgabe der Anwendung.

## Einbinden

1. Den Ordner `Fjord` in die eigene Solution kopieren, beispielsweise nach
   `Themes\Fjord`.
2. Im Anwendungsprojekt eine `ProjectReference` auf
   `..\Themes\Fjord\Fjord.csproj` hinzufügen.
3. In `App.axaml` den Namespace `xmlns:themes="using:Themes.Fjord"` ergänzen
   und in `Application.Styles` **einmal** `<themes:Fjord />` eintragen.
4. Das bisherige Disag-Theme sowie separat eingebundene `FluentTheme`- und
   DataGrid-Fluent-Styles entfernen: Fjord enthält beide bereits.

Minimales `App.axaml` (Zeilenangaben stehen jeweils links im Begleittext):

| Zeile | XML |
|---|---|
| 1 | `<Application xmlns="https://github.com/avaloniaui"` |
| 2 | ` xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"` |
| 3 | ` xmlns:themes="using:Themes.Fjord"` |
| 4 | ` x:Class="YourApp.App" RequestedThemeVariant="Light">` |
| 5 | `  <Application.Styles>` |
| 6 | `    <themes:Fjord />` |
| 7 | `  </Application.Styles>` |
| 8 | `</Application>` |

Ein vollständiges, direkt kompilierbares Beispiel liegt im benachbarten Projekt
`Fjord.Checks\CheckApp.axaml`; dort sind keine Zeilennummern Teil des Codes.

## Inter

Inter wird über **Avalonia.Fonts.Inter** aus dem NuGet-Paket eingebettet geladen,
nicht über eine lokal installierte Schrift:

`FontBody` und `FontHeading` verweisen beide auf
`avares://Avalonia.Fonts.Inter/Assets#Inter`.

Eine Systeminstallation, CSS, die Base64-Daten der HTML-Vorschau und ein zusätzlicher
`WithInter()`-Aufruf sind nicht notwendig. Bei selbst erstellten Controls diese
Font-Ressourcen verwenden. Die vom Paket mitgelieferte Inter-Lizenz beachten
(SIL Open Font License); Fjord fügt keine eigene Schriftdatei hinzu.

## Light / Dark und Systemmodus

Initial `RequestedThemeVariant="Light"`, `"Dark"` oder `"Default"` am
`Application` setzen. `Default` folgt dem System, soweit die verwendete
Avalonia-Plattform diese Information bereitstellt.

Zur Laufzeit kann die Anwendung `Application.Current!.RequestedThemeVariant`
auf `ThemeVariant.Light`, `ThemeVariant.Dark` oder `ThemeVariant.Default`
setzen (`using Avalonia.Styling`). Die Änderung gehört auf den UI-Thread.
`Window.RequestedThemeVariant` ermöglicht alternativ eine fensterweise Auswahl.

Beide Varianten haben eigene semantische Farbwerte in
`Resources\Colors.axaml`; Brushes und Styles referenzieren diese dynamisch.
Auch die Fluent-Template-Paletten wechseln mit. Für eigene Flächen und Texte
`DynamicResource` statt `StaticResource` verwenden, damit offene Ansichten
beim Wechsel aktualisiert werden.

## Aufbau und Nutzung

Assembly: `Fjord`; Namespace: `Themes.Fjord`; Theme-Klasse:
`Themes.Fjord.Fjord`.

| Pfad | Inhalt |
|---|---|
| `Fjord.axaml` | Fluent, DataGrid, Ressourcen, Control-Styles |
| `Resources\Colors.axaml` | Vollständige Light-/Dark-Paletten |
| `Resources\Brushes.axaml` | Semantische Brushes, bestehende Key-Konventionen |
| `Resources\CornerRadius.axaml` | Controls 5, Karten 8, Badges 4 DIPs |
| `Resources\Font.axaml` | Inter; Größen 12/14/15/18/23/30 |
| `Resources\NavigationItem.axaml` | Bedienbares ListBoxItem-ControlTheme |
| `Resources\Spacing.axaml` | 4/8/12/16/24/32 DIPs, Sidebar 220 DIPs |
| `Styles\*.axaml` | Die 24 Control-Style-Dateien der Vorlage |
| `Preview\Light.png`, `Preview\Dark.png` | Tatsächlich nativ gerenderte Beispielansicht |

Die Standard-Templates von Fluent und DataGrid bleiben erhalten. Nur die
Navigation hat ein eigenes kleines Template; ContentTemplate, Auswahl,
Tastaturbedienung und sichtbarer Fokus bleiben unterstützt. Tooltips unterstützen
auch beliebigen Control-Inhalt, nicht nur Zeichenketten.

Wichtige Ressourcen:

| Schlüssel | Verwendung |
|---|---|
| `AppBackgroundBrush` | App-Canvas |
| `SurfaceBrush`, `SurfaceSubtleBrush` | Karten und Tabellenkopf |
| `TextPrimaryBrush`, `TextSecondaryBrush`, `TextMutedBrush` | Text |
| `PrimaryBrush`, `PrimaryHoverBrush` | Gefüllte Teal-Aktionen |
| `LinkBrush`, `LinkHoverBrush` | Lesbare Akzenttexte auch im Dark-Modus |
| `InputBackgroundBrush`, `InputBorderBrush`, `InputHoverBorderBrush` | Eingaben |
| `NavigationBackgroundBrush`, `NavigationForegroundBrush` | Dunkle Sidebar |
| `NavigationActiveBrush`, `NavigationIndicatorBrush` | Auswahl und 2-DIP-Marker |
| `BadgeSuccessBackgroundBrush`, `BadgeSuccessForegroundBrush` | Erfolgs-Badge |
| `BadgeWarningBackgroundBrush`, `BadgeWarningForegroundBrush` | Wartender Status |

Die historischen `BackgroundWhiteColor`/`SurfaceBrush`-Schlüssel sind **semantische
Flächen**, kein festes Weiß: im Dark-Modus werden sie dunkel. `TextWhiteBrush`
bleibt bewusst weiß, etwa für gefüllte Primärbuttons.

### Klassen

| Element | Klassen / Verhalten |
|---|---|
| `Border` | `card`, `card-error`, `card-success`, `sidebar`, `badge`, `badge waiting` |
| `Button` | Standard primär; `secondary`, `outline`, `outline-blue`, `ghost`, `danger`; `xsmall`, `small`, `large`, `icon` |
| `TextBlock` | `h1`–`h4`, `secondary`, `muted`, `caption`, `label`, `on-dark`, `hint-error`, `hint-success`, `table-header`, `table-link` |
| `TextBox`, `ComboBox` | `error`; TextBox zusätzlich `success`; reguläre Datenvalidierung bleibt erhalten |
| `ListBox` | `nav`, `table-rows` |
| `ListBoxItem` | `navigation-header` für nicht interaktive Gruppenbeschriftung |
| `StackPanel` | `page-content` |
| `ProgressBar` | `primary`, `green`, `success`, `warning`, `error` |
| `PathIcon` | `icon-action`, `icon-danger`, `status-error`, `status-success`; vorhandene Statusklassen bleiben verfügbar |

Die alten Button-Klassen `blue` und `green` ergeben ohne zusätzliche
Farbspezialisierung den primären Fjord-Teal-Look. Feste globale Buttonbreiten
wurden entfernt: Beschriftungen und Übersetzungen dürfen wachsen; die Größenklassen
setzen Mindestbreiten. TextBox hat eine Mindesthöhe statt einer festen Höhe,
damit mehrzeilige Eingaben funktionieren.

### Sidebar und Navigation

Ein `Border` mit `Classes="sidebar"` als linke, über die verfügbare Höhe gestreckte
Spalte verwenden. Es liefert die dunkle Fläche, 220 DIPs Breite und die
Innenabstände. Die Hauptfläche bleibt eigenständig scrollbar; die Sidebar muss
nicht mitrollen. Das Beispiel zeigt eine unten angedockte Verbindungsanzeige.

Darin eine `ListBox` mit `Classes="nav"` und `SelectedIndex` beziehungsweise
`SelectedItem` verwenden. Das `NavigationItem`-Theme wird automatisch auf die
Container angewendet. Bei datengetriebener Navigation wie gewohnt `ItemsSource`
und `ItemTemplate` setzen. Bei externen `ListBoxItem`-Templates kann das Theme
explizit über `Theme="{DynamicResource NavigationItem}"` gesetzt werden.

Der ausgewählte Eintrag besitzt eine **gerade 2-DIP-Linie links über die volle
Höhe**. Die Linie ist ein eigenes Rechteck innerhalb des geclippten, 5 DIPs
gerundeten Roots, keine gebogene Border und kein Inset-Schatten.
Icons können im ItemTemplate mit Text kombiniert werden; das Theme schreibt
keine anwendungsspezifischen Navigationssymbole vor.

Badges sind `Border`-Klassen mit Textinhalt. Für den Statuspunkt wie im Beispiel
eine 5×5-DIP-Ellipse und Text in einem horizontalen StackPanel mit 6 DIPs Abstand
anordnen und den passenden Badge-Foreground-Brush für die Ellipse verwenden.

## Beispiel starten

Theme bauen: `dotnet build Fjord.csproj -c Release`

## Abgrenzung

Das Theme verändert **keine Fenster-Chrome**, Titelleisten, Drag-Bereiche oder
Systembuttons. Die Betriebssystemauswahl und Light/Dark-Werkzeugleiste der
HTML-Vorschau sind keine Produktionsfunktionen. Die Beispielanwendung verwendet
ein normales Avalonia-Fenster; Anwendungen behalten ihre technische Integration.

Native Windows-Starts und Light-/Dark-Inhaltsrendering wurden geprüft. Es wird
keine pixelidentische Umsetzung von HTML-Layout oder OS-Chrome zugesichert.
macOS, Linux, mobile Plattformen und die Integration in die tatsächliche
Produktanwendung wurden nicht ausgeführt.

Keine globalen Formatierer, XamlStyler-Konfigurationen oder externen
Build-Skripte erforderlich. Das Archiv enthält Quellcode, Beispiel und Checks,
keine maschinenabhängigen `bin`-/`obj`-Verzeichnisse.
