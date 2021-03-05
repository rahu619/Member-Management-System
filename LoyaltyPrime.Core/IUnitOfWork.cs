using LoyaltyPrime.Core.Repository;
using System.Threading.Tasks;

namespace LoyaltyPrime.Core
{
    public interface IUnitOfWork
    {
        IMemberRepository Members { get; }
        IAccountRepository Accounts { get; }
        Task<int> CommitAsync();
    }
}
