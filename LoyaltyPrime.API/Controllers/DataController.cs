using LoyaltyPrime.Core.Models.Data;
using LoyaltyPrime.Core.Models.Parameters;
using LoyaltyPrime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoyaltyPrime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;
        public DataController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        [HttpPost, Route(nameof(Import))]
        public async Task<IActionResult> Import([FromBody] DataMember[] members)
        {
            await this._dataService.ImportData(members);

            return NoContent();
        }

        [HttpGet, Route(nameof(Export))]
        public async Task<IActionResult> Export([FromQuery] MemberParameters memberParameters)
        {
            var result = await this._dataService.ExportData(memberParameters);
            return Ok(result);
        }
    }
}
