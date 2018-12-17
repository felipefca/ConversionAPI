using Conversion.Application.ViewModel;

namespace Conversion.Application.Interfaces
{
    public interface IConversionApplication
    {
        ResultConversionViewModel ConvertToCurrency(ConversionViewModel body);
    }
}