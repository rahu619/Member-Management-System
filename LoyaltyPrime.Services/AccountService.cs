using LoyaltyPrime.Core;
using LoyaltyPrime.Core.Models;
using System;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    /// <summary>
    /// The account service entity.
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<int> AddAccountAsync(Account account)
        {
            if (string.IsNullOrEmpty(account.CompanyName))
            {
                throw new Exception("Please enter a valid Account Company name.");
            }
            return await this._unitOfWork.Accounts.AddAsync(account);
        }

    }
}
