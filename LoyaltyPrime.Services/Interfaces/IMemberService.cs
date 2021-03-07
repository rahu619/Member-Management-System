using LoyaltyPrime.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    /// <summary>
    /// The interface for member service.
    /// </summary>
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();

        Task<Member> GetMemberAsync(int memberID);

        Task<int> AddMemberAsync(Member member);
    }
}
