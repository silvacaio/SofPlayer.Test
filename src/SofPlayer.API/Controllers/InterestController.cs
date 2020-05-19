using Microsoft.AspNetCore.Mvc;
using SoftPlayer.Domain.Interest;

namespace SofPlayer.API.Controllers
{    
    [ApiController]
    public class InterestController : ControllerBase
    {
        [Route("taxajuros")]
        [HttpGet]
        public decimal GetInterestRate()
        {
            return InterestRate._valueInterest;
        }
    }
}