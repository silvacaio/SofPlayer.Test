using Microsoft.AspNetCore.Mvc;
using SoftPlayer.Domain.Interest;
using System.Net.Http;

namespace SofPlayer.API.Controllers
{    
    [ApiController]
    public class InterestController : ControllerBase
    {
        [Route("taxajuros")]
        [HttpGet]
        public decimal GetInterestRate()
        {            
            return InterestRate.Value;
        }
    }
}