namespace BankManagementSystem.Models;

public abstract class BaseEntity
{
    public Guid Id { get; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public override string ToString()
    {
        return $"Id:{ Id} ({GetType().Name})";
    }
}
