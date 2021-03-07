using LoyaltyPrime.Core;
using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Core.Models.Data;
using LoyaltyPrime.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services
{
    public class DataService : IDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DataService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Imports the JSON to member, account, member account tables.
        /// </summary>
        /// <param name="members"></param>
        public async Task ImportData(IEnumerable<DataMember> members)
        {
            //clear existing data?

            foreach (var member in members)
            {
                //As Name will be not a unique property, inserting every single member entry into the system.

                //adding Members
                var memberEntity = new Member { Name = member.Name, Address = member.Address };
                var memberEntityID = await this._unitOfWork.Members.AddMemberAsync(memberEntity);

                //iterating through member accounts
                foreach (var account in member.Accounts)
                {
                    //adding Accounts
                    var accountEntity = new Account { CompanyName = account.Name };
                    var accountEntityID = await this._unitOfWork.Accounts.AddAccountAsync(accountEntity);

                    var memberAccountEntity = new MemberAccount
                    {
                        MemberID = memberEntityID,
                        AccountID = accountEntityID,
                        Balance = account.Balance,
                        IsActive = account.Status == Status.Active
                    };

                    //adding the MemberAccounts
                    await this._unitOfWork.MemberAccounts.AddMemberAccountAsync(memberAccountEntity);
                }


            }
        }
    }
}
