namespace LoyaltyPrime.API.Models
{
    /// <summary>
    /// The data transfer object for Member Account entity
    /// </summary>
    public class MemberAccountDTO
    {
        public int MemberID { get; set; }
        public int AccountID { get; set; }
        public int Balance { get; set; }
        public bool IsActive { get; set; }
    }
}
