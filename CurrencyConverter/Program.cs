using System;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var converter = new CNBCurrencyConverter();

            foreach (var r in converter.rates)
            {
                //Console.WriteLine($"{r.Key} => {r.Value}");
            }

            Console.WriteLine(converter.Convert("USD", "EUR"));
        }
    }
}