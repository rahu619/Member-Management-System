using AutoMapper;
using LoyaltyPrime.API.Models;
using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet("{memberID:int}")]
        public async Task<ActionResult<MemberDTO>> GetMemberByID(int memberID)
        {
            if (memberID <= 0)
            {
                return BadRequest("Please enter a valid member ID");
            }
            var members = await this._memberService.GetMemberAsync(memberID);
            return Ok(members);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMember([FromBody] MemberDTO member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //mapping the DTO to entity 
            var mappedMember = this._mapper.Map<Member>(member);

            await this._memberService.AddMemberAsync(mappedMember);

            //reverse mapping the entity back to DTO, for sending the result out to clients.
            member = this._mapper.Map<MemberDTO>(mappedMember);

            return CreatedAtAction(nameof(CreateMember), member);

        }
    }
}
