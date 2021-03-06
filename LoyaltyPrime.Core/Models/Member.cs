using System.Collections.Generic;

namespace LoyaltyPrime.Core.Models
{
    /// <summary>
    /// The member entity
    /// </summary>
    public class Member
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public ICollection<MemberAccount> MemberAccounts { get; set; }

        /// <summary>
        /// Retrieves fullname of the member.
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";


    }
}
