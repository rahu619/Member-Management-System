using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoyaltyPrime.API.Models;
using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateMemberAccount([FromBody] MemberAccountDTO member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedMember = this._mapper.Map<MemberAccount>(member);
            var ID = await this._memberAccountService.AddMemberAccountAsync(mappedMember);

            return CreatedAtAction(nameof(CreateMemberAccount), ID, member);

        }

        [HttpPut, Route("collect/{points:int}")]
        public async Task<IActionResult> CollectPoints(int points, [FromBody] MemberAccount memberAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._memberAccountService.AddToBalance(memberAccount, points);

            return NoContent();
        }

        [HttpPut, Route("redeem/{points:int}")]
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
