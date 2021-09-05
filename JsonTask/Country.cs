using System.Collections.Generic;

namespace JsonTask
{
    internal class Country
    {
        public string Name { get; set; }

        public long Population { get; set; }

        public List<Currency> Currencies { get; set; }
    }
}
