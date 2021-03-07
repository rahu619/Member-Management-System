using AutoMapper;
using LoyaltyPrime.API.Models;
using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoyaltyPrime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberAccountController : ControllerBase
    {
        private readonly IMemberAccountService _memberAccountService;
        private readonly IMapper _mapper;
        public MemberAccountController(IMemberAccountService memberAccountService, IMapper mapper)
        {
            this._memberAccountService = memberAccountService;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMemberAccount([FromBody] MemberAccountDTO memberAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedMemberAccount = this._mapper.Map<MemberAccount>(memberAccount);

            await this._memberAccountService.AddMemberAccountAsync(mappedMemberAccount);
            
            memberAccount = this._mapper.Map<MemberAccountDTO>(mappedMemberAccount);

            return CreatedAtAction(nameof(CreateMemberAccount), memberAccount);

        }

        [HttpPut, Route("collect")]
        public async Task<IActionResult> CollectPoints(int points, [FromBody] MemberAccount memberAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._memberAccountService.AddToBalance(memberAccount, points);

            return NoContent();
        }

        [HttpPut, Route("redeem")]
        public async Task<IActionResult> RedeemPoints(int points, [FromBody] MemberAccount memberAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //TODO: handle exception
            await this._memberAccountService.DeductFromBalance(memberAccount, points);

            return NoContent();
        }

    }
}
