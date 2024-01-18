namespace BankManagementSystem.Models
{
    public abstract class Person: BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTimeOffset Birthday { get; set; }
    }
}
