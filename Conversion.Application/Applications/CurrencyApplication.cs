using System.Threading.Tasks;
using Conversion.Application.Interfaces;
using Conversion.Application.ViewModel;
using Conversion.CrossCutting.Helpers;
using Conversion.Domain.Models;
using Services.Interfaces;

namespace Conversion.Application.Applications
{
    public class CurrencyApplication : ICurrencyApplication
    {
        private readonly ICurrencyService _currencyService;
        private readonly IHelper _helper;

        public CurrencyApplication(ICurrencyService currencyService, IHelper helper)
        {
            _currencyService = currencyService;
            _helper = helper;
        }


        public async Task<CurrencyViewModel> GetComparativeCurrency(string coinSource, string coinTo)
        {
            var response = await _currencyService.GetComparativeCurrency(coinSource, coinTo);

            var vm = new CurrencyViewModel {Currency = new Currency()};

            if (response.Success)
            {
                vm.Currency = _helper.AdjustCurrency(_helper.ConvertDictionaryToCurrency(response.Quotes));
                return vm;
            }

            vm.Validation.IsSuccess = false;
            vm.Validation.Message = response.Error.Info;
            return vm;
        }
    }
}