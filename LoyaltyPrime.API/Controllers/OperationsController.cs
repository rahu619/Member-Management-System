using LoyaltyPrime.API.Models;
using LoyaltyPrime.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyPrime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public DataController()
        {

        }

        [HttpPost("import")]
        public void Import([FromBody] MemberDTO member)
        {
            var test = member;
        }

    }
}
