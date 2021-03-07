using LoyaltyPrime.Core;
using LoyaltyPrime.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<int> AddAccountAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccountAsync(int accountID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAllAccounts()
        {
            //TODO 
            //this._unitOfWork.
            throw new NotImplementedException("Yet to implement!");
        }
    }
}
