using LoyaltyPrime.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    /// <summary>
    /// The interface for account service.
    /// </summary>
    public interface IAccountService
    {
        Task<int> AddAccountAsync(Account account);

        Task DeleteAccountAsync(int accountID);

        Task<IEnumerable<Account>> GetAllAccounts();
    }
}
