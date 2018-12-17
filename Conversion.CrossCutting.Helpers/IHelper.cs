using Conversion.Domain.Models;
using System.Collections.Generic;

namespace Conversion.CrossCutting.Helpers
{
    public interface IHelper
    {
        IList<Coins> ConvertDictionaryTo(IDictionary<string, string> dictionary);
        Currency ConvertDictionaryToCurrency(IDictionary<string, double> dictionary);
        Currency AdjustCurrency(Currency currency);
        double MultiplyAmount(double amount, double value);
        double CalculateAmount(double amount, double currencySource, double currencyTo);
        string FormatAmount(double value);
    }
}