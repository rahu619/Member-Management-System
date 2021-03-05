using LoyaltyPrime.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    /// <summary>
    /// 
    /// </summary>
    interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccounts();
    }
}
