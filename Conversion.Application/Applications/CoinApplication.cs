using System.Collections.Generic;
using System.Threading.Tasks;
using Conversion.Application.Interfaces;
using Conversion.Application.ViewModel;
using Conversion.CrossCutting.Helpers;
using Conversion.Domain.Models;
using Services.Interfaces;

namespace Conversion.Application.Applications
{
    public class CoinApplication : ICoinApplication
    {
        private readonly ICoinService _coinService;
        private readonly IHelper _helpers;

        public CoinApplication(ICoinService coinService, IHelper helpers)
        {
            _coinService = coinService;
            _helpers = helpers;
        }

        public async Task<CoinsViewModel> GetAllCoins()
        {
            var response = await _coinService.GetAllCoins();

            var vm = new CoinsViewModel { Coins = new List<Coins>() };

            if (response.Success)
            {
                vm.Coins = _helpers.ConvertDictionaryTo(response.Currencies);
                return vm;
            }

            vm.Validation.IsSuccess = false;
            vm.Validation.Message = response.Error.Info;
            return vm;
        }

        public SingleCoinViewModel GetBrazilianCoin()
        {
            var coin = new Coins {Initial = "BRL", Description = "Brazilian Real"};
            var vm = new SingleCoinViewModel {Coins = coin};

            return vm;
        }
    }
}