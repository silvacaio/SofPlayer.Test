using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SofPlayer.API.Configurations;
using SoftPlayer.Domain.Interest.Commands;
using SoftPlayer.Domain.Interest.Handlers;

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
            return "https://github.com/silvacaio/SofPlayer.Test";
        }

        [Route("calculajuros")]
        [HttpGet]
        public async Task<IActionResult> CalculateInterestRate([Required]decimal value, [Required]int time)
        {
            try
            {
                var result = await _calculateInterestHandler.Handler(
                    CalculateInterestCommand.CalculateInterestRateCommandFactory.Create(value, time, $"{ConfigurationsValues.SoftPlayerURL}/taxajuros"));

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