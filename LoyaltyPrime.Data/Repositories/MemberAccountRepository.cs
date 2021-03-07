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
        /// TODO: This method's bit pointless at the moment.
        /// </summary>
        /// <param name="memberAccount"></param>
        /// <returns></returns>
        public async Task<int> AddMemberAccountAsync(MemberAccount memberAccount)
        {
            return await AddAsync(memberAccount);
        }

        /// <summary>
        /// TODO: This method's bit pointless at the moment.
        /// </summary>
        /// <param name="memberAccount"></param>
        /// <returns></returns>
        public async Task<int> UpdateMemberAccountAsync(MemberAccount memberAccount)
        {
            return await UpdateAsync(memberAccount);
        }

        /// <summary>
        /// Retrieves the member account by passing in the composite key (Member & Account key)
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
