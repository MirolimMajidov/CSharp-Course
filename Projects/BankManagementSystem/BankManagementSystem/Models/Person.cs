using System.Text.Json.Serialization;

namespace BankManagementSystem.Models
{
    public abstract class Person : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        
        public string Username { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public string Role { get; set; }

        public DateTimeOffset Birthday { get; set; }

        [JsonIgnore]
        public virtual Branch Branch { get; set; }

        public Guid BranchId { get; set; }

        public bool IsBlocked { get; }
    }
}
