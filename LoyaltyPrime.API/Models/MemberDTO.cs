using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoyaltyPrime.API.Models
{
    /// <summary>
    /// The data transfer object for Member entity
    /// </summary>
    public class MemberDTO
    {
        public int ID { get; set; }

        [Required, StringLength(100, ErrorMessage = "First name length can't be more than 100")]
        public string FirstName { get; set; }

        [Required, StringLength(100, ErrorMessage = "Last name length can't be more than 100")]
        public string LastName { get; set; }

        [Required, StringLength(1000)]
        public string Address { get; set; }

        public List<MemberAccountDTO> MemberAccounts { get; set; }
    }
}
