using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyExchange
{
    class Program
    {
        private static Dictionary<string, string[]> currencyPairs = new Dictionary<string, string[]>();

        static void Main(string[] args)
        {
            string source = "RUB";
            string destination = "SEK";
            
            currencyPairs.Add("USD", new[] { "RUB", "EUR" });
            currencyPairs.Add("RUB", new[] { "USD" });
            currencyPairs.Add("EUR", new[] { "SEK"});
            currencyPairs.Add("SEK", Array.Empty<string>());

            Search(source, destination);
        }

        private static bool Search(string source, string destination)
        {
            int count = 0;
            var searchQueue = new Queue<string>(currencyPairs[source]);
            var searched = new List<string>();
            while (searchQueue.Any())
            {
                var currency = searchQueue.Dequeue();
                if (!searched.Contains(currency))
                {
                    if(Destination(currency, destination))
                    {
                        Console.WriteLine(count);
                        return true;
                    }
                    else
                    {
                        searchQueue = new Queue<string>(searchQueue.Concat(currencyPairs[currency]));
                        searched.Add(currency);
                        count++;
                    }
                }
            }
            return false;
        }
        private static bool Destination(string currency, string destination)
        {
            return currency.Equals(destination);
        }
    }
}
