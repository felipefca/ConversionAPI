using Conversion.Application.Interfaces;
using Conversion.Application.ViewModel;
using Conversion.CrossCutting.Helpers;

namespace Conversion.Application.Applications
{
    public class ConversionApplication : IConversionApplication
    {
        private readonly IHelper _helper;

        public ConversionApplication(IHelper helper)
        {
            _helper = helper;
        }

        public ResultConversionViewModel ConvertToCurrency(ConversionViewModel body)
        {
            var vm = new ResultConversionViewModel();

            if (body.Amount == 0 || body.Amount < 0)
            {
                vm.Validation.Message = "Valor Inválido";
                vm.Validation.IsSuccess = false;
                return vm;
            }

            vm.Total = _helper.CalculateAmount(body.Amount, body.CurrencySource, body.CurrencyTo);
            vm.Currency = body.CurrencyTo;
            vm.TotalConverted = _helper.FormatAmount(vm.Total);
            vm.Amount = body.Amount;

            return vm;
        }
    }
}