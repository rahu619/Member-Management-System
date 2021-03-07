using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Core.Repository;
using System.Threading.Tasks;

namespace LoyaltyPrime.Data.Repositories
{
    /// <summary>
    ///  Repository class for MemberAccount entity
    /// </summary>
    public class MemberAccountRepository : Repository<MemberAccount>, IMemberAccountRepository
    {
        public MemberAccountRepository(LoyaltyPrimeDbContext dbContext) : base(dbContext) { }

        /// <summary>
        /// TODO: To check If it's worth the async call
        /// </summary>
        /// <param name="memberAccount"></param>
        /// <returns></returns>
        public async Task<int> AddMemberAccountAsync(MemberAccount memberAccount)
        {
            return await AddAsync(memberAccount);
        }

        public async Task<int> UpdateMemberAccountAsync(MemberAccount memberAccount)
        {
            return await UpdateAsync(memberAccount);
        }

        /// <summary>
        /// Retrieves the member account by passing in the composite key
        /// ie, Member key and the Account key
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public async Task<MemberAccount> GetByIDsAsync(int memberID, int accountID)
        {
            return await SingleAsync(x => x.MemberID == memberID && x.AccountID == accountID);
        }
    }
}
