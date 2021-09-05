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

            var responseFromServer = "";

            var reader = new StreamReader(responseStream!);

            responseFromServer = reader.ReadToEnd();

            var countries = JsonConvert.DeserializeObject<List<Country>>(responseFromServer);

            var sumPopulation = countries!.Sum(country => country.Population);
            Console.WriteLine($"Total population by country: {sumPopulation}");
            Console.WriteLine();

            Console.WriteLine("List of currencies:");
            Console.WriteLine();

            var currencyNamesList = (from country in countries from currency in country.Currencies select currency.Name)
                .Distinct()
                .ToList();

            foreach (var currencyName in currencyNamesList)
            {
                Console.WriteLine(currencyName);
            }
        }
    }
}
