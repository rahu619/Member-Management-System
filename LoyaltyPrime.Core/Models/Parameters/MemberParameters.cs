using LoyaltyPrime.Core.Models.Data;

namespace LoyaltyPrime.Core.Models.Parameters
{
    /// <summary>
    /// Querystring parameter entity
    /// </summary>
    public class MemberParameters
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Balance { get; set; }
        public Status? Status { get; set; }
        public string Company { get; set; }
    }
}
