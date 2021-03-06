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

        public async Task<int> AddMemberAsync(Member member)
        {
            _dbContext.Add(member);
            return await _dbContext.SaveChangesAsync();
        }

    }
}
