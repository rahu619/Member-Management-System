using System.Collections.Generic;

namespace LoyaltyPrime.Core.Models
{
    /// <summary>
    ///  The account entity.
    /// </summary>
    public class Account
    {
        public int ID { get; set; }

        /// <summary>
        /// The name of the company
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// An account could have multiple member accounts.
        /// </summary>
        public ICollection<MemberAccount> MemberAccounts { get; set; }
    }
}
