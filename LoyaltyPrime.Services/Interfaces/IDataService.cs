using LoyaltyPrime.Core.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyPrime.Services.Interfaces
{
    public interface IDataService
    {
        Task ImportData(IEnumerable<DataMember> members);
    }
}
