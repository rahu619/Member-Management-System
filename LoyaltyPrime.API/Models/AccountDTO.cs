using System.Collections.Generic;

namespace LoyaltyPrime.API.Models
{
    public class AccountDTO
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public List<MemberAccountDTO> MemberAccounts { get; set; }
    }
}
