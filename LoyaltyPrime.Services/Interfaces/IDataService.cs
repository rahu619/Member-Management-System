using LoyaltyPrime.Core.Models.Data;
using LoyaltyPrime.Core.Models.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services.Interfaces
{
    public interface IDataService
    {
        Task ImportData(IEnumerable<DataMember> members);

        Task<IEnumerable<DataMember>> ExportData(MemberParameters memberParameters);
    }
}
