using System.Collections.Generic;

namespace LoyaltyPrime.API.Models
{
    /// <summary>
    /// The data transfer object for Member entity
    /// </summary>
    public class MemberDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public List<MemberAccountDTO> MemberAccounts { get; set; }
    }
}
