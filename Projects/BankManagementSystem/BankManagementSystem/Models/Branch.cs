namespace BankManagementSystem.Models;

public class Branch : BaseEntity
{
    public Branch()
    {
        Workers = new();
        Clients = new();
    }

    public string Address { get; set; }

    public List<Worker> Workers { get; set; }

    public List<Client> Clients { get; set; }
}
