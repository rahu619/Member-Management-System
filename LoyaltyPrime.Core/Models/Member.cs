using System.Collections.Generic;

namespace LoyaltyPrime.Core.Models
{
    /// <summary>
    /// The member entity
    /// </summary>
    public class Member
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<MemberAccount> MemberAccounts { get; set; }

    }
}
