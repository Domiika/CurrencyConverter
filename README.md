# Currency Converter (C#/.NET Console Application)

A simple console application in **C# (.NET)** that fetches daily exchange rates from the **Czech National Bank (CNB)** and allows currency conversion between supported currencies.

## Features
- Fetches daily exchange rates from the official CNB API using **HttpClient**
- Parses data with **CsvHelper** and maps them into strongly typed models
- Uses **ISO 4217 enum** for supported currencies
- Supports conversion between currencies with custom exchange rate logic
- Custom exception handling (`CurrencyNotSupported`, `HostNotReachedException`)

## Technologies
- C# / .NET  
- Visual Studio  
- HttpClient  
- CsvHelper  
- OOP principles  

## Example usage
```csharp
var converter = new CNBCurrencyConverter();
decimal result = converter.Convert(CurrencyCode.USD, CurrencyCode.EUR, 100);
Console.WriteLine($"100 USD = {result} EUR");
How it works
The application requests the daily exchange rate file from CNB (denni_kurz.txt).

Data are parsed using CsvHelper and mapped to the CurrencyRecord model.

Exchange rates are stored in a dictionary for quick lookup.

Conversion between currencies is performed using the stored exchange rates.

Installation & Run
Clone the repository and run with .NET:

bash
Zkopírovat kód
git clone https://github.com/yourusername/CurrencyConverter.git
cd CurrencyConverter
dotnet run
Future improvements
Add command-line interface for user input

Support for historical exchange rates

Unit testing

Call exchange rate services that require an API key

Work with JSON data instead of plain CSV
