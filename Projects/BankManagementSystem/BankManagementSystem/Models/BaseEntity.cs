namespace BankManagementSystem.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
