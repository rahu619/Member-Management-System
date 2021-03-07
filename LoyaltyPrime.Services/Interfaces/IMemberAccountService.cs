using LoyaltyPrime.Core.Models;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    /// <summary>
    /// The interface for member account service.
    /// </summary>
    public interface IMemberAccountService
    {
        Task<int> AddMemberAccountAsync(MemberAccount memberAccount);
        Task<int> AddToBalance(MemberAccount memberAccount, int points);
        Task<int> DeductFromBalance(MemberAccount memberAccount, int points);

    }
}
