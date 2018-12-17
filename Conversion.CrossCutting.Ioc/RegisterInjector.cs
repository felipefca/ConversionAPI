using Conversion.Application.Applications;
using Conversion.Application.Interfaces;
using Conversion.CrossCutting.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;

namespace Conversion.CrossCutting.Ioc
{
    public class RegisterInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<ICoinApplication, CoinApplication>();
            services.AddScoped<ICurrencyApplication, CurrencyApplication>();
            services.AddScoped<IConversionApplication, ConversionApplication>();

            //Services
            services.AddScoped<ICoinService, CoinService>();
            services.AddScoped<ICurrencyService, CurrencyService>();

            //Helper
            services.AddScoped<IHelper, Helper>();
        }
    }
}