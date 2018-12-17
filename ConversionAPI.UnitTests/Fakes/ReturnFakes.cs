using System.Collections.Generic;
using Conversion.Application.ViewModel;
using Conversion.Domain.Models;
using Services.Responses;

namespace ConversionAPI.UnitTests.Fakes
{
    public class ReturnFakes
    {
        public static IList<Coins> GetListCoinsFake()
        {
            var coin1 = new Coins { Description = "Brazilian Real", Initial = "BRL" };
            var coin2 = new Coins { Description = "Chinese Yuan", Initial = "CNY" };

            var coins = new List<Coins> {coin1, coin2};

            return coins;
        }

        public static Coins GetCoinsFake() => new Coins { Description = "Brazilian Real", Initial = "BRL" };

        public static Dictionary<string, string> GetDictionaryCoinsFake()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "BRL", "Brazilian Real" },
                { "CNY", "Chinese Yuan" }
            };

            return dictionary;
        }

        public static Dictionary<string, double> GetDictionaryCurrencyFake()
        {
            var dictionary = new Dictionary<string, double>
            {
                { "BRLUSD", 0.255295 }
            };

            return dictionary;
        }

        public static ResponseCoins GetResponseCoinsTrueFake()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "BRL", "Brazilian Real" },
                { "CNY", "Chinese Yuan" }
            };

            var responseCoins = new ResponseCoins {Currencies = dictionary, Success = true};

            return responseCoins;
        }

        public static ResponseCoins GetResponseCoinsFalseFake()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "BRL", "Brazilian Real" },
                { "CNY", "Chinese Yuan" }
            };

            var responseError = new ResponseError {Info = "Error"};
            var responseCoins = new ResponseCoins {Currencies = dictionary, Success = false, Error = responseError};

            return responseCoins;
        }

        public static ResponseCurrency GetResponseCurrencyTrueFake()
        {
            var dictionary = new Dictionary<string, double>
            {
                { "BRLUSD", 0.255295 }
            };

            var response = new ResponseCurrency { Quotes = dictionary, Success = true };

            return response;
        }

        public static ResponseCurrency GetResponseCurrencyFalseFake()
        {
            var dictionary = new Dictionary<string, double>
            {
                { "BRLUSD", 0.255295 }
            };

            var responseError = new ResponseError { Info = "Error" };
            var response = new ResponseCurrency { Quotes = dictionary, Success = false, Error = responseError};

            return response;
        }

        public static SingleCoinViewModel GetBrazilianCoineFake()
        {
            var coin = new Coins { Initial = "BRL", Description = "Brazilian Real" };
            var vm = new SingleCoinViewModel { Coins = coin };

            return vm;
        }

        public static Currency GetCurrencyCompleteFake() => new Currency {CoinSource = "BRL", CoinTo = "USD", SourceValue = 1, Value = 3.91};

        public static Currency GetCurrencyFake() => new Currency { CoinTo = "BRLUSD", Value = 3.91 };
    }
}