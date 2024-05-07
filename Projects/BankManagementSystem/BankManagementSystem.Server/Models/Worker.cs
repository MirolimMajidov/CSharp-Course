using System.Text.Json.Serialization;

namespace BankManagementSystem.Models;

public class Worker : Person
{
    public string Responsibility { get; set; }

    [JsonIgnore]
    public virtual Branch Branch { get; set; }

    public Guid? BranchId { get; set; }
}
