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
            _dbContext.Add(memberAccount);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateMemberAccountAsync(MemberAccount memberAccount)
        {
            _dbContext.Update(memberAccount);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
