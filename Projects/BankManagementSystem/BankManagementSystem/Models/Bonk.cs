namespace BankManagementSystem.Models;

public class Bonk : BaseEntity
{
    public Bonk()
    {
        Branchs = new();
        Departments = new();
    }

    public string Name { get; set; }

    public string Address { get; set; }

    public List<Branch> Branchs { get; set; }

    public List<Department> Departments { get; set; }
}
