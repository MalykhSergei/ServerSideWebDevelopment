using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            var sumPopulation = countries!.Sum(country => country.Population);

            Console.WriteLine($"Total population by country: {sumPopulation}");
            Console.WriteLine();

            Console.WriteLine("List of currencies:");
            Console.WriteLine();

            var currencyNamesList = countries
                .Select(country => country.Currencies
                    .First().Name)
                .Distinct();

            foreach (var currencyName in currencyNamesList)
            {
                Console.WriteLine(currencyName);
            }
        }
    }
}
