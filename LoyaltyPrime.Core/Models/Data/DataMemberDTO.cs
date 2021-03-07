using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace LoyaltyPrime.Core.Models.Data
{
    /// <summary>
    /// Import/Export entity
    /// </summary>
    /// <remarks> Using this for import and export funtionalities alone.</remarks>
    public class DataMember
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<DataMemberAccount> Accounts { get; set; }

    }

    public class DataMemberAccount
    {
        public string Name { get; set; }
        public int Balance { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }

    public enum Status { Active, Inactive }

}
