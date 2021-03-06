using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoyaltyPrime.API.Models;
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

        [HttpGet()]
        public ActionResult<IList<MemberDTO>> GetAllMembers()
        {
            List<MemberDTO> members = null;
            return Ok(members);
        }
    }
}
