using LoyaltyPrime.Core.Models;
using System.Collections;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    public interface IMemberService
    {
        Task<IEnumerable> GetAllMembersAsync();

        Task<int> AddMemberAsync(Member member);
    }
}
