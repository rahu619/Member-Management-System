using LoyaltyPrime.Core.Models;
using System.Threading.Tasks;

namespace LoyaltyPrime.Core.Repository
{
    /// <summary>
    /// Interface for Member repository
    /// </summary>
    public interface IMemberRepository : IRepository<Member>
    {
        Task<int> AddMemberAsync(Member member);
    }
}
