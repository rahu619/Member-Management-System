using LoyaltyPrime.Core.Repository;
using System.Threading.Tasks;

namespace LoyaltyPrime.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork
    {
        IMemberRepository Members { get; }
        IAccountRepository Accounts { get; }
        IMemberAccountRepository MemberAccounts { get; }

        Task<int> CommitAsync();
    }
}
