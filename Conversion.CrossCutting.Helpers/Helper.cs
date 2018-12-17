using System.Collections.Generic;
using System.Linq;
using Conversion.Domain.Models;

namespace Conversion.CrossCutting.Helpers
{
    public class Helper : IHelper
    {
        public IList<Coins> ConvertDictionaryTo(IDictionary<string, string> dictionary)
            => dictionary.Select(keyValue => new Coins { Initial = keyValue.Key, Description = keyValue.Value }).ToList();

        public Currency ConvertDictionaryToCurrency(IDictionary<string, double> dictionary)
        {
            var currency = new Currency();

            foreach (var item in dictionary)
            {
                currency.CoinTo = item.Key;
                currency.Value = item.Value;
            }

            return currency;
        }

        public Currency AdjustCurrency(Currency currency)
        {
            currency.CoinSource = currency.CoinTo.Substring(0, 3);
            currency.CoinTo = currency.CoinTo.Substring(3);
            currency.SourceValue = 1;

            return currency;
        }

        public double MultiplyAmount(double amount, double value) => amount * value;

        public double CalculateAmount(double amount, double currencySource, double currencyTo) 
            => currencySource.Equals(currencyTo) ? amount : MultiplyAmount(amount, currencyTo);

        public string FormatAmount(double value) => value.ToString("N2");
    }
}