namespace BankManagementSystem.Models
{
    public class Department : BaseEntity
    {
        public Bank Bank { get; set; }

        public Guid BankId { get; set; }
    }
}
