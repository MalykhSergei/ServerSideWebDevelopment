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

            request.Credentials = CredentialCache.DefaultCredentials;

            var response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Console.WriteLine();

            using (var dataStream = response.GetResponseStream())
            {
                var responseFromServer = "";

                if (dataStream != null)
                {
                    var reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();
                }

                var countries = JsonConvert.DeserializeObject<List<Country>>(responseFromServer);

                if (countries != null)
                {
                    var sumPopulation = countries.Sum(country => country.Population);
                    Console.WriteLine($"Total population by country: {sumPopulation}");
                    Console.WriteLine();
                }

                Console.WriteLine("List of currencies:");
                Console.WriteLine();

                countries?.ForEach(country => country.Currencies
                     .ForEach(currency => { Console.WriteLine(currency.Name); }));
            }

            response.Close();
        }
    }
}
