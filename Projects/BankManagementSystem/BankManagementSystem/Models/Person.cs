using System.Text.Json.Serialization;

namespace BankManagementSystem.Models
{
    public abstract class Person : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        
        public string FullName2 { get; }

        public DateTimeOffset Birthday { get; set; }

        [JsonIgnore]
        public virtual Branch Branch { get; set; }

        public Guid BranchId { get; set; }
    }
}
