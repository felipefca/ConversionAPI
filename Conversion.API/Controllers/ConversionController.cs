using System.Net;
using Conversion.Application.Interfaces;
using Conversion.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Conversion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionApplication _conversionApplication;

        public ConversionController(IConversionApplication conversionApplication)
        {
            _conversionApplication = conversionApplication;
        }

        /// <summary>
        /// Converts the value to the selected coin
        /// </summary>
        /// <param name="body">Object for conversion</param>
        /// <returns></returns>
        [HttpPost]
        [Route("ConvertToCurrency")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultConversionViewModel), (int)HttpStatusCode.OK)]
        public IActionResult ConvertToCurrency([FromBody]ConversionViewModel body)
        {
            if (body == null)
                return BadRequest();

            var response = _conversionApplication.ConvertToCurrency(body);

            if (!response.Validation.IsSuccess)
                return BadRequest(JsonConvert.SerializeObject(response.Validation.Message));

            return Ok(response);
        }
    }
}