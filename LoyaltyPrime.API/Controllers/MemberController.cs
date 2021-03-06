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
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        public MemberController(IMemberService memberService, IMapper mapper)
        {
            this._memberService = memberService;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IList<MemberDTO>>> GetAllMembers()
        {
            var members = await this._memberService.GetAllMembersAsync();
            return Ok(members);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMember([FromBody] MemberDTO member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedMember = this._mapper.Map<MemberDTO, Member>(member);
            var ID = await this._memberService.AddMemberAsync(mappedMember);

            return CreatedAtAction(nameof(CreateMember), ID, member);

        }
    }
}
