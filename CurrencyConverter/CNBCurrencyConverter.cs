using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class CNBCurrencyConverter
    {
        string url = "https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt";
        public Dictionary<string, decimal> rates = new Dictionary<string, decimal>();
        
        public CNBCurrencyConverter()
        {
            Refresh();
        }
        
        public void Refresh()
        {
            using(var client = new HttpClient())
            {
                using(var result = client.GetAsync(url).Result)
                {
                    var response = result.Content.ReadAsStringAsync().Result;
                    ParseToDict(response);
                }
            }
        }

        public void ParseToDict(string response)
        {
            var lines = response.Split('\n');

            foreach (string l in lines.Skip(2))
            {
                var parts = l.Trim().Split('|');
                if (parts.Length != 5) continue;

                decimal amount = decimal.Parse(parts[2], CultureInfo.InvariantCulture);
                decimal rate = decimal.Parse(parts[4], new CultureInfo("cs-CZ"));

                rates[parts[3]] = rate / amount;
            }
        }

        

        public decimal Convert(string fromRate, string toRate, decimal amount = 1)
        {
            decimal result = rates[fromRate] / rates[toRate] * amount;
            return result;
        }
    }
}
