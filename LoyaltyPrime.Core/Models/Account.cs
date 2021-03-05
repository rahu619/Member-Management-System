namespace LoyaltyPrime.Core.Models
{
    /// <summary>
    ///  The account entity.
    /// </summary>
    public class Account: Base
    {
        /// <summary>
        /// The name of the company
        /// Ideally this should be an enitity of it's own.
        /// TODO: move it later
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// The account balance.
        /// Assuming there wouldn't be any float values
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// To determine if the account is still active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// Adding for the sake of having one-to-many relationship
        /// </summary>
        public Member Member { get; set; }
    }
}
