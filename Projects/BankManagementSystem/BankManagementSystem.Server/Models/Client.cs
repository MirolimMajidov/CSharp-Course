using System.Text.Json.Serialization;

namespace BankManagementSystem.Models
{
    public class Client : Person
    {
        public ClientStatus State { get; set; }

        [JsonIgnore]
        public virtual Branch Branch { get; set; }

        public Guid BranchId { get; set; }

        //public List<Transaction> Transactions { get; set; }
    }

    public enum ClientStatus
    {
        Orginization,
        Persion
    }
}
