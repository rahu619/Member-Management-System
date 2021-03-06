using System.Collections.Generic;

namespace LoyaltyPrime.Core.Models
{
    /// <summary>
    /// The member account entity
    /// </summary>
    public class MemberAccount
    {
        public int MemberID { get; set; }

        public int AccountID { get; set; }

        public Member Member { get; set; }

        public Account Account { get; set; }

        /// <summary>
        /// The account balance.
        /// Assuming there wouldn't be any float values
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// To determine if the account is still active.
        /// </summary>
        public bool IsActive { get; set; }

    }
}
