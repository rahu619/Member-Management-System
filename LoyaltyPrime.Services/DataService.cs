using LoyaltyPrime.Core;
using LoyaltyPrime.Core.Models;
using LoyaltyPrime.Core.Models.Data;
using LoyaltyPrime.Core.Models.Parameters;
using LoyaltyPrime.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        /// <summary>
        /// Export the tables to JSON Data format
        /// </summary>
        /// <param name="memberParameters"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DataMember>> ExportData(MemberParameters memberParameters)
        {
            var filteredMembersTask = await this._unitOfWork.Members.FindAsync(x => string.IsNullOrEmpty(memberParameters.Name) || x.Name == memberParameters.Name);
            var filteredMemberAccountsTask = await this._unitOfWork.MemberAccounts.FindAsync(x => memberParameters.Status.HasValue ? x.IsActive == (memberParameters.Status.Value == Status.Active) : true);
            var filteredAccountsTask = await this._unitOfWork.Accounts.FindAsync(x => string.IsNullOrEmpty(memberParameters.Company) || x.CompanyName.ToLower().Equals(memberParameters.Company.ToLower()));

            //await Task.WhenAll(filteredMembersTask, filteredMemberAccountsTask, filteredAccountsTask);

            var result = (from mem in filteredMembersTask
                          select new DataMember
                          {
                              Name = mem.Name,
                              Address = mem.Address,
                              Accounts = (
                                          from mem_acc in filteredMemberAccountsTask
                                          join acc in filteredAccountsTask
                                          on new { mem_acc.MemberID, mem_acc.AccountID } equals new { MemberID = mem.ID, AccountID = acc.ID }
                                          select new DataMemberAccount
                                          {
                                              Name = acc.CompanyName,
                                              Balance = mem_acc.Balance,
                                              Status = mem_acc.IsActive ? Status.Active : Status.Inactive
                                          }).ToList()
                          }).ToArray();

            return result;

        }

    }
}
