using LoyaltyPrime.Core.Models;
using System.Threading.Tasks;

namespace LoyaltyPrime.Core.Repository
{
    public interface IMemberAccountRepository : IRepository<MemberAccount>
    {
        Task<int> AddMemberAccountAsync(MemberAccount memberAccount);
        Task<int> UpdateMemberAccountAsync(MemberAccount memberAccount);

        Task<MemberAccount> GetByIDsAsync(int memberID, int accountID);

    }
}
