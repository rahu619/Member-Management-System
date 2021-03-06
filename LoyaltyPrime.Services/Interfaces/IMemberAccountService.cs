using LoyaltyPrime.Core.Models;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    public interface IMemberAccountService
    {
        Task<int> AddMemberAccountAsync(MemberAccount memberAccount);
        Task<int> AddToBalance(MemberAccount memberAccount, int points);
        Task<int> DeductFromBalance(MemberAccount memberAccount, int points);

    }
}
