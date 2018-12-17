using System.Net;
using System.Threading.Tasks;
using Conversion.Application.Interfaces;
using Conversion.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conversion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyApplication _currencyApplication;

        public CurrencyController(ICurrencyApplication currencyApplication)
        {
            _currencyApplication = currencyApplication;
        }

        /// <summary>
        /// Returns the value of the currencies for the coins
        /// </summary>
        /// <param name="coinSource">Base coin for comparison</param>
        /// <param name="coinTo">Coin to be compared</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetComparativeCurrency")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CurrencyViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetComparativeCurrency(string coinSource, string coinTo)
        {
            var response = await _currencyApplication.GetComparativeCurrency(coinSource, coinTo);

            if (!response.Validation.IsSuccess)
                return BadRequest();

            return Ok(response.Currency);
        }
    }
}