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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            this._accountService = accountService;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDTO account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedAccount = this._mapper.Map<Account>(account);

            await this._accountService.AddAccountAsync(mappedAccount);

            account = this._mapper.Map<AccountDTO>(mappedAccount);

            return CreatedAtAction(nameof(CreateAccount), account);

        }
    }
}
