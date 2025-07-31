# CatFactsChecker

CatFactsChecker to prosty projekt w .NET, który pobiera losowy fakt o kotach z zewnętrznego API i zapisuje go do pliku `CatFacts.txt`.

## Funkcje:

- Pobieranie losowego faktu o kotach z `https://catfact.ninja/fact`.
- Zapis faktu do pliku tekstowego.
- Testy jednostkowe z wykorzystaniem `xUnit` i `Moq`.

## Struktura

- `ICatFactService` – interfejs serwisu.
- `CatFactService` – serwis z wykorzystaniem `HttpClient`.
- `CatFactServiceTests` – testy jednostkowe.
- `Program.cs` – główna aplikacja.

##  Instalacja i uruchomienie

1. **Sklonuj repozytorium**
   ```bash
   git clone https://github.com/PawDenst/CatFactChecker.git
    ```
   
2. Przejdź do głównego folderu
   ```bash
   cd CatFactChecker/
   ```

3. **Zbuduj projekt**
   ```bash
   dotnet build
   ```

4. **Uruchom aplikację**
   ```bash
   cd CatFact
   dotnet run
   ```

   Fakt o kotach zostanie zapisany do pliku `CatFacts.txt`.

5. **Uruchom testy**
   ```bash
   cd ../CatFact.Tests
   dotnet test
   ```

## Przykładowy zapis w pliku

```
Cats can predict earthquakes. We humans are not 100% sure how they do it. There are several different theories., Length: 111
```

## Technologie

- C#
- .NET 6
- xUnit
- Moq
- HttpClient
- Dependency Injection (DI)

## API źródłowe

Fakty pochodzą z API: [catfact.ninja](https://catfact.ninja/fact)
