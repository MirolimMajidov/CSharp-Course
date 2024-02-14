namespace BankManagementSystem.Models
{
    public class Department : BaseEntity
    {
        public virtual Bank Bank { get; set; }

        public Guid BankId { get; set; }
    }
}
