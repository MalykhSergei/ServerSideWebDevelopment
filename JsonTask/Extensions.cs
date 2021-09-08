using System.Collections.Generic;

namespace JsonTask
{
    public static class Extensions
    {
        public static int GetPopulationSum(this List<Country> countries)
        {
            var result = 0;

            foreach (var country in countries)
            {
                result += country.Population;
            }

            return result;
        }

        public static IEnumerable<List<Currency>> GetCountriesCurrenciesList(this List<Country> countries)
        {
            foreach (var country in countries)
            {
                yield return country.Currencies;
            }
        }

        public static string GetCurrencyNames(this List<Currency> currencies)
        {
            foreach (var currency in currencies)
            {
                return currency.Name;
            }

            return null;
        }
    }
}
