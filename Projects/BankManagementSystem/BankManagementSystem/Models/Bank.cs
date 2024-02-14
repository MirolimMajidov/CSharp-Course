using System.Text.Json.Serialization;

namespace BankManagementSystem.Models;

public class Bank : BaseEntity
{
    public Bank()
    {
        Branchs = new();
        Departments = new();
    }

    public string Name { get; set; }

    public string Address { get; set; }

    public virtual List<Branch> Branchs { get; set; }

    [JsonIgnore]
    public virtual List<Department> Departments { get; set; }
}
