using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace JsonTask
{
    internal class App
    {
        private static void Main()
        {
            var request = WebRequest.Create("https://restcountries.eu/rest/v2/region/americas");

            var response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Console.WriteLine();

            using var responseStream = response.GetResponseStream();

            var reader = new StreamReader(responseStream!);

            var countries = JsonConvert.DeserializeObject<List<Country>>(reader.ReadToEnd());

            Console.WriteLine($"Total population by country: {countries.GetPopulationSum()}");
            Console.WriteLine();

            Console.WriteLine("List of currencies:");
            Console.WriteLine();

            var countryCurrencies = countries.GetCountriesCurrenciesList();
            var currencyNamesSet = new HashSet<string>();

            foreach (var currency in countryCurrencies)
            {
                currencyNamesSet.Add(currency.GetCurrencyNames());
            }

            foreach (var item in currencyNamesSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
