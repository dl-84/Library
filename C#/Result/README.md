# Result

Eine schlanke C#-Bibliothek für das Result-Pattern. Operationen, die fehlschlagen können, geben anstelle von Exceptions ein `Result<TValue, TError>` zurück — der Fehlerfall wird dadurch im Typsystem sichtbar und muss zwingend behandelt werden.

---

## Typen

### `Result<TValue, TError>`

Repräsentiert das Ergebnis einer Operation, die entweder einen Erfolgswert (`TValue`) oder einen Fehlerwert (`Error<TError>`) enthält.

### `Error<T>`

Ein Wrapper, der den Fehlerfall explizit kennzeichnet. Wird als zweiter Typparameter in `Result<TValue, TError>` eingesetzt — `TError` beschreibt den inneren Typ des Fehlers.

---

## Einbindung

```xml
<!-- YourApp.csproj -->
<ItemGroup>
  <ProjectReference Include="..\Result\Result.csproj" />
</ItemGroup>
```

```csharp
using Result;
```

---

## Grundlegende Verwendung

### Erfolg zurückgeben

```csharp
public Result<User, string> FindUser(int id)
{
    User? user = database.Find(id);

    if (user == null)
    {
        return new Error<string>($"Kein Benutzer mit ID {id} gefunden.");
    }

    return user;
}
```

### Ergebnis auswerten mit `Match`

`Match` erzwingt die Behandlung beider Fälle. Beide Zweige müssen denselben Rückgabetyp haben.

```csharp
string message = FindUser(42).Match(
    user    => $"Gefunden: {user.Name}",
    error   => $"Fehler: {error.Value}"
);
```

---

## Operationen

### `Map` — Erfolgswert transformieren

Wendet eine Funktion auf den Erfolgswert an. Bei einem Fehler wird dieser unverändert durchgereicht.

```csharp
Result<int, string> länge = FindUser(42).Map(user => user.Name.Length);
```

### `AndThen` — Schritte verketten

Führt einen weiteren Schritt aus, der selbst fehlschlagen kann. Schlägt einer der Schritte fehl, wird der Fehler sofort weitergereicht — die nachfolgenden Schritte werden nicht mehr ausgeführt.

```csharp
Result<Invoice, string> rechnung = FindUser(42)
    .AndThen(user => FindAccount(user.AccountId))
    .AndThen(account => GenerateInvoice(account));
```

---

## Fehler prüfen ohne Match

Für einfache Fallunterscheidungen stehen `IsSuccess` und `IsError` zur Verfügung. Der Zugriff auf den Wert selbst ist nur über `Match` möglich.

```csharp
Result<User, string> result = FindUser(42);

if (result.IsError)
{
    // Fehlerbehandlung
}
```

---

## Implizite Konvertierungen

Rückgabewerte lassen sich direkt zurückgeben — ohne explizites Wrappen:

```csharp
// Erfolgswert
return user;

// Fehlerwert
return new Error<string>("Nicht gefunden.");
```

Da C# keine Konversionsketten unterstützt, muss `Error<T>` explizit erzeugt werden — eine direkte Rückgabe des Rohwerts als Fehler ist nicht möglich.
