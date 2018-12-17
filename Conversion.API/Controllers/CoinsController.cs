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
    public class CoinsController : ControllerBase
    {
        private readonly ICoinApplication _coinApplication;
        public CoinsController(ICoinApplication coinApplication)
        {
            _coinApplication = coinApplication;
        }

        /// <summary>
        /// Returns the list of coins
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllCoins")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CoinsViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCoins()
        {
            var response = await _coinApplication.GetAllCoins();

            if (!response.Validation.IsSuccess)
                return BadRequest();

            return Ok(response.Coins);
        }

        /// <summary>
        /// Returns the list of coins
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBrazilianCoin")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(SingleCoinViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetBrazilianCoin()
        {
            var response = _coinApplication.GetBrazilianCoin();
            return Ok(response.Coins);
        }
    }
}