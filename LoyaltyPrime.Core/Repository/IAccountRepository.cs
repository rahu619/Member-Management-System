using LoyaltyPrime.Core.Models;
using System.Threading.Tasks;

namespace LoyaltyPrime.Core.Repository
{
    /// <summary>
    /// The interface for Account Repository
    /// </summary>
    public interface IAccountRepository : IRepository<Account>
    {
        Task<int> AddAccountAsync(Account account);
    }
}
