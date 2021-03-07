using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Core.Repository;
using System.Threading.Tasks;

namespace LoyaltyPrime.Data.Repositories
{
    /// <summary>
    /// The member entity repository
    /// </summary>
    public class MemberRepository : Repository<Member>, IMemberRepository
    {

        public MemberRepository(LoyaltyPrimeDbContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task<int> AddMemberAsync(Member member)
        {
            return await AddAsync(member);
        }

    }
}
