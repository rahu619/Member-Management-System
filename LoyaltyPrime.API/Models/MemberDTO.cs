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

        [Required, StringLength(200, ErrorMessage = "Name length exceeded!")]
        public string Name { get; set; }

        [Required, StringLength(1000)]
        public string Address { get; set; }

        public List<MemberAccountDTO> MemberAccounts { get; set; }
    }
}
