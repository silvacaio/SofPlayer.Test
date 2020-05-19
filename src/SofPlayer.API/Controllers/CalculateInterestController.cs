using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftPlayer.Domain.Interest;
using SoftPlayer.Domain.Interest.Commands;

namespace SofPlayer.API.Controllers
{
    [ApiController]
    public class CalculateInterestController : ControllerBase
    {
        private readonly ICalculateInterestRateHandler _calculateInterestHandler;

        public CalculateInterestController(ICalculateInterestRateHandler calculateInterestHandler)
        {
            _calculateInterestHandler = calculateInterestHandler ?? throw new ArgumentNullException(nameof(calculateInterestHandler));
        }      

        [HttpGet]
        [Route("showmethecode")]
        public string ShowMeTheCode()
        {
            return "https://github.com/silvacaio/calculajuros";
        }

        [Route("calculajuros")]
        [HttpGet]
        public IActionResult CalculateInterestRate([FromQuery] CalculateInterestRateCommand command)
        {
            try
            {
                var result = _calculateInterestHandler.Handler(command);
                if (result.Valid)
                    return Ok(result.Value.ToString("#.00"));

                return BadRequest(result.Error);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}