using System.Collections.Generic;

namespace LoyaltyPrime.API.Models
{
    public class AccountDTO
    {
        public string CompanyName { get; set; }
        public List<MemberAccountDTO> MemberAccounts { get; set; }
    }
}
